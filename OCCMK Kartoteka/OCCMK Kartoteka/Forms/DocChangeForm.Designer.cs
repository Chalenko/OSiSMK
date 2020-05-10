namespace OCCMK_Kartoteka
{
    partial class DocChangeForm
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
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        protected void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DocChangeForm));
            this.btnAction = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dtpDateOfIntro = new System.Windows.Forms.DateTimePicker();
            this.dtpDateOfReg = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbDocumentName = new System.Windows.Forms.TextBox();
            this.lblDocumentEasterEggs = new System.Windows.Forms.Label();
            this.tbChangeNum = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAction
            // 
            this.btnAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAction.Location = new System.Drawing.Point(233, 110);
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(75, 23);
            this.btnAction.TabIndex = 4;
            this.btnAction.UseVisualStyleBackColor = true;
            this.btnAction.Click += new System.EventHandler(this.btnAction_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(314, 110);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Отменить";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dtpDateOfIntro
            // 
            this.dtpDateOfIntro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDateOfIntro.Location = new System.Drawing.Point(165, 84);
            this.dtpDateOfIntro.Name = "dtpDateOfIntro";
            this.dtpDateOfIntro.ShowCheckBox = true;
            this.dtpDateOfIntro.Size = new System.Drawing.Size(224, 20);
            this.dtpDateOfIntro.TabIndex = 3;
            // 
            // dtpDateOfReg
            // 
            this.dtpDateOfReg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDateOfReg.Location = new System.Drawing.Point(165, 58);
            this.dtpDateOfReg.Name = "dtpDateOfReg";
            this.dtpDateOfReg.ShowCheckBox = true;
            this.dtpDateOfReg.Size = new System.Drawing.Size(224, 20);
            this.dtpDateOfReg.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Дата регистрации";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Дата введения в действие";
            // 
            // tbDocumentName
            // 
            this.tbDocumentName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDocumentName.Location = new System.Drawing.Point(165, 32);
            this.tbDocumentName.Name = "tbDocumentName";
            this.tbDocumentName.Size = new System.Drawing.Size(224, 20);
            this.tbDocumentName.TabIndex = 1;
            this.tbDocumentName.TextChanged += new System.EventHandler(this.tbDocumentName_TextChanged);
            // 
            // lblDocumentEasterEggs
            // 
            this.lblDocumentEasterEggs.AutoSize = true;
            this.lblDocumentEasterEggs.Location = new System.Drawing.Point(12, 35);
            this.lblDocumentEasterEggs.Name = "lblDocumentEasterEggs";
            this.lblDocumentEasterEggs.Size = new System.Drawing.Size(58, 13);
            this.lblDocumentEasterEggs.TabIndex = 13;
            this.lblDocumentEasterEggs.Text = "Документ";
            this.lblDocumentEasterEggs.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lblDocumentEasterEggs_MouseClick);
            // 
            // tbChangeNum
            // 
            this.tbChangeNum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbChangeNum.Location = new System.Drawing.Point(165, 6);
            this.tbChangeNum.Name = "tbChangeNum";
            this.tbChangeNum.Size = new System.Drawing.Size(224, 20);
            this.tbChangeNum.TabIndex = 0;
            this.tbChangeNum.TextChanged += new System.EventHandler(this.tbChangeNum_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Номер изменения/поправки";
            // 
            // DocChangeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 146);
            this.Controls.Add(this.btnAction);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.dtpDateOfIntro);
            this.Controls.Add(this.dtpDateOfReg);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbDocumentName);
            this.Controls.Add(this.lblDocumentEasterEggs);
            this.Controls.Add(this.tbChangeNum);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(414, 180);
            this.Name = "DocChangeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Документ выдан в подразделение: ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Button btnAction;
        private System.Windows.Forms.Button btnCancel;
        protected System.Windows.Forms.DateTimePicker dtpDateOfIntro;
        protected System.Windows.Forms.DateTimePicker dtpDateOfReg;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        protected System.Windows.Forms.TextBox tbDocumentName;
        private System.Windows.Forms.Label lblDocumentEasterEggs;
        protected System.Windows.Forms.TextBox tbChangeNum;
        private System.Windows.Forms.Label label1;

    }
}