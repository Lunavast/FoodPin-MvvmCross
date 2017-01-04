using System;
using FoodPin.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using UIKit;
using CoreGraphics;

namespace FoodPin.iOS.Views
{
	public partial class RateRestaurantView : MvxViewController, IMvxModalIosView
	{
		public new RateRestaurantViewModel ViewModel
		{
			get { return (RateRestaurantViewModel)base.ViewModel; }
			set { base.ViewModel = value; }
		}

		public RateRestaurantView() : base("RateRestaurantView", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			BindView();
			var scale = CGAffineTransform.MakeScale(0.0f, 0.0f);
			var translate = CGAffineTransform.MakeTranslation(0, 500);
			ButtonStackView.Transform = scale;
			ButtonStackView.Transform = translate;
		}

		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);

			UIView.AnimateNotify(0.4f, 0.0f, 0.9f, 0.1f, UIViewAnimationOptions.CurveEaseInOut, () =>
			{
				ButtonStackView.Transform = CGAffineTransform.MakeIdentity();
			}, (finished) => { });
		}

		void BindView()
		{
			var BindingSet = this.CreateBindingSet<RateRestaurantView, RateRestaurantViewModel>();
			BindingSet.Bind(CloseButton).To(vm => vm.CloseCommand);
			BindingSet.Bind(DislikeButton).To(vm => vm.DislikeCommand);
			BindingSet.Bind(GoodButton).To(vm => vm.GoodCommand);
			BindingSet.Bind(GreatButton).To(vm => vm.GreatCommand);
			BindingSet.Apply();
		}
	}
}

