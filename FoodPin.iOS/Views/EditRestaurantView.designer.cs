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
	[Register ("EditRestaurantView")]
	partial class EditRestaurantView
	{
		[Outlet]
		UIKit.UITextField LocationTextField { get; set; }

		[Outlet]
		UIKit.UITextField NameTextField { get; set; }

		[Outlet]
		UIKit.UIButton NoButton { get; set; }

		[Outlet]
		UIKit.UIImageView RestaurantImageView { get; set; }

		[Outlet]
		UIKit.UITextField TypeTextField { get; set; }

		[Outlet]
		UIKit.UIButton YesButton { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (LocationTextField != null) {
				LocationTextField.Dispose ();
				LocationTextField = null;
			}

			if (NameTextField != null) {
				NameTextField.Dispose ();
				NameTextField = null;
			}

			if (NoButton != null) {
				NoButton.Dispose ();
				NoButton = null;
			}

			if (RestaurantImageView != null) {
				RestaurantImageView.Dispose ();
				RestaurantImageView = null;
			}

			if (TypeTextField != null) {
				TypeTextField.Dispose ();
				TypeTextField = null;
			}

			if (YesButton != null) {
				YesButton.Dispose ();
				YesButton = null;
			}
		}
	}
}
