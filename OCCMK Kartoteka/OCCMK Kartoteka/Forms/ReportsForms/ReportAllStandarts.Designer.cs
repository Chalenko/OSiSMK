namespace OCCMK_Kartoteka
{
    partial class ReportAllStandarts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportAllStandarts));
            this.label1 = new System.Windows.Forms.Label();
            this.dgvStandarts = new System.Windows.Forms.DataGridView();
            this.cmsStandarts = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmSendToFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSendToFind = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.ctsEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.ctsDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.btnFilter = new System.Windows.Forms.Button();
            this.gbFilter = new System.Windows.Forms.GroupBox();
            this.lblSum = new System.Windows.Forms.Label();
            this.lbFilterHistory = new System.Windows.Forms.ListBox();
            this.cmsFilterListBox = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiDeleteFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbFilter = new System.Windows.Forms.TextBox();
            this.tbFilterField = new System.Windows.Forms.TextBox();
            this.btnDropFilter = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.gbFind = new System.Windows.Forms.GroupBox();
            this.lblFindCount = new System.Windows.Forms.Label();
            this.btnClearFind = new System.Windows.Forms.Button();
            this.tbFind = new System.Windows.Forms.TextBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.gbTotal = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStandarts)).BeginInit();
            this.cmsStandarts.SuspendLayout();
            this.gbFilter.SuspendLayout();
            this.cmsFilterListBox.SuspendLayout();
            this.gbFind.SuspendLayout();
            this.gbTotal.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(265, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Перечень стандартов, внедренных на ПАО \"НМЗ\":";
            // 
            // dgvStandarts
            // 
            this.dgvStandarts.AllowUserToAddRows = false;
            this.dgvStandarts.AllowUserToDeleteRows = false;
            this.dgvStandarts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvStandarts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStandarts.ContextMenuStrip = this.cmsStandarts;
            this.dgvStandarts.ImeMode = System.Windows.Forms.ImeMode.AlphaFull;
            this.dgvStandarts.Location = new System.Drawing.Point(15, 25);
            this.dgvStandarts.MultiSelect = false;
            this.dgvStandarts.Name = "dgvStandarts";
            this.dgvStandarts.ReadOnly = true;
            this.dgvStandarts.RowHeadersVisible = false;
            this.dgvStandarts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStandarts.Size = new System.Drawing.Size(833, 554);
            this.dgvStandarts.TabIndex = 0;
            this.dgvStandarts.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvStandarts_ColumnHeaderMouseClick);
            this.dgvStandarts.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvDocuments_MouseDown);
            // 
            // cmsStandarts
            // 
            this.cmsStandarts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmSendToFilter,
            this.tsmSendToFind,
            this.tsmSeparator,
            this.ctsEdit,
            this.ctsDelete});
            this.cmsStandarts.Name = "contextMenuStripStandarts";
            this.cmsStandarts.Size = new System.Drawing.Size(155, 98);
            // 
            // tsmSendToFilter
            // 
            this.tsmSendToFilter.Image = ((System.Drawing.Image)(resources.GetObject("tsmSendToFilter.Image")));
            this.tsmSendToFilter.Name = "tsmSendToFilter";
            this.tsmSendToFilter.Size = new System.Drawing.Size(154, 22);
            this.tsmSendToFilter.Text = "В фильтр";
            this.tsmSendToFilter.Click += new System.EventHandler(this.tsmSendToFilter_Click);
            // 
            // tsmSendToFind
            // 
            this.tsmSendToFind.Image = ((System.Drawing.Image)(resources.GetObject("tsmSendToFind.Image")));
            this.tsmSendToFind.Name = "tsmSendToFind";
            this.tsmSendToFind.Size = new System.Drawing.Size(154, 22);
            this.tsmSendToFind.Text = "В поиск";
            this.tsmSendToFind.Click += new System.EventHandler(this.tsmSendToFind_Click);
            // 
            // tsmSeparator
            // 
            this.tsmSeparator.Name = "tsmSeparator";
            this.tsmSeparator.Size = new System.Drawing.Size(151, 6);
            // 
            // ctsEdit
            // 
            this.ctsEdit.Image = ((System.Drawing.Image)(resources.GetObject("ctsEdit.Image")));
            this.ctsEdit.Name = "ctsEdit";
            this.ctsEdit.Size = new System.Drawing.Size(154, 22);
            this.ctsEdit.Text = "Редактировать";
            this.ctsEdit.Click += new System.EventHandler(this.ctsEdit_Click);
            // 
            // ctsDelete
            // 
            this.ctsDelete.Image = ((System.Drawing.Image)(resources.GetObject("ctsDelete.Image")));
            this.ctsDelete.Name = "ctsDelete";
            this.ctsDelete.Size = new System.Drawing.Size(154, 22);
            this.ctsDelete.Text = "Удалить";
            this.ctsDelete.Click += new System.EventHandler(this.ctsDelete_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(6, 97);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(210, 23);
            this.btnFilter.TabIndex = 2;
            this.btnFilter.Text = "Применить фильтр";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // gbFilter
            // 
            this.gbFilter.Controls.Add(this.lblSum);
            this.gbFilter.Controls.Add(this.lbFilterHistory);
            this.gbFilter.Controls.Add(this.label3);
            this.gbFilter.Controls.Add(this.label4);
            this.gbFilter.Controls.Add(this.tbFilter);
            this.gbFilter.Controls.Add(this.tbFilterField);
            this.gbFilter.Controls.Add(this.btnDropFilter);
            this.gbFilter.Controls.Add(this.btnFilter);
            this.gbFilter.Controls.Add(this.label2);
            this.gbFilter.Location = new System.Drawing.Point(6, 8);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(222, 365);
            this.gbFilter.TabIndex = 0;
            this.gbFilter.TabStop = false;
            this.gbFilter.Text = "Фильтр";
            // 
            // lblSum
            // 
            this.lblSum.AutoSize = true;
            this.lblSum.Location = new System.Drawing.Point(6, 344);
            this.lblSum.Name = "lblSum";
            this.lblSum.Size = new System.Drawing.Size(47, 13);
            this.lblSum.TabIndex = 9;
            this.lblSum.Text = "Сумма: ";
            // 
            // lbFilterHistory
            // 
            this.lbFilterHistory.ContextMenuStrip = this.cmsFilterListBox;
            this.lbFilterHistory.FormattingEnabled = true;
            this.lbFilterHistory.HorizontalScrollbar = true;
            this.lbFilterHistory.Location = new System.Drawing.Point(6, 168);
            this.lbFilterHistory.Name = "lbFilterHistory";
            this.lbFilterHistory.ScrollAlwaysVisible = true;
            this.lbFilterHistory.Size = new System.Drawing.Size(210, 173);
            this.lbFilterHistory.TabIndex = 4;
            this.lbFilterHistory.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbFilterHistory_MouseClick);
            // 
            // cmsFilterListBox
            // 
            this.cmsFilterListBox.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiDeleteFilter});
            this.cmsFilterListBox.Name = "cms";
            this.cmsFilterListBox.Size = new System.Drawing.Size(119, 26);
            // 
            // tsmiDeleteFilter
            // 
            this.tsmiDeleteFilter.Image = ((System.Drawing.Image)(resources.GetObject("tsmiDeleteFilter.Image")));
            this.tsmiDeleteFilter.Name = "tsmiDeleteFilter";
            this.tsmiDeleteFilter.Size = new System.Drawing.Size(118, 22);
            this.tsmiDeleteFilter.Text = "Удалить";
            this.tsmiDeleteFilter.Click += new System.EventHandler(this.tsmiDeleteFilter_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "История фильтров";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Значение фильтра:";
            // 
            // tbFilter
            // 
            this.tbFilter.Location = new System.Drawing.Point(6, 32);
            this.tbFilter.Name = "tbFilter";
            this.tbFilter.Size = new System.Drawing.Size(210, 20);
            this.tbFilter.TabIndex = 0;
            this.tbFilter.TextChanged += new System.EventHandler(this.tbFilter_TextChanged);
            // 
            // tbFilterField
            // 
            this.tbFilterField.Location = new System.Drawing.Point(6, 71);
            this.tbFilterField.Name = "tbFilterField";
            this.tbFilterField.Size = new System.Drawing.Size(210, 20);
            this.tbFilterField.TabIndex = 1;
            this.tbFilterField.TextChanged += new System.EventHandler(this.tbFilterField_TextChanged);
            // 
            // btnDropFilter
            // 
            this.btnDropFilter.Location = new System.Drawing.Point(6, 126);
            this.btnDropFilter.Name = "btnDropFilter";
            this.btnDropFilter.Size = new System.Drawing.Size(210, 23);
            this.btnDropFilter.TabIndex = 3;
            this.btnDropFilter.Text = "Сбросить все фильтры";
            this.btnDropFilter.UseVisualStyleBackColor = true;
            this.btnDropFilter.Click += new System.EventHandler(this.btnDropFilter_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Поле фильтрации:";
            // 
            // gbFind
            // 
            this.gbFind.Controls.Add(this.lblFindCount);
            this.gbFind.Controls.Add(this.btnClearFind);
            this.gbFind.Controls.Add(this.tbFind);
            this.gbFind.Controls.Add(this.btnFind);
            this.gbFind.Location = new System.Drawing.Point(6, 379);
            this.gbFind.Name = "gbFind";
            this.gbFind.Size = new System.Drawing.Size(222, 122);
            this.gbFind.TabIndex = 1;
            this.gbFind.TabStop = false;
            this.gbFind.Text = "Поиск";
            // 
            // lblFindCount
            // 
            this.lblFindCount.AutoSize = true;
            this.lblFindCount.Location = new System.Drawing.Point(6, 100);
            this.lblFindCount.Name = "lblFindCount";
            this.lblFindCount.Size = new System.Drawing.Size(0, 13);
            this.lblFindCount.TabIndex = 3;
            // 
            // btnClearFind
            // 
            this.btnClearFind.Location = new System.Drawing.Point(6, 74);
            this.btnClearFind.Name = "btnClearFind";
            this.btnClearFind.Size = new System.Drawing.Size(210, 23);
            this.btnClearFind.TabIndex = 2;
            this.btnClearFind.Text = "Очистить";
            this.btnClearFind.UseVisualStyleBackColor = true;
            this.btnClearFind.Click += new System.EventHandler(this.btnClearFind_Click);
            // 
            // tbFind
            // 
            this.tbFind.Location = new System.Drawing.Point(6, 19);
            this.tbFind.Name = "tbFind";
            this.tbFind.Size = new System.Drawing.Size(210, 20);
            this.tbFind.TabIndex = 0;
            // 
            // btnFind
            // 
            this.btnFind.Image = ((System.Drawing.Image)(resources.GetObject("btnFind.Image")));
            this.btnFind.Location = new System.Drawing.Point(6, 45);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(210, 23);
            this.btnFind.TabIndex = 1;
            this.btnFind.Text = "Найти";
            this.btnFind.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFind.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Enabled = false;
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.Location = new System.Drawing.Point(854, 556);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(153, 23);
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "Экспорт в Excel";
            this.btnExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(1013, 556);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // gbTotal
            // 
            this.gbTotal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbTotal.Controls.Add(this.gbFilter);
            this.gbTotal.Controls.Add(this.gbFind);
            this.gbTotal.Location = new System.Drawing.Point(854, 18);
            this.gbTotal.Name = "gbTotal";
            this.gbTotal.Size = new System.Drawing.Size(234, 506);
            this.gbTotal.TabIndex = 1;
            this.gbTotal.TabStop = false;
            // 
            // ReportAllStandarts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 591);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.gbTotal);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvStandarts);
            this.Name = "ReportAllStandarts";
            this.Text = "Перечень стандартов, внедренных на ПАО \"НМЗ\"";
            this.Shown += new System.EventHandler(this.ReportAllStandarts_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStandarts)).EndInit();
            this.cmsStandarts.ResumeLayout(false);
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            this.cmsFilterListBox.ResumeLayout(false);
            this.gbFind.ResumeLayout(false);
            this.gbFind.PerformLayout();
            this.gbTotal.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvStandarts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.TextBox tbFilter;
        private System.Windows.Forms.Button btnDropFilter;
        private System.Windows.Forms.GroupBox gbFilter;
        private System.Windows.Forms.Label lblSum;
        private System.Windows.Forms.ContextMenuStrip cmsStandarts;
        private System.Windows.Forms.ToolStripMenuItem tsmSendToFilter;
        private System.Windows.Forms.ToolStripMenuItem tsmSendToFind;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbFilterField;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.ToolStripMenuItem ctsEdit;
        private System.Windows.Forms.ListBox lbFilterHistory;
        private System.Windows.Forms.ContextMenuStrip cmsFilterListBox;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteFilter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox gbFind;
        private System.Windows.Forms.Button btnClearFind;
        private System.Windows.Forms.TextBox tbFind;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.ToolStripSeparator tsmSeparator;
        private System.Windows.Forms.Label lblFindCount;
        private System.Windows.Forms.ToolStripMenuItem ctsDelete;
        private System.Windows.Forms.GroupBox gbTotal;
    }
}