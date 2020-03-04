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
        public string ChooseThisSystem([FromBody] string systemName)
        {
            return buffer.ChooseTransliterationSystem(systemName);
        }
    }
}