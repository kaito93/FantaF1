using System;
using FantaF1.Action.Interfaces;
using FantaF1DataAccessDB;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace FantaF1.Action
{
    public class CampionatiMondialiAction : ICampionatiMondialiAction
    {
        private List<CampionatiMondiali> _campionatiMondiali;
        private readonly IDatabaseAction _databaseAction;

        public CampionatiMondialiAction(IDatabaseAction databaseAction)
        {
            _databaseAction = databaseAction;
            _campionatiMondiali = databaseAction.GetCampionatiMondiali();
        }

        public void CreateCampionato(string year, string category)
        {
            var newCampionato = new CampionatiMondiali()
            {
                Anno = year,
                Categoria = category
            };

            _campionatiMondiali = _databaseAction.SaveCampionatoMondiale(newCampionato);

        }

        public IEnumerable<SelectListItem> GetAllCampionatiMondialiSelectItem()
        {
            return _campionatiMondiali.Select(campionatoMondiale => new SelectListItem
            {
                Text = campionatoMondiale.Categoria + " - " + campionatoMondiale.Anno,
                Value = campionatoMondiale.Id.ToString()
            }).ToList();
        }

        public int GetRegoleCampionatoIdFromCampionatoId(int idCampionato)
        {
            var result = _campionatiMondiali?.FirstOrDefault(x => x.Id == idCampionato);

            if (result != null)
                return result.RegoleId;

            return -1;
        }

        public DateTime GetYearCampionatoMondialeFromCampionatoId(int idCampionato)
        {
            return new DateTime(int.Parse(_campionatiMondiali?.FirstOrDefault(x => x.Id == idCampionato).Anno),1,1);
        }
    }
}