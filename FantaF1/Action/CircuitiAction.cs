using System;
using FantaF1.Action.Interfaces;
using FantaF1DataAccessDB;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace FantaF1.Action
{
    public class CircuitiAction : ICircuitiAction
    {
        private readonly IDatabaseAction _databaseAction;

        private List<Circuiti> _circuiti;

        public CircuitiAction(IDatabaseAction databaseAction)
        {
            _databaseAction = databaseAction;
            _circuiti = databaseAction.GetCircuiti();
        }

        public void CreateCircuito(string name, string nationality, int metres)
        {
            var newCircuito = new Circuiti
            {
                Nome = name,
                Nazione = nationality,
                Lunghezza_m_ = metres
            };

            _circuiti = _databaseAction.SaveCircuito(newCircuito);

        }

        public int GetIdCircuitoFromNationality(string nazioneCircuito)
        {
            var result = _circuiti.FirstOrDefault(x => x.Nazione.ToLower() == nazioneCircuito.ToLower());

            if (result != null)
                return result.Id;

            return -1;
        }

        public IEnumerable<SelectListItem> GetAllCircuitiSelectItem()
        {
            return _circuiti.Select(circuito => new SelectListItem
            { Text = circuito.Nazione + " - " + circuito.Nome, Value = circuito.Id.ToString() }).ToList();
        }

        public List<Circuiti> GetAllCircuiti()
        {
            return new List<Circuiti>(_circuiti);
        }

        public string GetNameCircuitoFromId(int idCircuito)
        {
            var result = _circuiti.FirstOrDefault(x => x.Id == idCircuito);

            return result != null ? result.Nome : string.Empty;
        }
    }
}