using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinPhone;
using XamFormsPlatformGesture;
using XamFormsPlatformGesture.WinPhone;

[assembly: ExportRenderer(typeof(CustomBoxView), typeof(CustomBoxViewRenderer))]

namespace XamFormsPlatformGesture.WinPhone
{
    public class CustomBoxViewRenderer : BoxViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<BoxView> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement == null)
            {
                this.Hold -= OnHold;
            }

            if (e.OldElement == null)
            {
                this.Hold += OnHold;
            }
        }

        private void OnHold(object sender, GestureEventArgs e)
        {
            Debug.WriteLine("OnHold");
        }
    }
}
