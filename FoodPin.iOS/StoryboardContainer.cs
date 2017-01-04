using System;
using MvvmCross.iOS.Views;
using UIKit;

namespace FoodPin.iOS
{
	public class StoryboardContainer : MvxIosViewsContainer
	{
		protected override IMvxIosView CreateViewOfType(Type viewType, MvvmCross.Core.ViewModels.MvxViewModelRequest request)
		{
			UIStoryboard storyboard;
			try
			{
				storyboard = UIStoryboard.FromName(viewType.Name, null);
			}
			catch (Exception)
			{
				return base.CreateViewOfType(viewType, request);
			}
			var view = storyboard.InstantiateViewController(viewType.Name);
			return (IMvxIosView)view;
		}
	}
}
