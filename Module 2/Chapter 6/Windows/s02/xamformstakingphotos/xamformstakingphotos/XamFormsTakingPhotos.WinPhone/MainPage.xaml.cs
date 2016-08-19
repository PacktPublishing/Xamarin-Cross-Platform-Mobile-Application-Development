using Microsoft.Phone.Controls;
using Plugin.Media;
using Xamarin.Forms;

namespace XamFormsTakingPhotos.WinPhone
{
    public partial class MainPage : global::Xamarin.Forms.Platform.WinPhone.FormsApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
            SupportedOrientations = SupportedPageOrientation.PortraitOrLandscape;

            global::Xamarin.Forms.Forms.Init();
            DependencyService.Register<MediaImplementation>();
            LoadApplication(new XamFormsTakingPhotos.App());
        }
    }
}
