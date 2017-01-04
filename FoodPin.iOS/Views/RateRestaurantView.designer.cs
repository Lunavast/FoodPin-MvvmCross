// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
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

            if (CloseButton != null) {
                CloseButton.Dispose ();
                CloseButton = null;
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
        }
    }
}