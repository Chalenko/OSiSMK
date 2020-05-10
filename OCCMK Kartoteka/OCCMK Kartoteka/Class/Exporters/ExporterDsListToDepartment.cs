using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace OCCMK_Kartoteka
{
    class ExporterDsListToDepartment:AExcelExporter
    {
        private int inStockCurrentDoc = 0;
        private int inStockTotalDoc = 0;
        private int uniqueDocCount = 0;

        private int copyNameColumnId = 3;
        private int oboznColumnId = 4;
        private int takeDateColumnId = 8;

        public ExporterDsListToDepartment(DataSet ds)
            : base(ds)
        {
            uniqueDocCount = ds.Tables[1].Rows.Count;
        }

        protected override void printHeader()
        {
            base.printHeader();

            excelcells = excelworksheet.Rows["1", Type.Missing];
            excelcells.RowHeight = 42;
            excelcells = excelworksheet.Columns["D", Type.Missing];
            excelcells.NumberFormat = "@";
        }

        protected override void printContent()
        {
            int rowStart = 0;
            for (int i = 0; i < uniqueDocCount; i++)
            {
                int copyCount = System.Convert.ToInt32(ds.Tables[1].Rows[i]["Количество экземпляров"]);
                printRows(ds.Tables[0], rowStart, copyCount);
                rowStart += copyCount;

                string luSubSum = getTextNameCell(verticalOffset, 0);
                string rdSubSum = getTextNameCell(verticalOffset, ds.Tables[0].Columns.Count - 1);
                excelcells = excelworksheet.get_Range(luSubSum, rdSubSum);
                setCellFormat();

                inStockCurrentDoc = (int)ds.Tables[1].Rows[i]["Количество списанных экземпляров"];
                inStockTotalDoc += inStockCurrentDoc;

                printCell(verticalOffset, 0, "Итого:");
                excelcells.Font.Bold = true;

                printCell(verticalOffset, copyNameColumnId, "Сумма " + copyCount);
                excelcells.Font.Bold = true;

                printCell(verticalOffset, takeDateColumnId, "Сумма " + inStockCurrentDoc);
                excelcells.Font.Bold = true;

                verticalOffset++;
            }
        }

        protected override void printFooter()
        {
            for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
            {
                string value = "";
                if (i == 0)
                    value = "Всего:";

                if (i == copyNameColumnId)
                {
                    int allCopiesCount = 0;

                    for (int j = 0; j < uniqueDocCount; j++)
                    {
                        allCopiesCount += System.Convert.ToInt32(ds.Tables[1].Rows[j]["Количество экземпляров"]);
                    }

                    value = allCopiesCount.ToString();
                }
                if (i == oboznColumnId)
                    value = ds.Tables[1].Rows.Count.ToString();

                if (i == takeDateColumnId)
                    value = inStockTotalDoc.ToString();

                printCell(verticalOffset, i, value);
                excelcells.Font.Bold = true;
            }

            string lu = getTextNameCell(verticalOffset, 0);
            string rd = getTextNameCell(verticalOffset, ds.Tables[0].Columns.Count - 1);
            excelcells = excelworksheet.get_Range(lu, rd);
            setCellFormat();
        }
    }
}
