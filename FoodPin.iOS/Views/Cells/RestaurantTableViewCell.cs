using System;
using FoodPin.Core.Models;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using UIKit;

namespace FoodPin.iOS.Cells
{
	public partial class RestaurantTableViewCell : MvxTableViewCell
	{
		public static readonly NSString Key = new NSString("RestaurantTableViewCell");
		public static readonly UINib Nib;

		public class IsChecked
		{
			public bool Accessory
			{
				get { return _cell.Accessory == UITableViewCellAccessory.Checkmark; }
				set { _cell.Accessory = value ? UITableViewCellAccessory.Checkmark : UITableViewCellAccessory.None; }
			}

			private UITableViewCell _cell;
			public IsChecked(UITableViewCell cell)
			{
				this._cell = cell;
				Accessory = false;
			}
		}
		public IsChecked _isChecked;

		static RestaurantTableViewCell()
		{
			Nib = UINib.FromName("RestaurantTableViewCell", NSBundle.MainBundle);
		}

		protected RestaurantTableViewCell(IntPtr handle) : base(handle)
		{
			_isChecked = new IsChecked(this);
			this.DelayBind(() =>
			{
				this.CreateBinding(NameLabel).To((RestaurantItem i) => i.Name).Apply();
				this.CreateBinding(LocationLabel).To((RestaurantItem i) => i.Location).Apply();
				this.CreateBinding(TypeLabel).To((RestaurantItem i) => i.Type).Apply();
				this.CreateBinding(_isChecked).For(v => v.Accessory).To((RestaurantItem i) => i.IsVisited).Apply();
				this.CreateBinding(ThumbnailImageView).To((RestaurantItem i) => i.ImageName).WithConversion("AssetsImage").Apply();
			});
		}

		public override void MovedToSuperview()
		{
			base.MovedToSuperview();
			this.LayoutIfNeeded();
		}
	}
}
