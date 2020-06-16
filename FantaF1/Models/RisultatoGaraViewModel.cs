using System.Collections.Generic;
using System.Web.Mvc;

namespace FantaF1.Models
{
    public class RisultatoGaraViewModel
    {
        public IEnumerable<SelectListItem> Piloti { get; set; }
        public IEnumerable<SelectListItem> Circuiti { get; set; }
        public IEnumerable<SelectListItem> Campionato { get; set; }

    }
}