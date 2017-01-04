using System;
using System.Diagnostics;
using FoodPin.Core.Models;
using FoodPin.Core.Services;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace FoodPin.Core.ViewModels
{
	public class MapKitViewModel : MvxViewModel
	{
		private readonly IGeoCoderService _geoCoder;
		public MapKitViewModel()
		{
			_geoCoder = Mvx.Resolve<IGeoCoderService>();
		}
		public RestaurantItem Item { get; private set; }
		public void Init(RestaurantDetailViewModel.Navigation nav)
		{
			Item = new RestaurantItem()
			{
				Name = nav.Name,
				Location = nav.Location,
				Type = nav.Type,
				//IsVisited = nav.IsVisited,
				ImageName = nav.ImageName,
				//PhoneNumber = nav.PhoneNumber
			};
			_geoCoder.GeoCodeAddress(Item.Location, (double arg1, double arg2, Exception arg3) =>
			{
				if (arg3 == null)
				{
					Lat = arg1;
					Lng = arg2;
				}
			});
		}

		private double _lat;
		public double Lat
		{
			get { return _lat; }
			set { _lat = value; RaisePropertyChanged(() => Lat); }
		}
		private double _lng;
		public double Lng
		{
			get { return _lng; }
			set { _lng = value; RaisePropertyChanged(() => Lng); }
		}
	}
}
