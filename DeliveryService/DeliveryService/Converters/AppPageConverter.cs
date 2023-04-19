using DeliveryService.Enums;
using DeliveryService.View;
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
    public class AppPageConverter : ConverterBase<AppPageConverter>
    {
        public override object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is AppPages)
            {
                switch (value) 
                {
                    case AppPages.Worker:
                        return new WorkerPage();
                    case AppPages.User:
                        return new UserPage();
                    case AppPages.Delivery:
                        return new DeliveryPage();
                    case AppPages.Storage:
                        return new StoragePage();
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
                    case WorkerPage:
                        return AppPages.Worker;
                    case UserPage:
                        return AppPages.User;
                    case DeliveryPage:
                        return AppPages.Delivery;
                    case StoragePage:
                        return AppPages.Storage;
                    default:
                        return null;
                }
            }
            return null;
        }
    }
}
