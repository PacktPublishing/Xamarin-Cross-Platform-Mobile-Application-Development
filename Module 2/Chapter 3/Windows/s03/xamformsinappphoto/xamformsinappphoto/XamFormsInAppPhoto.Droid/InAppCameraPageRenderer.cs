using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Hardware;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms.Platform.Android;
using Android.Graphics;
using Xamarin.Forms;
using System.IO;
using XamFormsInAppPhoto;
using XamFormsInAppPhoto.Droid;

[assembly: ExportRenderer(typeof(InAppCameraPage), typeof(InAppCameraPageRenderer))]

namespace XamFormsInAppPhoto.Droid
{
    public class InAppCameraPageRenderer : PageRenderer, TextureView.ISurfaceTextureListener
    {
        Android.Hardware.Camera camera;
        Android.Widget.Button takePhotoButton;
        Activity activity;
        TextureView textureView;
        Android.Views.View view;
		ImageView snapshotImageView;

        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || Element == null)
                return;

            activity = this.Context as Activity;
            view = activity.LayoutInflater.Inflate(Resource.Layout.InAppPhotoLayout, this, false);

            textureView = view.FindViewById<TextureView>(Resource.Id.textureView);
            textureView.SurfaceTextureListener = this;

            takePhotoButton = view.FindViewById<Android.Widget.Button>(Resource.Id.takePhotoButton);
            takePhotoButton.Click += OnTakePhoto;

			snapshotImageView = view.FindViewById<ImageView> (Resource.Id.snapshotView);

            AddView(view);
        }

        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            base.OnLayout(changed, l, t, r, b);

            var msw = MeasureSpec.MakeMeasureSpec(r - l, MeasureSpecMode.Exactly);
            var msh = MeasureSpec.MakeMeasureSpec(b - t, MeasureSpecMode.Exactly);

            view.Measure(msw, msh);
            view.Layout(0, 0, r - l, b - t);
        }

        private void OnTakePhoto(object sender, EventArgs e)
        {
            camera.StopPreview();
			snapshotImageView.SetImageBitmap (textureView.Bitmap);
            camera.StartPreview();
        }

        public void OnSurfaceTextureAvailable(SurfaceTexture surface, int width, int height)
        {
            camera = Android.Hardware.Camera.Open((int)CameraFacing.Back);
            textureView.LayoutParameters = new FrameLayout.LayoutParams(width, height);
            camera.SetPreviewTexture(surface);
            PrepareAndStartCamera();
        }

        public bool OnSurfaceTextureDestroyed(SurfaceTexture surface)
        {
            camera.StopPreview();
            camera.Release();

            return true;
        }

        public void OnSurfaceTextureSizeChanged(SurfaceTexture surface, int width, int height)
        {
            PrepareAndStartCamera();
        }

        public void OnSurfaceTextureUpdated(SurfaceTexture surface)
        {
            // Nothing
        }

        private void PrepareAndStartCamera()
        {
            camera.StopPreview();

            var display = activity.WindowManager.DefaultDisplay;
            if (display.Rotation == SurfaceOrientation.Rotation0)
            {
                camera.SetDisplayOrientation(90);
            }

            if (display.Rotation == SurfaceOrientation.Rotation270)
            {
                camera.SetDisplayOrientation(180);
            }

            camera.StartPreview();
        }
    }
}