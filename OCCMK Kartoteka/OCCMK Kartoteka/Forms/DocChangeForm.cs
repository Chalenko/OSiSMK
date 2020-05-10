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
    public partial class DocChangeForm : Form
    {
        protected DatabaseContext dbContext = DatabaseContext.Instance;
        protected string tableName;
        protected string docId;
        protected int id;

        public DocChangeForm()
        {
            InitializeComponent();
        }        

        #region обработка кнопок на форме

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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region вспомогательные функции

        protected bool isAllFieldCorrect()
        {
            return isChangeNameCorrect() & isChangeNumCorrect() & isDateOfRegCorrect() & isDateOfIntroCorrect();
        }

        private bool isChangeNumCorrect()
        {
            bool changeNumIsCorrect = true;
            if (tbChangeNum.Text.Trim().Equals(""))
            {
                MessageBox.Show("Номер изменения/поправки не введен!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbChangeNum.BackColor = Color.Crimson;
                changeNumIsCorrect = false;
            }
            return changeNumIsCorrect;
        }

        private bool isChangeNameCorrect()
        {
            bool changeNameIsCorrect = true;
            if (tbDocumentName.Text.Trim().Equals(""))
            {
                MessageBox.Show("Документ не введен!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbDocumentName.BackColor = Color.Crimson;
                changeNameIsCorrect = false;
            }
            return changeNameIsCorrect;
        }

        private bool isDateOfRegCorrect()
        {
            bool dateOfRegIsCorrect = true;
            if (dtpDateOfReg.Checked == false)
            {
                MessageBox.Show("Дата регистрации не введена!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpDateOfReg.BackColor = Color.Crimson;
                dateOfRegIsCorrect = false;
            }
            return dateOfRegIsCorrect;
        }

        private bool isDateOfIntroCorrect()
        {
            bool dateOfIntroIsCorrect = true;
            if (dtpDateOfIntro.Checked == false)
            {
                MessageBox.Show("Дата введения в действие не введена!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpDateOfIntro.BackColor = Color.Crimson;
                dateOfIntroIsCorrect = false;
            }
            return dateOfIntroIsCorrect;
        }

        #endregion

        #region возвращаем текстбоксам и комбобоксам стандартный цвет

        private void tbChangeNum_TextChanged(object sender, EventArgs e)
        {
            tbChangeNum.BackColor = Color.White;
        }

        private void tbDocumentName_TextChanged(object sender, EventArgs e)
        {
            tbDocumentName.BackColor = Color.White;
        }

        #endregion

        private void lblDocumentEasterEggs_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Middle)
            {
                MessageBox.Show("");
            }
        }
    }
}
