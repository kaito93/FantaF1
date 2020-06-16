using FantaF1DataAccessDB;
using System.Collections.Generic;
using FantaF1.Models;

namespace FantaF1.Action.Interfaces
{
    public interface IIscrizioniPilotiCampionatoAction
    {
        void UpdatePunteggioPiloti(RegoleCampionatoMondiale regoleCampionato, IEnumerable<RaceResultObj> resultRace,
            int idCampionatoReale);

        List<IscrizioniPilotiCampionato> GetAllIscrizioniPilotiCampionatoForCampionatoMondialeId(int campionatoId);
        List<IscrizioniPilotiCampionato> GetClassificaPilotiFromIdCampionato(int idCampionato);
    }
}
