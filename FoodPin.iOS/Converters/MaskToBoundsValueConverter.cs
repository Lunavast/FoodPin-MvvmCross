using System;
using System.Diagnostics;
using MvvmCross.Platform.Converters;

namespace FoodPin.iOS.Converters
{
	public class MaskToBoundsValueConverter : MvxValueConverter <byte[], bool>
	{
		protected override bool Convert(byte[] value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (value != null)
			{
				return true;
			}
			else 
			{
				return false;
			}
		}
	}
}
