using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransliterationApp.Modules.Interfaces
{
    public interface ITranslatorService
    {
        string ChooseTransliterationSystem(string systemName);
        string TryToTranslateText(string text);
    }
}
