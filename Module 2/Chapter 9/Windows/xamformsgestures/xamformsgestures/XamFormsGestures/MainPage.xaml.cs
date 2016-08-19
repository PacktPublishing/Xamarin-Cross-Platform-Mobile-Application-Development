using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace XamFormsGestures
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnImageTapped(object sender, EventArgs args)
        {
            Debug.WriteLine("Image double-tapped!");
        }

        private void OnPinchUpdated(object sender, PinchGestureUpdatedEventArgs e)
        {
            Debug.WriteLine("Image pinched!");
        }
    }
}
