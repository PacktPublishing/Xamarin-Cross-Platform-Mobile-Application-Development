using Android.App;
using Android.Content.PM;
using Android.OS;
using Plugin.LocalNotifications;
using Xamarin.Forms;

namespace XamFormsLocalNotifications.Droid
{
    [Activity(Label = "XamFormsLocalNotifications", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            DependencyService.Register<LocalNotificationsImplementation>();

            LoadApplication(new App());
        }
    }
}

