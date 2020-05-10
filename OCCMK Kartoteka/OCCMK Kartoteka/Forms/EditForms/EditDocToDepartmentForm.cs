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
    public partial class EditDocToDepartmentForm : DocToDepartmentForm
    {
        
        public EditDocToDepartmentForm(string tableName, string docId, string recId)
        {
            this.InitializeComponent();
            this.docId = docId;
            this.table = tableName;
            this.id = recId;
            tbCopyName.Enabled = false;
        }

        protected override void DocToDepartmentForm_Shown(object sender, EventArgs e)
        {
            try
            {
                FillAllFields();
            }
            catch
            {
                this.Close();
            }
        }

        #region вспомогательные функции

        private void FillAllFields()
        {
            FillStatusCombobox();
            LoadData();
        }

        private void LoadData()
        {
            using (SqlCommand com = dbContext._connection.CreateCommand())
            {
                try
                {
                    dbContext._connection.Open();
                    string commandString = string.Format("select dep.id id,dep.code+'/'+dep.name as codpod,Convert(varchar(10),{0}.givedate,104) gdate,{0}.giveto,Convert(varchar(10),{0}.takedate,104) tdate,copyName,copyStatus" + " from {0}" + " left join departments dep on dep.id = {0}.podrId where {0}.id = " + id, table);
                    com.CommandText = commandString;
                    com.CommandType = CommandType.Text;
                    SqlDataReader reader = com.ExecuteReader();

                    reader.Read();
                    readAllTB(reader);
                    reader.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Не удалось загрузить данные", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    FileLogger.log(LogLevel.Fatal, "Не удалось загрузить данные из таблицы " + table + ". " + ex.ToString());
                    throw ex;
                }
                finally
                {
                    dbContext._connection.Close();
                }
            }
        }

        private void readAllTB(SqlDataReader reader)
        {
            tbDepartment.Text = (reader["codpod"]).ToString();
            depID = Convert.ToInt32(reader["id"]);
            tbCopyName.Text = (reader["copyName"]).ToString();
            try
            {
                int id = (int)reader["copyStatus"];
                cmbStatus.SelectedIndex = StatusDictionary.Values.ToList<int>().IndexOf(id);
                //cmbStatus.SelectedIndex = (int)reader["copyStatus"] - 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не найдено значение статуса экземпляра");
                FileLogger.log(LogLevel.Warn, "Не найдено значение статуса экземпляра" + ex.ToString());
                cmbStatus.SelectedIndex = 0;
            }
            dtpGiveDate.ShowCheckBox = false;
            dtpGiveDate.Checked = true;
            dtpGiveDate.Value = DateTime.Parse(reader["gdate"].ToString());
            if ((int)reader["copyStatus"] != ConstantsOfProject.idOfGivenState)
            {
                dtpTakeDate.ShowCheckBox = true;
                dtpTakeDate.Checked = true;
                dtpTakeDate.Value = DateTime.Parse(reader["tdate"].ToString());
            }
            tbName.Text = (reader["giveto"]).ToString();
        }

        #endregion

        #region обработка кнопок на форме

        protected override void btnAction_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Изменить запись?", "Изменение записи", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (allFieldIsCorrect())
                {
                    string copyName = tbCopyName.Text;
                    string dtpTakeDateValue;
                    if (dtpTakeDate.Checked == false) dtpTakeDateValue = null;
                    else dtpTakeDateValue = dtpTakeDate.Value.Date.ToString();
                    string actionCommand = "set dateformat dmy Update " + table + " set docid = '" + docId + "',podrId = '" + depID + "',givedate = '" + dtpGiveDate.Value.Date + "',giveto = '" + tbName.Text +
                        "',takedate = '" + dtpTakeDateValue + "',copyName = '" + copyName + "',copyStatus = '" + /*(cmbStatus.SelectedIndex + 1)*/ cmbStatus.SelectedValue.ToString() + "' where id = " + id;
                    try
                    {
                        dbContext.ExecuteCommand(actionCommand, CommandType.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Не удалось изменить экземпляр!", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        FileLogger.log(LogLevel.Error, "Не удалось изменить экземпляр " + copyName +  " документа c docID = " + docId.ToString() + " выданный в подразделение depID = " + depID + " в таблице " + table + ". " + ex.ToString());
                        return;
                    }
                    finally
                    {
                        dbContext._connection.Close();
                    }
                    MessageBox.Show("Экземпляр изменен", "Изменение записи", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FileLogger.log(LogLevel.Info, "Изменен экземпляр " + copyName +  " документа c docID = " + docId.ToString() + " выданный в подразделение depID = " + depID + " в таблицу " + table + ".");
                    this.Close();
                }
            }
        }

        #endregion
    }
}
