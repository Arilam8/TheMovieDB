using System;
using System.Globalization;
using System.Windows.Data;

namespace WPFApplication.Converters
{
    public class ReleaseDateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is DateTime)
            {
                if (((DateTime)value) == (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue)
                    return "N/A";
                return ((DateTime)value).Year;
            }
            return "N/A";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
