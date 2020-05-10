using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace OCCMK_Kartoteka
{
    public abstract class AExcelExporter : AExporter
    {
        protected Excel.Application excelApp;
        protected Excel.Workbook excelAppWorkbook;
        protected Excel.Worksheet excelworksheet;
        protected Excel.Range excelcells;

        protected int verticalOffset = 0;
        protected DataSet ds;

        public AExcelExporter(DataSet ds)
        {
            this.ds = ds;
        }

        public override bool export(string fileName, System.ComponentModel.BackgroundWorker backgroundWorker)
        {
            bool error = false;
            setEnvironment(fileName, backgroundWorker);

            try
            {
                openExcelAndPreparePrint();

                printHeader();
                printContent();
                printFooter();

                excelAppWorkbook.Save();
            }
            catch (COMException ex)
            {
                actionsAfterExportError(ex);
                error = true;
                throw ex;
            }
            catch (CancelException ex)
            {
                closeApp();
                System.IO.File.Delete(fileName);
                error = true;
                throw ex;
            }
            catch (Exception ex)
            {
                actionsAfterExportError(ex);
                System.IO.File.Delete(fileName);
                error = true;
            }
            return !error;
        }

        #region вспомогательные функции

        protected override void setEnvironment(string fileName, System.ComponentModel.BackgroundWorker backgroundWorker)
        {
            base.setEnvironment(fileName, backgroundWorker);
            totalRowCount = ds.Tables[0].Rows.Count;
        }

        public override bool activeWorkBookIsNull()
        {
            if (excelApp.ActiveWorkbook == null)
                return true;
            return false;
        }

        public override void showApp()
        {
            excelApp.Visible = true;
        }

        protected override void closeApp()
        {
            excelApp.DisplayAlerts = false;
            excelApp.Quit();
            excelAppWorkbook = null;
            excelworksheet = null;
            excelcells = null;
            excelApp.Quit();
            excelApp.DisplayAlerts = true;
            excelApp = null;
        }

        protected int recalcDtIndexToExcelIndex(int index)
        {
            return index + 1;
        }

        protected void openExcelAndPreparePrint()
        {
            excelApp = new Excel.Application();
            excelApp.Visible = false;
            excelApp.DisplayAlerts = false;

            excelApp.SheetsInNewWorkbook = 1;
            excelApp.Workbooks.Add();

            excelAppWorkbook = excelApp.Workbooks[1];
            excelworksheet = excelAppWorkbook.Worksheets.get_Item(1);


            excelAppWorkbook.SaveAs(fileName);
            excelworksheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;

            excelApp.DisplayAlerts = true;
        }

        protected void printCell(int row, int column, string value)
        {
            excelcells = (Excel.Range)excelworksheet.Cells[recalcDtIndexToExcelIndex(row), recalcDtIndexToExcelIndex(column)];
            excelcells.Value2 = value;
            if (backgroundWorker.CancellationPending == true)
            {
                throw new CancelException("Экспорт прерван пользователем");
            }
        }

        protected void setCellFormat()
        {
            excelcells.Borders.Color = 2;
            excelcells.Font.Name = "Times New Roman";
            excelcells.Font.Size = 8;
            excelcells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            excelcells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            excelcells.Rows.AutoFit();
            excelcells.WrapText = true;
        }

        private void printMultiheaderArray(string[,] multiheader, List<Tuple<int, int>> repeatsList)
        {
            for (int i = 0; i < repeatsList.Count; i++)
            {
                int colBeginId = repeatsList[i].Item1;
                int repCountInList = repeatsList[i].Item2;

                if (repCountInList < 0)
                    printSimpleHeaderBlock(repCountInList, colBeginId, multiheader);
                else
                    printMultiHeaderBlock(repCountInList, colBeginId, multiheader);
            }
        }

        private void printSimpleHeaderBlock(int repCountInList, int colBeginId, string[,] multiheader)
        {
            repCountInList = -repCountInList;
            for (int j = colBeginId; j < colBeginId + repCountInList; j++)
            {
                string value = multiheader[0, j];
                string lu = getTextNameCell(0, j);
                string rd = getTextNameCell(1, j);

                mergeLuRdAndSetValueInto(lu, rd, value);
            }
        }

        private void printMultiHeaderBlock(int repCountInList, int colBeginId, string[,] multiheader)
        {
            string value = multiheader[0, colBeginId];
            string lu = getTextNameCell(0, colBeginId);
            string rd = getTextNameCell(0, colBeginId + repCountInList - 1);

            mergeLuRdAndSetValueInto(lu, rd, value);

            for (int k = colBeginId; k < colBeginId + repCountInList; k++)
            {
                printCell(1, k, multiheader[1, k]);
            }
        }

        private void mergeLuRdAndSetValueInto(string lu, string rd, string value)
        {
            excelcells = (Excel.Range)excelworksheet.get_Range(lu, rd);
            excelcells.Merge();
            excelcells.Value2 = value;
        }

        private static List<Tuple<int, int>> getRepeatsList(int colCount, string[,] multiheader)
        {
            List<Tuple<int, int>> repeatsList = new List<Tuple<int, int>>();

            for (int i = 0; i < colCount-1; i++)
            {
                int count = 0;
                int start = i;
                string curValue = multiheader[0, i+count];

                if (multiheader[1, i] == null)
                {
                    while ((i+count < colCount)&&(multiheader[1, i+count] == null))
                        count++;
                    repeatsList.Add(new Tuple<int, int>(start, -count));
                }
                else
                {
                    while ((i+count < colCount)&&(multiheader[0, i+count] == curValue))
                        count++;
                    repeatsList.Add(new Tuple<int, int>(start, count));
                }
                i += count-1;
            }
            return repeatsList;
        }

        private static string[,] getMultiheaderArray(DataTable table, int colCount)
        {
            string[,] multiheader = new string[2, colCount];

            for (int i = 0; i < colCount; i++)
            {
                string[] splitResult = table.Columns[i].ColumnName.Split('$');

                for (int j = 0; j < splitResult.Length; j++)
                {
                    multiheader[j, i] = splitResult[j].Trim();
                }
            }
            return multiheader;
        }

        private void printHeaderBorder(int columnCount)
        {
            string lu = "";
            string rd = "";

            lu = getTextNameCell(0, 0);
            rd = getTextNameCell(1, columnCount - 1);
            excelcells = (Excel.Range)excelworksheet.get_Range(lu, rd);
            setCellFormat();
        }

        protected virtual void printHeader()
        {
            DataTable table = ds.Tables[0];
            int colCount = table.Columns.Count;
            printHeaderBorder(colCount);

            string[,] multiheader = getMultiheaderArray(table, colCount);

            List<Tuple<int, int>> repeatsList = getRepeatsList(colCount, multiheader);

            printMultiheaderArray(multiheader, repeatsList);

            verticalOffset += 2;
        }

        protected abstract void printContent();

        protected abstract void printFooter();

        protected void printRows(DataTable dt, int rowStart, int rowCount)
        {
            string lu = getTextNameCell(verticalOffset, 0);
            string rd = getTextNameCell(rowCount + verticalOffset - 1, dt.Columns.Count - 1);

            for (int i = rowStart; i < rowStart + rowCount; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    printCell(verticalOffset, j, dt.Rows[i][j].ToString());
                }
                backgroundWorker.ReportProgress(calcPercent(i));

                verticalOffset++;
            }
            backgroundWorker.ReportProgress(calcPercent(rowStart + rowCount));

            excelcells = excelworksheet.get_Range(lu, rd);
            setCellFormat();
        }

        protected string getTextNameCell(int row, int col)
        {
            string res = "";
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            res += alphabet[col];
            res += recalcDtIndexToExcelIndex(row);

            return res;
        }

        #endregion
    }
}
