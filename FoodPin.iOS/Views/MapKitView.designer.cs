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
    [Register ("MapKitView")]
    partial class MapKitView
    {
        [Outlet]
        MapKit.MKMapView MapView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (MapView != null) {
                MapView.Dispose ();
                MapView = null;
            }
        }
    }
}