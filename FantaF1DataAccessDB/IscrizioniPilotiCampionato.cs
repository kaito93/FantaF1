//------------------------------------------------------------------------------
// <auto-generated>
//     Codice generato da un modello.
//
//     Le modifiche manuali a questo file potrebbero causare un comportamento imprevisto dell'applicazione.
//     Se il codice viene rigenerato, le modifiche manuali al file verranno sovrascritte.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FantaF1DataAccessDB
{
    using System;
    using System.Collections.Generic;
    
    public partial class IscrizioniPilotiCampionato
    {
        public int Id { get; set; }
        public int CampionatoId { get; set; }
        public int Punteggio { get; set; }
        public int IscrizionePilotaScuderiaId { get; set; }
    
        public virtual CampionatiMondiali CampionatiMondiali { get; set; }
        public virtual IscrizioniPilotiScuderie IscrizioniPilotiScuderie { get; set; }
    }
}
