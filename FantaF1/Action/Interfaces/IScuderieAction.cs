using FantaF1DataAccessDB;
using System.Collections.Generic;

namespace FantaF1.Action.Interfaces
{
    public interface IScuderieAction
    {
        int GetScuderiaIdFromName(string name);
        List<Scuderie> GetListScuderie();
    }
}
