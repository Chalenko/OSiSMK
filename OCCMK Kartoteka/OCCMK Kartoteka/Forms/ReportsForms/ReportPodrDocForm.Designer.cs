namespace OCCMK_Kartoteka
{
    partial class ReportPodrDocForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportPodrDocForm));
            this.btnClose = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.gbStatistic = new System.Windows.Forms.GroupBox();
            this.lblAllDocCount = new System.Windows.Forms.Label();
            this.dgvStatistic = new System.Windows.Forms.DataGridView();
            this.cmsStatistic = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tmsEditDocument = new System.Windows.Forms.ToolStripMenuItem();
            this.tmsDeleteDocument = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvMainList = new System.Windows.Forms.DataGridView();
            this.cmsMainList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiEditCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSelectDS = new System.Windows.Forms.Button();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbStatistic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatistic)).BeginInit();
            this.cmsStatistic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMainList)).BeginInit();
            this.cmsMainList.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(967, 548);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Enabled = false;
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.Location = new System.Drawing.Point(573, 548);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(113, 23);
            this.btnExport.TabIndex = 4;
            this.btnExport.Text = "Экспорт в Excel";
            this.btnExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // gbStatistic
            // 
            this.gbStatistic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbStatistic.Controls.Add(this.lblAllDocCount);
            this.gbStatistic.Controls.Add(this.dgvStatistic);
            this.gbStatistic.Location = new System.Drawing.Point(573, 33);
            this.gbStatistic.Name = "gbStatistic";
            this.gbStatistic.Size = new System.Drawing.Size(469, 375);
            this.gbStatistic.TabIndex = 3;
            this.gbStatistic.TabStop = false;
            this.gbStatistic.Text = "Статистика";
            // 
            // lblAllDocCount
            // 
            this.lblAllDocCount.AutoSize = true;
            this.lblAllDocCount.Location = new System.Drawing.Point(6, 357);
            this.lblAllDocCount.Name = "lblAllDocCount";
            this.lblAllDocCount.Size = new System.Drawing.Size(16, 13);
            this.lblAllDocCount.TabIndex = 1;
            this.lblAllDocCount.Text = "---";
            // 
            // dgvStatistic
            // 
            this.dgvStatistic.AllowUserToAddRows = false;
            this.dgvStatistic.AllowUserToDeleteRows = false;
            this.dgvStatistic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvStatistic.ContextMenuStrip = this.cmsStatistic;
            this.dgvStatistic.Location = new System.Drawing.Point(6, 19);
            this.dgvStatistic.MultiSelect = false;
            this.dgvStatistic.Name = "dgvStatistic";
            this.dgvStatistic.ReadOnly = true;
            this.dgvStatistic.RowHeadersVisible = false;
            this.dgvStatistic.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStatistic.Size = new System.Drawing.Size(457, 335);
            this.dgvStatistic.TabIndex = 0;
            this.dgvStatistic.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvStatistic_MouseDown);
            // 
            // cmsStatistic
            // 
            this.cmsStatistic.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmsEditDocument,
            this.tmsDeleteDocument});
            this.cmsStatistic.Name = "cmsStatistic";
            this.cmsStatistic.Size = new System.Drawing.Size(210, 48);
            // 
            // tmsEditDocument
            // 
            this.tmsEditDocument.Image = ((System.Drawing.Image)(resources.GetObject("tmsEditDocument.Image")));
            this.tmsEditDocument.Name = "tmsEditDocument";
            this.tmsEditDocument.Size = new System.Drawing.Size(209, 22);
            this.tmsEditDocument.Text = "Редактировать документ";
            this.tmsEditDocument.Click += new System.EventHandler(this.tmsEditDocument_Click);
            // 
            // tmsDeleteDocument
            // 
            this.tmsDeleteDocument.Image = ((System.Drawing.Image)(resources.GetObject("tmsDeleteDocument.Image")));
            this.tmsDeleteDocument.Name = "tmsDeleteDocument";
            this.tmsDeleteDocument.Size = new System.Drawing.Size(209, 22);
            this.tmsDeleteDocument.Text = "Удалить документ";
            this.tmsDeleteDocument.Click += new System.EventHandler(this.tmsDeleteDocument_Click);
            // 
            // dgvMainList
            // 
            this.dgvMainList.AllowUserToAddRows = false;
            this.dgvMainList.AllowUserToDeleteRows = false;
            this.dgvMainList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMainList.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvMainList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvMainList.ContextMenuStrip = this.cmsMainList;
            this.dgvMainList.Location = new System.Drawing.Point(15, 33);
            this.dgvMainList.MultiSelect = false;
            this.dgvMainList.Name = "dgvMainList";
            this.dgvMainList.ReadOnly = true;
            this.dgvMainList.RowHeadersVisible = false;
            this.dgvMainList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMainList.Size = new System.Drawing.Size(552, 538);
            this.dgvMainList.TabIndex = 2;
            this.dgvMainList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMainList_CellClick);
            this.dgvMainList.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvMainList_ColumnHeaderMouseClick);
            this.dgvMainList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvMainList_MouseDown);
            // 
            // cmsMainList
            // 
            this.cmsMainList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiEditCopy});
            this.cmsMainList.Name = "cmsGoToCopyEdit";
            this.cmsMainList.Size = new System.Drawing.Size(217, 26);
            // 
            // tsmiEditCopy
            // 
            this.tsmiEditCopy.Image = ((System.Drawing.Image)(resources.GetObject("tsmiEditCopy.Image")));
            this.tsmiEditCopy.Name = "tsmiEditCopy";
            this.tsmiEditCopy.Size = new System.Drawing.Size(216, 22);
            this.tsmiEditCopy.Text = "Редактировать экземпляр";
            this.tsmiEditCopy.Click += new System.EventHandler(this.tsmiEditCopy_Click);
            // 
            // btnSelectDS
            // 
            this.btnSelectDS.Image = ((System.Drawing.Image)(resources.GetObject("btnSelectDS.Image")));
            this.btnSelectDS.Location = new System.Drawing.Point(676, 4);
            this.btnSelectDS.Name = "btnSelectDS";
            this.btnSelectDS.Size = new System.Drawing.Size(295, 23);
            this.btnSelectDS.TabIndex = 1;
            this.btnSelectDS.Text = "Выбрать ДС";
            this.btnSelectDS.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSelectDS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSelectDS.UseVisualStyleBackColor = true;
            this.btnSelectDS.Click += new System.EventHandler(this.btnSelectDS_Click);
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(108, 6);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(562, 21);
            this.cmbDepartment.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Подразделение:";
            // 
            // ReportPodrDocForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 583);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.gbStatistic);
            this.Controls.Add(this.dgvMainList);
            this.Controls.Add(this.btnSelectDS);
            this.Controls.Add(this.cmbDepartment);
            this.Controls.Add(this.label1);
            this.Name = "ReportPodrDocForm";
            this.Text = "Перечень ДС, выданных в подразделение...";
            this.gbStatistic.ResumeLayout(false);
            this.gbStatistic.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatistic)).EndInit();
            this.cmsStatistic.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMainList)).EndInit();
            this.cmsMainList.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.Button btnSelectDS;
        private System.Windows.Forms.DataGridView dgvMainList;
        private System.Windows.Forms.GroupBox gbStatistic;
        private System.Windows.Forms.DataGridView dgvStatistic;
        private System.Windows.Forms.Label lblAllDocCount;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ContextMenuStrip cmsMainList;
        private System.Windows.Forms.ToolStripMenuItem tsmiEditCopy;
        private System.Windows.Forms.ContextMenuStrip cmsStatistic;
        private System.Windows.Forms.ToolStripMenuItem tmsEditDocument;
        private System.Windows.Forms.ToolStripMenuItem tmsDeleteDocument;
    }
}