using Foundation;
using System.Diagnostics;
using System.Globalization;
using Xamarin.Forms;

[assembly: Dependency(typeof(XamFormsLocalization.iOS.Localize))]

namespace XamFormsLocalization.iOS
{
    public class Localize : ILocalize
    {
        public CultureInfo GetCurrentCultureInfo()
        {
            string netLanguage = "en";
            string prefLanguageOnly = "en";

            if (NSLocale.PreferredLanguages.Length > 0)
            {
                var pref = NSLocale.PreferredLanguages[0];
                prefLanguageOnly = pref.Substring(0, 2);
                netLanguage = pref.Replace("_", "-");
                Debug.WriteLine("Preferred language:" + netLanguage);
            }

            CultureInfo ci = null;
            try
            {
                ci = new CultureInfo(netLanguage);
            }
            catch
            {
                // iOS locale not valid .NET culture (eg. "en-ES" : English in Spain)
                // fallback to first characters, in this case "en"
                ci = new CultureInfo(prefLanguageOnly);
            }

            return ci;
        }
    }
}
