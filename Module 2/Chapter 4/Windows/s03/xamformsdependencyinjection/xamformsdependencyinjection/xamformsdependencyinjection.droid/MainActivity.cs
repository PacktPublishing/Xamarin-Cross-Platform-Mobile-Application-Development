using Android.App;
using Android.Content.PM;
using Android.OS;
using Ninject;
using XLabs.Ioc.Ninject;
using XLabs.Ioc;

namespace XamFormsDependencyInjection.Droid
{
    [Activity(Label = "XamFormsDependencyInjection", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            SetupDependencyContainer();

            LoadApplication(new App());
        }

        private void SetupDependencyContainer()
        {
            StandardKernel standardKernel = new StandardKernel();
            NinjectContainer resolverContainer = new NinjectContainer(standardKernel);

            standardKernel.Bind<ISettingsRepository>().To<SettingsDroidRepository>().InSingletonScope();
            standardKernel.Bind<IDataService>().To<DataService>().InSingletonScope();

            Resolver.SetResolver(resolverContainer.GetResolver());
        }
    }
}

