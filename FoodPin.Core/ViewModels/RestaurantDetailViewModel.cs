using System;
using FoodPin.Core.Models;
using MvvmCross.Core.ViewModels;

namespace FoodPin.Core.ViewModels
{
	public class RestaurantDetailViewModel : MvxViewModel
	{
		public class Navigation
		{
			public string Name { get; set; }
			public string Location { get; set; }
			public string Type { get; set; }
			public bool Visited { get; set; }
		}

		public void Init(Navigation nav)
		{
			Item = new RestaurantItem()
			{
				Name = nav.Name,
				Location = nav.Location,
				Type = nav.Type
			};
		}

		private RestaurantItem _item;
		public RestaurantItem Item
		{
			get { return _item; }
			set { _item = value; RaisePropertyChanged(() => Item); }
		}

		private string _name;
		public string Name
		{
			get { return _name; }
			set { _name = value; RaisePropertyChanged(() => Name); }
		}

		private string _Location;
		public string Location
		{
			get { return _Location; }
			set { _Location = value; RaisePropertyChanged(() => Location); }
		}

		private string _type;
		public string Type
		{
			get { return _type; }
			set { _type = value; RaisePropertyChanged(() => Type); }
		}
	}
}
