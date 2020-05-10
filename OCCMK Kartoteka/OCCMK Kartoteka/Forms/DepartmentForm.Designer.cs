namespace OCCMK_Kartoteka.Forms
{
    partial class DepartmentForm
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
        protected void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DepartmentForm));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAction = new System.Windows.Forms.Button();
            this.lblCode = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.tbCode = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(290, 58);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAction
            // 
            this.btnAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAction.Location = new System.Drawing.Point(209, 58);
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(75, 23);
            this.btnAction.TabIndex = 3;
            this.btnAction.Text = "OK";
            this.btnAction.UseVisualStyleBackColor = true;
            this.btnAction.Click += new System.EventHandler(this.btnAction_Click);
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(12, 9);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(107, 13);
            this.lblCode.TabIndex = 5;
            this.lblCode.Text = "Код подразделения";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 35);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(74, 13);
            this.lblName.TabIndex = 6;
            this.lblName.Text = "Обозначение";
            // 
            // tbCode
            // 
            this.tbCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCode.Location = new System.Drawing.Point(129, 6);
            this.tbCode.Name = "tbCode";
            this.tbCode.Size = new System.Drawing.Size(236, 20);
            this.tbCode.TabIndex = 7;
            // 
            // tbName
            // 
            this.tbName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbName.Location = new System.Drawing.Point(129, 32);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(236, 20);
            this.tbName.TabIndex = 8;
            // 
            // DepartmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 92);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.tbCode);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAction);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(389, 130);
            this.Name = "DepartmentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Подразделение";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        protected System.Windows.Forms.Button btnAction;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Label lblName;
        protected System.Windows.Forms.TextBox tbCode;
        protected System.Windows.Forms.TextBox tbName;
    }
}