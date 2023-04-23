using System;
using System.Globalization;
using System.Windows.Controls;
using DeliveryService.Enums;
using DeliveryService.View;
using DeliveryService.View.Pages.Users;

namespace DeliveryService.Converters
{
    public class UserPageConverter : ConverterBase<UserPageConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
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
