using Xamarin.Forms;

namespace XamFormsLocalization
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

            label.Text = AppResources.HelloWorld;
        }
    }
}
