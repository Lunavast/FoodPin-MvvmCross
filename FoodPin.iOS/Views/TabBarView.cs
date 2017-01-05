using System;
using FoodPin.Core.ViewModels;
using Foundation;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Views;
using UIKit;

namespace FoodPin.iOS.Views
{
	[Register("TabBarView")]
	public sealed class TabBarView : MvxTabBarViewController
	{
		public TabBarView()
		{
			ViewDidLoad();
		}

		protected TabBarViewModel ViewModel
		{ get { return base.ViewModel as TabBarViewModel; } }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			if (ViewModel == null)
				return;

			var viewControllers = new UIViewController[]
			{
				CreateTabFor("Favourites", "favourite", ViewModel.RestaurantChildView),
				CreateTabFor("Discover", "discover", ViewModel.DiscoverViewModel),
				CreateTabFor("About", "about", ViewModel.AboutViewModel)
			};
			ViewControllers = viewControllers;
			CustomizableViewControllers = new UIViewController[] { };
			SelectedViewController = ViewControllers[0];
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);

			var userDefaults = NSUserDefaults.StandardUserDefaults;
			if (!userDefaults.BoolForKey("Walkthrough"))
			{
				ViewModel.ShowWalkthrough.Execute(null);
			}
		}

		private int _createdSoFarCount = 0;

		private UIViewController CreateTabFor(string title, string imageName, IMvxViewModel viewModel)
		{
			//var controller = new UINavigationController();
			var screen = this.CreateViewControllerFor(viewModel) as UIViewController;
			SetTitleAndTabBarItem(screen, title, imageName);
			//controller.PushViewController(screen, false);
			return screen;
		}

		void SetTitleAndTabBarItem(UIViewController screen, string title, string imageName)
		{
			screen.Title = title;
			screen.TabBarItem = new UITabBarItem(title, UIImage.FromBundle(imageName), _createdSoFarCount); 
				//UITabBarSystemItem.Favorites, _createdSoFarCount);
			_createdSoFarCount++;
		}
	}
}
