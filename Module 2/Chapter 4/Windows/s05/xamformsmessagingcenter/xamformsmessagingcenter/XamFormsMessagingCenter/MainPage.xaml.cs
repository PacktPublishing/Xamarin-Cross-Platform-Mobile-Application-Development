using System;
using Xamarin.Forms;

namespace XamFormsMessagingCenter
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

            try
            {
                throw new NotSupportedException("Need to fix this!");
            }
            catch(NotSupportedException ex)
            {
                MessagingCenter.Send<object, Exception>(this, MessagingKey.HandledException.ToString(), ex);
            }
        }
    }
}
