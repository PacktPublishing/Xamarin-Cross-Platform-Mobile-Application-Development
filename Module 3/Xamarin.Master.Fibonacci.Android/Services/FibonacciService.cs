using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Master.Core.DataSource;

namespace Xamarin.Master.Android.Services
{
[Service]
[IntentFilter(new String[] { "com.xamarin.MyDemoService" })]
public class MyDemoService : IntentService
{
    public MyDemoService()
        : base("MyDemoService")
    {
    }

    protected override void OnHandleIntent(Intent intent)
    {
        var myParameter = intent.GetStringExtra("parameter");

    }
}
}