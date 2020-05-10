using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System.Data;

namespace OCCMK_Kartoteka
{
    class ExporterAllStandartList : AExcelExporter
    {
        public ExporterAllStandartList(DataSet ds)
        : base(ds)
        {
        }

        protected override void printHeader()
        {
            base.printHeader();

            excelcells = (Excel.Range)excelworksheet.Rows["1", Type.Missing];
            excelcells.RowHeight = 42;
        }

        protected override void printContent()
        {
            printRows(ds.Tables[0], 0, ds.Tables[0].Rows.Count);
        }

        protected override void printFooter()
        {
            DataTable dt = ds.Tables[0];
            printCell(verticalOffset, 0, "Всего:");

            for (int i = 1; i < dt.Columns.Count; i++)
            {
                printCell(verticalOffset, i, dt.Rows.Count.ToString());
            }

            string lu = getTextNameCell(verticalOffset, 0);
            string rd = getTextNameCell(verticalOffset, dt.Columns.Count - 1);
            excelcells = (Excel.Range)excelworksheet.get_Range(lu, rd);
            setCellFormat();

            verticalOffset += 1;
        }
    }
}
