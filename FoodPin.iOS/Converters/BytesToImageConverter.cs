using System;
using CoreGraphics;
using Foundation;
using UIKit;

namespace FoodPin.iOS.Converters
{
	public class BytesToImageConverter
	{
		static public UIImage Convert(byte[] bytes)
		{
							NSData data = NSData.FromArray(bytes);
		UIImage image = UIImage.LoadFromData(data);
		CGSize scaleSize = new CGSize(500, 500);
		UIGraphics.BeginImageContextWithOptions(scaleSize, false, 0);
				image.Draw(new CGRect(0, 0, scaleSize.Width, scaleSize.Height));
				UIImage resizedImage = UIGraphics.GetImageFromCurrentImageContext();
		UIGraphics.EndImageContext();

				return resizedImage;	
		}
	}
}
