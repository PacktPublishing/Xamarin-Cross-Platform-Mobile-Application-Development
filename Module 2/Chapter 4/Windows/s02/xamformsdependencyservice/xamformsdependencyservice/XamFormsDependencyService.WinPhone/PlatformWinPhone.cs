[assembly: Xamarin.Forms.Dependency(typeof(XamFormsDependencyService.WinPhone.PlatformWinPhone))]

namespace XamFormsDependencyService.WinPhone
{
    public class PlatformWinPhone : IPlatform
    {
        public string GetPlatformDescription()
        {
            return "Windows Phone";
        }
    }
}
