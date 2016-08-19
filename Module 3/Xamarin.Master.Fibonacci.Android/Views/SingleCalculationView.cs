using Android.App;
using Android.OS;
using Cirrious.MvvmCross.Droid.Views;
using Xamarin.Master.Fibonacci.Core.DataSource;

namespace Xamarin.Master.Fibonacci.Android.Views
{
    [Activity(Label = "View for Single Calculation")]
    public class SingleCalculationView : MvxActivity
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.SingleCalculationView);
        }
    }
}