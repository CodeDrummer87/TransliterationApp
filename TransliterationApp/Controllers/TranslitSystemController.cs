using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TransliterationApp.Modules.Interfaces;

namespace TransliterationApp.Controllers
{
    public class TranslitSystemController : Controller
    {
        ITranslitSystemTransfer buffer;
        private readonly ILogger<TranslitSystemController> logger;

        public TranslitSystemController(ITranslitSystemTransfer buffer, ILogger<TranslitSystemController> logger)
        {
            this.buffer = buffer;
            this.logger = logger;
        }

        [HttpGet]
        public IQueryable GetTranslitSystemList()
        {
            logger.LogInformation("> Request for a list of available transliteration systems");
            return buffer.QueryForTranslierationSystemsList();
        }

        [HttpPost]
        public int DeleteSelectedTranslitSystem([FromBody] string systemName)
        {
            logger.LogInformation($"> Request to remove the \'{systemName}\' system");
            return buffer.DeleteTranslitSystem(systemName);
        }

        [HttpPost]
        public int SaveNewTransliterationSystem([FromBody] string[] newSystem)
        {
            logger.LogInformation("> Request to save a new transliteration system to the database");
            return buffer.SaveNewSystem(newSystem);
        }
    }
}