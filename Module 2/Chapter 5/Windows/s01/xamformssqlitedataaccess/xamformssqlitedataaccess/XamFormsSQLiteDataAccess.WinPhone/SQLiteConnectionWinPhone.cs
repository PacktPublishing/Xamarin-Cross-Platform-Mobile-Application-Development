using SQLite.Net;
using SQLite.Net.Async;
using SQLite.Net.Platform.WindowsPhone8;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(XamFormsSQLiteDataAccess.WinPhone.SQLiteConnectionWinPhone))]

namespace XamFormsSQLiteDataAccess.WinPhone
{
    public class SQLiteConnectionWinPhone : ISQLiteConnection
    {
        private SQLiteAsyncConnection _connection;

        public string GetDataBasePath()
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
