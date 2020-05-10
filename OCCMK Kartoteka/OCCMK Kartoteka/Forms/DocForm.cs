using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using OCCMK_Kartoteka.Forms;

namespace OCCMK_Kartoteka
{
    public partial class DocForm : Form
    {
        protected DatabaseContext dbContext = DatabaseContext.Instance;

        //словари для комбобоксов
        protected Dictionary<string, int> StatusDictionary = new Dictionary<string, int>();
        protected Dictionary<string, int> SecurityDictionary = new Dictionary<string, int>();
        protected Dictionary<string, int> DeveloperDictionary = new Dictionary<string, int>();

        protected int? ZamID;
        protected int? VzamID;
        protected int? podrID = 0;
        protected int? depID = 0;

        protected BindingSource srcDgvChanging;
        protected BindingSource srcDgvDepartment;

        protected string tableChangingName;
        protected string tableDepartmentName;
        protected string docId;

        private int lastSortedChangingColumnIndex = 0;
        private ListSortDirection lastSortedChangingDirection = ListSortDirection.Ascending;
        private int lastSortedDepartmentColumnIndex = 4;
        private ListSortDirection lastSortedDepartmentDirection = ListSortDirection.Ascending;

        public DocForm()
        {
            InitializeComponent();
        }

        protected virtual void DocForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        #region обработка событий на форме
        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected virtual void btnAction_Click(object sender, EventArgs e)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Функция действия не реализована", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FileLogger.log(LogLevel.Fatal, "Функция действия не реализована. " + ex.ToString());
                return;
            }
        }

        private void btnSelectVzamen_Click(object sender, EventArgs e)
        {
            SelectForm sf = new SubstitutionSelectForm("Zamena_select", null, (VzamID == null ? 0 : (int)VzamID));
            sf.Controls["btnAdd"].Visible = false;
            sf.Controls["btnEdit"].Visible = false;
            sf.Controls["btnDelete"].Visible = false;
            sf.ShowDialog();

            if (Data.Value != null) { tbVzamen.Text = Data.Value; VzamID = Data.IDval; }
            Data.IDval = null;
            Data.Value = null;
            
         }

        private void btnSelectZamenen_Click(object sender, EventArgs e)
        {
            SelectForm sf = new SubstitutionSelectForm("Zamena_select", null, (ZamID == null ? 0 : (int)ZamID));
            sf.Controls["btnAdd"].Visible = false;
            sf.Controls["btnEdit"].Visible = false;
            sf.Controls["btnDelete"].Visible = false;
            sf.ShowDialog();

            if (Data.Value != null) { tbZamenen.Text = Data.Value; ZamID = Data.IDval; }
            Data.IDval = null;
            Data.Value = null;
        }

        private void btnClearTbVzamen_Click(object sender, EventArgs e)
        {
            tbVzamen.Clear();
            VzamID = null;
        }

        private void btnClearTbZamenen_Click(object sender, EventArgs e)
        {
            tbZamenen.Clear();
            ZamID = null;
        }

        private void btnSelectInceptionResponseDepartment_Click(object sender, EventArgs e)
        {
            new DepartamentSelectForm("select id ,code [Код], name [Обозначение] from Departments", "Departments", (int)podrID).ShowDialog();

            if (Data.Value != null) { tbResponseInceptionDepartment.Text = Data.Value; podrID = Data.IDval; }
            Data.IDval = null;
            Data.Value = null;
        }

        private void btnAddChanging_Click(object sender, EventArgs e)
        {
            new AddDocChangeForm(tableChangingName, docId).ShowDialog();
            RefreshDGV();
        }

        private void btnDeleteChanging_Click(object sender, EventArgs e)
        {
            if (dgvChanging.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Удалить изменение?", "Удаление записи", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        dbContext.ExecuteCommand("delete from " + tableChangingName + " where id='" + dgvChanging.CurrentRow.Cells["id"].Value.ToString() + "'", CommandType.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Не удалось удалить изменение", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        FileLogger.log(LogLevel.Error, "Не удалось удалить изменение с id = " + dgvChanging.CurrentRow.Cells["id"].Value.ToString() + " из таблицы " + tableChangingName + ". " + ex.ToString());
                        return;
                    }
                    finally
                    {
                        dbContext._connection.Close();
                    }
                    MessageBox.Show("Запись удалена!", "Удаление записи", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FileLogger.log(LogLevel.Info, "Изменение с id = " + dgvChanging.CurrentRow.Cells["id"].Value.ToString() + " из таблицы " + tableChangingName + " удалено. ");
                    RefreshDGV();
                }
            }
            else 
            {
                MessageBox.Show("Не выделена запись для удаления!");
            }
        }

        private void btnAddDepartment_Click(object sender, EventArgs e)
        {
            DocToDepartmentForm dtdf;
            if (!tbSelectedDepartmentForDoc.Text.Equals("") && rbSelectDepartmentForDoc.Checked)
            {
                dtdf = new AddDocToDepartmentForm(tableDepartmentName, docId, (int)depID);
            }
            else
            {
                dtdf = new AddDocToDepartmentForm(tableDepartmentName, docId);
            }
            dtdf.ShowDialog();
            RefreshDGV();
        }

        private void btnDeleteDepartment_Click(object sender, EventArgs e)
        {
            if (dgvDepartment.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Удалить экземпляр?", "Удаление экземпляра", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        dbContext.ExecuteCommand("delete from " + tableDepartmentName + " where id='" + dgvDepartment.CurrentRow.Cells["id"].Value.ToString() + "'", CommandType.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Не удалось удалить экземпляр выданный в подразделение", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        FileLogger.log(LogLevel.Error, "Не удалось удалить экземпляр с id = " + dgvDepartment.CurrentRow.Cells["id"].Value.ToString() + " из таблицы " + tableDepartmentName + ". " + ex.ToString());
                        return;
                    }
                    finally
                    {
                        dbContext._connection.Close();
                    }
                    MessageBox.Show("Запись удалена!", "Удаление записи", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshDGV();
                }
            }
            else
            {
                MessageBox.Show("Не выделена запись для удаления!");
            }
        }

        private void rbSelectDepartmentForDoc_CheckedChanged(object sender, EventArgs e)
        {
            RefreshDGV();
        }

        private void btnSelectDepartmentForDoc_Click(object sender, EventArgs e)
        {
            new DepartamentSelectForm("select id ,code [Код], name [Обозначение] from Departments", "Departments", (int)depID).ShowDialog();

            if (Data.Value != null) { tbSelectedDepartmentForDoc.Text = Data.Value; depID = Data.IDval; }
            RefreshDGV();
            Data.IDval = null;
            Data.Value = null;
        }

        private void rbAllDepartmentForDoc_CheckedChanged(object sender, EventArgs e)
        {
            RefreshDGV();
        }

        private void btnClearTbDepartment_Click(object sender, EventArgs e)
        {
            tbResponseInceptionDepartment.Clear();
            podrID = 0;
        }

        protected void rbOuterDocument_CheckedChanged(object sender, EventArgs e)
        {
            RefreshDGV();
        }

        private void btnSelectStatus_Click(object sender, EventArgs e)
        {
            SelectForm sf = new SelectForm("Select distinct id,status [Статус] from docstatus", "DocStatus", cmbStatus.SelectedIndex != -1 ? StatusDictionary[cmbStatus.SelectedItem.ToString()] : 0);
            sf.Text = "Выбор статуса документа";
            sf.Controls["btnAdd"].Visible = false;
            sf.Controls["btnEdit"].Visible = false;
            sf.Controls["btnDelete"].Visible = false;
            sf.ShowDialog();

            cmbStatus.Items.Clear();
            StatusDictionary.Clear();
            fillCmbStatus();

            if (Data.Value != null)
                cmbStatus.Text = Data.Value;

            Data.Value = null;
        }

        private void btnSelectSecurity_Click(object sender, EventArgs e)
        {
            SelectForm sf = new SelectForm("Select distinct id,docSecret [Вид секретности] from DocSecret", "DocSecret", cmbSecurity.SelectedIndex != -1 ? SecurityDictionary[cmbSecurity.SelectedItem.ToString()] : 0);
            sf.Text = "Выбор вида секретности";
            sf.ShowDialog();

            cmbSecurity.Items.Clear();
            SecurityDictionary.Clear();
            fillCmbSecurity();

            if (Data.Value != null)
                cmbSecurity.Text = Data.Value;

            Data.Value = null;
        }

        private void btnSelectDeveloper_Click(object sender, EventArgs e)
        {
            SelectForm sf = new SelectForm("Select distinct id,developer [Разработчик] from Developer", "Developer", cmbDeveloper.SelectedIndex != -1 ? DeveloperDictionary[cmbDeveloper.SelectedItem.ToString()] : 0);
            sf.Text = "Выбор разработчика";
            sf.ShowDialog();

            cmbDeveloper.Items.Clear();
            cmbAdressOfReceiver.Items.Clear();
            cmbQueryAdress.Items.Clear();
            DeveloperDictionary.Clear();
            fillCmbDeveloper();

            if (Data.Value != null)
                cmbDeveloper.Text = Data.Value;

            Data.Value = null;
        }

        private void dgvChanging_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ListSortDirection lsd;
            lsd = (lastSortedChangingDirection == ListSortDirection.Descending) ? ListSortDirection.Descending : ListSortDirection.Ascending;
            dgvChanging.Sort(dgvChanging.Columns[lastSortedChangingColumnIndex], lsd);
            int id = Convert.ToInt32(dgvChanging.CurrentRow.Cells["id"].Value);
            lastSortedChangingDirection = (dgvChanging.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == System.Windows.Forms.SortOrder.Ascending) ? ListSortDirection.Descending : ListSortDirection.Ascending;
            dgvChanging.Sort(dgvChanging.Columns[e.ColumnIndex], lastSortedChangingDirection);
            dgvChanging.CurrentCell = dgvChanging["Номер", getIndexForKey(dgvChanging, "id", id)];
            lastSortedChangingColumnIndex = e.ColumnIndex;
        }

        private void dgvDepartment_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ListSortDirection lsd;
            lsd = (lastSortedDepartmentDirection == ListSortDirection.Descending) ? ListSortDirection.Descending : ListSortDirection.Ascending;
            dgvDepartment.Sort(dgvDepartment.Columns[lastSortedDepartmentColumnIndex], lsd);
            int id = Convert.ToInt32(dgvDepartment.CurrentRow.Cells["id"].Value);

            lastSortedDepartmentDirection = (dgvDepartment.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == System.Windows.Forms.SortOrder.Ascending) ? ListSortDirection.Descending : ListSortDirection.Ascending;
            dgvDepartment.Sort(dgvDepartment.Columns[e.ColumnIndex], lastSortedDepartmentDirection);
            dgvDepartment.CurrentCell = dgvDepartment["Номер экземпляра", getIndexForKey(dgvDepartment, "id", id)];
            lastSortedDepartmentColumnIndex = e.ColumnIndex;
        }

        protected void btnEditChanging_Click(object sender, EventArgs e)
        {
            if (dgvChanging.SelectedCells.Count > 0)
            {
                new EditDocChangeForm(tableChangingName, docId, dgvChanging.CurrentRow.Cells["id"].Value.ToString()).ShowDialog();
                RefreshDGV();
            }
        }

        protected void btnEditDepartment_Click(object sender, EventArgs e)
        {
            if (dgvDepartment.SelectedCells.Count > 0)
            {
                new EditDocToDepartmentForm(tableDepartmentName, docId, dgvDepartment.CurrentRow.Cells["id"].Value.ToString()).ShowDialog();
                RefreshDGV();
            }
        }

        protected virtual void dgvChanging_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEditChanging_Click(sender, e);
        }

        private void dgvChanging_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                btnEditChanging_Click(sender, e);
            }

            if (e.KeyCode.Equals(Keys.Delete))
            {
                btnDeleteChanging_Click(sender, e);
            }

            if (e.Control == true && e.KeyCode.Equals(Keys.E))
            {
                btnEditChanging_Click(sender, e);
            }

            if (e.Control == true && e.KeyCode.Equals(Keys.N))
            {
                btnAddChanging_Click(sender, e);
            }

            if (e.KeyCode.Equals(Keys.F5))
            {
                RefreshDGV();
            }
        }

        protected virtual void dgvDepartment_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEditDepartment_Click(sender, e);
        }

        private void dgvDepartment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                btnEditDepartment_Click(sender, e);
            }

            if (e.KeyCode.Equals(Keys.Delete))
            {
                btnDeleteDepartment_Click(sender, e);
            }

            if (e.Control == true && e.KeyCode.Equals(Keys.E))
            {
                btnEditDepartment_Click(sender, e);
            }

            if (e.Control == true && e.KeyCode.Equals(Keys.N))
            {
                btnAddDepartment_Click(sender, e);
            }

            if (e.KeyCode.Equals(Keys.F5))
            {
                RefreshDGV();
            }
        }

        #endregion

        #region вспомогательные функции
        
        #region проверки введенных данных

        protected bool isAllInnerFieldCorrect()
        {
            bool isCorrect = true;

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl.Name != "gbQueryInformation" && ctrl.Name != "gbReceiveInformation" && ctrl.Name != "gbVzamenZamenen")
                {
                    foreach (Control ctr2 in ctrl.Controls)
                    {
                        if (ctr2.Text.Trim().Equals("") && ctr2.GetType().ToString() != "System.Windows.Forms.DataGridView" && ctr2.Name != "tbSelectedDepartmentForDoc")
                        { isCorrect = false; ctr2.BackColor = Color.Crimson; }
                    }
                }
            }

            return isCorrect;
        }

        protected bool isAllOuterFieldCorrect()
        {
            bool isCorrect = isAllInnerFieldCorrect();

            Control query = this.Controls["gbQueryInformation"];
            foreach (Control ctr in query.Controls)
            {
                if (ctr.Text.Trim().Equals(""))
                { isCorrect = false; ctr.BackColor = Color.Crimson; }
            }

            Control receive = this.Controls["gbReceiveInformation"];
            foreach (Control ctr in receive.Controls)
            {
                if (ctr.Text.Trim().Equals(""))
                { isCorrect = false; ctr.BackColor = Color.Crimson; }
            }

            return isCorrect;
        }

        protected bool isSecuriryCorrect()
        {
            if (!cmbSecurity.Items.Contains(cmbSecurity.Text.Trim()))
            {
                cmbSecurity.BackColor = Color.Yellow;
                MessageBox.Show("Не корректно заполненно значение из выпадающего списка видов секретности! \nЗначение должно совпадать с уже имеющемся в списке.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        protected bool isStatusCorrect()
        {
            if (!cmbStatus.Items.Contains(cmbStatus.Text.Trim()))
            {
                cmbStatus.BackColor = Color.Yellow;
                MessageBox.Show("Не корректно заполненно значение из выпадающего списка статусов! \nЗначение должно совпадать с уже имеющемся в списке.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        protected bool isDeveloperCorrect()
        {
            if (!cmbDeveloper.Items.Contains(cmbDeveloper.Text.Trim()))
            {
                cmbDeveloper.BackColor = Color.Yellow;
                MessageBox.Show("Не корректно заполненно значение из выпадающего списка разработчиков! \nЗначение должно совпадать с уже имеющемся в списке.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        protected bool isQueryAddressCorrect()
        {
            if (!cmbQueryAdress.Items.Contains(cmbQueryAdress.Text.Trim()))
            {
                cmbQueryAdress.BackColor = Color.Yellow;
                MessageBox.Show("Не корректно заполненно значение из выпадающего списка! \nЗначение должно совпадать с уже имеющемся в списке.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        protected bool isAddressOfReceiverCorrect()
        {
            if (!cmbAdressOfReceiver.Items.Contains(cmbAdressOfReceiver.Text.Trim()))
            {
                cmbAdressOfReceiver.BackColor = Color.Yellow;
                MessageBox.Show("Не корректно заполненно значение из выпадающего списка! \nЗначение должно совпадать с уже имеющемся в списке.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        protected bool isGettingCountCorrect()
        {
            bool returnedValue = false;
            try
            {
                returnedValue |= (tbGettingCount.Text == "");
                Convert.ToInt32(tbGettingCount.Text);
                returnedValue |= true;
            }
            catch
            {
                tbGettingCount.BackColor = Color.Yellow;
                MessageBox.Show("Не удалось прочитать количесво копий.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return returnedValue;
        }

        #endregion

        protected void FillAllCombobox()
        {
            fillCmbStatus();
            fillCmbSecurity();
            fillCmbDeveloper();
        }

        private void fillCmbStatus()
        {
            using (SqlCommand com = dbContext._connection.CreateCommand())
            {
                try
                {
                    dbContext._connection.Open();
                    com.CommandText = "Select distinct id, status from docstatus order by status";
                    com.CommandType = CommandType.Text;
                    SqlDataReader reader = com.ExecuteReader();

                    while (reader.Read())
                    {
                        cmbStatus.Items.Add((reader["status"]).ToString());
                        StatusDictionary.Add((reader["status"]).ToString(), Convert.ToInt32((reader["id"])));
                    }
                    reader.Close();

                    cmbStatus.AutoCompleteSource = AutoCompleteSource.ListItems;
                    cmbStatus.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Не удалось загрузить статусы документов", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    FileLogger.log(LogLevel.Error, "Не удалось загрузить данные из таблицы DocStatus. " + ex.ToString());
                    return;
                }
                finally
                {
                    dbContext._connection.Close();
                }
            }
        }

        private void fillCmbSecurity()
        {
            using (SqlCommand com = dbContext._connection.CreateCommand())
            {
                try
                {
                    dbContext._connection.Open();
                    com.CommandText = "Select distinct id,docSecret from DocSecret order by docSecret";
                    com.CommandType = CommandType.Text;
                    SqlDataReader reader = com.ExecuteReader();
                    while (reader.Read())
                    {
                        cmbSecurity.Items.Add((reader["docSecret"]).ToString());
                        SecurityDictionary.Add((reader["docSecret"]).ToString(), Convert.ToInt32((reader["id"])));
                    }
                    reader.Close();

                    cmbSecurity.AutoCompleteSource = AutoCompleteSource.ListItems;
                    cmbSecurity.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Не удалось загрузить виды секретности документов", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    FileLogger.log(LogLevel.Error, "Не удалось загрузить данные из таблицы DocSecret. " + ex.ToString());
                    return;
                }
                finally
                {
                    dbContext._connection.Close();
                }
            }
        }

        private void fillCmbDeveloper()
        {
            using (SqlCommand com = dbContext._connection.CreateCommand())
            {
                try
                {
                    dbContext._connection.Open();
                    com.CommandText = "Select distinct id,developer  from Developer order by developer";
                    com.CommandType = CommandType.Text;
                    SqlDataReader reader = com.ExecuteReader();
                    while (reader.Read())
                    {
                        cmbDeveloper.Items.Add((reader["developer"]).ToString());
                        cmbQueryAdress.Items.Add((reader["developer"]).ToString());
                        cmbAdressOfReceiver.Items.Add((reader["developer"]).ToString());
                        DeveloperDictionary.Add((reader["developer"]).ToString(), Convert.ToInt32((reader["id"])));
                    }
                    reader.Close();

                    cmbDeveloper.AutoCompleteSource = AutoCompleteSource.ListItems;
                    cmbDeveloper.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

                    cmbQueryAdress.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    cmbQueryAdress.AutoCompleteSource = AutoCompleteSource.ListItems;
                    cmbAdressOfReceiver.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    cmbAdressOfReceiver.AutoCompleteSource = AutoCompleteSource.ListItems;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Не удалось загрузить разработчиков документов", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    FileLogger.log(LogLevel.Error, "Не удалось загрузить данные из таблицы Developer. " + ex.ToString());
                    return;
                }
                finally
                {
                    dbContext._connection.Close();
                }
            }
        }

        private void ClearDictionaryAndCombobox()
        {
            cmbStatus.Items.Clear();
            cmbSecurity.Items.Clear();
            cmbDeveloper.Items.Clear();
            cmbQueryAdress.Items.Clear();
            cmbAdressOfReceiver.Items.Clear();

            StatusDictionary.Clear();
            SecurityDictionary.Clear();
            DeveloperDictionary.Clear();
        }

        private int getCountReturnedCopies()
        {
            int returnCount = 0;
            using (SqlCommand com = dbContext._connection.CreateCommand())
            {
                int department = rbAllDepartmentForDoc.Checked ? 0 : (int)depID;
                try
                {
                    dbContext._connection.Open();
                    com.CommandText = "TotalCountReturnedCopies";
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@TName", tableDepartmentName);
                    com.Parameters.AddWithValue("@docId", docId);
                    com.Parameters.AddWithValue("@depId", department);
                    
                    SqlDataReader reader = com.ExecuteReader();
                    reader.Read();
                    returnCount = Convert.ToInt32(reader[0]);
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Не удалось посчитать количество возвращенных экземпляров из подразделения", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    FileLogger.log(LogLevel.Error, "Не удалось посчитать количество возвращенных экземпляров из подразделения с id = " + department.ToString() + " из таблицы " + tableDepartmentName + " для документа с id = " + docId.ToString() + ". " + ex.ToString());
                    return 0;
                }
                finally
                {
                    dbContext._connection.Close();
                }
            }
            return returnCount;
        }

        protected void RefreshDGV() 
        {
            base.Refresh();
            refreshChanges();
            refreshDepartments();
            UpdateControls();
        }

        private void refreshChanges()
        {
            try
            {
                srcDgvChanging.DataSource = dbContext.LoadFromDatabase("DocChange_select", new Dictionary<string, object> { { "@Tpodr", tableChangingName }, { "@id", docId } }, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось загрузить измененияrefreshChanges", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                FileLogger.log(LogLevel.Error, "Не удалось загрузить изменения для документа с id = " + docId.ToString() + " из таблицы " + tableChangingName + ". " + ex.ToString());
                return;
            }
        }

        private void refreshDepartments()
        {
            int department = rbAllDepartmentForDoc.Checked ? 0 : (int)depID;
            try
            {
                srcDgvDepartment.DataSource = dbContext.LoadFromDatabase("SelectLastDocPodr", new Dictionary<string, object> { { "@TName", tableDepartmentName }, { "@docId",docId }, { "@depId", department } }, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось загрузить экземпляры выданные в подразделение", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                FileLogger.log(LogLevel.Error, "Не удалось загрузить экземпляры выданные в подразделение с id = " + department.ToString() + " из таблицы " + tableDepartmentName + " для документа с id = " + docId.ToString() + ". " + ex.ToString());
                return;
            }
        }

        private void UpdateControls()
        {
            if (rbOuterDocument.Checked == true)
            {
                gbQueryInformation.Enabled = true;
                gbReceiveInformation.Enabled = true;
            }
            else
            {
                gbQueryInformation.Enabled = false;
                gbReceiveInformation.Enabled = false;
            }

            if (rbSelectDepartmentForDoc.Checked)
            {
                btnSelectDepartmentForDoc.Enabled = true;
            }
            else
            {
                btnSelectDepartmentForDoc.Enabled = false;
            }

            UpdateChanges();
            UpdateDocToDepartments();
        }

        protected virtual void UpdateChanges()
        {
            if (srcDgvChanging.DataSource == null)
            {
                gbChangeing.Enabled = false;
                return;
            }
            if (dgvChanging.Rows.Count == 0)
            {
                btnDeleteChanging.Enabled = false;
                btnEditChanging.Enabled = false;
                dgvChanging.Enabled = false;
            }
            else
            {
                btnDeleteChanging.Enabled = true;
                btnEditChanging.Enabled = true;
                dgvChanging.Enabled = true;
            }

            dgvChanging.Columns["id"].Visible = false;
        }
        
        protected virtual void UpdateDocToDepartments()
        {
            if (srcDgvDepartment.DataSource == null)
            {
                gbDocToDepartment.Enabled = false;
                return;
            }

            if (dgvDepartment.Rows.Count == 0)
            {
                btnDeleteDepartment.Enabled = false;
                btnEditDepartment.Enabled = false;
                dgvDepartment.Enabled = false;
            }
            else
            {
                btnDeleteDepartment.Enabled = true;
                btnEditDepartment.Enabled = true;
                dgvDepartment.Enabled = true;
            }
            lblTotalCopyCount.Text = "Количество экземпляров: " + srcDgvDepartment.Count;
            lblReturnCopyCount.Text = "Количество списанных копий: " + getCountReturnedCopies();

            dgvDepartment.Columns["id"].Visible = false;
            dgvDepartment.Columns["Индекс подразделения"].Visible = false;
            dgvDepartment.Columns["Номер документа"].Visible = false;
            dgvDepartment.Columns["Имя подразделения"].Visible = false;
            
            deleteTakedateIfCopyInStock((DataTable)srcDgvDepartment.DataSource);
        }

        public static void deleteTakedateIfCopyInStock(DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Columns["Дата списания"].ReadOnly = false;
                if (dt.Rows[i]["Статус"].Equals("Выдан"))
                    dt.Rows[i]["Дата списания"] = DBNull.Value;
            }
        }

        protected void createInnerParams(Dictionary<string, object> paramsDictionary)
        {
            //параметры для таблицы Kart
            paramsDictionary.Add("@doctype", rbOuterDocument.Checked == true ? "1" : "2");
            paramsDictionary.Add("@obozn", Convert.ToString(tbDocumentOboznachenine.Text).Trim());
            paramsDictionary.Add("@name", Convert.ToString(tbDocumentName.Text).Trim());
            if (dtpEnterDate.Checked) { paramsDictionary.Add("@dateenter", dtpEnterDate.Value.Date); } else { paramsDictionary.Add("@dateenter", null); }
            paramsDictionary.Add("@stat", Convert.ToString(StatusDictionary[cmbStatus.Text]).Trim());
            paramsDictionary.Add("@secr", Convert.ToString(SecurityDictionary[cmbSecurity.Text]).Trim());
            paramsDictionary.Add("@dev", Convert.ToString(DeveloperDictionary[cmbDeveloper.Text]).Trim());
            if (dtpDateOfCheck.Checked) { paramsDictionary.Add("@dateprov", dtpDateOfCheck.Value.Date); } else { paramsDictionary.Add("@dateprov", null); }
            paramsDictionary.Add("@contrcopy", chbControlCopy.Checked == true ? 1 : 0);
            paramsDictionary.Add("@original", chbOriginal.Checked == true ? 1 : 0);

            //взамен какого документа
            paramsDictionary.Add("@vzamen", VzamID);
            paramsDictionary.Add("@zamenen", ZamID);

            //информация о введении в дейсвие документа на предприятии
            paramsDictionary.Add("@poruchnum", Convert.ToString(tbPoruchenieNumber.Text).Trim());
            if (dtpInceptionDate.Checked) { paramsDictionary.Add("@poruchdate", dtpInceptionDate.Value.Date); } else { paramsDictionary.Add("@poruchdate", null); }
            paramsDictionary.Add("@podrId", podrID);
            paramsDictionary.Add("@ordernum", Convert.ToString(tbOrderNumber.Text).Trim());
            if (dtpDateOfOrder.Checked) { paramsDictionary.Add("@orderdate", dtpDateOfOrder.Value.Date); } else { paramsDictionary.Add("@orderdate", null); }
            if (dtpOtmFinishDate.Checked) { paramsDictionary.Add("@otmdate", dtpOtmFinishDate.Value.Date); } else { paramsDictionary.Add("@otmdate", null); }
            if (dtpEnteringOnPlantDate.Checked) { paramsDictionary.Add("@vveddate", dtpEnteringOnPlantDate.Value.Date); } else { paramsDictionary.Add("@vveddate", null); }

            //акт о внедрении докумнета
            paramsDictionary.Add("@actvnednum", Convert.ToString(tbActOfInceptionNumber.Text).Trim());
            if (dtpActOfInceptionDate.Checked) { paramsDictionary.Add("@actvneddate", dtpActOfInceptionDate.Value.Date); } else { paramsDictionary.Add("@actvneddate", null); }
            

            //акт о проверке докумнета
            paramsDictionary.Add("@actprovnum", Convert.ToString(tbActOfCheckingNumber.Text).Trim());
            if (dtpActOfChecking.Checked) { paramsDictionary.Add("@actprovdate", dtpActOfChecking.Value.Date); } else { paramsDictionary.Add("@actprovdate", null); }

            //дата окончания действия стандарта
            if (dtpEndDate.Checked) {paramsDictionary.Add("@enddate", dtpEndDate.Value.Date);} else {paramsDictionary.Add("@enddate", null);}

            //изменения(поправки)
            paramsDictionary.Add("@chtabname", Convert.ToString(tableChangingName).Trim());

            //документ выдан в подразделение
            paramsDictionary.Add("@docpodr", Convert.ToString(tableDepartmentName).Trim());
        }

        protected void createOuterParams(Dictionary<string, object> paramsDictionary)
        {
            createInnerParams(paramsDictionary);

            //параметры для таблицы ZaprosInfo
            paramsDictionary.Add("@zapnum", Convert.ToString(tbQueryNumber.Text).Trim());
            if (dtpQueryDate.Checked) { paramsDictionary.Add("@zapdat", dtpQueryDate.Value.Date); } else { paramsDictionary.Add("@zapdat", null); }
            paramsDictionary.Add("@zapadr", Convert.ToString(DeveloperDictionary[cmbQueryAdress.Text]).Trim());

            //параметры для таблицы PoluchatelInfo
            paramsDictionary.Add("@polnum", Convert.ToString(tbGettingNumber.Text).Trim());
            if (dtpDateOfReg.Checked) { paramsDictionary.Add("@polregdate", dtpDateOfReg.Value.Date); } else { paramsDictionary.Add("@polregdate", null); }
            if (dtpDateOfReceiving.Checked) { paramsDictionary.Add("@poldate", dtpDateOfReceiving.Value.Date); } else { paramsDictionary.Add("@poldate", null); }
            paramsDictionary.Add("@kolvo", tbGettingCount.Text.Trim());
            paramsDictionary.Add("@poladr", Convert.ToString(DeveloperDictionary[cmbAdressOfReceiver.Text]).Trim());
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

        #region возвращаем текстбоксам и комбобоксам стандартный цвет

        private void tbDocumentOboznachenie_TextChanged(object sender, EventArgs e)
        {
            tbDocumentOboznachenine.BackColor = Color.White;
        }

        private void tbDocumentName_TextChanged(object sender, EventArgs e)
        {
            tbDocumentName.BackColor = Color.White;
        }

        private void cmbSecurity_TextChanged(object sender, EventArgs e)
        {  
            cmbSecurity.BackColor = Color.White;
        }

        private void cmbStatus_TextChanged(object sender, EventArgs e)
        {
            cmbStatus.BackColor = Color.White;
        }

        private void cmbDeveloper_TextChanged(object sender, EventArgs e)
        {
            cmbDeveloper.BackColor = Color.White;
        }

        private void cmbStatus_DropDown(object sender, EventArgs e)
        {
            cmbStatus.BackColor = Color.White;
        }

        private void cmbDeveloper_DropDown(object sender, EventArgs e)
        {
            cmbDeveloper.BackColor = Color.White;
        }

        private void cmbSecurity_DropDown(object sender, EventArgs e)
        {
            cmbSecurity.BackColor = Color.White;
        }

        private void tbPoruchenieNumber_TextChanged(object sender, EventArgs e)
        {
            tbPoruchenieNumber.BackColor = Color.White;
        }

        private void tbResponseInceptionDepartment_TextChanged(object sender, EventArgs e)
        {
            tbResponseInceptionDepartment.BackColor = Color.White;
        }

        private void tbQueryNumber_TextChanged(object sender, EventArgs e)
        {
            tbQueryNumber.BackColor = Color.White;
        }

        private void tbGettingNumber_TextChanged(object sender, EventArgs e)
        {
            tbGettingNumber.BackColor = Color.White;
        }

        private void tbGettingCount_TextChanged(object sender, EventArgs e)
        {
            tbGettingCount.BackColor = Color.White;
        }

        private void tbOrderNumber_TextChanged(object sender, EventArgs e)
        {
            tbOrderNumber.BackColor = Color.White;
        }

        private void tbActOfInceptionNumber_TextChanged(object sender, EventArgs e)
        {
            tbActOfInceptionNumber.BackColor = Color.White;
        }

        private void tbActOfCheckingNumber_TextChanged(object sender, EventArgs e)
        {
            tbActOfCheckingNumber.BackColor = Color.White;
        }

        private void cmbQueryAdress_DropDown(object sender, EventArgs e)
        {
            cmbQueryAdress.BackColor = Color.White;
        }

        private void cmbAdressOfReceiver_DropDown(object sender, EventArgs e)
        {
            cmbAdressOfReceiver.BackColor = Color.White;
        }

        private void cmbQueryAdress_TextChanged(object sender, EventArgs e)
        {
            cmbQueryAdress.BackColor = Color.White;
        }

        private void cmbAdressOfReceiver_TextChanged(object sender, EventArgs e)
        {
            cmbAdressOfReceiver.BackColor = Color.White;
        }

        private void rbInnerDocument_CheckedChanged(object sender, EventArgs e)
        {
            tbQueryNumber.BackColor = Color.White;
            dtpQueryDate.BackColor = Color.White;
            cmbQueryAdress.BackColor = Color.White;

            tbGettingNumber.BackColor = Color.White;
            dtpDateOfReg.BackColor = Color.White;
            dtpDateOfReceiving.BackColor = Color.White;
            tbGettingCount.BackColor = Color.White;
            cmbAdressOfReceiver.BackColor = Color.White;
        }

        #endregion
    }
}
