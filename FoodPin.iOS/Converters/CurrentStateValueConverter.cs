using System;
using MvvmCross.Platform.Converters;
using FoodPin.Core.ViewModels;

namespace FoodPin.iOS.Converters
{
	public class CurrentStateValueConverter : MvxValueConverter <WalkthroughViewModel.Pages, nint>
	{
		protected override nint Convert(WalkthroughViewModel.Pages value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return (nint)(int)value;
		}
	}
}
