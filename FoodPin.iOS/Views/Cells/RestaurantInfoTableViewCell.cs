using System;

using Foundation;
using UIKit;

namespace FoodPin.iOS.Cells
{
	public partial class RestaurantInfoTableViewCell : UITableViewCell
	{
		public static readonly NSString Key = new NSString("RestaurantInfoTableViewCell");
		public static readonly UINib Nib;

		static RestaurantInfoTableViewCell()
		{
			Nib = UINib.FromName("RestaurantInfoTableViewCell", NSBundle.MainBundle);
		}

		protected RestaurantInfoTableViewCell(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public void ConfigureCell(string FieldText, string ValueText)
		{
			FieldLabel.Text = FieldText;
			ValueLabel.Text = ValueText;
		}
	}
}
