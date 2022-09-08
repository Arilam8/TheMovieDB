using System;
using System.Globalization;
using System.Windows.Data;
using WPFApplication.Models;

namespace WPFApplication.Converters
{
    public class RoleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is RoleModel)
            {
                if (((RoleModel)value).Id == -1 || string.IsNullOrEmpty(((RoleModel)value).Character))
                    return "N/A";
                else
                    return ((RoleModel)value).Character;
            }
            return "N/A";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
