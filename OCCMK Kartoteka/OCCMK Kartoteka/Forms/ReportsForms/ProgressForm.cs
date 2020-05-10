using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace OCCMK_Kartoteka
{
    public partial class ProgressForm : Form
    {
        private AExporter exporter;
        private string fileName;
        bool exportResultOK = false;
        
        public ProgressForm(AExporter exporter, string fileName)
        {
            this.exporter = exporter;
            this.fileName = fileName;

            InitializeComponent();
        }

        private void ProgressForm_Shown(object sender, EventArgs e)
        {
            backgroundWorker.RunWorkerAsync();
        }

        private void ProgressForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            backgroundWorker.CancelAsync();
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                exportResultOK = exporter.export(fileName, this.backgroundWorker);
            }
            catch (COMException ex)
            {
                MessageBox.Show("Данный документ уже используется");
                ex.ToString();
            }
            catch (CancelException ex)
            {
                FileLogger.log(LogLevel.Info, "Экспорт прерван пользователем. " + ex.ToString());
                e.Cancel = true;
            }
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("Экспорт прерван пользователем");
                this.Close();
                return;
            }
            DialogResult dr = MessageBox.Show("Экспорт завершен");
            if (exportResultOK)
            {
                exporter.showApp();
            }

            this.Close();
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            backgroundWorker.CancelAsync();
        }
    }
}
