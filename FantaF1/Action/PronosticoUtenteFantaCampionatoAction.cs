using FantaF1.Action.Interfaces;
using FantaF1.Models;
using FantaF1DataAccessDB;
using System.Collections.Generic;
using System.Linq;

namespace FantaF1.Action
{
    public class PronosticoUtenteFantaCampionatoAction : IPronosticoUtenteFantaCampionatoAction
    {
        private List<PronosticoUtenteFantaCampionato> _pronosticiUtentiFantaCampionato;
        private readonly IDatabaseAction _databaseAction;
        public PronosticoUtenteFantaCampionatoAction(IDatabaseAction databaseAction)
        {
            _databaseAction = databaseAction;
            _pronosticiUtentiFantaCampionato = databaseAction.GetPronosticiUtenteFantaCampionato();
        }
        public int SavePronosticoFantaCampionatoInDatabase(RegistrazioneUtenteStructure registrazione, List<Piloti> pilotiList, List<Scuderie> scuderieList)
        {
            var pronosticoDb = new PronosticoUtenteFantaCampionato
            {
                PrimoClassificatoPilotaId = GetPilotaIdFromNameAndSurname(registrazione.PrimoCognomePilota, pilotiList),
                SecondoClassificatoPilotaId = GetPilotaIdFromNameAndSurname(registrazione.SecondoCognomePilota, pilotiList),
                TerzoClassificatoPilotaId = GetPilotaIdFromNameAndSurname(registrazione.TerzoCognomePilota, pilotiList),
                QuartoClassificatoPilotaId = GetPilotaIdFromNameAndSurname(registrazione.QuartoCognomePilota, pilotiList),
                QuintoClassificatoPilotaId = GetPilotaIdFromNameAndSurname(registrazione.QuintoCognomePilota, pilotiList),
                SestoClassificatoPilotaId = GetPilotaIdFromNameAndSurname(registrazione.SestoCognomePilota, pilotiList),
                SettimoClassificatoPilotaId = GetPilotaIdFromNameAndSurname(registrazione.SettimoCognomePilota, pilotiList),
                OttavoClassificatoPilotaId = GetPilotaIdFromNameAndSurname(registrazione.OttavoCognomePilota, pilotiList),
                NonoClassificatoPilotaId = GetPilotaIdFromNameAndSurname(registrazione.NonoCognomePilota, pilotiList),
                DecimoClassificatoPilotaId = GetPilotaIdFromNameAndSurname(registrazione.DecimoCognomePilota, pilotiList),
                PrimaClassificataScuderiaId = GetScuderiaIdFromName(registrazione.PrimoNomeScuderia, scuderieList),
                SecondaClassificataScuderiaId = GetScuderiaIdFromName(registrazione.SecondoNomeScuderia, scuderieList),
                TerzaClassificataScuderiaId = GetScuderiaIdFromName(registrazione.TerzoNomeScuderia, scuderieList),
                QuartaClassificataScuderiaId = GetScuderiaIdFromName(registrazione.QuartoNomeScuderia, scuderieList),
                QuintaClassificataScuderiaId = GetScuderiaIdFromName(registrazione.QuintoNomeScuderia, scuderieList),
                SestaClassificataScuderiaId = GetScuderiaIdFromName(registrazione.SestoNomeScuderia, scuderieList),
                SettimaClassificataScuderiaId = GetScuderiaIdFromName(registrazione.SettimoNomeScuderia, scuderieList),
                OttavaClassificataScuderiaId = GetScuderiaIdFromName(registrazione.OttavoNomeScuderia, scuderieList),
                NonaClassificataScuderiaId = GetScuderiaIdFromName(registrazione.NonoNomeScuderia, scuderieList),
                DecimaClassificataScuderiaId = GetScuderiaIdFromName(registrazione.DecimoNomeScuderia, scuderieList),
            };

            _pronosticiUtentiFantaCampionato = _databaseAction.SavePronosticoUtenteFantaCampionato(pronosticoDb);

            return _pronosticiUtentiFantaCampionato.Last().Id;

        }

        public PronosticoUtenteFantaCampionato GetPronosticoUtenteFantaCampionatoFromIdPronostico(int idPronostico)
        {
            return _pronosticiUtentiFantaCampionato.FirstOrDefault(x => x.Id == idPronostico);
        }

        public List<PronosticoUtenteFantaCampionato> GetAllPronostici()
        {
            return new List<PronosticoUtenteFantaCampionato>(_pronosticiUtentiFantaCampionato);
        }

        private static int GetPilotaIdFromNameAndSurname(string nameSurname, List<Piloti> piloti)
        {
            var result = piloti.FirstOrDefault(x => nameSurname.ToLower().Contains(x.Cognome.ToLower()));

            if (result != null)
                return result.Id;

            return -1;
        }

        private static int GetScuderiaIdFromName(string name, List<Scuderie> scuderie)
        {
            var result = scuderie.FirstOrDefault(x => x.Nome.ToLower().Contains(name.ToLower()));

            if (result != null)
                return result.Id;

            return -1;
        }
    }
}