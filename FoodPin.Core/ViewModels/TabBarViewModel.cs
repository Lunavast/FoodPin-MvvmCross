using System;
using FoodPin.Core.Services;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace FoodPin.Core.ViewModels
{
	public class TabBarViewModel : MvxViewModel
	{
		public TabBarViewModel()
		{
			RestaurantChildView = new RestaurantListTableViewModel();
		}

		private RestaurantListTableViewModel _restaurantViewModel;
		public RestaurantListTableViewModel RestaurantChildView
		{
			get { return _restaurantViewModel; }
			set { _restaurantViewModel = value; RaisePropertyChanged(() => RestaurantChildView); }
		}
	}
}
