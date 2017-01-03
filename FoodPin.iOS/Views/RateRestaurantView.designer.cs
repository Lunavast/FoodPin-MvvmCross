// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace FoodPin.iOS.Views
{
	[Register ("RateRestaurantView")]
	partial class RateRestaurantView
	{
		[Outlet]
		UIKit.UIStackView ButtonStackView { get; set; }

		[Outlet]
		UIKit.UIButton CloseButton { get; set; }

		[Outlet]
		UIKit.UIButton DislikeButton { get; set; }

		[Outlet]
		UIKit.UIButton GoodButton { get; set; }

		[Outlet]
		UIKit.UIButton GreatButton { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (ButtonStackView != null) {
				ButtonStackView.Dispose ();
				ButtonStackView = null;
			}

			if (DislikeButton != null) {
				DislikeButton.Dispose ();
				DislikeButton = null;
			}

			if (GoodButton != null) {
				GoodButton.Dispose ();
				GoodButton = null;
			}

			if (GreatButton != null) {
				GreatButton.Dispose ();
				GreatButton = null;
			}

			if (CloseButton != null) {
				CloseButton.Dispose ();
				CloseButton = null;
			}
		}
	}
}
