using System;
using System.Collections.Generic;
using System.Linq;
using FoodPin.Core.Models;
using MvvmCross.Plugins.Sqlite;
using SQLite;

namespace FoodPin.Core.Services
{
	public class Repository : IRepository
	{
		private readonly SQLiteConnection _connection;
		public Repository(IMvxSqliteConnectionFactory factory)
		{
			_connection = factory.GetConnection("restaurants.sql");
			_connection.CreateTable<RestaurantItem>();
		}

		public void Add(RestaurantItem item)
		{
			_connection.Insert(item);
		}

		public List<RestaurantItem> All()
		{
			return _connection.Table<RestaurantItem>().ToList();
		}

		public void Delete(RestaurantItem item)
		{
			_connection.Delete(item);
		}

		public RestaurantItem Get(int id)
		{
			return _connection.Get<RestaurantItem>(id);
		}

		public void Update(RestaurantItem item)
		{
			_connection.Update(item);
		}
	}
}
