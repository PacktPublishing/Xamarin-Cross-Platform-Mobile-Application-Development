using Xamarin.Forms.Platform.Android;
using XamFormsRendererGestures.Droid;
using XamFormsRendererGestures;
using Xamarin.Forms;
using Android.Views;

[assembly: ExportRenderer(typeof(GestureImage), typeof(GestureImageDroidRenderer))]

namespace XamFormsRendererGestures.Droid
{
    public class GestureImageDroidRenderer : ImageRenderer
    {
        private readonly GestureImageListener _imageGestureListener;
        private readonly GestureDetector _gestureDetector;

        public GestureImageDroidRenderer()
        {
            _imageGestureListener = new GestureImageListener();
            _gestureDetector = new GestureDetector(_imageGestureListener);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement == null)
            {
                GenericMotion -= HandleGenericMotion;
                Touch -= HandleTouch;
            }

            if (e.OldElement == null)
            {
                GenericMotion += HandleGenericMotion;
                Touch += HandleTouch;
            }
        }

        void HandleTouch(object sender, TouchEventArgs e)
        {
            _gestureDetector.OnTouchEvent(e.Event);
        }

        void HandleGenericMotion(object sender, GenericMotionEventArgs e)
        {
            _gestureDetector.OnTouchEvent(e.Event);
        }
    }
}