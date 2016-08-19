using System.Threading.Tasks;

namespace XamFormsPortable
{
    public interface INameService
    {
        Task<string> GetGreeting(string firstName, string lastName);
    }
}
