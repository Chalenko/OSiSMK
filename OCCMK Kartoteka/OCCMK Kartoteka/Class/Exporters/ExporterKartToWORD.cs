using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Word = Microsoft.Office.Interop.Word;
using System.Data;
using System.Runtime.InteropServices;

namespace OCCMK_Kartoteka
{
    class ExporterKartToWORD : AExporter
    {
        private Word._Application wordApp;
        private Word._Document wordDocument;

        private Dictionary<string, string> paramList;
        int currentLine;
        int currentGlobalItem = 0;

        private DataView srcDgvChanging;
        private DataView srcDgvDepartment;

        public ExporterKartToWORD(Dictionary<string, string> paramList, DataView srcDgvChanging, DataView srcDgvDepartment)
        {
            currentLine = 0;
            this.paramList = paramList;
            this.srcDgvChanging = srcDgvChanging;
            this.srcDgvDepartment = srcDgvDepartment;

            int depCount = Convert.ToInt32((from Rows in srcDgvDepartment.Table.AsEnumerable()
                                 select Rows["Имя подразделения"]).Distinct().ToList().Count);

            totalRowCount = 43 + 4 * srcDgvChanging.Count + 4 * depCount + 5 * srcDgvDepartment.Count;
        }

        public override bool export(string fileName, System.ComponentModel.BackgroundWorker backgroundWorker)
        {
            bool error = false;
            setEnvironment(fileName, backgroundWorker);
            int tab = 0;

            try
            {
                printDocument(fileName, tab);
            }
            catch (COMException ex)
            {
                actionsAfterExportError(ex);
                error = true;
                throw ex;
            }
            catch (CancelException ex)
            {
                closeApp();
                System.IO.File.Delete(fileName);
                error = true;
                throw ex;
            }
            catch (Exception ex)
            {
                actionsAfterExportError(ex);
                System.IO.File.Delete(fileName);
                error = true;
            }
            return !error;
        }

        # region вспомогательные функции

        public override bool activeWorkBookIsNull()
        {
            return false;
        }

        public override void showApp()
        {
            wordApp.Visible = true;
            wordApp.Activate();
        }

        protected override void closeApp()
        {
            wordApp.DisplayAlerts = Word.WdAlertLevel.wdAlertsNone;
            wordDocument.Close();
            wordDocument = null;
        }

        private void openWordAndPreparePrint()
        {
            wordApp = new Word.Application();
            wordApp.Visible = false;
            wordApp.DisplayAlerts = Word.WdAlertLevel.wdAlertsAll;

            Object template = Type.Missing;
            Object newTemplate = false;
            Object documentType = Word.WdNewDocumentType.wdNewBlankDocument;
            Object visible = true;

            wordDocument = wordApp.Documents.Add(ref template, ref newTemplate, ref documentType, ref visible);
            wordDocument.SaveAs(fileName);
        }

        private void printDocument(string fileName, int tab)
        {
            openWordAndPreparePrint();

            printTitle(tab);
            printDocumentInfo(tab);
            printQuerytInfo(tab);
            printReceiveInfo(tab);
            printItem(string.Format("{0}. Разработчик: ", ++currentGlobalItem), tab);                           printData(paramList["Разработчик"]);
            printVzamenInfo(tab);
            printZamenenInfo(tab);
            printEnteringInfo(tab);
            printItem(string.Format("{0}. Акт о внедрении документа на предприятии, номер/дата: ", ++currentGlobalItem), tab);
            {
                wordApp.Selection.Font.Bold = 0;
                write(paramList["Акт внедрение номер"]); write(" от "); writeLine(paramList["Акт внедрение дата"]);
            }
            printCheckInfo(tab);
            printItem(string.Format("{0}. Дата проверки на документе: ", ++currentGlobalItem), tab);            printData(paramList["Проверка дата"]);
            printChanges(tab);
            printCopies(tab);

            wordDocument.SaveAs(fileName);
        }

        #region вывод частей документа

        private void printTitle(int tab)
        {
            // Добавить формат
            wordApp.Selection.Font.Name = "Times New Roman";
            wordApp.Selection.Font.Bold = 1;
            wordApp.Selection.Font.Size = 16;
            wordApp.Selection.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            wordApp.Selection.ParagraphFormat.LineSpacingRule = Word.WdLineSpacing.wdLineSpaceSingle;
            wordApp.Selection.ParagraphFormat.SpaceAfter = 10;
            wordApp.Selection.ParagraphFormat.SpaceBefore = 0;
            writeLine("Карточка учета документа по стандартизации", tab);
            wordApp.Selection.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
        }

        private void printDocumentInfo(int tab)
        {
            printItem(string.Format("{0}. Документ (внешний/внутренний): ", ++currentGlobalItem), tab);         printData(paramList["Тип"]);
            printItem(string.Format("{0}. Обозначение документа: ", ++currentGlobalItem), tab);                 printData(paramList["Обозначение"]);
            printItem(string.Format("{0}. Наименование документа: ", ++currentGlobalItem), tab);                printData(paramList["Наименование"]);
            printItem(string.Format("{0}. Подлинник: ", ++currentGlobalItem), tab);                             printData(paramList["Оригинал"].Equals("True") ? "Да" : "Нет");
            printItem(string.Format("{0}. Наличие контрольной копии: ", ++currentGlobalItem), tab);             printData(paramList["Контрольная копия"].Equals("True") ? "Да" : "Нет");
            printItem(string.Format("{0}. Дата введения: ", ++currentGlobalItem), tab);                         printData(paramList["Дата введения"]);
            printItem(string.Format("{0}. Дата окончания действия: ", ++currentGlobalItem), tab);               printData(paramList["Дата окончания"]);
            printItem(string.Format("{0}. Статус: ", ++currentGlobalItem), tab);                                printData(paramList["Статус"]);
            printItem(string.Format("{0}. Вид секретности: ", ++currentGlobalItem), tab);                       printData(paramList["Секретность"]);
        }

        private void printQuerytInfo(int tab)
        {
            printItem(string.Format("{0}. Информация о запросе: ", ++currentGlobalItem), tab);                  printData("");
            printItem(string.Format("{0}.1. исх.№ ", currentGlobalItem), tab + 1);                              printData(paramList["Запрос номер"]);
            printItem(string.Format("{0}.2. дата: ", currentGlobalItem), tab);                                  printData(paramList["Запрос дата"]);
            printItem(string.Format("{0}.3. адрес: ", currentGlobalItem), tab);                                 printData(paramList["Запрос адрес"]);

            wordApp.Selection.ParagraphFormat.TabIndent(-1);
        }

        private void printReceiveInfo(int tab)
        {
            printItem(string.Format("{0}. Информация о получении: ", ++currentGlobalItem), tab);                printData("");
            printItem(string.Format("{0}.1. входящий регистрационный номер: ", currentGlobalItem), tab + 1);    printData(paramList["Получение номер"]);
            printItem(string.Format("{0}.2. дата: ", currentGlobalItem), tab);                                  printData(paramList["Получение дата регистрации"]);
            printItem(string.Format("{0}.3. дата получения: ", currentGlobalItem), tab);                        printData(paramList["Получение дата"]);
            printItem(string.Format("{0}.4. количество: ", currentGlobalItem), tab);                            printData(paramList["Получение количество"]);
            printItem(string.Format("{0}.5. откуда получен: ", currentGlobalItem), tab);                        printData(paramList["Получение адрес"]);

            wordApp.Selection.ParagraphFormat.TabIndent(-1);
        }

        private void printVzamenInfo(int tab)
        {
            printItem(string.Format("{0}. Взамен: ", ++currentGlobalItem), tab);                                printData("");
            printItem(string.Format("{0}.1. обозначение документа: ", currentGlobalItem), tab + 1);             printData(paramList["Взамен обозначение"]);
            printItem(string.Format("{0}.2. наименование документа: ", currentGlobalItem), tab);                printData(paramList["Взамен наименование"]);

            wordApp.Selection.ParagraphFormat.TabIndent(-1);
        }

        private void printZamenenInfo(int tab)
        {
            printItem(string.Format("{0}. Заменен: ", ++currentGlobalItem), tab);                               printData("");
            printItem(string.Format("{0}.1. документ (внешний/внутренний): ", currentGlobalItem), tab + 1);     printData(paramList["Заменен тип"]);
            printItem(string.Format("{0}.2. обозначение: ", currentGlobalItem), tab);                           printData(paramList["Заменен обозначение"]);
            printItem(string.Format("{0}.3. наименование: ", currentGlobalItem), tab);                          printData(paramList["Заменен наименование"]);
            printItem(string.Format("{0}.4. дата введения: ", currentGlobalItem), tab);                         printData(paramList["Заменен дата"]);

            wordApp.Selection.ParagraphFormat.TabIndent(-1);
        }

        private void printEnteringInfo(int tab)
        {
            printItem(string.Format("{0}. Информация о введении в действие документа на предприятии: ", ++currentGlobalItem), tab);         printData("");
            printItem(string.Format("{0}.1. поручение о внедрение, номер/дата: ", currentGlobalItem), tab + 1);
            {
                wordApp.Selection.Font.Bold = 0;
                write(paramList["Внедрение номер"]); write(" от "); writeLine(paramList["Внедрение дата"]);
            }
            printItem(string.Format("{0}.2. подразделение ответственное за внедрение, индекс подразделения/наименование: ", currentGlobalItem), tab);
            {
                wordApp.Selection.Font.Bold = 0;
                write(paramList["Внедрение подразделение индекс"]); write("/"); writeLine(paramList["Внедрение подразделение наименование"]);
            }
            printItem(string.Format("{0}.3. номер приказа/распоряжения: ", currentGlobalItem), tab);                                        printData(paramList["Внедрение приказ"]);
            printItem(string.Format("{0}.4. дата приказа/распоряжения: ", currentGlobalItem), tab);                                         printData(paramList["Внедрение дата приказ"]);
            printItem(string.Format("{0}.5. дата завершения ОТМ (при наличии ОТМ): ", currentGlobalItem), tab);                             printData(paramList["Внедрение дата ОТМ"]);
            printItem(string.Format("{0}.6. дата введения на предприятии: ", currentGlobalItem), tab);                                      printData(paramList["Внедрение дата введение"]);

            wordApp.Selection.ParagraphFormat.TabIndent(-1);
        }

        private void printCheckInfo(int tab)
        {
            printItem(string.Format("{0}. Акт о проверке соблюдения документа: ", ++currentGlobalItem), tab);                               printData("");
            printItem(string.Format("{0}.1. номер акта: ", currentGlobalItem), tab + 1);                                                    printData(paramList["Акт проверка номер"]);
            printItem(string.Format("{0}.2. дата: ", currentGlobalItem), tab);                                                              printData(paramList["Акт проверка дата"]);

            wordApp.Selection.ParagraphFormat.TabIndent(-1);
        }

        private void printChanges(int tab)
        {
            printItem(string.Format("{0}. Изменения (поправки): ", ++currentGlobalItem), tab);                                              printData("");
            for (int i = 0; i < srcDgvChanging.Count; i++)
            {
                printChangeContext(tab, i);
            }
        }

        private void printChangeContext(int tab, int i)
        {
            printItem(string.Format("{0}.", currentGlobalItem) + (i + 1).ToString() + " номер изменения/поправки: ", tab + 1);              printData(srcDgvChanging.Table.Rows[i]["Номер"]);
            printItem(string.Format("{0}.", currentGlobalItem) + (i + 1).ToString() + ".1. документ: ", tab + 1);                           printData(srcDgvChanging.Table.Rows[i]["Документ"]);
            printItem(string.Format("{0}.", currentGlobalItem) + (i + 1).ToString() + ".2. дата регистрации: ", tab);                       printData(convertToShortDate(srcDgvChanging.Table, i, "Дата регистрации"));
            printItem(string.Format("{0}.", currentGlobalItem) + (i + 1).ToString() + ".3. дата введения в действие: ", tab);               printData(convertToShortDate(srcDgvChanging.Table, i, "Дата введения"));

            backgroundWorker.ReportProgress(calcPercent(currentLine));
            wordApp.Selection.ParagraphFormat.TabIndent(-2);
        }    

        private void printCopies(int tab)
        {
            printItem(string.Format("{0}. Документ выдан в подразделение: ", ++currentGlobalItem), tab);                                    printData("");
            int depCount = Convert.ToInt32((from Rows in srcDgvDepartment.Table.AsEnumerable()
                                            select Rows["Имя подразделения"]).Distinct().ToList().Count);

            int docId = (depCount != 0 ? Convert.ToInt32(srcDgvDepartment.Table.Rows[0]["Номер документа"]) : 0);
            DataTable statisctics = DatabaseContext.Instance.LoadFromDatabase("SelectPodrDocInfoForPrintCard", new Dictionary<string, object>() { { "docId", docId } });

            replaceNullByZero(statisctics);

            int rec = 0;
            for (int i = 0; i < depCount; i++)
            {
                printDepartmentCopyContext(tab, i, statisctics.Rows[i], ref rec);
            }
        }

        private void printDepartmentCopyContext(int tab, int i, DataRow dataRow, ref int rec)
        {
            printItem(string.Format("{0}." + (i + 1).ToString() + " Индекс подразделения: ", currentGlobalItem), tab + 1);                  printData(srcDgvDepartment.Table.Rows[rec]["Индекс подразделения"]);
            int j = 0;
            for (j = 0; j < Convert.ToInt32(dataRow["Количество копий"]); j++)
            {
                printCopyContent(tab, i, j, ref rec);
            }
            j++;

            printItem(string.Format("{0}." + (i + 1).ToString() + "." + (j++).ToString() + ". кому выдан: ", currentGlobalItem), tab + 1);  printData(srcDgvDepartment.Table.Rows[rec - 1]["Имя подразделения"]);
            printItem(string.Format("{0}." + (i + 1).ToString() + "." + (j++).ToString() + ". количество экземпляров: ", currentGlobalItem), tab); printData(Convert.ToInt32(dataRow["Количество копий"]));
            printItem(string.Format("{0}." + (i + 1).ToString() + "." + (j++).ToString() + ". количество сданных копий: ", currentGlobalItem), tab); printData(Convert.ToInt32(dataRow["Количество копий списано"]));

            backgroundWorker.ReportProgress(calcPercent(currentLine));
            wordApp.Selection.ParagraphFormat.TabIndent(-2);
        }

        private void printCopyContent(int tab, int i, int j, ref int rec)
        {
            printItem(string.Format("{0}." + (i + 1).ToString() + "." + (j + 1).ToString() + " номер экземпляра: ", currentGlobalItem), tab + 1);           printData(srcDgvDepartment.Table.Rows[rec]["Номер экземпляра"]);
            printItem(string.Format("{0}." + (i + 1).ToString() + "." + (j + 1).ToString() + ".1. дата выдачи: ", currentGlobalItem), tab + 1);             printData(convertToShortDate(srcDgvDepartment.Table, rec, "Дата выдачи"));
            printItem(string.Format("{0}." + (i + 1).ToString() + "." + (j + 1).ToString() + ".2. Ф.И.О. получившего: ", currentGlobalItem), tab);          printData(srcDgvDepartment.Table.Rows[rec]["Ф.И.О. получившего"]);
            printItem(string.Format("{0}." + (i + 1).ToString() + "." + (j + 1).ToString() + ".3. текущий статус: ", currentGlobalItem), tab);              printData(srcDgvDepartment.Table.Rows[rec]["Статус"]);
            printItem(string.Format("{0}." + (i + 1).ToString() + "." + (j + 1).ToString() + ".4. дата возврата/списания: ", currentGlobalItem), tab);      printData(convertToShortDate(srcDgvDepartment.Table, rec, "Дата списания"));
            rec++;

            backgroundWorker.ReportProgress(calcPercent(currentLine));
            wordApp.Selection.ParagraphFormat.TabIndent(-2);
        }

        #endregion

        private void replaceNullByZero(DataTable table)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                for (int j = 0; j < table.Columns.Count; j++)
                {
                    if (System.Convert.ToString(table.Rows[i][j]) == "")
                        table.Rows[i][j] = 0;
                }
            }
        }
        
        private string convertToShortDate(DataTable dt, int rowIndex, string columnName)
        {
            return dt.Rows[rowIndex][columnName].ToString() != "" ? Convert.ToDateTime(dt.Rows[rowIndex][columnName]).ToShortDateString() : dt.Rows[rowIndex][columnName].ToString();
        }

        private void printItem(string text, int tab)
        {
            wordApp.Selection.Font.Name = "Times New Roman";
            wordApp.Selection.Font.Bold = 1;
            wordApp.Selection.Font.Size = 11;
            wordApp.Selection.ParagraphFormat.LineSpacingRule = Word.WdLineSpacing.wdLineSpaceSingle;
            wordApp.Selection.ParagraphFormat.SpaceAfter = 0;
            wordApp.Selection.ParagraphFormat.SpaceBefore = 0;
            wordApp.Selection.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphJustify;
            write(text, tab);

            backgroundWorker.ReportProgress(calcPercent(currentLine));
            if (backgroundWorker.CancellationPending == true)
            {
                throw new CancelException("Экспорт прерван пользователем");
            }
        }

        private void printData(object data)
        {
            wordApp.Selection.Font.Name = "Times New Roman";
            wordApp.Selection.Font.Bold = 0;
            wordApp.Selection.Font.Size = 11;
            wordApp.Selection.ParagraphFormat.LineSpacingRule = Word.WdLineSpacing.wdLineSpaceSingle;
            wordApp.Selection.ParagraphFormat.SpaceAfter = 0;
            wordApp.Selection.ParagraphFormat.SpaceBefore = 0;
            writeLine(data.ToString());

            backgroundWorker.ReportProgress(calcPercent(currentLine));
            if (backgroundWorker.CancellationPending == true)
            {
                throw new CancelException("Экспорт прерван пользователем");
            }
        }

        private void writeLine(string text, int tabCount)
        {
            wordApp.Selection.ParagraphFormat.TabIndent((short)tabCount);

            this.writeLine(text);

            wordApp.Selection.ParagraphFormat.TabIndent((short)(-tabCount));
        }

        private void writeLine(string text)
        {
            wordApp.Selection.TypeText(text);
            wordApp.Selection.TypeParagraph();
            currentLine++;
        }

        private void write(string text, int tabCount)
        {
            wordApp.Selection.ParagraphFormat.TabIndent((short)tabCount);

            this.write(text);
        }

        private void write(string text)
        {
            wordApp.Selection.TypeText(text); ;
        }

        #endregion
    }
}
