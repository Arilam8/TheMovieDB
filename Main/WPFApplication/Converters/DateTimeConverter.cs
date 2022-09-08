using System;
using System.Globalization;
using System.Windows.Data;

namespace WPFApplication.Converters
{
    public class DateTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is DateTime)
                return ((DateTime)value).ToString("g", CultureInfo.CreateSpecificCulture("fr-BE"));
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
