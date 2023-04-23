using System;
using System.Globalization;
using System.Windows.Controls;
using DeliveryService.Enums;
using DeliveryService.View;
using DeliveryService.View.Pages.Storage;

namespace DeliveryService.Converters
{
    public class StoragePageConverter : ConverterBase<StoragePageConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
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
