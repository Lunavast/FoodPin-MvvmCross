using System;
using System.Diagnostics;
using FoodPin.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using UIKit;

namespace FoodPin.iOS.Views
{
	[MvxFromStoryboard]
	public partial class EditRestaurantView : MvxTableViewController, IMvxModalIosView
	{
		public new EditRestaurantViewModel ViewModel
		{
			get { return (EditRestaurantViewModel)base.ViewModel; }
			set { base.ViewModel = value; }
		}

		public EditRestaurantView(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
			ConfigureNavigationController();
			BindView();

			var TapGesture = new UITapGestureRecognizer((UITapGestureRecognizer obj) =>
			{
				var point = obj.LocationInView(View);
				var indexPath = TableView.IndexPathForRowAtPoint(point);

				if (indexPath.Row == 0)
				{
					StartPicker();
				}
				View.EndEditing(true);
			});
			View.AddGestureRecognizer(TapGesture);
		}

		private UIImagePickerController _imagePicker;
		void StartPicker()
		{
			if (!UIImagePickerController.IsSourceTypeAvailable(UIImagePickerControllerSourceType.Camera))
			{
				StartLibraryPicker();
				return;
			}
			var ActionController = UIAlertController.Create("", "How would you like to add an image?", UIAlertControllerStyle.ActionSheet);
			var CameraAction = UIAlertAction.Create("Take a photo", UIAlertActionStyle.Default, (obj) =>
			{
				StartCameraPicker();
			});
			var LibaryAction = UIAlertAction.Create("Choose from library", UIAlertActionStyle.Default, (obj) =>
{
				StartLibraryPicker();
});
			var CancelAction = UIAlertAction.Create("Cancel", UIAlertActionStyle.Cancel, (obj) => { });

			ActionController.AddAction(CameraAction);
			ActionController.AddAction(LibaryAction);
			ActionController.AddAction(CancelAction);

			this.PresentViewController(ActionController, true, null);
		}


		void StartCameraPicker()
		{
			StartPhotoPicker(UIImagePickerControllerSourceType.Camera);
		}

		void StartLibraryPicker()
		{
			StartPhotoPicker(UIImagePickerControllerSourceType.PhotoLibrary);
		}

		void StartPhotoPicker(UIImagePickerControllerSourceType type)
		{
			_imagePicker = new UIImagePickerController();
			_imagePicker.SourceType = type;
			_imagePicker.MediaTypes = UIImagePickerController.AvailableMediaTypes(UIImagePickerControllerSourceType.PhotoLibrary);

			_imagePicker.FinishedPickingMedia += FinishedPickingMediaHandler;
			_imagePicker.Canceled += CancelationHandler;

			NavigationController.PresentModalViewController(_imagePicker, true);
		}

		void FinishedPickingMediaHandler(object sender, UIImagePickerMediaPickedEventArgs e)
		{
			switch (e.Info[UIImagePickerController.MediaType].ToString())
			{
				case "public.image":
					UIImage originalImage = e.Info[UIImagePickerController.OriginalImage] as UIImage;
					if (originalImage != null)
					{
						ShowPhoto(originalImage);
					}
					break;
				case "public.video":
					Console.WriteLine("Only images are supported");
					break;
			}
			_imagePicker.DismissViewController(true, null);
		}

		void ShowPhoto(UIImage originalImage)
		{
			RestaurantImageView.Image = originalImage;
			RestaurantImageView.ContentMode = UIViewContentMode.ScaleAspectFill;
		}

		void CancelationHandler(object sender, EventArgs e)
		{
			_imagePicker.DismissViewController(true, null);
		}

		private UIBarButtonItem _cancel;
		private UIBarButtonItem _done;
		void ConfigureNavigationController()
		{
			_cancel = new UIBarButtonItem(UIBarButtonSystemItem.Cancel, (sender, e) =>
			{
				ViewModel.CancelCommand.Execute(null);
			});
			this.NavigationItem.LeftBarButtonItem = _cancel;

			_done = new UIBarButtonItem(UIBarButtonSystemItem.Save, (sender, e) =>
			{
				ViewModel.DoneCommand.Execute(null);
			});
			this.NavigationItem.RightBarButtonItem = _done;

			this.NavigationController.NavigationBar.TopItem.Title = "New Restaurant";
		}

		void BindView()
		{
			var BindingSet = this.CreateBindingSet<EditRestaurantView, EditRestaurantViewModel>();

			BindingSet.Bind(NameTextField).To(vm => vm.Item.Name);
			BindingSet.Bind(LocationTextField).To(vm => vm.Item.Location);
			BindingSet.Bind(TypeTextField).To(vm => vm.Item.Type);
			BindingSet.Bind(YesButton).For(b => b.BackgroundColor).To(vm => vm.Item.IsVisited).WithConversion("VisitedColor", true);
			BindingSet.Bind(YesButton).To(vm => vm.IsVisitedCommand);
			BindingSet.Bind(NoButton).For(b => b.BackgroundColor).To(vm => vm.Item.IsVisited).WithConversion("VisitedColor", false);
			BindingSet.Bind(NoButton).To(vm => vm.NotVisitedCommand);
			BindingSet.Apply();
		}


	}
}