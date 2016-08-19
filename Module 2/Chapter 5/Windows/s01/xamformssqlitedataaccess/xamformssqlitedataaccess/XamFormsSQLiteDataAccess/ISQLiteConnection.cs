using SQLite.Net.Async;

namespace XamFormsSQLiteDataAccess
{
    public interface ISQLiteConnection
    {
        string GetDataBasePath();
        SQLiteAsyncConnection GetConnection();
    }
}
