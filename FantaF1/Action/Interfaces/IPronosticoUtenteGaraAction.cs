using FantaF1.Models;
using FantaF1DataAccessDB;
using System.Collections.Generic;

namespace FantaF1.Action.Interfaces
{
    public interface IPronosticoUtenteGaraAction
    {
        void SavePronosticiInDatabase(IEnumerable<PronosticoStructure> pronosticiList, int garaId, int fantaCampionatoId, List<Piloti> pilotiList, List<Utenti> utentiList, bool hasSprintRace);
        List<PronosticoUtenteGara> GetPronosticoUtenteGaraFromFantaCampionatoIdAndCircuitoId(int fantaCampionatoId, int circuitoId);
        IEnumerable<PronosticoStructure> LoadPronosticiFromFileCsv(FileInformation fileCsv, bool sprintRace);
        List<PronosticoUtenteGara> GetAllPronostici();
    }
}
