using Microsoft.Phone.Controls;
using Plugin.Geolocator;
using Xamarin.Forms;

namespace XamFormsQueryGps.WinPhone
{
    public partial class MainPage : global::Xamarin.Forms.Platform.WinPhone.FormsApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
            SupportedOrientations = SupportedPageOrientation.PortraitOrLandscape;

            global::Xamarin.Forms.Forms.Init();
            DependencyService.Register<GeolocatorImplementation>();
            LoadApplication(new XamFormsQueryGps.App());
        }
    }
}
