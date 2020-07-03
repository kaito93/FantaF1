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
    
    public partial class CampionatiMondiali
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CampionatiMondiali()
        {
            this.FantaCampionati = new HashSet<FantaCampionati>();
            this.IscrizioniScuderieCampionato = new HashSet<IscrizioniScuderieCampionato>();
            this.IscrizioniCircuitiCampionato = new HashSet<IscrizioniCircuitiCampionato>();
            this.IscrizioniPilotiCampionato = new HashSet<IscrizioniPilotiCampionato>();
        }
    
        public int Id { get; set; }
        public string Anno { get; set; }
        public string Categoria { get; set; }
        public int RegoleId { get; set; }
    
        public virtual RegoleCampionatoMondiale RegoleCampionatoMondiale { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FantaCampionati> FantaCampionati { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IscrizioniScuderieCampionato> IscrizioniScuderieCampionato { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IscrizioniCircuitiCampionato> IscrizioniCircuitiCampionato { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IscrizioniPilotiCampionato> IscrizioniPilotiCampionato { get; set; }
    }
}