using FantaF1.Action.Interfaces;
using FantaF1DataAccessDB;
using System.Collections.Generic;
using System.Linq;
using FantaF1.Models;

namespace FantaF1.Action
{
    public class IscrizioniPilotiCampionatoAction : IIscrizioniPilotiCampionatoAction
    {
        private List<IscrizioniPilotiCampionato> _iscrizioniPilotiCampionato;
        private readonly IDatabaseAction _databaseAction;
        public IscrizioniPilotiCampionatoAction(IDatabaseAction databaseAction)
        {
            _databaseAction = databaseAction;
            _iscrizioniPilotiCampionato = databaseAction.GetIscrizioniPilotiCampionatoMondiale();
        }

        public void UpdatePunteggioPiloti(RegoleCampionatoMondiale regoleCampionato, IEnumerable<RaceResultObj> resultRace, int idCampionatoReale)
        {
            foreach (var risultato in resultRace)
            {
                if (risultato.PilotaId == 22) continue;

                var punteggio = CalcolaPunteggio(risultato.PosizioneFinale, regoleCampionato, risultato.GiroVeloce, risultato.PolePosition);

                _iscrizioniPilotiCampionato = _databaseAction.UpdateIscrizionePilotaCampionato(idCampionatoReale, risultato.PilotaId, punteggio);
            }
        }

        public List<IscrizioniPilotiCampionato> GetAllIscrizioniPilotiCampionatoForCampionatoMondialeId(int campionatoId)
        {
            return _iscrizioniPilotiCampionato.FindAll(x => x.CampionatoId == campionatoId);
        }

        public List<IscrizioniPilotiCampionato> GetClassificaPilotiFromIdCampionato(int idCampionato)
        {
            return _iscrizioniPilotiCampionato.FindAll(x => x.CampionatoId == idCampionato).OrderBy(x => x.Punteggio).ToList();
        }

        private static int CalcolaPunteggio(int posizioneFinale, RegoleCampionatoMondiale regoleCampionato, bool giroVeloce, bool polePosition)
        {
            var punteggio = 0;

            switch (posizioneFinale)
            {
                case 1:
                    punteggio = regoleCampionato.PunteggioPrimoClassificato;
                    break;
                case 2:
                    punteggio = regoleCampionato.PunteggioSecondoClassificato;
                    break;
                case 3:
                    punteggio = regoleCampionato.PunteggioTerzoClassificato;
                    break;
                case 4:
                    punteggio = regoleCampionato.PunteggioQuartoClassificato;
                    break;
                case 5:
                    punteggio = regoleCampionato.PunteggioQuintoClassificato;
                    break;
                case 6:
                    punteggio = regoleCampionato.PunteggioSestoClassificato;
                    break;
                case 7:
                    punteggio = regoleCampionato.PunteggioSettimoClassificato;
                    break;
                case 8:
                    punteggio = regoleCampionato.PunteggioOttavoClassificato;
                    break;
                case 9:
                    punteggio = regoleCampionato.PunteggioNonoClassificato;
                    break;
                case 10:
                    punteggio = regoleCampionato.PunteggioDecimoClassificato;
                    break;
                case 11:
                    punteggio = regoleCampionato.PunteggioUndicesimoClassificato;
                    break;
                case 12:
                    punteggio = regoleCampionato.PunteggioDodicesimoClassificato;
                    break;
                case 13:
                    punteggio = regoleCampionato.PunteggioTredicesimoClassificato;
                    break;
                case 14:
                    punteggio = regoleCampionato.PunteggioQuattordicesimoClassificato;
                    break;
                case 15:
                    punteggio = regoleCampionato.PunteggioQuindicesimoClassificato;
                    break;
                case 16:
                    punteggio = regoleCampionato.PunteggioSedicesimoClassificato;
                    break;
                case 17:
                    punteggio = regoleCampionato.PunteggioDiciassettesimoClassificato;
                    break;
                case 18:
                    punteggio = regoleCampionato.PunteggioDiciottesimoClassificato;
                    break;
                case 19:
                    punteggio = regoleCampionato.PunteggioDiciannovesimoClassificato;
                    break;
                case 20:
                    punteggio = regoleCampionato.PunteggioVentesimoClassificato;
                    break;
            }

            if (giroVeloce)
                punteggio += regoleCampionato.PunteggioGiroVeloce;

            if (polePosition)
                punteggio += regoleCampionato.PunteggioPolePosition;

            return punteggio;
        }

    }
}