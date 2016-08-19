using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.ViewModels;
using Xamarin.Master.Fibonacci.Core.DataSource;

namespace Xamarin.Master.Fibonacci.Core.ViewModels
{
    public class RangeCalculationViewModel : MvxViewModel
    {
        private FibonacciSourceAsync m_SourceAsync = new FibonacciSourceAsync();

        public RangeCalculationViewModel(IThreadInfo threadInfo)
        {
        }

        private string m_Input1 = "";
        public string Input1
        {
            get { return m_Input1; }
            set { m_Input1 = value; RaisePropertyChanged(() => Input1); }
        }

        private string m_Input2 = "";
        public string Input2
        {
            get { return m_Input2; }
            set { m_Input2 = value; RaisePropertyChanged(() => Input2); }
        }

        private string m_Result = "";
        public string Result
        {
            get { return m_Result; }
            set { m_Result = value; RaisePropertyChanged(() => Result); }
        }

        private string m_InfoText = "";
        public string InfoText
        {
            get { return m_InfoText; }
            set { m_InfoText = value; RaisePropertyChanged(() => InfoText); }
        }

        private float m_Progress = 0f;
        public float Progress
        {
            get { return m_Progress; }
            set
            {
                m_Progress = value;
                Mvx.Trace("New Progress value: {0}", value);
                RaisePropertyChanged(() => Progress);
            }
        }

        private MvxCommand m_DoCalculateCommand;

        public ICommand DoCalculateCommand
        {
            get
            {
                m_DoCalculateCommand = m_DoCalculateCommand ?? new MvxCommand(DoCalculate);
                return m_DoCalculateCommand;
            }
        }

        private void DoCalculate()
        {
            if (!string.IsNullOrWhiteSpace(Input1) && !string.IsNullOrWhiteSpace(Input2))
            {
                int numberOrdinal1, numberOrdinal2;

                if (int.TryParse(Input1, out numberOrdinal1) && int.TryParse(Input2, out numberOrdinal2))
                {
                    InfoText = "Calculating";

                    var currentCount = 0;
                    var totalCount = numberOrdinal2 - numberOrdinal1;

                    Action<int> reportProgress = (value) =>
                    {
                        InfoText = string.Format("{0}% Completed", value);
                    };


                    var progress = new Progress<int>(reportProgress) as IProgress<int>;

                    var blockingCollection = new BlockingCollection<int>();

                    var fibonacciTask = (new FibonacciSourceAsync())
                        .GetFibonacciRangeAsync(numberOrdinal1,
                            numberOrdinal2, blockingCollection);

                    fibonacciTask.ConfigureAwait(false);

                    Task.Factory.StartNew(() =>
                    {
                        foreach (var item in blockingCollection.GetConsumingEnumerable())
                        {
                            var currentTotal = Interlocked.Increment(ref currentCount);
                            decimal currentPercentage = (decimal)currentTotal / (decimal)totalCount;
                            Progress = (float)currentPercentage;
                            progress.Report((int)(currentPercentage * 100));
                            UpdateUIWithItem(item);
                        }

                        InfoText = "Done";

                    }, TaskCreationOptions.LongRunning);

                    return;
                }
            }

            InfoText = "Invalid Input";
        }

        private void UpdateUIWithItem(int item)
        {
            var currentItem = item;
            if (Result != string.Empty)
                Result += ",";

            Result += currentItem;
        }

        private MvxCommand m_CloseCommand;

        public ICommand CloseCommand
        {
            get
            {
                m_CloseCommand = m_CloseCommand ?? new MvxCommand(DoClose);
                return m_CloseCommand;
            }
        }

        private void DoClose()
        {
            Close(this);
        }
    }
}
