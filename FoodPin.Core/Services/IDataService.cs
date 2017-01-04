using System;
using System.Collections.Generic;
using FoodPin.Core.Models;

namespace FoodPin.Core.Services
{
	public interface IDataService
	{
		void AddItem(RestaurantItem item);
		void DeleteItem(RestaurantItem item);
		void UpdateItem(RestaurantItem item);
		RestaurantItem GetItem(int id);

		List<RestaurantItem> AllItems();

		List<RestaurantItem> SearchItems(string s);
	}
}
