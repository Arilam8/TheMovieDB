using System;
using System.Globalization;
using System.Windows.Data;
using Utils.ParserUtils;

namespace WPFApplication.Converters
{
    public class RatingBarTheMovieDBConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is float)
                return Math.Round((float)value, 2) - 1;
            return -1;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int)
                return ParserUtils.ParseFloat(value.ToString()) + 1;
            return 0;
        }
    }
}
