using System.Collections.Generic;
using FantaF1DataAccessDB;
using NPOI.SS.UserModel;

namespace FantaF1.Models.ExcelRisultatiPronostici
{
    public class UtentiIscritti
    {
        private List<UtentiIscrittiStructure> Proposals { get; set; }

        private static readonly List<NpoiColumnExcel> Asset = new List<NpoiColumnExcel>(new List<NpoiColumnExcel>
            {
                new NpoiColumnExcel { Text = "Id", ColumnWidth = 6700, TextAlign = HorizontalAlignment.Center, NumberFormat = "" }
                , new NpoiColumnExcel { Text = "Nome", ColumnWidth = 6700, TextAlign = HorizontalAlignment.Center, NumberFormat = "" }
                , new NpoiColumnExcel { Text = "Cognome", ColumnWidth = 6700, TextAlign = HorizontalAlignment.Center, NumberFormat = "" }
                , new NpoiColumnExcelDateTime { Text = "Data Iscrizione", ColumnWidth = 5000, TextAlign = HorizontalAlignment.Center, NumberFormat = "dd-mm-yyyy" }
            });

        public UtentiIscritti(IEnumerable<Utenti> utentiIscritti)
        {
            Proposals = new List<UtentiIscrittiStructure>();

            foreach (var utente in utentiIscritti)
            {
                Proposals.Add(new UtentiIscrittiStructure
                {
                    Id = utente.Id.ToString(),
                    Nome = utente.Nome,
                    Cognome = utente.Cognome,
                    DataIscrizione = utente.Data_Registrazione.ToShortDateString()
                });
            }
        }

        public static List<NpoiColumnExcel> GetAsset()
        {
            return Asset;
        }
    }

}
