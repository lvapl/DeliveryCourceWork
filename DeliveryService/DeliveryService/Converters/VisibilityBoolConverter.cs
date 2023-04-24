using System;
using System.Globalization;
using System.Windows;

namespace DeliveryService.Converters
{
    /// <summary>
    /// Конвертер, который принимает логическое значение типа <see cref="bool"/> и возвращает <see cref="Visibility"/>.
    /// </summary>
    public class VisibilityBoolConverter : ConverterBase<VisibilityBoolConverter>
    {
        /// <summary>
        /// Преобразует значение типа <see cref="bool"/> в эквивалентный объект <see cref="Visibility"/>.
        /// </summary>
        /// <param name="value">Значение типа <see cref="bool"/>, которое нужно преобразовать.</param>
        /// <param name="targetType">Тип, в который нужно преобразовать значение. Этот параметр игнорируется.</param>
        /// <param name="parameter">Дополнительный параметр. Этот параметр игнорируется.</param>
        /// <param name="culture">Объект <see cref="CultureInfo"/>, используемый для преобразования значения. Этот параметр игнорируется.</param>
        /// <returns>Эквивалентный объект <see cref="Visibility"/>.</returns>
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool)
            {
                return (bool)value ? Visibility.Visible : Visibility.Hidden;
            }
            return false;
        }

        /// <summary>
        /// Преобразует значение типа <see cref="Visibility"/> в эквивалентный объект <see cref="bool"/>.
        /// </summary>
        /// <param name="value">Значение типа <see cref="Visibility"/>, которое нужно преобразовать.</param>
        /// <param name="targetType">Тип, в который нужно преобразовать значение. Этот параметр игнорируется.</param>
        /// <param name="parameter">Дополнительный параметр. Этот параметр игнорируется.</param>
        /// <param name="culture">Объект <see cref="CultureInfo"/>, используемый для преобразования значения. Этот параметр игнорируется.</param>
        /// <returns>Эквивалентный объект <see cref="bool"/> или null.</returns>
        public override object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is Visibility)
            {
                return (Visibility)value == Visibility.Visible;
            }
            return null;
        }
    }
}
