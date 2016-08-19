using System;
using System.Threading.Tasks;
using System.IO;
using Xamarin.Forms;

#if WINDOWS_PHONE

using Windows.Storage;

#elif __IOS__

using Foundation;

#elif __ANDROID__

using Android.Content.Res;
using Android.Content;

#endif

namespace XamFormsSharedProject
{
    public class NameService
    {
        public async Task<string> GetGreeting(string firstName, string lastName)
        {
            string fullName = string.Format("{0} {1}", firstName, lastName);
            string content = string.Empty;

#if WINDOWS_PHONE

           string platformAssetFilePath = @"Assets\PlatformAsset.txt";
            StorageFolder InstallationFolder = Windows.ApplicationModel.Package.Current.InstalledLocation;
            StorageFile file = await InstallationFolder.GetFileAsync(platformAssetFilePath);
            using (StreamReader stream = new StreamReader(await file.OpenStreamForReadAsync()))
            {
                content = await stream.ReadToEndAsync();
            }

#elif __ANDROID__

            AssetManager assets = Forms.Context.Resources.Assets;
            using (StreamReader stream = new StreamReader (assets.Open ("PlatformAsset.txt")))
            {
                content = await stream.ReadToEndAsync();
            }

#elif __IOS__
            
            string path = NSBundle.MainBundle.PathForResource ("PlatformAsset", "txt");
            using (StreamReader stream = new StreamReader (path))
            {
                content = await stream.ReadToEndAsync();
            }

#endif
            fullName = string.Format("Hello {0} from {1}", fullName, content);
            return fullName;
        }
    }
}
