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
	[Register ("SingleCalculationView")]
	partial class SingleCalculationView
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
		UILabel lblOrdinal { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblResult { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField txtOrdinal { get; set; }

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
			if (lblOrdinal != null) {
				lblOrdinal.Dispose ();
				lblOrdinal = null;
			}
			if (lblResult != null) {
				lblResult.Dispose ();
				lblResult = null;
			}
			if (txtOrdinal != null) {
				txtOrdinal.Dispose ();
				txtOrdinal = null;
			}
			if (txtResult != null) {
				txtResult.Dispose ();
				txtResult = null;
			}
		}
	}
}
