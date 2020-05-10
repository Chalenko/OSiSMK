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
    public partial class AddDocToDepartmentForm : DocToDepartmentForm
    {
        public AddDocToDepartmentForm(string tableName, string docId) : base()
        {
            this.InitializeComponent();
            this.docId = docId;
            this.table = tableName;
        }

        public AddDocToDepartmentForm(string tableName, string docId, int depId) : base()
        {
            this.InitializeComponent();
            this.docId = docId;
            this.table = tableName;
            this.depID = depId;
            this.tbCopyName.Text = autoGenerateCopyName();
        }

        protected override void DocToDepartmentForm_Shown(object sender, EventArgs e)
        {
            try
            {
                FillStatusCombobox();
                tbDepartment.Text = LoadDepartmentName((int)depID);
            }
            catch
            {
                this.Close();
            }
        }

        #region вспомогательные функции

        private string LoadDepartmentName(int depId)
        {
            string result = "";
            using (SqlCommand com = dbContext._connection.CreateCommand())
            {
                try
                {
                    dbContext._connection.Open();
                    com.CommandText = "select code+'/'+name as codpod from departments where id = " + depId;
                    com.CommandType = CommandType.Text;
                    SqlDataReader reader = com.ExecuteReader();

                    while (reader.Read())
                    {
                        result = (reader["codpod"]).ToString();
                    }
                    reader.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Не удалось загрузить данные", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    FileLogger.log(LogLevel.Fatal, "Не удалось загрузить данные из таблицы departments. " + ex.ToString());
                    return result;
                }
                finally
                {
                    dbContext._connection.Close();
                }
            }
            return result;
        }

        #endregion

        #region обработка кнопок на форме

        protected override void btnAction_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Добавить новую запись?", "Новая запись", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                string copyName = tbCopyName.Text.Trim();
                try
                {
                    if (allFieldIsCorrect() && !isCopyBusy(tbCopyName.Text.Trim()))
                    {
                        string dtpTakeDateValue;
                        if (dtpTakeDate.Checked == false) dtpTakeDateValue = null;
                        else dtpTakeDateValue = dtpTakeDate.Value.Date.ToString();
                        string actionCommand = "set dateformat dmy Insert into " + table + " (docid,podrId,examplnum,givedate,giveto,takedate, copyName, copyStatus) values ('" +
                            docId + "'," + depID + "," + examplnum + ",'" + dtpGiveDate.Value.Date + "','" + Convert.ToString(tbName.Text).Trim() + "','" + dtpTakeDateValue + "','" + copyName + "','"
                            + cmbStatus.SelectedValue.ToString()/*(cmbStatus.SelectedIndex + 1)*/ + "')";
                    
                        dbContext.ExecuteCommand(actionCommand, CommandType.Text);
                    
                        MessageBox.Show("Экземпляр добавлен", "Новая запись", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FileLogger.log(LogLevel.Info, "Добавлен новый экземпляр " + copyName +  " документа c docID = " + docId.ToString() + " выданный в подразделение depID = " + depID + " в таблицу " + table + ".");
                        this.Close();
                    }
                    else if (isCopyBusy(tbCopyName.Text.Trim()))
                    {
                        MessageBox.Show("Экземпляр уже используется!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tbCopyName.BackColor = Color.Crimson;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Не удалось добавить экземпляр!", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    FileLogger.log(LogLevel.Error, "Не удалось добавить экземпляр " + copyName +  " документа c docID = " + docId.ToString() + " выданный в подразделение depID = " + depID + " в таблицу " + table + ". " + ex.ToString());
                    return;
                }
                finally
                {
                    dbContext._connection.Close();
                }
            }
        }

        #endregion
    }
}
