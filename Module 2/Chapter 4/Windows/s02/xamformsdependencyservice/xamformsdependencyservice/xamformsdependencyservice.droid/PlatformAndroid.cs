using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using XamFormsDependencyService;

[assembly: Xamarin.Forms.Dependency(typeof(XamFormsDependencyService.Droid.PlatformAndroid))]

namespace XamFormsDependencyService.Droid
{
    public class PlatformAndroid : IPlatform
    {
        public string GetPlatformDescription()
        {
            return "Android";
        }
    }
}