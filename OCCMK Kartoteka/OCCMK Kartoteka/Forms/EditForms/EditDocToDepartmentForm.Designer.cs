namespace OCCMK_Kartoteka
{
    partial class EditDocToDepartmentForm : DocToDepartmentForm
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
        private new void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // btnAction
            // 
            this.btnAction.Text = "Изменить";
            // 
            // tbCopyName
            // 
            this.tbCopyName.ReadOnly = true;
            // 
            // EditDocToDepartmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 203);
            this.Name = "EditDocToDepartmentForm";
            this.Text = "Редактирование экземпляра документа выданного в подразделение";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}