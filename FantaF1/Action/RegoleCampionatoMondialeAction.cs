using FantaF1.Action.Interfaces;
using FantaF1DataAccessDB;
using System.Collections.Generic;
using System.Linq;

namespace FantaF1.Action
{
    public class RegoleCampionatoMondialeAction : IRegoleCampionatoMondialeAction
    {
        private List<RegoleCampionatoMondiale> _regoleCampionatiMondiali;
        private readonly IDatabaseAction _databaseAction;
        public RegoleCampionatoMondialeAction(IDatabaseAction databaseAction)
        {
            _databaseAction = databaseAction;
            _regoleCampionatiMondiali = databaseAction.GetRegoleCampionato();
        }
        public RegoleCampionatoMondiale GetRegoleCampionatoMondialeFromIdRegole(int idRegole)
        {
            return _regoleCampionatiMondiali.FirstOrDefault(x => x.Id == idRegole);
        }
    }
}