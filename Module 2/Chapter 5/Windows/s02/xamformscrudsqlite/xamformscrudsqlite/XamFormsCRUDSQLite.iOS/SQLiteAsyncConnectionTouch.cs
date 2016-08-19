using System;
using SQLite.Net.Async;
using System.IO;
using SQLite.Net;
using SQLite.Net.Platform.XamarinIOS;
using Xamarin.Forms;

[assembly: Dependency(typeof(XamFormsCRUDSQLite.iOS.SQLiteAsyncConnectionServiceTouch))]

namespace XamFormsCRUDSQLite.iOS
{
    public class SQLiteAsyncConnectionServiceTouch : ISQLiteAsyncConnectionService
    {
        private SQLiteAsyncConnection _connection;

        private static string GetDataBasePath()
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
