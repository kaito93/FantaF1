using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FantaF1DataAccessDB;
using NPOI.SS.UserModel;

namespace FantaF1.Models.ExcelRisultatiPronostici
{
    public class StoricoSheetModel
    {
        public List<StoricoSheetStructure> StoricoSheetStructure { get; set; }

        public StoricoSheetModel()
        {
            StoricoSheetStructure = new List<StoricoSheetStructure>();
        }

        public StoricoSheetModel(IEnumerable<Utenti> utentiIscritti,
            IReadOnlyCollection<PronosticoUtenteGara> pronostici,
            List<IscrizioniCircuitiCampionato> iscritioniCircuitiCampionato, int idCampionatoReale,
            IReadOnlyCollection<Circuiti> circuitiList,
            IReadOnlyCollection<RisultatoPronostico> risultatiPronosticiUtenti, IReadOnlyCollection<IscrizioniUtentiFantaCampionato> iscrizioniUtentiFantaCampionato)
        {
            StoricoSheetStructure = new List<StoricoSheetStructure>();

            foreach (var utente in utentiIscritti)
            {
                //if (utente.Id == 642)
                //{
                StoricoSheetStructure.Add(new StoricoSheetStructure
                {
                    Id = utente.Id.ToString(),
                    Fanta_Utente = utente.Nome + " " + utente.Cognome,
                    Risultati_Punteggi = CalcolaPunteggiParziali(pronostici, iscritioniCircuitiCampionato,
                        idCampionatoReale, utente.Id, circuitiList, risultatiPronosticiUtenti),
                    Bonus_Mondiale = iscrizioniUtentiFantaCampionato.FirstOrDefault(x => x.UtenteId == utente.Id)?.PunteggioCampionatoMondiale.ToString(), //CalcolaPunteggioMondiale(),
                    Punteggio_Gare = CalcolaPunteggioTotale(pronostici, iscritioniCircuitiCampionato,
                        idCampionatoReale, utente.Id, risultatiPronosticiUtenti)
                });
                //}
            }
        }

        public static List<NpoiColumnExcel> GetAsset(int numberCircuiti)
        {
            var result = 2000 * numberCircuiti;
            if (result < 6000)
                result = 6000;

            var asset = new List<NpoiColumnExcel>(new List<NpoiColumnExcel>
            {
                new NpoiColumnExcel
                    {Text = "Id", ColumnWidth = 2000, TextAlign = HorizontalAlignment.Center, NumberFormat = ""},
                new NpoiColumnExcel
                    {Text = "Fanta Utente", ColumnWidth = 6000, TextAlign = HorizontalAlignment.Center, NumberFormat = ""},
                new NpoiColumnExcel
                {
                    Text = "Risultati punteggi", ColumnWidth = result,
                    TextAlign = HorizontalAlignment.Left,
                    NumberFormat = ""
                },
                new NpoiColumnExcel
                {
                    Text = "Bonus Mondiale", ColumnWidth = 5000, TextAlign = HorizontalAlignment.Center,
                    NumberFormat = ""
                },
                new NpoiColumnExcel
                {
                    Text = "Punteggio Gare", ColumnWidth = 5000, TextAlign = HorizontalAlignment.Center,
                    NumberFormat = ""
                }
            });

            return asset;
        }

        private static string CalcolaPunteggiParziali(IReadOnlyCollection<PronosticoUtenteGara> pronostici,
            List<IscrizioniCircuitiCampionato> iscritioniCircuitiCampionato, int idCampionatoReale, int utenteId,
            IReadOnlyCollection<Circuiti> circuitiList,
            IReadOnlyCollection<RisultatoPronostico> risultatiPronosticiUtenti)
        {
            var iscrizioniCircuiti =
                iscritioniCircuitiCampionato.FindAll(x => x.CampionatoId == idCampionatoReale && x.RisultatiId != null);

            var circuitoNames = string.Empty;

            var punteggio = string.Empty;

            foreach (var iscrizioneCircuito in iscrizioniCircuiti)
            {
                var nat = circuitiList.FirstOrDefault(x => x.Id == iscrizioneCircuito.CircuitoId)?.Nazione
                    .Substring(0, 3);

                circuitoNames += "  " + nat;

                if (nat == null) continue;

                var stringsBuilder = new StringBuilder(nat.Length);
                var str = new StringBuilder(nat.Length / 3);
                stringsBuilder.Append(AddEmptySpaces(str));

                var pronosticoGara = pronostici.FirstOrDefault(x =>
                    x.GaraId == iscrizioneCircuito.Id && x.UtenteId == utenteId);

                var risultatoPronostico =
                    risultatiPronosticiUtenti.FirstOrDefault(x =>
                        pronosticoGara != null && x.PronosticoId == pronosticoGara.Id);

                if (risultatoPronostico != null)
                    stringsBuilder.Append(" " + risultatoPronostico.PunteggioComplessivoPronostico);
                else
                {
                    stringsBuilder.Append((iscrizioniCircuiti.IndexOf(iscrizioneCircuito) + 1) % 3 == 0
                        ? "ND"
                        : " ND");
                }

                punteggio += AddEmptySpaces(stringsBuilder);

            }

            var firstText = circuitoNames + "@@" + " " + punteggio;

            firstText = firstText.Replace("@", Environment.NewLine);

            return firstText;
        }

        private static string CalcolaPunteggioTotale(IReadOnlyCollection<PronosticoUtenteGara> pronostici,
            List<IscrizioniCircuitiCampionato> iscritioniCircuitiCampionato, int idCampionatoReale, int utenteId,
            IReadOnlyCollection<RisultatoPronostico> risultatiPronosticiUtenti)
        {
            var punteggio = 0;

            var iscrizioniCircuiti =
                iscritioniCircuitiCampionato.FindAll(x => x.CampionatoId == idCampionatoReale && x.RisultatiId != null);

            foreach (var iscrizioneCircuito in iscrizioniCircuiti)
            {
                var pronosticoGara = pronostici.FirstOrDefault(x =>
                    x.GaraId == iscrizioneCircuito.Id && x.UtenteId == utenteId);

                var risultatoPronostico =
                    risultatiPronosticiUtenti.FirstOrDefault(x =>
                        pronosticoGara != null && x.PronosticoId == pronosticoGara.Id);

                if (risultatoPronostico != null)
                    punteggio += risultatoPronostico.PunteggioComplessivoPronostico;

            }

            return punteggio.ToString();
        }

        private static string AddEmptySpaces(StringBuilder str)
        {
            var lengActStr = str.Length;
            var maxCapacity = str.Capacity;
            var missingChar = maxCapacity - lengActStr;

            for (var i = 0; i < missingChar; i++)
                str.Append(" ");

            return str.ToString();
        }
    }
}
