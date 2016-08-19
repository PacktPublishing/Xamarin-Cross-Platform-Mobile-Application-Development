// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace XamFormsInAppPhoto.iOS
{
	[Register ("InAppCameraPage")]
	partial class InAppCameraPage
	{
		[Outlet]
		UIKit.UIView cameraViewContainer { get; set; }

		[Outlet]
		UIKit.UIImageView captureImageView { get; set; }

		[Outlet]
		UIKit.UIView overlayView { get; set; }

		[Outlet]
		UIKit.UIButton takePhotoButton { get; set; }

		[Action ("CapturePhotoTouchUpInside:")]
		partial void CapturePhotoTouchUpInside (UIKit.UIButton sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (cameraViewContainer != null) {
				cameraViewContainer.Dispose ();
				cameraViewContainer = null;
			}

			if (captureImageView != null) {
				captureImageView.Dispose ();
				captureImageView = null;
			}

			if (takePhotoButton != null) {
				takePhotoButton.Dispose ();
				takePhotoButton = null;
			}

			if (overlayView != null) {
				overlayView.Dispose ();
				overlayView = null;
			}
		}
	}
}
