using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OCCMK_Kartoteka.Forms.AddForms
{
    public partial class AddDepartmentForm : DepartmentForm
    {
        public AddDepartmentForm()
        {
            this.InitializeComponent();
        }

        protected override void btnAction_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Добавить новую запись?", "Новая запись", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (isAllFieldCorrect())
                {
                    string actionCommand = "insert into " + tableName +
                               " values ('" + Convert.ToString(tbCode.Text) + "','" + Convert.ToString(tbName.Text) + "')";
                    try
                    {
                        dbContext.ExecuteCommand(actionCommand, CommandType.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Не удалось добавить подразделение", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        FileLogger.log(LogLevel.Error, "Не удалось добавить запись в таблицу " + tableName + ". " + ex.ToString());
                        return;
                    }
                    finally
                    {
                        this.Close();
                    }
                    MessageBox.Show("Подразделение добавленно!", "Новая запись", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FileLogger.log(LogLevel.Info, "Добавлена новая запись в таблицу " + tableName + ".");
                }
                else
                {
                    MessageBox.Show("Не заполненно одно или несколько из обязательных полей!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
