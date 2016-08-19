using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace XamFormsTestCloud.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init ();

			// Code for starting up the Xamarin Test Cloud Agent
			#if ENABLE_TEST_CLOUD
			global::Xamarin.Forms.Forms.ViewInitialized += (sender, e) => {

				// http://developer.xamarin.com/recipes/testcloud/set-accessibilityidentifier-ios/
				if (null != e.View.StyleId) {
					e.NativeView.AccessibilityIdentifier = e.View.StyleId;
				}
			}; 

			Xamarin.Calabash.Start();
			#endif

			LoadApplication (new App ());

			return base.FinishedLaunching (app, options);
		}
	}
}

