namespace OCCMK_Kartoteka
{
    partial class EditDocForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditDocForm));
            this.sfdExportCard = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmExport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.gbChangeing.SuspendLayout();
            this.gbDocToDepartment.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAction
            // 
            this.btnAction.Click += new System.EventHandler(this.btnAction_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmEdit,
            this.tsmDelete,
            this.tsmExport,
            this.tsmPrint});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1136, 24);
            this.menuStrip1.TabIndex = 46;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmEdit
            // 
            this.tsmEdit.Image = ((System.Drawing.Image)(resources.GetObject("tsmEdit.Image")));
            this.tsmEdit.Name = "tsmEdit";
            this.tsmEdit.Size = new System.Drawing.Size(115, 20);
            this.tsmEdit.Text = "Редактировать";
            this.tsmEdit.Click += new System.EventHandler(this.tsmEdit_Click);
            // 
            // tsmDelete
            // 
            this.tsmDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsmDelete.Image")));
            this.tsmDelete.Name = "tsmDelete";
            this.tsmDelete.Size = new System.Drawing.Size(79, 20);
            this.tsmDelete.Text = "Удалить";
            this.tsmDelete.Click += new System.EventHandler(this.tsmDelete_Click);
            // 
            // tsmExport
            // 
            this.tsmExport.Image = ((System.Drawing.Image)(resources.GetObject("tsmExport.Image")));
            this.tsmExport.Name = "tsmExport";
            this.tsmExport.Size = new System.Drawing.Size(121, 20);
            this.tsmExport.Text = "Экспорт в Word";
            this.tsmExport.Click += new System.EventHandler(this.tsmExport_Click);
            // 
            // tsmPrint
            // 
            this.tsmPrint.Image = ((System.Drawing.Image)(resources.GetObject("tsmPrint.Image")));
            this.tsmPrint.Name = "tsmPrint";
            this.tsmPrint.Size = new System.Drawing.Size(74, 20);
            this.tsmPrint.Text = "Печать";
            this.tsmPrint.Click += new System.EventHandler(this.tsmPrint_Click);
            // 
            // EditDocForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 782);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "EditDocForm";
            this.Text = "Редактирование карточки";
            this.Load += new System.EventHandler(this.EditDocForm_Load);
            this.Controls.SetChildIndex(this.menuStrip1, 0);
            this.Controls.SetChildIndex(this.btnAction, 0);
            this.Controls.SetChildIndex(this.gbChangeing, 0);
            this.Controls.SetChildIndex(this.gbDocToDepartment, 0);
            this.gbChangeing.ResumeLayout(false);
            this.gbDocToDepartment.ResumeLayout(false);
            this.gbDocToDepartment.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog sfdExportCard;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmEdit;
        private System.Windows.Forms.ToolStripMenuItem tsmDelete;
        private System.Windows.Forms.ToolStripMenuItem tsmExport;
        private System.Windows.Forms.ToolStripMenuItem tsmPrint;
    }
}