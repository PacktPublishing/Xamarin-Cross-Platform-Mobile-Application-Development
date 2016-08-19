using SQLite.Net;
using SQLite.Net.Async;
using SQLite.Net.Platform.XamarinAndroid;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(XamFormsCRUDSQLite.Droid.SQLiteAsyncConnectionServiceDroid))]

namespace XamFormsCRUDSQLite.Droid
{
    public class SQLiteAsyncConnectionServiceDroid : ISQLiteAsyncConnectionService
    {
        private SQLiteAsyncConnection _connection;

        private static string GetDataBasePath()
        {
            string filename = "MyDb.db3";
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
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
                    new SQLitePlatformAndroid(),
                    new SQLiteConnectionString(GetDataBasePath(), true));
            return _connection = new SQLiteAsyncConnection(() => connectioonWithLock);
        }
    }
}