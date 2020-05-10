namespace OCCMK_Kartoteka
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.dgvDocument = new System.Windows.Forms.DataGridView();
            this.cmsDocument = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctsEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.ctsDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ctsExport = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnSelectInnerDoc = new System.Windows.Forms.Button();
            this.btnSelectOuterDoc = new System.Windows.Forms.Button();
            this.btnSelectPodrDoc = new System.Windows.Forms.Button();
            this.btnSelectAllStandarts = new System.Windows.Forms.Button();
            this.sfdExportCard = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmHelp = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocument)).BeginInit();
            this.cmsDocument.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDocument
            // 
            this.dgvDocument.AllowUserToAddRows = false;
            this.dgvDocument.AllowUserToDeleteRows = false;
            this.dgvDocument.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDocument.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocument.ContextMenuStrip = this.cmsDocument;
            this.dgvDocument.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDocument.Location = new System.Drawing.Point(0, 0);
            this.dgvDocument.MultiSelect = false;
            this.dgvDocument.Name = "dgvDocument";
            this.dgvDocument.ReadOnly = true;
            this.dgvDocument.RowHeadersVisible = false;
            this.dgvDocument.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDocument.Size = new System.Drawing.Size(682, 456);
            this.dgvDocument.TabIndex = 0;
            this.dgvDocument.CellContextMenuStripNeeded += new System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventHandler(this.dgvDocument_CellContextMenuStripNeeded);
            this.dgvDocument.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dgvDocument.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDocument_ColumnHeaderMouseClick);
            this.dgvDocument.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvDocument_KeyDown);
            this.dgvDocument.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvDocument_MouseDown);
            // 
            // cmsDocument
            // 
            this.cmsDocument.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctsEdit,
            this.ctsDelete,
            this.toolStripSeparator1,
            this.ctsExport});
            this.cmsDocument.Name = "ContextMenuStripDocument";
            this.cmsDocument.Size = new System.Drawing.Size(161, 76);
            // 
            // ctsEdit
            // 
            this.ctsEdit.Image = ((System.Drawing.Image)(resources.GetObject("ctsEdit.Image")));
            this.ctsEdit.Name = "ctsEdit";
            this.ctsEdit.Size = new System.Drawing.Size(160, 22);
            this.ctsEdit.Text = "Редактировать";
            this.ctsEdit.Click += new System.EventHandler(this.ctsEdit_Click);
            // 
            // ctsDelete
            // 
            this.ctsDelete.Image = ((System.Drawing.Image)(resources.GetObject("ctsDelete.Image")));
            this.ctsDelete.Name = "ctsDelete";
            this.ctsDelete.Size = new System.Drawing.Size(160, 22);
            this.ctsDelete.Text = "Удалить";
            this.ctsDelete.Click += new System.EventHandler(this.ctsDelete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(157, 6);
            // 
            // ctsExport
            // 
            this.ctsExport.Image = ((System.Drawing.Image)(resources.GetObject("ctsExport.Image")));
            this.ctsExport.Name = "ctsExport";
            this.ctsExport.Size = new System.Drawing.Size(160, 22);
            this.ctsExport.Text = "Экспорт в Word";
            this.ctsExport.Click += new System.EventHandler(this.ctsExport_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnSelectInnerDoc);
            this.splitContainer1.Panel1.Controls.Add(this.btnSelectOuterDoc);
            this.splitContainer1.Panel1.Controls.Add(this.btnSelectPodrDoc);
            this.splitContainer1.Panel1.Controls.Add(this.btnSelectAllStandarts);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvDocument);
            this.splitContainer1.Size = new System.Drawing.Size(807, 456);
            this.splitContainer1.SplitterDistance = 121;
            this.splitContainer1.TabIndex = 0;
            // 
            // btnSelectInnerDoc
            // 
            this.btnSelectInnerDoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectInnerDoc.Location = new System.Drawing.Point(3, 198);
            this.btnSelectInnerDoc.Name = "btnSelectInnerDoc";
            this.btnSelectInnerDoc.Size = new System.Drawing.Size(115, 59);
            this.btnSelectInnerDoc.TabIndex = 3;
            this.btnSelectInnerDoc.Text = "Перечень разработанных документов";
            this.btnSelectInnerDoc.UseVisualStyleBackColor = true;
            this.btnSelectInnerDoc.Click += new System.EventHandler(this.btnSelectInnerDoc_Click);
            // 
            // btnSelectOuterDoc
            // 
            this.btnSelectOuterDoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectOuterDoc.Location = new System.Drawing.Point(3, 133);
            this.btnSelectOuterDoc.Name = "btnSelectOuterDoc";
            this.btnSelectOuterDoc.Size = new System.Drawing.Size(115, 59);
            this.btnSelectOuterDoc.TabIndex = 2;
            this.btnSelectOuterDoc.Text = "Перечень поступивших документов";
            this.btnSelectOuterDoc.UseVisualStyleBackColor = true;
            this.btnSelectOuterDoc.Click += new System.EventHandler(this.btnSelectOuterDoc_Click);
            // 
            // btnSelectPodrDoc
            // 
            this.btnSelectPodrDoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectPodrDoc.Location = new System.Drawing.Point(3, 68);
            this.btnSelectPodrDoc.Name = "btnSelectPodrDoc";
            this.btnSelectPodrDoc.Size = new System.Drawing.Size(115, 59);
            this.btnSelectPodrDoc.TabIndex = 1;
            this.btnSelectPodrDoc.Text = "Перечень ДС в подразделении";
            this.btnSelectPodrDoc.UseVisualStyleBackColor = true;
            this.btnSelectPodrDoc.Click += new System.EventHandler(this.btnSelectPodrDoc_Click);
            // 
            // btnSelectAllStandarts
            // 
            this.btnSelectAllStandarts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectAllStandarts.Location = new System.Drawing.Point(4, 3);
            this.btnSelectAllStandarts.Name = "btnSelectAllStandarts";
            this.btnSelectAllStandarts.Size = new System.Drawing.Size(114, 59);
            this.btnSelectAllStandarts.TabIndex = 0;
            this.btnSelectAllStandarts.Text = "Перечень стандартов";
            this.btnSelectAllStandarts.UseVisualStyleBackColor = true;
            this.btnSelectAllStandarts.Click += new System.EventHandler(this.btnSelectAllStandarts_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmAdd,
            this.tsmEdit,
            this.tsmDelete,
            this.tsmUpdate,
            this.tsmHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(807, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmAdd
            // 
            this.tsmAdd.Enabled = false;
            this.tsmAdd.Image = ((System.Drawing.Image)(resources.GetObject("tsmAdd.Image")));
            this.tsmAdd.Name = "tsmAdd";
            this.tsmAdd.Size = new System.Drawing.Size(87, 20);
            this.tsmAdd.Text = "Добавить";
            this.tsmAdd.Click += new System.EventHandler(this.tsmAdd_Click);
            // 
            // tsmEdit
            // 
            this.tsmEdit.Enabled = false;
            this.tsmEdit.Image = ((System.Drawing.Image)(resources.GetObject("tsmEdit.Image")));
            this.tsmEdit.Name = "tsmEdit";
            this.tsmEdit.Size = new System.Drawing.Size(115, 20);
            this.tsmEdit.Text = "Редактировать";
            this.tsmEdit.Click += new System.EventHandler(this.tsmEdit_Click);
            // 
            // tsmDelete
            // 
            this.tsmDelete.Enabled = false;
            this.tsmDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsmDelete.Image")));
            this.tsmDelete.Name = "tsmDelete";
            this.tsmDelete.Size = new System.Drawing.Size(79, 20);
            this.tsmDelete.Text = "Удалить";
            this.tsmDelete.Click += new System.EventHandler(this.tsmDelete_Click);
            // 
            // tsmUpdate
            // 
            this.tsmUpdate.Image = ((System.Drawing.Image)(resources.GetObject("tsmUpdate.Image")));
            this.tsmUpdate.Name = "tsmUpdate";
            this.tsmUpdate.Size = new System.Drawing.Size(89, 20);
            this.tsmUpdate.Text = "Обновить";
            this.tsmUpdate.Click += new System.EventHandler(this.tsmUpdate_Click);
            // 
            // tsmHelp
            // 
            this.tsmHelp.Image = ((System.Drawing.Image)(resources.GetObject("tsmHelp.Image")));
            this.tsmHelp.Name = "tsmHelp";
            this.tsmHelp.Size = new System.Drawing.Size(81, 20);
            this.tsmHelp.Text = "Справка";
            this.tsmHelp.Click += new System.EventHandler(this.tsmHelp_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 480);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(500, 350);
            this.Name = "MainForm";
            this.Text = "ОССМК Картотека";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocument)).EndInit();
            this.cmsDocument.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDocument;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ContextMenuStrip cmsDocument;
        private System.Windows.Forms.ToolStripMenuItem ctsEdit;
        private System.Windows.Forms.ToolStripMenuItem ctsDelete;
        private System.Windows.Forms.Button btnSelectInnerDoc;
        private System.Windows.Forms.Button btnSelectOuterDoc;
        private System.Windows.Forms.Button btnSelectPodrDoc;
        private System.Windows.Forms.Button btnSelectAllStandarts;
        private System.Windows.Forms.ToolStripMenuItem ctsExport;
        private System.Windows.Forms.SaveFileDialog sfdExportCard;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmAdd;
        private System.Windows.Forms.ToolStripMenuItem tsmDelete;
        private System.Windows.Forms.ToolStripMenuItem tsmUpdate;
        private System.Windows.Forms.ToolStripMenuItem tsmEdit;
        private System.Windows.Forms.ToolStripMenuItem tsmHelp;
    }
}

