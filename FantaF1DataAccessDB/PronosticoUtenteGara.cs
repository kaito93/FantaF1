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
    
    public partial class PronosticoUtenteGara
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PronosticoUtenteGara()
        {
            this.RisultatoPronostico = new HashSet<RisultatoPronostico>();
        }
    
        public int Id { get; set; }
        public int UtenteId { get; set; }
        public int FantaCampionatoId { get; set; }
        public int PrimoClassificatoPilotaId { get; set; }
        public int SecondoClassificatoPilotaId { get; set; }
        public int TerzoClassificatoPilotaId { get; set; }
        public int PolePositionPilotaId { get; set; }
        public int GiroVelocePilotaId { get; set; }
        public int DFNPilotaId { get; set; }
        public System.DateTime Inserimento { get; set; }
        public int GaraId { get; set; }
    
        public virtual FantaCampionati FantaCampionati { get; set; }
        public virtual IscrizioniCircuitiCampionato IscrizioniCircuitiCampionato { get; set; }
        public virtual Piloti Piloti { get; set; }
        public virtual Piloti Piloti1 { get; set; }
        public virtual Piloti Piloti2 { get; set; }
        public virtual Piloti Piloti3 { get; set; }
        public virtual Piloti Piloti4 { get; set; }
        public virtual Piloti Piloti5 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RisultatoPronostico> RisultatoPronostico { get; set; }
        public virtual Utenti Utenti { get; set; }
        public virtual IscrizioniCircuitiCampionato IscrizioniCircuitiCampionato1 { get; set; }
    }
}
