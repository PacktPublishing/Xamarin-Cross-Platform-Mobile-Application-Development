using System;
using System.Diagnostics;
using System.Globalization;
using Xamarin.Forms;

namespace XamFormsValueConverter
{
    public class DateTimeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime dateValue = (DateTime)value;
            string stringDate = dateValue.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture);
            Debug.WriteLine("DateTime to string: {0}", stringDate);
            return stringDate;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime dateValue;

            if (!DateTime.TryParse(value as string, out dateValue))
            {
                throw new NotSupportedException();
            }
            Debug.WriteLine("string value to DateTime: {0}", dateValue.ToString());
            return dateValue;
        }
    }
}
