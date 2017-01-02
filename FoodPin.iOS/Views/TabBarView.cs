﻿using System;
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
				CreateTabFor("Tab 1", null, ViewModel.RestaurantChildView)
			};
			ViewControllers = viewControllers;
			CustomizableViewControllers = new UIViewController[] { };
			SelectedViewController = ViewControllers[0];
		}

		private int _createdSoFarCount = 0;

		private UIViewController CreateTabFor(string title, string imageName, IMvxViewModel viewModel)
		{
			var screen = this.CreateViewControllerFor(viewModel) as UIViewController;
			SetTitleAndTabBarItem(screen, title, imageName);
			return screen;
		}

		void SetTitleAndTabBarItem(UIViewController screen, string title, string imageName)
		{
			screen.Title = title;
			screen.TabBarItem = new UITabBarItem(UITabBarSystemItem.Favorites, _createdSoFarCount);
			_createdSoFarCount++;
		}
	}
}
