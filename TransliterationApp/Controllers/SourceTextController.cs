using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TransliterationApp.Models;
using TransliterationApp.Models.DbSets;

namespace TransliterationApp.Controllers
{
    public class SourceTextController : Controller
    {
        public TransAppContext db;

        public SourceTextController(TransAppContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Post([FromBody]SourceText data)
        {
            if (data != null)
            {
                db.SourceTexts.Add(new SourceText
                {
                    TextName = data.TextName,
                    TextDescription = data.TextDescription,
                    TextContent = data.TextContent,
                    UploadDate = DateTime.Now
                });
                db.SaveChanges();
            }
            
            return View();
        }
    }
}