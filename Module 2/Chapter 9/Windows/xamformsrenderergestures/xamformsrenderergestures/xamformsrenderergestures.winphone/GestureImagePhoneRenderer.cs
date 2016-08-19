using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinPhone;
using XamFormsRendererGestures;
using XamFormsRendererGestures.WinPhone;
using System.Windows.Input;
using System.Diagnostics;

[assembly: ExportRenderer(typeof(GestureImage), typeof(GestureImagePhoneRenderer))]

namespace XamFormsRendererGestures.WinPhone
{
    public class GestureImagePhoneRenderer : ImageRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement == null)
            {
                Tap -= OnTap;
                DoubleTap -= OnDoubleTap;
                ManipulationStarted -= OnManipulationStarted;
                ManipulationDelta -= OnManipulationDelta;
                ManipulationCompleted -= OnManipulationCompleted;
            }

            if (e.OldElement == null)
            {
                Tap += OnTap;
                DoubleTap += OnDoubleTap;
                ManipulationStarted += OnManipulationStarted;
                ManipulationDelta += OnManipulationDelta;
                ManipulationCompleted += OnManipulationCompleted;
            }
        }

        // ManipulationStarted is the same thing as DragCompleted.
        private void OnManipulationCompleted(object sender, ManipulationCompletedEventArgs e)
        {
            Debug.WriteLine("OnManipulationCompleted");
        }

        // ManipulationDelta represents either a drag or a pinch.
        private void OnManipulationDelta(object sender, ManipulationDeltaEventArgs e)
        {
            Debug.WriteLine("OnManipulationDelta");
        }

        // ManipulationStarted is the same thing as DragStarted.
        private void OnManipulationStarted(object sender, System.Windows.Input.ManipulationStartedEventArgs e)
        {
            Debug.WriteLine("OnManipulationStarted");
        }

        private void OnDoubleTap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Debug.WriteLine("OnDoubleTap");
        }

        private void OnTap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Debug.WriteLine("OnTap");
        }
    }
}
