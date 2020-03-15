using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TransliterationApp.Models;
using TransliterationApp.Modules.Interfaces;

namespace TransliterationApp.Controllers
{
    public class TranslatedTextController : Controller
    {
        ITranslatedTextTransfer buffer;
        private readonly ILogger<TranslatedTextController> logger;

        public TranslatedTextController(ITranslatedTextTransfer buffer, ILogger<TranslatedTextController> logger)
        {
            this.buffer = buffer;
            this.logger = logger;
        }

        [HttpPost]
        public int SaveAsFileTranslatedText([FromBody]SavingTranslatedText data)
        {
            logger.LogInformation($"> Request to save translated text '{data.FileName}' to file");
            return buffer.SaveAs(data);
        }
    }
}