using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OCCMK_Kartoteka.Forms
{
    public partial class AddDocChangeForm : DocChangeForm
    {
        public AddDocChangeForm(string tableName, string docId)
        {
            this.InitializeComponent();
            this.tableName = tableName;
            this.docId = docId;

            dtpDateOfReg.Checked = false;
            dtpDateOfIntro.Checked = false;
        }

        protected override void btnAction_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Добавить новую запись?", "Новая запись", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (isAllFieldCorrect())
                {
                    string actionCommand = "set dateformat dmy insert into " + tableName + 
                        " values ('" + docId + "','" + Convert.ToString(tbChangeNum.Text) + "','" + dtpDateOfReg.Value.Date + "','" + dtpDateOfIntro.Value.Date + "','" + tbDocumentName.Text.Trim() + "')";
                    try
                    {
                        dbContext.ExecuteCommand(actionCommand, CommandType.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Не удалось добавить изменение", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        FileLogger.log(LogLevel.Error, "Не удалось добавить изменение в таблицу " + tableName + ". " + ex.ToString());
                        return;
                    }
                    finally
                    {
                        this.Close();
                    }
                    MessageBox.Show("Изменение/поправка добавлена!", "Новая запись", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FileLogger.log(LogLevel.Info, "Добавлено новое изменение/поправка " + Convert.ToString(tbChangeNum.Text) + " для документа с id = " + docId.ToString() + " в таблицу " + tableName + ".");
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
