namespace OCCMK_Kartoteka
{
    partial class DocForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DocForm));
            this.rbOuterDocument = new System.Windows.Forms.RadioButton();
            this.rbInnerDocument = new System.Windows.Forms.RadioButton();
            this.gbDocument = new System.Windows.Forms.GroupBox();
            this.chbOriginal = new System.Windows.Forms.CheckBox();
            this.chbControlCopy = new System.Windows.Forms.CheckBox();
            this.btnSelectDeveloper = new System.Windows.Forms.Button();
            this.btnSelectSecretType = new System.Windows.Forms.Button();
            this.btnSelectStatus = new System.Windows.Forms.Button();
            this.cmbDeveloper = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbSecurity = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbDocumentName = new System.Windows.Forms.TextBox();
            this.tbDocumentOboznachenine = new System.Windows.Forms.TextBox();
            this.dtpEnterDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.gbReceiveInformation = new System.Windows.Forms.GroupBox();
            this.tbGettingCount = new System.Windows.Forms.MaskedTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.dtpDateOfReceiving = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.dtpDateOfReg = new System.Windows.Forms.DateTimePicker();
            this.cmbAdressOfReceiver = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tbGettingNumber = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbQueryNumber = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.gbQueryInformation = new System.Windows.Forms.GroupBox();
            this.dtpQueryDate = new System.Windows.Forms.DateTimePicker();
            this.cmbQueryAdress = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBoxActOfInception = new System.Windows.Forms.GroupBox();
            this.dtpActOfInceptionDate = new System.Windows.Forms.DateTimePicker();
            this.label16 = new System.Windows.Forms.Label();
            this.tbActOfInceptionNumber = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.gbActOfChecking = new System.Windows.Forms.GroupBox();
            this.dtpActOfChecking = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            this.tbActOfCheckingNumber = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBoxCheckingDate = new System.Windows.Forms.GroupBox();
            this.label20 = new System.Windows.Forms.Label();
            this.dtpDateOfCheck = new System.Windows.Forms.DateTimePicker();
            this.label19 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAction = new System.Windows.Forms.Button();
            this.tbVzamen = new System.Windows.Forms.TextBox();
            this.tbZamenen = new System.Windows.Forms.TextBox();
            this.btnSelectVzamen = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.groupBoxInceptionInformation = new System.Windows.Forms.GroupBox();
            this.btnClearTbDepartment = new System.Windows.Forms.Button();
            this.dtpEnteringOnPlantDate = new System.Windows.Forms.DateTimePicker();
            this.label30 = new System.Windows.Forms.Label();
            this.dtpOtmFinishDate = new System.Windows.Forms.DateTimePicker();
            this.label29 = new System.Windows.Forms.Label();
            this.dtpDateOfOrder = new System.Windows.Forms.DateTimePicker();
            this.label28 = new System.Windows.Forms.Label();
            this.tbOrderNumber = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.btnInceptionResponseDepartment = new System.Windows.Forms.Button();
            this.tbResponseInceptionDepartment = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.dtpInceptionDate = new System.Windows.Forms.DateTimePicker();
            this.label25 = new System.Windows.Forms.Label();
            this.tbPoruchenieNumber = new System.Windows.Forms.TextBox();
            this.btnSelectZamenen = new System.Windows.Forms.Button();
            this.btnClearTbZamenen = new System.Windows.Forms.Button();
            this.btnClearTbVzamen = new System.Windows.Forms.Button();
            this.gbChangeing = new System.Windows.Forms.GroupBox();
            this.btnEditChanging = new System.Windows.Forms.Button();
            this.btnAddChanging = new System.Windows.Forms.Button();
            this.btnDeleteChanging = new System.Windows.Forms.Button();
            this.dgvChanging = new System.Windows.Forms.DataGridView();
            this.gbDocToDepartment = new System.Windows.Forms.GroupBox();
            this.btnEditDepartment = new System.Windows.Forms.Button();
            this.btnSelectDepartmentForDoc = new System.Windows.Forms.Button();
            this.tbSelectedDepartmentForDoc = new System.Windows.Forms.TextBox();
            this.rbSelectDepartmentForDoc = new System.Windows.Forms.RadioButton();
            this.rbAllDepartmentForDoc = new System.Windows.Forms.RadioButton();
            this.lblReturnCopyCount = new System.Windows.Forms.Label();
            this.lblTotalCopyCount = new System.Windows.Forms.Label();
            this.btnDeleteDepartment = new System.Windows.Forms.Button();
            this.btnAddDepartment = new System.Windows.Forms.Button();
            this.dgvDepartment = new System.Windows.Forms.DataGridView();
            this.gbVzamenZamenen = new System.Windows.Forms.GroupBox();
            this.lblVzamen = new System.Windows.Forms.Label();
            this.lblZamenen = new System.Windows.Forms.Label();
            this.gbEndDate = new System.Windows.Forms.GroupBox();
            this.label21 = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.label22 = new System.Windows.Forms.Label();
            this.gbDocument.SuspendLayout();
            this.gbReceiveInformation.SuspendLayout();
            this.gbQueryInformation.SuspendLayout();
            this.groupBoxActOfInception.SuspendLayout();
            this.gbActOfChecking.SuspendLayout();
            this.groupBoxCheckingDate.SuspendLayout();
            this.groupBoxInceptionInformation.SuspendLayout();
            this.gbChangeing.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChanging)).BeginInit();
            this.gbDocToDepartment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartment)).BeginInit();
            this.gbVzamenZamenen.SuspendLayout();
            this.gbEndDate.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbOuterDocument
            // 
            this.rbOuterDocument.AutoSize = true;
            this.rbOuterDocument.Location = new System.Drawing.Point(99, 20);
            this.rbOuterDocument.Name = "rbOuterDocument";
            this.rbOuterDocument.Size = new System.Drawing.Size(70, 17);
            this.rbOuterDocument.TabIndex = 1;
            this.rbOuterDocument.Text = "Внешний";
            this.rbOuterDocument.UseVisualStyleBackColor = true;
            this.rbOuterDocument.CheckedChanged += new System.EventHandler(this.rbOuterDocument_CheckedChanged);
            // 
            // rbInnerDocument
            // 
            this.rbInnerDocument.AutoSize = true;
            this.rbInnerDocument.Checked = true;
            this.rbInnerDocument.Location = new System.Drawing.Point(9, 20);
            this.rbInnerDocument.Name = "rbInnerDocument";
            this.rbInnerDocument.Size = new System.Drawing.Size(84, 17);
            this.rbInnerDocument.TabIndex = 0;
            this.rbInnerDocument.TabStop = true;
            this.rbInnerDocument.Text = "Внутренний";
            this.rbInnerDocument.UseVisualStyleBackColor = true;
            this.rbInnerDocument.CheckedChanged += new System.EventHandler(this.rbInnerDocument_CheckedChanged);
            // 
            // gbDocument
            // 
            this.gbDocument.Controls.Add(this.chbOriginal);
            this.gbDocument.Controls.Add(this.chbControlCopy);
            this.gbDocument.Controls.Add(this.btnSelectDeveloper);
            this.gbDocument.Controls.Add(this.btnSelectSecretType);
            this.gbDocument.Controls.Add(this.btnSelectStatus);
            this.gbDocument.Controls.Add(this.cmbDeveloper);
            this.gbDocument.Controls.Add(this.label6);
            this.gbDocument.Controls.Add(this.cmbSecurity);
            this.gbDocument.Controls.Add(this.label5);
            this.gbDocument.Controls.Add(this.cmbStatus);
            this.gbDocument.Controls.Add(this.label4);
            this.gbDocument.Controls.Add(this.label1);
            this.gbDocument.Controls.Add(this.label2);
            this.gbDocument.Controls.Add(this.tbDocumentName);
            this.gbDocument.Controls.Add(this.tbDocumentOboznachenine);
            this.gbDocument.Controls.Add(this.dtpEnterDate);
            this.gbDocument.Controls.Add(this.label3);
            this.gbDocument.Controls.Add(this.rbOuterDocument);
            this.gbDocument.Controls.Add(this.rbInnerDocument);
            this.gbDocument.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDocument.Location = new System.Drawing.Point(14, 24);
            this.gbDocument.Name = "gbDocument";
            this.gbDocument.Size = new System.Drawing.Size(746, 192);
            this.gbDocument.TabIndex = 0;
            this.gbDocument.TabStop = false;
            this.gbDocument.Text = "Документ";
            // 
            // chbOriginal
            // 
            this.chbOriginal.AutoSize = true;
            this.chbOriginal.Location = new System.Drawing.Point(498, 19);
            this.chbOriginal.Name = "chbOriginal";
            this.chbOriginal.Size = new System.Drawing.Size(75, 17);
            this.chbOriginal.TabIndex = 2;
            this.chbOriginal.Text = "Оригинал";
            this.chbOriginal.UseVisualStyleBackColor = true;
            // 
            // chbControlCopy
            // 
            this.chbControlCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chbControlCopy.AutoSize = true;
            this.chbControlCopy.Location = new System.Drawing.Point(584, 19);
            this.chbControlCopy.Name = "chbControlCopy";
            this.chbControlCopy.Size = new System.Drawing.Size(153, 17);
            this.chbControlCopy.TabIndex = 3;
            this.chbControlCopy.Text = "Контрольный экземпляр";
            this.chbControlCopy.UseVisualStyleBackColor = true;
            // 
            // btnSelectDeveloper
            // 
            this.btnSelectDeveloper.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectDeveloper.Location = new System.Drawing.Point(670, 156);
            this.btnSelectDeveloper.Name = "btnSelectDeveloper";
            this.btnSelectDeveloper.Size = new System.Drawing.Size(67, 22);
            this.btnSelectDeveloper.TabIndex = 18;
            this.btnSelectDeveloper.Text = "Изменить";
            this.btnSelectDeveloper.UseVisualStyleBackColor = true;
            this.btnSelectDeveloper.Click += new System.EventHandler(this.btnSelectDeveloper_Click);
            // 
            // btnSelectSecretType
            // 
            this.btnSelectSecretType.Location = new System.Drawing.Point(670, 128);
            this.btnSelectSecretType.Name = "btnSelectSecretType";
            this.btnSelectSecretType.Size = new System.Drawing.Size(67, 22);
            this.btnSelectSecretType.TabIndex = 15;
            this.btnSelectSecretType.Text = "Изменить";
            this.btnSelectSecretType.UseVisualStyleBackColor = true;
            this.btnSelectSecretType.Click += new System.EventHandler(this.btnSelectSecurity_Click);
            // 
            // btnSelectStatus
            // 
            this.btnSelectStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectStatus.Location = new System.Drawing.Point(670, 100);
            this.btnSelectStatus.Name = "btnSelectStatus";
            this.btnSelectStatus.Size = new System.Drawing.Size(68, 22);
            this.btnSelectStatus.TabIndex = 12;
            this.btnSelectStatus.Text = "Изменить";
            this.btnSelectStatus.UseVisualStyleBackColor = true;
            this.btnSelectStatus.Click += new System.EventHandler(this.btnSelectStatus_Click);
            // 
            // cmbDeveloper
            // 
            this.cmbDeveloper.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbDeveloper.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDeveloper.FormattingEnabled = true;
            this.cmbDeveloper.Location = new System.Drawing.Point(154, 157);
            this.cmbDeveloper.Name = "cmbDeveloper";
            this.cmbDeveloper.Size = new System.Drawing.Size(510, 21);
            this.cmbDeveloper.TabIndex = 17;
            this.cmbDeveloper.DropDown += new System.EventHandler(this.cmbDeveloper_DropDown);
            this.cmbDeveloper.TextChanged += new System.EventHandler(this.cmbDeveloper_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Разработчик";
            // 
            // cmbSecurity
            // 
            this.cmbSecurity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSecurity.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSecurity.FormattingEnabled = true;
            this.cmbSecurity.Location = new System.Drawing.Point(154, 128);
            this.cmbSecurity.Name = "cmbSecurity";
            this.cmbSecurity.Size = new System.Drawing.Size(510, 21);
            this.cmbSecurity.TabIndex = 14;
            this.cmbSecurity.DropDown += new System.EventHandler(this.cmbSecurity_DropDown);
            this.cmbSecurity.TextChanged += new System.EventHandler(this.cmbSecurity_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Вид секретности";
            // 
            // cmbStatus
            // 
            this.cmbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(479, 101);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(185, 21);
            this.cmbStatus.TabIndex = 11;
            this.cmbStatus.DropDown += new System.EventHandler(this.cmbStatus_DropDown);
            this.cmbStatus.TextChanged += new System.EventHandler(this.cmbStatus_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(406, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Статус";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Обозначение документа";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Наименование документа";
            // 
            // tbDocumentName
            // 
            this.tbDocumentName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDocumentName.Location = new System.Drawing.Point(154, 69);
            this.tbDocumentName.Name = "tbDocumentName";
            this.tbDocumentName.Size = new System.Drawing.Size(584, 20);
            this.tbDocumentName.TabIndex = 7;
            this.tbDocumentName.TextChanged += new System.EventHandler(this.tbDocumentName_TextChanged);
            // 
            // tbDocumentOboznachenine
            // 
            this.tbDocumentOboznachenine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDocumentOboznachenine.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbDocumentOboznachenine.Location = new System.Drawing.Point(154, 43);
            this.tbDocumentOboznachenine.Name = "tbDocumentOboznachenine";
            this.tbDocumentOboznachenine.Size = new System.Drawing.Size(584, 20);
            this.tbDocumentOboznachenine.TabIndex = 5;
            this.tbDocumentOboznachenine.TextChanged += new System.EventHandler(this.tbDocumentOboznachenie_TextChanged);
            // 
            // dtpEnterDate
            // 
            this.dtpEnterDate.Checked = false;
            this.dtpEnterDate.Location = new System.Drawing.Point(154, 98);
            this.dtpEnterDate.Name = "dtpEnterDate";
            this.dtpEnterDate.ShowCheckBox = true;
            this.dtpEnterDate.Size = new System.Drawing.Size(246, 20);
            this.dtpEnterDate.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Дата введения";
            // 
            // gbReceiveInformation
            // 
            this.gbReceiveInformation.Controls.Add(this.tbGettingCount);
            this.gbReceiveInformation.Controls.Add(this.label14);
            this.gbReceiveInformation.Controls.Add(this.dtpDateOfReceiving);
            this.gbReceiveInformation.Controls.Add(this.label13);
            this.gbReceiveInformation.Controls.Add(this.dtpDateOfReg);
            this.gbReceiveInformation.Controls.Add(this.cmbAdressOfReceiver);
            this.gbReceiveInformation.Controls.Add(this.label10);
            this.gbReceiveInformation.Controls.Add(this.label11);
            this.gbReceiveInformation.Controls.Add(this.tbGettingNumber);
            this.gbReceiveInformation.Controls.Add(this.label12);
            this.gbReceiveInformation.Enabled = false;
            this.gbReceiveInformation.Location = new System.Drawing.Point(401, 222);
            this.gbReceiveInformation.Name = "gbReceiveInformation";
            this.gbReceiveInformation.Size = new System.Drawing.Size(359, 212);
            this.gbReceiveInformation.TabIndex = 2;
            this.gbReceiveInformation.TabStop = false;
            this.gbReceiveInformation.Text = "Информация о получении";
            // 
            // tbGettingCount
            // 
            this.tbGettingCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbGettingCount.BeepOnError = true;
            this.tbGettingCount.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.tbGettingCount.Location = new System.Drawing.Point(101, 109);
            this.tbGettingCount.Mask = "00000";
            this.tbGettingCount.Name = "tbGettingCount";
            this.tbGettingCount.PromptChar = ' ';
            this.tbGettingCount.ResetOnPrompt = false;
            this.tbGettingCount.ResetOnSpace = false;
            this.tbGettingCount.Size = new System.Drawing.Size(250, 21);
            this.tbGettingCount.TabIndex = 3;
            this.tbGettingCount.ValidatingType = typeof(int);
            this.tbGettingCount.TextChanged += new System.EventHandler(this.tbGettingCount_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(19, 111);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(47, 15);
            this.label14.TabIndex = 27;
            this.label14.Text = "Кол-во";
            // 
            // dtpDateOfReceiving
            // 
            this.dtpDateOfReceiving.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDateOfReceiving.Checked = false;
            this.dtpDateOfReceiving.Location = new System.Drawing.Point(101, 82);
            this.dtpDateOfReceiving.Name = "dtpDateOfReceiving";
            this.dtpDateOfReceiving.ShowCheckBox = true;
            this.dtpDateOfReceiving.Size = new System.Drawing.Size(250, 21);
            this.dtpDateOfReceiving.TabIndex = 2;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(19, 75);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(67, 30);
            this.label13.TabIndex = 25;
            this.label13.Text = "Дата \r\nполучения";
            // 
            // dtpDateOfReg
            // 
            this.dtpDateOfReg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDateOfReg.Checked = false;
            this.dtpDateOfReg.Location = new System.Drawing.Point(101, 52);
            this.dtpDateOfReg.Name = "dtpDateOfReg";
            this.dtpDateOfReg.ShowCheckBox = true;
            this.dtpDateOfReg.Size = new System.Drawing.Size(250, 21);
            this.dtpDateOfReg.TabIndex = 1;
            // 
            // cmbAdressOfReceiver
            // 
            this.cmbAdressOfReceiver.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbAdressOfReceiver.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAdressOfReceiver.FormattingEnabled = true;
            this.cmbAdressOfReceiver.Location = new System.Drawing.Point(101, 140);
            this.cmbAdressOfReceiver.Name = "cmbAdressOfReceiver";
            this.cmbAdressOfReceiver.Size = new System.Drawing.Size(250, 23);
            this.cmbAdressOfReceiver.TabIndex = 4;
            this.cmbAdressOfReceiver.DropDown += new System.EventHandler(this.cmbAdressOfReceiver_DropDown);
            this.cmbAdressOfReceiver.TextChanged += new System.EventHandler(this.cmbAdressOfReceiver_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(19, 140);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 15);
            this.label10.TabIndex = 22;
            this.label10.Text = "Адрес";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(19, 56);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(37, 15);
            this.label11.TabIndex = 21;
            this.label11.Text = "Дата";
            // 
            // tbGettingNumber
            // 
            this.tbGettingNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbGettingNumber.Location = new System.Drawing.Point(101, 20);
            this.tbGettingNumber.Name = "tbGettingNumber";
            this.tbGettingNumber.Size = new System.Drawing.Size(250, 21);
            this.tbGettingNumber.TabIndex = 0;
            this.tbGettingNumber.TextChanged += new System.EventHandler(this.tbGettingNumber_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(19, 28);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(46, 15);
            this.label12.TabIndex = 19;
            this.label12.Text = "Номер";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 15);
            this.label7.TabIndex = 6;
            this.label7.Text = "Номер";
            // 
            // tbQueryNumber
            // 
            this.tbQueryNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbQueryNumber.Location = new System.Drawing.Point(88, 21);
            this.tbQueryNumber.Name = "tbQueryNumber";
            this.tbQueryNumber.Size = new System.Drawing.Size(283, 21);
            this.tbQueryNumber.TabIndex = 0;
            this.tbQueryNumber.TextChanged += new System.EventHandler(this.tbQueryNumber_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 57);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 15);
            this.label8.TabIndex = 8;
            this.label8.Text = "Дата";
            // 
            // gbQueryInformation
            // 
            this.gbQueryInformation.Controls.Add(this.dtpQueryDate);
            this.gbQueryInformation.Controls.Add(this.cmbQueryAdress);
            this.gbQueryInformation.Controls.Add(this.label9);
            this.gbQueryInformation.Controls.Add(this.label8);
            this.gbQueryInformation.Controls.Add(this.tbQueryNumber);
            this.gbQueryInformation.Controls.Add(this.label7);
            this.gbQueryInformation.Enabled = false;
            this.gbQueryInformation.Location = new System.Drawing.Point(14, 222);
            this.gbQueryInformation.Name = "gbQueryInformation";
            this.gbQueryInformation.Size = new System.Drawing.Size(381, 130);
            this.gbQueryInformation.TabIndex = 1;
            this.gbQueryInformation.TabStop = false;
            this.gbQueryInformation.Text = "Информация о запросе";
            // 
            // dtpQueryDate
            // 
            this.dtpQueryDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpQueryDate.Checked = false;
            this.dtpQueryDate.Location = new System.Drawing.Point(88, 53);
            this.dtpQueryDate.Name = "dtpQueryDate";
            this.dtpQueryDate.ShowCheckBox = true;
            this.dtpQueryDate.Size = new System.Drawing.Size(283, 21);
            this.dtpQueryDate.TabIndex = 1;
            // 
            // cmbQueryAdress
            // 
            this.cmbQueryAdress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbQueryAdress.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbQueryAdress.FormattingEnabled = true;
            this.cmbQueryAdress.Location = new System.Drawing.Point(88, 82);
            this.cmbQueryAdress.Name = "cmbQueryAdress";
            this.cmbQueryAdress.Size = new System.Drawing.Size(283, 23);
            this.cmbQueryAdress.TabIndex = 2;
            this.cmbQueryAdress.DropDown += new System.EventHandler(this.cmbQueryAdress_DropDown);
            this.cmbQueryAdress.TextChanged += new System.EventHandler(this.cmbQueryAdress_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 82);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 15);
            this.label9.TabIndex = 9;
            this.label9.Text = "Адрес";
            // 
            // groupBoxActOfInception
            // 
            this.groupBoxActOfInception.Controls.Add(this.dtpActOfInceptionDate);
            this.groupBoxActOfInception.Controls.Add(this.label16);
            this.groupBoxActOfInception.Controls.Add(this.tbActOfInceptionNumber);
            this.groupBoxActOfInception.Controls.Add(this.label17);
            this.groupBoxActOfInception.Location = new System.Drawing.Point(14, 621);
            this.groupBoxActOfInception.Name = "groupBoxActOfInception";
            this.groupBoxActOfInception.Size = new System.Drawing.Size(381, 85);
            this.groupBoxActOfInception.TabIndex = 5;
            this.groupBoxActOfInception.TabStop = false;
            this.groupBoxActOfInception.Text = "Акт о внедрении документа на предприятии";
            // 
            // dtpActOfInceptionDate
            // 
            this.dtpActOfInceptionDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpActOfInceptionDate.Checked = false;
            this.dtpActOfInceptionDate.Location = new System.Drawing.Point(88, 53);
            this.dtpActOfInceptionDate.Name = "dtpActOfInceptionDate";
            this.dtpActOfInceptionDate.ShowCheckBox = true;
            this.dtpActOfInceptionDate.Size = new System.Drawing.Size(283, 21);
            this.dtpActOfInceptionDate.TabIndex = 1;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 57);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(37, 15);
            this.label16.TabIndex = 8;
            this.label16.Text = "Дата";
            // 
            // tbActOfInceptionNumber
            // 
            this.tbActOfInceptionNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbActOfInceptionNumber.Location = new System.Drawing.Point(88, 21);
            this.tbActOfInceptionNumber.Name = "tbActOfInceptionNumber";
            this.tbActOfInceptionNumber.Size = new System.Drawing.Size(283, 21);
            this.tbActOfInceptionNumber.TabIndex = 0;
            this.tbActOfInceptionNumber.TextChanged += new System.EventHandler(this.tbActOfInceptionNumber_TextChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 29);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(46, 15);
            this.label17.TabIndex = 6;
            this.label17.Text = "Номер";
            // 
            // gbActOfChecking
            // 
            this.gbActOfChecking.Controls.Add(this.dtpActOfChecking);
            this.gbActOfChecking.Controls.Add(this.label15);
            this.gbActOfChecking.Controls.Add(this.tbActOfCheckingNumber);
            this.gbActOfChecking.Controls.Add(this.label18);
            this.gbActOfChecking.Location = new System.Drawing.Point(401, 621);
            this.gbActOfChecking.Name = "gbActOfChecking";
            this.gbActOfChecking.Size = new System.Drawing.Size(359, 85);
            this.gbActOfChecking.TabIndex = 6;
            this.gbActOfChecking.TabStop = false;
            this.gbActOfChecking.Text = "Акт о провеке соблюдения документа";
            // 
            // dtpActOfChecking
            // 
            this.dtpActOfChecking.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpActOfChecking.Checked = false;
            this.dtpActOfChecking.Location = new System.Drawing.Point(88, 53);
            this.dtpActOfChecking.Name = "dtpActOfChecking";
            this.dtpActOfChecking.ShowCheckBox = true;
            this.dtpActOfChecking.Size = new System.Drawing.Size(265, 21);
            this.dtpActOfChecking.TabIndex = 1;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 57);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(37, 15);
            this.label15.TabIndex = 8;
            this.label15.Text = "Дата";
            // 
            // tbActOfCheckingNumber
            // 
            this.tbActOfCheckingNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbActOfCheckingNumber.Location = new System.Drawing.Point(88, 21);
            this.tbActOfCheckingNumber.Name = "tbActOfCheckingNumber";
            this.tbActOfCheckingNumber.Size = new System.Drawing.Size(265, 21);
            this.tbActOfCheckingNumber.TabIndex = 0;
            this.tbActOfCheckingNumber.TextChanged += new System.EventHandler(this.tbActOfCheckingNumber_TextChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(6, 29);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(46, 15);
            this.label18.TabIndex = 6;
            this.label18.Text = "Номер";
            // 
            // groupBoxCheckingDate
            // 
            this.groupBoxCheckingDate.Controls.Add(this.label20);
            this.groupBoxCheckingDate.Controls.Add(this.dtpDateOfCheck);
            this.groupBoxCheckingDate.Controls.Add(this.label19);
            this.groupBoxCheckingDate.Location = new System.Drawing.Point(14, 712);
            this.groupBoxCheckingDate.Name = "groupBoxCheckingDate";
            this.groupBoxCheckingDate.Size = new System.Drawing.Size(381, 58);
            this.groupBoxCheckingDate.TabIndex = 7;
            this.groupBoxCheckingDate.TabStop = false;
            this.groupBoxCheckingDate.Text = "Дата проверки на документе";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(6, 25);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(37, 15);
            this.label20.TabIndex = 21;
            this.label20.Text = "Дата";
            // 
            // dtpDateOfCheck
            // 
            this.dtpDateOfCheck.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDateOfCheck.Checked = false;
            this.dtpDateOfCheck.Location = new System.Drawing.Point(88, 20);
            this.dtpDateOfCheck.Name = "dtpDateOfCheck";
            this.dtpDateOfCheck.ShowCheckBox = true;
            this.dtpDateOfCheck.Size = new System.Drawing.Size(283, 21);
            this.dtpDateOfCheck.TabIndex = 0;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(-57, 43);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(37, 15);
            this.label19.TabIndex = 19;
            this.label19.Text = "Дата";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(1055, 754);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAction
            // 
            this.btnAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAction.Location = new System.Drawing.Point(974, 754);
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(75, 23);
            this.btnAction.TabIndex = 11;
            this.btnAction.Text = "Ок";
            this.btnAction.UseVisualStyleBackColor = true;
            // 
            // tbVzamen
            // 
            this.tbVzamen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbVzamen.Location = new System.Drawing.Point(74, 18);
            this.tbVzamen.Name = "tbVzamen";
            this.tbVzamen.ReadOnly = true;
            this.tbVzamen.Size = new System.Drawing.Size(186, 21);
            this.tbVzamen.TabIndex = 0;
            // 
            // tbZamenen
            // 
            this.tbZamenen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbZamenen.Location = new System.Drawing.Point(73, 45);
            this.tbZamenen.Name = "tbZamenen";
            this.tbZamenen.ReadOnly = true;
            this.tbZamenen.Size = new System.Drawing.Size(187, 21);
            this.tbZamenen.TabIndex = 3;
            // 
            // btnSelectVzamen
            // 
            this.btnSelectVzamen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectVzamen.Location = new System.Drawing.Point(266, 16);
            this.btnSelectVzamen.Name = "btnSelectVzamen";
            this.btnSelectVzamen.Size = new System.Drawing.Size(72, 22);
            this.btnSelectVzamen.TabIndex = 1;
            this.btnSelectVzamen.Text = "Выбрать";
            this.btnSelectVzamen.UseVisualStyleBackColor = true;
            this.btnSelectVzamen.Click += new System.EventHandler(this.btnSelectVzamen_Click);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(6, 25);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(145, 15);
            this.label23.TabIndex = 13;
            this.label23.Text = "Поручение о внедрении";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(188, 25);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(46, 15);
            this.label24.TabIndex = 14;
            this.label24.Text = "Номер";
            // 
            // groupBoxInceptionInformation
            // 
            this.groupBoxInceptionInformation.Controls.Add(this.btnClearTbDepartment);
            this.groupBoxInceptionInformation.Controls.Add(this.dtpEnteringOnPlantDate);
            this.groupBoxInceptionInformation.Controls.Add(this.label30);
            this.groupBoxInceptionInformation.Controls.Add(this.dtpOtmFinishDate);
            this.groupBoxInceptionInformation.Controls.Add(this.label29);
            this.groupBoxInceptionInformation.Controls.Add(this.dtpDateOfOrder);
            this.groupBoxInceptionInformation.Controls.Add(this.label28);
            this.groupBoxInceptionInformation.Controls.Add(this.tbOrderNumber);
            this.groupBoxInceptionInformation.Controls.Add(this.label27);
            this.groupBoxInceptionInformation.Controls.Add(this.btnInceptionResponseDepartment);
            this.groupBoxInceptionInformation.Controls.Add(this.tbResponseInceptionDepartment);
            this.groupBoxInceptionInformation.Controls.Add(this.label26);
            this.groupBoxInceptionInformation.Controls.Add(this.dtpInceptionDate);
            this.groupBoxInceptionInformation.Controls.Add(this.label25);
            this.groupBoxInceptionInformation.Controls.Add(this.tbPoruchenieNumber);
            this.groupBoxInceptionInformation.Controls.Add(this.label24);
            this.groupBoxInceptionInformation.Controls.Add(this.label23);
            this.groupBoxInceptionInformation.Location = new System.Drawing.Point(14, 440);
            this.groupBoxInceptionInformation.Name = "groupBoxInceptionInformation";
            this.groupBoxInceptionInformation.Size = new System.Drawing.Size(746, 175);
            this.groupBoxInceptionInformation.TabIndex = 4;
            this.groupBoxInceptionInformation.TabStop = false;
            this.groupBoxInceptionInformation.Text = "Иформация о введении в действие документа на предприятии";
            // 
            // btnClearTbDepartment
            // 
            this.btnClearTbDepartment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearTbDepartment.Location = new System.Drawing.Point(711, 52);
            this.btnClearTbDepartment.Name = "btnClearTbDepartment";
            this.btnClearTbDepartment.Size = new System.Drawing.Size(27, 21);
            this.btnClearTbDepartment.TabIndex = 4;
            this.btnClearTbDepartment.Text = "X";
            this.btnClearTbDepartment.UseVisualStyleBackColor = true;
            this.btnClearTbDepartment.Click += new System.EventHandler(this.btnClearTbDepartment_Click);
            // 
            // dtpEnteringOnPlantDate
            // 
            this.dtpEnteringOnPlantDate.Checked = false;
            this.dtpEnteringOnPlantDate.Location = new System.Drawing.Point(272, 139);
            this.dtpEnteringOnPlantDate.Name = "dtpEnteringOnPlantDate";
            this.dtpEnteringOnPlantDate.ShowCheckBox = true;
            this.dtpEnteringOnPlantDate.Size = new System.Drawing.Size(233, 21);
            this.dtpEnteringOnPlantDate.TabIndex = 8;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(6, 144);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(193, 15);
            this.label30.TabIndex = 29;
            this.label30.Text = "Дата введения на предприятии";
            // 
            // dtpOtmFinishDate
            // 
            this.dtpOtmFinishDate.Checked = false;
            this.dtpOtmFinishDate.Location = new System.Drawing.Point(272, 110);
            this.dtpOtmFinishDate.Name = "dtpOtmFinishDate";
            this.dtpOtmFinishDate.ShowCheckBox = true;
            this.dtpOtmFinishDate.Size = new System.Drawing.Size(233, 21);
            this.dtpOtmFinishDate.TabIndex = 7;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(6, 115);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(260, 15);
            this.label29.TabIndex = 27;
            this.label29.Text = "Дата завершения ОТМ ( при наличии ОТМ )";
            // 
            // dtpDateOfOrder
            // 
            this.dtpDateOfOrder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDateOfOrder.Checked = false;
            this.dtpDateOfOrder.Location = new System.Drawing.Point(533, 83);
            this.dtpDateOfOrder.Name = "dtpDateOfOrder";
            this.dtpDateOfOrder.ShowCheckBox = true;
            this.dtpDateOfOrder.Size = new System.Drawing.Size(205, 21);
            this.dtpDateOfOrder.TabIndex = 6;
            // 
            // label28
            // 
            this.label28.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(440, 86);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(87, 15);
            this.label28.TabIndex = 25;
            this.label28.Text = "Дата приказа";
            // 
            // tbOrderNumber
            // 
            this.tbOrderNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbOrderNumber.Location = new System.Drawing.Point(198, 85);
            this.tbOrderNumber.Name = "tbOrderNumber";
            this.tbOrderNumber.Size = new System.Drawing.Size(228, 21);
            this.tbOrderNumber.TabIndex = 5;
            this.tbOrderNumber.TextChanged += new System.EventHandler(this.tbOrderNumber_TextChanged);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(8, 86);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(184, 15);
            this.label27.TabIndex = 23;
            this.label27.Text = "Номер приказа/распоряжения";
            // 
            // btnInceptionResponseDepartment
            // 
            this.btnInceptionResponseDepartment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInceptionResponseDepartment.Location = new System.Drawing.Point(631, 52);
            this.btnInceptionResponseDepartment.Name = "btnInceptionResponseDepartment";
            this.btnInceptionResponseDepartment.Size = new System.Drawing.Size(74, 21);
            this.btnInceptionResponseDepartment.TabIndex = 3;
            this.btnInceptionResponseDepartment.Text = "Изменить";
            this.btnInceptionResponseDepartment.UseVisualStyleBackColor = true;
            this.btnInceptionResponseDepartment.Click += new System.EventHandler(this.btnSelectInceptionResponseDepartment_Click);
            // 
            // tbResponseInceptionDepartment
            // 
            this.tbResponseInceptionDepartment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbResponseInceptionDepartment.Location = new System.Drawing.Point(280, 52);
            this.tbResponseInceptionDepartment.Name = "tbResponseInceptionDepartment";
            this.tbResponseInceptionDepartment.ReadOnly = true;
            this.tbResponseInceptionDepartment.Size = new System.Drawing.Size(345, 21);
            this.tbResponseInceptionDepartment.TabIndex = 2;
            this.tbResponseInceptionDepartment.TextChanged += new System.EventHandler(this.tbResponseInceptionDepartment_TextChanged);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(8, 55);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(267, 15);
            this.label26.TabIndex = 20;
            this.label26.Text = "Подразделение ответственое за внедрение";
            // 
            // dtpInceptionDate
            // 
            this.dtpInceptionDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpInceptionDate.Checked = false;
            this.dtpInceptionDate.Location = new System.Drawing.Point(533, 22);
            this.dtpInceptionDate.Name = "dtpInceptionDate";
            this.dtpInceptionDate.ShowCheckBox = true;
            this.dtpInceptionDate.Size = new System.Drawing.Size(205, 21);
            this.dtpInceptionDate.TabIndex = 1;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(440, 25);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(37, 15);
            this.label25.TabIndex = 16;
            this.label25.Text = "Дата";
            // 
            // tbPoruchenieNumber
            // 
            this.tbPoruchenieNumber.Location = new System.Drawing.Point(240, 22);
            this.tbPoruchenieNumber.Name = "tbPoruchenieNumber";
            this.tbPoruchenieNumber.Size = new System.Drawing.Size(194, 21);
            this.tbPoruchenieNumber.TabIndex = 0;
            this.tbPoruchenieNumber.TextChanged += new System.EventHandler(this.tbPoruchenieNumber_TextChanged);
            // 
            // btnSelectZamenen
            // 
            this.btnSelectZamenen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectZamenen.Location = new System.Drawing.Point(266, 44);
            this.btnSelectZamenen.Name = "btnSelectZamenen";
            this.btnSelectZamenen.Size = new System.Drawing.Size(72, 22);
            this.btnSelectZamenen.TabIndex = 4;
            this.btnSelectZamenen.Text = "Выбрать";
            this.btnSelectZamenen.UseVisualStyleBackColor = true;
            this.btnSelectZamenen.Click += new System.EventHandler(this.btnSelectZamenen_Click);
            // 
            // btnClearTbZamenen
            // 
            this.btnClearTbZamenen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearTbZamenen.Location = new System.Drawing.Point(344, 44);
            this.btnClearTbZamenen.Name = "btnClearTbZamenen";
            this.btnClearTbZamenen.Size = new System.Drawing.Size(27, 21);
            this.btnClearTbZamenen.TabIndex = 5;
            this.btnClearTbZamenen.Text = "X";
            this.btnClearTbZamenen.UseVisualStyleBackColor = true;
            this.btnClearTbZamenen.Click += new System.EventHandler(this.btnClearTbZamenen_Click);
            // 
            // btnClearTbVzamen
            // 
            this.btnClearTbVzamen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearTbVzamen.Location = new System.Drawing.Point(344, 17);
            this.btnClearTbVzamen.Name = "btnClearTbVzamen";
            this.btnClearTbVzamen.Size = new System.Drawing.Size(27, 21);
            this.btnClearTbVzamen.TabIndex = 2;
            this.btnClearTbVzamen.Text = "X";
            this.btnClearTbVzamen.UseVisualStyleBackColor = true;
            this.btnClearTbVzamen.Click += new System.EventHandler(this.btnClearTbVzamen_Click);
            // 
            // gbChangeing
            // 
            this.gbChangeing.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbChangeing.Controls.Add(this.btnEditChanging);
            this.gbChangeing.Controls.Add(this.btnAddChanging);
            this.gbChangeing.Controls.Add(this.btnDeleteChanging);
            this.gbChangeing.Controls.Add(this.dgvChanging);
            this.gbChangeing.Location = new System.Drawing.Point(766, 24);
            this.gbChangeing.Name = "gbChangeing";
            this.gbChangeing.Size = new System.Drawing.Size(364, 331);
            this.gbChangeing.TabIndex = 9;
            this.gbChangeing.TabStop = false;
            this.gbChangeing.Text = "Изменения (поправки)";
            // 
            // btnEditChanging
            // 
            this.btnEditChanging.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditChanging.Location = new System.Drawing.Point(204, 273);
            this.btnEditChanging.Name = "btnEditChanging";
            this.btnEditChanging.Size = new System.Drawing.Size(154, 23);
            this.btnEditChanging.TabIndex = 8;
            this.btnEditChanging.Text = "Редактировать";
            this.btnEditChanging.UseVisualStyleBackColor = true;
            this.btnEditChanging.Click += new System.EventHandler(this.btnEditChanging_Click);
            // 
            // btnAddChanging
            // 
            this.btnAddChanging.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddChanging.Location = new System.Drawing.Point(202, 302);
            this.btnAddChanging.Name = "btnAddChanging";
            this.btnAddChanging.Size = new System.Drawing.Size(75, 23);
            this.btnAddChanging.TabIndex = 1;
            this.btnAddChanging.Text = "Добавить";
            this.btnAddChanging.UseVisualStyleBackColor = true;
            this.btnAddChanging.Click += new System.EventHandler(this.btnAddChanging_Click);
            // 
            // btnDeleteChanging
            // 
            this.btnDeleteChanging.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteChanging.Location = new System.Drawing.Point(283, 302);
            this.btnDeleteChanging.Name = "btnDeleteChanging";
            this.btnDeleteChanging.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteChanging.TabIndex = 2;
            this.btnDeleteChanging.Text = "Удалить";
            this.btnDeleteChanging.UseVisualStyleBackColor = true;
            this.btnDeleteChanging.Click += new System.EventHandler(this.btnDeleteChanging_Click);
            // 
            // dgvChanging
            // 
            this.dgvChanging.AllowUserToAddRows = false;
            this.dgvChanging.AllowUserToDeleteRows = false;
            this.dgvChanging.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvChanging.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChanging.Location = new System.Drawing.Point(6, 22);
            this.dgvChanging.MultiSelect = false;
            this.dgvChanging.Name = "dgvChanging";
            this.dgvChanging.ReadOnly = true;
            this.dgvChanging.RowHeadersVisible = false;
            this.dgvChanging.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChanging.Size = new System.Drawing.Size(352, 245);
            this.dgvChanging.TabIndex = 0;
            this.dgvChanging.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChanging_CellDoubleClick);
            this.dgvChanging.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvChanging_ColumnHeaderMouseClick);
            this.dgvChanging.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvChanging_KeyDown);
            // 
            // gbDocToDepartment
            // 
            this.gbDocToDepartment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDocToDepartment.Controls.Add(this.btnEditDepartment);
            this.gbDocToDepartment.Controls.Add(this.btnSelectDepartmentForDoc);
            this.gbDocToDepartment.Controls.Add(this.tbSelectedDepartmentForDoc);
            this.gbDocToDepartment.Controls.Add(this.rbSelectDepartmentForDoc);
            this.gbDocToDepartment.Controls.Add(this.rbAllDepartmentForDoc);
            this.gbDocToDepartment.Controls.Add(this.lblReturnCopyCount);
            this.gbDocToDepartment.Controls.Add(this.lblTotalCopyCount);
            this.gbDocToDepartment.Controls.Add(this.btnDeleteDepartment);
            this.gbDocToDepartment.Controls.Add(this.btnAddDepartment);
            this.gbDocToDepartment.Controls.Add(this.dgvDepartment);
            this.gbDocToDepartment.Location = new System.Drawing.Point(766, 361);
            this.gbDocToDepartment.Name = "gbDocToDepartment";
            this.gbDocToDepartment.Size = new System.Drawing.Size(364, 387);
            this.gbDocToDepartment.TabIndex = 10;
            this.gbDocToDepartment.TabStop = false;
            this.gbDocToDepartment.Text = "Документ выдан в подразделение:";
            // 
            // btnEditDepartment
            // 
            this.btnEditDepartment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditDepartment.Location = new System.Drawing.Point(204, 329);
            this.btnEditDepartment.Name = "btnEditDepartment";
            this.btnEditDepartment.Size = new System.Drawing.Size(154, 23);
            this.btnEditDepartment.TabIndex = 9;
            this.btnEditDepartment.Text = "Редактировать";
            this.btnEditDepartment.UseVisualStyleBackColor = true;
            this.btnEditDepartment.Click += new System.EventHandler(this.btnEditDepartment_Click);
            // 
            // btnSelectDepartmentForDoc
            // 
            this.btnSelectDepartmentForDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectDepartmentForDoc.Enabled = false;
            this.btnSelectDepartmentForDoc.Location = new System.Drawing.Point(285, 43);
            this.btnSelectDepartmentForDoc.Name = "btnSelectDepartmentForDoc";
            this.btnSelectDepartmentForDoc.Size = new System.Drawing.Size(74, 21);
            this.btnSelectDepartmentForDoc.TabIndex = 4;
            this.btnSelectDepartmentForDoc.Text = "Изменить";
            this.btnSelectDepartmentForDoc.UseVisualStyleBackColor = true;
            this.btnSelectDepartmentForDoc.Click += new System.EventHandler(this.btnSelectDepartmentForDoc_Click);
            // 
            // tbSelectedDepartmentForDoc
            // 
            this.tbSelectedDepartmentForDoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSelectedDepartmentForDoc.Location = new System.Drawing.Point(138, 43);
            this.tbSelectedDepartmentForDoc.Name = "tbSelectedDepartmentForDoc";
            this.tbSelectedDepartmentForDoc.ReadOnly = true;
            this.tbSelectedDepartmentForDoc.Size = new System.Drawing.Size(141, 21);
            this.tbSelectedDepartmentForDoc.TabIndex = 3;
            // 
            // rbSelectDepartmentForDoc
            // 
            this.rbSelectDepartmentForDoc.AutoSize = true;
            this.rbSelectDepartmentForDoc.Location = new System.Drawing.Point(6, 45);
            this.rbSelectDepartmentForDoc.Name = "rbSelectDepartmentForDoc";
            this.rbSelectDepartmentForDoc.Size = new System.Drawing.Size(126, 19);
            this.rbSelectDepartmentForDoc.TabIndex = 2;
            this.rbSelectDepartmentForDoc.Text = "В подразделение";
            this.rbSelectDepartmentForDoc.UseVisualStyleBackColor = true;
            this.rbSelectDepartmentForDoc.CheckedChanged += new System.EventHandler(this.rbSelectDepartmentForDoc_CheckedChanged);
            // 
            // rbAllDepartmentForDoc
            // 
            this.rbAllDepartmentForDoc.AutoSize = true;
            this.rbAllDepartmentForDoc.Checked = true;
            this.rbAllDepartmentForDoc.Location = new System.Drawing.Point(6, 20);
            this.rbAllDepartmentForDoc.Name = "rbAllDepartmentForDoc";
            this.rbAllDepartmentForDoc.Size = new System.Drawing.Size(156, 19);
            this.rbAllDepartmentForDoc.TabIndex = 1;
            this.rbAllDepartmentForDoc.TabStop = true;
            this.rbAllDepartmentForDoc.Text = "Во все подразделения";
            this.rbAllDepartmentForDoc.UseVisualStyleBackColor = true;
            this.rbAllDepartmentForDoc.CheckedChanged += new System.EventHandler(this.rbAllDepartmentForDoc_CheckedChanged);
            // 
            // lblReturnCopyCount
            // 
            this.lblReturnCopyCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblReturnCopyCount.AutoSize = true;
            this.lblReturnCopyCount.Location = new System.Drawing.Point(12, 362);
            this.lblReturnCopyCount.Name = "lblReturnCopyCount";
            this.lblReturnCopyCount.Size = new System.Drawing.Size(171, 15);
            this.lblReturnCopyCount.TabIndex = 5;
            this.lblReturnCopyCount.Text = "Количество сданных копий: ";
            // 
            // lblTotalCopyCount
            // 
            this.lblTotalCopyCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalCopyCount.AutoSize = true;
            this.lblTotalCopyCount.Location = new System.Drawing.Point(12, 333);
            this.lblTotalCopyCount.Name = "lblTotalCopyCount";
            this.lblTotalCopyCount.Size = new System.Drawing.Size(161, 15);
            this.lblTotalCopyCount.TabIndex = 4;
            this.lblTotalCopyCount.Text = "Количество экземпляров: ";
            // 
            // btnDeleteDepartment
            // 
            this.btnDeleteDepartment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteDepartment.Location = new System.Drawing.Point(285, 358);
            this.btnDeleteDepartment.Name = "btnDeleteDepartment";
            this.btnDeleteDepartment.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteDepartment.TabIndex = 6;
            this.btnDeleteDepartment.Text = "Удалить";
            this.btnDeleteDepartment.UseVisualStyleBackColor = true;
            this.btnDeleteDepartment.Click += new System.EventHandler(this.btnDeleteDepartment_Click);
            // 
            // btnAddDepartment
            // 
            this.btnAddDepartment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddDepartment.Location = new System.Drawing.Point(204, 358);
            this.btnAddDepartment.Name = "btnAddDepartment";
            this.btnAddDepartment.Size = new System.Drawing.Size(75, 23);
            this.btnAddDepartment.TabIndex = 5;
            this.btnAddDepartment.Text = "Добавить";
            this.btnAddDepartment.UseVisualStyleBackColor = true;
            this.btnAddDepartment.Click += new System.EventHandler(this.btnAddDepartment_Click);
            // 
            // dgvDepartment
            // 
            this.dgvDepartment.AllowUserToAddRows = false;
            this.dgvDepartment.AllowUserToDeleteRows = false;
            this.dgvDepartment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDepartment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDepartment.Location = new System.Drawing.Point(6, 75);
            this.dgvDepartment.MultiSelect = false;
            this.dgvDepartment.Name = "dgvDepartment";
            this.dgvDepartment.ReadOnly = true;
            this.dgvDepartment.RowHeadersVisible = false;
            this.dgvDepartment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDepartment.Size = new System.Drawing.Size(352, 248);
            this.dgvDepartment.TabIndex = 0;
            this.dgvDepartment.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDepartment_CellDoubleClick);
            this.dgvDepartment.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDepartment_ColumnHeaderMouseClick);
            this.dgvDepartment.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvDepartment_KeyDown);
            // 
            // gbVzamenZamenen
            // 
            this.gbVzamenZamenen.Controls.Add(this.lblVzamen);
            this.gbVzamenZamenen.Controls.Add(this.btnClearTbZamenen);
            this.gbVzamenZamenen.Controls.Add(this.btnClearTbVzamen);
            this.gbVzamenZamenen.Controls.Add(this.btnSelectZamenen);
            this.gbVzamenZamenen.Controls.Add(this.tbZamenen);
            this.gbVzamenZamenen.Controls.Add(this.tbVzamen);
            this.gbVzamenZamenen.Controls.Add(this.lblZamenen);
            this.gbVzamenZamenen.Controls.Add(this.btnSelectVzamen);
            this.gbVzamenZamenen.Location = new System.Drawing.Point(14, 358);
            this.gbVzamenZamenen.Name = "gbVzamenZamenen";
            this.gbVzamenZamenen.Size = new System.Drawing.Size(381, 76);
            this.gbVzamenZamenen.TabIndex = 3;
            this.gbVzamenZamenen.TabStop = false;
            this.gbVzamenZamenen.Text = "Замены";
            // 
            // lblVzamen
            // 
            this.lblVzamen.AutoSize = true;
            this.lblVzamen.Location = new System.Drawing.Point(8, 20);
            this.lblVzamen.Name = "lblVzamen";
            this.lblVzamen.Size = new System.Drawing.Size(51, 15);
            this.lblVzamen.TabIndex = 31;
            this.lblVzamen.Text = "Взамен";
            // 
            // lblZamenen
            // 
            this.lblZamenen.AutoSize = true;
            this.lblZamenen.Location = new System.Drawing.Point(8, 48);
            this.lblZamenen.Name = "lblZamenen";
            this.lblZamenen.Size = new System.Drawing.Size(59, 15);
            this.lblZamenen.TabIndex = 32;
            this.lblZamenen.Text = "Заменен";
            // 
            // gbEndDate
            // 
            this.gbEndDate.Controls.Add(this.label21);
            this.gbEndDate.Controls.Add(this.dtpEndDate);
            this.gbEndDate.Controls.Add(this.label22);
            this.gbEndDate.Location = new System.Drawing.Point(401, 712);
            this.gbEndDate.Name = "gbEndDate";
            this.gbEndDate.Size = new System.Drawing.Size(359, 58);
            this.gbEndDate.TabIndex = 8;
            this.gbEndDate.TabStop = false;
            this.gbEndDate.Text = "Дата окончания действия документа";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(6, 25);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(37, 15);
            this.label21.TabIndex = 21;
            this.label21.Text = "Дата";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpEndDate.Checked = false;
            this.dtpEndDate.Location = new System.Drawing.Point(88, 20);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.ShowCheckBox = true;
            this.dtpEndDate.Size = new System.Drawing.Size(261, 21);
            this.dtpEndDate.TabIndex = 0;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(-57, 43);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(37, 15);
            this.label22.TabIndex = 19;
            this.label22.Text = "Дата";
            // 
            // DocForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 782);
            this.Controls.Add(this.gbEndDate);
            this.Controls.Add(this.gbVzamenZamenen);
            this.Controls.Add(this.gbDocToDepartment);
            this.Controls.Add(this.gbChangeing);
            this.Controls.Add(this.groupBoxInceptionInformation);
            this.Controls.Add(this.btnAction);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBoxCheckingDate);
            this.Controls.Add(this.gbActOfChecking);
            this.Controls.Add(this.groupBoxActOfInception);
            this.Controls.Add(this.gbReceiveInformation);
            this.Controls.Add(this.gbQueryInformation);
            this.Controls.Add(this.gbDocument);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DocForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Карточка документа";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DocForm_FormClosing);
            this.gbDocument.ResumeLayout(false);
            this.gbDocument.PerformLayout();
            this.gbReceiveInformation.ResumeLayout(false);
            this.gbReceiveInformation.PerformLayout();
            this.gbQueryInformation.ResumeLayout(false);
            this.gbQueryInformation.PerformLayout();
            this.groupBoxActOfInception.ResumeLayout(false);
            this.groupBoxActOfInception.PerformLayout();
            this.gbActOfChecking.ResumeLayout(false);
            this.gbActOfChecking.PerformLayout();
            this.groupBoxCheckingDate.ResumeLayout(false);
            this.groupBoxCheckingDate.PerformLayout();
            this.groupBoxInceptionInformation.ResumeLayout(false);
            this.groupBoxInceptionInformation.PerformLayout();
            this.gbChangeing.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChanging)).EndInit();
            this.gbDocToDepartment.ResumeLayout(false);
            this.gbDocToDepartment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartment)).EndInit();
            this.gbVzamenZamenen.ResumeLayout(false);
            this.gbVzamenZamenen.PerformLayout();
            this.gbEndDate.ResumeLayout(false);
            this.gbEndDate.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.RadioButton rbOuterDocument;
        protected System.Windows.Forms.RadioButton rbInnerDocument;
        private System.Windows.Forms.GroupBox gbDocument;
        private System.Windows.Forms.Label label1;
        protected System.Windows.Forms.TextBox tbDocumentOboznachenine;
        private System.Windows.Forms.Label label2;
        protected System.Windows.Forms.TextBox tbDocumentName;
        protected System.Windows.Forms.DateTimePicker dtpEnterDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        protected System.Windows.Forms.ComboBox cmbSecurity;
        private System.Windows.Forms.Label label5;
        protected System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox gbReceiveInformation;
        private System.Windows.Forms.Label label14;
        protected System.Windows.Forms.DateTimePicker dtpDateOfReceiving;
        private System.Windows.Forms.Label label13;
        protected System.Windows.Forms.DateTimePicker dtpDateOfReg;
        protected System.Windows.Forms.ComboBox cmbAdressOfReceiver;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        protected System.Windows.Forms.TextBox tbGettingNumber;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label7;
        protected System.Windows.Forms.TextBox tbQueryNumber;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox gbQueryInformation;
        protected System.Windows.Forms.DateTimePicker dtpQueryDate;
        protected System.Windows.Forms.ComboBox cmbQueryAdress;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBoxActOfInception;
        protected System.Windows.Forms.DateTimePicker dtpActOfInceptionDate;
        private System.Windows.Forms.Label label16;
        protected System.Windows.Forms.TextBox tbActOfInceptionNumber;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.GroupBox gbActOfChecking;
        protected System.Windows.Forms.DateTimePicker dtpActOfChecking;
        private System.Windows.Forms.Label label15;
        protected System.Windows.Forms.TextBox tbActOfCheckingNumber;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox groupBoxCheckingDate;
        private System.Windows.Forms.Label label20;
        protected System.Windows.Forms.DateTimePicker dtpDateOfCheck;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button btnCancel;
        protected System.Windows.Forms.Button btnAction;
        private System.Windows.Forms.Button btnSelectStatus;
        private System.Windows.Forms.Button btnSelectDeveloper;
        private System.Windows.Forms.Button btnSelectSecretType;
        protected System.Windows.Forms.TextBox tbVzamen;
        protected System.Windows.Forms.TextBox tbZamenen;
        private System.Windows.Forms.Button btnSelectVzamen;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.GroupBox groupBoxInceptionInformation;
        protected System.Windows.Forms.DateTimePicker dtpEnteringOnPlantDate;
        private System.Windows.Forms.Label label30;
        protected System.Windows.Forms.DateTimePicker dtpOtmFinishDate;
        private System.Windows.Forms.Label label29;
        protected System.Windows.Forms.DateTimePicker dtpDateOfOrder;
        private System.Windows.Forms.Label label28;
        protected System.Windows.Forms.TextBox tbOrderNumber;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Button btnInceptionResponseDepartment;
        protected System.Windows.Forms.TextBox tbResponseInceptionDepartment;
        private System.Windows.Forms.Label label26;
        protected System.Windows.Forms.DateTimePicker dtpInceptionDate;
        private System.Windows.Forms.Label label25;
        protected System.Windows.Forms.TextBox tbPoruchenieNumber;
        public System.Windows.Forms.ComboBox cmbDeveloper;
        private System.Windows.Forms.Button btnSelectZamenen;
        private System.Windows.Forms.Button btnClearTbZamenen;
        private System.Windows.Forms.Button btnClearTbVzamen;
        protected System.Windows.Forms.GroupBox gbChangeing;
        protected System.Windows.Forms.DataGridView dgvChanging;
        private System.Windows.Forms.Button btnAddChanging;
        protected System.Windows.Forms.Button btnDeleteChanging;
        protected System.Windows.Forms.GroupBox gbDocToDepartment;
        protected System.Windows.Forms.Button btnDeleteDepartment;
        private System.Windows.Forms.Button btnAddDepartment;
        protected System.Windows.Forms.CheckBox chbControlCopy;
        private System.Windows.Forms.GroupBox gbVzamenZamenen;
        private System.Windows.Forms.Label lblVzamen;
        private System.Windows.Forms.Label lblZamenen;
        private System.Windows.Forms.Label lblReturnCopyCount;
        private System.Windows.Forms.Label lblTotalCopyCount;
        private System.Windows.Forms.RadioButton rbAllDepartmentForDoc;
        protected System.Windows.Forms.Button btnSelectDepartmentForDoc;
        protected System.Windows.Forms.TextBox tbSelectedDepartmentForDoc;
        protected System.Windows.Forms.RadioButton rbSelectDepartmentForDoc;
        protected System.Windows.Forms.DataGridView dgvDepartment;
        protected System.Windows.Forms.MaskedTextBox tbGettingCount;
        private System.Windows.Forms.Button btnClearTbDepartment;
        protected System.Windows.Forms.Button btnEditChanging;
        protected System.Windows.Forms.Button btnEditDepartment;
        protected System.Windows.Forms.CheckBox chbOriginal;
        private System.Windows.Forms.GroupBox gbEndDate;
        private System.Windows.Forms.Label label21;
        protected System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label label22;
    }
}