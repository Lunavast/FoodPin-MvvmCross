using System;
using System.Diagnostics;
using FoodPin.Core.Messenger;
using FoodPin.Core.Models;
using FoodPin.Core.Services;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Plugins.Messenger;

namespace FoodPin.Core.ViewModels
{
	public class MapKitViewModel : MvxViewModel
	{
		private readonly IGeoCoderService _geoCoder;
		private IMvxMessenger _messenger;
		public IMvxMessenger Messenger
		{
			get { return _messenger; }
			set { _messenger = value; RaisePropertyChanged(() => Messenger); }
		}
		public MapKitViewModel()
		{
			_geoCoder = Mvx.Resolve<IGeoCoderService>();
			Messenger = Mvx.Resolve<IMvxMessenger>();
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
					_messenger.Publish(new GeoCodingDoneMessage(this, arg1, arg2, false));
				}
				else 
				{
					_messenger.Publish(new GeoCodingDoneMessage(this, 0, 0, true));
				}
			});
		}
	}
}
