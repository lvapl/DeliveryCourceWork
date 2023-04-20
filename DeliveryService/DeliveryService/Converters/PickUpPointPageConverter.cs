using DeliveryService.Enums;
using DeliveryService.Model;
using DeliveryService.View;
using DeliveryService.View.Pages.PickUpPoints;
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
    public class PickUpPointPageConverter : ConverterBase<PickUpPointPageConverter>
    {
        public override object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is PickUpPointPages)
            {
                switch (value) 
                {
                    case PickUpPointPages.PickUpPointGeneralInfo:
                        return new PickUpPointGeneralInfoPage();
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
                    case PickUpPointGeneralInfoPage:
                        return PickUpPointPages.PickUpPointGeneralInfo;
                    default:
                        return null;
                }
            }
            return null;
        }
    }
}
