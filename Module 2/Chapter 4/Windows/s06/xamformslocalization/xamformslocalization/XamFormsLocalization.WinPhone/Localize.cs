using System.Globalization;
using System.Threading;
using Xamarin.Forms;

[assembly: Dependency(typeof(XamFormsLocalization.WinPhone.Localize))]

namespace XamFormsLocalization.WinPhone
{
    public class Localize : ILocalize
    {
        public CultureInfo GetCurrentCultureInfo()
        {
            return Thread.CurrentThread.CurrentUICulture;
        }
    }
}
