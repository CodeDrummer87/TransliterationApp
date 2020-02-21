using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TransliterationApp.Models
{
    public class SourceText
    {
        [Key]
        public int TextId { get; set; }
        public string TextName { get; set; }
        public string TextDescription { get; set; }
        public string TextContent { get; set; }
        public DateTime UploadDate { get; set; }
    }
}
