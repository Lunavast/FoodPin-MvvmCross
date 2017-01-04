using System;
using System.Collections.Generic;
using System.Windows.Input;
using FoodPin.Core.Messenger;
using FoodPin.Core.Models;
using FoodPin.Core.Services;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Plugins.Messenger;

namespace FoodPin.Core.ViewModels
{
	public class RestaurantListTableViewModel : MvxViewModel
	{
		private List<RestaurantItem> _items;
		public List<RestaurantItem> Items
		{
			get { return _items; }
			set { _items = value; RaisePropertyChanged(() => Items); }
		}

		private readonly IDataService _dataService;
		private readonly MvxSubscriptionToken _token;
		public RestaurantListTableViewModel()
		{
			_dataService = Mvx.Resolve<IDataService>();
			_token = Mvx.Resolve<IMvxMessenger>().Subscribe<DataChangeMessage>(OnDataChange);
			Items = _dataService.AllItems();
		}

		void OnDataChange(DataChangeMessage obj)
		{
			Items = _dataService.AllItems();
		}

		private MvxCommand _showAddCommand;
		public ICommand ShowAddCommand
		{
			get
			{
				_showAddCommand = _showAddCommand ?? new MvxCommand(DoAdd);
				return _showAddCommand;
			}
		}

		private void DoAdd()
		{
			ShowViewModel<EditRestaurantViewModel>();
		}

		public ICommand SelectionChangeCommand
		{
			get
			{
				return new MvxCommand<RestaurantItem>(i => ShowViewModel<RestaurantDetailViewModel>(new RestaurantDetailViewModel.Navigation()
				{
					Id = i.Id
				}));
			}
		}

		public void DeleteItem(RestaurantItem item)
		{
			Items.Remove(item);
		}
	}
}
