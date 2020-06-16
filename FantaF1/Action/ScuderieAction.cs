using FantaF1.Action.Interfaces;
using FantaF1DataAccessDB;
using System.Collections.Generic;
using System.Linq;

namespace FantaF1.Action
{
    public class ScuderieAction : IScuderieAction
    {
        private List<Scuderie> _scuderie;
        private readonly IDatabaseAction _databaseAction;
        public ScuderieAction(IDatabaseAction databaseAction)
        {
            _databaseAction = databaseAction;
            _scuderie = databaseAction.GetScuderie();
        }
        public int GetScuderiaIdFromName(string name)
        {
            var result = _scuderie.FirstOrDefault(x => x.Nome.ToLower().Contains(name.ToLower()));

            if (result != null)
                return result.Id;

            return -1;
        }

        public List<Scuderie> GetListScuderie()
        {
            return new List<Scuderie>(_scuderie);
        }
    }
}