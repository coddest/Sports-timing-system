using System;
using System.Globalization;
using System.Windows.Data;

namespace SportsTimingSystem.UI.Helpers
{
    internal class EnumToStringConverter : IValueConverter
    {
        public EnumToStringConverter()
        {
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string response = string.Empty;

            if (parameter is not null)
            {
                response = (bool)value ? "Visible" : "Hidden";
            }
            else
            {
                response = (bool)value ? "Hidden" : "Visible";
            }
            return response;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
