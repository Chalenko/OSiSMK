using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OCCMK_Kartoteka
{
    internal enum LogLevel
    {
        Debug, Info, Warn, Error, Fatal
    }

    static class FileLogger
    {
        private static string fileName = "./log.txt";

        static void setFileName(string fileName)
        {
            FileLogger.fileName = fileName;
        }

        public static void log(LogLevel lvl, string text)
        {
            fileName = Application.StartupPath.ToString() + "\\log.txt";
            System.IO.FileInfo fi = new System.IO.FileInfo(fileName);
            if (fi.Length > 5000000)
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(fileName, false))
                {
                    try
                    {
                        file.Write("");
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.ToString());
                    }
                    finally
                    {
                        file.Close();
                    }
                }
            }

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(fileName, true))
            {
                try
                {
                    file.WriteLine(DateTime.Now.ToString() + ". " + lvl.ToString() + ": " + text);
                    file.WriteLine("");
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
                finally
                {
                    file.Close();
                }
            }
        }
    }
}
