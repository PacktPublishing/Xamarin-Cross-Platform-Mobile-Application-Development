using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Cirrious.CrossCore;

namespace Xamarin.Master.Fibonacci.Core.DataSource
{
    public class FibonacciSource
    {
        private static FibonacciSource m_Instance = null;

        private FibonacciCache m_FibonacciCache = null;

        public IThreadInfo ThreadInfo
        {
            get
            {
                return Mvx.GetSingleton<IThreadInfo>();
            }
        }

        private void TraceThreadInfo(string message)
        {
            Debug.WriteLine(message + " on Thread '{0}'", ThreadInfo.CurrentThreadId);
            //Debug.WriteLine("Current Syncronization Context is {0}", SynchronizationContext.Current);
        }

        public FibonacciSource(FibonacciCache cache = null)
        {
            m_FibonacciCache = cache;

            if (m_FibonacciCache == null) m_FibonacciCache = new FibonacciCache();
        }

        public event EventHandler<FibonacciItem> CalculationCompleted;

        public event EventHandler<List<FibonacciItem>> RangeCalculationCompleted;

        public event EventHandler<string> CalculationFailed;

        public FibonacciItem GetFibonacciNumberInternal(int ordinal)
        {
            if (ordinal < 0)
            {
                Debug.WriteLine("Error:" + "Throwing OUtOfRangeException");
                throw new ArgumentOutOfRangeException("ordinal", "Cannot calculate Fibonacci number for a negative number");
            }

            //if (m_FibonacciCache != null && m_FibonacciCache[ordinal] != null)
            //{
            //    return m_FibonacciCache[ordinal];
            //}

            FibonacciItem result = null;

            int previous = 0;

            int next = 1;

            for (int i = 0; i < ordinal; i++)
            {
                var delayTask = Task.Delay(100);
                delayTask.Wait();

                int sum = next + previous;
                previous = next;

                next = sum;
            }

            result = new FibonacciItem(next, DateTime.Now);

            //if (m_FibonacciCache != null && m_FibonacciCache[ordinal] == null)
            //{
            //    m_FibonacciCache[ordinal] = result;
            //}

            return result;
        }

        public void GetFibonacciNumberAsync(int ordinal)
        {
            TraceThreadInfo("Begin FibonacciSource.GetFibonacciNumberAsync");

            //if (ordinal < 0)
            //{
            //    if (CalculationFailed != null) CalculationFailed(this, "Cannot calculate Fibonacci number for a negative number");
            //throw new ArgumentOutOfRangeException("ordinal", "Cannot calculate Fibonacci number for a negative number");
            //}


            Task.Factory.StartNew(() =>
            {
                try
                {

                    TraceThreadInfo("Begin FibonacciSource.GetFibonacciNumberInternal");

                    var result = GetFibonacciNumberInternal(ordinal);

                    TraceThreadInfo("End FibonacciSource.GetFibonacciNumberInternal");

                    if (CalculationCompleted != null) CalculationCompleted(this, result);

                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Debug.WriteLine("Error:" + ex.Message);

                    if (CalculationFailed != null) CalculationFailed(this, ex.Message);
                }
            }, TaskCreationOptions.LongRunning);

            TraceThreadInfo("End FibonacciSource.GetFibonacciNumberAsync");
        }

        public List<FibonacciItem> GetFibonacciRangeAsyncWithProgress(int firstOrdinal, int lastOrdinal, IProgress<int> progress = null)
        {
            var results = new List<FibonacciItem>();

            for (var i = firstOrdinal; i < lastOrdinal; i++)
            {
                results.Add(GetFibonacciNumberInternal(i));

                if (progress != null)
                    progress.Report(((lastOrdinal - i) / (lastOrdinal - firstOrdinal)) * 100);
            }

            return results;
        }

        public void GetFibonacciRangeAsync(int firstOrdinal, int lastOrdinal)
        {
            try
            {
                var result = GetFibonacciRangeAsyncWithProgress(firstOrdinal, lastOrdinal);

                if (RangeCalculationCompleted != null) RangeCalculationCompleted(this, result);
            }
            catch (Exception ex)
            {
                if (CalculationFailed != null) CalculationFailed(this, ex.Message);
            }
        }

        public static FibonacciSource Instance
        {
            get
            {
                if (m_Instance == null) m_Instance = new FibonacciSource();

                return m_Instance;
            }
            set { m_Instance = value; }
        }

        public FibonacciCache Cache
        {
            get { return m_FibonacciCache; }
            set { m_FibonacciCache = value; }
        }
    }

    public class FibonacciSourceAsync : FibonacciSource
    {
        public int GetFibonacciNumber(int ordinal)
        {
            throw new NotImplementedException();
        }

        public new Task<int> GetFibonacciNumberAsync(int ordinal)
        {
            var myTaskSource = new TaskCompletionSource<int>();

            EventHandler<FibonacciItem> onCalculationCompleted = null;
            EventHandler<string> onCalculationFailed = null;

            //
            // Subscribe to TaskCompleted: When the CalculationCompleted event is fired, set result.
            onCalculationCompleted = (sender, args) =>
            {
                // Not forgetting to release the event handler
                CalculationCompleted -= onCalculationCompleted;
                myTaskSource.SetResult(args.Value);
            };

            //
            // Subscribe to TaskFailed: If there is an error in the execution, set error.
            onCalculationFailed = (sender, args) =>
            {
                CalculationFailed -= onCalculationFailed;
                myTaskSource.SetException(new Exception(args));
            };

            CalculationCompleted += onCalculationCompleted;

            CalculationFailed += onCalculationFailed;

            // Finally execute the task and return the associated Task promise.
            base.GetFibonacciNumberAsync(ordinal);

            return myTaskSource.Task;

        }

        public async Task<List<int>> GetFibonacciRangeAsync(int firstOrdinal, int lastOrdinal, IProgress<int> progress = null)
        {
            int currentCount = 0;

            int totalCount = lastOrdinal - firstOrdinal;

            List<Task<int>> calculations = new List<Task<int>>();

            Mvx.Trace("Starting Calculations");

            for (var i = firstOrdinal; i < lastOrdinal; i++)
            {
                var currentOrdinal = i;
                calculations.Add(Task.Factory.StartNew(() =>
                    GetFibonacciNumberInternal(currentOrdinal).Value, TaskCreationOptions.LongRunning)
                    .ContinueWith(task =>
                    {
                        if (progress != null)
                        {
                            var currentTotal = Interlocked.Increment(ref currentCount);
                            decimal currentPercentage = (decimal)currentTotal / (decimal)totalCount;
                            progress.Report((int)(currentPercentage * 100));
                        }
                        return task.Result;
                    }));
            }

            Mvx.Trace("Starting When All", DateTime.Now);
            int[] results = await Task.WhenAll(calculations);
            Mvx.Trace("Calculations Completed", DateTime.Now);

            return results.OrderBy(value => value).ToList();
        }

        public async Task GetFibonacciRangeAsync(int firstOrdinal, int lastOrdinal, BlockingCollection<int> blockingCollection)
        {
            List<Task<int>> calculations = new List<Task<int>>();

            Mvx.Trace("Starting Calculations");

            for (var i = firstOrdinal; i < lastOrdinal; i++)
            {
                var currentOrdinal = i;

                calculations.Add(Task.Factory.StartNew(() =>
                    GetFibonacciNumberInternal(currentOrdinal).Value, TaskCreationOptions.LongRunning)
                    .ContinueWith(task =>
                    {
                        blockingCollection.Add(task.Result);
                        return task.Result;
                    }));
            }

            Debug.WriteLine("Starting When All", DateTime.Now);

            //
            // Collection is filled completely
            await Task.WhenAll(calculations).ContinueWith(task =>
            {
                blockingCollection.CompleteAdding();
            });

            Mvx.Trace("Calculations Completed", DateTime.Now);
        }
    }
}