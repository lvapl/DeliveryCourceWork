using DeliveryService.Enums;
using DeliveryService.View;
using DeliveryService.View.Pages.Users;
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
    public class UserPageConverter : ConverterBase<UserPageConverter>
    {
        public override object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is UserPages)
            {
                switch (value) 
                {
                    case UserPages.UserGenerlaInfo:
                        return new UserGeneralInfoPage();
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
                    case UserGeneralInfoPage:
                        return UserPages.UserGenerlaInfo;
                    default:
                        return null;
                }
            }
            return null;
        }
    }
}
