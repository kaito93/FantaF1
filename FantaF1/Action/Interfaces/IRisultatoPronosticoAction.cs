using FantaF1DataAccessDB;
using System.Collections.Generic;

namespace FantaF1.Action.Interfaces
{
    public interface IRisultatoPronosticoAction
    {
        void CreateAndSaveRisultatoPronostico(IEnumerable<PronosticoUtenteGara> pronosticiGara,
            RisultatoGaraReale risultatoGara, RegoleFantaCampionato regolamentoFantaCampionato,
            RisultatoDFNGaraReale risultatoDfnGara);
        RisultatoPronostico GetRisultatoPronosticoFromIdPronosticoUtente(int idPronosticoUtente);
    }
}
