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
    public partial class ReportDocSinceTo : AReportForm
    {
        private string storedProcedureName;
        private string mainLblString;
        DateTime sinceTime;
        DateTime toTime;

        private ReportDocSinceTo()
        {
            InitializeComponent();
        }

        public ReportDocSinceTo(String titleString, String procedure) : this()
        {
            mainLblString = titleString;
            storedProcedureName = procedure;
        }

        private void ReportDocSinceTo_Load(object sender, EventArgs e)
        {
            lblMainPhaseMulti.Text = mainLblString;
            sinceTime = dtpSince.Value.Date;
            toTime = dtpTo.Value.Date;
        }

        protected override void export()
        {
            totalRowCount = dTable.Rows.Count;

            DataTable dt = ((DataTable)dgvStandarts.DataSource).Copy();
            dt.Columns.Remove("Номер");
            DataTable dtToDs = dt.DefaultView.ToTable();
            DataSet ds = new DataSet();
            ds.Tables.Add(dtToDs);

            new ProgressForm(new ExporterDocumentsSinceTo(ds), saveFileDialog.FileName).ShowDialog();

            ds.Clear();
        }

        #region обработка событий на форме

        protected void btnGet_Click(object sender, EventArgs e)
        {
            btnExport.Enabled = false;

            sinceTime = dtpSince.Value.Date;
            toTime = dtpTo.Value.Date;

            if (sinceTime > toTime)
            {
                MessageBox.Show("Неверный временной промежуток");
                return;
            }

            RefreshDGV();
            dgvStandarts.Focus();
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            string dateAppend = string.Format(" с {0} по {1}.xls", dtpSince.Value.ToShortDateString(), dtpTo.Value.ToShortDateString());
            string fileName = mainLblString + dateAppend;
            
            base.btnExportClicked(fileName);
        }

        private void dgvDocuments_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                DataGridView.HitTestInfo hitInfo = dgvStandarts.HitTest(e.X, e.Y);
                if (hitInfo.Type == DataGridViewHitTestType.Cell)
                {
                    tsmiEdit.Enabled = true;
                    tsmiDelete.Enabled = true;
                    dgvStandarts.CurrentCell = dgvStandarts.Rows[hitInfo.RowIndex].Cells[hitInfo.ColumnIndex];
                    dgvStandarts.Rows[hitInfo.RowIndex].Selected = true;
                }
                else
                {
                    tsmiEdit.Enabled = false;
                    tsmiDelete.Enabled = false;
                }
            }
        }

        private void tsmiEdit_Click(object sender, EventArgs e)
        {
            int index = dgvStandarts.SelectedRows[0].Index;
            int id = (int)dgvStandarts.SelectedRows[0].Cells["Номер"].Value;

            new EditDocForm(id.ToString()).ShowDialog();

            btnGet_Click(null, null);
            dgvStandarts.Rows[index].Selected = true;
        }

        private void tsmiDelete_Click(object sender, EventArgs e)
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

        private void dgvStandarts_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.dgvDocuments_ColumnHeaderMouseClick(sender, e);
        }

        #endregion

        #region вспомогательные функции

        protected override void RefreshDGV()
        {
            Dictionary<string, object> dic = new Dictionary<string, object> { { "date1", sinceTime }, { "date2", toTime } };

            try
            {
                dTable = dbContext.LoadFromDatabase(storedProcedureName, dic, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось загрузить данные", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                FileLogger.log(LogLevel.Error, "Ошибка при получении данных " + ex.ToString());
            }

            base.RefreshDGV();
        }

        override protected void UpdateControls()
        {
            if (dTable == null)
            {
                return;
            }

            dgvStandarts.DataSource = dTable;

            if (dTable.Rows.Count != 0)
            {
                btnExport.Enabled = true;
            }
            else
            {
                btnExport.Enabled = false;
            }

            replaceDollarBySlash(dgvStandarts);
            dgvStandarts.Columns["Номер"].Visible = false;
            dgvStandarts.Columns["№ п/п"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvStandarts.Columns["№ п/п"].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        protected override bool isDateColumn(int index)
        {
            return dgvStandarts.Columns[index].HeaderText.ToLower().Contains("дата");
        }

        protected override bool isNumericColumn(int index)
        {
            return index == dgvStandarts.Columns["№ п/п"].Index
                || index == dgvStandarts.Columns["Номер"].Index;
        }

        protected override bool isTextColumn(int index)
        {
            return !(isDateColumn(index) || isNumericColumn(index));
        }

        #endregion
    }
}
