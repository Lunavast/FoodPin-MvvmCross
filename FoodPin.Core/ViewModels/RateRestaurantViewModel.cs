using System;
using System.Windows.Input;
using FoodPin.Core.Messenger;
using FoodPin.Core.Models;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Plugins.Messenger;

namespace FoodPin.Core.ViewModels
{
	public class RateRestaurantViewModel : MvxViewModel
	{
		private readonly IMvxMessenger _messenger;
		public RateRestaurantViewModel()
		{
			_messenger = Mvx.Resolve<IMvxMessenger>();
		}

		private MvxCommand _closeCommand;
		public ICommand CloseCommand
		{
			get
			{
				_closeCommand = _closeCommand ?? new MvxCommand(DoClose);
				return _closeCommand;
			}
		}

		private void DoClose()
		{
			Close(this);
		}

		private MvxCommand _dislikeCommand;
		public ICommand DislikeCommand
		{
			get
			{
				_dislikeCommand = _dislikeCommand ?? new MvxCommand(DoDislike);
				return _dislikeCommand;
			}
		}

		private void DoDislike()
		{
			_messenger.Publish(new RatingChangeMessage(this, Rating.Dislike));
			DoClose();
		}

		private MvxCommand _goodCommand;
		public ICommand GoodCommand
		{
			get//
			{
				_goodCommand = _goodCommand ?? new MvxCommand(DoGood);
				return _goodCommand;
			}
		}

		private void DoGood()
		{
			_messenger.Publish(new RatingChangeMessage(this, Rating.Good));
			DoClose();
		}
		private MvxCommand _greatCommand;
		public ICommand GreatCommand
		{
			get
			{
				_greatCommand = _greatCommand ?? new MvxCommand(DoGreat);
				return _greatCommand;
			}
		}

		private void DoGreat()
		{
			_messenger.Publish(new RatingChangeMessage(this, Rating.Great));
			DoClose();
		}
	}
}
