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
    public partial class AddDocForm : DocForm
    {

        public AddDocForm() : base()
        {
            this.InitializeComponent();

            srcDgvChanging = new BindingSource();
            srcDgvDepartment = new BindingSource();

            tableChangingName = "tempDCH" + DateTime.Now.ToString("ddMMyyyyhhmmss");
            tableDepartmentName = "tempPodrDoc" + DateTime.Now.ToString("ddMMyyyyhhmmss");
            docId = "0";

            FillAllCombobox();

            dgvChanging.DataSource = srcDgvChanging;
            dgvDepartment.DataSource = srcDgvDepartment;

            try
            {
                dbContext.ExecuteCommand("tempDocChange", new Dictionary<string, object> { { "@Tname", tableChangingName }, { "@Tpodr", tableDepartmentName } }, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось создать временные таблицы", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                FileLogger.log(LogLevel.Error, "Не удалось создать временные таблицы изменений и экземпляров " + tableChangingName + " и " + tableDepartmentName + ". " + ex.ToString());
                return;
            }
            finally
            {
                dbContext._connection.Close();
                RefreshDGV();
            }
        }

        protected override void DocForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                dbContext.ExecuteCommand("drop table " + tableChangingName, CommandType.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось удалить временную таблицу изменений", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                FileLogger.log(LogLevel.Error, "Не удалось удалить таблицу " + tableChangingName + ". " + ex.ToString());
            }
            finally
            {
                dbContext._connection.Close();
            }

            try
            {
                dbContext.ExecuteCommand("drop table " + tableDepartmentName, CommandType.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось удалить временную таблицу экземпляров выданных в подразделение", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                FileLogger.log(LogLevel.Error, "Не удалось удалить таблицу " + tableDepartmentName + ". " + ex.ToString());
            }
            finally
            {
                dbContext._connection.Close();
            }
        }

        #region вспомогательные функции

        private void addOuterDocument()
        {
            if (isSecuriryCorrect() & isStatusCorrect() & isDeveloperCorrect() & isQueryAddressCorrect() & isAddressOfReceiverCorrect() & isGettingCountCorrect())
            {
                if (isAllOuterFieldCorrect())
                {
                    Dictionary<string, object> paramsDictionary = new Dictionary<string, object>();
                    createOuterParams(paramsDictionary);
                    addDocument(paramsDictionary);
                }
                else
                {
                    if (MessageBox.Show("Добавить новую запись с незаполнеными полями?", "Новая запись", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        Dictionary<string, object> paramsDictionary = new Dictionary<string, object>();
                        createOuterParams(paramsDictionary);
                        addDocument(paramsDictionary);
                    }
                }
            }
            else
            {
                MessageBox.Show("Не заполненно одно или несколько из обязательных полей!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addInnerDocument()
        {
            if (isSecuriryCorrect() & isStatusCorrect() & isDeveloperCorrect())
            {
                if (isAllInnerFieldCorrect())
                {
                    Dictionary<string, object> paramsDictionary = new Dictionary<string, object>();
                    createInnerParams(paramsDictionary);
                    addDocument(paramsDictionary);
                }
                else
                {
                    if (MessageBox.Show("Добавить новую запись с незаполнеными полями?", "Новая запись", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        Dictionary<string, object> paramsDictionary = new Dictionary<string, object>();
                        createInnerParams(paramsDictionary);
                        addDocument(paramsDictionary);
                    }
                }
            }
            else
            {
                MessageBox.Show("Не заполненно одно или несколько из обязательных полей!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addDocument(Dictionary<string, object> paramsDictionary)
        {
            try
            {
                dbContext.ExecuteCommand("Kart_Add", paramsDictionary);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось добавить карточку!", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                FileLogger.log(LogLevel.Error, "Не удалось добавить карточку. " + ex.ToString());
                return;
            }
            finally
            {
                dbContext._connection.Close();
            }
            MessageBox.Show("Запись добавлена!", "Новая запись", MessageBoxButtons.OK, MessageBoxIcon.Information);
            FileLogger.log(LogLevel.Info, "Добавлена новая запись в таблицу Kart.");
            this.Close();
        }

        #endregion

        #region обработка кнопок на форме

        protected override void btnAction_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Добавить новую запись?", "Новая запись", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (rbOuterDocument.Checked == true)
                    addOuterDocument();
                else
                    addInnerDocument();
            }
        }

        #endregion

    }
}
