using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace DeliveryService.Converters
{
    /// <summary>
    /// Базовый класс для конвертеров, реализующих интерфейсы IValueConverter и MarkupExtension.
    /// </summary>
    /// <typeparam name="T">Тип конвертера, должен быть классом и иметь публичный конструктор без параметров.</typeparam>
    public abstract class ConverterBase<T> : MarkupExtension, IValueConverter
        where T : class, new()
    {
        /// <summary>
        /// Преобразует значение объекта.
        /// </summary>
        /// <param name="value">Входное значение объекта.</param>
        /// <param name="targetType">Тип целевого свойства.</param>
        /// <param name="parameter">Дополнительный параметр.</param>
        /// <param name="culture">Языковые и региональные настройки.</param>
        /// <returns>Преобразованное значение.</returns>
        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

        /// <summary>
        /// Преобразует значение объекта обратно в исходный формат.
        /// </summary>
        /// <param name="value">Преобразованное значение.</param>
        /// <param name="targetType">Тип целевого свойства.</param>
        /// <param name="parameter">Дополнительный параметр.</param>
        /// <param name="culture">Языковые и региональные настройки.</param>
        /// <returns>Исходное значение объекта.</returns>
        public virtual object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Возвращает объект конвертера.
        /// </summary>
        /// <param name="serviceProvider">Объект, предоставляющий сервисы для расширения разметки.</param>
        /// <returns>Объект конвертера.</returns>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return _converter ??= new T();
        }

        private static T? _converter;
    }
}
