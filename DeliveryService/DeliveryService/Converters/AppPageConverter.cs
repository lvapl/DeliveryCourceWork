using System;
using System.Globalization;
using System.Windows.Controls;
using DeliveryService.Enums;
using DeliveryService.View;

namespace DeliveryService.Converters
{
    /// <summary>
    /// Конвертер, который принимает страницу в виде значения типа <see cref="AppPages"/> и возвращает эквивалентную страницу.
    /// </summary>
    public class AppPageConverter : ConverterBase<AppPageConverter>
    {
        /// <summary>
        /// Преобразует значение типа <see cref="AppPages"/> в эквивалентный объект <see cref="Page"/>.
        /// </summary>
        /// <param name="value">Значение типа <see cref="AppPages"/>, которое нужно преобразовать.</param>
        /// <param name="targetType">Тип, в который нужно преобразовать значение. Этот параметр игнорируется.</param>
        /// <param name="parameter">Дополнительный параметр. Этот параметр игнорируется.</param>
        /// <param name="culture">Объект <see cref="CultureInfo"/>, используемый для преобразования значения. Этот параметр игнорируется.</param>
        /// <returns>Эквивалентный объект <see cref="Page"/>.</returns>
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
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
                    case AppPages.PickUpPoint:
                        return new PickUpPointPage();
                    default:
                        return new EmptyPage();
                }
            }

            return new EmptyPage();
        }

        /// <summary>
        /// Преобразует значение типа <see cref="Page"/> в эквивалентный объект <see cref="AppPages"/>.
        /// </summary>
        /// <param name="value">Значение типа <see cref="Page"/>, которое нужно преобразовать.</param>
        /// <param name="targetType">Тип, в который нужно преобразовать значение. Этот параметр игнорируется.</param>
        /// <param name="parameter">Дополнительный параметр. Этот параметр игнорируется.</param>
        /// <param name="culture">Объект <see cref="CultureInfo"/>, используемый для преобразования значения. Этот параметр игнорируется.</param>
        /// <returns>Эквивалентный объект <see cref="AppPages"/> или null.</returns>
        public override object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Page)
            {
                switch (value)
                {
                    case WorkerPage:
                        return AppPages.Worker;
                    case UserPage:
                        return AppPages.User;
                    case DeliveryPage:
                        return AppPages.Delivery;
                    case StoragePage:
                        return AppPages.Storage;
                    case PickUpPointPage:
                        return AppPages.PickUpPoint;
                    default:
                        return null;
                }
            }
            return null;
        }
    }
}
