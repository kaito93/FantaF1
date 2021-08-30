using FantaF1DataAccessDB;
using System.Collections.Generic;

namespace FantaF1.Action.Interfaces
{
    public interface IIscrizioniCircuitoCampionatoAction
    {
        void AssignCircuitoToCampionato(int campionatoId, int circuitoId);
        void UpdateResultRace(int idIscrizione, int idRisultato, bool garaCompletata);
        int GetIdCircuitoFromIscrizioneCircuitoCampionatoRealeId(int iscrizioneCircuitoCampionatoReale);
        int GetIdCampionatoFromIscrizioneCircuitoCampionatoRealeId(int iscrizioneCircuitoCampionatoReale);
        int? GetIdRisultatoFromIscrizioneCircuitoCampionatoRealeId(int iscrizioneCircuitoCampionatoReale);
        List<int> GetIdRisultatiFromCampionatoRealeIdWhenRisultatoGaraNotEmpty(int campionatoRealeId);
        List<IscrizioniCircuitiCampionato> GetIscrizioniList();
        List<IscrizioniCircuitiCampionato> GetIscrizioniWithResultsForCampionatoReale(int idCampionato);
        List<IscrizioniCircuitiCampionato> GetAllIscrizioniForCampionatoReale(int idCampionato);
        List<IscrizioniCircuitiCampionato> GetIscrizioniForCampionatoRealeWithoutResults(int idCampionato);
        IscrizioniCircuitiCampionato GetIscrizioneForId(int idIscrizione);
    }
}
