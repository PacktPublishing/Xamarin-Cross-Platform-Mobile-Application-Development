using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.App.Backup;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Widget;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Droid.Views;
using Xamarin.Master.Fibonacci.Core;
using Xamarin.Master.Fibonacci.Core.DataSource;
using Xamarin.Master.Fibonacci.Core.ViewModels;
using Xamarin.Master.Fibonacci.Android.Services;
using Environment = Android.OS.Environment;
using File = Java.IO.File;
using Uri = Android.Net.Uri;

namespace Xamarin.Master.Fibonacci.Android.Views
{
    [Activity(Label = "View for FirstViewModel")]
    public class MainView : MvxActivity
    {

        public MainView()
        {
           
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.MainView);
        }
    }
}