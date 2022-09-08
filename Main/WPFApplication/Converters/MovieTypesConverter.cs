using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using Utils.TextUtils;
using WPFApplication.Models;

namespace WPFApplication.Converters
{
    public class MovieTypesConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is List<MovieTypeModel>)
            {
                if(((List<MovieTypeModel>)value).Count == 0)
                    return "N/A";
                return TextUtils.GetTextList(((List<MovieTypeModel>)value).Select(m => m.Name).ToList());
            }
            return "N/A";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
