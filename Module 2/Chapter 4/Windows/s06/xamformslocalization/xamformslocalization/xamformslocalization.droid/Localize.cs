using Java.Util;
using System.Diagnostics;
using System.Globalization;
using Xamarin.Forms;

[assembly: Dependency(typeof(XamFormsLocalization.Droid.Localize))]

namespace XamFormsLocalization.Droid
{
    public class Localize : ILocalize
    {
        public CultureInfo GetCurrentCultureInfo()
        {
            Locale androidLocale = Locale.Default;
            string netLanguage = androidLocale.ToString().Replace("_", "-");
            Debug.WriteLine("NetLanguage: {0}", netLanguage);
            return new CultureInfo(netLanguage);
        }
    }
}