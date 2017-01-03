// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
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
