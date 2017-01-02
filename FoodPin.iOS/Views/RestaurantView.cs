﻿using System;
using System.Diagnostics;
using FoodPin.Core.ViewModels;
using FoodPin.iOS.Cells;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.iOS.Views;
using UIKit;

namespace FoodPin.iOS.Views
{
	public partial class RestaurantView : MvxViewController
	{
		public new RestaurantViewModel ViewModel
		{
			get { return (RestaurantViewModel)base.ViewModel; }
			set { base.ViewModel = value; }
		}

		public RestaurantView() : base("RestaurantView", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			ConfigureTableView();
		}

		private void ConfigureTableView()
		{
			TableView.EstimatedRowHeight = 80;

			var Source = new RestaurantSource(this, TableView, RestaurantTableViewCell.Key, RestaurantTableViewCell.Key);
			TableView.Source = Source;

			var BindingSet = this.CreateBindingSet<RestaurantView, RestaurantViewModel>();
			BindingSet.Bind(Source).To(vm => vm.Items);
			BindingSet.Bind(Source).For(s => s.SelectionChangedCommand).To(vm => vm.SelectionChangeCommand);
			BindingSet.Apply();
		}

		private class RestaurantSource : MvxSimpleTableViewSource
		{
			private RestaurantView _vc;
			public RestaurantSource(RestaurantView vc, UITableView tableView, string nibName, string cellIdentifier = null) : base(tableView, nibName, cellIdentifier)
			{
				_vc = vc;
			}

			public override UITableViewRowAction[] EditActionsForRow(UITableView tableView, Foundation.NSIndexPath indexPath)
			{
				var ShareAction = UITableViewRowAction.Create(UITableViewRowActionStyle.Normal, "Share", (arg1, arg2) =>
				{
					var defaultText = string.Format("Just checking in at {0}", _vc.ViewModel.Items[indexPath.Row].Name);
					var activityController = new UIActivityViewController(new NSObject[] { (NSString)defaultText }, null);
					_vc.PresentViewController(activityController, true, null);
					Debug.WriteLine("Share");
				});
				ShareAction.BackgroundColor = UIColor.FromRGB(28.0f / 255.0f, 165.0f / 255.0f, 253.0f / 255.0f);

				var DeleteAction = UITableViewRowAction.Create(UITableViewRowActionStyle.Default, "Delete", (arg1, arg2) =>
				{
					_vc.ViewModel.DeleteItem(_vc.ViewModel.Items[indexPath.Row]);
					tableView.DeleteRows(new NSIndexPath[] { indexPath }, UITableViewRowAnimation.Automatic);
					Debug.WriteLine("Delete");
				});
				DeleteAction.BackgroundColor = UIColor.FromRGB(202.0f / 255.0f, 202.0f / 255.0f, 203.0f / 255.0f);
				return new UITableViewRowAction[] { DeleteAction, ShareAction };
			}

			void ShareActionHandler(UITableViewRowAction arg1, NSIndexPath arg2)
			{
				throw new NotImplementedException();
			}
	}
	}
}
