using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace XamFormsOnPlatform
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Device.OnPlatform(
                iOS: () =>
                {
                    label.FontFamily = "HelveticaNeue-Thin";
                    label.FontSize = 10;
                },
                Android: () => 
                {
                    label.FontFamily = "Arial Black";
                    label.FontSize = 20;
                },
                WinPhone: () =>
                {
                    label.FontFamily = "Calibri";
                    label.FontSize = 30;
                }
           );
        }
    }
}
