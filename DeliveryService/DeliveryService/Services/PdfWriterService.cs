using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using DeliveryService.DTO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Win32;

namespace DeliveryService.Services
{
    public class PdfWriterService : IPdfWriterService
    {
        public void CreatePdfFile<T>(IEnumerable<T> data, Dictionary<string, string> propertyTranslations) where T : class
        {
            // Создаёт диалоговое окно создания файла
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PDF files (*.pdf)|*.pdf"
            };
            if (saveFileDialog.ShowDialog() != true)
            {
                return; // Пользователь отменил диалоговое окно
            }

            // Создаёт PDF документ
            Document doc = new Document(new Rectangle(PageSize.A4.Height, PageSize.A4.Width), 10f, 10f, 10f, 10f);
            PdfWriter.GetInstance(doc, new FileStream(saveFileDialog.FileName, FileMode.Create));
            doc.Open();

            string? path = Directory.GetParent(Environment.CurrentDirectory)?.Parent?.Parent?.FullName;
            if (path != null)
            {
                BaseFont baseFont = BaseFont.CreateFont(Path.Combine(path, "Resources", "Fonts", "Roboto-Medium.ttf"), BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                Font font = new Font(baseFont, 12, Font.NORMAL);

                // Создание таблицы
                PdfPTable table = new PdfPTable(typeof(T).GetProperties().Count(x => propertyTranslations.ContainsKey(x.Name)));

                // Добавление заголовков столбцов
                foreach (PropertyInfo prop in typeof(T).GetProperties())
                {
                    if (propertyTranslations.ContainsKey(prop.Name))
                    {
                        string translatedName = propertyTranslations[prop.Name];

                        PdfPHeaderCell cell = new PdfPHeaderCell
                        {
                            Phrase = new Phrase(translatedName, font),
                            BackgroundColor = new BaseColor(220, 220, 220),
                            HorizontalAlignment = Element.ALIGN_CENTER,
                            VerticalAlignment = Element.ALIGN_MIDDLE
                        };
                        table.AddCell(cell);
                    }
                }

                // Добавляет данные в таблицу
                foreach (T item in data)
                {
                    foreach (PropertyInfo prop in typeof(T).GetProperties())
                    {
                        if (propertyTranslations.ContainsKey(prop.Name))
                        {
                            object? propValue = prop.GetValue(item);
                            if (propValue == null)
                            {
                                PdfPCell emptyCell = new PdfPCell
                                {
                                    HorizontalAlignment = Element.ALIGN_CENTER,
                                    VerticalAlignment = Element.ALIGN_MIDDLE
                                };
                                table.AddCell(emptyCell);
                            }
                            else
                            {
                                if (prop.PropertyType == typeof(AddressDTO))
                                {
                                    string cellText = "";
                                    // Если свойство комплексное, то оно заполняет по другому
                                    foreach (PropertyInfo nestedProp in prop.PropertyType.GetProperties())
                                    {
                                        if (!(nestedProp.Name != "Id" && nestedProp.Name.Contains("Id")))
                                        {
                                            object? nestedPropValue = nestedProp.GetValue(propValue);
                                            cellText += (nestedPropValue?.ToString() ?? "") + "  ";
                                        } 
                                    }

                                    PdfPCell cell = new PdfPCell(new Phrase(cellText, font))
                                    {
                                        HorizontalAlignment = Element.ALIGN_CENTER,
                                        VerticalAlignment = Element.ALIGN_MIDDLE
                                    };
                                    table.AddCell(cell);
                                }
                                else if (prop.PropertyType == typeof(UserDTO))
                                {
                                    string cellText = "";

                                    // Если свойство комплексное, то оно заполняет по другому
                                    foreach (PropertyInfo nestedProp in prop.PropertyType.GetProperties())
                                    {
                                        if (nestedProp.Name == "Id"
                                            || nestedProp.Name == "FirstName"
                                            || nestedProp.Name == "LastName"
                                            || nestedProp.Name == "Patronymic")
                                        {
                                            object? nestedPropValue = nestedProp.GetValue(propValue);
                                            cellText += nestedPropValue;
                                        }
                                    }

                                    PdfPCell cell = new PdfPCell(new Phrase(cellText, font))
                                    {
                                        HorizontalAlignment = Element.ALIGN_CENTER,
                                        VerticalAlignment = Element.ALIGN_MIDDLE
                                    };
                                    table.AddCell(cell);
                                }
                                else
                                {
                                    PdfPCell cell = new PdfPCell(new Phrase(propValue.ToString(), font))
                                        {
                                            HorizontalAlignment = Element.ALIGN_CENTER,
                                            VerticalAlignment = Element.ALIGN_MIDDLE
                                        };
                                    table.AddCell(cell);
                                }
                            }
                        
                        }
                    }
                }

                // Add table to the document and close it
                table.CompleteRow();
                doc.Add(table);
            }

            doc.Close();
        }
    }
}
