using FantaF1.Action.Interfaces;
using FantaF1DataAccessDB;
using System.Collections.Generic;
using System.Linq;

namespace FantaF1.Action
{
    public class FantaCampionatiAction : IFantaCampionatiAction
    {
        private List<FantaCampionati> _fantaCampionati;
        private readonly IDatabaseAction _databaseAction;

        public FantaCampionatiAction(IDatabaseAction databaseAction)
        {
            _databaseAction = databaseAction;
            _fantaCampionati = databaseAction.GetFantaCampionati();

        }
        public IEnumerable<FantaCampionati> GetFantaCampionatiListFromCampionatoId(int campionatoId)
        {
            return _fantaCampionati.FindAll(x => x.CampionatoRealeId == campionatoId);
        }

        public int GetFantaCampionatoIdFromName(string name)
        {
            var result = _fantaCampionati.FirstOrDefault(x => x.Nome.ToLower() == name.ToLower());

            if (result != null)
                return result.Id;

            return -1;
        }

        public int GetCampionatoRealeIdFromIdFantaCampionato(int fantaCampionatoId)
        {
            var result = _fantaCampionati.FirstOrDefault(x => x.Id == fantaCampionatoId);

            if (result != null)
                return result.CampionatoRealeId;

            return -1;
        }

        public int GetRegolamentoIdFromIdFantaCampionato(int fantaCampionatoId)
        {
            var result = _fantaCampionati.FirstOrDefault(x => x.Id == fantaCampionatoId);

            if (result != null)
                return result.RegoleId;

            return -1;
        }

        public List<FantaCampionati> GetFantaCampionatiList()
        {
            return new List<FantaCampionati>(_fantaCampionati);
        }

        public FantaCampionati GetFantacampionatoFromId(int idFantaCampionato)
        {
            return _fantaCampionati.FirstOrDefault(x => x.Id == idFantaCampionato);
        }
    }
}
