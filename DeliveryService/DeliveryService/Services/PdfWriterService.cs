using iTextSharp.text.pdf;
using iTextSharp.text;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Document = iTextSharp.text.Document;
using DeliveryService.DTO;

namespace DeliveryService.Services
{
    public class PdfWriterService : IPdfWriterService
    {
        public void CreatePdfFile<T>(IEnumerable<T> data, Dictionary<string, string> propertyTranslations) where T : class
        {
            // Create a file dialog to allow the user to choose the destination file
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
            if (saveFileDialog.ShowDialog() != true)
            {
                return; // User canceled the dialog
            }

            // Create a PDF document
            Document doc = new Document(new Rectangle(PageSize.A4.Height, PageSize.A4.Width), 10f, 10f, 10f, 10f);
            PdfWriter.GetInstance(doc, new FileStream(saveFileDialog.FileName, FileMode.Create));
            doc.Open();

            BaseFont baseFont = BaseFont.CreateFont(Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, "Resources", "Fonts", "Roboto-Medium.ttf"), BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            Font font = new Font(baseFont, 12, Font.NORMAL);

            // Create a table
            PdfPTable table = new PdfPTable(typeof(T).GetProperties().Where(x => propertyTranslations.ContainsKey(x.Name)).Count());

            // Add table header
            foreach (PropertyInfo prop in typeof(T).GetProperties())
            {
                if (propertyTranslations.ContainsKey(prop.Name))
                {
                    string translatedName = propertyTranslations[prop.Name];

                    PdfPHeaderCell cell = new PdfPHeaderCell();
                    cell.Phrase = new Phrase(translatedName, font);
                    cell.BackgroundColor = new BaseColor(220, 220, 220);
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    table.AddCell(cell);
                }
            }

            // Add table data
            foreach (T item in data)
            {
                foreach (PropertyInfo prop in typeof(T).GetProperties())
                {
                    if (propertyTranslations.ContainsKey(prop.Name))
                    {
                        object? propValue = prop.GetValue(item);
                        if (propValue == null)
                        {
                            PdfPCell emptyCell = new PdfPCell();
                            emptyCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            emptyCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            table.AddCell(emptyCell);
                        }
                        else
                        {
                            if (prop.PropertyType == typeof(AddressDTO))
                            {
                                string cellText = "";
                                // If the property type is a complex type, recursively add its nested properties to the table
                                foreach (PropertyInfo nestedProp in prop.PropertyType.GetProperties())
                                {
                                    if (!(nestedProp.Name != "Id" && nestedProp.Name.Contains("Id")))
                                    {
                                        object? nestedPropValue = nestedProp.GetValue(propValue);
                                        cellText += (nestedPropValue?.ToString() ?? "") + "  ";
                                    } 
                                }

                                PdfPCell cell = new PdfPCell(new Phrase(cellText, font));
                                cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                                cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                                table.AddCell(cell);
                            }
                            else if (prop.PropertyType == typeof(UserDTO))
                            {
                                string cellText = "";

                                // If the property type is a complex type, recursively add its nested properties to the table
                                foreach (PropertyInfo nestedProp in prop.PropertyType.GetProperties())
                                {
                                    if (nestedProp.Name == "Id"
                                     || nestedProp.Name == "FirstName"
                                     || nestedProp.Name == "LastName"
                                     || nestedProp.Name == "Patronymic")
                                    {
                                        object? nestedPropValue = nestedProp.GetValue(propValue);
                                        cellText += nestedPropValue?.ToString() + " " ?? "";
                                    }
                                }

                                PdfPCell cell = new PdfPCell(new Phrase(cellText, font));
                                cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                                cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                                table.AddCell(cell);
                            }
                            else
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(propValue.ToString(), font));
                                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                                table.AddCell(cell);
                            }
                        }
                        
                    }
                }
            }

            // Add table to the document and close it
            table.CompleteRow();
            doc.Add(table);
            doc.Close();
        }
    }
}
