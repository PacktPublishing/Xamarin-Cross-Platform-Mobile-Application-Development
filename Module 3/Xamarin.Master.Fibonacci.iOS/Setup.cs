using System;
using System.Threading;
using Cirrious.CrossCore;
using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Touch.Platform;
using Cirrious.MvvmCross.Touch.Views;
using UIKit;
using Xamarin.Master.Fibonacci.Core;
using Xamarin.Master.Fibonacci.iOS.Views;

namespace Xamarin.Master.Fibonacci.iOS
{
	public class Setup : MvxTouchSetup
	{
		public Setup(MvxApplicationDelegate applicationDelegate, UIWindow window)
            : base(applicationDelegate, window)
		{
		}

		protected override IMvxApplication CreateApp()
		{
		    Mvx.RegisterSingleton(typeof (IThreadInfo), new ThreadInfo());

		    AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
		    {
		        System.Diagnostics.Debug.WriteLine("Exception was uncaught: " + args.ExceptionObject.ToString());
		    };

			return new Core.App();
		}

	    protected override IMvxTouchViewsContainer CreateTouchViewsContainer()
	    {
	        return new StoryBoardTouchViewsContainer();
	    }

	    protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }
	}
}