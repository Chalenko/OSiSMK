namespace OCCMK_Kartoteka
{
    partial class DocToDepartmentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DocToDepartmentForm));
            this.lblDepartment = new System.Windows.Forms.Label();
            this.lblGiveDate = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblTakeDate = new System.Windows.Forms.Label();
            this.btnAction = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dtpTakeDate = new System.Windows.Forms.DateTimePicker();
            this.tbName = new System.Windows.Forms.TextBox();
            this.dtpGiveDate = new System.Windows.Forms.DateTimePicker();
            this.btnDepartmentSelect = new System.Windows.Forms.Button();
            this.tbDepartment = new System.Windows.Forms.TextBox();
            this.lblCopyNumber = new System.Windows.Forms.Label();
            this.tbCopyName = new System.Windows.Forms.TextBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnSelectStatus = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Location = new System.Drawing.Point(12, 13);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(87, 13);
            this.lblDepartment.TabIndex = 0;
            this.lblDepartment.Text = "Подразделение";
            // 
            // lblGiveDate
            // 
            this.lblGiveDate.AutoSize = true;
            this.lblGiveDate.Location = new System.Drawing.Point(12, 95);
            this.lblGiveDate.Name = "lblGiveDate";
            this.lblGiveDate.Size = new System.Drawing.Size(73, 13);
            this.lblGiveDate.TabIndex = 1;
            this.lblGiveDate.Text = "Дата выдачи";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 118);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(108, 13);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Ф.И.О получившего";
            // 
            // lblTakeDate
            // 
            this.lblTakeDate.AutoSize = true;
            this.lblTakeDate.Location = new System.Drawing.Point(12, 147);
            this.lblTakeDate.Name = "lblTakeDate";
            this.lblTakeDate.Size = new System.Drawing.Size(83, 13);
            this.lblTakeDate.TabIndex = 3;
            this.lblTakeDate.Text = "Дата возврата";
            // 
            // btnAction
            // 
            this.btnAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAction.Location = new System.Drawing.Point(204, 167);
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(75, 23);
            this.btnAction.TabIndex = 8;
            this.btnAction.UseVisualStyleBackColor = true;
            this.btnAction.Click += new System.EventHandler(this.btnAction_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(285, 167);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // dtpTakeDate
            // 
            this.dtpTakeDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpTakeDate.Checked = false;
            this.dtpTakeDate.Location = new System.Drawing.Point(126, 141);
            this.dtpTakeDate.Name = "dtpTakeDate";
            this.dtpTakeDate.ShowCheckBox = true;
            this.dtpTakeDate.Size = new System.Drawing.Size(234, 20);
            this.dtpTakeDate.TabIndex = 7;
            // 
            // tbName
            // 
            this.tbName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbName.Location = new System.Drawing.Point(126, 115);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(234, 20);
            this.tbName.TabIndex = 6;
            this.tbName.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            // 
            // dtpGiveDate
            // 
            this.dtpGiveDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpGiveDate.Checked = false;
            this.dtpGiveDate.Location = new System.Drawing.Point(126, 89);
            this.dtpGiveDate.Name = "dtpGiveDate";
            this.dtpGiveDate.ShowCheckBox = true;
            this.dtpGiveDate.Size = new System.Drawing.Size(234, 20);
            this.dtpGiveDate.TabIndex = 5;
            this.dtpGiveDate.ValueChanged += new System.EventHandler(this.dtpGiveDate_ValueChanged);
            // 
            // btnDepartmentSelect
            // 
            this.btnDepartmentSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDepartmentSelect.Location = new System.Drawing.Point(301, 10);
            this.btnDepartmentSelect.Name = "btnDepartmentSelect";
            this.btnDepartmentSelect.Size = new System.Drawing.Size(59, 20);
            this.btnDepartmentSelect.TabIndex = 1;
            this.btnDepartmentSelect.Text = "Выбрать";
            this.btnDepartmentSelect.UseVisualStyleBackColor = true;
            this.btnDepartmentSelect.Click += new System.EventHandler(this.btnDepartmentSelect_Click);
            // 
            // tbDepartment
            // 
            this.tbDepartment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDepartment.Location = new System.Drawing.Point(126, 10);
            this.tbDepartment.Name = "tbDepartment";
            this.tbDepartment.ReadOnly = true;
            this.tbDepartment.Size = new System.Drawing.Size(169, 20);
            this.tbDepartment.TabIndex = 0;
            this.tbDepartment.TextChanged += new System.EventHandler(this.tbDepartment_TextChanged);
            // 
            // lblCopyNumber
            // 
            this.lblCopyNumber.AutoSize = true;
            this.lblCopyNumber.Location = new System.Drawing.Point(12, 39);
            this.lblCopyNumber.Name = "lblCopyNumber";
            this.lblCopyNumber.Size = new System.Drawing.Size(106, 13);
            this.lblCopyNumber.TabIndex = 12;
            this.lblCopyNumber.Text = "Номер экземпляра";
            // 
            // tbCopyName
            // 
            this.tbCopyName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCopyName.Location = new System.Drawing.Point(126, 36);
            this.tbCopyName.Name = "tbCopyName";
            this.tbCopyName.Size = new System.Drawing.Size(234, 20);
            this.tbCopyName.TabIndex = 2;
            this.tbCopyName.TextChanged += new System.EventHandler(this.tbCopyName_TextChanged);
            // 
            // cmbStatus
            // 
            this.cmbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(126, 62);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(169, 21);
            this.cmbStatus.TabIndex = 3;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 66);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(41, 13);
            this.lblStatus.TabIndex = 18;
            this.lblStatus.Text = "Статус";
            // 
            // btnSelectStatus
            // 
            this.btnSelectStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectStatus.Location = new System.Drawing.Point(301, 62);
            this.btnSelectStatus.Name = "btnSelectStatus";
            this.btnSelectStatus.Size = new System.Drawing.Size(59, 21);
            this.btnSelectStatus.TabIndex = 4;
            this.btnSelectStatus.Text = "Выбрать";
            this.btnSelectStatus.UseVisualStyleBackColor = true;
            this.btnSelectStatus.Click += new System.EventHandler(this.btnSelectStatus_Click);
            // 
            // DocToDepartmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(365, 199);
            this.Controls.Add(this.btnSelectStatus);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.tbCopyName);
            this.Controls.Add(this.lblCopyNumber);
            this.Controls.Add(this.tbDepartment);
            this.Controls.Add(this.btnDepartmentSelect);
            this.Controls.Add(this.dtpGiveDate);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.dtpTakeDate);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAction);
            this.Controls.Add(this.lblTakeDate);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblGiveDate);
            this.Controls.Add(this.lblDepartment);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(381, 237);
            this.Name = "DocToDepartmentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Экземпляр документа выданного в подразделение";
            this.Shown += new System.EventHandler(this.DocToDepartmentForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.Label lblGiveDate;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblTakeDate;
        protected System.Windows.Forms.Button btnAction;
        private System.Windows.Forms.Button btnCancel;
        protected System.Windows.Forms.DateTimePicker dtpTakeDate;
        protected System.Windows.Forms.TextBox tbName;
        protected System.Windows.Forms.DateTimePicker dtpGiveDate;
        private System.Windows.Forms.Button btnDepartmentSelect;
        protected System.Windows.Forms.TextBox tbDepartment;
        private System.Windows.Forms.Label lblCopyNumber;
        protected System.Windows.Forms.TextBox tbCopyName;
        protected System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnSelectStatus;
    }
}