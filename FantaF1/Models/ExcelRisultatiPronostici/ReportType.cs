using System;
using System.Collections.Generic;
using System.IO;
using NPOI.SS.UserModel;

namespace FantaF1.Models.ExcelRisultatiPronostici
{
    public class HeaderReport
    {
        public string Title { get; set; }
        public string ListDescription { get; set; }
    }

    public class NpoiColumnExcel
    {
        public string Text { get; set; }
        public int ColumnWidth { get; set; }
        public ICellStyle[] Style { get; set; }
        public HorizontalAlignment TextAlign { get; set; }
        public string NumberFormat { get; set; }

        public virtual void SetValue(ICell cell, string text)
        {
            cell.SetCellValue(text);
        }
    }

    public class NpoiColumnExcelDouble : NpoiColumnExcel
    {
        public override void SetValue(ICell cell, string text)
        {
            double value;
            double.TryParse(text, out value);

            cell.SetCellValue(value);
        }
    }

    public class NpoiColumnExcelDateTime : NpoiColumnExcel
    {
        public override void SetValue(ICell cell, string text)
        {
            DateTime value;
            DateTime.TryParse(text, out value);

            cell.SetCellValue(value);
        }
    }

    public class NpoiMemoryStream : MemoryStream
    {
        public NpoiMemoryStream()
        {
            AllowClose = true;
        }

        public bool AllowClose { get; set; }

        public override void Close()
        {
            if (AllowClose)
                base.Close();
        }
    }
}
