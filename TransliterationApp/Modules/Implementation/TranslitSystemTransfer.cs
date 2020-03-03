using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransliterationApp.Models;
using TransliterationApp.Models.DbSets;
using TransliterationApp.Modules.Interfaces;

namespace TransliterationApp.Modules.Implementation
{
    public class TranslitSystemTransfer : ITranslitSystemTransfer
    {
        TransAppContext db;

        public TranslitSystemTransfer(TransAppContext context)
        {
            db = context;
        }

        public IQueryable QueryForTranslierationSystemsList()
        {
            return db.Alphabets.Where(a => a.SystemId > 0);
        }

        public string DeleteTranslitSystem(string systemName)
        {
            if (systemName != null)
            {
                var system = db.Alphabets.Where(s => s.SystemName == systemName).FirstOrDefault();
                if (system != null)
                {
                    if (system.SystemId > 6)
                    {
                        db.Alphabets.Remove(system);
                        db.SaveChanges();
                        return $".:: The transliteration system '{systemName}' deleted successfully";
                    }
                    else
                    {
                        return $".:: This transliteration system is protected against deletion";
                    }
                }
                else
                {
                    return ".:: The transliteration system has been deleted previously";
                }
            }
            else
            {
                return $".:: The transliteration system doesn't exist";
            }
        }

        public string SaveNewSystem(string[] newSystem)
        {
            if (newSystem != null)
            {
                int currentNumberOfSavedSystems = GetNumberOfSavedSystems();
                if (currentNumberOfSavedSystems < 40)
                {
                    Alphabet system = MappingAlphabetFromStringArray(newSystem);

                    db.Alphabets.Add(system);
                    db.SaveChanges();

                    return $".:: User transliteration system '{system.SystemName}' saved";
                }
                else
                {
                    return ".:: The system not saved because storage is full";
                }
                
            }

            return ".:: User transliteration system not defined";
        }

        private Alphabet MappingAlphabetFromStringArray(string[] alphabet)
        {
            Alphabet system = new Alphabet
            {
                SystemName = alphabet[64],
                RUS_UPPERCASE_A = alphabet[0],
                RUS_a = alphabet[1],
                RUS_UPPERCASE_B = alphabet[2],
                RUS_b = alphabet[3],
                RUS_UPPERCASE_V = alphabet[4],
                RUS_v = alphabet[5],
                RUS_UPPERCASE_G = alphabet[6],
                RUS_g = alphabet[7],
                RUS_UPPERCASE_D = alphabet[8],
                RUS_d = alphabet[9],
                RUS_UPPERCASE_E = alphabet[10],
                RUS_e = alphabet[11],
                RUS_UPPERCASE_YO = alphabet[12],
                RUS_yo = alphabet[13],
                RUS_UPPERCASE_ZH = alphabet[14],
                RUS_zh = alphabet[15],
                RUS_UPPERCASE_Z = alphabet[16],
                RUS_z = alphabet[17],
                RUS_UPPERCASE_I = alphabet[18],
                RUS_i = alphabet[19],
                RUS_UPPERCASE_J = alphabet[20],
                RUS_j = alphabet[21],
                RUS_UPPERCASE_K = alphabet[22],
                RUS_k = alphabet[23],
                RUS_UPPERCASE_L = alphabet[24],
                RUS_l = alphabet[25],
                RUS_UPPERCASE_M = alphabet[26],
                RUS_m = alphabet[27],
                RUS_UPPERCASE_N = alphabet[28],
                RUS_n = alphabet[29],
                RUS_UPPERCASE_O = alphabet[30],
                RUS_o = alphabet[31],
                RUS_UPPERCASE_P = alphabet[32],
                RUS_p = alphabet[33],
                RUS_UPPERCASE_R = alphabet[34],
                RUS_r = alphabet[35],
                RUS_UPPERCASE_S = alphabet[36],
                RUS_s = alphabet[37],
                RUS_UPPERCASE_T = alphabet[38],
                RUS_t = alphabet[39],
                RUS_UPPERCASE_U = alphabet[40],
                RUS_u = alphabet[41],
                RUS_UPPERCASE_F = alphabet[42],
                RUS_f = alphabet[43],
                RUS_UPPERCASE_KH = alphabet[44],
                RUS_kh = alphabet[45],
                RUS_UPPERCASE_C = alphabet[46],
                RUS_c = alphabet[47],
                RUS_UPPERCASE_CH = alphabet[48],
                RUS_ch = alphabet[49],
                RUS_UPPERCASE_SH = alphabet[50],
                RUS_sh = alphabet[51],
                RUS_UPPERCASE_SHCH = alphabet[52],
                RUS_shch = alphabet[53],
                RUS_SolidSign = alphabet[56],
                RUS_UPPERCASE_Y = alphabet[54],
                RUS_y = alphabet[55],
                RUS_SoftSign = alphabet[57],
                RUS_UPPERCASE_EH = alphabet[58],
                RUS_eh = alphabet[59],
                RUS_UPPERCASE_YU = alphabet[60],
                RUS_yu = alphabet[61],
                RUS_UPPERCASE_YA = alphabet[62],
                RUS_ya = alphabet[63]
            };

            return system;
        }

        private int GetNumberOfSavedSystems() => db.Alphabets.Where(a => a.SystemId > 0).Count();
    }
}
