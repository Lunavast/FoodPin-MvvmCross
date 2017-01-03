using System;
using FoodPin.Core.Services;
using CoreLocation;

namespace FoodPin.iOS.Services
{
	public class GeoCoderService : IGeoCoderService
	{
		public void GeoCodeAddress(string address, Action<double, double, Exception> action)
		{
			var GeoCoder = new CLGeocoder();

			GeoCoder.GeocodeAddress(address, (placemarks, error) =>
			{
				if (error == null)
				{
					var placemark = placemarks[0];
					action(placemark.Location.Coordinate.Latitude, placemark.Location.Coordinate.Longitude, null);
				}
				else 
				{
					action(0, 0, new Exception());
				}
			});
		}
	}
}
