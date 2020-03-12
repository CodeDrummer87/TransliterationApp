using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TransliterationApp.Modules.Interfaces;

namespace TransliterationApp.Controllers
{
    public class TranslatorController : Controller
    {
        ITranslatorService buffer;

        public TranslatorController(ITranslatorService buffer)
        {
            this.buffer = buffer;
        }

        [HttpPost]
        public int ChooseThisSystem([FromBody] string systemName)
        {
            return buffer.ChooseTransliterationSystem(systemName);
        }

        [HttpPost]
        public string TryToTranslate([FromBody] string text)
        {
            return buffer.TryToTranslateText(text);
        }
    }
}