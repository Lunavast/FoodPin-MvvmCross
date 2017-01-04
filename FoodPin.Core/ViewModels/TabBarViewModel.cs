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
			RestaurantChildView = new RestaurantViewModel();
		}

		private RestaurantViewModel _restaurantViewModel;
		public RestaurantViewModel RestaurantChildView
		{
			get { return _restaurantViewModel; }
			set { _restaurantViewModel = value; RaisePropertyChanged(() => RestaurantChildView); }
		}
	}
}
