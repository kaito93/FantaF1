using FantaF1.Action.Interfaces;
using FantaF1.Models;
using FantaF1DataAccessDB;
using System.Collections.Generic;
using System.Linq;

namespace FantaF1.Action
{
    public class RisultatoGaraRealeAction : IRisultatoGaraRealeAction
    {
        private List<RisultatoGaraReale> _risultatiGareReali;
        private readonly IDatabaseAction _databaseAction;
        public RisultatoGaraRealeAction(IDatabaseAction databaseAction)
        {
            _databaseAction = databaseAction;
            _risultatiGareReali = databaseAction.GetRisultatiGaraReale();
        }
        public int ManageSaveResultRace(List<RaceResultObj> listResultRace, int idRisultatoDfnGaraReale)
        {
            var newResultRace = new RisultatoGaraReale
            {
                PilotaId01 = listResultRace.FirstOrDefault(x => x.PosizioneFinale == 1).PilotaId,
                PilotaId02 = listResultRace.FirstOrDefault(x => x.PosizioneFinale == 2).PilotaId,
                PilotaId03 = listResultRace.FirstOrDefault(x => x.PosizioneFinale == 3).PilotaId,
                PilotaId04 = listResultRace.FirstOrDefault(x => x.PosizioneFinale == 4).PilotaId,
                PilotaId05 = listResultRace.FirstOrDefault(x => x.PosizioneFinale == 5).PilotaId,
                PilotaId06 = listResultRace.FirstOrDefault(x => x.PosizioneFinale == 6).PilotaId,
                PilotaId07 = listResultRace.FirstOrDefault(x => x.PosizioneFinale == 7).PilotaId,
                PilotaId08 = listResultRace.FirstOrDefault(x => x.PosizioneFinale == 8).PilotaId,
                PilotaId09 = listResultRace.FirstOrDefault(x => x.PosizioneFinale == 9).PilotaId,
                PilotaId10 = listResultRace.FirstOrDefault(x => x.PosizioneFinale == 10).PilotaId,
                PilotaId11 = listResultRace.FirstOrDefault(x => x.PosizioneFinale == 11).PilotaId,
                PilotaId12 = listResultRace.FirstOrDefault(x => x.PosizioneFinale == 12).PilotaId,
                PilotaId13 = listResultRace.FirstOrDefault(x => x.PosizioneFinale == 13).PilotaId,
                PilotaId14 = listResultRace.FirstOrDefault(x => x.PosizioneFinale == 14).PilotaId,
                PilotaId15 = listResultRace.FirstOrDefault(x => x.PosizioneFinale == 15).PilotaId,
                PilotaId16 = listResultRace.FirstOrDefault(x => x.PosizioneFinale == 16).PilotaId,
                PilotaId17 = listResultRace.FirstOrDefault(x => x.PosizioneFinale == 17).PilotaId,
                PilotaId18 = listResultRace.FirstOrDefault(x => x.PosizioneFinale == 18).PilotaId,
                PilotaId19 = listResultRace.FirstOrDefault(x => x.PosizioneFinale == 19).PilotaId,
                PilotaId20 = listResultRace.FirstOrDefault(x => x.PosizioneFinale == 20).PilotaId,
                PilotaIdPolePosition = listResultRace.FirstOrDefault(x => x.PolePosition).PilotaId,
                PilotaIdGiroVeloce = listResultRace.FirstOrDefault(x => x.GiroVeloce).PilotaId,
                RisultatoDFNId = idRisultatoDfnGaraReale,
                PilotaId01SprintRace = listResultRace.FirstOrDefault(x => x.SprintRacePosition == "1SPR")?.PilotaId,
                PilotaId02SprintRace = listResultRace.FirstOrDefault(x => x.SprintRacePosition == "2SPR")?.PilotaId,
                PilotaId03SprintRace = listResultRace.FirstOrDefault(x => x.SprintRacePosition == "3SPR")?.PilotaId,
                PilotaId04SprintRace = listResultRace.FirstOrDefault(x => x.SprintRacePosition == "4SPR")?.PilotaId,
                PilotaId05SprintRace = listResultRace.FirstOrDefault(x => x.SprintRacePosition == "5SPR")?.PilotaId,
                PilotaId06SprintRace = listResultRace.FirstOrDefault(x => x.SprintRacePosition == "6SPR")?.PilotaId,
                PilotaId07SprintRace = listResultRace.FirstOrDefault(x => x.SprintRacePosition == "7SPR")?.PilotaId,
                PilotaId08SprintRace = listResultRace.FirstOrDefault(x => x.SprintRacePosition == "8SPR")?.PilotaId
            };

            _risultatiGareReali = _databaseAction.SaveRisultatoGaraReale(newResultRace);

            return _risultatiGareReali.Last().Id;
        }

        public RisultatoGaraReale GetRisultatoGaraFromIdRisultato(int idRisultato)
        {
            return _risultatiGareReali.FirstOrDefault(x => x.Id == idRisultato);
        }
    }
}