using FantaF1DataAccessDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantaF1.Action.Interfaces
{
    public interface IIscrizioniPilotiScuderieAction
    {
        List<IscrizioniPilotiScuderie> GetAllIscrizioniPilotiScuderie();
        List<int> GetIDPilotiForGara(DateTime giornoGara);
    }
}
