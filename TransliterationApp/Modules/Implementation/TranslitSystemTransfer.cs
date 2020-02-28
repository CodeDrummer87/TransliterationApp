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
    }
}
