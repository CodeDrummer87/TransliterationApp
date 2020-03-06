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

        public string ChooseTransliterationSystem(string systemName)
        {
            Alphabet alphabet = db.Alphabets.FirstOrDefault(a => a.SystemName == systemName);
            if (alphabet != null)
            {
                AlphabetLoader.SetCurrentAlphabet(alphabet);
                return $".:: '{systemName}' system selected for translation";
            }
            else
            {
                return $".:: System not defined";
            }
        }

        public string TryToTranslateText(string text)
        {
            if (text != null && AlphabetLoader.alphabet.Count != 0)
            {
                return Translator.TranslateText(text, AlphabetLoader.alphabet);
            }
            else
                return "No transliteration system selected";
        }
    }
}
