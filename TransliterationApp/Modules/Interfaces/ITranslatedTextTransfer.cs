using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransliterationApp.Models;

namespace TransliterationApp.Modules.Interfaces
{
    public interface ITranslatedTextTransfer
    {
        string SaveAsFileText(SavingTranslatedText data);
    }
}
