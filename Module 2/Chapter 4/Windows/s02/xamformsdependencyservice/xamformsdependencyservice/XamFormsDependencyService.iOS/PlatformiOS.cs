[assembly: Xamarin.Forms.Dependency(typeof(XamFormsDependencyService.iOS.PlatformiOS))]

namespace XamFormsDependencyService.iOS
{
    public class PlatformiOS : IPlatform
    {
        public string GetPlatformDescription()
        {
            return "iOS";
        }
    }
}
