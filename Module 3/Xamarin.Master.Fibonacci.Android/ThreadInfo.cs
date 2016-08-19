using Xamarin.Master.Fibonacci.Core;

namespace Xamarin.Master.Fibonacci.Android
{
    public class ThreadInfo : IThreadInfo
    {
        public string CurrentThreadId { get { return Java.Lang.Thread.CurrentThread().Id.ToString(); } }
    }
}