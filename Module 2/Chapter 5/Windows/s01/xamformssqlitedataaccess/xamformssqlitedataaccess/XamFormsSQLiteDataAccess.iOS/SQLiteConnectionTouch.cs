using System;
using SQLite.Net.Async;
using SQLite.Net;
using SQLite.Net.Platform.XamarinIOS;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(XamFormsSQLiteDataAccess.iOS.SQLiteConnectionTouch))]

namespace XamFormsSQLiteDataAccess.iOS
{
    public class SQLiteConnectionTouch : ISQLiteConnection
    {
        private SQLiteAsyncConnection _connection;

        public string GetDataBasePath()
        {
            string filename = "MyDb.db3";
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }

            return Path.Combine(libFolder, filename);
        }

        public SQLiteAsyncConnection GetConnection()
        {
            if (_connection != null)
            {
                return _connection;
            }

            SQLiteConnectionWithLock connectioonWithLock =
                new SQLiteConnectionWithLock(
                    new SQLitePlatformIOS(),
                    new SQLiteConnectionString(GetDataBasePath(), true));
            return _connection = new SQLiteAsyncConnection(() => connectioonWithLock);
        }
    }
}
