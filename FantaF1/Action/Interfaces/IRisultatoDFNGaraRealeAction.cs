using FantaF1.Models;
using FantaF1DataAccessDB;
using System.Collections.Generic;

namespace FantaF1.Action.Interfaces
{
    public interface IRisultatoDfnGaraRealeAction
    {
        int ManageDfnResult(List<RaceResultObj> listResultRace);
        RisultatoDFNGaraReale GetRisultatoDfnFromIdRisultatoDfn(int risultatoGaraDfnId);
    }
}
