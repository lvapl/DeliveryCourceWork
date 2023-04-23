using System;
using System.Globalization;
using System.Windows.Controls;
using DeliveryService.Enums;
using DeliveryService.View;
using DeliveryService.View.Pages.Delivery;

namespace DeliveryService.Converters
{
    public class DeliveryPageConverter : ConverterBase<DeliveryPageConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DeliveryPages)
            {
                switch (value) 
                {
                    case DeliveryPages.DeliveryGeneralInfo:
                        return new DeliveryGeneralInfoPage();
                    default:
                        return new EmptyPage();
                }
            }
            return new EmptyPage();
        }

        public override object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Page)
            {
                switch(value)
                {
                    case DeliveryGeneralInfoPage:
                        return DeliveryPages.DeliveryGeneralInfo;
                    default:
                        return null;
                }
            }
            return null;
        }
    }
}
