using FantaF1DataAccessDB;
using System.Collections.Generic;
using System.Web.Mvc;

namespace FantaF1.Action.Interfaces
{
    public interface IPilotiAction
    {
        int GetPilotaIdFromNameAndSurname(string nameSurname);
        List<Piloti> GetPilotiList();
        IEnumerable<SelectListItem> GetAllPilotiSelectItem();
        IEnumerable<SelectListItem> GetPilotiFromIdSelectItem(IEnumerable<int> piloti);
        List<Piloti> GetPilotiFromIdList(IEnumerable<int> pilotisId);
    }
}
