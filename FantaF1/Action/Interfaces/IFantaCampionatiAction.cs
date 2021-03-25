using FantaF1DataAccessDB;
using System.Collections.Generic;
using System.Web.Mvc;

namespace FantaF1.Action.Interfaces
{
    public interface IFantaCampionatiAction
    {
        IEnumerable<FantaCampionati> GetFantaCampionatiListFromCampionatoId(int campionatoId);
        int GetFantaCampionatoIdFromName(string name);
        int GetCampionatoRealeIdFromIdFantaCampionato(int fantaCampionatoId);
        int GetRegolamentoIdFromIdFantaCampionato(int fantaCampionatoId);
        List<FantaCampionati> GetFantaCampionatiList();
        FantaCampionati GetFantacampionatoFromId(int idFantaCampionato);
        List<SelectListItem> GetFantaCampionatiSelectListWithIdCampionatoReale();
        List<SelectListItem> GetActiveFantaCampionatiSelectList();
    }
}
