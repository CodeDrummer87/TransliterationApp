using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransliterationApp.Models;

namespace TransliterationApp.Modules.Implementation
{
    public static class TranslationSetting
    {
        public static List<Cell> CreateListOfComplexCharacters(List<string> alphabet)
        {
            List<Cell> list = new List<Cell>();
            bool isSaved;

            for (int i = 0; i < alphabet.Count; i++)
            {               
                isSaved = false;
                if (alphabet[i].Length > 1 && alphabet[i][0] != '\\')
                {
                    for (int j = 0; j < list.Count; j++)
                    {
                        if (alphabet[i][0].ToString() == list[j].ch)
                        {
                            isSaved = true;
                            if (alphabet[i].Length > list[j].length)
                                list[j].length = alphabet[i].Length;
                        }
                    }
                    if (!isSaved)
                    {
                        list.Add(new Cell
                        {
                            ch = alphabet[i][0].ToString(),
                            length = alphabet[i].Length
                        });
                    }
                }
            }
            return list;
        }         

        public static string GetTranslatedCharacter(string ch)
        {
            Alphabet alpha = AlphabetLoader.currentTranslitSystem;
            if (ch == alpha.RUS_UPPERCASE_A) return "А";
            if (ch == alpha.RUS_a) return "а";
            if (ch == alpha.RUS_UPPERCASE_B) return "Б";
            if (ch == alpha.RUS_b) return "б";
            if (ch == alpha.RUS_UPPERCASE_V) return "В";
            if (ch == alpha.RUS_v) return "в";
            if (ch == alpha.RUS_UPPERCASE_G) return "Г";
            if (ch == alpha.RUS_g) return "г";
            if (ch == alpha.RUS_UPPERCASE_D) return "Д";
            if (ch == alpha.RUS_d) return "д";
            if (ch == alpha.RUS_UPPERCASE_E) return "Е";
            if (ch == alpha.RUS_e) return "е";
            if (ch == alpha.RUS_UPPERCASE_YO) return "Ё";
            if (ch == alpha.RUS_yo) return "ё";
            if (ch == alpha.RUS_UPPERCASE_ZH) return "Ж";
            if (ch == alpha.RUS_zh) return "ж";
            if (ch == alpha.RUS_UPPERCASE_Z) return "З";
            if (ch == alpha.RUS_z) return "з";
            if (ch == alpha.RUS_UPPERCASE_I) return "И";
            if (ch == alpha.RUS_i) return "и";
            if (ch == alpha.RUS_UPPERCASE_J) return "Й";
            if (ch == alpha.RUS_j) return "й";
            if (ch == alpha.RUS_UPPERCASE_K) return "К";
            if (ch == alpha.RUS_k) return "к";
            if (ch == alpha.RUS_UPPERCASE_L) return "Л";
            if (ch == alpha.RUS_l) return "л";
            if (ch == alpha.RUS_UPPERCASE_M) return "М";
            if (ch == alpha.RUS_m) return "м";
            if (ch == alpha.RUS_UPPERCASE_N) return "Н";
            if (ch == alpha.RUS_n) return "н";
            if (ch == alpha.RUS_UPPERCASE_O) return "О";
            if (ch == alpha.RUS_o) return "о";
            if (ch == alpha.RUS_UPPERCASE_P) return "П";
            if (ch == alpha.RUS_p) return "п";
            if (ch == alpha.RUS_UPPERCASE_R) return "Р";
            if (ch == alpha.RUS_r) return "р";
            if (ch == alpha.RUS_UPPERCASE_S) return "С";
            if (ch == alpha.RUS_s) return "с";
            if (ch == alpha.RUS_UPPERCASE_T) return "Т";
            if (ch == alpha.RUS_t) return "т";
            if (ch == alpha.RUS_UPPERCASE_U) return "У";
            if (ch == alpha.RUS_u) return "у";
            if (ch == alpha.RUS_UPPERCASE_F) return "Ф";
            if (ch == alpha.RUS_f) return "ф";
            if (ch == alpha.RUS_UPPERCASE_KH) return "Х";
            if (ch == alpha.RUS_kh) return "х";
            if (ch == alpha.RUS_UPPERCASE_C) return "Ц";
            if (ch == alpha.RUS_c) return "ц";
            if (ch == alpha.RUS_UPPERCASE_CH) return "Ч";
            if (ch == alpha.RUS_ch) return "ч";
            if (ch == alpha.RUS_UPPERCASE_SH) return "Ш";
            if (ch == alpha.RUS_sh) return "ш";
            if (ch == alpha.RUS_UPPERCASE_SHCH) return "Щ";
            if (ch == alpha.RUS_shch) return "щ";
            if (ch == alpha.RUS_SolidSign) return "ъ";
            if (ch == alpha.RUS_UPPERCASE_Y) return "Ы";
            if (ch == alpha.RUS_y) return "ы";
            if (ch == alpha.RUS_SoftSign) return "ь";
            if (ch == alpha.RUS_UPPERCASE_EH) return "Э";
            if (ch == alpha.RUS_eh) return "э";
            if (ch == alpha.RUS_UPPERCASE_YU) return "Ю";
            if (ch == alpha.RUS_yu) return "ю";
            if (ch == alpha.RUS_UPPERCASE_YA) return "Я";
            if (ch == alpha.RUS_ya) return "я";
            return ch;
        }
    }
}
