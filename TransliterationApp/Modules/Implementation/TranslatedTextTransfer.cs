using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using TransliterationApp.Models;
using TransliterationApp.Modules.Interfaces;

namespace TransliterationApp.Modules.Implementation
{
    public class TranslatedTextTransfer : ITranslatedTextTransfer
    {
        public string SaveAsFileText(SavingTranslatedText data)
        {
            if (data != null)
            {
                try
                {
                    string fileName = data.FileName + ".txt";
                    string path = data.Path + fileName;
                    File.WriteAllText(path, data.TranslatedText);
                    return ".:: Saving text to file was successful";
                }
                catch
                {
                    return ".:: Invalid save path";
                }
            }
            else
            {
                return ".:: Save error";
            }
        }
    }
}
