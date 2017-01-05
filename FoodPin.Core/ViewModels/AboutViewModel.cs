using System;
using MvvmCross.Core.ViewModels;

namespace FoodPin.Core.ViewModels
{
	public class AboutViewModel : MvxViewModel
	{
		private string _rateUrl;
		public string RateUrl
		{
			get { return _rateUrl; }
			set { _rateUrl = value; RaisePropertyChanged(() => RateUrl); }
		}

		private string _feedbackUrl;
		public string FeedbackUrl
		{
			get { return _feedbackUrl; }
			set { _feedbackUrl = value; RaisePropertyChanged(() => FeedbackUrl); }
		}

		private string _facebookUrl;
		public string FacebookUrl
		{
			get { return _facebookUrl; }
			set { _facebookUrl = value; RaisePropertyChanged(() => FacebookUrl); }
		}

		private string _twitterUrl;
		public string TwitterUrl
		{
			get { return _twitterUrl; }
			set { _twitterUrl = value; RaisePropertyChanged(() => TwitterUrl); }
		}

		private string _youtubeUrl;
		public string YouTubeUrl
		{
			get { return _youtubeUrl; }
			set { _youtubeUrl = value; RaisePropertyChanged(() => YouTubeUrl); }
		}

		public AboutViewModel()
		{
			RateUrl = "http://www.apple.com/itunes/charts/paid-apps/";
			FeedbackUrl = "https://infusion.com";
			FacebookUrl = "https://www.facebook.com/infusiondevpl/";
			TwitterUrl = "https://twitter.com/infusiontweets";
			YouTubeUrl = "https://www.youtube.com/user/InfusionDevelopment";
		}
	}
}
