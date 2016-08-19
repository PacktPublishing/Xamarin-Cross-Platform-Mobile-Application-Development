using System;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;

[assembly: Xamarin.Forms.Dependency(typeof(XamFormsPortable.WinPhone.NameService))]

namespace XamFormsPortable.WinPhone
{
    public class NameService : INameService
    {
        public async Task<string> GetGreeting(string firstName, string lastName)
        {
            string fullName = string.Format("{0} {1}", firstName, lastName);
            string content = string.Empty;
            string platformAssetFilePath = @"Assets\PlatformAsset.txt";
            StorageFolder InstallationFolder = Windows.ApplicationModel.Package.Current.InstalledLocation;
            StorageFile file = await InstallationFolder.GetFileAsync(platformAssetFilePath);
            using (StreamReader stream = new StreamReader(await file.OpenStreamForReadAsync()))
            {
                content = await stream.ReadToEndAsync();
            }
            fullName = string.Format("Hello {0} from {1}", fullName, content);
            return fullName;
        }
    }
}
