using DeliveryService.Enums;
using DeliveryService.MVVM.View;
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
                    case AppPages.WorkerGeneralInfo:
                        return new WorkerGeneralInfoPage();
                    default:
                        return null;
                }
            }
            return null;
        }

        public override object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Page)
            {
                switch(value)
                {
                    case WorkerGeneralInfoPage:
                        return AppPages.WorkerGeneralInfo;
                    default:
                        return null;
                }
            }
            return null;
        }
    }
}
