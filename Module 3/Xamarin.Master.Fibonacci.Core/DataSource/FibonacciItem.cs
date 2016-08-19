using System;

namespace Xamarin.Master.Fibonacci.Core.DataSource
{
    public class FibonacciItem
    {
        public int Value { get; private set; }

        private readonly DateTime m_Calculated;

        public FibonacciItem(int value, DateTime calculatedTime)
        {
            Value = value;

            m_Calculated = calculatedTime;
        }
    }
}