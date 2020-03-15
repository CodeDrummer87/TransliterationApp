using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TransliterationApp.Modules.Interfaces;

namespace TransliterationApp.Controllers
{
    public class TranslatorController : Controller
    {
        ITranslatorService buffer;
        private readonly ILogger<TranslatorController> logger;

        public TranslatorController(ITranslatorService buffer, ILogger<TranslatorController> logger)
        {
            this.buffer = buffer;
            this.logger = logger;
        }

        [HttpPost]
        public int ChooseThisSystem([FromBody] string systemName)
        {
            logger.LogInformation($"> Request to select {systemName} system");
            return buffer.ChooseTransliterationSystem(systemName);
        }

        [HttpPost]
        public string TryToTranslate([FromBody] string text)
        {
            logger.LogInformation("> Request for translation text");
            return buffer.TryToTranslateText(text);
        }
    }
}