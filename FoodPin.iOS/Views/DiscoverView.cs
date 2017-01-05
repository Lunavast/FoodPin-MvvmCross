using System;
using FoodPin.Core.ViewModels;
using Foundation;
using MvvmCross.iOS.Views;

namespace FoodPin.iOS.Views
{
	[Register("DiscoverView")]
	[MvxFromStoryboard]
	public partial class DiscoverView : MvxTableViewController
	{
		public new DiscoverViewModel ViewModel
		{
			get { return (DiscoverViewModel)base.ViewModel; }
			set { base.ViewModel = value; }
		}

		public DiscoverView(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
			this.TabBarController.NavigationItem.RightBarButtonItem = null;
		}
	}
}
