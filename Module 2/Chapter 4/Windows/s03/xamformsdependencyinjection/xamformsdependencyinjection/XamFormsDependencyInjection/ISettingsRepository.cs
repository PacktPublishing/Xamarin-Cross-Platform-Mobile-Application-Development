namespace XamFormsDependencyInjection
{
    public interface ISettingsRepository
    {
        void Save(string key, string value);
        string GetValue(string key);
    }
}
