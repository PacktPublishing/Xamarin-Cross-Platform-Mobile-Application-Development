using SQLite.Net.Async;
using Xamarin.Forms;
using System.IO;
using SQLite.Net;
using SQLite.Net.Platform.WindowsPhone8;

[assembly: Dependency(typeof(XamFormsCRUDSQLite.WinPhone.SQLiteAsyncConnectionServiceWinPhone))]

namespace XamFormsCRUDSQLite.WinPhone
{
    public class SQLiteAsyncConnectionServiceWinPhone : ISQLiteAsyncConnectionService
    {
        private SQLiteAsyncConnection _connection;

        private static string GetDataBasePath()
        {
            string filename = "MyDb.db3";
            string path = Windows.Storage.ApplicationData.Current.LocalFolder.Path;
            return Path.Combine(path, filename);
        }

        public SQLiteAsyncConnection GetConnection()
        {
            if (_connection != null)
            {
                return _connection;
            }

            SQLiteConnectionWithLock connectioonWithLock =
                new SQLiteConnectionWithLock(
                    new SQLitePlatformWP8(),
                    new SQLiteConnectionString(GetDataBasePath(), true));
            return _connection = new SQLiteAsyncConnection(() => connectioonWithLock);
        }
    }
}
