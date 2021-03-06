using FoodPin.Core.Services;
using FoodPin.iOS.Services;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Platform;
using MvvmCross.iOS.Views;
using MvvmCross.iOS.Views.Presenters;
using MvvmCross.Platform;
using MvvmCross.Platform.Platform;
using UIKit;

namespace FoodPin.iOS
{
    public class Setup : MvxIosSetup
    {
        public Setup(MvxApplicationDelegate applicationDelegate, UIWindow window)
            : base(applicationDelegate, window)
        {
        }
        
        public Setup(MvxApplicationDelegate applicationDelegate, IMvxIosViewPresenter presenter)
            : base(applicationDelegate, presenter)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new Core.App();
        }
        
        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }
				protected override void InitializeFirstChance()
		{
			Mvx.RegisterSingleton<IGeoCoderService>(new GeoCoderService());
			base.InitializeFirstChance();
		}

		protected override IMvxIosViewsContainer CreateIosViewsContainer()
		{
			return new StoryboardContainer();
		}
    }
}
