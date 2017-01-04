using System;
using FoodPin.Core.Models;
using MvvmCross.Plugins.Messenger;

namespace FoodPin.Core.Messenger
{
	public class RatingChangeMessage : MvxMessage
	{
		public Rating Rating { get; set; }
		public RatingChangeMessage(object sender, Rating rating) : base(sender)
		{
			Rating = rating;
		}
	}
}
