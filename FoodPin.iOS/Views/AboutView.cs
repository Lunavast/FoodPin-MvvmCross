using System;
using FoodPin.Core.ViewModels;
using Foundation;
using MvvmCross.iOS.Views;
using SafariServices;
using UIKit;
using WebKit;

namespace FoodPin.iOS.Views
{
	[Register("AboutView")]
	[MvxFromStoryboard]
	public partial class AboutView : MvxTableViewController
	{
		public new AboutViewModel ViewModel
		{
			get { return (AboutViewModel)base.ViewModel; }
			set { base.ViewModel = value; }
		}


		public AboutView(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			ConfigureTapGestureRecognizer();
		}


		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
			NavigationController.HidesBarsOnSwipe = false;
			this.TabBarController.NavigationItem.RightBarButtonItem = null;
			NavigationController.NavigationBar.TopItem.Title = "About";
		}

		void ConfigureTapGestureRecognizer()
		{
			var TapGesture = new UITapGestureRecognizer((UITapGestureRecognizer obj) =>
			{
				var point = obj.LocationInView(View);
				var indexPath = TableView.IndexPathForRowAtPoint(point);
				if (indexPath.Section == 1)
				{
					if (indexPath.Row == 0)
					{
						var url = new NSUrl(ViewModel.RateUrl);
						UIApplication.SharedApplication.OpenUrl(url);
					}
					else if (indexPath.Row == 1)
					{
						ShowContactWebView();
					}
				}
				else if (indexPath.Section == 2)
				{
					if (indexPath.Row == 0)
					{
						ShowSafariViewController(ViewModel.FacebookUrl);
					}
					else if (indexPath.Row == 1)
					{
						ShowSafariViewController(ViewModel.TwitterUrl);
					}
					else if (indexPath.Row == 2)
					{
						ShowSafariViewController(ViewModel.YouTubeUrl);
					}
				}
			});
			View.AddGestureRecognizer(TapGesture);
		}

		private void ShowContactWebView()
		{
			var contactVC = new UIViewController();
			var WebView = new UIWebView(contactVC.View.Frame);
			contactVC.View.AddSubview(WebView);
			WebView.LoadRequest(new NSUrlRequest(new NSUrl(ViewModel.FacebookUrl)));

			NavigationController.PushViewController(contactVC, true);
		}

		private void ShowSafariViewController(string stringUrl)
		{
			var url = new NSUrl(stringUrl);
			var safariController = new SFSafariViewController(url, true);
			PresentViewController(safariController, true, null);
		}
	}
}
