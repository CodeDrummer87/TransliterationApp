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
                if (alphabet[i].Length > 1)
                {
                    for (int j = 0; j < list.Count; j++)
                    {
                        if (alphabet[i][0].ToString() == list[j].ch)
                        {
                            isSaved = true;
                            if (alphabet[i].Length > list[j].count)
                                list[j].count = alphabet[i].Length;
                        }
                    }
                    if (!isSaved)
                    {
                        list.Add(new Cell
                        {
                            ch = alphabet[i][0].ToString(),
                            count = alphabet[i].Length
                        });
                    }
                }
            }
            return list;
        }

        public static string GetTranslatedCharacter(string characterPosition)
        {
            return characterPosition switch
            {
            "1" => "А",
            "2" => "а",
            "3" => "Б",
            "4" => "б",
            "5" => "В",
            "6" => "в",
            "7" => "Г",
            "8" => "г",
            "9" => "Д",
            "10" => "д",
            "11" => "Е",
            "12" => "е",
            "13" => "Ё",
            "14" => "ё",
            "15" => "Ж",
            "16" => "ж",
            "17" => "З",
            "18" => "з",
            "19" => "И",
            "20" => "и",
            "21" => "Й",
            "22" => "й",
            "23" => "К",
            "24" => "к",
            "25" => "Л",
            "26" => "л",
            "27" => "М",
            "28" => "м",
            "29" => "Н",
            "30" => "н",
            "31" => "О",
            "32" => "о",
            "33" => "П",
            "34" => "п",
            "35" => "Р",
            "36" => "р",
            "37" => "С",
            "38" => "с",
            "39" => "Т",
            "40" => "т",
            "41" => "У",
            "42" => "у",
            "43" => "Ф",
            "44" => "ф",
            "45" => "Х",
            "46" => "х",
            "47" => "Ц",
            "48" => "ц",
            "49" => "Ч",
            "50" => "ч",
            "51" => "Ш",
            "52" => "ш",
            "53" => "Щ",
            "54" => "щ",
            "55" => "ъ",
            "56" => "Ы",
            "57" => "ы",
            "58" => "ь",
            "59" => "Э",
            "60" => "э",
            "61" => "Ю",
            "62" => "ю",
            "63" => "Я",
            "64" => "я",
            _ => characterPosition
            };
        }

        public static string GetNumberOfCharacter(string ch)
        {
            Alphabet alpha = AlphabetLoader.currentTranslitSystem;
            if (ch == alpha.RUS_UPPERCASE_A) return "1";
            if (ch == alpha.RUS_a) return "2";
            if (ch == alpha.RUS_UPPERCASE_B) return "3";
            if (ch == alpha.RUS_b) return "4";
            if (ch == alpha.RUS_UPPERCASE_V) return "5";
            if (ch == alpha.RUS_v) return "6";
            if (ch == alpha.RUS_UPPERCASE_G) return "7";
            if (ch == alpha.RUS_g) return "8";
            if (ch == alpha.RUS_UPPERCASE_D) return "9";
            if (ch == alpha.RUS_d) return "10";
            if (ch == alpha.RUS_UPPERCASE_E) return "11";
            if (ch == alpha.RUS_e) return "12";
            if (ch == alpha.RUS_UPPERCASE_YO) return "13";
            if (ch == alpha.RUS_yo) return "14";
            if (ch == alpha.RUS_UPPERCASE_ZH) return "15";
            if (ch == alpha.RUS_zh) return "16";
            if (ch == alpha.RUS_UPPERCASE_Z) return "17";
            if (ch == alpha.RUS_z) return "18";
            if (ch == alpha.RUS_UPPERCASE_I) return "19";
            if (ch == alpha.RUS_i) return "20";
            if (ch == alpha.RUS_UPPERCASE_J) return "21";
            if (ch == alpha.RUS_j) return "22";
            if (ch == alpha.RUS_UPPERCASE_K) return "23";
            if (ch == alpha.RUS_k) return "24";
            if (ch == alpha.RUS_UPPERCASE_L) return "25";
            if (ch == alpha.RUS_l) return "26";
            if (ch == alpha.RUS_UPPERCASE_M) return "27";
            if (ch == alpha.RUS_m) return "28";
            if (ch == alpha.RUS_UPPERCASE_N) return "29";
            if (ch == alpha.RUS_n) return "30";
            if (ch == alpha.RUS_UPPERCASE_O) return "31";
            if (ch == alpha.RUS_o) return "32";
            if (ch == alpha.RUS_UPPERCASE_P) return "33";
            if (ch == alpha.RUS_p) return "34";
            if (ch == alpha.RUS_UPPERCASE_R) return "35";
            if (ch == alpha.RUS_r) return "36";
            if (ch == alpha.RUS_UPPERCASE_S) return "37";
            if (ch == alpha.RUS_s) return "38";
            if (ch == alpha.RUS_UPPERCASE_T) return "39";
            if (ch == alpha.RUS_t) return "40";
            if (ch == alpha.RUS_UPPERCASE_U) return "41";
            if (ch == alpha.RUS_u) return "42";
            if (ch == alpha.RUS_UPPERCASE_F) return "43";
            if (ch == alpha.RUS_f) return "44";
            if (ch == alpha.RUS_UPPERCASE_KH) return "45";
            if (ch == alpha.RUS_kh) return "46";
            if (ch == alpha.RUS_UPPERCASE_C) return "47";
            if (ch == alpha.RUS_c) return "48";
            if (ch == alpha.RUS_UPPERCASE_CH) return "49";
            if (ch == alpha.RUS_ch) return "50";
            if (ch == alpha.RUS_UPPERCASE_SH) return "51";
            if (ch == alpha.RUS_sh) return "52";
            if (ch == alpha.RUS_UPPERCASE_SHCH) return "53";
            if (ch == alpha.RUS_shch) return "54";
            if (ch == alpha.RUS_SolidSign) return "55";
            if (ch == alpha.RUS_UPPERCASE_Y) return "56";
            if (ch == alpha.RUS_y) return "57";
            if (ch == alpha.RUS_SoftSign) return "58";
            if (ch == alpha.RUS_UPPERCASE_EH) return "59";
            if (ch == alpha.RUS_eh) return "60";
            if (ch == alpha.RUS_UPPERCASE_YU) return "61";
            if (ch == alpha.RUS_yu) return "62";
            if (ch == alpha.RUS_UPPERCASE_YA) return "63";
            if (ch == alpha.RUS_ya) return "64";
            return ch;
        }
    }
}
