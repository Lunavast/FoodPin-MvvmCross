using System;
using System.Windows.Input;
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
	}
}
