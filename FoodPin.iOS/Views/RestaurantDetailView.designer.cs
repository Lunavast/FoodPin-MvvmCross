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
	[Register ("RestaurantDetailView")]
	partial class RestaurantDetailView
	{
		[Outlet]
		UIKit.UIButton RatingButton { get; set; }

		[Outlet]
		UIKit.UIImageView RestaurantImageView { get; set; }

		[Outlet]
		UIKit.UITableView TableView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (RestaurantImageView != null) {
				RestaurantImageView.Dispose ();
				RestaurantImageView = null;
			}

			if (TableView != null) {
				TableView.Dispose ();
				TableView = null;
			}

			if (RatingButton != null) {
				RatingButton.Dispose ();
				RatingButton = null;
			}
		}
	}
}
