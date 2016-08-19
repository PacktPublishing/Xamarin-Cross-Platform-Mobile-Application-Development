using Android.App;
using Android.Content.PM;
using Android.OS;
using Plugin.Geolocator;
using Xamarin.Forms;

namespace XamFormsQueryGps.Droid
{
    [Activity(Label = "XamFormsQueryGps", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            DependencyService.Register<GeolocatorImplementation>();
            LoadApplication(new App());
        }
    }
}

