using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TransliterationApp.Models;
using TransliterationApp.Modules.Interfaces;

namespace TransliterationApp.Controllers
{
    public class SourceTextController : Controller
    {
        ISourceTransfer buffer;

        public SourceTextController(ISourceTransfer buffer)
        {
            this.buffer = buffer;
        }

        [HttpPost]
        public int SaveSource([FromBody]SourceText data)
        {
            return buffer.TryToSaveSourceInDb(data);
        }

        [HttpGet]
        public IQueryable GetListSourceText()
        {
            return buffer.QueryForSourceList();
        }

        [HttpPost]
        public IQueryable GetSelectedSource([FromBody] string textName)
        {
            return buffer.GetSourceByName(textName);
        }

        [HttpPost]
        public string DeleteSelectedSource([FromBody] string textName)
        {
            return buffer.DeleteSource(textName);
        }

        [HttpPost]
        public int GetCurrentLimit()
        {
            return buffer.GetLimitForSaveSource();
        }
    }
}