using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XamFormsPlatformGesture;
using XamFormsPlatformGesture.iOS;

[assembly: ExportRenderer(typeof(CustomBoxView), typeof(CustomBoxViewRenderer))]

namespace XamFormsPlatformGesture.iOS
{
    public class CustomBoxViewRenderer : BoxRenderer
    {
        UILongPressGestureRecognizer longPressGestureRecognizer;
        
        protected override void OnElementChanged(ElementChangedEventArgs<BoxView> e)
        {
            base.OnElementChanged(e);

            longPressGestureRecognizer = new UILongPressGestureRecognizer(() => Debug.WriteLine("Long Press"));

            if (e.NewElement == null)
            {
                if (longPressGestureRecognizer != null)
                {
                    this.RemoveGestureRecognizer(longPressGestureRecognizer);
                }
            }

            if (e.OldElement == null)
            {
                this.AddGestureRecognizer(longPressGestureRecognizer);
            }
        }
    }
}
