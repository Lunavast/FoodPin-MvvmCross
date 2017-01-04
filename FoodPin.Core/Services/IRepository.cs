using System;
using System.Collections.Generic;
using System.Linq;
using FoodPin.Core.Models;
using MvvmCross.Plugins.Sqlite;
using SQLite;

namespace FoodPin.Core.Services
{
	public interface IRepository
	{
		void Add(RestaurantItem item);
		void Delete(RestaurantItem item);
		void Update(RestaurantItem item);
		RestaurantItem Get(int id);

		List<RestaurantItem> All();

		List<RestaurantItem> Search(string s);
	}
}