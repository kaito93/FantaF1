using FantaF1.Action.Interfaces;
using FantaF1DataAccessDB;
using System.Collections.Generic;
using System.Linq;

namespace FantaF1.Action
{
    public class RisultatoPronosticoAction : IRisultatoPronosticoAction
    {
        private List<RisultatoPronostico> _risultatiPronostici;
        private readonly IDatabaseAction _databaseAction;
        public RisultatoPronosticoAction(IDatabaseAction databaseAction)
        {
            _databaseAction = databaseAction;
            _risultatiPronostici = databaseAction.GetRisultatiPronostico();
        }
        public void CreateAndSaveRisultatoPronostico(IEnumerable<PronosticoUtenteGara> pronosticiGara,
            RisultatoGaraReale risultatoGara, RegoleFantaCampionato regolamentoFantaCampionato,
            RisultatoDFNGaraReale risultatoDfnGara)
        {
            foreach (var pronostico in pronosticiGara)
            {

                var risultatoPronostico = new RisultatoPronostico();
                var punteggio = 0;

                if (pronostico.PrimoClassificatoPilotaId == risultatoGara.PilotaId01)
                {
                    risultatoPronostico.RisultatoPrimoClassificato = true;
                    punteggio += regolamentoFantaCampionato.PunteggioPrimoClassificato;
                }


                if (pronostico.SecondoClassificatoPilotaId == risultatoGara.PilotaId02)
                {
                    risultatoPronostico.RisultatoSecondoClassificato = true;
                    punteggio += regolamentoFantaCampionato.PunteggioSecondoClassificato;
                }


                if (pronostico.TerzoClassificatoPilotaId == risultatoGara.PilotaId03)
                {
                    risultatoPronostico.RisultatoTerzoClassificato = true;
                    punteggio += regolamentoFantaCampionato.PunteggioTerzoClassificato;
                }


                if (pronostico.PolePositionPilotaId == risultatoGara.PilotaIdPolePosition)
                {
                    risultatoPronostico.RisultatoPolePosition = true;
                    punteggio += regolamentoFantaCampionato.PunteggioPolePosition;
                }


                if (pronostico.GiroVelocePilotaId == risultatoGara.PilotaIdGiroVeloce)
                {
                    risultatoPronostico.RisultatoGiroVeloce = true;
                    punteggio += regolamentoFantaCampionato.PunteggioGiroVeloce;
                }

                if (IsPilotaDfn(pronostico.DFNPilotaId, risultatoDfnGara))
                {
                    risultatoPronostico.RisultatoDFN = true;
                    punteggio += regolamentoFantaCampionato.PunteggioDFN;
                }

                if (risultatoGara.PilotaId01SprintRace != null && pronostico.PrimoClassificatoSprintRacePilotaId ==
                    risultatoGara.PilotaId01SprintRace)
                {
                    risultatoPronostico.PunteggioPrimoClassificatoSprintRace = true;
                    punteggio += (int)regolamentoFantaCampionato.PunteggioPrimoPilotaSprintRace;
                }


                var risultatoPodio = false;

                if (regolamentoFantaCampionato.ComboPodio && risultatoPronostico.RisultatoPrimoClassificato &&
                    risultatoPronostico.RisultatoSecondoClassificato && risultatoPronostico.RisultatoTerzoClassificato)
                {
                    risultatoPodio = true;
                    punteggio += regolamentoFantaCampionato.PunteggioPodio;
                }

                if (regolamentoFantaCampionato.ComboTotale && risultatoPodio &&
                    risultatoPronostico.RisultatoPolePosition && risultatoPronostico.RisultatoGiroVeloce &&
                    risultatoPronostico.RisultatoDFN)

                    punteggio += regolamentoFantaCampionato.PunteggioTotale;


                risultatoPronostico.PunteggioComplessivoPronostico = punteggio;

                risultatoPronostico.PronosticoId = pronostico.Id;

                _risultatiPronostici = _databaseAction.SaveRisultatoPronostico(risultatoPronostico);

            }
        }

        private static bool IsPilotaDfn(int? pilotaId, RisultatoDFNGaraReale resultDfn)
        {
            if (pilotaId == null || pilotaId == 23) // Caso nessun DFN
            {
                return resultDfn.PilotaId01 == null;
            }

            if (resultDfn.PilotaId01 == pilotaId)
                return true;
            if (resultDfn.PilotaId02 == pilotaId)
                return true;
            if (resultDfn.PilotaId03 == pilotaId)
                return true;
            if (resultDfn.PilotaId04 == pilotaId)
                return true;
            if (resultDfn.PilotaId05 == pilotaId)
                return true;
            if (resultDfn.PilotaId06 == pilotaId)
                return true;
            if (resultDfn.PilotaId07 == pilotaId)
                return true;
            if (resultDfn.PilotaId08 == pilotaId)
                return true;
            if (resultDfn.PilotaId09 == pilotaId)
                return true;
            if (resultDfn.PilotaId10 == pilotaId)
                return true;
            if (resultDfn.PilotaId11 == pilotaId)
                return true;
            if (resultDfn.PilotaId12 == pilotaId)
                return true;
            if (resultDfn.PilotaId13 == pilotaId)
                return true;
            if (resultDfn.PilotaId14 == pilotaId)
                return true;
            if (resultDfn.PilotaId15 == pilotaId)
                return true;
            if (resultDfn.PilotaId16 == pilotaId)
                return true;
            if (resultDfn.PilotaId17 == pilotaId)
                return true;
            if (resultDfn.PilotaId18 == pilotaId)
                return true;
            if (resultDfn.PilotaId19 == pilotaId)
                return true;

            return resultDfn.PilotaId20 == pilotaId;
        }

        public RisultatoPronostico GetRisultatoPronosticoFromIdPronosticoUtente(int idPronosticoUtente)
        {
            return _risultatiPronostici.FirstOrDefault(x => x.PronosticoId == idPronosticoUtente);
        }

    }
}