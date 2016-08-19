using SQLite.Net.Async;

namespace XamFormsCRUDSQLite
{
    public interface ISQLiteAsyncConnectionService
    {
        SQLiteAsyncConnection GetConnection();
    }
}
