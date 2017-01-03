// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace FoodPin.iOS.Cells
{
    [Register ("RestaurantInfoTableViewCell")]
    partial class RestaurantInfoTableViewCell
    {
        [Outlet]
        UIKit.UILabel FieldLabel { get; set; }


        [Outlet]
        UIKit.UILabel ValueLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (FieldLabel != null) {
                FieldLabel.Dispose ();
                FieldLabel = null;
            }

            if (ValueLabel != null) {
                ValueLabel.Dispose ();
                ValueLabel = null;
            }
        }
    }
}