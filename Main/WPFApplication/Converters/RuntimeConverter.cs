using System;
using System.Globalization;
using System.Windows.Data;
using Utils.TimeSpanUtils;

namespace WPFApplication.Converters
{
    public class RuntimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is TimeSpan)
            {
                return TimeSpanUtils.GetRuntime((TimeSpan)value);
            }
            return "N/A";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
