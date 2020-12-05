using FantaF1.Action;
using FantaF1.Action.Interfaces;
using FantaF1.Models;
using FantaF1DataAccessDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FantaF1.Action.ReportAction;
using FantaF1.Models.ExcelRisultatiPronostici;

namespace FantaF1.Controllers
{
    public class HomeController : Controller
    {
        private Orchestrator _orchestrator;
        private IDatabaseAction _databaseAction;

        public ActionResult Index()
        {
            InitializeAll();

            return View();
        }

        public ActionResult LoadIscrizioniUtenti()
        {
            return PartialView("_IscrizioniUtenti");
        }

        public ActionResult LoadPronosticiUtenti()
        {
            InitializeAll();

            var model = new RisultatoGaraViewModel
            {
                Campionato = _orchestrator.FantaCampionatiAction.GetFantaCampionatiSelectListWithIdCampionatoReale(),
                Circuiti = new List<SelectListItem>()                
            };

            return PartialView("_PronosticiUtenti", model);
        }

        public ActionResult LoadCalcolaPronosticiGara()
        {
            InitializeAll();

            var fantaCampionatiList = _orchestrator.FantaCampionatiAction.GetFantaCampionatiList();

            var optionsResult = fantaCampionatiList.Select(fantaCampionato => new SelectListItem
            { Value = fantaCampionato.Id.ToString(), Text = fantaCampionato.Nome }).ToList();

            var model = new CalcolaPronosticiGaraViewModel { FantaCampionatiList = optionsResult, CircuitiList = new List<SelectListItem>() };

            return PartialView("_CalcolaPronosticiGara", model);
        }

        public ActionResult LoadScaricaRisultatiPronosticiGara()
        {
            InitializeAll();

            var fantaCampionatiList = _orchestrator.FantaCampionatiAction.GetFantaCampionatiList();

            var optionsResult = fantaCampionatiList.Select(fantaCampionato => new SelectListItem
            { Value = fantaCampionato.Id.ToString(), Text = fantaCampionato.Nome }).ToList();

            var model = new CalcolaPronosticiGaraViewModel { FantaCampionatiList = optionsResult, CircuitiList = new List<SelectListItem>() };

            return PartialView("_ScaricaRisultatiPronosticiGP", model);
        }

        public JsonResult RetrieveCircuitiWithResultsForFantaCampionato(string fantaCampionatoId)
        {
            InitializeAll();

            var idFantaCampioanto = int.Parse(fantaCampionatoId);

            var campionatoRealeId =
                _orchestrator.FantaCampionatiAction.GetCampionatoRealeIdFromIdFantaCampionato(idFantaCampioanto);
            var iscrizioniCircuitiList =
                _orchestrator.IscrizioniCircuitoCampionatoAction.GetIscrizioniWithResultsForCampionatoReale(
                    campionatoRealeId);

            iscrizioniCircuitiList = iscrizioniCircuitiList.OrderBy(x => x.DataGara).ToList();

            var result = new List<SelectListItem>();

            for (int i = 0; i < iscrizioniCircuitiList.Count; i++)
            {
                result.Add(new SelectListItem
                {
                    Value = iscrizioniCircuitiList[i].Id.ToString(),
                    Text = (i + 1).ToString() + " - " + iscrizioniCircuitiList[i].NomeGP
                });
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [UploadFileFilter]
        public JsonResult SetPartecipantiFantaCampionatoFromCsv(List<FileInformation> uploadedFiles, int idFantaCampionato)
        {
            InitializeAll();

            JsonResult res;

            try
            {
                var pronostici =
                    _orchestrator.IscrizioniUtentiFantaCampionatoAction.LoadUtentiFromFileCsv(
                        uploadedFiles.FirstOrDefault());

                SaveUtentiInDatabase(pronostici, idFantaCampionato);

                res = new JsonResult { Data = "Ok" };
            }

            catch (Exception ex)
            {
                res = new JsonResult { Data = ex.Message };
            }

            return res;
        }

        [HttpPost]
        [UploadFileFilter]
        public JsonResult LoadPronostici(List<FileInformation> uploadedFiles)
        {
            InitializeAll();

            JsonResult res;

            try
            {
                var result = uploadedFiles.FirstOrDefault();

                if (result == null) return null;

                var splitName = result.FileName.Split('-');

                var idGara = int.Parse(splitName[0]);

                var idFantaCampionato =
                    _orchestrator.FantaCampionatiAction.GetFantaCampionatoIdFromName(splitName[1].Trim());

                var pronostici =
                    _orchestrator.PronosticoUtenteGaraAction.LoadPronosticiFromFileCsv(uploadedFiles.FirstOrDefault());

                var dateGara = _orchestrator.IscrizioniCircuitoCampionatoAction.GetIscrizioneForId(idGara).DataGara;

                var idPiloti = _orchestrator.IscrizioniPilotiScuderieAction.GetIDPilotiForGara(dateGara);

                var pilotiList = _orchestrator.PilotiAction.GetPilotiFromIdList(idPiloti);

                var utentiList = _orchestrator.UtentiAction.GetUtentiList();

                _orchestrator.PronosticoUtenteGaraAction.SavePronosticiInDatabase(pronostici, idGara,
                    idFantaCampionato, pilotiList, utentiList);

                res = new JsonResult { Data = "Ok" };
            }
            catch (Exception ex)
            {
                res = new JsonResult { Data = ex.Message };
            }

            return res;
        }

        public ActionResult ShowSetResultRace()
        {
            InitializeAll();

            var model = new RisultatoGaraViewModel
            {
                Campionato = _orchestrator.CampionatiMondialiAction.GetAllCampionatiMondialiSelectItem(),
                Circuiti = new List<SelectListItem>(),
                Piloti = _orchestrator.PilotiAction.GetAllPilotiSelectItem()
            };

            return PartialView("_InserisciRisultatoGara", model);
        }

        public JsonResult RetrieveGrandPrixForCampionatoReale(int idCampionato)
        {
            InitializeAll();

            var grandPrixList = _orchestrator.IscrizioniCircuitoCampionatoAction.GetIscrizioniForCampionatoRealeWithoutResults(idCampionato);

            grandPrixList = grandPrixList.OrderBy(x => x.DataGara).ToList();

            var result = new List<SelectListItem>();

            for (int i = 0; i < grandPrixList.Count; i++)
            {
                result.Add(new SelectListItem
                {
                    Value = grandPrixList[i].Id.ToString(),
                    Text = (i + 1).ToString() + " - " + grandPrixList[i].NomeGP
                });
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult RetrievePilotiForGaraReale(int idGara)
        {
            InitializeAll();
            var giornoGara = _orchestrator.IscrizioniCircuitoCampionatoAction.GetIscrizioneForId(idGara).DataGara;
            var pilotiId = _orchestrator.IscrizioniPilotiScuderieAction.GetIDPilotiForGara(giornoGara);
            pilotiId.Remove(23);
            var model = new RisultatoGaraViewModel
            {
                Piloti = _orchestrator.PilotiAction.GetPilotiFromIdSelectItem(pilotiId)
            };

            return PartialView("_PilotiForGara",model);
        }

        [HttpPost]
        public JsonResult SetRaceResult(RaceResultObj[] listResultRace)
        {
            var list = listResultRace.ToList();
            InitializeAll();

            JsonResult res;

            try
            {
                var idDfnResult = _orchestrator.RisultatoDfnGaraRealeAction.ManageDfnResult(list);

                var idRisultato = _orchestrator.RisultatoGaraRealeAction.ManageSaveResultRace(list, idDfnResult);

                var result = list.FirstOrDefault();

                if (result == null) return null;

                _orchestrator.IscrizioniCircuitoCampionatoAction.UpdateResultRace(result.IdIscrizione, idRisultato);

                var regoleCampionatoMondialeId =
                    _orchestrator.CampionatiMondialiAction.GetRegoleCampionatoIdFromCampionatoId(result.IdCampionato);

                var regolamentoCampionato =
                    _orchestrator.RegoleCampionatoMondialeAction.GetRegoleCampionatoMondialeFromIdRegole(
                        regoleCampionatoMondialeId);

                _orchestrator.IscrizioniPilotiCampionatoAction.UpdatePunteggioPiloti(regolamentoCampionato,
                    listResultRace.ToList(), result.IdCampionato);

                var iscrizioniPilotiCampionato =
                    _orchestrator.IscrizioniPilotiCampionatoAction
                        .GetAllIscrizioniPilotiCampionatoForCampionatoMondialeId(result.IdCampionato);

                var scuderieList = _orchestrator.ScuderieAction.GetListScuderie();

                var iscrizioniPilotiScuderie = _orchestrator.IscrizioniPilotiScuderieAction.GetAllIscrizioniPilotiScuderie();

                _orchestrator.IscrizioniScuderieCampionatoAction.UpdatePunteggioScuderie(result.IdCampionato,
                    iscrizioniPilotiCampionato, scuderieList, iscrizioniPilotiScuderie);

                res = new JsonResult { Data = "Ok" };
            }
            catch (Exception ex)
            {
                res = new JsonResult { Data = ex.Message };
            }

            return res;
        }

        public JsonResult CalculateScorePronostici(int iscrizioneCircuitoCampionatoReale)
        {
            InitializeAll();

            JsonResult res = null;

            try
            {
                var campionatoId =
                    _orchestrator.IscrizioniCircuitoCampionatoAction
                        .GetIdCampionatoFromIscrizioneCircuitoCampionatoRealeId(iscrizioneCircuitoCampionatoReale);

                var listFantaCampionatiDaAggiornare =
                    _orchestrator.FantaCampionatiAction.GetFantaCampionatiListFromCampionatoId(campionatoId);

                var idRisultato =
                    _orchestrator.IscrizioniCircuitoCampionatoAction
                        .GetIdRisultatoFromIscrizioneCircuitoCampionatoRealeId(iscrizioneCircuitoCampionatoReale);

                if (idRisultato == null)
                    throw new Exception(
                        "Non è presente il risultato di gara per il pronostico che si sta cercando di calcolare");

                var idResult = (int) idRisultato;

                var risultatoGara = _orchestrator.RisultatoGaraRealeAction.GetRisultatoGaraFromIdRisultato(idResult);

                var risultatoDfnGara =
                    _orchestrator.RisultatoDfnGaraRealeAction.GetRisultatoDfnFromIdRisultatoDfn(risultatoGara
                        .RisultatoDFNId);

                foreach (var fantaCampionato in listFantaCampionatiDaAggiornare)
                {
                    #region Risultato pronostici gara

                    var pronosticiUtenteGara =
                        _orchestrator.PronosticoUtenteGaraAction
                            .GetPronosticoUtenteGaraFromFantaCampionatoIdAndCircuitoId(fantaCampionato.Id,
                                iscrizioneCircuitoCampionatoReale);

                    var regolamentoFantaCampionato =
                        _orchestrator.RegoleFantaCampionatoAction.GetRegoleFantaCampionatoFromIdRegole(fantaCampionato
                            .RegoleId);

                    _orchestrator.RisultatoPronosticoAction.CreateAndSaveRisultatoPronostico(pronosticiUtenteGara,
                        risultatoGara, regolamentoFantaCampionato, risultatoDfnGara);

                    #endregion

                    #region Aggiornamento punteggio mondiale

                    var classificaPiloti =
                        _orchestrator.IscrizioniPilotiCampionatoAction
                            .GetClassificaPilotiFromIdCampionato(campionatoId);

                    var classificaScuderie =
                        _orchestrator.IscrizioniScuderieCampionatoAction.GetClassificaScuderieFromCampionatoId(
                            campionatoId);

                    var pronosticiMondialeList = _orchestrator.PronosticoUtenteFantaCampionatoAction.GetAllPronostici();

                    _orchestrator.IscrizioniUtentiFantaCampionatoAction.UpdatePunteggioPronosticoMondiale(
                        classificaPiloti, classificaScuderie, pronosticiMondialeList, fantaCampionato.Id,
                        regolamentoFantaCampionato, fantaCampionato.DataTerminePronostici);

                    #endregion

                    res = new JsonResult { Data = "Calcoli effettuati correttamente" };
                }
            }
            catch (Exception ex)
            {
                res = new JsonResult { Data = ex.Message };
            }
            
            return res;
        }

        public void GenerateResultsExcel(int fantaCampionatoId)
        {
            InitializeAll();

            var fantaCampionato = _orchestrator.FantaCampionatiAction.GetFantacampionatoFromId(fantaCampionatoId);

            var iscrizioniUtentiIscrittiFantaCampionato =
                _orchestrator.IscrizioniUtentiFantaCampionatoAction
                    .GetIscrizioniUtentiFantaCampionatoFromIdFantaCampionato(fantaCampionato.Id);

            var utentiIscrittiFantaCampioanto = iscrizioniUtentiIscrittiFantaCampionato.Select(iscrizioneUtente => _orchestrator.UtentiAction.GetUtenteFromId(iscrizioneUtente.UtenteId)).ToList();

            var pronosticiUtenteGara = _orchestrator.PronosticoUtenteGaraAction.GetAllPronostici();

            var risultatiPronosticiUtentiGara = pronosticiUtenteGara.Select(pronosticoUtenteGara =>
                _orchestrator.RisultatoPronosticoAction.GetRisultatoPronosticoFromIdPronosticoUtente(
                    pronosticoUtenteGara.Id)).ToList();

            var campionatoRealeId =
                _orchestrator.FantaCampionatiAction.GetCampionatoRealeIdFromIdFantaCampionato(fantaCampionato.Id);

            var pilotiList = _orchestrator.PilotiAction.GetPilotiList();

            var iscrizioniCircuitiCampionati = _orchestrator.IscrizioniCircuitoCampionatoAction.GetIscrizioniList();

            var circuitiList = _orchestrator.CircuitiAction.GetAllCircuiti();

            var regolamentoidFantaCampionato =
                _orchestrator.FantaCampionatiAction.GetRegolamentoIdFromIdFantaCampionato(fantaCampionato.Id);

            var regolamentoFantaCampionato =
                _orchestrator.RegoleFantaCampionatoAction.GetRegoleFantaCampionatoFromIdRegole(
                    regolamentoidFantaCampionato);

            var iscrizioniUtentiFantaCampionato =
                _orchestrator.IscrizioniUtentiFantaCampionatoAction
                    .GetIscrizioniUtentiFantaCampionatoFromIdFantaCampionato(fantaCampionato.Id);

            var pronosticiFantaCampionato = iscrizioniUtentiFantaCampionato.Select(iscrizione => _orchestrator.PronosticoUtenteFantaCampionatoAction.GetPronosticoUtenteFantaCampionatoFromIdPronostico(iscrizione.PronosticoCampionatoId)).ToList();

            var scuderieList = _orchestrator.ScuderieAction.GetListScuderie();

            var classificaPiloti =
                _orchestrator.IscrizioniPilotiCampionatoAction.GetClassificaPilotiFromIdCampionato(campionatoRealeId);

            var classificaScuderie =
                _orchestrator.IscrizioniScuderieCampionatoAction
                    .GetClassificaScuderieFromCampionatoId(campionatoRealeId);

            var model = CreateExcel(utentiIscrittiFantaCampioanto, pilotiList, pronosticiUtenteGara, risultatiPronosticiUtentiGara, iscrizioniCircuitiCampionati, campionatoRealeId, circuitiList, regolamentoFantaCampionato, iscrizioniUtentiFantaCampionato, pronosticiFantaCampionato, scuderieList, classificaPiloti, classificaScuderie, fantaCampionato);

            if (!ExportExcel(model))
                throw new Exception("Uno o più fogli Excel sono vuoti!");

        }


        #region Private methods

        private void SaveUtentiInDatabase(IEnumerable<RegistrazioneUtenteStructure> registrazioniList, int idFantaCampionato)
        {
            var pilotiList = _orchestrator.PilotiAction.GetPilotiList();
            var scuderieList = _orchestrator.ScuderieAction.GetListScuderie();

            foreach (RegistrazioneUtenteStructure registrazione in registrazioniList)
            {
                var utenteId = _orchestrator.UtentiAction.SaveUtenteInDatabase(registrazione);
                var pronosticoUtenteFantaCampionatoId = _orchestrator.PronosticoUtenteFantaCampionatoAction.SavePronosticoFantaCampionatoInDatabase(registrazione, pilotiList, scuderieList);
                if (utenteId != -1) // Salva nuovo pronostico
                    _orchestrator.IscrizioniUtentiFantaCampionatoAction.SaveIscrizioneUtenteFantaCampionatoInDatabase(idFantaCampionato, pronosticoUtenteFantaCampionatoId, utenteId);
                else
                { // Aggiorna pronostico già esistente
                    utenteId = _orchestrator.UtentiAction.GetUtenteIdFromNameAndSurname(registrazione.Nome, registrazione.Cognome);
                    _orchestrator.IscrizioniUtentiFantaCampionatoAction.UpdateIscrizioneUtenteFantaCampionato(utenteId, idFantaCampionato, pronosticoUtenteFantaCampionatoId);
                }

            }
        }

        private void InitializeAll()
        {
            _databaseAction = new DatabaseAction();
            _orchestrator = new Orchestrator(_databaseAction);
        }

        private List<ReportMainModel.ReportGenericModel> CreateExcel(List<Utenti> utentiIscritti,
            List<Piloti> pilotiList, List<PronosticoUtenteGara> pronosticiUtenti,
            List<RisultatoPronostico> risultatiPronosticiUtenti,
            List<IscrizioniCircuitiCampionato> iscrizioniCircuitiCampionato, int idCampionatoReale,
            List<Circuiti> circuitiList, RegoleFantaCampionato regolamentoFantaCampionato,
            List<IscrizioniUtentiFantaCampionato> iscrizioniUtentiFantaCampionato,
            List<PronosticoUtenteFantaCampionato> pronosticiUtentiFantaCampionato, List<Scuderie> scuderieList,
            List<IscrizioniPilotiCampionato> classificaPiloti, List<IscrizioniScuderieCampionato> classificaScuderie,
            FantaCampionati fantaCampionato)
        {
            var response = new List<ReportMainModel.ReportGenericModel>
            {
                GetDataUtenti(utentiIscritti),
                GetDataPronostici(pilotiList, utentiIscritti, pronosticiUtenti, risultatiPronosticiUtenti,
                    iscrizioniCircuitiCampionato, idCampionatoReale, circuitiList, regolamentoFantaCampionato),
                GetDataStorico(utentiIscritti, pronosticiUtenti, iscrizioniCircuitiCampionato, idCampionatoReale,
                    circuitiList, risultatiPronosticiUtenti, iscrizioniUtentiFantaCampionato),
                GetDataClassifica(utentiIscritti, pronosticiUtenti, iscrizioniCircuitiCampionato, idCampionatoReale,
                    risultatiPronosticiUtenti),
                GetDataMondiale(utentiIscritti, regolamentoFantaCampionato, iscrizioniUtentiFantaCampionato,
                    pronosticiUtentiFantaCampionato, pilotiList, scuderieList, classificaPiloti, classificaScuderie,
                    fantaCampionato.DataTerminePronostici),
                GetDataSuperClassifica(utentiIscritti, pronosticiUtenti, iscrizioniCircuitiCampionato,
                    idCampionatoReale, risultatiPronosticiUtenti, iscrizioniUtentiFantaCampionato)
            };

            return response;
        }

        private static ReportMainModel.ReportGenericModel GetDataUtenti(List<Utenti> utentiIscritti)
        {
            string outp;
            var manager = new ReportsManager();

            var ds = manager.GetReportByTypeUtenti(utentiIscritti, out outp);

            if (ds == null || ds.Tables.Count <= 0)
                return null;

            const string nameSubtitle = "Elenco utenti: ";

            var newModel = new ReportMainModel.ReportGenericModel
            {
                Table = ReportsManager.RetrieveData("Report", "prova.xml"),
                ReportTitle = nameSubtitle,
                AssetsColumn = UtentiIscritti.GetAsset()
            };

            return newModel;
        }

        private static ReportMainModel.ReportGenericModel GetDataPronostici(List<Piloti> pilotiList,
            List<Utenti> utentiIscritti, List<PronosticoUtenteGara> pronosticiUtenti,
            List<RisultatoPronostico> risultatiPronosticiUtenti,
            List<IscrizioniCircuitiCampionato> iscrizioniCircuitiCampionato, int idCampionatoReale,
            List<Circuiti> circuitiList, RegoleFantaCampionato regolamentoFantaCampionato)
        {
            string outp;
            var manager = new ReportsManager();

            var ds = manager.GetReportByTypePronostici(pilotiList, utentiIscritti, pronosticiUtenti, risultatiPronosticiUtenti, iscrizioniCircuitiCampionato, idCampionatoReale, circuitiList, regolamentoFantaCampionato, out outp);

            if (ds == null || ds.Tables.Count <= 0)
                return null;

            const string nameSubtitle = "Elenco pronostici: ";

            var numberCircuiti = iscrizioniCircuitiCampionato.FindAll(x => x.CampionatoId == idCampionatoReale && x.RisultatiId != null).Count;

            var newModel = new ReportMainModel.ReportGenericModel
            {
                Table = ReportsManager.RetrieveData("ReportPronostici", "provaPronostici.xml"),
                ReportTitle = nameSubtitle,
                AssetsColumn = PronosticiSheetModel.GetAsset(numberCircuiti)
            };

            return newModel;
        }

        private ReportMainModel.ReportGenericModel GetDataStorico(IEnumerable<Utenti> utentiIscritti,
            IReadOnlyCollection<PronosticoUtenteGara> pronostici,
            List<IscrizioniCircuitiCampionato> iscritioniCircuitiCampionato, int idCampionatoReale,
            IReadOnlyCollection<Circuiti> circuitiList,
            IReadOnlyCollection<RisultatoPronostico> risultatiPronosticiUtenti,
            List<IscrizioniUtentiFantaCampionato> iscrizioniUtentiFantaCampionato)
        {
            string outp;
            var manager = new ReportsManager();

            var ds = manager.GetReportByTypeStorico(utentiIscritti, pronostici, iscritioniCircuitiCampionato, idCampionatoReale, circuitiList, risultatiPronosticiUtenti, iscrizioniUtentiFantaCampionato, out outp);

            if (ds == null || ds.Tables.Count <= 0)
                return null;

            const string nameSubtitle = "Storico risultati: ";

            var numberCircuiti = iscritioniCircuitiCampionato.FindAll(x => x.CampionatoId == idCampionatoReale && x.RisultatiId != null).Count;

            var newModel = new ReportMainModel.ReportGenericModel
            {
                Table = ReportsManager.RetrieveData("ReportStorico", "provaStorico.xml"),
                ReportTitle = nameSubtitle,
                AssetsColumn = StoricoSheetModel.GetAsset(numberCircuiti)
            };

            return newModel;
        }

        private ReportMainModel.ReportGenericModel GetDataClassifica(List<Utenti> utentiIscritti,
            List<PronosticoUtenteGara> pronostici, List<IscrizioniCircuitiCampionato> iscritioniCircuitiCampionato,
            int idCampionatoReale, List<RisultatoPronostico> risultatiPronosticiUtenti)
        {
            string outp;
            var manager = new ReportsManager();

            var ds = manager.GetReportByTypeClassifica(utentiIscritti, pronostici, risultatiPronosticiUtenti, iscritioniCircuitiCampionato, idCampionatoReale, out outp);

            if (ds == null || ds.Tables.Count <= 0)
                return null;

            const string nameSubtitle = "Classifica: ";

            var newModel = new ReportMainModel.ReportGenericModel
            {
                Table = ReportsManager.RetrieveData("ReportClassifica", "provaClassifica.xml"),
                ReportTitle = nameSubtitle,
                AssetsColumn = ClassificaSheetModel.GetAsset()
            };

            return newModel;
        }

        private static ReportMainModel.ReportGenericModel GetDataMondiale(List<Utenti> utentiIscritti,
            RegoleFantaCampionato regolamentoFantaCampionato,
            List<IscrizioniUtentiFantaCampionato> iscrizioniUtentiFantaCampionato,
            List<PronosticoUtenteFantaCampionato> pronosticiUtentiFantaCampionato, List<Piloti> pilotiList,
            List<Scuderie> scuderieList, List<IscrizioniPilotiCampionato> classificaPiloti,
            List<IscrizioniScuderieCampionato> classificaScuderie, DateTime dataTermineIscrizioni)
        {
            string outp;
            var manager = new ReportsManager();

            var ds = manager.GetReportByTypeMondiale(utentiIscritti, regolamentoFantaCampionato, iscrizioniUtentiFantaCampionato, pronosticiUtentiFantaCampionato, pilotiList, scuderieList, classificaPiloti, classificaScuderie, dataTermineIscrizioni, out outp);

            if (ds == null || ds.Tables.Count <= 0)
                return null;

            const string nameSubtitle = "Mondiale: ";

            var newModel = new ReportMainModel.ReportGenericModel
            {
                Table = ReportsManager.RetrieveData("ReportMondiale", "provaMondiale.xml"),
                ReportTitle = nameSubtitle,
                AssetsColumn = MondialeSheetModel.GetAsset()
            };

            return newModel;
        }

        private static ReportMainModel.ReportGenericModel GetDataSuperClassifica(List<Utenti> utentiIscritti,
            List<PronosticoUtenteGara> pronostici, List<IscrizioniCircuitiCampionato> iscritioniCircuitiCampionato,
            int idCampionatoReale, List<RisultatoPronostico> risultatiPronosticiUtenti,
            List<IscrizioniUtentiFantaCampionato> iscrizioniUtentiFantaCampionato)
        {
            string outp;
            var manager = new ReportsManager();

            var ds = manager.GetReportByTypeSuperClassifica(utentiIscritti, pronostici, risultatiPronosticiUtenti, iscritioniCircuitiCampionato, idCampionatoReale, iscrizioniUtentiFantaCampionato, out outp);

            if (ds == null || ds.Tables.Count <= 0)
                return null;

            const string nameSubtitle = "Super classifica: ";

            var newModel = new ReportMainModel.ReportGenericModel
            {
                Table = ReportsManager.RetrieveData("ReportSuperClassifica", "provaSuperClassifica.xml"),
                ReportTitle = nameSubtitle,
                AssetsColumn = SuperClassificaSheetModel.GetAsset()
            };

            return newModel;
        }

        private bool ExportExcel(IReadOnlyList<ReportMainModel.ReportGenericModel> model)
        {
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("iso-8859-1");
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;filename=Report.xlsx");

            var reportHelper = new ReportUtils(false);

            // REPORT
            var oWorkbook = reportHelper.CreateWorkbook();

            if (model[0] == null || model[1] == null || model[2] == null || model[3] == null || model[4] == null ||
                model[5] == null)
                return false;

            reportHelper.CreateFirstSheet(oWorkbook, model[0].Table, model[0].AssetsColumn, FillHeaderReport(model[0].ReportTitle));

            reportHelper.CreateSecondSheet(oWorkbook, model[1].Table, model[1].AssetsColumn, FillHeaderReport(model[1].ReportTitle));

            reportHelper.CreateThirdSheet(oWorkbook, model[2].Table, model[2].AssetsColumn, FillHeaderReport(model[2].ReportTitle));

            reportHelper.CreateFourthSheet(oWorkbook, model[3].Table, model[3].AssetsColumn, FillHeaderReport(model[3].ReportTitle));

            reportHelper.CreateFifthSheet(oWorkbook, model[4].Table, model[4].AssetsColumn, FillHeaderReport(model[4].ReportTitle));

            reportHelper.CreateSixthSheet(oWorkbook, model[5].Table, model[5].AssetsColumn, FillHeaderReport(model[5].ReportTitle));

            using (var stream = new NpoiMemoryStream { AllowClose = false })
            {
                oWorkbook.Write(stream);
                stream.WriteTo(Response.OutputStream);
            }

            Response.Flush();

            Response.End();

            return true;
        }

        private static HeaderReport FillHeaderReport(string typeReport)
        {
            return new HeaderReport
            {
                Title = "Report",
                ListDescription = typeReport + DateTime.Today.Date.ToShortDateString()
            };
        }

        #endregion
    }
}