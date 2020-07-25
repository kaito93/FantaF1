using FantaF1.Action.Interfaces;
using FantaF1DataAccessDB;
using System.Collections.Generic;
using System.Linq;

namespace FantaF1.Action
{
    public class IscrizioniCircuitoCampionatoAction : IIscrizioniCircuitoCampionatoAction
    {
        private List<IscrizioniCircuitiCampionato> _iscrizioniCircuitiCampionato;
        private readonly IDatabaseAction _databaseAction;
        public IscrizioniCircuitoCampionatoAction(IDatabaseAction databaseAction)
        {
            _databaseAction = databaseAction;
            _iscrizioniCircuitiCampionato = databaseAction.GetIscrizioniCircuitoCampionato();
        }
        public void AssignCircuitoToCampionato(int campionatoId, int circuitoId)
        {
            var newIscrizione = new IscrizioniCircuitiCampionato
            {
                CircuitoId = circuitoId,
                CampionatoId = campionatoId
            };

            _iscrizioniCircuitiCampionato = _databaseAction.SaveIscrizioniCircuitoCampionato(newIscrizione);
        }

        public void UpdateResultRace(int idIscrizione, int idRisultato)
        {
            _iscrizioniCircuitiCampionato = _databaseAction.UpdateIscrizioneCircuitoCampionato(idIscrizione, idRisultato);
        }

        public int GetIdCircuitoFromIscrizioneCircuitoCampionatoRealeId(int iscrizioneCircuitoCampionatoReale)
        {
            var result = _iscrizioniCircuitiCampionato.FirstOrDefault(x => x.Id == iscrizioneCircuitoCampionatoReale);

            if (result != null)
                return result.CircuitoId;

            return -1;
        }

        public int GetIdCampionatoFromIscrizioneCircuitoCampionatoRealeId(int iscrizioneCircuitoCampionatoReale)
        {
            var result = _iscrizioniCircuitiCampionato.FirstOrDefault(x => x.Id == iscrizioneCircuitoCampionatoReale);

            if (result != null)
                return result.CampionatoId;

            return -1;
        }

        public int? GetIdRisultatoFromIscrizioneCircuitoCampionatoRealeId(int iscrizioneCircuitoCampionatoReale)
        {
            var result = _iscrizioniCircuitiCampionato.FirstOrDefault(x => x.Id == iscrizioneCircuitoCampionatoReale);

            if (result != null)
                return result.RisultatiId;

            return -1;
        }

        public List<int> GetIdRisultatiFromCampionatoRealeIdWhenRisultatoGaraNotEmpty(int campionatoRealeId)
        {
            var iscrizioni = _iscrizioniCircuitiCampionato.FindAll(x => x.CampionatoId == campionatoRealeId && x.RisultatiId != null);

            var response = iscrizioni.Select(iscrizione => iscrizione.RisultatiId ?? default).ToList();

            return response;
        }

        public List<IscrizioniCircuitiCampionato> GetIscrizioniList()
        {
            return new List<IscrizioniCircuitiCampionato>(_iscrizioniCircuitiCampionato);
        }

        public List<IscrizioniCircuitiCampionato> GetIscrizioniWithResultsForCampionatoReale(int idCampionato)
        {
            var iscrizioniWithResults = _iscrizioniCircuitiCampionato.FindAll(x => x.CampionatoId == idCampionato && x.RisultatiId != null);
            return iscrizioniWithResults;
        }

        public List<IscrizioniCircuitiCampionato> GetAllIscrizioniForCampionatoReale(int idCampionato)
        {
            var iscrizioniWithResults = _iscrizioniCircuitiCampionato.FindAll(x => x.CampionatoId == idCampionato);
            return iscrizioniWithResults;
        }

        public List<IscrizioniCircuitiCampionato> GetIscrizioniForCampionatoRealeWithoutResults(int idCampionato)
        {
            var iscrizioni = GetAllIscrizioniForCampionatoReale(idCampionato);

            return iscrizioni.Where(iscrizione => iscrizione.RisultatiId == null).ToList();

        }
    }
}