using System;
using System.Globalization;
using System.Windows.Controls;
using DeliveryService.Enums;
using DeliveryService.View;
using DeliveryService.View.Pages.Workers;
using DeliveryService.View.Workers;

namespace DeliveryService.Converters
{
    public class WorkerPageConverter : ConverterBase<WorkerPageConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is WorkerPages)
            {
                switch (value) 
                {
                    case WorkerPages.WorkerGeneralInfo:
                        return new WorkerGeneralInfoPage();
                    case WorkerPages.WorkerPassword:
                        return new WorkerPasswordPage();
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
                    case WorkerPasswordPage:
                        return WorkerPages.WorkerPassword;
                    default:
                        return null;
                }
            }
            return null;
        }
    }
}
