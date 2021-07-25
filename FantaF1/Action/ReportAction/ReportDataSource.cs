using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using FantaF1.Models.ExcelRisultatiPronostici;
using FantaF1DataAccessDB;

namespace FantaF1.Action.ReportAction
{
    public class ReportDataSource
    {
        public XmlNode GetReportByType(List<Utenti> utentiIscritti, TextWriter writer)
        {

            XmlSerializer ser;
            object dat;

            ser = new XmlSerializer(typeof(UtentiIscritti));
            dat = new UtentiIscritti(utentiIscritti);

            ser.Serialize(writer, dat);
            writer.Close();

            BuildDataTableFromXml("Report", "prova.xml");

            var doc = new XmlDocument();
            doc.Load(Path.GetTempPath() + "prova.xml");

            var root = doc.DocumentElement;
            var nodeList = root?.SelectNodes("/");
            var it = nodeList?.Item(0);
            return it;

        }

        public XmlNode GetReportByTypePronostici(List<Piloti> pilotiList, List<Utenti> utentiIscritti, List<PronosticoUtenteGara> pronosticiUtenti, List<RisultatoPronostico> risultatiPronosticiUtenti, List<IscrizioniCircuitiCampionato> iscrizioniCircuitiCampionato, int idCampionatoReale, List<Circuiti> circuitiList, RegoleFantaCampionato regolamentoFantaCampionato, int idFantaCampionato, TextWriter writer)
        {

            XmlSerializer ser;
            object dat;

            ser = new XmlSerializer(typeof(PronosticiSheetModel));
            dat = new PronosticiSheetModel(pilotiList, utentiIscritti, pronosticiUtenti, risultatiPronosticiUtenti, iscrizioniCircuitiCampionato, idCampionatoReale, circuitiList, regolamentoFantaCampionato, idFantaCampionato);

            ser.Serialize(writer, dat);
            writer.Close();

            BuildDataTableFromXml("ReportPronostici", "provaPronostici.xml");

            var doc = new XmlDocument();
            doc.Load(Path.GetTempPath() + "provaPronostici.xml");

            var root = doc.DocumentElement;
            var nodeList = root?.SelectNodes("/");
            var it = nodeList?.Item(0);
            return it;

        }

        public XmlNode GetReportByTypeStorico(IEnumerable<Utenti> utentiIscritti, IReadOnlyCollection<PronosticoUtenteGara> pronostici, List<IscrizioniCircuitiCampionato> iscritioniCircuitiCampionato, int idCampionatoReale, IReadOnlyCollection<Circuiti> circuitiList, IReadOnlyCollection<RisultatoPronostico> risultatiPronosticiUtenti, List<IscrizioniUtentiFantaCampionato> iscrizioniUtentiFantaCampionato, TextWriter writer)
        {

            XmlSerializer ser;
            object dat;

            ser = new XmlSerializer(typeof(StoricoSheetModel));
            dat = new StoricoSheetModel(utentiIscritti, pronostici, iscritioniCircuitiCampionato, idCampionatoReale, circuitiList, risultatiPronosticiUtenti, iscrizioniUtentiFantaCampionato);

            ser.Serialize(writer, dat);
            writer.Close();

            BuildDataTableFromXml("ReportStorico", "provaStorico.xml");

            var doc = new XmlDocument();
            doc.Load(Path.GetTempPath() + "provaStorico.xml");

            var root = doc.DocumentElement;
            var nodeList = root?.SelectNodes("/");
            var it = nodeList?.Item(0);
            return it;

        }

        public XmlNode GetReportByTypeClassifica(List<Utenti> utentiIscritti, List<PronosticoUtenteGara> pronosticiUtenti,
            List<RisultatoPronostico> risultatiPronosticiUtenti, List<IscrizioniCircuitiCampionato> iscrizioniCircuitiCampionato, int idCampionatoReale, TextWriter writer)
        {

            XmlSerializer ser;
            object dat;

            ser = new XmlSerializer(typeof(ClassificaSheetModel));
            dat = new ClassificaSheetModel(utentiIscritti, pronosticiUtenti, risultatiPronosticiUtenti, iscrizioniCircuitiCampionato, idCampionatoReale);

            ser.Serialize(writer, dat);
            writer.Close();

            BuildDataTableFromXml("ReportClassifica", "provaClassifica.xml");

            var doc = new XmlDocument();
            doc.Load(Path.GetTempPath() + "provaClassifica.xml");

            var root = doc.DocumentElement;
            var nodeList = root?.SelectNodes("/");
            var it = nodeList?.Item(0);
            return it;

        }

        public XmlNode GetReportByTypeMondiale(List<Utenti> utentiIscritti, RegoleFantaCampionato regolamentoFantaCampionato, List<IscrizioniUtentiFantaCampionato> iscrizioniUtentiFantaCampionato, List<PronosticoUtenteFantaCampionato> pronosticiUtentiFantaCampionato, List<Piloti> pilotiList, List<Scuderie> scuderieList, List<IscrizioniPilotiCampionato> classificaPiloti, List<IscrizioniScuderieCampionato> classificaScuderie, DateTime dataTermineIscrizioni, TextWriter writer)
        {

            XmlSerializer ser;
            object dat;

            ser = new XmlSerializer(typeof(MondialeSheetModel));
            dat = new MondialeSheetModel(utentiIscritti, regolamentoFantaCampionato, iscrizioniUtentiFantaCampionato, pronosticiUtentiFantaCampionato, pilotiList, scuderieList, classificaPiloti, classificaScuderie, dataTermineIscrizioni);

            ser.Serialize(writer, dat);
            writer.Close();

            BuildDataTableFromXml("ReportMondiale", "provaMondiale.xml");

            var doc = new XmlDocument();
            doc.Load(Path.GetTempPath() + "provaMondiale.xml");

            var root = doc.DocumentElement;
            var nodeList = root?.SelectNodes("/");
            var it = nodeList?.Item(0);
            return it;

        }

        public XmlNode GetReportByTypeSuperClassifica(List<Utenti> utentiIscritti, List<PronosticoUtenteGara> pronosticiUtenti,
            List<RisultatoPronostico> risultatiPronosticiUtenti, List<IscrizioniCircuitiCampionato> iscrizioniCircuitiCampionato, int idCampionatoReale, List<IscrizioniUtentiFantaCampionato> iscrizioniUtentiFantaCampionato, TextWriter writer)
        {

            XmlSerializer ser;
            object dat;

            ser = new XmlSerializer(typeof(SuperClassificaSheetModel));
            dat = new SuperClassificaSheetModel(utentiIscritti, pronosticiUtenti, risultatiPronosticiUtenti, iscrizioniCircuitiCampionato, idCampionatoReale, iscrizioniUtentiFantaCampionato);

            ser.Serialize(writer, dat);
            writer.Close();

            BuildDataTableFromXml("ReportSuperClassifica", "provaSuperClassifica.xml");

            var doc = new XmlDocument();
            doc.Load(Path.GetTempPath() + "provaSuperClassifica.xml");

            var root = doc.DocumentElement;
            var nodeList = root?.SelectNodes("/");
            var it = nodeList?.Item(0);
            return it;

        }

        /// <summary>
        /// Converts XML string to DataTable
        /// </summary>
        /// <param name="name">DataTable name</param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static DataTable BuildDataTableFromXml(string name, string fileName)
        {
            var doc = new XmlDocument();
            doc.Load(Path.GetTempPath() + fileName);
            var dt = new DataTable(name);
            try
            {
                var nodoEstructura = doc.LastChild.FirstChild.FirstChild;

                //  Table structure (columns definition) 
                foreach (XmlNode columna in nodoEstructura.ChildNodes)
                    dt.Columns.Add(columna.Name, typeof(string));

                var filas = doc.LastChild;

                //  Data Rows 
                foreach (XmlNode fila in filas.FirstChild.ChildNodes)
                    dt.Rows.Add((from XmlNode columna in fila.ChildNodes select columna.InnerText).ToArray());

            }
            catch (Exception)
            {
                // ignored
            }

            return dt;
        }
    }
}