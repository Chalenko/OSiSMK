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
    public partial class AddEntityForm : Form
    {
        private DatabaseContext dbContext = DatabaseContext.Instance;
        string tableName;

        public AddEntityForm(string table)
        {
            InitializeComponent();
            tableName = table;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Добавить новую запись?", "Новая запись", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (!tbInputText.Text.Trim().Equals(""))
                {
                    try
                    {
                        dbContext.ExecuteCommand("Insert into " + tableName + " values ('" + tbInputText.Text.Trim().ToString() + "')", CommandType.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Не удалось добавить запись", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        FileLogger.log(LogLevel.Error, "Не удалось добавить запись в таблицу " + tableName + ". " + ex.ToString());
                        return;
                    }
                    finally
                    {
                        this.Close();
                    }
                    MessageBox.Show("Запись добавленна!", "Новая запись", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FileLogger.log(LogLevel.Info, "Добавлена новая запись в таблицу " + tableName + ".");
                }
                else
                {
                    MessageBox.Show("Запись не может содержать пустую строку", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
