using System;
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

			var TapGesture = new UITapGestureRecognizer(() =>
			{
				View.EndEditing(true);
			});
			View.AddGestureRecognizer(TapGesture);
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

