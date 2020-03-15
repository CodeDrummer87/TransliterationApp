using System;
using System.IO;
using System.Text;
using TransliterationApp.Models;
using TransliterationApp.Modules.Interfaces;

using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using Microsoft.Extensions.Logging;

namespace TransliterationApp.Modules.Implementation
{
    public class TranslatedTextTransfer : ITranslatedTextTransfer
    {
        private readonly ILogger<TranslatedTextTransfer> logger;

        public TranslatedTextTransfer(ILogger<TranslatedTextTransfer> logger)
        {
            this.logger = logger;
        }

        public int SaveAs(SavingTranslatedText data)
        {
            if (data.asPdf)
            {
                logger.LogInformation($">> PDF format selected");
                return SaveAsFilePdf(data);
            }
            else
            { 
                logger.LogInformation($">> TXT format selected");
                return SaveAsFileText(data);
            }
        }

        private int SaveAsFileText(SavingTranslatedText data)
        {
            try
            {
                string fileName = data.FileName + ".txt";
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string exportFile = Path.Combine(path, fileName);
                File.WriteAllText(exportFile, data.TranslatedText);
                logger.LogInformation($">>> {fileName} saved to your desktop");
                return 1;
            }
            catch
            {
                logger.LogError(">>> Error saving file [TXT]");
                return 0;
            }
        }

        private int SaveAsFilePdf(SavingTranslatedText data)
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
                logger.LogInformation($">>> {fileName} saved to your desktop");
                return 1;
            }
            catch
            {
                logger.LogError(">>> Error saving file [PDF]");
                return 0;
            }
        }
    }
}