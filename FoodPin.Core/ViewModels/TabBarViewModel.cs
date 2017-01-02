using System;
using MvvmCross.Core.ViewModels;

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
