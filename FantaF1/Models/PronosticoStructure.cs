using System;

namespace FantaF1.Models
{
    public class PronosticoStructure
    {
        public string IdUtente { get; set; }
        public string PilotaPrimoClassificato { get; set; }
        public string PilotaSecondoClassificato { get; set; }
        public string PilotaTerzoClassificato { get; set; }
        public string PilotaGiroVeloce { get; set; }
        public string PilotaPolePosition { get; set; }
        public string PilotaDfn { get; set; }
        public DateTime InserimentoPronostico { get; set; }

    }
}