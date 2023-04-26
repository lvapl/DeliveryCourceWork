using System.Collections.Generic;

namespace DeliveryService.Services
{
    /// <summary>
    /// Интерфейс, представляющий сервис записи данных в PDF.
    /// </summary>
    public interface IPdfWriterService
    {
        /// <summary>
        /// Метод, выполняющий создание PDF файла из данных.
        /// </summary>
        /// <typeparam name="T">Тип передаваемых данных.</typeparam>
        /// <param name="data">Сами данные</param>
        /// <param name="propertyTranslations">Словарь необходимых столбцов, так же является их переводом.</param>
        public void CreatePdfFile<T>(IEnumerable<T> data, Dictionary<string, string> propertyTranslations) where T : class;
    }
}
