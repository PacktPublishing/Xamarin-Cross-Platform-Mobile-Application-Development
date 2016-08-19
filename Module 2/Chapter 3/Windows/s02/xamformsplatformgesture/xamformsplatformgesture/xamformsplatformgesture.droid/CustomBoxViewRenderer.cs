using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms.Platform.Android;
using XamFormsPlatformGesture;
using XamFormsPlatformGesture.Droid;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(CustomBoxView), typeof(CustomBoxViewRenderer))]

namespace XamFormsPlatformGesture.Droid
{
    public class CustomBoxViewRenderer : BoxRenderer
    {
        private readonly CustomBoxViewGestureListener _listener;
        private readonly GestureDetector _detector;

        public CustomBoxViewRenderer()
        {
            _listener = new CustomBoxViewGestureListener();
            _detector = new GestureDetector(_listener);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<BoxView> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement == null)
            {
                if (this.GenericMotion != null)
                {
                    this.GenericMotion -= HandleGenericMotion;
                }
                if (this.Touch != null)
                {
                    this.Touch -= HandleTouch;
                }
            }

            if (e.OldElement == null)
            {
                this.GenericMotion += HandleGenericMotion;
                this.Touch += HandleTouch;
            }
        }

        void HandleTouch(object sender, TouchEventArgs e)
        {
            _detector.OnTouchEvent(e.Event);
        }

        void HandleGenericMotion(object sender, GenericMotionEventArgs e)
        {
            _detector.OnTouchEvent(e.Event);
        }
    }
}