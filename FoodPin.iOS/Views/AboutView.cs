using System;
using FoodPin.Core.ViewModels;
using Foundation;
using MvvmCross.iOS.Views;

namespace FoodPin.iOS.Views
{
	[Register("AboutView")]
	[MvxFromStoryboard]
	public partial class AboutView : MvxTableViewController
	{
		public new AboutViewModel ViewModel
		{
			get { return (AboutViewModel)base.ViewModel; }
			set { base.ViewModel = value; }
		}


		public AboutView(IntPtr handle) : base(handle)
		{
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
			this.TabBarController.NavigationItem.RightBarButtonItem = null;
		}
	}
}
