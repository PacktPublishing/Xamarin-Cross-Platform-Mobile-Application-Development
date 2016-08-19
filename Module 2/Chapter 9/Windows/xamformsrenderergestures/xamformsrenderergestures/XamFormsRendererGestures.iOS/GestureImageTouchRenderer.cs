using System;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XamFormsRendererGestures;
using XamFormsRendererGestures.iOS;

[assembly: ExportRenderer(typeof(GestureImage), typeof(GestureImageTouchRenderer))]

namespace XamFormsRendererGestures.iOS
{
    public class GestureImageTouchRenderer : ImageRenderer
    {
        UILongPressGestureRecognizer longPressGestureRecognizer;
        UIPinchGestureRecognizer pinchGestureRecognizer;
        UIPanGestureRecognizer panGestureRecognizer;
        UISwipeGestureRecognizer swipeGestureRecognizer;
        UIRotationGestureRecognizer rotationGestureRecognizer;

        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);

            longPressGestureRecognizer = new UILongPressGestureRecognizer(() => Console.WriteLine("Long Press"));
            pinchGestureRecognizer = new UIPinchGestureRecognizer(() => Console.WriteLine("Pinch"));
            panGestureRecognizer = new UIPanGestureRecognizer(() => Console.WriteLine("Pan"));
            swipeGestureRecognizer = new UISwipeGestureRecognizer(() => Console.WriteLine("Swipe"));
            rotationGestureRecognizer = new UIRotationGestureRecognizer(() => Console.WriteLine("Rotation"));

            if (e.NewElement == null)
            {
                if (longPressGestureRecognizer != null)
                {
                    RemoveGestureRecognizer(longPressGestureRecognizer);
                }
                if (pinchGestureRecognizer != null)
                {
                    RemoveGestureRecognizer(pinchGestureRecognizer);
                }
                if (panGestureRecognizer != null)
                {
                    RemoveGestureRecognizer(panGestureRecognizer);
                }
                if (swipeGestureRecognizer != null)
                {
                    RemoveGestureRecognizer(swipeGestureRecognizer);
                }
                if (rotationGestureRecognizer != null)
                {
                    RemoveGestureRecognizer(rotationGestureRecognizer);
                }
            }

            if (e.OldElement == null)
            {
                AddGestureRecognizer(longPressGestureRecognizer);
                AddGestureRecognizer(pinchGestureRecognizer);
                AddGestureRecognizer(panGestureRecognizer);
                AddGestureRecognizer(swipeGestureRecognizer);
                AddGestureRecognizer(rotationGestureRecognizer);
            }
        }
    }
}
