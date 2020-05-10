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
    public partial class MainForm : Form
    {
        private static DatabaseContext dbContext = DatabaseContext.Instance;
        BindingSource src;

        private int lastSortedColumnIndex = 0;
        private ListSortDirection lastSortedDirection = ListSortDirection.Ascending;
        
        public MainForm()
        {
            src = new BindingSource();
            InitializeComponent();
            dgvDocument.DataSource = src;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            RefreshDGV();
        }

        #region обработка событий на форме

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                new EditDocForm(dgvDocument.CurrentRow.Cells["Номер"].Value.ToString()).ShowDialog();
                RefreshDGV();
            }
        }

        private void ctsEdit_Click(object sender, EventArgs e)
        {
            new EditDocForm(dgvDocument.CurrentRow.Cells["Номер"].Value.ToString()).ShowDialog();
            RefreshDGV();
        }

        private void ctsDelete_Click(object sender, EventArgs e)
        {
            tsmDelete_Click(sender, e);
        }

        private void dgvDocument_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            int colIndex = e.ColumnIndex;
            if (colIndex < 0)
                colIndex = 0;

            int rowIndex = e.RowIndex;
            if (rowIndex < 0)
                rowIndex = 0;

            dgvDocument.CurrentCell = dgvDocument.Rows[rowIndex].Cells[colIndex];
            dgvDocument.Rows[rowIndex].Selected = true;
        }

        private void btnSelectAllStandarts_Click(object sender, EventArgs e)
        {
            new ReportAllStandarts().ShowDialog();
            RefreshDGV();
        }

        private void btnSelectPodrDoc_Click(object sender, EventArgs e)
        {
            new ReportPodrDocForm().ShowDialog();
            RefreshDGV();
        }

        private void ctsExport_Click(object sender, EventArgs e)
        {
            sfdExportCard.Filter = String.Format("Файлы Word(*.doc)|*.doc");
            sfdExportCard.FileName = "Карточка учета документа по стандартизации.doc";
            DialogResult dr = sfdExportCard.ShowDialog();

            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                export(dr);
            }
            if (dr == System.Windows.Forms.DialogResult.Cancel)
                return;
        }

        private void btnSelectOuterDoc_Click(object sender, EventArgs e)
        {
            new ReportDocSinceTo("Перечень документов, поступивших на предприятие", "GetOuterDocListSinceTo").ShowDialog();
            RefreshDGV();
        }

        private void btnSelectInnerDoc_Click(object sender, EventArgs e)
        {
            new ReportDocSinceTo("Перечень документов по стандартизации, разработанных на предприятии", "GetInnerDocListSinceTo").ShowDialog();
            RefreshDGV();
        }

        private void dgvDocument_MouseDown(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hitInfo = dgvDocument.HitTest(e.X, e.Y);
            if (hitInfo.Type == DataGridViewHitTestType.Cell)
            {
                cmsDocument.Enabled = true;
                dgvDocument.CurrentCell = dgvDocument.Rows[hitInfo.RowIndex].Cells[hitInfo.ColumnIndex];
                dgvDocument.Rows[hitInfo.RowIndex].Selected = true;
            }
            else
            {
                cmsDocument.Enabled = false;
            }
        }

        private void dgvDocument_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ListSortDirection lsd;
            lsd = (lastSortedDirection == ListSortDirection.Descending) ? ListSortDirection.Descending : ListSortDirection.Ascending;
            dgvDocument.Sort(dgvDocument.Columns[lastSortedColumnIndex], lsd);
            int id = Convert.ToInt32(dgvDocument.CurrentRow.Cells["Номер"].Value);
            lastSortedDirection = (dgvDocument.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == System.Windows.Forms.SortOrder.Ascending) ? ListSortDirection.Descending : ListSortDirection.Ascending;
            dgvDocument.Sort(dgvDocument.Columns[e.ColumnIndex], lastSortedDirection);
            dgvDocument.CurrentCell = dgvDocument["Обозначение", getIndexForKey(dgvDocument, "Номер", id)];
            lastSortedColumnIndex = e.ColumnIndex;
        }

        private void dgvDocument_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                ctsEdit_Click(sender, e);
            }

            if (e.KeyCode.Equals(Keys.Delete))
            {
                ctsDelete_Click(sender, e);
            }
            
            if (e.Control == true && e.KeyCode.Equals(Keys.E))
            {
                ctsEdit_Click(sender, e);
            }

            if (e.Control == true && e.KeyCode.Equals(Keys.N))
            {
                tsmAdd_Click(sender, e);
            }

            if (e.KeyCode.Equals(Keys.F5))
            {
                RefreshDGV();
            }
        }

        private void tsmAdd_Click(object sender, EventArgs e)
        {
            new AddDocForm().ShowDialog();
            RefreshDGV();
        }

        private void tsmDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удалить запись?", "Удаление записи", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                string tbVzamen = "";
                string tbZamenen = "";
                int docId = Convert.ToInt32(dgvDocument.CurrentRow.Cells["Номер"].Value);
                getVzamenZamenen(docId, ref tbVzamen, ref tbZamenen);
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

        private void tsmUpdate_Click(object sender, EventArgs e)
        {
            RefreshDGV();
        }

        private void tsmEdit_Click(object sender, EventArgs e)
        {
            ctsEdit_Click(sender, e);
            RefreshDGV();
        }

        private void tsmHelp_Click(object sender, EventArgs e)
        {
            string fileName = Application.StartupPath.ToString();
            fileName += @"\Инструкция.pdf";
            System.Diagnostics.Process.Start(fileName);
        }

        #endregion

        #region вспомогательные функции

        public void RefreshDGV() 
        {
            try
            {
                src.DataSource = dbContext.LoadFromDatabase("Kartoteka_Select", CommandType.StoredProcedure);
            }
            catch (Exception e)
            {
                MessageBox.Show("Не удалось загрузить картотеку", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FileLogger.log(LogLevel.Fatal, "Не удалось загрузить картотеку " + e.ToString());
                //this.Close();
                //return;
            }

            Refresh();
        }

        public override void Refresh()
        {
            base.Refresh();
            UpdateControls();
        }

        private void UpdateControls()
        {
            if (src.DataSource == null)
            {
                splitContainer1.Enabled = false;
                return;
            }

            dgvDocument.Columns["Номер"].Visible = false;
            dgvDocument.Columns["Номер"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dgvDocument.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            tsmAdd.Enabled = true;
            if (dgvDocument.Rows.Count == 0)
            {
                ctsDelete.Enabled = false;
                tsmDelete.Enabled = false;
                tsmEdit.Enabled = false;
                dgvDocument.Enabled = false;
            }
            else
            {
                ctsDelete.Enabled = true;
                tsmDelete.Enabled = true;
                tsmEdit.Enabled = true;
                dgvDocument.Enabled = true;
            }

            lastSortedColumnIndex = dgvDocument.Columns["Номер"].Index;
            dgvDocument.Sort(dgvDocument.Columns["Номер"], ListSortDirection.Ascending);
            dgvDocument.Focus();
        }

        public static void getVzamenZamenen(int docId, ref string tbVzamen, ref string tbZamenen)
        {
            using (SqlCommand com = dbContext._connection.CreateCommand())
            {
                try
                {
                    dbContext._connection.Open();
                    com.CommandText = "Select k2.obozn vzamenobozn, k3.obozn zamenenobozn from Kart k left join kart k2 on k2.id = k.vzamen left join kart k3 on k3.id = k.zamenen where k.id = " + docId.ToString();
                    com.CommandType = CommandType.Text;

                    SqlDataReader reader = com.ExecuteReader();
                    reader.Read();
                    tbVzamen = reader["vzamenobozn"].ToString();
                    tbZamenen = reader["zamenenobozn"].ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Не удалось удалить карточку", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    FileLogger.log(LogLevel.Fatal, "Не удалось удалить карточку " + ex.ToString());
                    return;
                }
                finally
                {
                    dbContext._connection.Close();
                }
            }
        }

        private void export(System.Windows.Forms.DialogResult dr)
        {
            Dictionary<string, string> paramDic = new Dictionary<string, string>();
            DataTable tableChanging = new DataTable();
            DataTable tableDepartments = new DataTable();

            createDocumentParams(paramDic);

            createTableChanges(ref tableChanging, dgvDocument.CurrentRow.Cells["Номер"].Value.ToString());

            createTableDepartments(ref tableDepartments, dgvDocument.CurrentRow.Cells["Номер"].Value.ToString());

            new ProgressForm(new ExporterKartToWORD(paramDic, new DataView(tableChanging), new DataView(tableDepartments)), sfdExportCard.FileName).ShowDialog();
        }

        private void createDocumentParams(Dictionary<string, string> paramDic)
        {
            using (SqlCommand com = dbContext._connection.CreateCommand())
            {
                try
                {
                    dbContext._connection.Open();
                    com.CommandText = "SelectCardForPrint";
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@docid", Convert.ToInt32(dgvDocument.CurrentRow.Cells["Номер"].Value));

                    SqlDataReader reader = com.ExecuteReader();
                    reader.Read();

                    createParamsForExport(paramDic, reader);

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Не удалось загрузить данные о карточке!", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    FileLogger.log(LogLevel.Error, "Не удалось загрузить карточку с id = " + dgvDocument.CurrentRow.Cells["Номер"].Value.ToString() + " в форму редактирования карточки. " + ex.ToString());
                    return;
                }
                finally
                {
                    dbContext._connection.Close();
                }
            }
        }

        private void createTableChanges(ref DataTable tableChanges, string docId)
        {
            try
            {
                tableChanges = dbContext.LoadFromDatabase("DocChange_select", new Dictionary<string, object> { { "@Tpodr", "DocChange" }, { "@id", docId } }, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось загрузить изменения", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                FileLogger.log(LogLevel.Fatal, "Не удалось загрузить изменения для документа с id = " + docId + " из таблицы " + "DocChange" + ". " + ex.ToString());
                return;
            }
            finally
            {
                dbContext._connection.Close();
            }
        }

        private void createTableDepartments(ref DataTable tableDepartments, string docId)
        {
            try
            {
                tableDepartments = dbContext.LoadFromDatabase("SelectLastDocPodr", new Dictionary<string, object> { { "@TName", "podrDoc" }, { "@docId", docId }, { "@depId", 0 } }, CommandType.StoredProcedure);
                DocForm.deleteTakedateIfCopyInStock(tableDepartments);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось загрузить экземпляры выданные в подразделение", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                FileLogger.log(LogLevel.Fatal, "Не удалось загрузить экземпляры выданные в подразделения из таблицы " + "podrDoc" + " для документа с id = " + docId.ToString() + ". " + ex.ToString());
            }
            finally
            {
                dbContext._connection.Close();
            }
        }

        private void createParamsForExport(Dictionary<string, string> paramsDictionary, SqlDataReader reader)
        {
            paramsDictionary.Add("docId", reader["Номер"].ToString());
            paramsDictionary.Add("Тип", reader["Тип"].ToString());
            paramsDictionary.Add("Обозначение", reader["Обозначение"].ToString());
            paramsDictionary.Add("Наименование", reader["Наименование"].ToString());
            paramsDictionary.Add("Оригинал", reader["Оригинал"].ToString());
            paramsDictionary.Add("Контрольная копия", reader["Копия"].ToString());
            paramsDictionary.Add("Дата введения", reader["Дата введения"].ToString());
            paramsDictionary.Add("Дата окончания", reader["Дата окончания"].ToString());
            paramsDictionary.Add("Статус", reader["Статус"].ToString());
            paramsDictionary.Add("Секретность", reader["Секретность"].ToString());
            paramsDictionary.Add("Разработчик", reader["Разработчик"].ToString());

            paramsDictionary.Add("Запрос номер", reader["Запрос номер"].ToString());
            paramsDictionary.Add("Запрос дата", reader["Запрос дата"].ToString());
            paramsDictionary.Add("Запрос адрес", reader["Запрос адрес"].ToString());

            paramsDictionary.Add("Получение номер", reader["Получение номер"].ToString());
            paramsDictionary.Add("Получение дата регистрации", reader["Получение дата регистрации"].ToString());
            paramsDictionary.Add("Получение дата", reader["Получение дата"].ToString());
            paramsDictionary.Add("Получение количество", reader["Получение количество"].ToString());
            paramsDictionary.Add("Получение адрес", reader["Получение адрес"].ToString());

            paramsDictionary.Add("Взамен обозначение", reader["Взамен обозначение"].ToString());
            paramsDictionary.Add("Взамен наименование", reader["Взамен наименование"].ToString());

            paramsDictionary.Add("Заменен тип", reader["Заменен тип"].ToString());
            paramsDictionary.Add("Заменен обозначение", reader["Заменен обозначение"].ToString());
            paramsDictionary.Add("Заменен наименование", reader["Заменен наименование"].ToString());
            paramsDictionary.Add("Заменен дата", reader["Заменен дата"].ToString());

            paramsDictionary.Add("Внедрение номер", reader["Внедрение номер"].ToString());
            paramsDictionary.Add("Внедрение дата", reader["Внедрение дата"].ToString());
            paramsDictionary.Add("Внедрение подразделение индекс", reader["Внедрение подразделение индекс"].ToString());
            paramsDictionary.Add("Внедрение подразделение наименование", reader["Внедрение подразделение наименование"].ToString());
            paramsDictionary.Add("Внедрение приказ", reader["Внедрение приказ"].ToString());
            paramsDictionary.Add("Внедрение дата приказ", reader["Внедрение дата приказ"].ToString());
            paramsDictionary.Add("Внедрение дата ОТМ", reader["Внедрение дата ОТМ"].ToString());
            paramsDictionary.Add("Внедрение дата введение", reader["Внедрение дата введение"].ToString());

            paramsDictionary.Add("Акт внедрение номер", reader["Акт внедрение номер"].ToString());
            paramsDictionary.Add("Акт внедрение дата", reader["Акт внедрение дата"].ToString());
            paramsDictionary.Add("Акт проверка номер", reader["Акт проверка номер"].ToString());
            paramsDictionary.Add("Акт проверка дата", reader["Акт проверка дата"].ToString());

            paramsDictionary.Add("Проверка дата", reader["Проверка дата"].ToString());
        }

        private int getIndexForKey(DataGridView dgv, string colName, int key)
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

        #endregion
    }
}
