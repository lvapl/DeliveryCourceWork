using System;
using System.Globalization;
using System.Windows.Controls;
using DeliveryService.Enums;
using DeliveryService.View;
using DeliveryService.View.Pages.PickUpPoints;

namespace DeliveryService.Converters
{
    /// <summary>
    /// Конвертер, который принимает страницу в виде значения типа <see cref="PickUpPointPages"/> и возвращает эквивалентную страницу.
    /// </summary>
    public class PickUpPointPageConverter : ConverterBase<PickUpPointPageConverter>
    {
        /// <summary>
        /// Преобразует значение типа <see cref="PickUpPointPages"/> в эквивалентный объект <see cref="Page"/>.
        /// </summary>
        /// <param name="value">Значение типа <see cref="PickUpPointPages"/>, которое нужно преобразовать.</param>
        /// <param name="targetType">Тип, в который нужно преобразовать значение. Этот параметр игнорируется.</param>
        /// <param name="parameter">Дополнительный параметр. Этот параметр игнорируется.</param>
        /// <param name="culture">Объект <see cref="CultureInfo"/>, используемый для преобразования значения. Этот параметр игнорируется.</param>
        /// <returns>Эквивалентный объект <see cref="Page"/>.</returns>
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
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

        /// <summary>
        /// Преобразует значение типа <see cref="Page"/> в эквивалентный объект <see cref="PickUpPointPages"/>.
        /// </summary>
        /// <param name="value">Значение типа <see cref="Page"/>, которое нужно преобразовать.</param>
        /// <param name="targetType">Тип, в который нужно преобразовать значение. Этот параметр игнорируется.</param>
        /// <param name="parameter">Дополнительный параметр. Этот параметр игнорируется.</param>
        /// <param name="culture">Объект <see cref="CultureInfo"/>, используемый для преобразования значения. Этот параметр игнорируется.</param>
        /// <returns>Эквивалентный объект <see cref="PickUpPointPages"/> или null.</returns>
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
