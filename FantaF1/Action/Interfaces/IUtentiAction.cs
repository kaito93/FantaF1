using FantaF1.Models;
using FantaF1DataAccessDB;
using System.Collections.Generic;

namespace FantaF1.Action.Interfaces
{
    public interface IUtentiAction
    {
        int SaveUtenteInDatabase(RegistrazioneUtenteStructure registrazione);
        int GetUtenteIdFromNameAndSurname(string name, string surname);
        List<Utenti> GetUtentiList();

        Utenti GetUtenteFromId(int idUtente);
    }
}
