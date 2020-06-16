using FantaF1.Action.Interfaces;
using FantaF1.Models;
using FantaF1DataAccessDB;
using System.Collections.Generic;
using System.Linq;

namespace FantaF1.Action
{
    public class RisultatoDfnGaraRealeAction : IRisultatoDfnGaraRealeAction
    {
        private List<RisultatoDFNGaraReale> _risultatiDfnGareReali;
        private readonly IDatabaseAction _databaseAction;
        public RisultatoDfnGaraRealeAction(IDatabaseAction databaseAction)
        {
            _databaseAction = databaseAction;
            _risultatiDfnGareReali = databaseAction.GetRisultatiDfnGaraReale();
        }
        public int ManageDfnResult(List<RaceResultObj> listResultRace)
        {
            var listDfn = listResultRace.FindAll(x => x.Dfn).ToList();

            var newResult = new RisultatoDFNGaraReale();

            for (var i = 0; i < listDfn.Count; i++)
            {
                switch (i + 1)
                {
                    case 1:
                        newResult.PilotaId01 = listDfn[i].PilotaId;
                        break;
                    case 2:
                        newResult.PilotaId02 = listDfn[i].PilotaId;
                        break;
                    case 3:
                        newResult.PilotaId03 = listDfn[i].PilotaId;
                        break;
                    case 4:
                        newResult.PilotaId04 = listDfn[i].PilotaId;
                        break;
                    case 5:
                        newResult.PilotaId05 = listDfn[i].PilotaId;
                        break;
                    case 6:
                        newResult.PilotaId06 = listDfn[i].PilotaId;
                        break;
                    case 7:
                        newResult.PilotaId07 = listDfn[i].PilotaId;
                        break;
                    case 8:
                        newResult.PilotaId08 = listDfn[i].PilotaId;
                        break;
                    case 9:
                        newResult.PilotaId09 = listDfn[i].PilotaId;
                        break;
                    case 10:
                        newResult.PilotaId10 = listDfn[i].PilotaId;
                        break;
                    case 11:
                        newResult.PilotaId11 = listDfn[i].PilotaId;
                        break;
                    case 12:
                        newResult.PilotaId12 = listDfn[i].PilotaId;
                        break;
                    case 13:
                        newResult.PilotaId13 = listDfn[i].PilotaId;
                        break;
                    case 14:
                        newResult.PilotaId14 = listDfn[i].PilotaId;
                        break;
                    case 15:
                        newResult.PilotaId15 = listDfn[i].PilotaId;
                        break;
                    case 16:
                        newResult.PilotaId16 = listDfn[i].PilotaId;
                        break;
                    case 17:
                        newResult.PilotaId17 = listDfn[i].PilotaId;
                        break;
                    case 18:
                        newResult.PilotaId18 = listDfn[i].PilotaId;
                        break;
                    case 19:
                        newResult.PilotaId19 = listDfn[i].PilotaId;
                        break;
                    case 20:
                        newResult.PilotaId20 = listDfn[i].PilotaId;
                        break;

                }
            }

            _risultatiDfnGareReali = _databaseAction.SaveRisultatoDfnGaraReale(newResult);


            return _risultatiDfnGareReali.Last().Id;
        }

        public RisultatoDFNGaraReale GetRisultatoDfnFromIdRisultatoDfn(int risultatoGaraDfnId)
        {
            return _risultatiDfnGareReali.FirstOrDefault(x => x.Id == risultatoGaraDfnId);
        }
    }
}