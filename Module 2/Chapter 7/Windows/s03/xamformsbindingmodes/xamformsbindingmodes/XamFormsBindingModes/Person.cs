using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace XamFormsBindingModes
{
    public class Person : INotifyPropertyChanged
    {
        private string _firstName;
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                SetFieldAndRaise(ref _firstName, value,
                    () => FirstName, () => FullName);
            }
        }

        private string _lastName;
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                SetFieldAndRaise(ref _lastName, value,
                    () => LastName, () => FullName);
            }
        }
        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", FirstName, LastName);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged.Raise(this, propertyName);
        }

        protected virtual void Raise<T>([CallerMemberName] string propertyName = "")
        {
            PropertyChanged.Raise(this, propertyName);
        }

        protected virtual void Raise<T>(Expression<Func<T>> propertyExpression)
        {
            PropertyChanged.Raise(this, propertyExpression);
        }

        protected virtual void Raise<T>(params Expression<Func<T>>[] propertyExpressions)
        {
            PropertyChanged.Raise(this, propertyExpressions);
        }

        protected virtual bool SetFieldAndRaise<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            if (SetFieldValue<T>(ref field, value)) return false;
            Raise<string>(propertyName);
            return true;
        }

        protected virtual bool SetFieldAndRaise<T>(ref T field, T value, Expression<Func<T>> propertyExpression)
        {
            if (SetFieldValue<T>(ref field, value)) return false;
            Raise(propertyExpression);
            return true;
        }

        protected virtual bool SetFieldAndRaise<T>(ref T field, T value, params Expression<Func<T>>[] propertyExpressions)
        {
            if (SetFieldValue<T>(ref field, value)) return false;
            Raise(propertyExpressions);
            return true;
        }

        private bool SetFieldValue<T>(ref T field, T value)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            return false;
        }
    }
}
