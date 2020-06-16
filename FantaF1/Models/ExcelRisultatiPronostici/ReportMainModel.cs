using System.Collections.Generic;
using System.Data;

namespace FantaF1.Models.ExcelRisultatiPronostici
{
    public class ReportMainModel
    {
        public class ReportGenericModel
        {
            public DataTable Table { get; set; }
            public string ReportName { get; set; }
            public string ReportTitle { get; set; }
            public List<NpoiColumnExcel> AssetsColumn { get; set; }
        }
    }
}