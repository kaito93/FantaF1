//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FantaF1DataAccessDB
{
    using System;
    using System.Collections.Generic;
    
    public partial class IscrizioniPilotiCampionato
    {
        public int Id { get; set; }
        public int PilotaId { get; set; }
        public int CampionatoId { get; set; }
        public int Punteggio { get; set; }
    
        public virtual CampionatiMondiali CampionatiMondiali { get; set; }
        public virtual Piloti Piloti { get; set; }
    }
}
