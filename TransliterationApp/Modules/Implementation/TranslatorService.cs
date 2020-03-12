using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransliterationApp.Models;
using TransliterationApp.Models.DbSets;
using TransliterationApp.Modules.Interfaces;

namespace TransliterationApp.Modules.Implementation
{
    public class TranslatorService : ITranslatorService
    {
        TransAppContext db;

        public TranslatorService(TransAppContext context)
        {
            db = context;
        }

        public int ChooseTransliterationSystem(string systemName)
        {
            Alphabet alphabet = db.Alphabets.FirstOrDefault(a => a.SystemName == systemName);
            if (alphabet != null)
            {
                AlphabetLoader.SetCurrentAlphabet(alphabet);
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public string TryToTranslateText(string text)
        {
            if (text != null && AlphabetLoader.alphabet.Count != 0)
            {
                return Translator.TranslateText(text, AlphabetLoader.alphabet);
            }
            else
                return null;
        }
    }
}
