using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransliterationApp.Models
{
    public class SavingTranslatedText
    {
        public string FileName { get; set; }
        public string TranslatedText { get; set; }
        public bool asPdf { get; set; }
    }
}
