using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace OCCMK_Kartoteka
{
    class ExporterDocumentsSinceTo:AExcelExporter
    {

        public ExporterDocumentsSinceTo(DataSet ds)
            : base(ds)
        {
        }

        protected override void printContent()
        {
            printRows(ds.Tables[0], 0, ds.Tables[0].Rows.Count);
        }

        protected override void printFooter()
        {
        }

    }
}
