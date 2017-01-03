using System;
using MvvmCross.Platform.Converters;
using UIKit;

namespace FoodPin.iOS.Converters
{
	public class AssetsImageValueConverter : MvxValueConverter <string, UIImage>
	{
		protected override UIImage Convert(string value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return UIImage.FromBundle(value);
		}
	}
}
