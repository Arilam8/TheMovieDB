using System;
using System.Globalization;
using System.Windows.Data;

namespace WPFApplication.Converters
{
    public class RatingTheMovieDBConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is float)
                return Math.Round((float)value, 2);
            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
