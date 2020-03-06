using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransliterationApp.Models;
using TransliterationApp.Modules.Interfaces;

namespace TransliterationApp.Modules.Implementation
{
    public static class AlphabetLoader
    {
        public static Alphabet currentTranslitSystem = new Alphabet();
        public static List<string> alphabet = new List<string>();

        public static void SetCurrentAlphabet(Alphabet currentSystem)
        {
            currentTranslitSystem = currentSystem;
         
            alphabet.Clear();

            CheckForContent(currentSystem.RUS_UPPERCASE_A);
            CheckForContent(currentSystem.RUS_a);
            CheckForContent(currentSystem.RUS_UPPERCASE_B);
            CheckForContent(currentSystem.RUS_b);
            CheckForContent(currentSystem.RUS_UPPERCASE_V);
            CheckForContent(currentSystem.RUS_v);
            CheckForContent(currentSystem.RUS_UPPERCASE_G);
            CheckForContent(currentSystem.RUS_g);
            CheckForContent(currentSystem.RUS_UPPERCASE_D);
            CheckForContent(currentSystem.RUS_d);
            CheckForContent(currentSystem.RUS_UPPERCASE_E);
            CheckForContent(currentSystem.RUS_e);
            CheckForContent(currentSystem.RUS_UPPERCASE_YO);
            CheckForContent(currentSystem.RUS_yo);
            CheckForContent(currentSystem.RUS_UPPERCASE_ZH);
            CheckForContent(currentSystem.RUS_zh);
            CheckForContent(currentSystem.RUS_UPPERCASE_Z);
            CheckForContent(currentSystem.RUS_z);
            CheckForContent(currentSystem.RUS_UPPERCASE_I);
            CheckForContent(currentSystem.RUS_i);
            CheckForContent(currentSystem.RUS_UPPERCASE_J);
            CheckForContent(currentSystem.RUS_j);
            CheckForContent(currentSystem.RUS_UPPERCASE_K);
            CheckForContent(currentSystem.RUS_k);
            CheckForContent(currentSystem.RUS_UPPERCASE_L);
            CheckForContent(currentSystem.RUS_l);
            CheckForContent(currentSystem.RUS_UPPERCASE_M);
            CheckForContent(currentSystem.RUS_m);
            CheckForContent(currentSystem.RUS_UPPERCASE_N);
            CheckForContent(currentSystem.RUS_n);
            CheckForContent(currentSystem.RUS_UPPERCASE_O);
            CheckForContent(currentSystem.RUS_o);
            CheckForContent(currentSystem.RUS_UPPERCASE_P);
            CheckForContent(currentSystem.RUS_p);
            CheckForContent(currentSystem.RUS_UPPERCASE_R);
            CheckForContent(currentSystem.RUS_r);
            CheckForContent(currentSystem.RUS_UPPERCASE_S);
            CheckForContent(currentSystem.RUS_s);
            CheckForContent(currentSystem.RUS_UPPERCASE_T);
            CheckForContent(currentSystem.RUS_t);
            CheckForContent(currentSystem.RUS_UPPERCASE_U);
            CheckForContent(currentSystem.RUS_u);
            CheckForContent(currentSystem.RUS_UPPERCASE_F);
            CheckForContent(currentSystem.RUS_f);
            CheckForContent(currentSystem.RUS_UPPERCASE_KH);
            CheckForContent(currentSystem.RUS_kh);
            CheckForContent(currentSystem.RUS_UPPERCASE_C);
            CheckForContent(currentSystem.RUS_c);
            CheckForContent(currentSystem.RUS_UPPERCASE_CH);
            CheckForContent(currentSystem.RUS_ch);
            CheckForContent(currentSystem.RUS_UPPERCASE_SH);
            CheckForContent(currentSystem.RUS_sh);
            CheckForContent(currentSystem.RUS_UPPERCASE_SHCH);
            CheckForContent(currentSystem.RUS_shch);
            CheckForContent(currentSystem.RUS_SolidSign);
            CheckForContent(currentSystem.RUS_UPPERCASE_Y);
            CheckForContent(currentSystem.RUS_y);
            CheckForContent(currentSystem.RUS_SoftSign);
            CheckForContent(currentSystem.RUS_UPPERCASE_EH);
            CheckForContent(currentSystem.RUS_eh);
            CheckForContent(currentSystem.RUS_UPPERCASE_YU);
            CheckForContent(currentSystem.RUS_yu);
            CheckForContent(currentSystem.RUS_UPPERCASE_YA);
            CheckForContent(currentSystem.RUS_ya);
        }

        private static void CheckForContent(string ch)
        {
            if(ch != "")
            {
                ch = MapHexToChar(ch);
                alphabet.Add(ch);
            }
        }

        private static string MapHexToChar(string ch)
        {
            return ch switch
            {
                "\\u0022" => "\u0022",
                "\\u0027" => "\u0027",
                "\\u00CB" => "\u00CB",
                "\\u00EB" => "\u00EB",
                "\\u017E" => "\u017E",
                "\\u010C" => "\u010C",
                "\\u010D" => "\u010D",
                "\\u0160" => "\u0160",
                "\\u0161" => "\u0161",
                "\\u015C" => "\u015C",
                "\\u015D" => "\u015D",
                "\\u00C8" => "\u00C8",
                "\\u00E8" => "\u00E8",
                "\\u00DB" => "\u00DB",
                "\\u00FB" => "\u00FB",
                "\\u00C2" => "\u00C2",
                "\\u00E2" => "\u00E2",
                _ => ch
            };
        }

        public static string MapCharToHex(string ch)
        {
            return ch switch
            {
                "\u0022" => "\\u0022",
                "\u0027" => "\\u0027",
                "\u00CB" => "\\u00CB",
                "\u00EB" => "\\u00EB",
                "\u017E" => "\\u017E",
                "\u010C" => "\\u010C",
                "\u010D" => "\\u010D",
                "\u0160" => "\\u0160",
                "\u0161" => "\\u0161",
                "\u015C" => "\\u015C",
                "\u015D" => "\\u015D",
                "\u00C8" => "\\u00C8",
                "\u00E8" => "\\u00E8",
                "\u00DB" => "\\u00DB",
                "\u00FB" => "\\u00FB",
                "\u00C2" => "\\u00C2",
                "\u00E2" => "\\u00E2",
                _ => ch
            };
        }
    }
}
