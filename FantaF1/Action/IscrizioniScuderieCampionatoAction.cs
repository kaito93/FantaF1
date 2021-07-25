using System;
using FantaF1.Action.Interfaces;
using FantaF1DataAccessDB;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Ajax.Utilities;

namespace FantaF1.Action
{
    public class IscrizioniScuderieCampionatoAction : IIscrizioniScuderieCampionatoAction
    {
        private List<IscrizioniScuderieCampionato> _iscrizioniScuderieCampionato;
        private readonly IDatabaseAction _databaseAction;
        public IscrizioniScuderieCampionatoAction(IDatabaseAction databaseAction)
        {
            _databaseAction = databaseAction;
            _iscrizioniScuderieCampionato = databaseAction.GetIscrizioniScuderieCampionato();
        }

        public void UpdatePunteggioScuderie(int idCampionatoReale, List<IscrizioniPilotiCampionato> iscrizioniPilotiCampionato, List<Scuderie> scuderieList, List<IscrizioniPilotiScuderie> iscrizioniPilotiScuderieYear, List<IscrizioniPilotiScuderie> iscrizioniPilotiScuderieGara)
        {
            foreach (var scuderia in scuderieList)
            {
                if (IsScuderiaInCampionato(scuderia, idCampionatoReale) && scuderia.Id != 12)
                {
                    var pilots = iscrizioniPilotiScuderieYear.FindAll(x => x.ScuderiaId == scuderia.Id).DistinctBy(x => x.PilotaId).ToList();

                    var pilotsInScuderia = pilots
                        .Select(pilota => iscrizioniPilotiCampionato.FindAll(x =>
                            x.IscrizioniPilotiScuderie.PilotaId == pilota.PilotaId &&
                            x.IscrizioniPilotiScuderie.ScuderiaId == scuderia.Id));

                    var punteggio = pilotsInScuderia.Sum(pilotInScuderia =>
                        pilotInScuderia.Where(result => result != null).Sum(result => result.Punteggio));

                    _iscrizioniScuderieCampionato = _databaseAction.UpdateIscrizioneScuderiaCampionato(idCampionatoReale, scuderia.Id, punteggio);
                }

            }
        }

        public List<IscrizioniScuderieCampionato> GetClassificaScuderieFromCampionatoId(int idCampionato)
        {
            return _iscrizioniScuderieCampionato.FindAll(x => x.CampionatoId == idCampionato).OrderByDescending(x => x.Punteggio)
                .ToList();
        }

        private bool IsScuderiaInCampionato(Scuderie scuderia, int idCampionato)
        {
            var resultIscrizione =
                _iscrizioniScuderieCampionato.FirstOrDefault(x => x.ScuderiaId == scuderia.Id && x.CampionatoId == idCampionato);

            return resultIscrizione != null;
        }
    }
}