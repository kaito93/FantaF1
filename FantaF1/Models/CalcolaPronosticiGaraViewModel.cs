using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FantaF1.Models
{
    public class CalcolaPronosticiGaraViewModel
    {
        public List<SelectListItem> FantaCampionatiList { get; set; }
        public List<SelectListItem> CircuitiList { get; set; }
    }
}