﻿using FantaF1DataAccessDB;
using System.Collections.Generic;

namespace FantaF1.Action.Interfaces
{
    public interface IIscrizioniScuderieCampionatoAction
    {
        void UpdatePunteggioScuderie(int idCampionatoReale, List<IscrizioniPilotiCampionato> iscrizioniPilotiCampionato,
            List<Scuderie> scuderieList, List<IscrizioniPilotiScuderie> iscrizioniPilotiScuderieYear,
            List<IscrizioniPilotiScuderie> iscrizioniPilotiScuderieGara);

        List<IscrizioniScuderieCampionato> GetClassificaScuderieFromCampionatoId(int idCampionato);
    }
}
