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
    
    public partial class Scuderie
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Scuderie()
        {
            this.IscrizioniScuderieCampionato = new HashSet<IscrizioniScuderieCampionato>();
            this.PronosticoUtenteFantaCampionato = new HashSet<PronosticoUtenteFantaCampionato>();
            this.PronosticoUtenteFantaCampionato1 = new HashSet<PronosticoUtenteFantaCampionato>();
            this.PronosticoUtenteFantaCampionato2 = new HashSet<PronosticoUtenteFantaCampionato>();
            this.PronosticoUtenteFantaCampionato3 = new HashSet<PronosticoUtenteFantaCampionato>();
            this.PronosticoUtenteFantaCampionato4 = new HashSet<PronosticoUtenteFantaCampionato>();
            this.PronosticoUtenteFantaCampionato5 = new HashSet<PronosticoUtenteFantaCampionato>();
            this.PronosticoUtenteFantaCampionato6 = new HashSet<PronosticoUtenteFantaCampionato>();
            this.PronosticoUtenteFantaCampionato7 = new HashSet<PronosticoUtenteFantaCampionato>();
            this.PronosticoUtenteFantaCampionato8 = new HashSet<PronosticoUtenteFantaCampionato>();
            this.PronosticoUtenteFantaCampionato9 = new HashSet<PronosticoUtenteFantaCampionato>();
            this.IscrizioniPilotiScuderie = new HashSet<IscrizioniPilotiScuderie>();
        }
    
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Nazionalita { get; set; }
        public string NomeCorto { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IscrizioniScuderieCampionato> IscrizioniScuderieCampionato { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PronosticoUtenteFantaCampionato> PronosticoUtenteFantaCampionato { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PronosticoUtenteFantaCampionato> PronosticoUtenteFantaCampionato1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PronosticoUtenteFantaCampionato> PronosticoUtenteFantaCampionato2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PronosticoUtenteFantaCampionato> PronosticoUtenteFantaCampionato3 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PronosticoUtenteFantaCampionato> PronosticoUtenteFantaCampionato4 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PronosticoUtenteFantaCampionato> PronosticoUtenteFantaCampionato5 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PronosticoUtenteFantaCampionato> PronosticoUtenteFantaCampionato6 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PronosticoUtenteFantaCampionato> PronosticoUtenteFantaCampionato7 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PronosticoUtenteFantaCampionato> PronosticoUtenteFantaCampionato8 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PronosticoUtenteFantaCampionato> PronosticoUtenteFantaCampionato9 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IscrizioniPilotiScuderie> IscrizioniPilotiScuderie { get; set; }
    }
}
