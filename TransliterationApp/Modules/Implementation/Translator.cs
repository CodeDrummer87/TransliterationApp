using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransliterationApp.Modules.Implementation
{
    public class Cell
    {
        public string ch;
        public int count;
    }

    public static class Translator
    {
        public static string TranslateText(string sourceText, List<string> alphabet)
        {
            string translatedText = String.Empty;
            List<Cell> complexCharactersList = TranslationSetting.CreateListOfComplexCharacters(alphabet);       

            string ch;
            bool isEqual;
            int currentCount;
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
                        try
                        {
                            ch += sourceText[i + t].ToString();
                        }
                        catch(IndexOutOfRangeException) 
                        {
                            //.:: Exception...
                        }
                    }

                    bool isCoincided = false;

                    while (true)
                    {
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
                        try
                        {
                            ch = ch.Substring(0, ch.Length - 1);
                        }
                        catch(ArgumentOutOfRangeException)
                        {
                            // Exception...
                        }
                    }
                    i += ch.Length - 1;
                }
                translatedText += TranslatorChar(ch);
            }
            return translatedText;
        }

        public static string TranslatorChar(string ch)
        {
            return TranslationSetting.GetTranslatedCharacter(TranslationSetting.GetNumberOfCharacter(ch));
        }
    }
}
