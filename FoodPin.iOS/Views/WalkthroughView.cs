using System;
using System.Diagnostics;
using FoodPin.Core.ViewModels;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using UIKit;

namespace FoodPin.iOS.Views
{
	public partial class WalkthroughView : MvxViewController, IMvxModalIosView
	{
		public new WalkthroughViewModel ViewModel
		{
			get { return (WalkthroughViewModel)base.ViewModel; }
			set { base.ViewModel = value; }
		}

		public WalkthroughView() : base("WalkthroughView", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			ViewModel.CurrentState = WalkthroughViewModel.Pages.Personalize;

			// Perform any additional setup after loading the view, typically from a nib.
			NavigationController.SetNavigationBarHidden(true, false);
			BindView();

			var swipeLeft = new UISwipeGestureRecognizer((obj) =>
			{
				ViewModel.LeftCommand.Execute(null);
			});
			var swipeRight = new UISwipeGestureRecognizer((obj) =>
			{
			ViewModel.RightCommand.Execute(null);
			});
			swipeLeft.Direction = UISwipeGestureRecognizerDirection.Left;
			swipeRight.Direction = UISwipeGestureRecognizerDirection.Right;
			View.AddGestureRecognizer(swipeLeft);
			View.AddGestureRecognizer(swipeRight);
		}

		public override void ViewWillDisappear(bool animated)
		{
			base.ViewWillDisappear(animated);

			var userDefaults = NSUserDefaults.StandardUserDefaults;
			userDefaults.SetBool(true, "Walkthrough");
		}

		void BindView()
		{
			var Set = this.CreateBindingSet<WalkthroughView, WalkthroughViewModel>();
			Set.Bind(HeadingLabel).To(vm => vm.Title);
			Set.Bind(ContentLabel).To(vm => vm.Content);
			Set.Bind(IntoImageView).To(vm => vm.ImageName).WithConversion("AssetsImage");
			Set.Bind(NextButton).To(vm => vm.NextCommand);
			Set.Bind(NextButton).For("Title").To(vm => vm.NextTitle);
			Set.Bind(PageControl).For(p => p.CurrentPage).To(vm => vm.CurrentState).WithConversion("CurrentState");
			Set.Apply();
		}
	}
}

