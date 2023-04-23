using System;
using System.Globalization;
using System.Windows.Controls;
using DeliveryService.Enums;
using DeliveryService.View;

namespace DeliveryService.Converters
{
    /// <summary>
    /// Конвертер, преобразующий перечисление AppPages в соответствующие страницы приложения.
    /// </summary>
    public class AppPageConverter : ConverterBase<AppPageConverter>
    {
        /// <summary>
        /// Преобразует перечисление AppPages в соответствующие страницы приложения.
        /// </summary>
        /// <param name="value">Значение, которое требуется преобразовать.</param>
        /// <param name="targetType">Тип целевого свойства.</param>
        /// <param name="parameter">Дополнительный параметр.</param>
        /// <param name="culture">Языковые и региональные настройки.</param>
        /// <returns>Соответствующую страницу приложения.</returns>
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
        /// Преобразует страницы приложения обратно в перечисление AppPages.
        /// </summary>
        /// <param name="value">Значение, которое требуется преобразовать.</param>
        /// <param name="targetType">Тип целевого свойства.</param>
        /// <param name="parameter">Дополнительный параметр.</param>
        /// <param name="culture">Языковые и региональные настройки.</param>
        /// <returns>Перечисление AppPages, соответствующее странице приложения.</returns>
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
