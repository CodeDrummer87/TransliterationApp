using Microsoft.Extensions.Logging;
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
        private readonly ILogger<SourceTransfer> logger;

        public SourceTransfer(TransAppContext context)
        {
            db = context;
        }
        public SourceTransfer(TransAppContext context, ILogger<SourceTransfer> logger)
        {
            db = context;
            this.logger = logger;
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
                        logger.LogInformation($">>>> The source text \"{data.TextName}\" is saved in the database");
                        return 1;
                    }
                    else
                    {
                        logger.LogWarning($">>>> Unable to save source text \"{data.TextName}\": text with the same name already exists");
                        return -2;
                    }
                }
                else
                {
                    logger.LogError(">>> Request Error: no data transferred");
                    return 0;
                }
            }
            else
            {
                logger.LogWarning($">> Unable to save source because storage is full ({currentCounter})");
                return -1;
            }
        }

        public IQueryable QueryForSourceList()
        {
            logger.LogInformation(">> Source list uploaded");
            return db.SourceTexts.Select(c => new { c.TextName, c.TextDescription, c.UploadDate });
        }

        public IQueryable GetSourceByName(string textName)
        {
            if (textName != null)
            {
                logger.LogInformation($">> Source \"{textName}\" uploaded");
                return db.SourceTexts.Where(source => source.TextName == textName);
            }
            else
            {
                logger.LogError(">> Request error: source name not received");
                return null;
            }
        }

        public int DeleteSource(string textName)
        {
            if (textName != null)
            {
                var source = db.SourceTexts.Where(s => s.TextName == textName).FirstOrDefault();
                if (source != null)
                {
                    db.SourceTexts.Remove(source);
                    db.SaveChanges();
                    logger.LogInformation($">>> Source \"{textName}\" deleted from the database");
                    return 1;
                }
                else
                {
                    logger.LogError($">>> The source text \"{textName}\" in the database does not exist");
                    return 2;
                }
            }
            else
            {
                logger.LogError(">> Request error: source name not received");
                return 0;
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
