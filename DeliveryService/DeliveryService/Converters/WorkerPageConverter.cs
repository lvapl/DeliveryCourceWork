using System;
using System.Globalization;
using System.Windows.Controls;
using DeliveryService.Enums;
using DeliveryService.View;
using DeliveryService.View.Pages.Workers;
using DeliveryService.View.Workers;

namespace DeliveryService.Converters
{ 
    /// <summary>
    /// Конвертер, который принимает страницу в виде значения типа <see cref="WorkerPages"/> и возвращает эквивалентную страницу.
    /// </summary>
    public class WorkerPageConverter : ConverterBase<WorkerPageConverter>
    {
        
        /// /// <summary>
        /// Преобразует значение типа <see cref="WorkerPages"/> в эквивалентный объект <see cref="Page"/>.
        /// </summary>
        /// <param name="value">Значение типа <see cref="WorkerPages"/>, которое нужно преобразовать.</param>
        /// <param name="targetType">Тип, в который нужно преобразовать значение. Этот параметр игнорируется.</param>
        /// <param name="parameter">Дополнительный параметр. Этот параметр игнорируется.</param>
        /// <param name="culture">Объект <see cref="CultureInfo"/>, используемый для преобразования значения. Этот параметр игнорируется.</param>
        /// <returns>Эквивалентный объект <see cref="Page"/>.</returns>
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

        /// <summary>
        /// Преобразует значение типа <see cref="Page"/> в эквивалентный объект <see cref="WorkerPages"/>.
        /// </summary>
        /// <param name="value">Значение типа <see cref="Page"/>, которое нужно преобразовать.</param>
        /// <param name="targetType">Тип, в который нужно преобразовать значение. Этот параметр игнорируется.</param>
        /// <param name="parameter">Дополнительный параметр. Этот параметр игнорируется.</param>
        /// <param name="culture">Объект <see cref="CultureInfo"/>, используемый для преобразования значения. Этот параметр игнорируется.</param>
        /// <returns>Эквивалентный объект <see cref="WorkerPages"/> или null.</returns>
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
