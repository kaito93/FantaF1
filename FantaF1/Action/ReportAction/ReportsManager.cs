using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using FantaF1.Models.ExcelRisultatiPronostici;
using FantaF1DataAccessDB;

namespace FantaF1.Action.ReportAction
{
    public class ReportsManager
    {
        public ExcelSet GetReportByTypeUtenti(List<Utenti> utentiIscritti, out string retMsgs)
        {
            var dataSource = new ReportDataSource();

            retMsgs = string.Empty;
            TextWriter writer = new StreamWriter(Path.GetTempPath() + "prova.xml");

            try
            {
                var responseNode = dataSource.GetReportByType(utentiIscritti, writer);

                if (responseNode == null || responseNode.OuterXml.IndexOf("<erro", 0) > -1)
                {
                    retMsgs = responseNode == null ? "EmptyResponseMessage" : responseNode.OuterXml;
                    return null;
                }

                var responseXml = XDocument.Load(new XmlNodeReader(responseNode));
                var ds = new ExcelSet();

                ds.ReadXml(new StringReader(responseXml.ToString()), XmlReadMode.InferSchema);
                return ds;
            }
            catch (Exception e)
            {
                writer.Close();
            }

            return null;
        }

        public ExcelSet GetReportByTypePronostici(List<Piloti> pilotiList, List<Utenti> utentiIscritti, List<PronosticoUtenteGara> pronosticiUtenti, List<RisultatoPronostico> risultatiPronosticiUtenti, List<IscrizioniCircuitiCampionato> iscrizioniCircuitiCampionato, int idCampionatoReale, List<Circuiti> circuitiList, RegoleFantaCampionato regolamentoFantaCampionato, out string retMsgs)
        {
            var dataSource = new ReportDataSource();

            retMsgs = string.Empty;
            TextWriter writer = new StreamWriter(Path.GetTempPath() + "provaPronostici.xml");

            try
            {
                var responseNode = dataSource.GetReportByTypePronostici(pilotiList, utentiIscritti, pronosticiUtenti, risultatiPronosticiUtenti, iscrizioniCircuitiCampionato, idCampionatoReale, circuitiList, regolamentoFantaCampionato, writer);

                if (responseNode == null || responseNode.OuterXml.IndexOf("<erro", 0) > -1)
                {
                    retMsgs = responseNode == null ? "EmptyResponseMessage" : responseNode.OuterXml;
                    return null;
                }

                var responseXml = XDocument.Load(new XmlNodeReader(responseNode));
                var ds = new ExcelSet();

                ds.ReadXml(new StringReader(responseXml.ToString()), XmlReadMode.InferSchema);
                return ds;
            }
            catch (Exception e)
            {
                writer.Close();
            }

            return null;
        }

        public ExcelSet GetReportByTypeStorico(IEnumerable<Utenti> utentiIscritti, IReadOnlyCollection<PronosticoUtenteGara> pronostici, List<IscrizioniCircuitiCampionato> iscritioniCircuitiCampionato, int idCampionatoReale, IReadOnlyCollection<Circuiti> circuitiList, IReadOnlyCollection<RisultatoPronostico> risultatiPronosticiUtenti, List<IscrizioniUtentiFantaCampionato> iscrizioniUtentiFantaCampionato, out string retMsgs)
        {
            var dataSource = new ReportDataSource();

            retMsgs = string.Empty;
            TextWriter writer = new StreamWriter(Path.GetTempPath() + "provaStorico.xml");

            try
            {
                var responseNode = dataSource.GetReportByTypeStorico(utentiIscritti, pronostici, iscritioniCircuitiCampionato, idCampionatoReale, circuitiList, risultatiPronosticiUtenti, iscrizioniUtentiFantaCampionato, writer);

                if (responseNode == null || responseNode.OuterXml.IndexOf("<erro", 0) > -1)
                {
                    retMsgs = responseNode == null ? "EmptyResponseMessage" : responseNode.OuterXml;
                    return null;
                }

                var responseXml = XDocument.Load(new XmlNodeReader(responseNode));
                var ds = new ExcelSet();

                ds.ReadXml(new StringReader(responseXml.ToString()), XmlReadMode.InferSchema);
                return ds;
            }
            catch (Exception e)
            {
                writer.Close();
            }

            return null;
        }

        public ExcelSet GetReportByTypeClassifica(List<Utenti> utentiIscritti, List<PronosticoUtenteGara> pronosticiUtenti,
            List<RisultatoPronostico> risultatiPronosticiUtenti, List<IscrizioniCircuitiCampionato> iscrizioniCircuitiCampionato, int idCampionatoReale, out string retMsgs)
        {
            var dataSource = new ReportDataSource();

            retMsgs = string.Empty;
            TextWriter writer = new StreamWriter(Path.GetTempPath() + "provaClassifica.xml");

            try
            {
                var responseNode = dataSource.GetReportByTypeClassifica(utentiIscritti, pronosticiUtenti, risultatiPronosticiUtenti, iscrizioniCircuitiCampionato, idCampionatoReale, writer);

                if (responseNode == null || responseNode.OuterXml.IndexOf("<erro", 0) > -1)
                {
                    retMsgs = responseNode == null ? "EmptyResponseMessage" : responseNode.OuterXml;
                    return null;
                }

                var responseXml = XDocument.Load(new XmlNodeReader(responseNode));
                var ds = new ExcelSet();

                ds.ReadXml(new StringReader(responseXml.ToString()), XmlReadMode.InferSchema);
                return ds;
            }
            catch (Exception e)
            {
                writer.Close();
            }

            return null;
        }

        public ExcelSet GetReportByTypeMondiale(List<Utenti> utentiIscritti, RegoleFantaCampionato regolamentoFantaCampionato, List<IscrizioniUtentiFantaCampionato> iscrizioniUtentiFantaCampionato, List<PronosticoUtenteFantaCampionato> pronosticiUtentiFantaCampionato, List<Piloti> pilotiList, List<Scuderie> scuderieList, List<IscrizioniPilotiCampionato> classificaPiloti, List<IscrizioniScuderieCampionato> classificaScuderie, DateTime dataTermineIscrizioni, out string retMsgs)
        {
            var dataSource = new ReportDataSource();

            retMsgs = string.Empty;
            TextWriter writer = new StreamWriter(Path.GetTempPath() + "provaMondiale.xml");

            try
            {
                var responseNode = dataSource.GetReportByTypeMondiale(utentiIscritti, regolamentoFantaCampionato, iscrizioniUtentiFantaCampionato, pronosticiUtentiFantaCampionato, pilotiList, scuderieList, classificaPiloti, classificaScuderie, dataTermineIscrizioni, writer);

                if (responseNode == null || responseNode.OuterXml.IndexOf("<erro", 0) > -1)
                {
                    retMsgs = responseNode == null ? "EmptyResponseMessage" : responseNode.OuterXml;
                    return null;
                }

                var responseXml = XDocument.Load(new XmlNodeReader(responseNode));
                var ds = new ExcelSet();

                ds.ReadXml(new StringReader(responseXml.ToString()), XmlReadMode.InferSchema);
                return ds;
            }
            catch (Exception e)
            {
                writer.Close();
            }

            return null;
        }

        public ExcelSet GetReportByTypeSuperClassifica(List<Utenti> utentiIscritti, List<PronosticoUtenteGara> pronosticiUtenti,
            List<RisultatoPronostico> risultatiPronosticiUtenti, List<IscrizioniCircuitiCampionato> iscrizioniCircuitiCampionato, int idCampionatoReale, List<IscrizioniUtentiFantaCampionato> iscrizioniUtentiFantaCampionato, out string retMsgs)
        {
            var dataSource = new ReportDataSource();

            retMsgs = string.Empty;
            TextWriter writer = new StreamWriter(Path.GetTempPath() + "provaSuperClassifica.xml");

            try
            {
                var responseNode = dataSource.GetReportByTypeSuperClassifica(utentiIscritti, pronosticiUtenti, risultatiPronosticiUtenti, iscrizioniCircuitiCampionato, idCampionatoReale, iscrizioniUtentiFantaCampionato, writer);

                if (responseNode == null || responseNode.OuterXml.IndexOf("<erro", 0) > -1)
                {
                    retMsgs = responseNode == null ? "EmptyResponseMessage" : responseNode.OuterXml;
                    return null;
                }

                var responseXml = XDocument.Load(new XmlNodeReader(responseNode));
                var ds = new ExcelSet();

                ds.ReadXml(new StringReader(responseXml.ToString()), XmlReadMode.InferSchema);
                return ds;
            }
            catch (Exception e)
            {
                writer.Close();
            }

            return null;
        }

        public static DataTable RetrieveData(string nameReport, string nameFileXml)
        {
            return ReportDataSource.BuildDataTableFromXml(nameReport, nameFileXml);
        }
    }
}