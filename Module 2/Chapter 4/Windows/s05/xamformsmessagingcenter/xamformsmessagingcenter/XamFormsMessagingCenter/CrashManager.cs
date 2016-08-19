using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace XamFormsMessagingCenter
{
    public class CrashManager
    {
        public void Dispose()
        {
            MessagingCenter.Unsubscribe<object, Exception>(this, MessagingKey.HandledException.ToString());
        }

        public CrashManager ()
        {
            MessagingCenter.Subscribe<object, Exception>(this, MessagingKey.HandledException.ToString(), (obj, ex) =>
            {
                Debug.WriteLine("Exception: {0}", ex);
            });
        }
    }
}
