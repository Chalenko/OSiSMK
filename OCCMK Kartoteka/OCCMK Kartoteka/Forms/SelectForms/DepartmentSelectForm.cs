using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OCCMK_Kartoteka.Forms.AddForms;
using OCCMK_Kartoteka.Forms;

namespace OCCMK_Kartoteka
{
    public partial class DepartamentSelectForm : SelectForm
    {
        private string value;

        public DepartamentSelectForm(string command, string table, int id) : base(command, table, id)
        {
            this.InitializeComponent();
        }

        protected override void SelectForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Data.Value = value;
            Data.IDval = id;
        }

        #region обработка кнопок на форме

        protected override void btnAdd_Click(object sender, EventArgs e)
        {
            new AddDepartmentForm().ShowDialog();
            RefreshDGV();
        }

        protected override void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvSelect.SelectedRows.Count != 0)
            {
                int id = Convert.ToInt32(dgvSelect.CurrentRow.Cells["id"].Value);
                new EditDepartmentForm(id.ToString()).ShowDialog();
                RefreshDGV();
                dgvSelect.CurrentCell = dgvSelect[1, getIndexForKey("id", id)];
            }
            else
            {
                MessageBox.Show("Не выбрана запись для редактирования");
            }
        }

        protected override void btnSelect_Click(object sender, EventArgs e)
        {
            value = dgvSelect.CurrentRow.Cells["Код"].Value.ToString() + "/" + dgvSelect.CurrentRow.Cells["Обозначение"].Value.ToString();
            id = Convert.ToInt32(dgvSelect.CurrentRow.Cells["id"].Value);
            this.Close();
        }

        protected override void dgvSelect_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            value = dgvSelect.CurrentRow.Cells["Код"].Value.ToString() + "/" + dgvSelect.CurrentRow.Cells["Обозначение"].Value.ToString();
            id = Convert.ToInt32(dgvSelect.CurrentRow.Cells["id"].Value);
            this.Close();
        }   

        #endregion
    }
}
