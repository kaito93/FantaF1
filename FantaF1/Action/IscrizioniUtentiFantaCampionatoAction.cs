using FantaF1.Action.Interfaces;
using FantaF1.Models;
using FantaF1DataAccessDB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FantaF1.Action
{
    public class IscrizioniUtentiFantaCampionatoAction : IIscrizioniUtentiFantaCampionatoAction
    {
        private List<IscrizioniUtentiFantaCampionato> _iscrizioniUtentiFantaCampionato;
        private readonly IDatabaseAction _databaseAction;
        public IscrizioniUtentiFantaCampionatoAction(IDatabaseAction databaseAction)
        {
            _databaseAction = databaseAction;
            _iscrizioniUtentiFantaCampionato = databaseAction.GetIscrizioniUtentiFantaCampionato();
        }
        public void SaveIscrizioneUtenteFantaCampionatoInDatabase(int idFantaCampionato, int idPronosticoutenteFantaCampionato, int idUtente)
        {
            var iscrizioneUtenteFantaCampionatoDb = new IscrizioniUtentiFantaCampionato
            {
                CampionatoId = idFantaCampionato,
                PronosticoCampionatoId = idPronosticoutenteFantaCampionato,
                UtenteId = idUtente,
                DataPronosticoMondiale = DateTime.Now
            };

            _iscrizioniUtentiFantaCampionato = _databaseAction.SaveIscrizioniUtentiFantaCampionato(iscrizioneUtenteFantaCampionatoDb);
        }

        public IEnumerable<RegistrazioneUtenteStructure> LoadUtentiFromFileCsv(FileInformation fileCsv)
        {
            var riga = 0;
            var registrazioniList = new List<RegistrazioneUtenteStructure>();

            var path = Path.GetTempPath();
            fileCsv.File.SaveAs(path + "csvIscrizioniFile.csv");

            using (var reader = new StreamReader(path + "csvIscrizioniFile.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var registrazione = line?.Split(',').ToList();

                    if (riga != 0)
                    {
                        if (!string.IsNullOrEmpty(registrazione?[0]))
                        {
                            var registrazioneParsed = new RegistrazioneUtenteStructure
                            {
                                Nome = registrazione[1],
                                Cognome = registrazione[2],
                                PrimoCognomePilota = registrazione[3],
                                SecondoCognomePilota = registrazione[4],
                                TerzoCognomePilota = registrazione[5],
                                QuartoCognomePilota = registrazione[6],
                                QuintoCognomePilota = registrazione[7],
                                SestoCognomePilota = registrazione[8],
                                SettimoCognomePilota = registrazione[9],
                                OttavoCognomePilota = registrazione[10],
                                NonoCognomePilota = registrazione[11],
                                DecimoCognomePilota = registrazione[12],
                                PrimoNomeScuderia = registrazione[13],
                                SecondoNomeScuderia = registrazione[14],
                                TerzoNomeScuderia = registrazione[15],
                                QuartoNomeScuderia = registrazione[16],
                                QuintoNomeScuderia = registrazione[17],
                                SestoNomeScuderia = registrazione[18],
                                SettimoNomeScuderia = registrazione[19],
                                OttavoNomeScuderia = registrazione[20],
                                NonoNomeScuderia = registrazione[21],
                                DecimoNomeScuderia = registrazione[22]
                            };

                            registrazioniList.Add(registrazioneParsed);
                        }
                    }

                    riga++;

                }
                reader.Close();
            }

            return registrazioniList;
        }

        public void UpdatePunteggioPronosticoMondiale(List<IscrizioniPilotiCampionato> classificaPiloti,
            List<IscrizioniScuderieCampionato> classificaScuderie,
            List<PronosticoUtenteFantaCampionato> pronosticiUtentiFantaCampionato, int fantaCampionatoId,
            RegoleFantaCampionato regoleFantaCampionato, DateTime dataTerminePronostici)
        {
            var iscrizioniUtenti = GetIscrizioniUtentiFantaCampionatoFromIdFantaCampionato(fantaCampionatoId);

            foreach (var iscrizioneUtenteFantaCampionato in iscrizioniUtenti)
            {
                var pronosticoMondiale = pronosticiUtentiFantaCampionato.FirstOrDefault(x =>
                    x.Id == iscrizioneUtenteFantaCampionato.PronosticoCampionatoId);

                var punteggio = CalcolaPunteggioFantaMondialePiloti(pronosticoMondiale, regoleFantaCampionato, classificaPiloti);

                punteggio +=
                    CalcolaPunteggioFantaMondialeScuerie(pronosticoMondiale, regoleFantaCampionato, classificaScuderie);

                punteggio += ControlloCambioPronosticoMondiale(iscrizioneUtenteFantaCampionato, regoleFantaCampionato, dataTerminePronostici);

                _iscrizioniUtentiFantaCampionato = _databaseAction.UpdateIscrizioneUtenteFantaCampionato(iscrizioneUtenteFantaCampionato.Id, punteggio);
            }
        }

        public void UpdateIscrizioneUtenteFantaCampionato(int idUtente, int idFantaCampionato, int idNuovoPronostico)
        {
            var result = _iscrizioniUtentiFantaCampionato
                .FirstOrDefault(x => x.CampionatoId == idFantaCampionato && x.UtenteId == idUtente);

            if (result == null) return;

            var idIscrizioneUtente = result.Id;
            _iscrizioniUtentiFantaCampionato = _databaseAction.UpdateIscrizioneWithNewPronostico(idIscrizioneUtente, idNuovoPronostico);
        }


        public List<IscrizioniUtentiFantaCampionato> GetIscrizioniUtentiFantaCampionatoFromIdFantaCampionato(
            int idFantaCampionato)
        {
            return _iscrizioniUtentiFantaCampionato.FindAll(x => x.CampionatoId == idFantaCampionato);
        }

        private static int CalcolaPunteggioFantaMondialePiloti(PronosticoUtenteFantaCampionato pronostico,
            RegoleFantaCampionato regolamento, IReadOnlyList<IscrizioniPilotiCampionato> classificaPiloti)
        {
            var punteggio = 0;

            if (pronostico.PrimoClassificatoPilotaId == classificaPiloti[0].PilotaId)
                punteggio += regolamento.PunteggioPrimoPilotaMondiale;

            if (pronostico.SecondoClassificatoPilotaId == classificaPiloti[1].PilotaId)
                punteggio += regolamento.PunteggioSecondoPilotaMondiale;

            if (pronostico.TerzoClassificatoPilotaId == classificaPiloti[2].PilotaId)
                punteggio += regolamento.PunteggioTerzoPilotaMondiale;

            if (pronostico.QuartoClassificatoPilotaId == classificaPiloti[3].PilotaId)
                punteggio += regolamento.PunteggioQuartoPilotaMondiale;

            if (pronostico.QuintoClassificatoPilotaId == classificaPiloti[4].PilotaId)
                punteggio += regolamento.PunteggioQuintoPilotaMondiale;

            if (pronostico.SestoClassificatoPilotaId == classificaPiloti[5].PilotaId)
                punteggio += regolamento.PunteggioSestoPilotaMondiale;

            if (pronostico.SettimoClassificatoPilotaId == classificaPiloti[6].PilotaId)
                punteggio += regolamento.PunteggioSettimoPilotaMondiale;

            if (pronostico.OttavoClassificatoPilotaId == classificaPiloti[7].PilotaId)
                punteggio += regolamento.PunteggioOttavoPilotaMondiale;

            if (pronostico.NonoClassificatoPilotaId == classificaPiloti[8].PilotaId)
                punteggio += regolamento.PunteggioNonoPilotaMondiale;

            if (pronostico.DecimoClassificatoPilotaId == classificaPiloti[9].PilotaId)
                punteggio += regolamento.PunteggioDecimoPilotaMondiale;

            return punteggio;
        }

        private static int CalcolaPunteggioFantaMondialeScuerie(PronosticoUtenteFantaCampionato pronostico,
            RegoleFantaCampionato regolamento, IReadOnlyList<IscrizioniScuderieCampionato> classificaScuderie)
        {
            var punteggio = 0;

            if (pronostico.PrimaClassificataScuderiaId == classificaScuderie[0].ScuderiaId)
                punteggio += regolamento.PunteggioPrimaScuderiaMondiale;

            if (pronostico.SecondaClassificataScuderiaId == classificaScuderie[1].ScuderiaId)
                punteggio += regolamento.PunteggioSecondaScuderiaMondiale;

            if (pronostico.TerzaClassificataScuderiaId == classificaScuderie[2].ScuderiaId)
                punteggio += regolamento.PunteggioTerzaScuderiaMondiale;

            if (pronostico.QuartaClassificataScuderiaId == classificaScuderie[3].ScuderiaId)
                punteggio += regolamento.PunteggioQuartaScuderiaMondiale;

            if (pronostico.QuintaClassificataScuderiaId == classificaScuderie[4].ScuderiaId)
                punteggio += regolamento.PunteggioQuintaScuderiaMondiale;

            if (pronostico.SestaClassificataScuderiaId == classificaScuderie[5].ScuderiaId)
                punteggio += regolamento.PunteggioSestaScuderiaMondiale;

            if (pronostico.SettimaClassificataScuderiaId == classificaScuderie[6].ScuderiaId)
                punteggio += regolamento.PunteggioSettimaScuderiaMondiale;

            if (pronostico.OttavaClassificataScuderiaId == classificaScuderie[7].ScuderiaId)
                punteggio += regolamento.PunteggioOttavaScuderiaMondiale;

            if (pronostico.NonaClassificataScuderiaId == classificaScuderie[8].ScuderiaId)
                punteggio += regolamento.PunteggioNonaScuderiaMondiale;

            if (pronostico.DecimaClassificataScuderiaId == classificaScuderie[9].ScuderiaId)
                punteggio += regolamento.PunteggioDecimaScuderiaMondiale;

            return punteggio;
        }

        private static int ControlloCambioPronosticoMondiale(IscrizioniUtentiFantaCampionato iscrizioneUtente,
            RegoleFantaCampionato regolamento, DateTime dataTerminePronostici)
        {
            var punteggio = 0;

            if (DateTime.Compare(iscrizioneUtente.DataPronosticoMondiale, dataTerminePronostici) > 0)
                punteggio = regolamento.PunteggioMalusCambioPronosticoMondiale;

            return punteggio;
        }
    }
}