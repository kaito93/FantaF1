using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using FantaF1.Models.ExcelRisultatiPronostici;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace FantaF1.Action.ReportAction
{
    public class ReportUtils
    {
        private delegate void FontColorHandler(IWorkbook workbook, IFont font, byte r, byte g, byte b);
        private delegate void FillForegroundColorHandler(IWorkbook workbook, ICellStyle font, byte r, byte g, byte b);

        private readonly Func<IWorkbook> _createWorkbook;
        private readonly Func<IWorkbook, IFont> _createFont;
        private readonly FillForegroundColorHandler _setFillForegroundColor;
        private readonly FontColorHandler _setColor;

        public ReportUtils(bool isXls)
        {
            if (isXls)
            {
                HSSFPalette palette = null;

                _createWorkbook = () =>
                {
                    var oWorkbook = new HSSFWorkbook();

                    palette = oWorkbook.GetCustomPalette();
                    palette.SetColorAtIndex(12, 51, 51, 153);
                    palette.SetColorAtIndex(12, 51, 102, 255);
                    palette.SetColorAtIndex(9, 255, 255, 255);
                    palette.SetColorAtIndex(8, 0, 0, 0);
                    palette.SetColorAtIndex(22, 245, 245, 245);

                    return oWorkbook;
                };
                _createFont = oWorkbook => (HSSFFont)oWorkbook.CreateFont();
                _setFillForegroundColor = (workbook, style, r, g, b) =>
                {
                    ((HSSFCellStyle)style).FillForegroundColor = palette.FindColor(r, g, b).Indexed;
                };
                _setColor = (workbook, font, r, g, b) =>
                {
                    ((HSSFFont)font).Color = palette.FindColor(r, g, b).Indexed;
                };
            }
            else
            {
                _createWorkbook = () => new XSSFWorkbook();
                _createFont = oWorkbook => (XSSFFont)oWorkbook.CreateFont();
                _setFillForegroundColor = (workbook, style, r, g, b) =>
                {
                    ((XSSFCellStyle)style).FillForegroundXSSFColor = new XSSFColor(new[] { r, g, b });
                };
                _setColor = (workbook, font, r, g, b) =>
                {
                    ((XSSFFont)font).SetColor(new XSSFColor(new[] { r, g, b }));
                };
            }
        }

        public IWorkbook CreateWorkbook()
        {
            return _createWorkbook();
        }

        #region Create Sheets

        public void CreateFirstSheet(IWorkbook oWorkbook, DataTable dataTable, List<NpoiColumnExcel> columnsTable, HeaderReport header)
        {
            var oSheet = oWorkbook.CreateSheet("Utenti iscritti");

            //CreateRowsColumns(oSheet, 0, 3, 0, 5);
            //CreateHeader1(oWorkbook, oSheet.GetRow(0).GetCell(0), header.Title);
            //var cellRange = new CellRangeAddress(0, 2, 0, 4);
            //oSheet.AddMergedRegion(cellRange);

            // Tipo elenco + data
            //CreateRowsColumns(oSheet, 3, 6, 0, 5);
            //CreateHeader2(oWorkbook, oSheet.GetRow(3).GetCell(0), header.ListDescription);
            //cellRange = new CellRangeAddress(3, 5, 0, 4);
            //oSheet.AddMergedRegion(cellRange);

            // Filtri di ricerca Usati
            //CreateRowsColumns(oSheet, 6, 8, 0, 2);
            //CreateHeader3(oWorkbook, oSheet.GetRow(6).GetCell(0));
            //cellRange = new CellRangeAddress(6, 7, 0, 1);
            //oSheet.AddMergedRegion(cellRange);

            // Colonne
            CreateRowHeader(oWorkbook, oSheet, 3, columnsTable, dataTable);

            // Tabella
            var lastRow = 4; //+ header.FilterUsedDescription.Count;

            for (var rowIndex = 0; rowIndex < dataTable.Rows.Count; rowIndex++)
            {
                var row = oSheet.CreateRow(lastRow + rowIndex);
                var opt = rowIndex % 2 == 0 ? 0 : 1;

                for (var colIndex = 0; colIndex < dataTable.Columns.Count; colIndex++)
                {
                    if (columnsTable == null)
                        continue;

                    var column = columnsTable.ToList().FirstOrDefault(x =>
                        x.Text.ToLower() == dataTable.Columns[colIndex].ColumnName.Replace('_', ' ').ToLower());

                    var cell = row.CreateCell(colIndex);

                    if (column == null)
                        continue;

                    column.SetValue(cell,
                        dataTable.Rows[rowIndex].ItemArray[colIndex].ToString() == "-"
                            ? "-"
                            : dataTable.Rows[rowIndex].ItemArray[colIndex].ToString());

                    cell.CellStyle = column.Style[opt];
                }
            }

        }

        public void CreateSecondSheet(IWorkbook oWorkbook, DataTable dataTable, List<NpoiColumnExcel> columnsTable, HeaderReport header)
        {
            var oSheet = oWorkbook.CreateSheet("Pronostici");

            //CreateRowsColumns(oSheet, 0, 3, 0, 5);
            //CreateHeader1(oWorkbook, oSheet.GetRow(0).GetCell(0), header.Title);
            //var cellRange = new CellRangeAddress(0, 2, 0, 4);
            //oSheet.AddMergedRegion(cellRange);

            //// Tipo elenco + data
            //CreateRowsColumns(oSheet, 3, 6, 0, 5);
            //CreateHeader2(oWorkbook, oSheet.GetRow(3).GetCell(0), header.ListDescription);
            //cellRange = new CellRangeAddress(3, 5, 0, 4);
            //oSheet.AddMergedRegion(cellRange);

            //// Filtri di ricerca Usati
            //CreateRowsColumns(oSheet, 6, 8, 0, 2);
            //CreateHeader3(oWorkbook, oSheet.GetRow(6).GetCell(0));
            //cellRange = new CellRangeAddress(6, 7, 0, 1);
            //oSheet.AddMergedRegion(cellRange);

            // Colonne
            CreateRowHeader(oWorkbook, oSheet, 3, columnsTable, dataTable);

            // Tabella
            var lastRow = 4; //+ header.FilterUsedDescription.Count;

            for (var rowIndex = 0; rowIndex < dataTable.Rows.Count; rowIndex++)
            {
                var row = oSheet.CreateRow(lastRow + rowIndex);

                //row.HeightInPoints = 200;

                var opt = rowIndex % 2 == 0 ? 0 : 1;

                for (var colIndex = 0; colIndex < dataTable.Columns.Count; colIndex++)
                {
                    if (columnsTable == null)
                        continue;

                    var column = columnsTable.ToList().FirstOrDefault(x =>
                        x.Text.ToLower() == dataTable.Columns[colIndex].ColumnName.Replace('_', ' ').ToLower());

                    var cell = row.CreateCell(colIndex);

                    if (column == null)
                        continue;

                    column.SetValue(cell,
                        dataTable.Rows[rowIndex].ItemArray[colIndex].ToString() == "-"
                            ? "-"
                            : dataTable.Rows[rowIndex].ItemArray[colIndex].ToString());

                    column.Style[opt].WrapText = true;

                    cell.CellStyle = column.Style[opt];
                }
            }

        }

        public void CreateThirdSheet(IWorkbook oWorkbook, DataTable dataTable, List<NpoiColumnExcel> columnsTable, HeaderReport header)
        {
            var oSheet = oWorkbook.CreateSheet("Storico");

            //CreateRowsColumns(oSheet, 0, 3, 0, 5);
            //CreateHeader1(oWorkbook, oSheet.GetRow(0).GetCell(0), header.Title);
            //var cellRange = new CellRangeAddress(0, 2, 0, 4);
            //oSheet.AddMergedRegion(cellRange);

            //// Tipo elenco + data
            //CreateRowsColumns(oSheet, 3, 6, 0, 5);
            //CreateHeader2(oWorkbook, oSheet.GetRow(3).GetCell(0), header.ListDescription);
            //cellRange = new CellRangeAddress(3, 5, 0, 4);
            //oSheet.AddMergedRegion(cellRange);

            //// Filtri di ricerca Usati
            //CreateRowsColumns(oSheet, 6, 8, 0, 2);
            //CreateHeader3(oWorkbook, oSheet.GetRow(6).GetCell(0));
            //cellRange = new CellRangeAddress(6, 7, 0, 1);
            //oSheet.AddMergedRegion(cellRange);

            // Colonne
            CreateRowHeader(oWorkbook, oSheet, 3, columnsTable, dataTable);

            // Tabella
            var lastRow = 4; //+ header.FilterUsedDescription.Count;

            for (var rowIndex = 0; rowIndex < dataTable.Rows.Count; rowIndex++)
            {
                var row = oSheet.CreateRow(lastRow + rowIndex);

                //row.HeightInPoints = 200;

                var opt = rowIndex % 2 == 0 ? 0 : 1;

                for (var colIndex = 0; colIndex < dataTable.Columns.Count; colIndex++)
                {
                    if (columnsTable == null)
                        continue;

                    var column = columnsTable.ToList().FirstOrDefault(x =>
                        x.Text.ToLower() == dataTable.Columns[colIndex].ColumnName.Replace('_', ' ').ToLower());

                    var cell = row.CreateCell(colIndex);

                    if (column == null)
                        continue;

                    column.SetValue(cell,
                        dataTable.Rows[rowIndex].ItemArray[colIndex].ToString() == "-"
                            ? "-"
                            : dataTable.Rows[rowIndex].ItemArray[colIndex].ToString());

                    column.Style[opt].WrapText = true;

                    cell.CellStyle = column.Style[opt];
                }
            }

        }

        public void CreateFourthSheet(IWorkbook oWorkbook, DataTable dataTable, List<NpoiColumnExcel> columnsTable, HeaderReport header)
        {
            var oSheet = oWorkbook.CreateSheet("Classifica");

            //CreateRowsColumns(oSheet, 0, 3, 0, 5);
            //CreateHeader1(oWorkbook, oSheet.GetRow(0).GetCell(0), header.Title);
            //var cellRange = new CellRangeAddress(0, 2, 0, 4);
            //oSheet.AddMergedRegion(cellRange);

            //// Tipo elenco + data
            //CreateRowsColumns(oSheet, 3, 6, 0, 5);
            //CreateHeader2(oWorkbook, oSheet.GetRow(3).GetCell(0), header.ListDescription);
            //cellRange = new CellRangeAddress(3, 5, 0, 4);
            //oSheet.AddMergedRegion(cellRange);

            //// Filtri di ricerca Usati
            //CreateRowsColumns(oSheet, 6, 8, 0, 2);
            //CreateHeader3(oWorkbook, oSheet.GetRow(6).GetCell(0));
            //cellRange = new CellRangeAddress(6, 7, 0, 1);
            //oSheet.AddMergedRegion(cellRange);

            // Colonne
            CreateRowHeader(oWorkbook, oSheet, 3, columnsTable, dataTable);

            // Tabella
            var lastRow = 4; //+ header.FilterUsedDescription.Count;

            for (var rowIndex = 0; rowIndex < dataTable.Rows.Count; rowIndex++)
            {
                var row = oSheet.CreateRow(lastRow + rowIndex);

                //row.HeightInPoints = 200;

                var opt = rowIndex % 2 == 0 ? 0 : 1;

                for (var colIndex = 0; colIndex < dataTable.Columns.Count; colIndex++)
                {
                    if (columnsTable == null)
                        continue;

                    var column = columnsTable.ToList().FirstOrDefault(x =>
                        x.Text.ToLower() == dataTable.Columns[colIndex].ColumnName.Replace('_', ' ').ToLower());

                    var cell = row.CreateCell(colIndex);

                    if (column == null)
                        continue;

                    column.SetValue(cell,
                        dataTable.Rows[rowIndex].ItemArray[colIndex].ToString() == "-"
                            ? "-"
                            : dataTable.Rows[rowIndex].ItemArray[colIndex].ToString());

                    column.Style[opt].WrapText = true;

                    cell.CellStyle = column.Style[opt];
                }
            }

        }

        public void CreateFifthSheet(IWorkbook oWorkbook, DataTable dataTable, List<NpoiColumnExcel> columnsTable, HeaderReport header)
        {
            var oSheet = oWorkbook.CreateSheet("Mondiale");

            //CreateRowsColumns(oSheet, 0, 3, 0, 5);
            //CreateHeader1(oWorkbook, oSheet.GetRow(0).GetCell(0), header.Title);
            //var cellRange = new CellRangeAddress(0, 2, 0, 4);
            //oSheet.AddMergedRegion(cellRange);

            //// Tipo elenco + data
            //CreateRowsColumns(oSheet, 3, 6, 0, 5);
            //CreateHeader2(oWorkbook, oSheet.GetRow(3).GetCell(0), header.ListDescription);
            //cellRange = new CellRangeAddress(3, 5, 0, 4);
            //oSheet.AddMergedRegion(cellRange);

            //// Filtri di ricerca Usati
            //CreateRowsColumns(oSheet, 6, 8, 0, 2);
            //CreateHeader3(oWorkbook, oSheet.GetRow(6).GetCell(0));
            //cellRange = new CellRangeAddress(6, 7, 0, 1);
            //oSheet.AddMergedRegion(cellRange);

            // Colonne
            CreateRowHeader(oWorkbook, oSheet, 3, columnsTable, dataTable);

            // Tabella
            var lastRow = 4; //+ header.FilterUsedDescription.Count;

            for (var rowIndex = 0; rowIndex < dataTable.Rows.Count; rowIndex++)
            {
                var row = oSheet.CreateRow(lastRow + rowIndex);

                //row.HeightInPoints = 200;

                var opt = rowIndex % 2 == 0 ? 0 : 1;

                for (var colIndex = 0; colIndex < dataTable.Columns.Count; colIndex++)
                {
                    if (columnsTable == null)
                        continue;

                    var column = columnsTable.ToList().FirstOrDefault(x =>
                        x.Text.ToLower() == dataTable.Columns[colIndex].ColumnName.Replace('_', ' ').ToLower());

                    var cell = row.CreateCell(colIndex);

                    if (column == null)
                        continue;

                    column.SetValue(cell,
                        dataTable.Rows[rowIndex].ItemArray[colIndex].ToString() == "-"
                            ? "-"
                            : dataTable.Rows[rowIndex].ItemArray[colIndex].ToString());

                    column.Style[opt].WrapText = true;

                    cell.CellStyle = column.Style[opt];
                }
            }

        }

        public void CreateSixthSheet(IWorkbook oWorkbook, DataTable dataTable, List<NpoiColumnExcel> columnsTable, HeaderReport header)
        {
            var oSheet = oWorkbook.CreateSheet("Super Classifica");

            //CreateRowsColumns(oSheet, 0, 3, 0, 5);
            //CreateHeader1(oWorkbook, oSheet.GetRow(0).GetCell(0), header.Title);
            //var cellRange = new CellRangeAddress(0, 2, 0, 4);
            //oSheet.AddMergedRegion(cellRange);

            //// Tipo elenco + data
            //CreateRowsColumns(oSheet, 3, 6, 0, 5);
            //CreateHeader2(oWorkbook, oSheet.GetRow(3).GetCell(0), header.ListDescription);
            //cellRange = new CellRangeAddress(3, 5, 0, 4);
            //oSheet.AddMergedRegion(cellRange);

            //// Filtri di ricerca Usati
            //CreateRowsColumns(oSheet, 6, 8, 0, 2);
            //CreateHeader3(oWorkbook, oSheet.GetRow(6).GetCell(0));
            //cellRange = new CellRangeAddress(6, 7, 0, 1);
            //oSheet.AddMergedRegion(cellRange);

            // Colonne
            CreateRowHeader(oWorkbook, oSheet, 3, columnsTable, dataTable);

            // Tabella
            var lastRow = 4; //+ header.FilterUsedDescription.Count;

            for (var rowIndex = 0; rowIndex < dataTable.Rows.Count; rowIndex++)
            {
                var row = oSheet.CreateRow(lastRow + rowIndex);

                //row.HeightInPoints = 200;

                var opt = rowIndex % 2 == 0 ? 0 : 1;

                for (var colIndex = 0; colIndex < dataTable.Columns.Count; colIndex++)
                {
                    if (columnsTable == null)
                        continue;

                    var column = columnsTable.ToList().FirstOrDefault(x =>
                        x.Text.ToLower() == dataTable.Columns[colIndex].ColumnName.Replace('_', ' ').ToLower());

                    var cell = row.CreateCell(colIndex);

                    if (column == null)
                        continue;

                    column.SetValue(cell,
                        dataTable.Rows[rowIndex].ItemArray[colIndex].ToString() == "-"
                            ? "-"
                            : dataTable.Rows[rowIndex].ItemArray[colIndex].ToString());

                    column.Style[opt].WrapText = true;

                    cell.CellStyle = column.Style[opt];
                }
            }

        }

        #endregion

        #region Create Style

        //private void CreateHeader1(IWorkbook oWorkbook, ICell headerCell, string value)
        //{
        //    var styleHeader = oWorkbook.CreateCellStyle();

        //    var fontHeader = _createFont(oWorkbook);

        //    fontHeader.FontHeightInPoints = 17;
        //    fontHeader.FontName = "Verdana";
        //    fontHeader.Boldweight = (short)FontBoldWeight.Bold;
        //    _setColor(oWorkbook, fontHeader, 51, 51, 153);

        //    styleHeader.SetFont(fontHeader);
        //    styleHeader.VerticalAlignment = VerticalAlignment.Center;

        //    headerCell.SetCellValue(value);
        //    headerCell.CellStyle = styleHeader;
        //}

        //private void CreateHeader2(IWorkbook oWorkbook, ICell headerCell, string value)
        //{
        //    var styleHeader = oWorkbook.CreateCellStyle();

        //    var fontHeader = _createFont(oWorkbook);

        //    fontHeader.FontHeightInPoints = 11;
        //    fontHeader.FontName = "Verdana";
        //    fontHeader.Boldweight = (short)FontBoldWeight.Bold;
        //    _setColor(oWorkbook, fontHeader, 51, 51, 153);

        //    styleHeader.SetFont(fontHeader);
        //    styleHeader.VerticalAlignment = VerticalAlignment.Center;

        //    headerCell.SetCellValue(value);
        //    headerCell.CellStyle = styleHeader;
        //}

        //private void CreateHeader3(IWorkbook oWorkbook, ICell headerCell)
        //{
        //    var styleHeader = oWorkbook.CreateCellStyle();

        //    var fontHeader = _createFont(oWorkbook);

        //    fontHeader.FontHeightInPoints = 11;
        //    fontHeader.FontName = "Verdana";
        //    fontHeader.Boldweight = (short)FontBoldWeight.Bold;
        //    _setColor(oWorkbook, fontHeader, 51, 51, 153);

        //    styleHeader.SetFont(fontHeader);
        //    styleHeader.VerticalAlignment = VerticalAlignment.Center;

        //    headerCell.SetCellValue("Filtri di ricerca usati:");
        //    headerCell.CellStyle = styleHeader;
        //}

        //private void CreateHeader4(IWorkbook oWorkbook, ICell headerCell, string value)
        //{
        //    var styleHeader = oWorkbook.CreateCellStyle();

        //    var fontHeader = _createFont(oWorkbook);

        //    fontHeader.FontHeightInPoints = 9;
        //    fontHeader.FontName = "Verdana";
        //    fontHeader.Boldweight = (short)FontBoldWeight.Bold;
        //    _setColor(oWorkbook, fontHeader, 51, 102, 255);

        //    styleHeader.SetFont(fontHeader);
        //    styleHeader.VerticalAlignment = VerticalAlignment.Center;
        //    styleHeader.Alignment = HorizontalAlignment.Left;

        //    headerCell.SetCellValue(value);
        //    headerCell.CellStyle = styleHeader;
        //}

        private void CreateRowHeader(IWorkbook oWorkbook, ISheet oSheet, int rowIndex, List<NpoiColumnExcel> columns, DataTable dataTable)
        {
            var row = oSheet.CreateRow(rowIndex);

            var styleHeader = oWorkbook.CreateCellStyle();

            var fontHeader = _createFont(oWorkbook);

            fontHeader.FontHeightInPoints = 9;
            fontHeader.FontName = "Verdana";
            fontHeader.Boldweight = (short)FontBoldWeight.Bold;

            styleHeader.SetFont(fontHeader);
            styleHeader.VerticalAlignment = VerticalAlignment.Center;
            styleHeader.Alignment = HorizontalAlignment.Center;
            _setColor(oWorkbook, fontHeader, 255, 255, 255);

            _setFillForegroundColor(oWorkbook, styleHeader, 51, 102, 255);

            styleHeader.FillPattern = FillPattern.SolidForeground;

            for (var colIndex = 0; colIndex < columns.Count; colIndex++)
            {
                var column = columns.ToList().FirstOrDefault(x =>
                    x.Text.ToLower() == dataTable.Columns[colIndex].ColumnName.Replace('_', ' ').ToLower());

                if (column == null)
                    continue;

                column.Style = new[]
                {
                    CreateStyle(oWorkbook, column.TextAlign, 255, 255, 255, column.NumberFormat),
                    CreateStyle(oWorkbook, column.TextAlign, 245, 245, 245, column.NumberFormat)
                };

                var headerCell = row.CreateCell(colIndex);

                headerCell.SetCellValue(column.Text);
                headerCell.CellStyle = styleHeader;

                oSheet.SetColumnWidth(colIndex, column.ColumnWidth);


            }
        }

        //private static void CreateRowsColumns(ISheet oSheet, int firstRow, int lastRow, int firstCol, int lastCol)
        //{
        //    for (var rowIndex = firstRow; rowIndex < lastRow; rowIndex++)
        //    {
        //        var row = oSheet.CreateRow(rowIndex);

        //        for (var colIndex = firstCol; colIndex < lastCol; colIndex++)
        //            row.CreateCell(colIndex);

        //    }
        //}

        private ICellStyle CreateStyle(IWorkbook oWorkbook, HorizontalAlignment alignment, byte r, byte g, byte b, string numberFormat)
        {
            var fontHeader = _createFont(oWorkbook);

            fontHeader.FontHeightInPoints = 8;
            fontHeader.FontName = "Verdana";
            _setColor(oWorkbook, fontHeader, 0, 0, 0);

            var styleHeader = oWorkbook.CreateCellStyle();

            styleHeader.SetFont(fontHeader);
            styleHeader.VerticalAlignment = VerticalAlignment.Center;
            styleHeader.Alignment = alignment;

            styleHeader.BorderLeft = BorderStyle.Thin;
            styleHeader.BorderTop = BorderStyle.Thin;
            styleHeader.BorderRight = BorderStyle.Thin;
            styleHeader.BorderBottom = BorderStyle.Thin;

            _setFillForegroundColor(oWorkbook, styleHeader, r, g, b);
            styleHeader.FillPattern = FillPattern.SolidForeground;

            if (!string.IsNullOrWhiteSpace(numberFormat))
                styleHeader.DataFormat = oWorkbook.CreateDataFormat().GetFormat(numberFormat);

            return styleHeader;
        }

        #endregion

    }
}
