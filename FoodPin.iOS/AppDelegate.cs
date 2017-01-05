using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Platform;
using MvvmCross.Platform;
using Foundation;
using UIKit;
using MvvmCross.iOS.Views.Presenters;
using FoodPin.iOS.Presenters;

namespace FoodPin.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : MvxApplicationDelegate
	{
		public override UIWindow Window
		{
			get;
			set;
		}

		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			Window = new UIWindow(UIScreen.MainScreen.Bounds);

			var presenter = new NestedModalPresenter(this, Window);
			var setup = new Setup(this, presenter);
			setup.Initialize();

			var startup = Mvx.Resolve<IMvxAppStart>();
			startup.Start();

			Window.MakeKeyAndVisible();

			ConfigureNavigationBar();
			ConfigureTabBar();

			return true;
		}

		private void ConfigureNavigationBar()
		{
			UINavigationBar.Appearance.BarTintColor = UIColor.FromRGB(242.0f / 255.0f, 116.0f / 255.0f, 119.0f / 255.0f);
			UINavigationBar.Appearance.TintColor = UIColor.White;

			var BarFont = UIFont.FromName("Avenir-Light", 24.0f);

			if (BarFont == null)
				return;

			UINavigationBar.Appearance.TitleTextAttributes = new UIStringAttributes()
			{
				ForegroundColor = UIColor.White,
				Font = BarFont
			};
		}

		private void ConfigureTabBar()
		{
			UITabBar.Appearance.TintColor = UIColor.FromRGB(235.0f / 255.0f, 75.0f / 255.0f, 27.0f / 255.0f);
			UITabBar.Appearance.SelectedImageTintColor = UIColor.FromRGB(242.0f / 255.0f, 116.0f / 255.0f, 119.0f / 255.0f);
			//UITabBar.Appearance.SelectionIndicatorImage = UIImage.FromBundle("tabitem-selected");
		}
	}
}