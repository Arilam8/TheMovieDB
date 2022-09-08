using System;
using System.Globalization;
using System.Windows.Data;

namespace WPFApplication.Converters
{
    public class SearchHintConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is string)
            {
                switch((string)value)
                {
                    case Utils.Constant.SEARCH_TYPE_MOVIE_TITLE:
                        return "Search for a movie title";
                    case Utils.Constant.SEARCH_TYPE_MOVIE_ACTOR:
                        return "Search for an actor name";
                }
            }
            return "Search";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
