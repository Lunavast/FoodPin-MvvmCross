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
		private readonly IDataService _dataService;
		private IMvxMessenger _messenger;
		public IMvxMessenger Messenger
		{
			get { return _messenger; }
			set { _messenger = value; RaisePropertyChanged(() => Messenger); }
		}
		public MapKitViewModel()
		{
			_geoCoder = Mvx.Resolve<IGeoCoderService>();
			_dataService = Mvx.Resolve<IDataService>();
			Messenger = Mvx.Resolve<IMvxMessenger>();
		}
		public RestaurantItem Item { get; private set; }
		public void Init(RestaurantDetailViewModel.Navigation nav)
		{
			Item = _dataService.GetItem(nav.Id);

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
