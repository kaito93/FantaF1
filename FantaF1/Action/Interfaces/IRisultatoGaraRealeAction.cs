using FantaF1.Models;
using FantaF1DataAccessDB;
using System.Collections.Generic;

namespace FantaF1.Action.Interfaces
{
    public interface IRisultatoGaraRealeAction
    {
        int ManageSaveResultRace(List<RaceResultObj> listResultRace, int idRisultatoDfnGaraReale);
        RisultatoGaraReale GetRisultatoGaraFromIdRisultato(int idRisultato);

    }
}
