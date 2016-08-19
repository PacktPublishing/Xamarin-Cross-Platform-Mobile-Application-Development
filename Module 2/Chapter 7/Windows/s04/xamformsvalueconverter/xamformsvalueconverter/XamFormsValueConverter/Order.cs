using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace XamFormsValueConverter
{
    public class Order : INotifyPropertyChanged
    {
        private DateTime _dateOrdered;
        public DateTime DateOrdered
        {
            get
            {
                return _dateOrdered;
            }
            set
            {
                SetFieldAndRaise(ref _dateOrdered, value);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        
        protected virtual bool SetFieldAndRaise<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            PropertyChanged.Raise(this, propertyName);
            return true;
        }

        protected virtual void Raise<T>(Expression<Func<T>> propertyExpression)
        {
            PropertyChanged.Raise(this, propertyExpression);
        }

        protected virtual void Raise<T>(params Expression<Func<T>>[] propertyExpressions)
        {
            PropertyChanged.Raise(this, propertyExpressions);
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged.Raise(this, propertyName);
        }

        protected virtual bool SetFieldAndRaise<T>(ref T field, T value, Expression<Func<T>> propertyExpression)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            Raise(propertyExpression);
            return true;
        }

        protected virtual bool SetFieldAndRaise<T>(ref T field, T value, params Expression<Func<T>>[] propertyExpressions)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            Raise(propertyExpressions);
            return true;
        }
    }
}
