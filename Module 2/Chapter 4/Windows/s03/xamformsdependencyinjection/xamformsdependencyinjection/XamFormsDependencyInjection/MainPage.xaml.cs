using Xamarin.Forms;
using XLabs.Ioc;

namespace XamFormsDependencyInjection
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

            IDataService dataService = Resolver.Resolve<IDataService>();
			dataService.SettingsRepository.Save ("Username", "George");
            label.Text = dataService.SettingsRepository.GetValue("Username");
        }
    }
}
