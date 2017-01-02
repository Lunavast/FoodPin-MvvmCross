using MvvmCross.Platform;
using MvvmCross.Platform.IoC;

namespace FoodPin.Core
{
    public class App : MvvmCross.Core.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
			//Mvx.LazyConstructAndRegisterSingleton<interface, service>();

			RegisterAppStart<ViewModels.TabBarViewModel>();
        }
    }
}
