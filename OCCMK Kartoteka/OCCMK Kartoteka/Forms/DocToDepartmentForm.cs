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
    public partial class DocToDepartmentForm : Form
    {
        protected DatabaseContext dbContext = DatabaseContext.Instance;
        protected string table;
        protected int? depID = 0;
        protected string docId;
        protected string id;

        //словари для комбобоксов
        protected Dictionary<string, int> StatusDictionary = new Dictionary<string, int>();
        protected int examplnum;

        public DocToDepartmentForm()
        {
            InitializeComponent();
        }

        protected virtual void DocToDepartmentForm_Shown(object sender, EventArgs e)
        {
        }

        #region обработка кнопок на форме

        private void btnDepartmentSelect_Click(object sender, EventArgs e)
        {
            new DepartamentSelectForm("select id ,code [Код], name [Обозначение] from Departments", "Departments", (int)depID).ShowDialog();

            if (Data.Value != null) { tbDepartment.Text = Data.Value; depID = Data.IDval; }
            Data.IDval = null;
            Data.Value = null;

            try
            {
                this.tbCopyName.Text = autoGenerateCopyName();
            }
            catch
            {
                tbCopyName.Text = "";
            }
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

        private void dtpGiveDate_ValueChanged(object sender, EventArgs e)
        {
            dtpGiveDate.BackColor = Color.White;
            dtpGiveDate.Text = dtpGiveDate.Value.ToString();
        }

        private void btnSelectStatus_Click(object sender, EventArgs e)
        {
            SelectForm sf = new SelectForm("Select distinct id, status [Статус] from copyStatus", "copyStatus", cmbStatus.SelectedIndex);
            sf.Text = "Выбор статуса экземпляра";
            sf.Controls["btnAdd"].Visible = false;
            sf.Controls["btnEdit"].Visible = false;
            sf.Controls["btnDelete"].Visible = false;
            sf.ShowDialog();

            ClearDictionaryAndCombobox();
            FillStatusCombobox();

            if (Data.Value != null) cmbStatus.Text = Data.Value;
            Data.Value = null;
        }

        #endregion

        #region вспомогательные функции

        protected bool allFieldIsCorrect()
        {
            return isDepNameCorrect() & isCopyNameCorrect() & isStatusCorrect() & isCorrectGiveDate() & isCorrectNameTo() & isCorrectTakeDate();
        }

        private bool isDepNameCorrect()
        {
            bool depNameIsCorrect = false;
            if (tbDepartment.Text.Trim().Equals(""))
            {
                MessageBox.Show("Индекс подразделения не выбран!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbDepartment.BackColor = Color.Crimson;
            }
            else
            {
                depNameIsCorrect = true;
            }
            return depNameIsCorrect;
        }

        private bool isCopyNameCorrect()
        {
            bool copyNameIsCorrect = true;
            if (tbCopyName.Text.Trim().Equals(""))
            {
                MessageBox.Show("Номер экземпляра введен не верно!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbCopyName.BackColor = Color.Crimson;
                copyNameIsCorrect = false;
            }
            return copyNameIsCorrect;
        }

        private bool isStatusCorrect()
        {
            bool isCorrect = true;
            if(!StatusDictionary.ContainsKey(cmbStatus.Text.Trim()))
           // if (!cmbStatus.Items.Contains(cmbStatus.Text.Trim()))
            {
                cmbStatus.BackColor = Color.Yellow; isCorrect = false;
                MessageBox.Show("Не корректно заполненно значение из выпадающего списка! \nЗначение должно совпадать с уже имеющемся в списке.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return isCorrect;
        }

        private bool isCorrectGiveDate()
        {
            bool giveDateIsCorrect = false;
            if (dtpGiveDate.Checked == false)
            {
                MessageBox.Show("Дата выдачи не введена!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpGiveDate.BackColor = Color.Crimson;
            }
            else
            {
                giveDateIsCorrect = true;
            }
            return giveDateIsCorrect;
        }

        private bool isCorrectNameTo()
        {
            bool nameToIsCorrect = false;
            if (tbName.Text.Trim().Equals(""))
            {
                MessageBox.Show("Ф.И.О. получившего не введено!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbName.BackColor = Color.Crimson;
            }
            else
            {
                nameToIsCorrect = true;
            }
            return nameToIsCorrect;
        }

        private bool isCorrectTakeDate()
        {
            bool takeDateIsCorrect = true;
            if ((Convert.ToInt32(cmbStatus.SelectedValue) != ConstantsOfProject.idOfGivenState)&& !dtpTakeDate.Checked)
            //if (((cmbStatus.SelectedIndex == 0) || (cmbStatus.SelectedValue == 2)) && !dtpTakeDate.Checked)
            {
                MessageBox.Show("Дата возврата не введена!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                takeDateIsCorrect = false;
            }
            return takeDateIsCorrect;
        }

        protected string autoGenerateCopyName()
        {
            string str = getDepartmentCode();
            str += "-";
            int copyNumber = 1;
            while (isCopyBusy(str + copyNumber.ToString()))
            {
                copyNumber++;
            }
            examplnum = copyNumber;
            return str + copyNumber.ToString();
        }

        private string getDepartmentCode()
        {
            string str = "";
            using (SqlCommand com = dbContext._connection.CreateCommand())
            {
                try
                {
                    dbContext._connection.Open();
                    com.CommandText = "select code from departments where id = " + depID;
                    com.CommandType = CommandType.Text;
                    SqlDataReader reader = com.ExecuteReader();

                    while (reader.Read())
                    {
                        str += (reader["code"]).ToString();
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Не удалось загрузить данные", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    FileLogger.log(LogLevel.Fatal, "Не удалось загрузить данные из таблицы departments. " + ex.ToString());
                    return str;
                }
                finally
                {
                    dbContext._connection.Close();
                }
            }
            return str;
        }

        protected bool isCopyBusy(string copyName)
        {
            bool busy = false;
            using (SqlCommand com = dbContext._connection.CreateCommand())
            {
                try
                {
                    dbContext._connection.Open();
                    string text = "select count(id) from " + table + " where copyName = '" + copyName + "' and docid = " + Convert.ToInt32(docId);
                    com.CommandText = text;
                    com.CommandType = CommandType.Text;
                    SqlDataReader reader = com.ExecuteReader();

                    if (reader.Read())
                    {
                        if (Convert.ToInt32(reader[0]) == 0)
                        {
                            busy = false;
                        }
                        else
                        {
                            busy = true;
                        }
                    }
                    else
                    {
                        busy = false;
                    }
                }
                catch (Exception ex)
                {
                    FileLogger.log(LogLevel.Error, "Не удалось проверить экземпляр " + copyName + " на занятость. " + ex.ToString());
                    throw ex;
                }
                finally
                {
                    dbContext._connection.Close();
                }
            }
            return busy;
        }

        private void ClearDictionaryAndCombobox()
        {
            //cmbStatus.Items.Clear();
            cmbStatus.DataSource = null;
            StatusDictionary.Clear();
        }

        protected void FillStatusCombobox()
        {
            using (SqlCommand com = dbContext._connection.CreateCommand())
            {
                try
                {
                    dbContext._connection.Open();
                    com.CommandText = "Select distinct id, status from copyStatus order by status";
                    com.CommandType = CommandType.Text;
                    SqlDataReader reader = com.ExecuteReader();

                    while (reader.Read())
                    {
                        //cmbStatus.Items.Add((reader["status"]).ToString());
                        StatusDictionary.Add((reader["status"]).ToString(), Convert.ToInt32((reader["id"])));
                    }
                    cmbStatus.DataSource = new BindingSource(StatusDictionary, null);
                    cmbStatus.DisplayMember = "Key";
                    cmbStatus.ValueMember = "Value";
                    reader.Close();

                    cmbStatus.AutoCompleteSource = AutoCompleteSource.ListItems;
                    cmbStatus.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Не удалось загрузить данные", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    FileLogger.log(LogLevel.Fatal, "Не удалось загрузить данные из таблицы copyStatus. " + ex.ToString());
                    return;
                }
                finally
                {
                    dbContext._connection.Close();
                }
            }
        }

        #endregion

        #region возвращаем текстбоксам и комбобоксам стандартный цвет

        private void tbDepartment_TextChanged(object sender, EventArgs e)
        {
            tbDepartment.BackColor = Color.White;
        }

        private void tbCopyName_TextChanged(object sender, EventArgs e)
        {
            tbCopyName.BackColor = Color.White;
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            tbName.BackColor = Color.White;
        }

        #endregion
    }
}
