
using System;

using Foundation;
using UIKit;
using Xamarin.Forms;
using XamFormsInAppPhoto;
using Xamarin.Forms.Platform.iOS;
using AVFoundation;
using System.Threading.Tasks;

[assembly: ExportRenderer(typeof(InAppCameraPage), typeof(XamFormsInAppPhoto.iOS.InAppCameraPage))]

namespace XamFormsInAppPhoto.iOS
{
	public partial class InAppCameraPage : PageRenderer
	{
		AVCaptureSession captureSession;
		AVCaptureDeviceInput captureDeviceInput;
		AVCaptureStillImageOutput stillImageOutput;

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			AuthorizeCameraUseAsync ().ContinueWith ((antecedent) => {
				bool result = antecedent.Result;
				if (result)
				{
					SetupCameraLiveFeed ();
				}
			});
		}

        public async Task<bool> AuthorizeCameraUseAsync()
        {
            var authorizationStatus = AVCaptureDevice.GetAuthorizationStatus(AVMediaType.Video);

            if (authorizationStatus != AVAuthorizationStatus.Authorized)
            {
                return await AVCaptureDevice.RequestAccessForMediaTypeAsync(AVMediaType.Video);
            }
            else if (authorizationStatus == AVAuthorizationStatus.Authorized)
            {
                return true;
            }
            return false;
        }

		public void SetupCameraLiveFeed()
		{
			captureSession = new AVCaptureSession();
			AVCaptureVideoPreviewLayer videoPreviewLayer = new AVCaptureVideoPreviewLayer(captureSession)
			{
				Frame = cameraViewContainer.Bounds
			};
			cameraViewContainer.Layer.AddSublayer(videoPreviewLayer);

			AVCaptureDevice captureDevice = AVCaptureDevice.DefaultDeviceWithMediaType(AVMediaType.Video);
			ConfigureCameraForDevice(captureDevice);
			captureDeviceInput = AVCaptureDeviceInput.FromDevice(captureDevice);
			stillImageOutput = new AVCaptureStillImageOutput();

			captureSession.AddOutput(stillImageOutput);
			captureSession.AddInput(captureDeviceInput);
			captureSession.StartRunning();
		}

		public void ConfigureCameraForDevice(AVCaptureDevice device)
		{
			NSError error = new NSError();
			if (device.IsFocusModeSupported(AVCaptureFocusMode.ContinuousAutoFocus))
			{
				device.LockForConfiguration(out error);
				device.FocusMode = AVCaptureFocusMode.ContinuousAutoFocus;
				device.UnlockForConfiguration();
			}
			else if (device.IsExposureModeSupported(AVCaptureExposureMode.ContinuousAutoExposure))
			{
				device.LockForConfiguration(out error);
				device.ExposureMode = AVCaptureExposureMode.ContinuousAutoExposure;
				device.UnlockForConfiguration();
			}
			else if (device.IsWhiteBalanceModeSupported(AVCaptureWhiteBalanceMode.ContinuousAutoWhiteBalance))
			{
				device.LockForConfiguration(out error);
				device.WhiteBalanceMode = AVCaptureWhiteBalanceMode.ContinuousAutoWhiteBalance;
				device.UnlockForConfiguration();
			}
		}

        partial void CapturePhotoTouchUpInside(UIKit.UIButton sender)
        {
            CapturePhotoAsync();
        }

        public async Task CapturePhotoAsync()
		{
			var videoConnection = stillImageOutput.ConnectionFromMediaType(AVMediaType.Video);
			var sampleBuffer = await stillImageOutput.CaptureStillImageTaskAsync(videoConnection);
			var jpegImageAsNsData = AVCaptureStillImageOutput.JpegStillToNSData(sampleBuffer);
//			var image = new UIImage (jpegImageAsNsData);
			captureImageView.Image = new UIImage (jpegImageAsNsData);
		}

        protected override void Dispose(bool disposing)
        {
            captureSession.Dispose();
            captureDeviceInput.Dispose();
            stillImageOutput.Dispose();
            base.Dispose(disposing);
        }
    }
}

