using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinPhone;
using XamFormsNativePages;
using XamFormsNativePages.WinPhone;

[assembly: ExportRenderer(typeof(XamFormsNativePages.MainPage), typeof(MainPageRenderer))]

namespace XamFormsNativePages.WinPhone
{
    public class MainPageRenderer : PageRenderer
    {
        private System.Windows.Controls.Button _button;

        private XamFormsNativePages.MainPage Page
        {
            get { return Element as XamFormsNativePages.MainPage; }
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);

            var oldPage = e.OldElement as XamFormsNativePages.MainPage;
            if (oldPage != null)
            {
                oldPage.PropertyChanged -= OnPagePropertyChanged;
            }

            var newPage = e.NewElement as XamFormsNativePages.MainPage;
            if (newPage != null)
            {
                newPage.PropertyChanged += OnPagePropertyChanged;
            }

            WindowsPhoneControl ctrl = new WindowsPhoneControl();
            _button = ctrl.button;
            _button.Click += OnButtonClick;
            Children.Add(ctrl);

            UpdateButtonText();
        }

        private void OnPagePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == XamFormsNativePages.MainPage.RandomNumberProperty.PropertyName)
            {
                UpdateButtonText();
            }
        }

        private void UpdateButtonText()
        {
            if (Page != null)
            {
                _button.Content = Page.RandomNumber.ToString();
            }
        }

        private void OnButtonClick(object sender, EventArgs e)
        {
            if (Page != null)
            {
                Page.OnButtonPressed();
            }
        }
    }
}
