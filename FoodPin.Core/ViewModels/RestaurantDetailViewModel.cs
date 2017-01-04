using System;
using System.Diagnostics;
using System.Windows.Input;
using FoodPin.Core.Messenger;
using FoodPin.Core.Models;
using FoodPin.Core.Services;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Plugins.Messenger;

namespace FoodPin.Core.ViewModels
{
	public class RestaurantDetailViewModel : MvxViewModel
	{
		private readonly MvxSubscriptionToken _token;
		private readonly IDataService _dataService;
		public RestaurantDetailViewModel()
		{
			IMvxMessenger messenger = Mvx.Resolve<IMvxMessenger>();
			_token = messenger.Subscribe<RatingChangeMessage>(RatingChangeHandler);
			_dataService = Mvx.Resolve<IDataService>();
		}

		void RatingChangeHandler(RatingChangeMessage obj)
		{
			_rating = obj.Rating;
		}

		public class Navigation
		{
			public int Id { get; set; }
			//public string Name { get; set; }
			//public string Location { get; set; }
			//public string Type { get; set; }
			//public bool IsVisited { get; set; }
			//public string ImageName { get; set; }
			//public string PhoneNumber { get; set; }
		}

		public void Init(Navigation nav)
		{
			Item = _dataService.GetItem(nav.Id);
			//Item = new RestaurantItem()
			//{
			//	Name = nav.Name,
			//	Location = nav.Location,
			//	Type = nav.Type,
			//	IsVisited = nav.IsVisited,
			//	ImageName = nav.ImageName,
			//	PhoneNumber = nav.PhoneNumber
			//};
		}

		private RestaurantItem _item;
		public RestaurantItem Item
		{
			get { return _item; }
			set { _item = value; RaisePropertyChanged(() => Item); }
		}

		private string _name;
		public string Name
		{
			get { return _name; }
			set { _name = value; RaisePropertyChanged(() => Name); }
		}

		private string _Location;
		public string Location
		{
			get { return _Location; }
			set { _Location = value; RaisePropertyChanged(() => Location); }
		}

		private string _type;
		public string Type
		{
			get { return _type; }
			set { _type = value; RaisePropertyChanged(() => Type); }
		}

		private MvxCommand _showRating;
		public ICommand ShowRatingCommand
		{
			get
			{
				_showRating = _showRating ?? new MvxCommand(DoShowRating);
				return _showRating;
			}
		}

		private void DoShowRating()
		{
			ShowViewModel<RateRestaurantViewModel>();
		}

		private Rating _rating;
		public Rating Rating
		{
			get { return _rating; }
			set { _rating = value; RaisePropertyChanged(() => Rating); }
		}

		public ICommand ShowMapCommand
		{
			get
			{
				return new MvxCommand(() => ShowViewModel<MapKitViewModel>(new RestaurantDetailViewModel.Navigation()
				{
					Id = Item.Id
				}));
			}
		}
	}
}
