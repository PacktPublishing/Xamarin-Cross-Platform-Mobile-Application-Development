using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Foundation;
using Xamarin.Master.Fibonacci.Core;

namespace Xamarin.Master.Fibonacci.iOS
{
    public class ThreadInfo : IThreadInfo
    {
        public string CurrentThreadId { get { return Thread.CurrentThread.ManagedThreadId.ToString(); } }
    }
}
