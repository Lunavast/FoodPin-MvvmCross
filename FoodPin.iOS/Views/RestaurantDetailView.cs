using System;
using CoreGraphics;
using FoodPin.Core.ViewModels;
using FoodPin.iOS.Cells;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.iOS.Views;
using UIKit;

namespace FoodPin.iOS.Views
{
	public partial class RestaurantDetailView : MvxViewController
	{
		public new RestaurantDetailViewModel ViewModel
		{
			get { return (RestaurantDetailViewModel)base.ViewModel; }
			set { base.ViewModel = value; }
		}

		public RestaurantDetailView() : base("RestaurantDetailView", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
			ConfigureTableView();
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
			NavigationItem.Title = ViewModel.Item.Name;
			NavigationController.HidesBarsOnSwipe = false;
			NavigationController.SetNavigationBarHidden(false, true);
		}

		void ConfigureTableView()
		{
			TableView.BackgroundColor = UIColor.FromRGB(240.0f / 255.0f, 240.0f / 255.0f, 240.0f / 255.0f).ColorWithAlpha(0.2f);
			TableView.TableFooterView = new UIView(new CGRect(0, 0, 0, 0));
			TableView.SeparatorColor = UIColor.FromRGB(240.0f / 255.0f, 240.0f / 255.0f, 240.0f / 255.0f).ColorWithAlpha(0.8f); 

			var Source = new TableSource(ViewModel);
			TableView.Source = Source;
			TableView.RegisterNibForCellReuse(RestaurantInfoTableViewCell.Nib, RestaurantInfoTableViewCell.Key);
		}

		private class TableSource : UITableViewSource
		{
			private readonly RestaurantDetailViewModel _vm;
			public TableSource(RestaurantDetailViewModel vm)
			{
				_vm = vm;
			}

			public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
			{
				RestaurantInfoTableViewCell cell = tableView.DequeueReusableCell(RestaurantInfoTableViewCell.Key, indexPath) as RestaurantInfoTableViewCell;
				cell.BackgroundColor = UIColor.Clear;

				switch (indexPath.Row)
				{
					case 0:
						{
							cell.ConfigureCell("Name", _vm.Item.Name);
							break;
						}
					case 1:
						{
							cell.ConfigureCell("Type ", _vm.Item.Type);
							break;
						}
					case 2:
						{
							cell.ConfigureCell("Location", _vm.Item.Location);
							break;
						}
					case 3:
						{
							cell.ConfigureCell("Been here", _vm.Item.IsVisited ? "Yes" : "No");
							break;
						}
					default:
						break;
				}
				return cell;
			}

			public override nint RowsInSection(UITableView tableview, nint section)
			{
				return 4;
			}
		}
	}
}

