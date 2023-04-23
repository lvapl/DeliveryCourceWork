using System;
using System.Globalization;
using System.Windows;

namespace DeliveryService.Converters
{
    public class VisibilityBoolConverter : ConverterBase<VisibilityBoolConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool)
            {
                return (bool)value ? Visibility.Visible : Visibility.Hidden;
            }
            return false;
        }

        public override object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is Visibility)
            {
                return (Visibility)value == Visibility.Visible;
            }
            return null;
        }
    }
}
