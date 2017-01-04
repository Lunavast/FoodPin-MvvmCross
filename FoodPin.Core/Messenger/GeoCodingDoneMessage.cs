using System;
using MvvmCross.Plugins.Messenger;

namespace FoodPin.Core.Messenger
{
	public class GeoCodingDoneMessage : MvxMessage
	{
		public double Lat { get; set; }
		public double Lng { get; set; }
		public bool Error { get; set; }
		public GeoCodingDoneMessage(object sender, double lat, double lng, bool error) : base(sender)
		{
			Lat = lat;
			Lng = lng;
			Error = error;
		}
	}
}
