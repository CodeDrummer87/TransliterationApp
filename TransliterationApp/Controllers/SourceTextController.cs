using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
        public void Post([FromBody]SourceText data)
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
        }

        [HttpGet]
        public IQueryable GetListSourceText()
        {
            return db.SourceTexts.Select(c => new { c.TextName, c.TextDescription, c.UploadDate });
        }

        [HttpPost]
        public IQueryable GetSelectedSource([FromBody]string textName)
        {
            if (textName != null)
            {
                return db.SourceTexts.Where(source => source.TextName == textName);
            }
            else
            {
                return null;
            }
        }
    }
}