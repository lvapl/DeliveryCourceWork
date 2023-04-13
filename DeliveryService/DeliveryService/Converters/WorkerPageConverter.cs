using DeliveryService.Enums;
using DeliveryService.View;
using DeliveryService.View.Workers;
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
    public class WorkerPageConverter : ConverterBase<WorkerPageConverter>
    {
        public override object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is WorkerPages)
            {
                switch (value) 
                {
                    case WorkerPages.WorkerGeneralInfo:
                        return new WorkerGeneralInfoPage();
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
                    case WorkerGeneralInfoPage:
                        return WorkerPages.WorkerGeneralInfo;
                    default:
                        return null;
                }
            }
            return null;
        }
    }
}
