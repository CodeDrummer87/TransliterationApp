using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TransliterationApp.Modules.Interfaces;

namespace TransliterationApp.Controllers
{
    public class TranslitSystemController : Controller
    {
        ITranslitSystemTransfer buffer;

        public TranslitSystemController(ITranslitSystemTransfer buffer)
        {
            this.buffer = buffer;
        }

        [HttpGet]
        public IQueryable GetTranslitSystemList()
        {
            return buffer.QueryForTranslierationSystemsList();
        }

        [HttpPost]
        public int DeleteSelectedTranslitSystem([FromBody] string systemName)
        {
            return buffer.DeleteTranslitSystem(systemName);
        }

        [HttpPost]
        public int SaveNewTransliterationSystem([FromBody] string[] newSystem)
        {
            return buffer.SaveNewSystem(newSystem);
        }
    }
}