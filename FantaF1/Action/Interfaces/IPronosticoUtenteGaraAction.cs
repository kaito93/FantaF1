using FantaF1.Models;
using FantaF1DataAccessDB;
using System.Collections.Generic;

namespace FantaF1.Action.Interfaces
{
    public interface IPronosticoUtenteGaraAction
    {
        void SavePronosticiInDatabase(IEnumerable<PronosticoStructure> pronosticiList, int circuitoId, int fantaCampionatoId, List<Piloti> pilotiList, List<Utenti> utentiList);
        List<PronosticoUtenteGara> GetPronosticoUtenteGaraFromFantaCampionatoIdAndCircuitoId(int fantaCampionatoId, int circuitoId);
        IEnumerable<PronosticoStructure> LoadPronosticiFromFileCsv(FileInformation fileCsv);
        List<PronosticoUtenteGara> GetAllPronostici();
    }
}
