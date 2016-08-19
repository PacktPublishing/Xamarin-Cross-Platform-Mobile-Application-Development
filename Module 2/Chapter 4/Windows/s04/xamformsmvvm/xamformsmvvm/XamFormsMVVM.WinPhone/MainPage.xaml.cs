using Microsoft.Phone.Controls;
using XLabs.Ioc;

namespace XamFormsMVVM.WinPhone
{
    public partial class MainPage : global::Xamarin.Forms.Platform.WinPhone.FormsApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
            SupportedOrientations = SupportedPageOrientation.PortraitOrLandscape;

            global::Xamarin.Forms.Forms.Init();

            if (!Resolver.IsSet)
            {
                Resolver.SetResolver(new SimpleContainer().GetResolver());
            }

            LoadApplication(new XamFormsMVVM.App());
        }
    }
}
