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
        private static int sourceLimit = 20;

        public SourceTextController(TransAppContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public int SaveSource([FromBody]SourceText data)
        {
            int currentCounter = GetSourceCounter();
            if (currentCounter < sourceLimit)
            {
                if (data != null)
                {
                    if (CheckTextNameForExist(data.TextName))
                    {
                        db.SourceTexts.Add(new SourceText
                        {
                            TextName = data.TextName,
                            TextDescription = data.TextDescription,
                            TextContent = data.TextContent,
                            UploadDate = DateTime.Now
                        });
                        db.SaveChanges();

                        return 1;
                    }
                    else
                        return -2;
                }
                else
                    return 0;
            }
            else
                return -1;
        }

        [HttpGet]
        public IQueryable GetListSourceText()
        {
            return db.SourceTexts.Select(c => new { c.TextName, c.TextDescription, c.UploadDate });
        }

        [HttpPost]
        public IQueryable GetSelectedSource([FromBody] string textName)
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

        [HttpPost]
        public string DeleteSelectedSource([FromBody] string textName)
        {
            if (textName != null)
            {
                var source = db.SourceTexts.Where(s => s.TextName == textName).FirstOrDefault();
                if (source != null)
                {
                    db.SourceTexts.Remove(source);
                    db.SaveChanges();
                    return $".:: Source '{textName}' deleted successfully";
                }
                return ".:: Source has been deleted previously";
            }
            else
            {
                return $".:: The source doesn't exist";
            }
        }

        [HttpPost]
        public int GetCounter()
        {
            int currentSourcesLimit = sourceLimit - db.SourceTexts.Where(text => text.TextId > 0).Count();
            return currentSourcesLimit;
        }

        private int GetSourceCounter()
        {
            return db.SourceTexts.Where(text => text.TextId > 0).Count();
        }

        private bool CheckTextNameForExist(string textName)
        {
            var temp = db.SourceTexts.Where(s => s.TextName == textName).FirstOrDefault();
            if(temp == null)
            {
                return true;
            }
            return false;
        }
    }
}