using Android.Content.Res;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(XamFormsPortable.Droid.NameService))]

namespace XamFormsPortable.Droid
{
    public class NameService : INameService
    {
        public async Task<string> GetGreeting(string firstName, string lastName)
        {
            string fullName = string.Format("{0} {1}", firstName, lastName);
            string content = string.Empty;
            AssetManager assets = Forms.Context.Resources.Assets;
            using (StreamReader stream = new StreamReader(assets.Open("PlatformAsset.txt")))
            {
                content = await stream.ReadToEndAsync();
                fullName = string.Format("Hello {0} from {1}", fullName, content);
                return fullName;
            }
        }
    }
}
