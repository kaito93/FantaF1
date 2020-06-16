using System.Collections.Generic;
using System.Linq;
using FantaF1DataAccessDB;
using NPOI.SS.UserModel;

namespace FantaF1.Models.ExcelRisultatiPronostici
{
    public class ClassificaSheetModel
    {
        private List<ClassificaSheetStructure> ClassificaSheetStructure { get; set; }

        public ClassificaSheetModel(List<Utenti> utentiIscritti, IReadOnlyCollection<PronosticoUtenteGara> pronosticiUtenti,
            IReadOnlyCollection<RisultatoPronostico> risultatiPronosticiUtenti, List<IscrizioniCircuitiCampionato> iscrizioniCircuitiCampionato, int idCampionatoReale)
        {
            CalcolaClassificaAttuale(utentiIscritti, pronosticiUtenti, iscrizioniCircuitiCampionato, idCampionatoReale, risultatiPronosticiUtenti);

            var penultimaClassifica = CalcolaPenultimaClassifica(utentiIscritti, pronosticiUtenti, iscrizioniCircuitiCampionato, idCampionatoReale, risultatiPronosticiUtenti);

            foreach (var fantautente in ClassificaSheetStructure)
            {
                var posizione = penultimaClassifica?.FirstOrDefault(x => x.FantaUtente == fantautente.FantaUtente)?.Posizione;

                if (posizione == null) continue;

                var guadagno =
                    int.Parse(posizione) - int.Parse(fantautente.Posizione);

                if (guadagno > 0)
                    fantautente.Pos = "+" + guadagno;
                else
                    fantautente.Pos = guadagno.ToString();
            }
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
                },
                new NpoiColumnExcel
                {
                    Text = "Pos", ColumnWidth = 2000, TextAlign = HorizontalAlignment.Center,
                    NumberFormat = ""
                }
            });

            return asset;
        }

        private static string CalcolaPunteggioTotale(IReadOnlyCollection<PronosticoUtenteGara> pronostici,
            List<IscrizioniCircuitiCampionato> iscritioniCircuitiCampionato, int idCampionatoReale, int utenteId,
            IReadOnlyCollection<RisultatoPronostico> risultatiPronosticiUtenti)
        {
            var iscrizioniCircuiti =
                iscritioniCircuitiCampionato.FindAll(x => x.CampionatoId == idCampionatoReale && x.RisultatiId != null);

            var punteggio = iscrizioniCircuiti
                .Select(iscrizioneCircuito => pronostici.FirstOrDefault(x =>
                    x.CircuitoId == iscrizioneCircuito.CircuitoId && x.UtenteId == utenteId))
                .Select(pronosticoGara =>
                    risultatiPronosticiUtenti.FirstOrDefault(x =>
                        pronosticoGara != null && x.PronosticoId == pronosticoGara.Id))
                .Where(risultatoPronostico => risultatoPronostico != null).Sum(risultatoPronostico =>
                    risultatoPronostico.PunteggioComplessivoPronostico);

            return punteggio.ToString();
        }

        private void CalcolaClassificaAttuale(List<Utenti> utentiIscritti, IReadOnlyCollection<PronosticoUtenteGara> pronostici,
            List<IscrizioniCircuitiCampionato> iscritioniCircuitiCampionato, int idCampionatoReale,
            IReadOnlyCollection<RisultatoPronostico> risultatiPronosticiUtenti)
        {
            ClassificaSheetStructure = new List<ClassificaSheetStructure>();

            foreach (var utente in utentiIscritti)
            {
                //if (utente.Id == 642)
                //{
                ClassificaSheetStructure.Add(new ClassificaSheetStructure
                {
                    FantaUtente = utente.Nome + " " + utente.Cognome,
                    Punti = CalcolaPunteggioTotale(pronostici, iscritioniCircuitiCampionato, idCampionatoReale, utente.Id, risultatiPronosticiUtenti)
                });
                //}
            }

            ClassificaSheetStructure = ClassificaSheetStructure.OrderByDescending(x => x.Punti).ToList();

            for (var posizione = 0; posizione < ClassificaSheetStructure.Count; posizione++)
                ClassificaSheetStructure[posizione].Posizione = (posizione + 1).ToString();

        }

        private List<ClassificaSheetStructure> CalcolaPenultimaClassifica(List<Utenti> utentiIscritti, IReadOnlyCollection<PronosticoUtenteGara> pronostici,
            List<IscrizioniCircuitiCampionato> iscritioniCircuitiCampionato, int idCampionatoReale,
            IReadOnlyCollection<RisultatoPronostico> risultatiPronosticiUtenti)
        {
            var response = utentiIscritti.Select(utente => new ClassificaSheetStructure
            {
                FantaUtente = utente.Nome + " " + utente.Cognome,
                Punti = CalcolaPunteggioTotalePenultima(pronostici, iscritioniCircuitiCampionato, idCampionatoReale,
                    utente.Id, risultatiPronosticiUtenti)
            }).ToList();

            response = response.OrderByDescending(x => x.Punti).ToList();

            for (var posizione = 0; posizione < response.Count; posizione++)
                response[posizione].Posizione = (posizione + 1).ToString();

            return response;
        }

        private static string CalcolaPunteggioTotalePenultima(IReadOnlyCollection<PronosticoUtenteGara> pronostici,
            List<IscrizioniCircuitiCampionato> iscritioniCircuitiCampionato, int idCampionatoReale, int utenteId,
            IReadOnlyCollection<RisultatoPronostico> risultatiPronosticiUtenti)
        {
            var iscrizioniCircuiti =
                iscritioniCircuitiCampionato.FindAll(x => x.CampionatoId == idCampionatoReale && x.RisultatiId != null);

            iscrizioniCircuiti.RemoveAt(iscrizioniCircuiti.Count - 1);

            var punteggio = iscrizioniCircuiti
                .Select(iscrizioneCircuito => pronostici.FirstOrDefault(x =>
                    x.CircuitoId == iscrizioneCircuito.CircuitoId && x.UtenteId == utenteId))
                .Select(pronosticoGara =>
                    risultatiPronosticiUtenti.FirstOrDefault(x =>
                        pronosticoGara != null && x.PronosticoId == pronosticoGara.Id))
                .Where(risultatoPronostico => risultatoPronostico != null).Sum(risultatoPronostico =>
                    risultatoPronostico.PunteggioComplessivoPronostico);

            return punteggio.ToString();
        }
    }
}