using Microsoft.Extensions.Logging;
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
        private readonly ILogger<TranslatorService> logger;

        public TranslatorService(TransAppContext context, ILogger<TranslatorService> logger)
        {
            db = context;
            this.logger = logger;
        }

        public int ChooseTransliterationSystem(string systemName)
        {
            Alphabet alphabet = db.Alphabets.FirstOrDefault(a => a.SystemName == systemName);
            if (alphabet != null)
            {
                AlphabetLoader.SetCurrentAlphabet(alphabet);
                logger.LogInformation($">> System \'{systemName}\' is selected for translation");
                return 1;
            }
            else
            {
                logger.LogError($">> Transliteration system named \'{systemName}\' does not exist");
                return 0;
            }
        }

        public string TryToTranslateText(string text)
        {
            if (text != null && AlphabetLoader.alphabet.Count != 0)
            {
                logger.LogInformation(">> Text translated successfully");
                return Translator.TranslateText(text, AlphabetLoader.alphabet);
            }
            else
            {
                logger.LogWarning(">> Error: no transliteration system selected or missing text");
                return null;
            }
        }
    }
}
