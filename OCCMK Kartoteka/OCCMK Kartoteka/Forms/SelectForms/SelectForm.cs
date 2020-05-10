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
    public partial class SelectForm : Form
    {
        protected DatabaseContext dbContext = DatabaseContext.Instance;
        protected BindingSource src;
        protected string commandText;
        protected string tableName;
        protected int id;
        private int lastSortedColumnIndex = 0;
        private ListSortDirection lastSortDirection = ListSortDirection.Ascending;

        public SelectForm()
        {
            InitializeComponent();
        }

        public SelectForm(string command, string table, int id) : base()
        {
            InitializeComponent();
            src = new BindingSource();
            dgvSelect.DataSource = src;
            commandText = command;
            tableName = table;
            this.id = id;

            RefreshDGV();
        }

        protected virtual void SelectForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dgvSelect.RowCount != 0)
                Data.Value = dgvSelect.Rows[getIndexForKey("id", id) != -1 ? getIndexForKey("id", id) : 0].Cells[1].Value.ToString();
        }

        #region обработка событий на форме

        protected virtual void dgvSelect_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            id = Convert.ToInt32(dgvSelect.CurrentRow.Cells["id"].Value);
            this.Close();
        }

        protected virtual void btnSelect_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32(dgvSelect.CurrentRow.Cells["id"].Value);
            this.Close();
        }

        protected virtual void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvSelect.SelectedRows.Count != 0)
            {
                int id = Convert.ToInt32(dgvSelect.CurrentRow.Cells["id"].Value);
                string oldValue = Convert.ToString(dgvSelect.CurrentRow.Cells[1].Value);

                EditEntityForm form = new EditEntityForm(tableName, id, oldValue);
                form.ShowDialog();

                RefreshDGV();
                dgvSelect.CurrentCell = dgvSelect[1, getIndexForKey("id", id)];
            }
            else
            {
                MessageBox.Show("Не выбрана запись для редактирования");
            }
        }

        protected virtual void btnAdd_Click(object sender, EventArgs e)
        {
            AddEntityForm form = new AddEntityForm(tableName);
            form.ShowDialog();
            RefreshDGV();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удалить запись?", "Удаление записи", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    string commandText = "delete from " + tableName + " where id = " + dgvSelect["id", dgvSelect.CurrentRow.Index].Value.ToString();
                    dbContext.ExecuteCommand(commandText, CommandType.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Не удалось удалить запись", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    FileLogger.log(LogLevel.Error, "Не удалось удалить запись с id = " + dgvSelect["id", dgvSelect.CurrentRow.Index].Value.ToString() + " из таблицы " + tableName + ". " + ex.ToString());
                    return;
                }
                finally
                {
                    dbContext._connection.Close();
                }

                RefreshDGV();
            }
        }

        private void dgvSelect_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ListSortDirection lsd;
            if (lastSortedColumnIndex != e.ColumnIndex)
            {
                lsd = (dgvSelect.Columns[lastSortedColumnIndex].HeaderCell.SortGlyphDirection == System.Windows.Forms.SortOrder.Descending) ? ListSortDirection.Descending : ListSortDirection.Ascending;
            }
            else
            {
                lsd = (dgvSelect.Columns[lastSortedColumnIndex].HeaderCell.SortGlyphDirection == System.Windows.Forms.SortOrder.Descending) ? ListSortDirection.Ascending : ListSortDirection.Descending;
            }
            dgvSelect.Sort(dgvSelect.Columns[lastSortedColumnIndex], lsd);
            int id = Convert.ToInt32(dgvSelect.CurrentRow.Cells["id"].Value);
            dgvSelect.Sort(dgvSelect.Columns[e.ColumnIndex], (dgvSelect.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == System.Windows.Forms.SortOrder.Ascending) ? ListSortDirection.Descending : ListSortDirection.Ascending);
            dgvSelect.CurrentCell = dgvSelect[1, getIndexForKey("id", id)];
            lastSortedColumnIndex = e.ColumnIndex;
        }

        private void dgvSelect_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                btnSelect_Click(sender, e);
            }

            if (e.Control == true && e.KeyCode.Equals(Keys.E))
            {
                btnEdit_Click(sender, e);
            }

            if (e.Control == true && e.KeyCode.Equals(Keys.E))
            {
                btnEdit_Click(sender, e);
            }

            if (e.KeyCode.Equals(Keys.F5))
            {
                RefreshDGV();
            }
        }

        #endregion

        #region вспомогательные функции

        protected virtual void RefreshDGV() 
        {
            base.Refresh();
            try
            {
                src.DataSource = dbContext.LoadFromDatabase(commandText, CommandType.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось загрузить данные", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                FileLogger.log(LogLevel.Fatal, "Не удалось загрузить данные из таблицы " + tableName + ". " + ex.ToString());
                //return;
            }
            finally
            {
                dbContext._connection.Close();
            }
            UpdateControls();
        }

        protected void UpdateControls()
        {
            //btnDelete.Visible = false;
            if (src.DataSource == null)
            {
                dgvSelect.Enabled = false;
                btnSelect.Enabled = false;
                btnEdit.Enabled = false;
                btnAdd.Enabled = false;
                return;
            }
            btnAdd.Enabled = true;
            dgvSelect.Columns["id"].Visible = false;
            dgvSelect.Sort(dgvSelect.Columns[lastSortedColumnIndex], lastSortDirection);
            if (dgvSelect.RowCount == 0)
            {
                btnSelect.Enabled = false;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                dgvSelect.Enabled = false;
            }
            else
            {
                btnSelect.Enabled = true;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                dgvSelect.Enabled = true;
                dgvSelect.CurrentCell = dgvSelect[1, getIndexForKey("id", id) != -1 ? getIndexForKey("id", id) : 0];
            }
        }

        protected int getIndexForKey(string colName, object key)
        {
            int index = -1;
            for (int i = 0; i < dgvSelect.RowCount; i++)
            {
                if (dgvSelect[colName, i].Value.Equals(key))
                {
                    index = i;
                }
            }
            return index;
        }

        #endregion
    }
}