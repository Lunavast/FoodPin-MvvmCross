using System;
using System.Diagnostics;
using System.Windows.Input;
using FoodPin.Core.Models;
using FoodPin.Core.Services;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace FoodPin.Core.ViewModels
{
	public class EditRestaurantViewModel : MvxViewModel
	{
		private readonly IDataService _dataService;
		public EditRestaurantViewModel()
		{
			_dataService = Mvx.Resolve<IDataService>();
		}

		private MvxCommand _cancelCommand;
		public ICommand CancelCommand
		{
			get
			{
				_cancelCommand = _cancelCommand ?? new MvxCommand(DoCancel);
				return _cancelCommand;
			}
		}

		private void DoCancel()
		{
			Close(this);
		}

		private MvxCommand _doneCommand;
		public ICommand DoneCommand
		{
			get
			{
				_doneCommand = _doneCommand ?? new MvxCommand(DoDone);
				return _doneCommand;
			}
		}

		private void DoDone()
		{
			_dataService.AddItem(Item);
			Close(this);
		}

		private RestaurantItem _item = new RestaurantItem();
		public RestaurantItem Item
		{
			get { return _item; }
			set { _item = value; RaisePropertyChanged(() => Item); }
		}

		private MvxCommand _notVisitedCommand;
		public ICommand NotVisitedCommand
		{
			get
			{
				_notVisitedCommand = _notVisitedCommand ?? new MvxCommand(DoNotVisited);
				return _notVisitedCommand;
			}
		}

		private void DoNotVisited()
		{
			Item.IsVisited = false;
			Debug.WriteLine("not visited");
			RaisePropertyChanged(() => Item);
		}

		private MvxCommand _isVisitedCommand;
		public ICommand IsVisitedCommand
		{
			get
			{
				_isVisitedCommand = _isVisitedCommand ?? new MvxCommand(DoIsVisited);
				return _isVisitedCommand;
			}
		}

		private void DoIsVisited()
		{
			Debug.WriteLine("visited");
			Item.IsVisited = true;
			RaisePropertyChanged(() => Item);
		}

		public bool IsValid
		{
			get
			{
				return !string.IsNullOrWhiteSpace(Item.Name) && !string.IsNullOrWhiteSpace(Item.Location) && !string.IsNullOrWhiteSpace(Item.Type);
			}
		}
	}
}
