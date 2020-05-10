namespace OCCMK_Kartoteka
{
    partial class ReportDocSinceTo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportDocSinceTo));
            this.dtpSince = new System.Windows.Forms.DateTimePicker();
            this.lblMainPhaseMulti = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.btnGet = new System.Windows.Forms.Button();
            this.dgvStandarts = new System.Windows.Forms.DataGridView();
            this.cmsGoToEditDoc = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStandarts)).BeginInit();
            this.cmsGoToEditDoc.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpSince
            // 
            this.dtpSince.Location = new System.Drawing.Point(31, 16);
            this.dtpSince.Name = "dtpSince";
            this.dtpSince.Size = new System.Drawing.Size(151, 20);
            this.dtpSince.TabIndex = 1;
            // 
            // lblMainPhaseMulti
            // 
            this.lblMainPhaseMulti.AutoSize = true;
            this.lblMainPhaseMulti.Location = new System.Drawing.Point(12, 3);
            this.lblMainPhaseMulti.Name = "lblMainPhaseMulti";
            this.lblMainPhaseMulti.Size = new System.Drawing.Size(0, 13);
            this.lblMainPhaseMulti.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(188, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "по";
            // 
            // dtpTo
            // 
            this.dtpTo.Location = new System.Drawing.Point(213, 16);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(151, 20);
            this.dtpTo.TabIndex = 2;
            // 
            // btnGet
            // 
            this.btnGet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGet.Image = ((System.Drawing.Image)(resources.GetObject("btnGet.Image")));
            this.btnGet.Location = new System.Drawing.Point(735, 3);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(115, 23);
            this.btnGet.TabIndex = 3;
            this.btnGet.Text = "Получить";
            this.btnGet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGet.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // dgvDocuments
            // 
            this.dgvStandarts.AllowUserToAddRows = false;
            this.dgvStandarts.AllowUserToDeleteRows = false;
            this.dgvStandarts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvStandarts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStandarts.ContextMenuStrip = this.cmsGoToEditDoc;
            this.dgvStandarts.Location = new System.Drawing.Point(15, 42);
            this.dgvStandarts.MultiSelect = false;
            this.dgvStandarts.Name = "dgvDocuments";
            this.dgvStandarts.ReadOnly = true;
            this.dgvStandarts.RowHeadersVisible = false;
            this.dgvStandarts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStandarts.Size = new System.Drawing.Size(838, 185);
            this.dgvStandarts.TabIndex = 4;
            this.dgvStandarts.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvStandarts_ColumnHeaderMouseClick);
            this.dgvStandarts.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvDocuments_MouseDown);
            // 
            // cmsGoToEditDoc
            // 
            this.cmsGoToEditDoc.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiEdit,
            this.tsmiDelete});
            this.cmsGoToEditDoc.Name = "cmsGoToEditDoc";
            this.cmsGoToEditDoc.Size = new System.Drawing.Size(155, 48);
            // 
            // tsmiEdit
            // 
            this.tsmiEdit.Image = ((System.Drawing.Image)(resources.GetObject("tsmiEdit.Image")));
            this.tsmiEdit.Name = "tsmiEdit";
            this.tsmiEdit.Size = new System.Drawing.Size(154, 22);
            this.tsmiEdit.Text = "Редактировать";
            this.tsmiEdit.Click += new System.EventHandler(this.tsmiEdit_Click);
            // 
            // tsmiDelete
            // 
            this.tsmiDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsmiDelete.Image")));
            this.tsmiDelete.Name = "tsmiDelete";
            this.tsmiDelete.Size = new System.Drawing.Size(154, 22);
            this.tsmiDelete.Text = "Удалить";
            this.tsmiDelete.Click += new System.EventHandler(this.tsmiDelete_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Enabled = false;
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.Location = new System.Drawing.Point(647, 236);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(122, 23);
            this.btnExport.TabIndex = 5;
            this.btnExport.Text = "Экспорт в Excel";
            this.btnExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(775, 236);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "c";
            // 
            // ReportDocSinceTo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 266);
            this.Controls.Add(this.dgvStandarts);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnGet);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblMainPhaseMulti);
            this.Controls.Add(this.dtpSince);
            this.Name = "ReportDocSinceTo";
            this.Text = "Перечень документов с ... по ...";
            this.Load += new System.EventHandler(this.ReportDocSinceTo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStandarts)).EndInit();
            this.cmsGoToEditDoc.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvStandarts;
        private System.Windows.Forms.DateTimePicker dtpSince;
        private System.Windows.Forms.Label lblMainPhaseMulti;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip cmsGoToEditDoc;
        private System.Windows.Forms.ToolStripMenuItem tsmiEdit;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelete;
    }
}