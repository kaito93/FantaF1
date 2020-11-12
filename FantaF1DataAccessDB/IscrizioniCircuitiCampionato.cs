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
    
    public partial class IscrizioniCircuitiCampionato
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public IscrizioniCircuitiCampionato()
        {
            this.PronosticoUtenteGara = new HashSet<PronosticoUtenteGara>();
            this.PronosticoUtenteGara1 = new HashSet<PronosticoUtenteGara>();
        }
    
        public int Id { get; set; }
        public int CircuitoId { get; set; }
        public int CampionatoId { get; set; }
        public Nullable<int> RisultatiId { get; set; }
        public System.DateTime DataGara { get; set; }
        public string NomeGP { get; set; }
    
        public virtual CampionatiMondiali CampionatiMondiali { get; set; }
        public virtual Circuiti Circuiti { get; set; }
        public virtual RisultatoGaraReale RisultatoGaraReale { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PronosticoUtenteGara> PronosticoUtenteGara { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PronosticoUtenteGara> PronosticoUtenteGara1 { get; set; }
    }
}
