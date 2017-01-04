using System;
namespace FoodPin.Core.Services
{
	public interface IGeoCoderService
	{
		void GeoCodeAddress(string address, Action<double, double, Exception> action);
	}
}
