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
    
    public partial class IscrizioniScuderieCampionato
    {
        public int Id { get; set; }
        public int ScuderiaId { get; set; }
        public int CampionatoId { get; set; }
        public int Punteggio { get; set; }
    
        public virtual CampionatiMondiali CampionatiMondiali { get; set; }
        public virtual Scuderie Scuderie { get; set; }
    }
}