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
    
    public partial class RisultatoGaraReale
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RisultatoGaraReale()
        {
            this.IscrizioniCircuitiCampionato = new HashSet<IscrizioniCircuitiCampionato>();
        }
    
        public int Id { get; set; }
        public int PilotaId01 { get; set; }
        public Nullable<int> PilotaId02 { get; set; }
        public Nullable<int> PilotaId03 { get; set; }
        public Nullable<int> PilotaId04 { get; set; }
        public Nullable<int> PilotaId05 { get; set; }
        public Nullable<int> PilotaId06 { get; set; }
        public Nullable<int> PilotaId07 { get; set; }
        public Nullable<int> PilotaId08 { get; set; }
        public Nullable<int> PilotaId09 { get; set; }
        public Nullable<int> PilotaId10 { get; set; }
        public Nullable<int> PilotaId11 { get; set; }
        public Nullable<int> PilotaId12 { get; set; }
        public Nullable<int> PilotaId13 { get; set; }
        public Nullable<int> PilotaId14 { get; set; }
        public Nullable<int> PilotaId15 { get; set; }
        public Nullable<int> PilotaId16 { get; set; }
        public Nullable<int> PilotaId17 { get; set; }
        public Nullable<int> PilotaId18 { get; set; }
        public Nullable<int> PilotaId19 { get; set; }
        public Nullable<int> PilotaId20 { get; set; }
        public Nullable<int> PilotaIdGiroVeloce { get; set; }
        public Nullable<int> PilotaIdPolePosition { get; set; }
        public int RisultatoDFNId { get; set; }
        public Nullable<int> PilotaId01SprintRace { get; set; }
        public Nullable<int> PilotaId02SprintRace { get; set; }
        public Nullable<int> PilotaId03SprintRace { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IscrizioniCircuitiCampionato> IscrizioniCircuitiCampionato { get; set; }
        public virtual Piloti Piloti { get; set; }
        public virtual Piloti Piloti1 { get; set; }
        public virtual Piloti Piloti2 { get; set; }
        public virtual Piloti Piloti3 { get; set; }
        public virtual Piloti Piloti4 { get; set; }
        public virtual Piloti Piloti5 { get; set; }
        public virtual Piloti Piloti6 { get; set; }
        public virtual Piloti Piloti7 { get; set; }
        public virtual Piloti Piloti8 { get; set; }
        public virtual Piloti Piloti9 { get; set; }
        public virtual Piloti Piloti10 { get; set; }
        public virtual Piloti Piloti11 { get; set; }
        public virtual Piloti Piloti12 { get; set; }
        public virtual Piloti Piloti13 { get; set; }
        public virtual Piloti Piloti14 { get; set; }
        public virtual Piloti Piloti15 { get; set; }
        public virtual Piloti Piloti16 { get; set; }
        public virtual Piloti Piloti17 { get; set; }
        public virtual Piloti Piloti18 { get; set; }
        public virtual Piloti Piloti19 { get; set; }
        public virtual Piloti Piloti20 { get; set; }
        public virtual Piloti Piloti21 { get; set; }
        public virtual RisultatoDFNGaraReale RisultatoDFNGaraReale { get; set; }
        public virtual Piloti Piloti22 { get; set; }
        public virtual Piloti Piloti23 { get; set; }
        public virtual Piloti Piloti24 { get; set; }
    }
}
