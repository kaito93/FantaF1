using FantaF1DataAccessDB;
using System.Collections.Generic;
using System.Web.Mvc;

namespace FantaF1.Action.Interfaces
{
    public interface ICircuitiAction
    {
        void CreateCircuito(string name, string nationality, int metres);
        int GetIdCircuitoFromNationality(string nazioneCircuito);
        IEnumerable<SelectListItem> GetAllCircuitiSelectItem();
        List<Circuiti> GetAllCircuiti();
        string GetNameCircuitoFromId(int idCircuito);
    }
}
