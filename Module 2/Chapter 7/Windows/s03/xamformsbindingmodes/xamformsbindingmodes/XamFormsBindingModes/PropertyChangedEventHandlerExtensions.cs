using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace XamFormsBindingModes
{
    public static class PropertyChangedEventHandlerExtensions
    {
        public static void Raise<T>(this PropertyChangedEventHandler handler, object sender, Expression<Func<T>> propertyExpression)
        {
            var body = propertyExpression.Body as MemberExpression;
            if (body == null)
                throw new ArgumentException("'propertyExpression' should be a member expression");

            var expression = body.Expression as ConstantExpression;
            if (expression == null)
                throw new ArgumentException("'propertyExpression' body should be a constant expression");

            handler.Raise(sender, body.Member.Name);
        }

        public static void Raise<T>(this PropertyChangedEventHandler handler, object sender, params Expression<Func<T>>[] propertyExpressions)
        {
            foreach (var propertyExpression in propertyExpressions)
            {
                handler.Raise<T>(sender, propertyExpression);
            }
        }

        public static void Raise(this PropertyChangedEventHandler propertyChangedHandler, object sender, [CallerMemberName] string propertyName = "")
        {
            var handler = propertyChangedHandler;
            if (handler != null)
            {
                handler(sender, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
