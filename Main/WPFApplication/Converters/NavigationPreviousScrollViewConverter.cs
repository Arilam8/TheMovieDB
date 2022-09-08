using System;
using System.Globalization;
using System.Windows.Data;

namespace WPFApplication.Converters
{
    public class NavigationPreviousScrollViewConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double)
                return (double)value > 0 ? true : false;
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
