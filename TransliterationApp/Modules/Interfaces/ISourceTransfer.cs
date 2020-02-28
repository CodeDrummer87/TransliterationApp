using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransliterationApp.Models;
using TransliterationApp.Models.DbSets;

namespace TransliterationApp.Modules.Interfaces
{
    public interface ISourceTransfer
    {
        int TryToSaveSourceInDb(SourceText data);
        IQueryable QueryForSourceList();
        IQueryable GetSourceByName(string textName);
        string DeleteSource(string textName);
        int GetLimitForSaveSource();
    }
}
