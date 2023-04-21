using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Services
{
    public interface IPdfWriterService
    {
        public void CreatePdfFile<T>(IEnumerable<T> data, Dictionary<string, string> propertyTranslations) where T : class;
    }
}
