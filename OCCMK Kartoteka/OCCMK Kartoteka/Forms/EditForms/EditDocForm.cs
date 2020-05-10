using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using OCCMK_Kartoteka.Forms;
using System.Drawing.Printing;

namespace OCCMK_Kartoteka
{
    public partial class EditDocForm : DocForm
    {
        bool isOnEdit = false;

        public EditDocForm(string id) : base()
        {
            this.InitializeComponent();
            
            srcDgvChanging = new BindingSource();
            srcDgvDepartment = new BindingSource();
            
            docId = id;
            
            tableChangingName = "DocChange";
            tableDepartmentName = "PodrDoc";
            
            FillAllCombobox();
            readonlyform(isOnEdit);

            dgvChanging.DataSource = srcDgvChanging;
            dgvDepartment.DataSource = srcDgvDepartment;
        }

        private void EditDocForm_Load(object sender, EventArgs e)
        {
            tsmPrint.Visible = false;
            try
            {
                DataTable dt = dbContext.LoadFromDatabase("outer_kart_view", new Dictionary<string, object> { { "@id", Convert.ToInt32(docId) } }, CommandType.StoredProcedure);
                DataRow dr = dt.Rows[0];

                FillAllFields(dr);

                podrID = Convert.ToInt32(dr["Номер подразделения"]);
                if (dr["vzamen"] == DBNull.Value)
                    VzamID = null;
                else
                    VzamID = Convert.ToInt32(dr["vzamen"]);

                if (dr["zamenen"] == DBNull.Value)
                    ZamID = null;
                else
                    ZamID = Convert.ToInt32(dr["zamenen"]);      
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось загрузить данные о карточке!", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                FileLogger.log(LogLevel.Fatal, "Не удалось загрузить карточку с id = " + docId + " в форму редактирования карточки. " + ex.ToString());
                this.Close();
                return;
            }
            RefreshDGV();
        }

        #region обработка кнопок на форме

        protected override void btnAction_Click(object sender, EventArgs e)
        {
            if (isOnEdit)
            {
                if (MessageBox.Show("Обновить запись?", "Редактировать запись", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (rbOuterDocument.Checked == true)
                        updateOuterDocument();
                    else
                        updateInnerDocument();
                }
            }
            else
            {
                Close();
            }
        }

        protected override void dgvDepartment_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (isOnEdit)
            {
                btnEditDepartment_Click(sender, e);
            }
        }

        protected override void dgvChanging_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (isOnEdit)
            {
                btnEditChanging_Click(sender, e);
            }
        }

        private void tsmEdit_Click(object sender, EventArgs e)
        {
            isOnEdit = true;
            readonlyform(isOnEdit);
            RefreshDGV();
            tbDocumentOboznachenine.Focus();
        }

        private void tsmDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удалить запись?", "Удаление записи", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
                bool vzamen = true;
                bool zamenen = true;
                if (!tbVzamen.Text.Trim().Equals("")) vzamen = MessageBox.Show("Данный документ является заменой другого докумета! \nВсе равно удалить?", "Удаление записи", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes ? true : false;
                if (!tbZamenen.Text.Trim().Equals("")) zamenen = MessageBox.Show("Данный документ был заменен другим документом! \nУдаление данного документа приведет к потере сведений в заменяющем документе. \nВсе равно удалить?", "Удаление записи", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes ? true : false;
                if (vzamen && zamenen)
                {
                    string command = "DeleteCard";
                    try
                    {
                        dbContext.ExecuteCommand(command, new Dictionary<string, object> { { "@docID", docId } }, CommandType.StoredProcedure);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Не удалось удалить карточку", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        FileLogger.log(LogLevel.Error, "Не удалось удалить карточку " + ex.ToString());
                        return;
                    }
                    finally
                    {
                        dbContext._connection.Close();
                    }
                    FileLogger.log(LogLevel.Info, "Карточка с id = " + docId.ToString() + " удалена.");
                    MessageBox.Show("Запись удалена!", "Удаление записи", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void tsmExport_Click(object sender, EventArgs e)
        {
            //sfdExportCard.InitialDirectory = Application.StartupPath.ToString();
            sfdExportCard.Filter = String.Format("Файлы Word(*.doc)|*.doc");
            sfdExportCard.FileName = "Карточка учета документа по стандартизации.doc";
            DialogResult dr = sfdExportCard.ShowDialog();

            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                export(dr);
            }
            if (dr == System.Windows.Forms.DialogResult.Cancel)
                return;
        }

        private void tsmPrint_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region вспомогательные функции

        private void readonlyform(bool can)
        {
            foreach (Control ctrl in this.Controls)
            {
                foreach (Control ctr2 in ctrl.Controls) { ctr2.Enabled = can; }
            }
            dgvChanging.Enabled = true;
            dgvDepartment.Enabled = true;
            if (can)
            {
                dgvDepartment.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDepartment_CellDoubleClick);
                dgvChanging.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChanging_CellDoubleClick);
            }
            else
            {
                dgvDepartment.CellDoubleClick -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDepartment_CellDoubleClick);
                dgvChanging.CellDoubleClick -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChanging_CellDoubleClick);
            }
            btnSelectDepartmentForDoc.Enabled = rbSelectDepartmentForDoc.Checked;
        }

        private void FillAllFields(DataRow reader)
        {
            rbOuterDocument.Checked = (reader["Тип"].ToString() == "Внешний") ? true : false;
            string type = reader["Тип"].ToString();
            if (type == "Внешний")
                FillOuterFields(reader);
            else
                FillInnerFields(reader);
        }

        private void FillInnerFields(DataRow reader)
        {
            chbControlCopy.Checked = Convert.ToInt32(reader["Контрольная копия"]) == 1 ? true : false;
            chbOriginal.Checked = Convert.ToInt32(reader["Оригинал"]) == 1 ? true : false;
            tbDocumentOboznachenine.Text = reader["Обозначение"].ToString();
            tbDocumentName.Text = reader["Наименование документа"].ToString();
            if (reader["Дата введения"].ToString() != "")
            {
                dtpEnterDate.Value = DateTime.Parse(reader["Дата введения"].ToString());
                dtpEnterDate.Checked = true;
            }
            cmbStatus.Text = reader["Статус"].ToString();
            cmbSecurity.Text = reader["Секретность"].ToString();
            cmbDeveloper.Text = reader["Разработчик"].ToString();
            tbVzamen.Text = reader["vzamenobozn"].ToString();
            tbZamenen.Text = reader["zamenenobozn"].ToString();
            tbActOfInceptionNumber.Text = reader["vnednum"].ToString();
            if (reader["vneddat"].ToString() != "")
            {
                dtpActOfInceptionDate.Value = DateTime.Parse(reader["vneddat"].ToString());
                dtpActOfInceptionDate.Checked = true;
            }
            tbActOfCheckingNumber.Text = reader["provnum"].ToString();
            if (reader["provdat"].ToString() != "")
            {
                dtpActOfChecking.Value = DateTime.Parse(reader["provdat"].ToString());
                dtpActOfChecking.Checked = true;
            }
            if (reader["Дата введения"].ToString() != "")
            {
                dtpEnterDate.Value = DateTime.Parse(reader["Дата введения"].ToString());
                dtpEnterDate.Checked = true;
            }
            tbPoruchenieNumber.Text = reader["divnum"].ToString();
            if (reader["ddat"].ToString() != "")
            {
                dtpInceptionDate.Value = DateTime.Parse(reader["ddat"].ToString());
                dtpInceptionDate.Checked = true;
            }
            tbResponseInceptionDepartment.Text = reader["dicod"].ToString();
            tbOrderNumber.Text = reader["diord"].ToString();
            if (reader["ordat"].ToString() != "")
            {
                dtpDateOfOrder.Value = DateTime.Parse(reader["ordat"].ToString());
                dtpDateOfOrder.Checked = true;
            }
            if (reader["otm"].ToString() != "")
            {
                dtpOtmFinishDate.Value = DateTime.Parse(reader["otm"].ToString());
                dtpOtmFinishDate.Checked = true;
            }
            if (reader["vved"].ToString() != "")
            {
                dtpEnteringOnPlantDate.Value = DateTime.Parse(reader["vved"].ToString());
                dtpEnteringOnPlantDate.Checked = true;
            }
            if (reader["Дата окончания"].ToString() != "")
            {
                dtpEndDate.Value = DateTime.Parse(reader["Дата окончания"].ToString());
                dtpEndDate.Checked = true;
            }
            if (reader["Дата проверки"].ToString() != "")
            {
                dtpDateOfCheck.Value = DateTime.Parse(reader["Дата проверки"].ToString());
                dtpDateOfCheck.Checked = true;
            }
        }

        private void FillOuterFields(DataRow reader)
        {
            FillInnerFields(reader);

            tbQueryNumber.Text = reader["zapnum"].ToString();
            if (reader["zapdat"].ToString() != "")
            {
                dtpQueryDate.Value = DateTime.Parse(reader["zapdat"].ToString());
                dtpQueryDate.Checked = true;
            }
            cmbQueryAdress.Text = reader["zapdev"].ToString();

            tbGettingNumber.Text = reader["polnum"].ToString();
            if (reader["polreg"].ToString() != "")
            {
                dtpDateOfReg.Value = DateTime.Parse(reader["polreg"].ToString());
                dtpDateOfReg.Checked = true;
            }
            if (reader["pol"].ToString() != "")
            {
                dtpDateOfReceiving.Value = DateTime.Parse(reader["pol"].ToString());
                dtpDateOfReceiving.Checked = true;
            }
            cmbAdressOfReceiver.Text = reader["poldev"].ToString();
            tbGettingCount.Text = reader["polkol"].ToString();
        }

        private void updateInnerDocument()
        {
            if (isSecuriryCorrect() & isStatusCorrect() & isDeveloperCorrect())
            {
                if (isAllInnerFieldCorrect())
                {
                    Dictionary<string, object> paramsDictionary = new Dictionary<string, object>();
                    paramsDictionary.Add("@docID", docId);
                    createInnerParams(paramsDictionary);
                    updateDocument(paramsDictionary);
                }
                else
                {
                    if (MessageBox.Show("Обновить запись с незаполнеными полями?", "Новая запись", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        Dictionary<string, object> paramsDictionary = new Dictionary<string, object>();
                        paramsDictionary.Add("@docID", docId);
                        createInnerParams(paramsDictionary);
                        updateDocument(paramsDictionary);
                    }
                }
            }
            else
            {
                MessageBox.Show("Не заполненно одно или несколько из обязательных полей!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void updateOuterDocument()
        {
            if (isSecuriryCorrect() & isStatusCorrect() & isDeveloperCorrect() & isQueryAddressCorrect() & isAddressOfReceiverCorrect() & isGettingCountCorrect())
            {
                if (isAllOuterFieldCorrect())
                {
                    Dictionary<string, object> paramsDictionary = new Dictionary<string, object>();
                    paramsDictionary.Add("@docID", docId);
                    createOuterParams(paramsDictionary);
                    updateDocument(paramsDictionary);
                }
                else
                {
                    if (MessageBox.Show("Обновить запись с незаполнеными полями?", "Новая запись", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        Dictionary<string, object> paramsDictionary = new Dictionary<string, object>();
                        paramsDictionary.Add("@docID", docId);
                        createOuterParams(paramsDictionary);
                        updateDocument(paramsDictionary);
                    }
                }
            }
            else
            {
                MessageBox.Show("Не заполненно одно или несколько из обязательных полей!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void updateDocument(Dictionary<string, object> paramsDictionary)
        {
            try
                {
                    dbContext.ExecuteCommand("Kart_Edit", paramsDictionary);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Не удалось изменить карточку!", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    FileLogger.log(LogLevel.Error, "Не удалось изменить карточку с id = " + docId.ToString() + " в таблице Kart. " + ex.ToString());
                    return;
                }
                finally
                {
                    dbContext._connection.Close();
                }
                MessageBox.Show("Запись изменена", "Измененние записи", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FileLogger.log(LogLevel.Info, "Изменена карточка с id = " + docId.ToString() + " в таблице Kart.");
                this.Close();
        }

        protected override void UpdateChanges()
        {
            base.UpdateChanges();

            if (srcDgvChanging.Count != 0 && isOnEdit)
            {
                btnDeleteChanging.Enabled = true;
                btnEditChanging.Enabled = true;
            }
            else
            {
                btnDeleteChanging.Enabled = false;
                btnEditChanging.Enabled = false;
            }
        }

        protected override void UpdateDocToDepartments()
        {
            base.UpdateDocToDepartments();

            if (srcDgvDepartment.Count != 0 && isOnEdit)
            {
                btnDeleteDepartment.Enabled = true;
                btnEditDepartment.Enabled = true;
            }
            else
            {
                btnDeleteDepartment.Enabled = false;
                btnEditDepartment.Enabled = false;
            }
        }

        private void createParamsForExport(Dictionary<string, string> paramsDictionary, SqlDataReader reader)
        {
            paramsDictionary.Add("Тип",                                 reader["Тип"].ToString());
            paramsDictionary.Add("Обозначение",                         reader["Обозначение"].ToString());
            paramsDictionary.Add("Наименование",                        reader["Наименование"].ToString());
            paramsDictionary.Add("Оригинал",                            reader["Оригинал"].ToString());
            paramsDictionary.Add("Контрольная копия",                   reader["Копия"].ToString());
            paramsDictionary.Add("Дата введения",                       reader["Дата введения"].ToString());
            paramsDictionary.Add("Дата окончания",                      reader["Дата окончания"].ToString());
            paramsDictionary.Add("Статус",                              reader["Статус"].ToString());
            paramsDictionary.Add("Секретность",                         reader["Секретность"].ToString());
            paramsDictionary.Add("Разработчик",                         reader["Разработчик"].ToString());

            paramsDictionary.Add("Запрос номер",                        reader["Запрос номер"].ToString());
            paramsDictionary.Add("Запрос дата",                         reader["Запрос дата"].ToString());
            paramsDictionary.Add("Запрос адрес",                        reader["Запрос адрес"].ToString());

            paramsDictionary.Add("Получение номер",                     reader["Получение номер"].ToString());
            paramsDictionary.Add("Получение дата регистрации",          reader["Получение дата регистрации"].ToString());
            paramsDictionary.Add("Получение дата",                      reader["Получение дата"].ToString());
            paramsDictionary.Add("Получение количество",                reader["Получение количество"].ToString());
            paramsDictionary.Add("Получение адрес",                     reader["Получение адрес"].ToString());

            paramsDictionary.Add("Взамен обозначение",                  reader["Взамен обозначение"].ToString());
            paramsDictionary.Add("Взамен наименование",                 reader["Взамен наименование"].ToString());

            paramsDictionary.Add("Заменен тип",                         reader["Заменен тип"].ToString());
            paramsDictionary.Add("Заменен обозначение",                 reader["Заменен обозначение"].ToString());
            paramsDictionary.Add("Заменен наименование",                reader["Заменен наименование"].ToString());
            paramsDictionary.Add("Заменен дата",                        reader["Заменен дата"].ToString());

            paramsDictionary.Add("Внедрение номер",                     reader["Внедрение номер"].ToString());
	        paramsDictionary.Add("Внедрение дата",                      reader["Внедрение дата"].ToString());
	        paramsDictionary.Add("Внедрение подразделение индекс",      reader["Внедрение подразделение индекс"].ToString());
	        paramsDictionary.Add("Внедрение подразделение наименование",reader["Внедрение подразделение наименование"].ToString());
	        paramsDictionary.Add("Внедрение приказ",                    reader["Внедрение приказ"].ToString());
	        paramsDictionary.Add("Внедрение дата приказ",               reader["Внедрение дата приказ"].ToString());
	        paramsDictionary.Add("Внедрение дата ОТМ",                  reader["Внедрение дата ОТМ"].ToString());
            paramsDictionary.Add("Внедрение дата введение",             reader["Внедрение дата введение"].ToString());

            paramsDictionary.Add("Акт внедрение номер",                 reader["Акт внедрение номер"].ToString());
            paramsDictionary.Add("Акт внедрение дата",                  reader["Акт внедрение дата"].ToString());
            paramsDictionary.Add("Акт проверка номер",                  reader["Акт проверка номер"].ToString());
            paramsDictionary.Add("Акт проверка дата",                   reader["Акт проверка дата"].ToString());

            paramsDictionary.Add("Проверка дата",                       reader["Проверка дата"].ToString());
        }

        private void export(System.Windows.Forms.DialogResult dr)
        {
            Dictionary<string, string> paramDic = new Dictionary<string, string>();
            using (SqlCommand com = dbContext._connection.CreateCommand())
            {
                try
                {
                    dbContext._connection.Open();
                    com.CommandText = "SelectCardForPrint";
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@docid", Convert.ToInt32(docId));

                    SqlDataReader reader = com.ExecuteReader();
                    reader.Read();

                    createParamsForExport(paramDic, reader);

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Не удалось загрузить данные о карточке!", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    FileLogger.log(LogLevel.Error, "Не удалось загрузить карточку с id = " + docId + " в форму редактирования карточки. " + ex.ToString());
                    return;
                }
                finally
                {
                    dbContext._connection.Close();
                }
            }

            new ProgressForm(new ExporterKartToWORD(paramDic, new DataView((DataTable)srcDgvChanging.DataSource), new DataView((DataTable)srcDgvDepartment.DataSource)), sfdExportCard.FileName).ShowDialog();
        }

        #endregion 
    }
}
