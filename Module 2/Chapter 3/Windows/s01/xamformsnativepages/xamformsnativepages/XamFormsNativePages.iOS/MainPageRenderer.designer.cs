// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace XamFormsNativePages.iOS
{
	[Register ("MainPageRenderer")]
	partial class MainPageRenderer
	{
		[Outlet]
		UIKit.UIButton button { get; set; }

		[Action ("OnButtonPressed:")]
		partial void OnButtonPressed (UIKit.UIButton sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (button != null) {
				button.Dispose ();
				button = null;
			}
		}
	}
}
