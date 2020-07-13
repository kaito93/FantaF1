using System;
using FantaF1.Action.Interfaces;
using FantaF1DataAccessDB;
using System.Collections.Generic;
using System.Linq;

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

        public void UpdatePunteggioScuderie(int idCampionatoReale, List<IscrizioniPilotiCampionato> iscrizioniPilotiCampionato, List<Piloti> pilotiList, List<Scuderie> scuderieList)
        {
            foreach (var scuderia in scuderieList)
            {
                if (scuderia.Id == 12) continue;

                var pilots = pilotiList.FindAll(x => x.ScuderiaId == scuderia.Id);

                try
                {
                    foreach (var pilot in pilots.Where(pilot => iscrizioniPilotiCampionato.FirstOrDefault(x => x.PilotaId == pilot.Id) == null))
                        pilots.Remove(pilot);
                }
                catch (Exception e)
                {
                    //ignore
                }

                var punteggioScuderia = pilots
                    .Select(pilota => iscrizioniPilotiCampionato.FirstOrDefault(x => x.PilotaId == pilota.Id))
                    .Where(result => result != null).Sum(result => result.Punteggio);

                _iscrizioniScuderieCampionato = _databaseAction.UpdateIscrizioneScuderiaCampionato(idCampionatoReale, scuderia.Id, punteggioScuderia);

            }
        }

        public List<IscrizioniScuderieCampionato> GetClassificaScuderieFromCampionatoId(int idCampionato)
        {
            return _iscrizioniScuderieCampionato.FindAll(x => x.CampionatoId == idCampionato).OrderByDescending(x => x.Punteggio)
                .ToList();
        }
    }
}