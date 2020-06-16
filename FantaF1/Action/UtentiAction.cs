using FantaF1.Action.Interfaces;
using FantaF1.Models;
using FantaF1DataAccessDB;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FantaF1.Action
{
    public class UtentiAction : IUtentiAction
    {
        private List<Utenti> _utenti;
        private readonly IDatabaseAction _databaseAction;
        public UtentiAction(IDatabaseAction databaseAction)
        {
            _databaseAction = databaseAction;
            _utenti = databaseAction.GetUtenti();
        }
        public int SaveUtenteInDatabase(RegistrazioneUtenteStructure registrazione)
        {
            var utenteDb = new Utenti
            {
                Cognome = registrazione.Cognome,
                Nome = registrazione.Nome,
                Data_Registrazione = DateTime.Today
            };

            var alreadyExist = _utenti.FirstOrDefault(x => x.Cognome == registrazione.Cognome && x.Nome == registrazione.Nome);

            if (alreadyExist != null) return -1;

            _utenti = _databaseAction.SaveUtente(utenteDb);
            return _utenti.Last().Id;

        }
        public int GetUtenteIdFromNameAndSurname(string name, string surname)
        {
            var result = _utenti.FirstOrDefault(x =>
                x.Nome.ToLower() == name.ToLower() && x.Cognome.ToLower() == surname.ToLower());

            if (result != null)
                return result.Id;

            return -1;
        }

        public List<Utenti> GetUtentiList()
        {
            return new List<Utenti>(_utenti);
        }

        public Utenti GetUtenteFromId(int idUtente)
        {
            return _utenti.FirstOrDefault(x => x.Id == idUtente);
        }
    }
}