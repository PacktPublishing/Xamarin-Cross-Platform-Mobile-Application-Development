using Foundation;
using System.IO;
using System.Threading.Tasks;

[assembly: Xamarin.Forms.Dependency(typeof(XamFormsPortable.iOS.NameService))]

namespace XamFormsPortable.iOS
{
    public class NameService : INameService
    {
        public async Task<string> GetGreeting(string firstName, string lastName)
        {
            string fullName = string.Format("{0} {1}", firstName, lastName);
            string content = string.Empty;

            string path = NSBundle.MainBundle.PathForResource("PlatformAsset", "txt");
            using (StreamReader stream = new StreamReader(path))
            {
                content = await stream.ReadToEndAsync();
            }
            fullName = string.Format("Hello {0} from {1}", fullName, content);
            return fullName;
        }
    }
}