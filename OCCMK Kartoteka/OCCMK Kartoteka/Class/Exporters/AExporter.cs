using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OCCMK_Kartoteka
{
    public abstract class AExporter
    {
        protected string fileName;
        protected int totalRowCount;
        protected System.ComponentModel.BackgroundWorker backgroundWorker;

        public abstract bool export(string fileName, System.ComponentModel.BackgroundWorker backgroundWorker);

        protected virtual void setEnvironment(string fileName, System.ComponentModel.BackgroundWorker backgroundWorker)
        {
            this.fileName = fileName;
            this.backgroundWorker = backgroundWorker;
        }

        public virtual void showApp()
        {
            new NotImplementedException();
        }

        protected virtual void closeApp()
        {
            new NotImplementedException();
        }

        public virtual bool activeWorkBookIsNull()
        {
            throw new NotImplementedException();
        }
        
        protected int calcPercent(int rowPrinted)
        {
            float f = (float)rowPrinted * 100 / totalRowCount;
            return (int)f;
        }

        protected void actionsAfterExportError(Exception ex)
        {
            FileLogger.log(LogLevel.Warn, "Ошибка при экспорте. Нет доступа к файлу. " + ex.ToString());
            closeApp();
        }
    }

    class CancelException : Exception
    {
        public CancelException(string p)
            : base(p)
        {
        }
    }
}
