using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OCCMK_Kartoteka
{
    public partial class AReportForm : Form
    {
        protected DatabaseContext dbContext = DatabaseContext.Instance;
        protected DataTable dTable;
        protected int totalRowCount;
        protected string sortColumnName = "Номер";
        protected ListSortDirection sortDirection = ListSortDirection.Ascending;

        public AReportForm()
        {
            InitializeComponent();
            saveFileDialog = new SaveFileDialog();
        }

        protected virtual void export() {}
        protected virtual void UpdateControls() {}

        #region обработка событий на форме

        protected void btnExportClicked(string fileNameSample)
        {
            saveFileDialog.Filter = String.Format("Файлы Excel(*.xls)|*.xls");
            saveFileDialog.FileName = fileNameSample;
            DialogResult dr = saveFileDialog.ShowDialog();


            if (dr == System.Windows.Forms.DialogResult.OK)
            {
               export();
            }
            if (dr == System.Windows.Forms.DialogResult.Cancel)
                return;
        }

        protected void dgvDocuments_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView dgvDocuments = (DataGridView)sender;
            if (e.ColumnIndex == dgvDocuments.Columns["№ п/п"].Index) return;
            sortDirection = (dgvDocuments.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == System.Windows.Forms.SortOrder.Ascending) ? ListSortDirection.Descending : ListSortDirection.Ascending;
            Sort(dgvDocuments, dgvDocuments.Columns[e.ColumnIndex].Name, sortDirection);
            sortColumnName = dgvDocuments.Columns[e.ColumnIndex].Name;
            recalcOrderNumber((DataTable)dgvDocuments.DataSource);
        }

        #endregion

        #region вспомогательные функции

        protected virtual void RefreshDGV()
        {
            base.Refresh();
            UpdateControls();
        }

        protected void replaceDollarBySlash(DataGridView dgv)
        {
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                dgv.Columns[i].HeaderText = dgv.Columns[i].HeaderText.Replace('$', '/');
            }
        }

        protected int getIndexForKey(DataGridView dgv, int colNum, object key)
        {
            int index = -1;
            for (int i = 0; i < dgv.RowCount; i++)
            {
                if (dgv[colNum, i].Equals(key))
                {
                    index = i;
                }
            }
            return index;
        }

        protected int getIndexForKey(DataGridView dgv, string colName, object key)
        {
            int index = -1;
            for (int i = 0; i < dgv.RowCount; i++)
            {
                if (dgv[colName, i].Value.Equals(key))
                {
                    index = i;
                }
            }
            return index;
        }

        protected virtual bool isDateColumn(int index)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Функция действия не реализована", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FileLogger.log(LogLevel.Fatal, "Функция действия не реализована. " + ex.ToString());
                return false;
            }
        }

        protected virtual bool isTextColumn(int index)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Функция действия не реализована", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FileLogger.log(LogLevel.Fatal, "Функция действия не реализована. " + ex.ToString());
                return false;
            }
        }

        protected virtual bool isNumericColumn(int index)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Функция действия не реализована", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FileLogger.log(LogLevel.Fatal, "Функция действия не реализована. " + ex.ToString());
                return false;
            }
        }

        protected void recalcOrderNumber(DataTable dt)
        {
            dt.Columns["№ п/п"].ReadOnly = false;
            for (int i = 0; i < dt.Rows.Count; i++)
                dt.Rows[i]["№ п/п"] = i + 1;
        }

        protected void Sort(DataGridView dgv, string columnName, ListSortDirection lsd)
        {
            if (((DataTable)dgv.DataSource).Rows.Count != 0)
            {
                dgv.Columns[columnName].SortMode = DataGridViewColumnSortMode.Programmatic;
                int index = dgv.Columns[columnName].Index;
                if (isDateColumn(index))
                {
                    dgv.DataSource = ((DataTable)dgv.DataSource).AsEnumerable().OrderBy(row => row[index].ToString(), new DateComparer(sortDirection)).CopyToDataTable();
                }
                else if (isTextColumn(index))
                {
                    dgv.DataSource = ((DataTable)dgv.DataSource).AsEnumerable().OrderBy(row => row[index].ToString(), new TextComparer(sortDirection)).CopyToDataTable();
                }
                else if (isNumericColumn(index))
                {
                    dgv.DataSource = ((DataTable)dgv.DataSource).AsEnumerable().OrderBy(row => row[index].ToString(), new NumberComparer(sortDirection)).CopyToDataTable();
                }
                sortColumnName = columnName;
                dgv.Columns[sortColumnName].HeaderCell.SortGlyphDirection = (sortDirection == ListSortDirection.Ascending) ? System.Windows.Forms.SortOrder.Ascending : System.Windows.Forms.SortOrder.Descending;
            } 
        }

        #endregion
    }
}
