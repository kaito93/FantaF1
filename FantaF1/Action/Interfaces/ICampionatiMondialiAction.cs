using System.Collections.Generic;
using System.Web.Mvc;

namespace FantaF1.Action.Interfaces
{
    public interface ICampionatiMondialiAction
    {
        void CreateCampionato(string year, string category);
        IEnumerable<SelectListItem> GetAllCampionatiMondialiSelectItem();
        int GetRegoleCampionatoIdFromCampionatoId(int idCampioanto);
    }
}
