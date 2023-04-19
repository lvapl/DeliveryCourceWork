using DeliveryService.Enums;
using DeliveryService.View.Pages.Delivery;
using DeliveryService.View;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeliveryService.View.Pages.Storage;
using System.Windows.Controls;

namespace DeliveryService.Converters
{
    public class StoragePageConverter : ConverterBase<StoragePageConverter>
    {
        public override object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is StoragePages)
            {
                switch (value)
                {
                    case StoragePages.StorageGeneralInfo:
                        return new StorageGeneralInfoPage();
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
                switch (value)
                {
                    case StorageGeneralInfoPage:
                        return StoragePages.StorageGeneralInfo;
                    default:
                        return null;
                }
            }
            return null;
        }
    }
}
