namespace XamFormsDependencyInjection
{
    public class DataService : IDataService
    {
        public ISettingsRepository SettingsRepository { get; set; }

        public DataService(ISettingsRepository settingsRepository)
        {
            SettingsRepository = settingsRepository;
        }
    }
}
