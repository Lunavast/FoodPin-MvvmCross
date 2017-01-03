using System;
using SQLite;
using System.ComponentModel;

namespace FoodPin.Core.Models
{
	public enum Rating 
	{ 
		Rating,
		Dislike, 
		Good, 
		Great
	}

	[Table("Restaurants")]
	public class RestaurantItem
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
		public string Name { get; set; }
		public string Location { get; set; }
		public string Type { get; set; }
		public string ImageName { get; set; }
		public string PhoneNumber { get; set; }
		public Rating Rating { get; set; }
		public bool IsVisited { get; set; } = false;
	}

}
