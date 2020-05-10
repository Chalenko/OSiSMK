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
    public partial class EditDocChangeForm : DocChangeForm
    {
        public EditDocChangeForm(string tableName, string docId, string id)
        {
            this.InitializeComponent();
            this.tableName = tableName;
            this.docId = docId;
            this.id = Convert.ToInt32(id);

            dtpDateOfReg.ShowCheckBox = false;
            dtpDateOfReg.Checked = true;
            dtpDateOfIntro.ShowCheckBox = false;
            dtpDateOfIntro.Checked = true;

            LoadChanges();
        }

        private void LoadChanges()
        {
            using (SqlCommand com = dbContext._connection.CreateCommand())
            {
                try
                {
                    dbContext._connection.Open();
                    com.CommandText = "Select number,regdoc,regdate,vvoddate from " + tableName + " where id = " + this.id.ToString();
                    com.CommandType = CommandType.Text;
                    SqlDataReader reader = com.ExecuteReader();

                    while (reader.Read())
                    {
                        tbChangeNum.Text = (reader["number"]).ToString();
                        tbDocumentName.Text = (reader["regdoc"]).ToString();
                        dtpDateOfReg.Value = DateTime.Parse(reader["regdate"].ToString());
                        dtpDateOfIntro.Value = DateTime.Parse(reader["vvoddate"].ToString());
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Не удалось загрузить данные", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    FileLogger.log(LogLevel.Fatal, "Не удалось загрузить данные из таблицы DocChange. " + ex.ToString());
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
                    string actionCommand = "set dateformat dmy Update " + tableName + " set docID = '" + docId +
                        "',Number = '" + Convert.ToString(tbChangeNum.Text) + "',regDoc = '" + Convert.ToString(tbDocumentName.Text) +
                        "',regDate = '" + dtpDateOfReg.Value.Date + "',vvodDate = '" + dtpDateOfIntro.Value.Date + "' where id = " + id;
                    try
                    {
                        dbContext.ExecuteCommand(actionCommand, CommandType.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Не удалось изменить поправку", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        FileLogger.log(LogLevel.Error, "Не удалось изменить поправку с id = " + id.ToString() + " в таблице " + tableName + " для документа с id = " + docId + ". " + ex.ToString());
                        return;
                    }
                    finally
                    {
                        this.Close();
                    }
                    MessageBox.Show("Изменение/поправка изменена!", "Изменение записи", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FileLogger.log(LogLevel.Info, "Изменена поправка с id = " + id.ToString() + " в таблице " + tableName + " для документа с id = " + docId + ".");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Не заполненно одно или несколько из обязательных полей!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
