using FantaF1.Models;
using FantaF1DataAccessDB;
using System;
using System.Collections.Generic;

namespace FantaF1.Action.Interfaces
{
    public interface IIscrizioniUtentiFantaCampionatoAction
    {
        void SaveIscrizioneUtenteFantaCampionatoInDatabase(int idFantaCampionato, int idPronosticoutenteFantaCampionato, int idUtente);
        IEnumerable<RegistrazioneUtenteStructure> LoadUtentiFromFileCsv(FileInformation fileCsv);

        void UpdatePunteggioPronosticoMondiale(List<IscrizioniPilotiCampionato> classificaPiloti,
            List<IscrizioniScuderieCampionato> classificaScuderie,
            List<PronosticoUtenteFantaCampionato> pronosticiUtentiFantaCampionato, int fantaCampionatoId,
            RegoleFantaCampionato regoleFantaCampionato, DateTime dataTerminePronostici);

        List<IscrizioniUtentiFantaCampionato> GetIscrizioniUtentiFantaCampionatoFromIdFantaCampionato(
            int idFantaCampionato);

        void UpdateIscrizioneUtenteFantaCampionato(int idUtente, int idFantaCampionato, int idNuovoPronostico);
    }
}
