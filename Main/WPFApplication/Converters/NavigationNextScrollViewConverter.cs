using System;
using System.Globalization;
using System.Windows.Data;

namespace WPFApplication.Converters
{
    public class NavigationNextScrollViewConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] is double && values[1] is double)
                return (double)values[1] > (double)values[0] ? true : false;
            else
                return false;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
