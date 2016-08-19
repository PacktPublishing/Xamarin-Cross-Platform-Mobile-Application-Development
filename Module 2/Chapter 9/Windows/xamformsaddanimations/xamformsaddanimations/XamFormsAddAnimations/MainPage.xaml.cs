using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamFormsAddAnimations
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnButtonClicked(object sender, EventArgs args)
        {
            await Task.WhenAll(
                image.FadeTo(1.0, 400, Easing.BounceIn),
                image.RotateTo(360, 400, Easing.BounceOut),
                image.LayoutTo(new Rectangle(200, image.Y, image.Width, image.Height), 2000, Easing.Linear))
                    .ContinueWith(async (antecedent) =>
                    {
                        if (antecedent.Status == TaskStatus.RanToCompletion)
                        {
                            await image.ScaleTo(1.5, 200);
                            await image.ScaleTo(1.0, 200);
                            await image.LayoutTo(new Rectangle(0, image.Y, image.Width, image.Height), 2000, Easing.Linear);
                        }
                    }, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}