using System;
using CoreGraphics;
using Foundation;
using MvvmCross.Platform.Converters;
using UIKit;

namespace FoodPin.iOS.Converters
{
public class BytesToUIImageValueConverter : MvxValueConverter<byte[], UIImage>
		{
			protected override UIImage Convert(byte[] value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
			{
				if (value == null)
					return UIImage.FromBundle("PhotoAlbum");

				return BytesToImageConverter.Convert(value);			
			}
		}
	}
