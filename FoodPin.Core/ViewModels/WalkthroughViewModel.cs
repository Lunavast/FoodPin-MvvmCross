using System;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;

namespace FoodPin.Core.ViewModels
{
	public class WalkthroughViewModel : MvxViewModel
	{
		public enum Pages : int { Personalize = 0, Locate, Discover };

		private Pages _currentState;
		public Pages CurrentState
		{
			get { return _currentState; }
			set { _currentState = value; RaisePropertyChanged(() => CurrentState); SetValues(); }
		}

		private void SetValues()
		{
			switch (CurrentState)
			{
				case Pages.Personalize:
					{
						Title = "Personalize";
						Content = "Pin your favourite restaurants and create your own food guides";
						ImageName = "foodpin-intro-1";
						NextTitle = "NEXT";
						break;
					}
				case Pages.Locate:
					{
						Title = "Locate";
						Content = "Search and located your farourites restaurants on Maps";
						ImageName = "foodpin-intro-2";
						NextTitle = "NEXT";
						break;
					}
				case Pages.Discover:
					{
						Title = "Discover";
						Content = "Find restaurants pinned by your friends and other foodies around the world";
						ImageName = "foodpin-intro-3";
						NextTitle = "DONE";
						break;
					}
			}
		}

		private string _title;
		public string Title
		{
			get { return _title; }
			set { _title = value; RaisePropertyChanged(() => Title); }
		}

		private string _content;
		public string Content
		{
			get { return _content; }
			set { _content = value; RaisePropertyChanged(() => Content); }
		}

		private string _imageName;
		public string ImageName
		{
			get { return _imageName; }
			set { _imageName = value; RaisePropertyChanged(() => ImageName); }
		}

		private string _nextTitle;
		public string NextTitle
		{
			get { return _nextTitle; }
			set { _nextTitle = value; RaisePropertyChanged(() => NextTitle); }
		}

		private MvxCommand _nextCommand;
		public ICommand NextCommand
		{
			get
			{
				_nextCommand = _nextCommand ?? new MvxCommand(DoNext);
				return _nextCommand;
			}
		}

		private void DoNext()
		{
			switch (CurrentState)
			{
				case Pages.Personalize:
					{
						CurrentState = Pages.Locate;
						break;
					}
				case Pages.Locate:
					{
						CurrentState = Pages.Discover;
						break;
					}
				case Pages.Discover:
					{
						Close(this);
						break;
					}
			}
		}

		private MvxCommand _leftCommand;
		public ICommand LeftCommand
		{
			get
			{
				_leftCommand = _leftCommand ?? new MvxCommand(DoLeft);
				return _leftCommand;
			}
		}

		private void DoLeft()
		{
			switch (CurrentState)
			{
				case Pages.Personalize:
					{
						CurrentState = Pages.Locate;
						break;
					}
				case Pages.Locate:
					{
						CurrentState = Pages.Discover;
						break;
					}
				case Pages.Discover:
					{
						break;
					}
			}
		}

		private MvxCommand _rightCommand;
		public ICommand RightCommand
		{
			get
			{
				_rightCommand = _rightCommand ?? new MvxCommand(DoRight);
				return _rightCommand;
			}
		}

		private void DoRight()
		{
			switch (CurrentState)
			{
				case Pages.Personalize:
					{
						break;
					}
				case Pages.Locate:
					{
						CurrentState = Pages.Personalize;
						break;
					}
				case Pages.Discover:
					{
						CurrentState = Pages.Locate;
						break;
					}
			}
		}
	}
}
