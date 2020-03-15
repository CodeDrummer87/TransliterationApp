using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TransliterationApp.Models;
using Microsoft.Extensions.Logging;
using TransliterationApp.Modules.Interfaces;

namespace TransliterationApp.Controllers
{
    public class SourceTextController : Controller
    {
        ISourceTransfer buffer;
        private readonly ILogger<SourceTextController> logger;

        public SourceTextController(ISourceTransfer buffer, ILogger<SourceTextController> logger)
        {
            this.buffer = buffer;
            this.logger = logger;
        }

        [HttpPost]
        public int SaveSource([FromBody]SourceText data)
        {
            logger.LogInformation($"> Request to save the source text \"{data.TextName}\" to a database");
            return buffer.TryToSaveSourceInDb(data);
        }

        [HttpGet]
        public IQueryable GetListSourceText()
        {
            logger.LogInformation("> Request to get a list of sources from the Database");
            return buffer.QueryForSourceList();
        }

        [HttpPost]
        public IQueryable GetSelectedSource([FromBody] string textName)
        {
            logger.LogInformation($"> Request to get source text \"{textName}\" from database");
            return buffer.GetSourceByName(textName);
        }

        [HttpPost]
        public int DeleteSelectedSource([FromBody] string textName)
        {
            logger.LogInformation($"> Request to remove source \"{textName}\" from database");
            return buffer.DeleteSource(textName);
        }

        [HttpPost]
        public int GetCurrentLimit()
        {
            return buffer.GetLimitForSaveSource();
        }
    }
}