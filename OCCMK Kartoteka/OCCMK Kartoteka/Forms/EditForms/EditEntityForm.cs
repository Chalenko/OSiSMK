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
    public partial class EditEntityForm : Form
    {
        private DatabaseContext dbContext = DatabaseContext.Instance;
        string tableName;
        private int id;

        public EditEntityForm(string table, int id, string oldValue)
        {
            InitializeComponent();
            tableName = table;
            this.id = id;

            tbInputText.Text = oldValue;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Изменить запись?", "Изменение записи", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (!tbInputText.Text.Trim().Equals(""))
                {
                    string colName = "";
                    try
                    {
                        colName = dbContext.getUpdateColumnNameForTable(tableName);
                        string query = string.Format("UPDATE {0} SET {1} = '{2}' WHERE id = {3}", tableName, colName, tbInputText.Text, id);
                        dbContext.ExecuteCommand(query, CommandType.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Не удалось изменить запись" + ". ", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        FileLogger.log(LogLevel.Error, "Не удалось изменить запись с id = " + id.ToString() + " в таблице " + tableName + ". " + ex.ToString());
                        return;
                    }
                    finally
                    {
                        this.Close();
                    }
                    MessageBox.Show("Запись изменена!", "Измененние записи", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FileLogger.log(LogLevel.Info, "Изменена запись с id = " + id.ToString() + " в таблице " + tableName + ".");
                }
                else
                {
                    MessageBox.Show("Запись не может содержать пустую строку", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
