using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace SportsTimingSystem.UI.Helpers
{
    class StringToDateTimeConverter : IValueConverter
    {
        private const string Format = @"mm\:ss\.ff";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime time)
            {
                return time.ToString(Format);
            }
            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (TimeSpan.TryParseExact(value as string, Format, CultureInfo.InvariantCulture, out TimeSpan result))
            {
                DateTime formattedTime = new DateTime(DateTime.Today.Year, DateTime.Today.Day, DateTime.Today.Month);
                formattedTime = formattedTime.Add(result);
                return formattedTime;
            }
            return DependencyProperty.UnsetValue;
        }
    }
}
