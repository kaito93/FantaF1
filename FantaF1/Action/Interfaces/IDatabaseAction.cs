using FantaF1DataAccessDB;
using System.Collections.Generic;

namespace FantaF1.Action.Interfaces
{
    public interface IDatabaseAction
    {
        List<CampionatiMondiali> SaveCampionatoMondiale(CampionatiMondiali campionatoMondiale);
        List<Circuiti> SaveCircuito(Circuiti circuito);
        List<FantaCampionati> SaveFantaCampionato(FantaCampionati fantaCampionato);
        List<IscrizioniCircuitiCampionato> SaveIscrizioniCircuitoCampionato(IscrizioniCircuitiCampionato iscrizioneCircuitoCampionato);
        List<IscrizioniScuderieCampionato> SaveIscrizioniScuderieCampionato(IscrizioniScuderieCampionato iscrizioneScuderiaCampionato);
        List<IscrizioniUtentiFantaCampionato> SaveIscrizioniUtentiFantaCampionato(IscrizioniUtentiFantaCampionato iscrizioneUtenteFantaCampionato);
        List<Piloti> SavePiloti(Piloti pilota);
        List<PronosticoUtenteFantaCampionato> SavePronosticoUtenteFantaCampionato(PronosticoUtenteFantaCampionato pronosticoUtenteFantaCampionato);
        List<PronosticoUtenteGara> SavePronosticoUtenteGara(PronosticoUtenteGara pronosticoUtenteGara);
        List<RegoleFantaCampionato> SaveRegoleFantaCampionato(RegoleFantaCampionato regoleFantaCampionato);
        List<RisultatoDFNGaraReale> SaveRisultatoDfnGaraReale(RisultatoDFNGaraReale risultatoDfnGaraReale);
        List<RisultatoGaraReale> SaveRisultatoGaraReale(RisultatoGaraReale risultatoGaraReale);
        List<RisultatoPronostico> SaveRisultatoPronostico(RisultatoPronostico risultatoPronostico);
        List<Scuderie> SaveScuderia(Scuderie scuderia);
        List<Utenti> SaveUtente(Utenti utente);
        List<IscrizioniCircuitiCampionato> UpdateIscrizioneCircuitoCampionato(int idIscrizione, int idRisultato);

        List<CampionatiMondiali> GetCampionatiMondiali();
        List<Circuiti> GetCircuiti();
        List<FantaCampionati> GetFantaCampionati();
        List<IscrizioniCircuitiCampionato> GetIscrizioniCircuitoCampionato();
        List<IscrizioniScuderieCampionato> GetIscrizioniScuderieCampionato();
        List<IscrizioniUtentiFantaCampionato> GetIscrizioniUtentiFantaCampionato();
        List<Piloti> GetPiloti();
        List<PronosticoUtenteFantaCampionato> GetPronosticiUtenteFantaCampionato();
        List<PronosticoUtenteGara> GetPronosticiUtenteGara();
        List<RegoleFantaCampionato> GetRegoleFantaCampionato();
        List<RisultatoDFNGaraReale> GetRisultatiDfnGaraReale();
        List<RisultatoGaraReale> GetRisultatiGaraReale();
        List<RisultatoPronostico> GetRisultatiPronostico();
        List<Scuderie> GetScuderie();
        List<Utenti> GetUtenti();
        List<IscrizioniPilotiCampionato> GetIscrizioniPilotiCampionatoMondiale();
        List<RegoleCampionatoMondiale> GetRegoleCampionato();

        List<IscrizioniPilotiCampionato> UpdateIscrizionePilotaCampionato(int idCampionato, int idPilota, int punteggio);

        List<IscrizioniScuderieCampionato> UpdateIscrizioneScuderiaCampionato(int idCampionato, int idScuderia,
            int punteggio);
        List<IscrizioniUtentiFantaCampionato> UpdateIscrizioneUtenteFantaCampionato(int idIscrizione, int punteggio);

        List<IscrizioniUtentiFantaCampionato> UpdateIscrizioneWithNewPronostico(int idIscrizione,
            int idNewPronostico);
        List<IscrizioniPilotiScuderie> GetIscrizioniPilotiScuderie();
    }
}
