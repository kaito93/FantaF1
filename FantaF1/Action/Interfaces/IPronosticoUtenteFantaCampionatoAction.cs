using FantaF1.Models;
using FantaF1DataAccessDB;
using System.Collections.Generic;

namespace FantaF1.Action.Interfaces
{
    public interface IPronosticoUtenteFantaCampionatoAction
    {
        int SavePronosticoFantaCampionatoInDatabase(RegistrazioneUtenteStructure registrazione, List<Piloti> pilotiList, List<Scuderie> scuderieList);
        PronosticoUtenteFantaCampionato GetPronosticoUtenteFantaCampionatoFromIdPronostico(int idPronostico);
        List<PronosticoUtenteFantaCampionato> GetAllPronostici();
    }
}
