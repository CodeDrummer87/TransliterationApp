using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransliterationApp.Modules.Implementation
{
    class Cell
    {
        public string ch;
        public int count;
    }

    public static class Translator
    {
        public static string TranslateText(string sourceText, List<string> alphabet)
        {
            string translatedText = String.Empty;
            bool isSaved = false;           // .:: Flag for checking stored characters

            List<Cell> complexCharactersList = new List<Cell>();

            for (int i = 0; i < alphabet.Count; i++)
            {
                isSaved = false;
                if (alphabet[i].Length > 1)
                {
                    for (int j = 0; j < complexCharactersList.Count; j++)
                    {
                        if (alphabet[i][0].ToString() == complexCharactersList[j].ch)
                        {
                            isSaved = true;
                            if (alphabet[i].Length > complexCharactersList[j].count)
                                complexCharactersList[j].count = alphabet[i].Length;
                        }
                    }
                    if (!isSaved)
                    {
                        complexCharactersList.Add(new Cell
                        {
                            ch = alphabet[i][0].ToString(),
                            count = alphabet[i].Length
                        });
                    }
                }
            }

            string ch = String.Empty;

            bool isEqual = false;
            int currentCount = 0;
            for (int i = 0; i < sourceText.Length; i++)
            {
                ch = String.Empty;
                isEqual = false;
                currentCount = 0;
                for (int j = 0; j < complexCharactersList.Count; j++)
                {
                    if (sourceText[i].ToString() == complexCharactersList[j].ch)
                    {
                        isEqual = true;
                        currentCount = complexCharactersList[j].count;
                        break;
                    }
                }
                if (!isEqual)
                {
                    ch = sourceText[i].ToString();
                }
                else
                {

                    List<string> equalList = new List<string>();
                    for (int k = 0; k < alphabet.Count; k++)
                    {
                        if (sourceText[i] == alphabet[k][0])
                        {
                            equalList.Add(alphabet[k]);
                        }
                    }

                    for (int t = 0; t < currentCount; t++)
                    {
                        ch += sourceText[i + t].ToString();
                    }

                    bool isCoincided = false;

                    int x = 0;
                    while (true)
                    {
                        ++x;
                        for (int q = 0; q < equalList.Count; q++)
                        {
                            if (ch == equalList[q])
                            {
                                isCoincided = true;
                                break;
                            }
                        }
                        if (isCoincided)
                            break;
                        ch = ch.Substring(0, ch.Length - 1);
                    }
                    i += ch.Length - 1;
                }
                translatedText += TranslatorChar(ch);
            }
                return translatedText;
        }

        public static string TranslatorChar(string ch)
        {
            //.:: Temporary method implementation
            switch (ch)
            {
                case "a": return "а";
                case "b": return "б";
                case "v": return "в";
                case "g": return "г";
                case "d": return "д";
                case "e": return "е";
                case "yo": return "ё";
                case "zh": return "ж";
                case "z": return "з";
                case "i": return "и";
                case "j": return "й";
                case "k": return "к";
                case "l": return "л";
                case "m": return "м";
                case "n": return "н";
                case "o": return "о";
                case "p": return "п";
                case "r": return "р";
                case "s": return "с";
                case "t": return "т";
                case "u": return "у";
                case "f": return "ф";
                case "kh": return "х";
                case "c": return "ц";
                case "ch": return "ч";
                case "sh": return "ш";
                case "shch": return "щ";
                case "'": return "ъ";
                case "y": return "ы";
                case "\"": return "ь";
                case "eh": return "э";
                case "yu": return "ю";
                case "ya": return "я";
                default: return ch;
            }
        }
    }
}
