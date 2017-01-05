using System;
using System.Windows.Input;
using FoodPin.Core.Services;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace FoodPin.Core.ViewModels
{
	public class TabBarViewModel : MvxViewModel
	{
		public TabBarViewModel()
		{
			RestaurantChildView = new RestaurantViewModel();
			DiscoverViewModel = new DiscoverViewModel();
			AboutViewModel = new AboutViewModel();
		}

		private RestaurantViewModel _restaurantViewModel;
		public RestaurantViewModel RestaurantChildView
		{
			get { return _restaurantViewModel; }
			set { _restaurantViewModel = value; RaisePropertyChanged(() => RestaurantChildView); }
		}

		private DiscoverViewModel _discoverViewModel;
		public DiscoverViewModel DiscoverViewModel
		{
			get { return _discoverViewModel; }
			set { _discoverViewModel = value; RaisePropertyChanged(() => DiscoverViewModel); }
		}

		private AboutViewModel _aboutViewModel;
		public AboutViewModel AboutViewModel
		{
			get { return _aboutViewModel; }
			set { _aboutViewModel = value; RaisePropertyChanged(() => AboutViewModel); }
		}

		private MvxCommand _showWalkthrough;
		public ICommand ShowWalkthrough
		{
			get
			{
				_showWalkthrough = _showWalkthrough ?? new MvxCommand(DoWalkthrough);
				return _showWalkthrough;
			}
		}

		private void DoWalkthrough()
		{
			ShowViewModel<WalkthroughViewModel>();
		}
	}
}
