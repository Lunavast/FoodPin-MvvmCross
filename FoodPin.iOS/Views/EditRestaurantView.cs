using System;
using FoodPin.Core.ViewModels;
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

			_done = new UIBarButtonItem(UIBarButtonSystemItem.Done, (sender, e) =>
			{
				ViewModel.DoneCommand.Execute(null);
			});
			this.NavigationItem.RightBarButtonItem = _done;
		}

	}
}

