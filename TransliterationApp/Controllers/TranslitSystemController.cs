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
        public string DeleteSelectedTranslitSystem([FromBody] string systemName)
        {
            return buffer.DeleteTranslitSystem(systemName);
        }
    }
}