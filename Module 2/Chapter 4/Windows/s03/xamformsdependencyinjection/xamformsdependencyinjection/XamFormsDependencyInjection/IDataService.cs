namespace XamFormsDependencyInjection
{
    public interface IDataService
    {
        ISettingsRepository SettingsRepository { get; set; }
    }
}