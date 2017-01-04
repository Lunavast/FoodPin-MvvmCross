using FoodPin.Core.Services;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;

namespace FoodPin.Core
{
    public class App : MvvmCross.Core.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
			Mvx.LazyConstructAndRegisterSingleton<IDataService, DataService>();
			Mvx.LazyConstructAndRegisterSingleton<IRepository, Repository>();

			RegisterAppStart<ViewModels.TabBarViewModel>();
        }
    }
}
