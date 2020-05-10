using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Data.SqlClient;

namespace OCCMK_Kartoteka
{
    public partial class ReportAllStandarts : AReportForm
    {

        public ReportAllStandarts()
        {
            InitializeComponent();
            //dgvStandarts.Sort(dgvStandarts.Columns["Номер"], ListSortDirection.Ascending);
        }

        private void ReportAllStandarts_Shown(object sender, EventArgs e)
        {
            RefreshDGV();
        }

        protected override void export()
        {
            DataTable dt = ((DataTable)dgvStandarts.DataSource).Copy();
            dt.Columns.RemoveAt(dgvStandarts.Columns["Номер"].Index);
            DataTable dtToDs = dt.DefaultView.ToTable();
            DataSet ds = new DataSet();
            ds.Tables.Add(dtToDs);

            new ProgressForm(new ExporterAllStandartList(ds), saveFileDialog.FileName).ShowDialog();

            ds.Clear();
        }

        #region обработка событий на форме

        private void btnFilter_Click(object sender, EventArgs e)
        {
            string filter = tbFilter.Text;
            string field = tbFilterField.Text;

            if (field.Trim().Equals(""))
            {
                MessageBox.Show("Необходимо выбрать поле для фильтрации, кликнув на ячейке в нужной колонке");
                tbFilterField.BackColor = Color.Crimson;
                return;
            }

            string filterStringForFormDataView = "";
            string textForLbFilterHistory = "";

            if (filter.Trim().Equals(""))
            {
                filterStringForFormDataView = string.Format("[{0}] is null", field);
                textForLbFilterHistory = filterStringForFormDataView;
            }
            else
            {
                filterStringForFormDataView = string.Format("[{0}] like '%{1}%'", field, filter);
                textForLbFilterHistory = field + " => " + filter;
            }

            if (lbFilterHistory.Items.Contains(textForLbFilterHistory))
            {
                MessageBox.Show("Попытка применить уже примененный фильтр");
                return;
            }

            toFilter(filterStringForFormDataView, textForLbFilterHistory);

            dgvStandarts.Focus();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            DataTable dataSource = (DataTable)dgvStandarts.DataSource;

            string searchingValue = tbFind.Text;
            int fCount = 0;

            for (int i = 0; i < dgvStandarts.Rows.Count; i++)
            {
                for (int j = 2; j < dgvStandarts.Columns.Count; j++)
                {
                    string cellValue = dgvStandarts[j, i].Value.ToString();// dataSource.Rows[i][j].ToString();
                    dgvStandarts[j, i].Style.BackColor = Color.White;

                    int compareResult = cellValue.IndexOf(searchingValue, 0, cellValue.Length, StringComparison.CurrentCultureIgnoreCase);
                    if (compareResult >= 0)
                    {
                        dgvStandarts[j, i].Style.BackColor = Color.GreenYellow;
                        fCount++;
                    }
                }
            }

            if (fCount == 0)
                MessageBox.Show(string.Format("Нет записей, содержащих \"{0}\"", searchingValue));

            lblFindCount.Text = "Кол-во совпадений: " + fCount;

            printSum();

            dgvStandarts.Focus();
        }

        private void btnClearFind_Click(object sender, EventArgs e)
        {
            DataTable dataSource = (DataTable)dgvStandarts.DataSource;
            for (int i = 0; i < dataSource.Rows.Count; i++)
            {
                for (int j = 1; j < dataSource.Columns.Count; j++)
                {
                    dgvStandarts[j, i].Style.BackColor = Color.White;
                }
            }
            lblFindCount.Text = "";
        }

        private void tsmSendToFilter_Click(object sender, EventArgs e)
        {
            if (dgvStandarts.CurrentCell.ColumnIndex != 0)
                tbFilterField.Text = dgvStandarts.Columns[dgvStandarts.CurrentCell.ColumnIndex].Name;
            tbFilter.Text = dgvStandarts.CurrentCell.Value.ToString();
        }

        private void tsmSendToFind_Click(object sender, EventArgs e)
        {
            tbFind.Text = dgvStandarts.CurrentCell.Value.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            string fileName = "Перечень стандартов, внедренных на ПАО 'НМЗ'.xls";
            base.btnExportClicked(fileName);
        }

        private void lbFilterHistory_MouseClick(object sender, MouseEventArgs e)
        {
            cmsFilterListBox.Enabled = true;
            if (e.Button == MouseButtons.Right)
            {
                int index = this.lbFilterHistory.IndexFromPoint(e.Location);
                if (index != ListBox.NoMatches)
                {
                    lbFilterHistory.SelectedItem = lbFilterHistory.Items[index];
                }
                else
                {
                    cmsFilterListBox.Enabled = false;
                }
            }
        }

        private void dgvDocuments_MouseDown(object sender, MouseEventArgs e)
        {
            cmsStandarts.Enabled = true;
            DataGridView.HitTestInfo hitInfo = dgvStandarts.HitTest(e.X, e.Y);

            if ((hitInfo.Type == DataGridViewHitTestType.Cell) && (hitInfo.ColumnIndex != 0))
            {
                tbFilterField.Text = dgvStandarts.Columns[hitInfo.ColumnIndex].Name;
                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    cmsStandarts.Enabled = true;
                    dgvStandarts.CurrentCell = dgvStandarts.Rows[hitInfo.RowIndex].Cells[hitInfo.ColumnIndex];
                    dgvStandarts.Rows[hitInfo.RowIndex].Selected = true;
                    
                }
            }
            else
            {
                cmsStandarts.Enabled = false;
            }
        }

        private void tsmiDeleteFilter_Click(object sender, EventArgs e)
        {
            lbFilterHistory.Items.Remove(lbFilterHistory.SelectedItem);
            applyAllFiltersFromHistory();
        }

        private void tbFilterField_TextChanged(object sender, EventArgs e)
        {
            tbFilterField.BackColor = Color.White;
        }

        private void tbFilter_TextChanged(object sender, EventArgs e)
        {
            tbFilter.BackColor = Color.White;
        }

        private void ctsEdit_Click(object sender, EventArgs e)
        {
            new EditDocForm(dgvStandarts.CurrentRow.Cells["Номер"].Value.ToString()).ShowDialog();
            RefreshDGV();
            applyAllFiltersFromHistory();
        }

        private void ctsDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удалить запись?", "Удаление записи", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                string tbVzamen = "";
                string tbZamenen = "";
                int docId = Convert.ToInt32(dgvStandarts.CurrentRow.Cells["Номер"].Value);
                MainForm.getVzamenZamenen(docId, ref tbVzamen, ref tbZamenen);
                bool vzamen = true;
                bool zamenen = true;
                if (!tbVzamen.Trim().Equals("")) vzamen = MessageBox.Show("Данный документ является заменой другого докумета! \nВсе равно удалить?", "Удаление записи", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes ? true : false;
                if (!tbZamenen.Trim().Equals("")) zamenen = MessageBox.Show("Данный документ был заменен другим документом! \nУдаление данного документа приведет к потере сведений в заменяющем документе. \nВсе равно удалить?", "Удаление записи", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes ? true : false;
                if (vzamen && zamenen)
                {
                    string command = "DeleteCard";
                    try
                    {
                        dbContext.ExecuteCommand(command, new Dictionary<string, object> { { "@docID", docId } }, CommandType.StoredProcedure);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Не удалось удалить карточку", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        FileLogger.log(LogLevel.Error, "Не удалось удалить карточку " + ex.ToString());
                        return;
                    }
                    finally
                    {
                        dbContext._connection.Close();
                    }
                    FileLogger.log(LogLevel.Info, "Карточка с id = " + docId.ToString() + " удалена.");
                    MessageBox.Show("Запись удалена!", "Удаление записи", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                RefreshDGV();
            }
        }

        private void btnDropFilter_Click(object sender, EventArgs e)
        {
            dgvStandarts.DataSource = dTable;
            RefreshDGV();

            lbFilterHistory.Items.Clear();
        }

        private void dgvStandarts_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.dgvDocuments_ColumnHeaderMouseClick(sender, e);
        }

        #endregion

        #region вспомогательные функции

        protected override void RefreshDGV()
        {
            try
            {
                dTable = dbContext.LoadFromDatabase("SelectAllStandarts");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось загрузить данные", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                FileLogger.log(LogLevel.Error, "Ошибка при загрузке данных " + ex.ToString());
            }

            base.RefreshDGV();
        }

        override protected void UpdateControls()
        {
            if (dTable == null)
            {
                gbTotal.Enabled = false;
                return;
            }

            dgvStandarts.DataSource = dTable;
            dgvStandarts.Columns["№ п/п"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvStandarts.Columns["№ п/п"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvStandarts.Columns["Номер"].Visible = false;
            Sort(dgvStandarts, "Номер", ListSortDirection.Ascending);
            recalcOrderNumber((DataTable)dgvStandarts.DataSource);
            //dgvStandarts.Columns["№ п/п"].Visible = false;
            replaceDollarBySlash(dgvStandarts);

            sortDirection = ListSortDirection.Ascending;

            printSum();

            if (dgvStandarts.Rows.Count == 0)
            {
                btnExport.Enabled = false;
                dgvStandarts.Enabled = false;
                MessageBox.Show("В базе отсутствуют карточки!");
            }
            else
            {
                btnExport.Enabled = true;
                dgvStandarts.Enabled = true;
            }
        }

        private void printSum()
        {
            lblSum.Text = "Сумма: " + dgvStandarts.RowCount;
        }

        private string constructSelectStringByAllColumns(string searchingValue)
        {
            string filter = "";
            for (int i = 0; i < dgvStandarts.Columns.Count; i++)
            {
                filter += string.Format("[{0}] like '%{1}%' or ", dgvStandarts.Columns[i].Name, searchingValue);
            }
            filter = filter.Remove(filter.Length - 3);
            return filter;
        }

        private void applyAllFiltersFromHistory()
        {
            string query = createQuery();

            DataView dv = new DataView(dTable, query, "", DataViewRowState.CurrentRows);
            DataTable dt = dv.ToTable();
            int k = 1;
            foreach (DataRow row in dt.Rows)
            {
                dt.Columns[0].ReadOnly = false;
                row[0] = k++;
            }
            dgvStandarts.DataSource = dt;

            if (dt.Rows.Count == 0)
                btnExport.Enabled = false;
            else
                btnExport.Enabled = true;

            printSum();
        }

        private string createQuery()
        {
            string query = "";
            for (int i = 0; i < lbFilterHistory.Items.Count; i++)
            {
                string[] split = ((string)lbFilterHistory.Items[i].ToString()).Split(new string[] { "=>" }, System.StringSplitOptions.RemoveEmptyEntries);
                if (split.Length != 1)
                    query += string.Format("[{0}] like '%{1}%' and ", split[0].Trim(), split[1].Trim());
                else
                    query += lbFilterHistory.Items[i].ToString() + " and ";
            }
            if (query.Length != 0)
                query = query.Substring(0, query.Length - 4);
            return query;
        }

        private void toFilter(string filterStringForFormDataView, string textForLbFilterHistory)
        {
            try
            {
                DataTable dtDataSourceOld = (DataTable)dgvStandarts.DataSource;
                DataView dv = new DataView(dtDataSourceOld, filterStringForFormDataView, "", DataViewRowState.CurrentRows);

                DataTable dt = dv.ToTable();
                int k = 1;
                foreach (DataRow row in dt.Rows)
                {
                    dt.Columns[0].ReadOnly = false;
                    row[0] = k++;
                }
                dgvStandarts.DataSource = dt;

                Refresh();

                lbFilterHistory.Items.Add(textForLbFilterHistory);

                printSum();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при применении фильтра\n" + ex.Message);
                FileLogger.log(LogLevel.Warn, "Ошибка при применении фильтра " + ex.ToString());
            }
        }

        protected override bool isDateColumn(int index)
        {
            return index == dgvStandarts.Columns["Дата введения"].Index 
                || index == dgvStandarts.Columns["Информация о получении $ Дата получения"].Index
                || index == dgvStandarts.Columns["Информация о введении $ Дата поручения о внедрении"].Index
                || index == dgvStandarts.Columns["Информация о введении $ Дата приказа/распоряжения"].Index
                || index == dgvStandarts.Columns["Информация о введении $ Дата завершения ОТМ(при наличии ОТМ)"].Index
                || index == dgvStandarts.Columns["Информация о введении $ Дата введения на предприятии"].Index;
        }

        protected override bool isNumericColumn(int index)
        {
            return index == dgvStandarts.Columns["Номер"].Index;
        }

        protected override bool isTextColumn(int index)
        {
            return !(isDateColumn(index) || isNumericColumn(index));
        }

        #endregion
    }
}
