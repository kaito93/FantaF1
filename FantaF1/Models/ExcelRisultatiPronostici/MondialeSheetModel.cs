using System;
using System.Collections.Generic;
using System.Linq;
using FantaF1DataAccessDB;
using NPOI.SS.UserModel;

namespace FantaF1.Models.ExcelRisultatiPronostici
{
    public class MondialeSheetModel
    {
        public List<MondialeSheetStructure> MondialeSheetStructure { get; set; }

        public MondialeSheetModel()
        {
            MondialeSheetStructure = new List<MondialeSheetStructure>();
        }

        public MondialeSheetModel(IEnumerable<Utenti> utentiIscritti, RegoleFantaCampionato regolamentoFantaCampionato,
            List<IscrizioniUtentiFantaCampionato> iscrizioniUtentiFantaCampionato,
            List<PronosticoUtenteFantaCampionato> pronosticiUtentiFantaCampionato, List<Piloti> pilotiList,
            List<Scuderie> scuderieList, List<IscrizioniPilotiCampionato> classificaPiloti,
            List<IscrizioniScuderieCampionato> classificaScuderie, DateTime dataTermineIscrizioni)
        {
            MondialeSheetStructure = new List<MondialeSheetStructure>();

            foreach (var utente in utentiIscritti)
            {
                //if (utente.Id == 642)
                //{
                MondialeSheetStructure.Add(new MondialeSheetStructure
                {
                    Id = utente.Id.ToString(),
                    Fanta_Utente = utente.Nome + " " + utente.Cognome,
                    Risultato_Pronostico = RetrieveListPronosticoMondiale(utente.Id, pronosticiUtentiFantaCampionato, iscrizioniUtentiFantaCampionato, pilotiList, scuderieList, regolamentoFantaCampionato, classificaPiloti, classificaScuderie),
                    Malus = ControlloCambioPronosticoMondiale(utente.Id, iscrizioniUtentiFantaCampionato, regolamentoFantaCampionato, dataTermineIscrizioni),
                    Punteggio_Mondiale = CalculateTotalResult(utente.Id, iscrizioniUtentiFantaCampionato)
                        .ToString()
                });
                //}
            }
        }

        public static List<NpoiColumnExcel> GetAsset()
        {
            var asset = new List<NpoiColumnExcel>(new List<NpoiColumnExcel>
            {
                new NpoiColumnExcel
                    {Text = "Id", ColumnWidth = 2000, TextAlign = HorizontalAlignment.Center, NumberFormat = ""},
                new NpoiColumnExcel
                    {Text = "Fanta Utente", ColumnWidth = 6000, TextAlign = HorizontalAlignment.Center, NumberFormat = ""},
                new NpoiColumnExcel
                    {Text = "Risultato pronostico", ColumnWidth = 10000, TextAlign = HorizontalAlignment.Left, NumberFormat = ""},
                new NpoiColumnExcel
                    {Text = "Punteggio mondiale", ColumnWidth = 5000, TextAlign = HorizontalAlignment.Center, NumberFormat = ""},
                new NpoiColumnExcel
                    {Text = "Malus", ColumnWidth = 3000, TextAlign = HorizontalAlignment.Center, NumberFormat = ""}
            });

            return asset;
        }

        private static int CalculateTotalResult(int idUtente, IEnumerable<IscrizioniUtentiFantaCampionato> iscrizioniUtenti)
        {
            return iscrizioniUtenti?.FirstOrDefault(x => x.UtenteId == idUtente)?.PunteggioCampionatoMondiale ?? 0;
        }

        private static string RetrieveListPronosticoMondiale(int utenteId,
            IEnumerable<PronosticoUtenteFantaCampionato> pronosticiUtentiCampionato,
            IEnumerable<IscrizioniUtentiFantaCampionato> iscrizioniUtentiFantaCampionato, IReadOnlyCollection<Piloti> pilotiList,
            IReadOnlyCollection<Scuderie> scuderieList, RegoleFantaCampionato regolamentoFantaCampionato,
            IReadOnlyList<IscrizioniPilotiCampionato> iscrizioniPilotiList,
            List<IscrizioniScuderieCampionato> iscrizioniScuderieList)
        {
            var result = iscrizioniUtentiFantaCampionato.FirstOrDefault(x => x.UtenteId == utenteId);

            if (result == null) return string.Empty;

            var pronosticoId = result.PronosticoCampionatoId;
            var pronosticoMondiale =
                pronosticiUtentiCampionato.FirstOrDefault(
                    x => x.Id == pronosticoId);

            var title = "@Piloti:";

            var pilota16 = "  I - " + RecoverSurnamePilot(pilotiList, pronosticoMondiale, "Primo") + " | " + RetrieveScoreForPositionPilota(regolamentoFantaCampionato, "Primo", pronosticoMondiale, iscrizioniPilotiList) + "     VI - " +
                           RecoverSurnamePilot(pilotiList, pronosticoMondiale, "Sesto") + " | " + RetrieveScoreForPositionPilota(regolamentoFantaCampionato, "Sesto", pronosticoMondiale, iscrizioniPilotiList);
            var pilota27 = "  II - " + RecoverSurnamePilot(pilotiList, pronosticoMondiale, "Secondo") + " | " + RetrieveScoreForPositionPilota(regolamentoFantaCampionato, "Secondo", pronosticoMondiale, iscrizioniPilotiList) + "     VII - " +
                           RecoverSurnamePilot(pilotiList, pronosticoMondiale, "Settimo") + " | " + RetrieveScoreForPositionPilota(regolamentoFantaCampionato, "Settimo", pronosticoMondiale, iscrizioniPilotiList);
            var pilota38 = "  III - " + RecoverSurnamePilot(pilotiList, pronosticoMondiale, "Terzo") + " | " + RetrieveScoreForPositionPilota(regolamentoFantaCampionato, "Terzo", pronosticoMondiale, iscrizioniPilotiList) + "    VIII - " +
                           RecoverSurnamePilot(pilotiList, pronosticoMondiale, "Ottavo") + " | " + RetrieveScoreForPositionPilota(regolamentoFantaCampionato, "Ottavo", pronosticoMondiale, iscrizioniPilotiList);
            var pilota49 = "  IV - " + RecoverSurnamePilot(pilotiList, pronosticoMondiale, "Quarto") + " | " + RetrieveScoreForPositionPilota(regolamentoFantaCampionato, "Quarto", pronosticoMondiale, iscrizioniPilotiList) + "     IX - " +
                           RecoverSurnamePilot(pilotiList, pronosticoMondiale, "Nono") + " | " + RetrieveScoreForPositionPilota(regolamentoFantaCampionato, "Nono", pronosticoMondiale, iscrizioniPilotiList);
            var pilota510 = "  V - " + RecoverSurnamePilot(pilotiList, pronosticoMondiale, "Quinto") + " | " + RetrieveScoreForPositionPilota(regolamentoFantaCampionato, "Quinto", pronosticoMondiale, iscrizioniPilotiList) + "     X - " +
                            RecoverSurnamePilot(pilotiList, pronosticoMondiale, "Decimo") + " | " + RetrieveScoreForPositionPilota(regolamentoFantaCampionato, "Decimo", pronosticoMondiale, iscrizioniPilotiList);

            var pilotiPronostico = title + "@@" + pilota16 + "@" + pilota27 + "@" + pilota38 + "@" + pilota49 + "@" +
                                   pilota510;

            title = "Scuderie:";

            var scuderie16 = "  I - " + RecoverNameScuderia(scuderieList, pronosticoMondiale, "Primo") + " | " + RetrieveScoreForPositionScuderia(regolamentoFantaCampionato, "Primo", pronosticoMondiale, iscrizioniScuderieList) + "     VI - " +
                             RecoverNameScuderia(scuderieList, pronosticoMondiale, "Sesto") + " | " + RetrieveScoreForPositionScuderia(regolamentoFantaCampionato, "Sesto", pronosticoMondiale, iscrizioniScuderieList);
            var scuderie27 = "  II - " + RecoverNameScuderia(scuderieList, pronosticoMondiale, "Secondo") + " | " + RetrieveScoreForPositionScuderia(regolamentoFantaCampionato, "Secondo", pronosticoMondiale, iscrizioniScuderieList) + "     VII - " +
                             RecoverNameScuderia(scuderieList, pronosticoMondiale, "Settimo") + " | " + RetrieveScoreForPositionScuderia(regolamentoFantaCampionato, "Settimo", pronosticoMondiale, iscrizioniScuderieList);
            var scuderie38 = "  III - " + RecoverNameScuderia(scuderieList, pronosticoMondiale, "Terzo") + " | " + RetrieveScoreForPositionScuderia(regolamentoFantaCampionato, "Terzo", pronosticoMondiale, iscrizioniScuderieList) + "     VIII - " +
                             RecoverNameScuderia(scuderieList, pronosticoMondiale, "Ottavo") + " | " + RetrieveScoreForPositionScuderia(regolamentoFantaCampionato, "Ottavo", pronosticoMondiale, iscrizioniScuderieList);
            var scuderie49 = "  IV - " + RecoverNameScuderia(scuderieList, pronosticoMondiale, "Quarto") + " | " + RetrieveScoreForPositionScuderia(regolamentoFantaCampionato, "Quarto", pronosticoMondiale, iscrizioniScuderieList) + "     IX - " +
                             RecoverNameScuderia(scuderieList, pronosticoMondiale, "Nono") + " | " + RetrieveScoreForPositionScuderia(regolamentoFantaCampionato, "Nono", pronosticoMondiale, iscrizioniScuderieList);
            var scuderie510 = "  V - " + RecoverNameScuderia(scuderieList, pronosticoMondiale, "Quinto") + " | " + RetrieveScoreForPositionScuderia(regolamentoFantaCampionato, "Quinto", pronosticoMondiale, iscrizioniScuderieList) + "     X - " +
                              RecoverNameScuderia(scuderieList, pronosticoMondiale, "Decimo") + " | " + RetrieveScoreForPositionScuderia(regolamentoFantaCampionato, "Decimo", pronosticoMondiale, iscrizioniScuderieList);

            var scuderiePronostico = title + "@@" + scuderie16 + "@" + scuderie27 + "@" + scuderie38 + "@" + scuderie49 + "@" +
                                     scuderie510;

            var risultato = pilotiPronostico + "@@" + scuderiePronostico + "@";

            risultato = risultato.Replace("@", Environment.NewLine);

            return risultato;

        }

        private static int RetrieveScoreForPositionPilota(RegoleFantaCampionato regolamento, string posizione,
            PronosticoUtenteFantaCampionato pronostico, IReadOnlyList<IscrizioniPilotiCampionato> classificaPiloti)
        {
            var punteggio = 0;

            if (pronostico == null) return punteggio;

            switch (posizione)
            {
                case "Primo":
                    if (pronostico.PrimoClassificatoPilotaId == classificaPiloti[0].IscrizioniPilotiScuderie.PilotaId)
                        punteggio = regolamento.PunteggioPrimoPilotaMondiale;
                    break;
                case "Secondo":
                    if (pronostico.SecondoClassificatoPilotaId == classificaPiloti[1].IscrizioniPilotiScuderie.PilotaId)
                        punteggio = regolamento.PunteggioSecondoPilotaMondiale;
                    break;
                case "Terzo":
                    if (pronostico.TerzoClassificatoPilotaId == classificaPiloti[2].IscrizioniPilotiScuderie.PilotaId)
                        punteggio = regolamento.PunteggioTerzoPilotaMondiale;
                    break;
                case "Quarto":
                    if (pronostico.QuartoClassificatoPilotaId == classificaPiloti[3].IscrizioniPilotiScuderie.PilotaId)
                        punteggio = regolamento.PunteggioQuartoPilotaMondiale;
                    break;
                case "Quinto":
                    if (pronostico.QuintoClassificatoPilotaId == classificaPiloti[4].IscrizioniPilotiScuderie.PilotaId)
                        punteggio = regolamento.PunteggioQuintoPilotaMondiale;
                    break;
                case "Sesto":
                    if (pronostico.SestoClassificatoPilotaId == classificaPiloti[5].IscrizioniPilotiScuderie.PilotaId)
                        punteggio = regolamento.PunteggioSestoPilotaMondiale;
                    break;
                case "Settimo":
                    if (pronostico.SettimoClassificatoPilotaId == classificaPiloti[6].IscrizioniPilotiScuderie.PilotaId)
                        punteggio = regolamento.PunteggioSettimoPilotaMondiale;
                    break;
                case "Ottavo":
                    if (pronostico.OttavoClassificatoPilotaId == classificaPiloti[7].IscrizioniPilotiScuderie.PilotaId)
                        punteggio = regolamento.PunteggioOttavoPilotaMondiale;
                    break;
                case "Nono":
                    if (pronostico.NonoClassificatoPilotaId == classificaPiloti[8].IscrizioniPilotiScuderie.PilotaId)
                        punteggio = regolamento.PunteggioNonoPilotaMondiale;
                    break;
                case "Decimo":
                    if (pronostico.DecimoClassificatoPilotaId == classificaPiloti[9].IscrizioniPilotiScuderie.PilotaId)
                        punteggio = regolamento.PunteggioDecimoPilotaMondiale;
                    break;
            }

            return punteggio;
        }

        private static int RetrieveScoreForPositionScuderia(RegoleFantaCampionato regolamento, string posizione,
            PronosticoUtenteFantaCampionato pronostico, IReadOnlyList<IscrizioniScuderieCampionato> classificaScuderie)
        {
            var punteggio = 0;

            if (pronostico == null) return punteggio;

            switch (posizione)
            {
                case "Primo":
                    if (pronostico.PrimaClassificataScuderiaId == classificaScuderie[0].ScuderiaId)
                        punteggio = regolamento.PunteggioPrimaScuderiaMondiale;
                    break;
                case "Secondo":
                    if (pronostico.SecondaClassificataScuderiaId == classificaScuderie[1].ScuderiaId)
                        punteggio = regolamento.PunteggioSecondaScuderiaMondiale;
                    break;
                case "Terzo":
                    if (pronostico.TerzaClassificataScuderiaId == classificaScuderie[2].ScuderiaId)
                        punteggio = regolamento.PunteggioTerzaScuderiaMondiale;
                    break;
                case "Quarto":
                    if (pronostico.QuartaClassificataScuderiaId == classificaScuderie[3].ScuderiaId)
                        punteggio = regolamento.PunteggioQuartaScuderiaMondiale;
                    break;
                case "Quinto":
                    if (pronostico.QuintaClassificataScuderiaId == classificaScuderie[4].ScuderiaId)
                        punteggio = regolamento.PunteggioQuintaScuderiaMondiale;
                    break;
                case "Sesto":
                    if (pronostico.SestaClassificataScuderiaId == classificaScuderie[5].ScuderiaId)
                        punteggio = regolamento.PunteggioSestaScuderiaMondiale;
                    break;
                case "Settimo":
                    if (pronostico.SettimaClassificataScuderiaId == classificaScuderie[6].ScuderiaId)
                        punteggio = regolamento.PunteggioSettimaScuderiaMondiale;
                    break;
                case "Ottavo":
                    if (pronostico.OttavaClassificataScuderiaId == classificaScuderie[7].ScuderiaId)
                        punteggio = regolamento.PunteggioOttavaScuderiaMondiale;
                    break;
                case "Nono":
                    if (pronostico.NonaClassificataScuderiaId == classificaScuderie[8].ScuderiaId)
                        punteggio = regolamento.PunteggioNonaScuderiaMondiale;
                    break;
                case "Decimo":
                    if (pronostico.DecimaClassificataScuderiaId == classificaScuderie[9].ScuderiaId)
                        punteggio = regolamento.PunteggioDecimaScuderiaMondiale;
                    break;
            }

            return punteggio;
        }

        private static string RecoverSurnamePilot(IEnumerable<Piloti> pilotiList, PronosticoUtenteFantaCampionato pronosticoMondiale,
            string posizione)
        {
            var pilota = new Piloti();

            switch (posizione)
            {
                case "Primo":
                    pilota = pilotiList.FirstOrDefault(x =>
                        pronosticoMondiale != null && x.Id == pronosticoMondiale.PrimoClassificatoPilotaId);
                    break;
                case "Secondo":
                    pilota = pilotiList.FirstOrDefault(x =>
                        pronosticoMondiale != null && x.Id == pronosticoMondiale.SecondoClassificatoPilotaId);
                    break;
                case "Terzo":
                    pilota = pilotiList.FirstOrDefault(x =>
                        pronosticoMondiale != null && x.Id == pronosticoMondiale.TerzoClassificatoPilotaId);
                    break;
                case "Quarto":
                    pilota = pilotiList.FirstOrDefault(x =>
                        pronosticoMondiale != null && x.Id == pronosticoMondiale.QuartoClassificatoPilotaId);
                    break;
                case "Quinto":
                    pilota = pilotiList.FirstOrDefault(x =>
                        pronosticoMondiale != null && x.Id == pronosticoMondiale.QuintoClassificatoPilotaId);
                    break;
                case "Sesto":
                    pilota = pilotiList.FirstOrDefault(x =>
                        pronosticoMondiale != null && x.Id == pronosticoMondiale.SestoClassificatoPilotaId);
                    break;
                case "Settimo":
                    pilota = pilotiList.FirstOrDefault(x =>
                        pronosticoMondiale != null && x.Id == pronosticoMondiale.SettimoClassificatoPilotaId);
                    break;
                case "Ottavo":
                    pilota = pilotiList.FirstOrDefault(x =>
                        pronosticoMondiale != null && x.Id == pronosticoMondiale.OttavoClassificatoPilotaId);
                    break;
                case "Nono":
                    pilota = pilotiList.FirstOrDefault(x =>
                        pronosticoMondiale != null && x.Id == pronosticoMondiale.NonoClassificatoPilotaId);
                    break;
                case "Decimo":
                    pilota = pilotiList.FirstOrDefault(x =>
                        pronosticoMondiale != null && x.Id == pronosticoMondiale.DecimoClassificatoPilotaId);
                    break;

            }

            return pilota != null ? pilota.Cognome : "xxx";
        }

        private static string RecoverNameScuderia(IEnumerable<Scuderie> scuderieList, PronosticoUtenteFantaCampionato pronosticoMondiale,
            string posizione)
        {
            var scuderia = new Scuderie();

            switch (posizione)
            {
                case "Primo":
                    scuderia = scuderieList.FirstOrDefault(x =>
                        pronosticoMondiale != null && x.Id == pronosticoMondiale.PrimaClassificataScuderiaId);
                    break;
                case "Secondo":
                    scuderia = scuderieList.FirstOrDefault(x =>
                        pronosticoMondiale != null && x.Id == pronosticoMondiale.SecondaClassificataScuderiaId);
                    break;
                case "Terzo":
                    scuderia = scuderieList.FirstOrDefault(x =>
                        pronosticoMondiale != null && x.Id == pronosticoMondiale.TerzaClassificataScuderiaId);
                    break;
                case "Quarto":
                    scuderia = scuderieList.FirstOrDefault(x =>
                        pronosticoMondiale != null && x.Id == pronosticoMondiale.QuartaClassificataScuderiaId);
                    break;
                case "Quinto":
                    scuderia = scuderieList.FirstOrDefault(x =>
                        pronosticoMondiale != null && x.Id == pronosticoMondiale.QuintaClassificataScuderiaId);
                    break;
                case "Sesto":
                    scuderia = scuderieList.FirstOrDefault(x =>
                        pronosticoMondiale != null && x.Id == pronosticoMondiale.SestaClassificataScuderiaId);
                    break;
                case "Settimo":
                    scuderia = scuderieList.FirstOrDefault(x =>
                        pronosticoMondiale != null && x.Id == pronosticoMondiale.SettimaClassificataScuderiaId);
                    break;
                case "Ottavo":
                    scuderia = scuderieList.FirstOrDefault(x =>
                        pronosticoMondiale != null && x.Id == pronosticoMondiale.OttavaClassificataScuderiaId);
                    break;
                case "Nono":
                    scuderia = scuderieList.FirstOrDefault(x =>
                        pronosticoMondiale != null && x.Id == pronosticoMondiale.NonaClassificataScuderiaId);
                    break;
                case "Decimo":
                    scuderia = scuderieList.FirstOrDefault(x =>
                        pronosticoMondiale != null && x.Id == pronosticoMondiale.DecimaClassificataScuderiaId);
                    break;

            }

            return scuderia != null ? scuderia.NomeCorto : "xxx";
        }

        private static string ControlloCambioPronosticoMondiale(int utenteId, List<IscrizioniUtentiFantaCampionato> iscrizioniUtenti,
            RegoleFantaCampionato regolamento, DateTime dataTerminePronostici)
        {
            var punteggio = 0;

            var iscrizioneUtente = iscrizioniUtenti.FirstOrDefault(x => x.UtenteId == utenteId);

            if (iscrizioneUtente != null && DateTime.Compare(iscrizioneUtente.DataPronosticoMondiale, dataTerminePronostici) > 0)
                punteggio = regolamento.PunteggioMalusCambioPronosticoMondiale;

            return punteggio.ToString();
        }
    }
}