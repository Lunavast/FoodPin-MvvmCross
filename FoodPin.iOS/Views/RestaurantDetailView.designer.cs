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
    [Register ("RestaurantDetailView")]
    partial class RestaurantDetailView
    {
        [Outlet]
        UIKit.UIButton MapButton { get; set; }


        [Outlet]
        UIKit.UIButton RatingButton { get; set; }


        [Outlet]
        UIKit.UIImageView RestaurantImageView { get; set; }


        [Outlet]
        UIKit.UITableView TableView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (MapButton != null) {
                MapButton.Dispose ();
                MapButton = null;
            }

            if (RatingButton != null) {
                RatingButton.Dispose ();
                RatingButton = null;
            }

            if (RestaurantImageView != null) {
                RestaurantImageView.Dispose ();
                RestaurantImageView = null;
            }

            if (TableView != null) {
                TableView.Dispose ();
                TableView = null;
            }
        }
    }
}