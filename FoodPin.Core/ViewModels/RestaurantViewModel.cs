using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Input;
using FoodPin.Core.Messenger;
using FoodPin.Core.Models;
using FoodPin.Core.Services;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Plugins.Messenger;

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

		private readonly IDataService _dataService;
		private readonly MvxSubscriptionToken _token;
		public RestaurantViewModel()
		{
			_dataService = Mvx.Resolve<IDataService>();
			_token = Mvx.Resolve<IMvxMessenger>().Subscribe<DataChangeMessage>(OnDataChange);
			Items = _dataService.AllItems();
			//Items = new List<RestaurantItem>() {
			//	new RestaurantItem() {
			//		Name = "Cafe Deadend",
			//		Type = "Coffee & Tea Shop",
			//		Location = "G/F,72 Po Hing Fong, Sheung Wan, Hong Kong",
			//		PhoneNumber = "232-923423",
			//		ImageName = "cafedeadend",
			//		IsVisited = false
			//	},
			//	new RestaurantItem() {
			//		Name = "Homei",
			//		Type = "Cafe",
			//		Location = "Shop B, G/F, 22-24A Tai Ping San Street SOHO, Sheung Wan, Hong Kong",
			//		PhoneNumber = "348 - 233423",
			//		ImageName = "homei",
			//		IsVisited = false
			//	},
			//	new RestaurantItem() {
			//		Name = "Teakha", 
			//		Type =  "Tea House", 
			//		Location =  "Shop B, 18 Tai Ping Shan Road SOHO, Sheung Wan, Hong Kong",
			//		PhoneNumber =  "354-243523",
			//		ImageName = "teakha",
			//		IsVisited =  false
			//	},
			//	new RestaurantItem() {
			//		Name = "Cafe loisl", 
			//		Type =  "Austrian / Causual Drink",
			//		Location = "Shop B, 20 Tai Ping Shan Road SOHO, Sheung Wan, Hong Kong",
			//		PhoneNumber =  "453-333423",
			//		ImageName = "cafeloisl", IsVisited =  false
			//	},
			//	new RestaurantItem() {
			//		Name = "Petite Oyster", 
			//		Type =  "French", 
			//		Location =  "24 Tai Ping Shan Road SOHO, Sheung Wan, Hong Kong",
			//		PhoneNumber =  "983-284334",
			//		ImageName = "petiteoyster",
			//		IsVisited =  false
			//	},
			//	new RestaurantItem() {
			//		Name = "For Kee Restaurant",
			//		Type =  "Bakery",
			//		Location =  "Shop J-K., 200 Hollywood Road, SOHO, Sheung Wan, Hong Kong",
			//		PhoneNumber =  "232-434222",
			//		ImageName = "forkeerestaurant",
			//		IsVisited =  false
			//	},
			//	new RestaurantItem() {
			//		Name = "Po's Atelier",
			//		Type =  "Bakery",
			//		Location =  "G/F, 62 Po Hing Fong, Sheung Wan, Hong Kong",
			//		PhoneNumber =  "234-834322",
			//		ImageName = "posatelier",
			//		IsVisited =  false},
			//	new RestaurantItem() { 
			//		Name = "Bourke Street Backery",
			//		Type =  "Chocolate",
			//		Location =  "633 Bourke St Sydney New South Wales 2010 Surry Hills",
			//		PhoneNumber =  "982-434343",
			//		ImageName = "bourkestreetbakery",
			//		IsVisited =  false
			//	},
			//	new RestaurantItem() {
			//		Name = "Haigh's Chocolate",
			//		Type =  "Cafe",
			//		Location =  "412-414 George St Sydney New South Wales",
			//		PhoneNumber =  "734-232323",
			//		ImageName = "haighschocolate",
			//		IsVisited =  false
			//			},
			//	new RestaurantItem() {
			//		Name = "Palomino Espresso",
			//		Type =  "American / Seafood",
			//		Location = "Shop 1 61 York St Sydney New South Wales",
			//		PhoneNumber =  "872-734343",
			//		ImageName = "palominoespresso",
			//		IsVisited =  false
			//			},
			//	new RestaurantItem() {
			//		Name = "Upstate",
			//		Type =  "American",
			//		Location =  "95 1st Ave New York, NY 10003",
			//		PhoneNumber =  "343-233221",
			//		ImageName = "upstate",
			//		IsVisited =  false
			//			},
			//	new RestaurantItem() {
			//		Name = "Traif",
			//		Type =  "American",
			//		Location =  "229 S 4th St Brooklyn, NY 11211",
			//		PhoneNumber =  "985-723623",
			//		ImageName = "traif",
			//		IsVisited = false
			//			},
			//	new RestaurantItem() {
			//		Name = "Graham Avenue Meats",
			//		Type =  "Breakfast & Brunch",
			//		Location =  "445 Graham Ave Brooklyn, NY 11211",
			//		PhoneNumber =  "455-232345",
			//		ImageName = "grahamavenuemeats",
			//		IsVisited =  false},
			//	new RestaurantItem() {
			//		Name = "Waffle & Wolf",
			//		Type =  "Coffee & Tea",
			//		Location =  "413 Graham Ave Brooklyn, NY 11211",
			//		PhoneNumber =  "434-232322", 
			//		ImageName = "wafflewolf",
			//		IsVisited =  false
			//	},
			//	new RestaurantItem() {
			//		Name = "Five Leaves",
			//		Type =  "Coffee & Tea",
			//		Location =  "18 Bedford Ave Brooklyn, NY 11222",
			//		PhoneNumber =  "343-234553",
			//		ImageName = "fiveleaves",
			//		IsVisited =  false
			//	},
			//	new RestaurantItem() {
			//		Name = "Cafe Lore",
			//		Type =  "Latin American",
			//		Location =  "Sunset Park 4601 4th Ave Brooklyn, NY 11220",
			//		PhoneNumber =  "342-455433",
			//		ImageName = "cafelore",
			//		IsVisited =  false
			//			},
			//	new RestaurantItem() {
			//		Name = "Confessional", 
			//		Type =  "Spanish", 
			//		Location =  "308 E 6th St New York, NY 10003", 
			//		PhoneNumber =  "643-332323", 
			//		ImageName = "confessional",
			//		IsVisited =  false
			//	},
			//	new RestaurantItem() {
			//		Name = "Barrafina", 
			//		Type =  "Spanish", 
			//		Location =  "54 Frith Street London W1D 4SL United Kingdom", 
			//		PhoneNumber =  "542-343434", 
			//		ImageName = "barrafina", 
			//		IsVisited =  false
			//	},
			//	new RestaurantItem() {
			//		Name = "Donostia", 
			//		Type =  "Spanish", 
			//		Location =  "10 Seymour Place London W1H 7ND United Kingdom", 
			//		PhoneNumber =  "722-232323", 
			//		ImageName = "donostia", 
			//		IsVisited =  false
			//	},
			//	new RestaurantItem() {
			//		Name = "Royal Oak", 
			//		Type =  "British", 
			//		Location = "2 Regency Street London SW1P 4BZ United Kingdom", 
			//		PhoneNumber =  "343-988834", 
			//		ImageName = "royaloak", 
			//		IsVisited =  false
			//	},
			//	new RestaurantItem() {
			//		Name = "Thai Cafe", 
			//		Type =  "Thai", 
			//		Location = "22 Charlwood Street London SW1V 2DY Pimlico", 
			//		PhoneNumber =  "432-344050", 
			//		ImageName = "thaicafe",
			//		IsVisited =  false
			//	}
			//};
		}

		void OnDataChange(DataChangeMessage obj)
		{
			Items = _dataService.AllItems();
		}

		private MvxCommand _showAddCommand;
		public ICommand ShowAddCommand
		{
			get
			{
				_showAddCommand = _showAddCommand ?? new MvxCommand(DoAdd);
				return _showAddCommand;
			}
		}

		private void DoAdd()
		{
			ShowViewModel<EditRestaurantViewModel>();
		}

		public ICommand SelectionChangeCommand
		{
			get
			{
				return new MvxCommand<RestaurantItem>(i => ShowViewModel<RestaurantDetailViewModel>(new RestaurantDetailViewModel.Navigation()
				{
					Id = i.Id
				}));
			}
		}

		public void DeleteItem(RestaurantItem item)
		{
			Items.Remove(item);
		}

		public void Search(string s)
		{
			Items = _dataService.SearchItems(s);
		}
	}
}