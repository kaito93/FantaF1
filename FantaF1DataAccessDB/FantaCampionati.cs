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
    
    public partial class FantaCampionati
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FantaCampionati()
        {
            this.PronosticoUtenteGara = new HashSet<PronosticoUtenteGara>();
        }
    
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Anno { get; set; }
        public int CampionatoRealeId { get; set; }
        public int RegoleId { get; set; }
        public System.DateTime DataTerminePronostici { get; set; }
    
        public virtual CampionatiMondiali CampionatiMondiali { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PronosticoUtenteGara> PronosticoUtenteGara { get; set; }
    }
}
