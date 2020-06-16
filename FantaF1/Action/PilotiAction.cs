using FantaF1.Action.Interfaces;
using FantaF1DataAccessDB;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace FantaF1.Action
{
    public class PilotiAction : IPilotiAction
    {
        private List<Piloti> _piloti;
        private readonly IDatabaseAction _databaseAction;
        public PilotiAction(IDatabaseAction databaseAction)
        {
            _databaseAction = databaseAction;
            _piloti = databaseAction.GetPiloti();
        }
        public int GetPilotaIdFromNameAndSurname(string nameSurname)
        {
            var result = _piloti.FirstOrDefault(x => nameSurname.ToLower().Contains(x.Cognome.ToLower()));

            if (result != null)
                return result.Id;

            return -1;
        }

        public List<Piloti> GetPilotiList()
        {
            return new List<Piloti>(_piloti);
        }

        public IEnumerable<SelectListItem> GetAllPilotiSelectItem()
        {
            return _piloti.Select(pilota => new SelectListItem
            { Text = pilota.Nome + " " + pilota.Cognome, Value = pilota.Id.ToString() }).ToList();
        }
    }
}