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
    
    public partial class RegoleCampionatoMondiale
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RegoleCampionatoMondiale()
        {
            this.CampionatiMondiali = new HashSet<CampionatiMondiali>();
        }
    
        public int Id { get; set; }
        public int PunteggioPrimoClassificato { get; set; }
        public int PunteggioSecondoClassificato { get; set; }
        public int PunteggioTerzoClassificato { get; set; }
        public int PunteggioQuartoClassificato { get; set; }
        public int PunteggioQuintoClassificato { get; set; }
        public int PunteggioSestoClassificato { get; set; }
        public int PunteggioSettimoClassificato { get; set; }
        public int PunteggioOttavoClassificato { get; set; }
        public int PunteggioNonoClassificato { get; set; }
        public int PunteggioDecimoClassificato { get; set; }
        public int PunteggioUndicesimoClassificato { get; set; }
        public int PunteggioDodicesimoClassificato { get; set; }
        public int PunteggioTredicesimoClassificato { get; set; }
        public int PunteggioQuattordicesimoClassificato { get; set; }
        public int PunteggioQuindicesimoClassificato { get; set; }
        public int PunteggioSedicesimoClassificato { get; set; }
        public int PunteggioDiciassettesimoClassificato { get; set; }
        public int PunteggioDiciottesimoClassificato { get; set; }
        public int PunteggioDiciannovesimoClassificato { get; set; }
        public int PunteggioVentesimoClassificato { get; set; }
        public int PunteggioGiroVeloce { get; set; }
        public int PunteggioPolePosition { get; set; }
        public int PunteggioPrimoSprintRace { get; set; }
        public int PunteggioSecondoSprintRace { get; set; }
        public int PunteggioTerzoSprintRace { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CampionatiMondiali> CampionatiMondiali { get; set; }
    }
}
