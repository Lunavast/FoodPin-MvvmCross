using System;
using MvvmCross.Platform.Converters;
using UIKit;

namespace FoodPin.iOS.Converters
{
	public class VisitedColorValueConverter : MvxValueConverter <bool, UIColor>
	{
		protected override UIColor Convert(bool value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			bool BoolParameter = (bool)parameter;
			if (BoolParameter == true)
			{
				return value ? UIColor.Red : UIColor.DarkGray;
			}
			return !value ? UIColor.Red : UIColor.DarkGray;
		}
	}
}
