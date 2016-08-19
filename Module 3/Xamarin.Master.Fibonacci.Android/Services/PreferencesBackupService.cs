using Android.App.Backup;
using Android.OS;
using Java.IO;

namespace Xamarin.Master.Fibonacci.Android.Services
{
    public class PreferencesBackupService : BackupAgentHelper
    {
        public override void OnCreate()
        {
            var preferencesHelper = new SharedPreferencesBackupHelper(this, "ApplicationSettings");
            AddHelper("ApplicationPreferences", preferencesHelper);

            System.Diagnostics.Debug.WriteLine("PreferencesBackupService was created", "BackUp");

            base.OnCreate();
        }

        public override void OnFullBackup(FullBackupDataOutput data)
        {
            System.Diagnostics.Debug.WriteLine("OnFullBackup initiated", "BackUp");

            base.OnFullBackup(data);
        }

        public override void OnBackup(ParcelFileDescriptor oldState, BackupDataOutput data, ParcelFileDescriptor newState)
        {
            System.Diagnostics.Debug.WriteLine("OnBackup initiated", "BackUp");

            base.OnBackup(oldState, data, newState);
        }

        public override void OnRestoreFile(ParcelFileDescriptor data, long size, File destination, BackupFileType type, long mode, long mtime)
        {
            System.Diagnostics.Debug.WriteLine("OnRestore initiated", "BackUp");

            base.OnRestoreFile(data, size, destination, type, mode, mtime);
        }

        public override void OnRestore(BackupDataInput data, int appVersionCode, ParcelFileDescriptor newState)
        {
            System.Diagnostics.Debug.WriteLine("Data restore is requested");

            base.OnRestore(data, appVersionCode, newState);
        }
    }
}