using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransliterationApp.Models;
using TransliterationApp.Models.DbSets;
using TransliterationApp.Modules.Interfaces;

namespace TransliterationApp.Modules.Implementation
{
    public class SourceTransfer : ISourceTransfer
    {
        TransAppContext db;
        private static int sourceLimit = 20;

        public SourceTransfer(TransAppContext context)
        {
            db = context;
        }

        public int TryToSaveSourceInDb(SourceText data)
        {
            int currentCounter = GetCurrentCounter();
            if (currentCounter < sourceLimit)
            {
                if (data != null)
                {
                    if (CheckForExist(data.TextName))
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

        public IQueryable QueryForSourceList()
        {
            return db.SourceTexts.Select(c => new { c.TextName, c.TextDescription, c.UploadDate });
        }

        public IQueryable GetSourceByName(string textName)
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

        public string DeleteSource(string textName)
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

        public int GetLimitForSaveSource()
        {
            int currentSourcesLimit = sourceLimit - db.SourceTexts.Where(text => text.TextId > 0).Count();
            return currentSourcesLimit;
        }

        private int GetCurrentCounter()
        {
            return db.SourceTexts.Where(text => text.TextId > 0).Count();
        }

        private bool CheckForExist(string textName)
        {
            var temp = db.SourceTexts.Where(s => s.TextName == textName).FirstOrDefault();
            if (temp == null)
            {
                return true;
            }
            return false;
        }
    }
}
