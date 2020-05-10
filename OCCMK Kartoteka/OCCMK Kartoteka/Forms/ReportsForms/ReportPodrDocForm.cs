using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace OCCMK_Kartoteka
{
    public partial class ReportPodrDocForm : AReportForm
    {

        Dictionary<string, int> departmentDictionary = new Dictionary<string, int>();
        private DataTable dtStatistic;
        private int depId;

        public ReportPodrDocForm()
        {
            InitializeComponent();
            fillCmbDepartment();
        }

        protected override void export()
        {
            deleteTakedateIfCopyInStock(dTable);
            totalRowCount = dTable.Rows.Count;

            DataSet ds = new DataSet();
            DataTable dt = dTable.DefaultView.ToTable();
            dt.Columns.Remove("docId");
            dt.Columns.Remove("id");

            DataTable dtsToDs = ((DataTable)dgvStatistic.DataSource).Copy();
            dtsToDs.Columns.RemoveAt(dgvStatistic.Columns["Номер"].Index);

            ds.Tables.Add(dt);
            ds.Tables.Add(dtsToDs);

            new ProgressForm(new ExporterDsListToDepartment(ds), saveFileDialog.FileName).ShowDialog();

            ds.Clear();
        }

        #region обработка событий на форме

        private void btnSelectDS_Click(object sender, EventArgs e)
        {
            if (cmbDepartment.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите отдел");
                return;
            }

            depId = departmentDictionary[(string)cmbDepartment.SelectedItem];

            RefreshDGV();

            if (dgvMainList.Rows.Count != 0) dgvMainList.CurrentCell = dgvMainList[6, 0];
            if (dgvStatistic.Rows.Count != 0) dgvStatistic.CurrentCell = dgvStatistic[1, 0];
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            string fileName = string.Format("Перечень ДС, выданных в подразделение {0}", cmbDepartment.SelectedItem.ToString());
            base.btnExportClicked(fileName);
        }

        private void dgvMainList_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                DataGridView.HitTestInfo hitInfo = dgvMainList.HitTest(e.X, e.Y);
                if (hitInfo.Type == DataGridViewHitTestType.Cell)
                {
                    tsmiEditCopy.Enabled = true;
                    dgvMainList.CurrentCell = dgvMainList.Rows[hitInfo.RowIndex].Cells[hitInfo.ColumnIndex];
                    dgvMainList.Rows[hitInfo.RowIndex].Selected = true;

                    int statisticRow = getIndexForKey(dgvStatistic, "Номер", dgvMainList.CurrentRow.Cells["docId"].Value);
                    dgvStatistic.CurrentCell = dgvStatistic.Rows[statisticRow].Cells["Наименование"];
                    dgvStatistic.Rows[statisticRow].Selected = true;
                }
                else
                {
                    tsmiEditCopy.Enabled = false;
                }
            }
        }

        private void dgvMainList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int statisticRow = getIndexForKey(dgvStatistic, "Номер", dgvMainList.CurrentRow.Cells["docId"].Value);
            dgvStatistic.CurrentCell = dgvStatistic.Rows[statisticRow].Cells["Наименование"];
            dgvStatistic.Rows[statisticRow].Selected = true;
        }

        private void tsmiEditCopy_Click(object sender, EventArgs e)
        {
            int index = dgvMainList.SelectedRows[0].Index;

            int docId = (int)dgvMainList.SelectedRows[0].Cells["docId"].Value;
            int recId = (int)dgvMainList.SelectedRows[0].Cells["id"].Value;

            EditDocToDepartmentForm f = new EditDocToDepartmentForm("PodrDoc", docId.ToString(), recId.ToString());
            f.ShowDialog();

            RefreshDGV();
            dgvMainList.Rows[index].Selected = true;
        }

        private void dgvStatistic_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                DataGridView.HitTestInfo hitInfo = dgvStatistic.HitTest(e.X, e.Y);
                if (hitInfo.Type == DataGridViewHitTestType.Cell)
                {
                    tmsEditDocument.Enabled = true;
                    tmsDeleteDocument.Enabled = true;
                    dgvStatistic.CurrentCell = dgvStatistic.Rows[hitInfo.RowIndex].Cells[hitInfo.ColumnIndex];
                    dgvStatistic.Rows[hitInfo.RowIndex].Selected = true;
                }
                else
                {
                    tmsEditDocument.Enabled = false;
                    tmsDeleteDocument.Enabled = false;
                }
            }
        }

        private void tmsEditDocument_Click(object sender, EventArgs e)
        {
            new EditDocForm(dgvStatistic.CurrentRow.Cells["Номер"].Value.ToString()).ShowDialog();
            RefreshDGV();
        }

        private void tmsDeleteDocument_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удалить запись?", "Удаление записи", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                string tbVzamen = "";
                string tbZamenen = "";
                int docId = Convert.ToInt32(dgvStatistic.CurrentRow.Cells["Номер"].Value);
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

        private void dgvMainList_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvDocuments_ColumnHeaderMouseClick(sender, e);
            int statisticRow = getIndexForKey(dgvStatistic, "Номер", dgvMainList.CurrentRow.Cells["docId"].Value);
            dgvStatistic.CurrentCell = dgvStatistic.Rows[statisticRow].Cells["Наименование"];
        }

        #endregion

        #region вспомогательные функции

        private void fillCmbDepartment()
        {
            using (SqlCommand com = dbContext._connection.CreateCommand())
            {
                try
                {
                    DataTable dt = dbContext.LoadFromDatabase("Select distinct id, name from Departments", CommandType.Text);
                    dt = dt.AsEnumerable().OrderBy(row => row["name"].ToString(), new NaturalComparer(ListSortDirection.Ascending)).CopyToDataTable();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        cmbDepartment.Items.Add((dt.Rows[i]["name"]).ToString());
                        departmentDictionary.Add((dt.Rows[i]["name"]).ToString(), Convert.ToInt32((dt.Rows[i]["id"])));
                    }
                    cmbDepartment.AutoCompleteSource = AutoCompleteSource.ListItems;
                    cmbDepartment.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Не удалось загрузить список подразделений\n" + ex.Message, "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    FileLogger.log(LogLevel.Error, "Ошибка при получении данных " + ex.ToString());
                    return;
                }
                finally
                {
                    dbContext._connection.Close();
                }
            }
        }

        protected override void RefreshDGV()
        {
            try
            {
                RefreshMainList();
                RefreshStatistic();               
            }
            catch
            {
            }
            
            base.RefreshDGV();
        }

        private void RefreshMainList()
        {
            try
            {
                dTable = dbContext.LoadFromDatabase("SelectPodrDocForPrint", new Dictionary<string, object>() { { "podrId", depId } });
                dgvMainList.DataSource = dTable.DefaultView.ToTable();
            }
            catch (Exception ex)
            {
                FileLogger.log(LogLevel.Error, "Ошибка при получении данных " + ex.ToString());
                MessageBox.Show("Не удалось загрузить данные", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                throw ex;
            }
        }

        private void RefreshStatistic()
        {
            try
            {
                dtStatistic = dbContext.LoadFromDatabase("SelectPodrDocStatisticForPrint", new Dictionary<string, object>() { { "podrId", depId } });
            }
            catch (Exception ex)
            {
                FileLogger.log(LogLevel.Error, "Ошибка при получении данных " + ex.ToString());
                MessageBox.Show("Не удалось загрузить данные", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                throw ex;
            }
        }

        override protected void UpdateControls()
        {
            if (dTable == null || dtStatistic == null)
            {
                //btnSelectDS.Enabled = false;
                return;
            }

            //dgvMainList.DataSource = dTable;
            dgvMainList.Columns["docId"].Visible = false;
            dgvMainList.Columns["id"].Visible = false;
            dgvMainList.Columns["№ п/п"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMainList.Columns["№ п/п"].SortMode = DataGridViewColumnSortMode.NotSortable;
            //dgvMainList.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dgvMainList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            replaceDollarBySlash(dgvMainList);

            replaceNullByZeroCountCopyInStockInStatistic();
            dgvStatistic.DataSource = dtStatistic;
            dgvStatistic.Columns["Номер"].Visible = false;
            dgvStatistic.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            foreach (DataGridViewColumn c in dgvStatistic.Columns)
            {
                c.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            lblAllDocCount.Text = "Количество документов в подразделении: " + dtStatistic.Rows.Count;

            deleteTakedateIfCopyInStock((DataTable)dgvMainList.DataSource);

            if (cmbDepartment.Items.Count == 0)
                btnSelectDS.Enabled = false;

            if (dTable.Rows.Count != 0)
            {
                btnExport.Enabled = true;
            }
            else
            {
                MessageBox.Show("В данное подразделение документы не выдавались");
                lblAllDocCount.Text = "---";
                btnExport.Enabled = false;
            }
        }

        private void deleteTakedateIfCopyInStock(DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["Статус"].Equals("Выдан"))
                    dt.Rows[i]["Дата возврата"] = DBNull.Value;
            }
        }

        private void replaceNullByZeroCountCopyInStockInStatistic()
        {
            for (int i = 0; i < dtStatistic.Rows.Count; i++)
            {
                string value = System.Convert.ToString( dtStatistic.Rows[i]["Количество списанных экземпляров"]);
                if (value == "")
                    dtStatistic.Rows[i]["Количество списанных экземпляров"] = 0;
            }
        }

        protected override bool isDateColumn(int index)
        {
            return dgvMainList.Columns[index].HeaderText.ToLower().Contains("дата");
        }

        protected override bool isNumericColumn(int index)
        {
            return index == dgvMainList.Columns["№ п/п"].Index
                || index == dgvMainList.Columns["id"].Index
                || index == dgvMainList.Columns["docId"].Index;
        }

        protected override bool isTextColumn(int index)
        {
            return !(isDateColumn(index) || isNumericColumn(index));
        }

        #endregion
    }
}