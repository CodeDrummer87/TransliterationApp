using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransliterationApp.Modules.Interfaces
{
    public interface ITranslitSystemTransfer
    {
        IQueryable QueryForTranslierationSystemsList();
    }
}