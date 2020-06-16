using FantaF1.Action.Interfaces;
using FantaF1DataAccessDB;
using System.Collections.Generic;
using System.Linq;

namespace FantaF1.Action
{
    public class RegoleFantaCampionatoAction : IRegoleFantaCampionatoAction
    {
        private List<RegoleFantaCampionato> _regoleFantaCampionati;
        private readonly IDatabaseAction _databaseAction;
        public RegoleFantaCampionatoAction(IDatabaseAction databaseAction)
        {
            _databaseAction = databaseAction;
            _regoleFantaCampionati = databaseAction.GetRegoleFantaCampionato();
        }
        public RegoleFantaCampionato GetRegoleFantaCampionatoFromIdRegole(int idRegole)
        {
            return _regoleFantaCampionati.FirstOrDefault(x => x.Id == idRegole);
        }
    }
}