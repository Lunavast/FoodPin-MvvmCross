using System;
using SQLite;

namespace FoodPin.Core.Models
{
	[Table("Restaurants")]
	public class RestaurantItem
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
		public string Name { get; set; }
		public string Location { get; set; }
		public string Type { get; set; }

		public Boolean IsVisited { get; set; } = false;
	}
}
