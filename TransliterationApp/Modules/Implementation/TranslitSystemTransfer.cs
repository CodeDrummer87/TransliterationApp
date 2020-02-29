using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransliterationApp.Models.DbSets;
using TransliterationApp.Modules.Interfaces;

namespace TransliterationApp.Modules.Implementation
{
    public class TranslitSystemTransfer : ITranslitSystemTransfer
    {
        TransAppContext db;

        public TranslitSystemTransfer(TransAppContext context)
        {
            db = context;
        }

        public IQueryable QueryForTranslierationSystemsList()
        {
            return db.Alphabets.Where(a => a.SystemId > 0);
        }

        public string DeleteTranslitSystem(string systemName)
        {
            if (systemName != null)
            {
                var system = db.Alphabets.Where(s => s.SystemName == systemName).FirstOrDefault();
                if (system != null)
                {
                    db.Alphabets.Remove(system);
                    db.SaveChanges();
                    return $".:: The transliteration system '{systemName}' deleted successfully";
                }
                else
                {
                    return ".:: The transliteration system has been deleted previously";
                }
            }
            else
            {
                return $".:: The transliteration system doesn't exist";
            }
        }
    }
}
