using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FantaF1DataAccessDB;
using NPOI.SS.UserModel;

namespace FantaF1.Models.ExcelRisultatiPronostici
{
    public class PronosticiSheetModel
    {
        private List<PronosticiSheetStructure> PronosticoSheetStructure { get; set; }

        public PronosticiSheetModel(List<Piloti> pilotiList,
            List<Utenti> utentiIscritti, List<PronosticoUtenteGara> pronosticiUtenti,
            List<RisultatoPronostico> risultatiPronosticiUtenti,
            List<IscrizioniCircuitiCampionato> iscrizioniCircuitiCampionato, int idCampionatoReale,
            List<Circuiti> circuitiList, RegoleFantaCampionato regolamentoFantaCampionato)
        {
            PronosticoSheetStructure = new List<PronosticiSheetStructure>();

            foreach (var utente in utentiIscritti)
            {
                //if (utente.Id == 642)
                //{
                PronosticoSheetStructure.Add(new PronosticiSheetStructure
                {
                    Id = utente.Id.ToString(),
                    FantaUtente = utente.Nome + " " + utente.Cognome,
                    Risultato = RetrieveListPronosticoGara(pronosticiUtenti, pilotiList,
                        iscrizioniCircuitiCampionato,
                        idCampionatoReale, utente.Id, circuitiList, risultatiPronosticiUtenti,
                        regolamentoFantaCampionato),
                    PunteggioTotale = CalculateTotalResult(risultatiPronosticiUtenti, pronosticiUtenti, utente.Id)
                        .ToString()
                });
                //}
            }
        }

        public static List<NpoiColumnExcel> GetAsset(int numberCircuiti)
        {
            var asset = new List<NpoiColumnExcel>(new List<NpoiColumnExcel>
            {
                new NpoiColumnExcel
                    {Text = "Id", ColumnWidth = 2000, TextAlign = HorizontalAlignment.Center, NumberFormat = ""},
                new NpoiColumnExcel
                    {Text = "Fanta Utente", ColumnWidth = 6000, TextAlign = HorizontalAlignment.Center, NumberFormat = ""},
                new NpoiColumnExcel
                {
                    Text = "Risultato", ColumnWidth = (9000 * numberCircuiti), TextAlign = HorizontalAlignment.Left,
                    NumberFormat = ""
                },
                new NpoiColumnExcel
                {
                    Text = "Punteggio Totale", ColumnWidth = 5000, TextAlign = HorizontalAlignment.Center,
                    NumberFormat = ""
                }
            });

            return asset;
        }

        private static int CalculateTotalResult(IReadOnlyCollection<RisultatoPronostico> risultatiPronosticoUtenti,
            List<PronosticoUtenteGara> pronosticiUtentiGara, int idUtente)
        {
            var pronosticiSingoloUtente = pronosticiUtentiGara.FindAll(x => x.UtenteId == idUtente);

            var risultatiPronosticoUtente = pronosticiSingoloUtente.Select(pronosticoSingoloUtente =>
                risultatiPronosticoUtenti.FirstOrDefault(x => x.PronosticoId == pronosticoSingoloUtente.Id)).ToList();

            return risultatiPronosticoUtente.Sum(risultatoPronostico =>
                risultatoPronostico.PunteggioComplessivoPronostico);
        }

        private static string RetrieveListPronosticoGara(IReadOnlyCollection<PronosticoUtenteGara> pronostici,
            IReadOnlyCollection<Piloti> pilotiList, List<IscrizioniCircuitiCampionato> iscritioniCircuitiCampionato,
            int idCampionatoReale, int utenteId, IReadOnlyCollection<Circuiti> circuitiList,
            IReadOnlyCollection<RisultatoPronostico> risultatiPronosticiUtenti, RegoleFantaCampionato regolamentoFantaCampionato)
        {
            var iscrizioniCircuiti =
                iscritioniCircuitiCampionato.FindAll(x => x.CampionatoId == idCampionatoReale && x.RisultatiId != null);

            var primoPilota = string.Empty;
            var secondoPilota = string.Empty;
            var terzoPilota = string.Empty;
            var polePilota = string.Empty;
            var giroVelocePilota = string.Empty;
            var dfnPilota = string.Empty;
            var circuitoNames = string.Empty;



            foreach (var iscrizioneCircuito in iscrizioniCircuiti)
            {
                var listStringsBuilder = new List<StringBuilder>();

                var circuitoNameWithoutSpaces = circuitiList.FirstOrDefault(x => x.Id == iscrizioneCircuito.CircuitoId)?.Nome;

                var circuitoName = circuitoNameWithoutSpaces + "              ";

                circuitoNames += circuitoName;

                for (var j = 0; j < 6; j++)
                    listStringsBuilder.Add(new StringBuilder(circuitoName.Length));

                if (circuitoNameWithoutSpaces != null)
                {
                    var str = new StringBuilder(3 + circuitoNameWithoutSpaces.Length / 3);
                    listStringsBuilder[0]?.Append(AddEmptySpaces(str));
                    str = new StringBuilder(2 + circuitoNameWithoutSpaces.Length / 3);
                    listStringsBuilder[1]?.Append(AddEmptySpaces(str));
                    str = new StringBuilder(2 + circuitoNameWithoutSpaces.Length / 3);
                    listStringsBuilder[2]?.Append(AddEmptySpaces(str));
                    str = new StringBuilder(circuitoNameWithoutSpaces.Length / 3);
                    listStringsBuilder[3]?.Append(AddEmptySpaces(str));
                    str = new StringBuilder(1 + circuitoNameWithoutSpaces.Length / 3);
                    listStringsBuilder[4]?.Append(AddEmptySpaces(str));
                    str = new StringBuilder(circuitoNameWithoutSpaces.Length / 3);
                    listStringsBuilder[5]?.Append(AddEmptySpaces(str));
                }

                var pronosticoGara = pronostici.FirstOrDefault(x =>
                    x.GaraId == iscrizioneCircuito.Id && x.UtenteId == utenteId);

                var risultatoPronostico =
                    risultatiPronosticiUtenti.FirstOrDefault(x =>
                        pronosticoGara != null && x.PronosticoId == pronosticoGara.Id);


                listStringsBuilder[0].Append("   I - " +
                                             RecoverSurnamePilot(pilotiList, pronosticoGara, "Primo") + " | " +
                                             RetrieveScoreForPosition(risultatoPronostico, regolamentoFantaCampionato,
                                                 "Primo"));
                listStringsBuilder[1].Append("  II - " +
                                             RecoverSurnamePilot(pilotiList, pronosticoGara, "Secondo") + " | " +
                                             RetrieveScoreForPosition(risultatoPronostico, regolamentoFantaCampionato,
                                                 "Secondo"));
                listStringsBuilder[2].Append(" III - " +
                                             RecoverSurnamePilot(pilotiList, pronosticoGara, "Terzo") + " | " +
                                             RetrieveScoreForPosition(risultatoPronostico, regolamentoFantaCampionato,
                                                 "Terzo"));
                listStringsBuilder[3].Append("Pole - " +
                                             RecoverSurnamePilot(pilotiList, pronosticoGara, "Pole") + " | " +
                                             RetrieveScoreForPosition(risultatoPronostico, regolamentoFantaCampionato,
                                                 "Pole"));
                listStringsBuilder[4].Append("  GV - " +
                                             RecoverSurnamePilot(pilotiList, pronosticoGara, "GV") + " | " +
                                             RetrieveScoreForPosition(risultatoPronostico, regolamentoFantaCampionato,
                                                 "GV"));
                listStringsBuilder[5].Append(" DFN - " +
                                             RecoverSurnamePilot(pilotiList, pronosticoGara, "DFN") + " | " +
                                             RetrieveScoreForPosition(risultatoPronostico, regolamentoFantaCampionato,
                                                 "DFN"));

                primoPilota += AddEmptySpaces(listStringsBuilder[0]);
                secondoPilota += AddEmptySpaces(listStringsBuilder[1]);
                terzoPilota += AddEmptySpaces(listStringsBuilder[2]);
                polePilota += AddEmptySpaces(listStringsBuilder[3]);
                giroVelocePilota += AddEmptySpaces(listStringsBuilder[4]);
                dfnPilota += AddEmptySpaces(listStringsBuilder[5]);
            }

            var firstText = circuitoNames + "@@" + primoPilota + "@" + secondoPilota + "@" + terzoPilota + "@" + polePilota +
                            "@" + giroVelocePilota + "@" + dfnPilota;

            firstText = firstText.Replace("@", Environment.NewLine);

            return firstText;
        }

        private static int RetrieveScoreForPosition(RisultatoPronostico risultato, RegoleFantaCampionato regolamento,
            string resultWishes)
        {
            var punteggio = 0;

            if (risultato == null) return punteggio;

            switch (resultWishes)
            {
                case "Primo":
                    if (risultato.RisultatoPrimoClassificato)
                        punteggio += regolamento.PunteggioPrimoClassificato;
                    break;
                case "Secondo":
                    if (risultato.RisultatoSecondoClassificato)
                        punteggio += regolamento.PunteggioSecondoClassificato;
                    break;
                case "Terzo":
                    if (risultato.RisultatoTerzoClassificato)
                        punteggio += regolamento.PunteggioTerzoClassificato;
                    break;
                case "Pole":
                    if (risultato.RisultatoPolePosition)
                        punteggio += regolamento.PunteggioPolePosition;
                    break;
                case "GV":
                    if (risultato.RisultatoGiroVeloce)
                        punteggio += regolamento.PunteggioGiroVeloce;
                    break;
                case "DFN":
                    if (risultato.RisultatoDFN)
                        punteggio += regolamento.PunteggioDFN;
                    break;
            }

            return punteggio;
        }

        private static string AddEmptySpaces(StringBuilder str)
        {
            var lengActStr = str.Length;
            var maxCapacity = str.Capacity;
            var missingChar = maxCapacity - lengActStr;

            for (var i = 0; i < missingChar; i++)
                str.Append(i % 3 == 0 ? "  " : " ");

            return str.ToString();
        }

        private static string RecoverSurnamePilot(IEnumerable<Piloti> pilotiList, PronosticoUtenteGara pronosticoGara,
            string posizione)
        {
            var pilota = new Piloti();

            switch (posizione)
            {
                case "Primo":
                    pilota = pilotiList.FirstOrDefault(x =>
                        pronosticoGara != null && x.Id == pronosticoGara.PrimoClassificatoPilotaId);
                    break;
                case "Secondo":
                    pilota = pilotiList.FirstOrDefault(x =>
                        pronosticoGara != null && x.Id == pronosticoGara.SecondoClassificatoPilotaId);
                    break;
                case "Terzo":
                    pilota = pilotiList.FirstOrDefault(x =>
                        pronosticoGara != null && x.Id == pronosticoGara.TerzoClassificatoPilotaId);
                    break;
                case "Pole":
                    pilota = pilotiList.FirstOrDefault(x =>
                        pronosticoGara != null && x.Id == pronosticoGara.PolePositionPilotaId);
                    break;
                case "GV":
                    pilota = pilotiList.FirstOrDefault(x =>
                        pronosticoGara != null && x.Id == pronosticoGara.GiroVelocePilotaId);
                    break;
                case "DFN":
                    pilota = pilotiList.FirstOrDefault(
                        x => pronosticoGara != null && x.Id == pronosticoGara.DFNPilotaId);
                    break;
            }

            return pilota != null ? pilota.Cognome.Substring(0, 3) : "xxx";
        }
    }
}