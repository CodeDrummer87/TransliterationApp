using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TransliterationApp.Models;
using TransliterationApp.Modules.Interfaces;

namespace TransliterationApp.Controllers
{
    public class TranslatedTextController : Controller
    {
        ITranslatedTextTransfer buffer;

        public TranslatedTextController(ITranslatedTextTransfer buffer)
        {
            this.buffer = buffer;
        }

        [HttpPost]
        public int SaveAsFileTranslatedText([FromBody]SavingTranslatedText data)
        {
            return buffer.SaveAs(data);
        }
    }
}