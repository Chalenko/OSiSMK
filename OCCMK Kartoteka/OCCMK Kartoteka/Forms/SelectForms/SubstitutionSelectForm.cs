using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OCCMK_Kartoteka
{
    public partial class SubstitutionSelectForm : SelectForm
    {
        private string value;

        public SubstitutionSelectForm(string command, string table, int id) : base (command, table, id)
        {
            this.InitializeComponent();
        }

        protected override void SelectForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Data.Value = value;
            Data.IDval = id;
        }

        #region обработка кнопок на форме

        protected override void btnSelect_Click(object sender, EventArgs e)
        {
            value = dgvSelect.CurrentRow.Cells["Обозначение"].Value.ToString();
            id = Convert.ToInt32(dgvSelect.CurrentRow.Cells["id"].Value);
            this.Close();
        }

        protected override void dgvSelect_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            value = dgvSelect.CurrentRow.Cells["Обозначение"].Value.ToString();
            id = Convert.ToInt32(dgvSelect.CurrentRow.Cells["id"].Value);
            this.Close();
        }

        #endregion
    }
}
