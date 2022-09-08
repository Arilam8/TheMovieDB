using System;
using System.Globalization;
using System.Windows.Data;

namespace WPFApplication.Converters
{
    public class ReleaseDateCompleteConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is DateTime)
            {
                if (((DateTime)value) == (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue)
                    return "N/A";
                CultureInfo cultureInfo = CultureInfo.InvariantCulture;
                return ((DateTime)value).ToString("dd/MM/yyyy", cultureInfo);
            }
            return "N/A";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
