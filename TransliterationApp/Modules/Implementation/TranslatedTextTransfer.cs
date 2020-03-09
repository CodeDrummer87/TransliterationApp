using System;
using System.IO;
using System.Text;
using TransliterationApp.Models;
using TransliterationApp.Modules.Interfaces;

using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;


namespace TransliterationApp.Modules.Implementation
{
    public class TranslatedTextTransfer : ITranslatedTextTransfer
    {
        public string SaveAs(SavingTranslatedText data)
        {
            if (data.asPdf)
            {
                return SaveAsFilePdf(data);
            }
            else
            {
                return SaveAsFileText(data);
            }
        }

        private string SaveAsFileText(SavingTranslatedText data)
        {
            try
            {
                string fileName = data.FileName + ".txt";
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string exportFile = Path.Combine(path, fileName);
                File.WriteAllText(exportFile, data.TranslatedText);

                return $".:: File '{fileName}' saved to the desktop";
            }
            catch
            {
                return ".:: Save error";
            }
        }

        private string SaveAsFilePdf(SavingTranslatedText data)
        {
            try
            {
                string fileName = data.FileName + ".pdf";

                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                PdfFont russian = PdfFontFactory.CreateFont(
                    @"C:\Windows\Fonts\Verdana.ttf", "CP1251", true);

                var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                var exportFile = Path.Combine(path, fileName);

                using (var writer = new PdfWriter(exportFile))
                {
                    using (var pdf = new PdfDocument(writer))
                    {
                        var doc = new Document(pdf);
                        doc.SetFont(russian);
                        doc.Add(new Paragraph("TRANSLATION TRANSLITERATION"));
                        doc.Add(new Paragraph(data.TranslatedText));
                    }
                }

                return $".:: File '{fileName}' saved to the desktop";
            }
            catch
            {
                return ".:: Save error";
            }
        }
    }
}