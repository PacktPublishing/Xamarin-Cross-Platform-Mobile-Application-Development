using Android.App;
using Android.OS;
using Cirrious.MvvmCross.Droid.Views;

namespace Xamarin.Master.Fibonacci.Android.Views
{
    [Activity(Label = "View for Range Calculation")]
    public class RangeCalculationView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.RangeCalculationView);
        }
    }
}