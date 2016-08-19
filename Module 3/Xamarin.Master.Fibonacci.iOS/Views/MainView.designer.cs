// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Xamarin.Master.Fibonacci.iOS.Views
{
	[Register ("MainView")]
	partial class MainView
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnGCCollect { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnRangeCalculation { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnSingleCalculation { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (btnGCCollect != null) {
				btnGCCollect.Dispose ();
				btnGCCollect = null;
			}
			if (btnRangeCalculation != null) {
				btnRangeCalculation.Dispose ();
				btnRangeCalculation = null;
			}
			if (btnSingleCalculation != null) {
				btnSingleCalculation.Dispose ();
				btnSingleCalculation = null;
			}
		}
	}
}
