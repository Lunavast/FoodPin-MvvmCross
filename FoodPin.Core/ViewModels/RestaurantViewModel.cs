using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Input;
using FoodPin.Core.Models;
using MvvmCross.Core.ViewModels;

namespace FoodPin.Core.ViewModels
{
	public class RestaurantViewModel : MvxViewModel
	{
		private List<RestaurantItem> _items;
		public List<RestaurantItem> Items
		{
			get { return _items; }
			set { _items = value; RaisePropertyChanged(() => Items); }
		}

		public RestaurantViewModel()
		{
			Items = new List<RestaurantItem>() { new RestaurantItem() { Name = "First restaurant", Location = "Cracow", Type = "Good food" },
				new RestaurantItem() { Name = "Second restaurant", Location = "Warsaw", Type = "Bad food", IsVisited = true }};
		}

		public ICommand SelectionChangeCommand
		{
			get
			{
				//return new MvxCommand<RestaurantItem>(i => Debug.WriteLine("Selection"));
				//// ShowViewModel<RestaurantDetailViewModel>(new RestaurantDetailViewModel.Navigation()
				////{

				////}));

				return new MvxCommand<RestaurantItem>(i =>
				{
					i.IsVisited = !i.IsVisited;
					Debug.WriteLine("accessory");
				});
			}
		}

		public void DeleteItem(RestaurantItem item)
		{
			Items.Remove(item);
		}
	}
}