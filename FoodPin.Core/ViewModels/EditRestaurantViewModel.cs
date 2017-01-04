using System;
using System.Diagnostics;
using System.Windows.Input;
using FoodPin.Core.Models;
using MvvmCross.Core.ViewModels;

namespace FoodPin.Core.ViewModels
{
	public class EditRestaurantViewModel : MvxViewModel
	{
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


	}
}
