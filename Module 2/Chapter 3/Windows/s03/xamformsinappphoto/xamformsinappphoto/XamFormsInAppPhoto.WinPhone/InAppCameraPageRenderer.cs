using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinPhone;
using XamFormsInAppPhoto;
using XamFormsInAppPhoto.WinPhone;
using Microsoft.Phone.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

[assembly: ExportRenderer(typeof(InAppCameraPage), typeof(InAppCameraPageRenderer))]

namespace XamFormsInAppPhoto.WinPhone
{
    public class InAppCameraPageRenderer : PageRenderer
    {
        CameraCaptureTask cameraCaptureTask;
        PreviewImageUserControl previewImageUserControl;

        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || Element == null)
                return;

            cameraCaptureTask = new CameraCaptureTask();
            cameraCaptureTask.Completed += OnCameraCaptureTaskCompleted;

            previewImageUserControl = new PreviewImageUserControl();
            Children.Add(previewImageUserControl);

            cameraCaptureTask.Show();
        }

        private void OnCameraCaptureTaskCompleted(object sender, PhotoResult e)
        {
            if (e.TaskResult == TaskResult.OK)
            {
                BitmapImage bmp = new BitmapImage();
                bmp.SetSource(e.ChosenPhoto);
                previewImageUserControl.previewImage.Source = bmp;
            }
        }
    }
}
