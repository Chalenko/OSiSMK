using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace OCCMK_Kartoteka.Forms
{
    public partial class EditDepartmentForm : DepartmentForm
    {
        public EditDepartmentForm(string depId)
        {
            this.InitializeComponent();

            this.depId = depId;

            RefreshTB();
        }

        private void RefreshTB()
        {
            using (SqlCommand com = dbContext._connection.CreateCommand())
            {
                try
                {
                    dbContext._connection.Open();
                    com.CommandText = "select id, code, name " +
                    " from " + tableName +
                    " where id = " + this.depId;
                    com.CommandType = CommandType.Text;
                    SqlDataReader reader = com.ExecuteReader();

                    reader.Read();
                    tbCode.Text = (reader["code"]).ToString();
                    tbName.Text = (reader["name"]).ToString();
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Не удалось загрузить данные о подразделениях!", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    FileLogger.log(LogLevel.Fatal, "Не удалось загрузить подразделение с id = " + this.depId + " в форму редактирования подразделения." + ex.ToString());
                    return;
                }
                finally
                {
                    dbContext._connection.Close();
                }
            }
        }

        protected override void btnAction_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Изменить запись?", "Изменение записи", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (isAllFieldCorrect())
                {
                    string actionCommand = "UPDATE " + tableName + " SET code = '" + Convert.ToString(tbCode.Text) + "', name = '" + Convert.ToString(tbName.Text) + "' WHERE id = " + depId;
                    try
                    {
                        dbContext.ExecuteCommand(actionCommand, CommandType.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Не удалось изменить подразделение" + ". ", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        FileLogger.log(LogLevel.Error, "Не удалось изменить запись с id = " + depId+ " в таблице " + tableName + ". " + ex.ToString());
                        return;
                    }
                    finally
                    {
                        this.Close();
                    }
                    MessageBox.Show("Запись изменена!", "Измененние записи", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FileLogger.log(LogLevel.Info, "Изменена запись с id = " + depId + " в таблице " + tableName + ".");
                }
                else
                {
                    MessageBox.Show("Не заполненно одно или несколько из обязательных полей!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
