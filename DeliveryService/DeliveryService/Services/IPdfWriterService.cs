using System.Collections.Generic;

namespace DeliveryService.Services
{
    public interface IPdfWriterService
    {
        public void CreatePdfFile<T>(IEnumerable<T> data, Dictionary<string, string> propertyTranslations) where T : class;
    }
}
