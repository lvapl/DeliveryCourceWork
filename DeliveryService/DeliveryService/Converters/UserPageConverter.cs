using System;
using System.Globalization;
using System.Windows.Controls;
using DeliveryService.Enums;
using DeliveryService.View;
using DeliveryService.View.Pages.Users;

namespace DeliveryService.Converters
{
    /// <summary>
    /// Конвертер, который принимает страницу в виде значения типа <see cref="UserPages"/> и возвращает эквивалентную страницу.
    /// </summary>
    public class UserPageConverter : ConverterBase<UserPageConverter>
    {
        /// <summary>
        /// Преобразует значение типа <see cref="UserPages"/> в эквивалентный объект <see cref="Page"/>.
        /// </summary>
        /// <param name="value">Значение типа <see cref="UserPages"/>, которое нужно преобразовать.</param>
        /// <param name="targetType">Тип, в который нужно преобразовать значение. Этот параметр игнорируется.</param>
        /// <param name="parameter">Дополнительный параметр. Этот параметр игнорируется.</param>
        /// <param name="culture">Объект <see cref="CultureInfo"/>, используемый для преобразования значения. Этот параметр игнорируется.</param>
        /// <returns>Эквивалентный объект <see cref="Page"/>.</returns>
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

        /// <summary>
        /// Преобразует значение типа <see cref="Page"/> в эквивалентный объект <see cref="UserPages"/>.
        /// </summary>
        /// <param name="value">Значение типа <see cref="Page"/>, которое нужно преобразовать.</param>
        /// <param name="targetType">Тип, в который нужно преобразовать значение. Этот параметр игнорируется.</param>
        /// <param name="parameter">Дополнительный параметр. Этот параметр игнорируется.</param>
        /// <param name="culture">Объект <see cref="CultureInfo"/>, используемый для преобразования значения. Этот параметр игнорируется.</param>
        /// <returns>Эквивалентный объект <see cref="UserPages"/> или null.</returns>
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
