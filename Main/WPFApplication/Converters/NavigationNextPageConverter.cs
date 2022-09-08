using System;
using System.Globalization;
using System.Windows.Data;

namespace WPFApplication.Converters
{
    public class NavigationNextPageConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] is int && values[1] is int)
                return (int)values[0] < (int)values[1] ? true : false;
            else
                return false;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
