using Microsoft.Phone.Controls;
using Ninject;
using XLabs.Ioc.Ninject;
using XLabs.Ioc;

namespace XamFormsDependencyInjection.WinPhone
{
    public partial class MainPage : global::Xamarin.Forms.Platform.WinPhone.FormsApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
            SupportedOrientations = SupportedPageOrientation.PortraitOrLandscape;

            global::Xamarin.Forms.Forms.Init();

            SetupDependencyContainer();

            LoadApplication(new XamFormsDependencyInjection.App());
        }

        private void SetupDependencyContainer()
        {
            StandardKernel standardKernel = new StandardKernel();
            NinjectContainer resolverContainer = new NinjectContainer(standardKernel);

            standardKernel.Bind<ISettingsRepository>().To<SettingsPhoneRepository>().InSingletonScope();
            standardKernel.Bind<IDataService>().To<DataService>().InSingletonScope();

            Resolver.SetResolver(resolverContainer.GetResolver());
        }
    }
}
