using FantaF1.Action.Interfaces;
using FantaF1DataAccessDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FantaF1.Action
{
    public class IscrizioniPilotiScuderieAction : IIscrizioniPilotiScuderieAction
    {
        private List<IscrizioniPilotiScuderie> _iscrizioniPilotiScuderie;
        private readonly IDatabaseAction _databaseAction;
        public IscrizioniPilotiScuderieAction(IDatabaseAction databaseAction)
        {
            _databaseAction = databaseAction;
            _iscrizioniPilotiScuderie = _databaseAction.GetIscrizioniPilotiScuderie();
        }

        public List<IscrizioniPilotiScuderie> GetAllIscrizioniPilotiScuderie()
        {
            return new List<IscrizioniPilotiScuderie>(_iscrizioniPilotiScuderie);
        }

        public List<int> GetIDPilotiForGara(DateTime giornoGara)
        {
            var pilotiIscrittiForGara = _iscrizioniPilotiScuderie.FindAll(x =>
                DateTime.Compare(giornoGara, x.DataInizioContratto) > 0 &&
                DateTime.Compare(x.DataFineContratto, giornoGara) > 0);
            

            var pilotiIscr= pilotiIscrittiForGara.Select(pilota => pilota.PilotaId).ToList();
            pilotiIscr.Add(23);
            return pilotiIscr;
        }
    }
}