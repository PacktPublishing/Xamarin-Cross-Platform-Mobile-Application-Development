using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.ViewModels;
using Xamarin.Master.Fibonacci.Core.DataSource;

namespace Xamarin.Master.Fibonacci.Core.ViewModels
{
    public class SingleCalculationViewModel : MvxViewModel
    {

        public IThreadInfo ThreadInfo
        {
            get { return Mvx.GetSingleton<IThreadInfo>(); }
        }

        private void TraceThreadInfo(string message)
        {
            Debug.WriteLine("{0} on Thread '{1}'", message, ThreadInfo.CurrentThreadId);
            //Debug.WriteLine("Current Syncronization Context is {0}", SynchronizationContext.Current);
        }

        public SingleCalculationViewModel()
        {
        }

        private string m_Input = "";
        public string Input
        {
            get { return m_Input; }
            set { m_Input = value; RaisePropertyChanged(() => Input); }
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
            TraceThreadInfo("Begin DoCalculate");

            if (!string.IsNullOrWhiteSpace(Input))
            {
                int numberOrdinal;

                if (int.TryParse(Input, out numberOrdinal))
                {
                    InfoText = "Calculating";

                    try
                    {
                        TraceThreadInfo("Starting Calculations");

                        //await Task.WhenAll(tasks);

                        (new FibonacciSourceAsync()).GetFibonacciNumberAsync(numberOrdinal)
                        .ContinueWith((task) =>
                        {
                            TraceThreadInfo("Response from GetFibonacciNumberAsync");

                            Result = task.Result.ToString();

                            InfoText = string.Empty;
                        });
                    }
                    catch (Exception ex)
                    {
                        //Debug.WriteLine("Error:" + ex.Message);

                        //Result = string.Empty;

                        //InfoText = string.Join("\r\n", ex
                        //    .InnerExceptions.Select(exception => exception.Message));
                    }

                    //}, TaskCreationOptions.LongRunning);

                    //await task;

                    TraceThreadInfo("End DoCalculate");

                    return;
                }
            }

            InfoText = "Invalid Input";
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
