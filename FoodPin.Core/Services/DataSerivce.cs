using System;
using System.Collections.Generic;
using FoodPin.Core.Messenger;
using FoodPin.Core.Models;
using MvvmCross.Plugins.Messenger;

namespace FoodPin.Core.Services
{
	public class DataService : IDataService
	{
		private readonly IRepository _repository;
		private readonly IMvxMessenger _messenger;
		public DataService(IRepository repository, IMvxMessenger messenger)
		{
			_repository = repository;
			_messenger = messenger;
		}

		public void AddItem(RestaurantItem item)
		{
			_repository.Add(item);
			_messenger.Publish(new DataChangeMessage(this));
		}

		public List<RestaurantItem> AllItems()
		{
			return _repository.All();
		}

		public void DeleteItem(RestaurantItem item)
		{
			_repository.Delete(item);
			_messenger.Publish(new DataChangeMessage(this));
		}

		public RestaurantItem GetItem(int id)
		{
			return _repository.Get(id);
		}

		public void UpdateItem(RestaurantItem item)
		{
			_repository.Update(item);
			_messenger.Publish(new DataChangeMessage(this));
		}

		public List<RestaurantItem> SearchItems(string s)
		{
			_messenger.Publish(new DataChangeMessage(this));
			return _repository.Search(s);
		}
	}
}