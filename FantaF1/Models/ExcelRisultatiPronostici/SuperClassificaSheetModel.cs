using System.Collections.Generic;
using System.Linq;
using FantaF1DataAccessDB;
using NPOI.SS.UserModel;

namespace FantaF1.Models.ExcelRisultatiPronostici
{
    public class SuperClassificaSheetModel
    {
        private List<SuperClassificaSheetStructure> SuperClassificaSheetStructure { get; set; }

        public SuperClassificaSheetModel(IEnumerable<Utenti> utentiIscritti, IReadOnlyCollection<PronosticoUtenteGara> pronosticiUtenti,
            IReadOnlyCollection<RisultatoPronostico> risultatiPronosticiUtenti,
            List<IscrizioniCircuitiCampionato> iscrizioniCircuitiCampionato, int idCampionatoReale,
            IReadOnlyCollection<IscrizioniUtentiFantaCampionato> iscrizioniUtentiFantaCampionato)
        {
            SuperClassificaSheetStructure = new List<SuperClassificaSheetStructure>();

            foreach (var utente in utentiIscritti)
            {
                var punti = 0;

                var punteggioMondiale = iscrizioniUtentiFantaCampionato.FirstOrDefault(x => x.UtenteId == utente.Id);

                if (punteggioMondiale != null)
                    punti = punteggioMondiale.PunteggioCampionatoMondiale;

                //if (utente.Id == 642)
                //{
                SuperClassificaSheetStructure.Add(new SuperClassificaSheetStructure
                {
                    FantaUtente = utente.Nome + " " + utente.Cognome,
                    Punti = CalcolaPunteggioTotale(pronosticiUtenti, iscrizioniCircuitiCampionato, idCampionatoReale, utente.Id, risultatiPronosticiUtenti, punti)
                });
                //}
            }

            SuperClassificaSheetStructure = SuperClassificaSheetStructure.OrderByDescending(x => x.Punti).ToList();

            for (var posizione = 0; posizione < SuperClassificaSheetStructure.Count; posizione++)
                SuperClassificaSheetStructure[posizione].Posizione = (posizione + 1).ToString();

        }

        public static List<NpoiColumnExcel> GetAsset()
        {
            var asset = new List<NpoiColumnExcel>(new List<NpoiColumnExcel>
            {
                new NpoiColumnExcel
                    {Text = "Posizione", ColumnWidth = 3000, TextAlign = HorizontalAlignment.Center, NumberFormat = ""},
                new NpoiColumnExcel
                    {Text = "Fanta Utente", ColumnWidth = 6000, TextAlign = HorizontalAlignment.Center, NumberFormat = ""},
                new NpoiColumnExcel
                {
                    Text = "Punti", ColumnWidth = 3000, TextAlign = HorizontalAlignment.Center,
                    NumberFormat = ""
                }
            });

            return asset;
        }

        private static string CalcolaPunteggioTotale(IReadOnlyCollection<PronosticoUtenteGara> pronostici,
            List<IscrizioniCircuitiCampionato> iscritioniCircuitiCampionato, int idCampionatoReale, int utenteId,
            IReadOnlyCollection<RisultatoPronostico> risultatiPronosticiUtenti, int punteggioMondiale)
        {
            var iscrizioniCircuiti =
                iscritioniCircuitiCampionato.FindAll(x => x.CampionatoId == idCampionatoReale && x.RisultatiId != null);

            var punteggio = iscrizioniCircuiti
                .Select(iscrizioneCircuito => pronostici.FirstOrDefault(x =>
                    x.GaraId == iscrizioneCircuito.Id && x.UtenteId == utenteId))
                .Select(pronosticoGara =>
                    risultatiPronosticiUtenti.FirstOrDefault(x =>
                        pronosticoGara != null && x.PronosticoId == pronosticoGara.Id))
                .Where(risultatoPronostico => risultatoPronostico != null).Sum(risultatoPronostico =>
                    risultatoPronostico.PunteggioComplessivoPronostico);

            punteggio += punteggioMondiale;

            return punteggio.ToString();
        }

    }
}