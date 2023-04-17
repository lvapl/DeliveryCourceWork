using DeliveryService.Enums;
using DeliveryService.View;
using DeliveryService.View.Pages.Delivery;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;

namespace DeliveryService.Converters
{
    public class DeliveryPageConverter : ConverterBase<DeliveryPageConverter>
    {
        public override object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
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
