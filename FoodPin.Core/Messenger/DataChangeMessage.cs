﻿using System;
using MvvmCross.Plugins.Messenger;

namespace FoodPin.Core.Messenger
{
	public class DataChangeMessage : MvxMessage
	{
		public DataChangeMessage(object sender) : base(sender)
		{
		}
	}
}
