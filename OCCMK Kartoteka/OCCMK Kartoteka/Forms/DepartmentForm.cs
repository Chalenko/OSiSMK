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
    public partial class DepartmentForm : Form
    {
        protected DatabaseContext dbContext = DatabaseContext.Instance;
        protected string tableName = "departments";
        protected string depId;

        public DepartmentForm()
        {
            InitializeComponent();
        }

        #region вспомагательные функции

        protected bool isAllFieldCorrect()
        {
            return isCodeCorrect() && isNameCorrect();
        }

        private bool isNameCorrect()
        {
            bool nameIsCorrect = true;
            if (tbName.Text.Trim().Equals(""))
            {
                MessageBox.Show("Обозначение подразделения не введено!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbName.BackColor = Color.Crimson;
                nameIsCorrect = false;
            }
            return nameIsCorrect;
        }

        private bool isCodeCorrect()
        {
            bool codeIsCorrect = true;
            if (tbCode.Text.Trim().Equals(""))
            {
                MessageBox.Show("Код подразделения не введен!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbCode.BackColor = Color.Crimson;
                codeIsCorrect = false;
            }
            return codeIsCorrect;
        }

        #endregion

        #region обработка кнопок на форме

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
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

        #endregion
    }
}
