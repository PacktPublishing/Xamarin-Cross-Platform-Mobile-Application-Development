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
	[Register ("RangeCalculationView")]
	partial class RangeCalculationView
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnCalculate { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnClose { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblInfoText { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblOrdinal1 { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblOrdinal2 { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIProgressView prgCalculation { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField txtOrdinal1 { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField txtOrdinal2 { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField txtResult { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (btnCalculate != null) {
				btnCalculate.Dispose ();
				btnCalculate = null;
			}
			if (btnClose != null) {
				btnClose.Dispose ();
				btnClose = null;
			}
			if (lblInfoText != null) {
				lblInfoText.Dispose ();
				lblInfoText = null;
			}
			if (lblOrdinal1 != null) {
				lblOrdinal1.Dispose ();
				lblOrdinal1 = null;
			}
			if (lblOrdinal2 != null) {
				lblOrdinal2.Dispose ();
				lblOrdinal2 = null;
			}
			if (prgCalculation != null) {
				prgCalculation.Dispose ();
				prgCalculation = null;
			}
			if (txtOrdinal1 != null) {
				txtOrdinal1.Dispose ();
				txtOrdinal1 = null;
			}
			if (txtOrdinal2 != null) {
				txtOrdinal2.Dispose ();
				txtOrdinal2 = null;
			}
			if (txtResult != null) {
				txtResult.Dispose ();
				txtResult = null;
			}
		}
	}
}
