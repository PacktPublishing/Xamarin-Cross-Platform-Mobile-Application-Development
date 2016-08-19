using System;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;

namespace Xamarin.Master.Fibonacci.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        public MainViewModel()
        {
        }

        private MvxCommand m_NavigateToSingleCalculationCommand;

        public ICommand NavigateToSingleCalculationCommand
        {
            get
            {
                m_NavigateToSingleCalculationCommand = m_NavigateToSingleCalculationCommand ?? new MvxCommand(DoNavigateToSingleCalculationView);
                return m_NavigateToSingleCalculationCommand;
            }
        }

        private void DoNavigateToSingleCalculationView()
        {
            ShowViewModel<SingleCalculationViewModel>();
        }

        private MvxCommand m_NavigateToRangeCalculationCommand;

        public ICommand NavigateToRangeCalculationCommand
        {
            get
            {
                m_NavigateToRangeCalculationCommand = m_NavigateToRangeCalculationCommand ?? new MvxCommand(DoNavigateToRangeCalculationView);
                return m_NavigateToRangeCalculationCommand;
            }
        }

        private void DoNavigateToRangeCalculationView()
        {
            ShowViewModel<RangeCalculationViewModel>();
        }

        private MvxCommand m_GarbageCollectCommand;

        public ICommand GarbageCollectCommand
        {
            get
            {
                m_GarbageCollectCommand = m_GarbageCollectCommand ?? new MvxCommand(DoGarbageCollect);
                return m_GarbageCollectCommand;
            }
        }

        private void DoGarbageCollect()
        {
            GC.Collect();
        }
    }
}
