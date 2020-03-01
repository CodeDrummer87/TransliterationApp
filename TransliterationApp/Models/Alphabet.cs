using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TransliterationApp.Models
{
    public class Alphabet
    {
        [Key]
        public int SystemId { get; set; }
        public string SystemName { get; set; }
        public string RUS_UPPERCASE_A { get; set; }
        public string RUS_a { get; set; }
        public string RUS_UPPERCASE_B { get; set; }
        public string RUS_b { get; set; }
        public string RUS_UPPERCASE_V { get; set; }
        public string RUS_v { get; set; }
        public string RUS_UPPERCASE_G { get; set; }
        public string RUS_g { get; set; }
        public string RUS_UPPERCASE_D { get; set; }
        public string RUS_d { get; set; }
        public string RUS_UPPERCASE_E { get; set; }
        public string RUS_e { get; set; }
        public string RUS_UPPERCASE_YO { get; set; }
        public string RUS_yo { get; set; }
        public string RUS_UPPERCASE_ZH { get; set; }
        public string RUS_zh { get; set; }
        public string RUS_UPPERCASE_Z { get; set; }
        public string RUS_z { get; set; }
        public string RUS_UPPERCASE_I { get; set; }
        public string RUS_i { get; set; }
        public string RUS_UPPERCASE_J { get; set; }
        public string RUS_j { get; set; }
        public string RUS_UPPERCASE_K { get; set; }
        public string RUS_k { get; set; }
        public string RUS_UPPERCASE_L { get; set; }
        public string RUS_l { get; set; }
        public string RUS_UPPERCASE_M { get; set; }
        public string RUS_m { get; set; }
        public string RUS_UPPERCASE_N { get; set; }
        public string RUS_n{ get; set; }
        public string RUS_UPPERCASE_O { get; set; }
        public string RUS_o { get; set; }
        public string RUS_UPPERCASE_P { get; set; }
        public string RUS_p { get; set; }
        public string RUS_UPPERCASE_R { get; set; }
        public string RUS_r { get; set; }
        public string RUS_UPPERCASE_S { get; set; }
        public string RUS_s { get; set; }
        public string RUS_UPPERCASE_T { get; set; }
        public string RUS_t { get; set; }
        public string RUS_UPPERCASE_U { get; set; }
        public string RUS_u { get; set; }
        public string RUS_UPPERCASE_F { get; set; }
        public string RUS_f { get; set; }
        public string RUS_UPPERCASE_KH { get; set; }
        public string RUS_kh { get; set; }
        public string RUS_UPPERCASE_C { get; set; }
        public string RUS_c { get; set; }
        public string RUS_UPPERCASE_CH { get; set; }
        public string RUS_ch { get; set; }
        public string RUS_UPPERCASE_SH { get; set; }
        public string RUS_sh { get; set; }
        public string RUS_UPPERCASE_SHCH { get; set; }
        public string RUS_shch{ get; set; }
        public string RUS_SolidSign { get; set; }
        public string RUS_UPPERCASE_Y { get; set; }
        public string RUS_y { get; set; }
        public string RUS_SoftSign { get; set; }
        public string RUS_UPPERCASE_EH { get; set; }
        public string RUS_eh { get; set; }
        public string RUS_UPPERCASE_YU { get; set; }
        public string RUS_yu { get; set; }
        public string RUS_UPPERCASE_YA { get; set; }
        public string RUS_ya { get; set; }
    }
}
