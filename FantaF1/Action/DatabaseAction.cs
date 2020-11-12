using FantaF1.Action.Interfaces;
using FantaF1DataAccessDB;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FantaF1.Action
{
    public class DatabaseAction : IDatabaseAction
    {
        private FantaF1_SVRKEntities _database;

        public DatabaseAction()
        {
            _database = new FantaF1_SVRKEntities();
        }

        public List<CampionatiMondiali> GetCampionatiMondiali()
        {
            return _database.CampionatiMondiali.ToList();
        }

        public List<Circuiti> GetCircuiti()
        {
            return _database.Circuiti.ToList();
        }

        public List<FantaCampionati> GetFantaCampionati()
        {
            return _database.FantaCampionati.ToList();
        }

        public List<IscrizioniCircuitiCampionato> GetIscrizioniCircuitoCampionato()
        {
            return _database.IscrizioniCircuitiCampionato.ToList();
        }
        public List<IscrizioniPilotiCampionato> GetIscrizioniPilotiCampionatoMondiale()
        {
            return _database.IscrizioniPilotiCampionato.ToList();
        }

        public List<IscrizioniPilotiScuderie> GetIscrizioniPilotiScuderie()
        {
            return _database.IscrizioniPilotiScuderie.ToList();
        }

        public List<IscrizioniScuderieCampionato> GetIscrizioniScuderieCampionato()
        {
            return _database.IscrizioniScuderieCampionato.ToList();
        }

        public List<IscrizioniUtentiFantaCampionato> GetIscrizioniUtentiFantaCampionato()
        {
            return _database.IscrizioniUtentiFantaCampionato.ToList();
        }

        public List<Piloti> GetPiloti()
        {
            return _database.Piloti.ToList();
        }

        public List<PronosticoUtenteFantaCampionato> GetPronosticiUtenteFantaCampionato()
        {
            return _database.PronosticoUtenteFantaCampionato.ToList();
        }

        public List<PronosticoUtenteGara> GetPronosticiUtenteGara()
        {
            return _database.PronosticoUtenteGara.ToList();
        }

        public List<RegoleCampionatoMondiale> GetRegoleCampionato()
        {
            return _database.RegoleCampionatoMondiale.ToList();
        }

        public List<RegoleFantaCampionato> GetRegoleFantaCampionato()
        {
            return _database.RegoleFantaCampionato.ToList();
        }

        public List<RisultatoDFNGaraReale> GetRisultatiDfnGaraReale()
        {
            return _database.RisultatoDFNGaraReale.ToList();
        }

        public List<RisultatoGaraReale> GetRisultatiGaraReale()
        {
            return _database.RisultatoGaraReale.ToList();
        }

        public List<RisultatoPronostico> GetRisultatiPronostico()
        {
            return _database.RisultatoPronostico.ToList();
        }

        public List<Scuderie> GetScuderie()
        {
            return _database.Scuderie.ToList();
        }

        public List<Utenti> GetUtenti()
        {
            return _database.Utenti.ToList();
        }

        public List<CampionatiMondiali> SaveCampionatoMondiale(CampionatiMondiali campionatoMondiale)
        {
            _database.CampionatiMondiali.Add(campionatoMondiale);
            _database.SaveChanges();
            return _database.CampionatiMondiali.ToList();
        }

        public List<Circuiti> SaveCircuito(Circuiti circuito)
        {
            _database.Circuiti.Add(circuito);
            _database.SaveChanges();
            return _database.Circuiti.ToList();
        }

        public List<FantaCampionati> SaveFantaCampionato(FantaCampionati fantaCampionato)
        {
            _database.FantaCampionati.Add(fantaCampionato);
            _database.SaveChanges();
            return _database.FantaCampionati.ToList();
        }

        public List<IscrizioniCircuitiCampionato> SaveIscrizioniCircuitoCampionato(IscrizioniCircuitiCampionato iscrizioneCircuitoCampionato)
        {
            _database.IscrizioniCircuitiCampionato.Add(iscrizioneCircuitoCampionato);
            _database.SaveChanges();
            return _database.IscrizioniCircuitiCampionato.ToList();
        }

        public List<IscrizioniScuderieCampionato> SaveIscrizioniScuderieCampionato(IscrizioniScuderieCampionato iscrizioneScuderiaCampionato)
        {
            _database.IscrizioniScuderieCampionato.Add(iscrizioneScuderiaCampionato);
            _database.SaveChanges();
            return _database.IscrizioniScuderieCampionato.ToList();
        }

        public List<IscrizioniUtentiFantaCampionato> SaveIscrizioniUtentiFantaCampionato(IscrizioniUtentiFantaCampionato iscrizioneUtenteFantaCampionato)
        {
            _database.IscrizioniUtentiFantaCampionato.Add(iscrizioneUtenteFantaCampionato);
            _database.SaveChanges();
            return _database.IscrizioniUtentiFantaCampionato.ToList();
        }

        public List<Piloti> SavePiloti(Piloti pilota)
        {
            _database.Piloti.Add(pilota);
            _database.SaveChanges();
            return _database.Piloti.ToList();
        }

        public List<PronosticoUtenteFantaCampionato> SavePronosticoUtenteFantaCampionato(PronosticoUtenteFantaCampionato pronosticoUtenteFantaCampionato)
        {
            _database.PronosticoUtenteFantaCampionato.Add(pronosticoUtenteFantaCampionato);
            _database.SaveChanges();
            return _database.PronosticoUtenteFantaCampionato.ToList();
        }

        public List<PronosticoUtenteGara> SavePronosticoUtenteGara(PronosticoUtenteGara pronosticoUtenteGara)
        {
            _database.PronosticoUtenteGara.Add(pronosticoUtenteGara);
            _database.SaveChanges();
            return _database.PronosticoUtenteGara.ToList();
        }

        public List<RegoleFantaCampionato> SaveRegoleFantaCampionato(RegoleFantaCampionato regoleFantaCampionato)
        {
            _database.RegoleFantaCampionato.Add(regoleFantaCampionato);
            _database.SaveChanges();
            return _database.RegoleFantaCampionato.ToList();
        }

        public List<RisultatoDFNGaraReale> SaveRisultatoDfnGaraReale(RisultatoDFNGaraReale risultatoDfnGaraReale)
        {
            _database.RisultatoDFNGaraReale.Add(risultatoDfnGaraReale);
            _database.SaveChanges();
            return _database.RisultatoDFNGaraReale.ToList();
        }

        public List<RisultatoGaraReale> SaveRisultatoGaraReale(RisultatoGaraReale risultatoGaraReale)
        {
            _database.RisultatoGaraReale.Add(risultatoGaraReale);
            _database.SaveChanges();
            return _database.RisultatoGaraReale.ToList();
        }

        public List<RisultatoPronostico> SaveRisultatoPronostico(RisultatoPronostico risultatoPronostico)
        {
            _database.RisultatoPronostico.Add(risultatoPronostico);
            _database.SaveChanges();
            return _database.RisultatoPronostico.ToList();
        }

        public List<Scuderie> SaveScuderia(Scuderie scuderia)
        {
            _database.Scuderie.Add(scuderia);
            _database.SaveChanges();
            return _database.Scuderie.ToList();
        }

        public List<Utenti> SaveUtente(Utenti utente)
        {
            _database.Utenti.Add(utente);
            _database.SaveChanges();
            return _database.Utenti.ToList();
        }

        public List<IscrizioniCircuitiCampionato> UpdateIscrizioneCircuitoCampionato(int idIscrizione, int idRisultato)
        {
            if (_database != null)
            {
                _database.IscrizioniCircuitiCampionato
                        .FirstOrDefault(x => x.Id == idIscrizione).RisultatiId =
                    idRisultato;
                _database.SaveChanges();
                return _database.IscrizioniCircuitiCampionato.ToList();
            }

            return null;
        }

        public List<IscrizioniPilotiCampionato> UpdateIscrizionePilotaCampionato(int idCampionato, int idPilota, int punteggio)
        {
            _database.IscrizioniPilotiCampionato.FirstOrDefault(x => x.CampionatoId == idCampionato && x.PilotaId == idPilota).Punteggio += punteggio;
            _database.SaveChanges();
            return _database.IscrizioniPilotiCampionato.ToList();
        }

        public List<IscrizioniScuderieCampionato> UpdateIscrizioneScuderiaCampionato(int idCampionato, int idScuderia, int punteggio)
        {
            _database.IscrizioniScuderieCampionato.FirstOrDefault(x => x.CampionatoId == idCampionato && x.ScuderiaId == idScuderia).Punteggio = punteggio;
            _database.SaveChanges();
            return _database.IscrizioniScuderieCampionato.ToList();
        }

        public List<IscrizioniUtentiFantaCampionato> UpdateIscrizioneUtenteFantaCampionato(int idIscrizione, int punteggio)
        {
            _database.IscrizioniUtentiFantaCampionato.FirstOrDefault(x => x.Id == idIscrizione)
                .PunteggioCampionatoMondiale = punteggio;
            _database.SaveChanges();
            return _database.IscrizioniUtentiFantaCampionato.ToList();
        }

        public List<IscrizioniUtentiFantaCampionato> UpdateIscrizioneWithNewPronostico(int idIscrizione,
            int idNewPronostico)
        {
            _database.IscrizioniUtentiFantaCampionato.FirstOrDefault(x => x.Id == idIscrizione).PronosticoCampionatoId =
                idNewPronostico;
            _database.IscrizioniUtentiFantaCampionato.FirstOrDefault(x => x.Id == idIscrizione).DataPronosticoMondiale =
                DateTime.Now;
            _database.SaveChanges();
            return _database.IscrizioniUtentiFantaCampionato.ToList();
        }
    }
}