using System;
using System.Globalization;
using System.Windows.Controls;
using DeliveryService.Enums;
using DeliveryService.View;
using DeliveryService.View.Pages.Delivery;

namespace DeliveryService.Converters
{
    /// <summary>
    /// Конвертер, который принимает страницу в виде значения типа <see cref="DeliveryPages"/> и возвращает эквивалентную страницу.
    /// </summary>
    public class DeliveryPageConverter : ConverterBase<DeliveryPageConverter>
    {
        /// <summary>
        /// Преобразует значение типа <see cref="DeliveryPages"/> в эквивалентный объект <see cref="Page"/>.
        /// </summary>
        /// <param name="value">Значение типа <see cref="DeliveryPages"/>, которое нужно преобразовать.</param>
        /// <param name="targetType">Тип, в который нужно преобразовать значение. Этот параметр игнорируется.</param>
        /// <param name="parameter">Дополнительный параметр. Этот параметр игнорируется.</param>
        /// <param name="culture">Объект <see cref="CultureInfo"/>, используемый для преобразования значения. Этот параметр игнорируется.</param>
        /// <returns>Эквивалентный объект <see cref="Page"/>.</returns>
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DeliveryPages)
            {
                switch (value)
                {
                    case DeliveryPages.DeliveryGeneralInfo:
                        return new DeliveryGeneralInfoPage();
                    default:
                        return new EmptyPage();
                }
            }
            return new EmptyPage();
        }

        /// <summary>
        /// Преобразует значение типа <see cref="Page"/> в эквивалентный объект <see cref="DeliveryPages"/>.
        /// </summary>
        /// <param name="value">Значение типа <see cref="Page"/>, которое нужно преобразовать.</param>
        /// <param name="targetType">Тип, в который нужно преобразовать значение. Этот параметр игнорируется.</param>
        /// <param name="parameter">Дополнительный параметр. Этот параметр игнорируется.</param>
        /// <param name="culture">Объект <see cref="CultureInfo"/>, используемый для преобразования значения. Этот параметр игнорируется.</param>
        /// <returns>Эквивалентный объект <see cref="DeliveryPages"/> или null.</returns>
        public override object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Page)
            {
                switch (value)
                {
                    case DeliveryGeneralInfoPage:
                        return DeliveryPages.DeliveryGeneralInfo;
                    default:
                        return null;
                }
            }
            return null;
        }
    }
}
