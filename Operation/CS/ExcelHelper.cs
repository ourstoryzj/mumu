using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Operation.CS
{
    public class ExcelHelper
    {



        #region 之前的代码

       

        #region ReadExcel
        /// <summary>
        /// 读取Excel[.xls](返回DataTable)
        /// 实例
        /// string FileUrl = this.openFileDialog1.FileName;
        /// DataTable dt = ReadExcel(FileUrl);
        /// dataGridView1.AutoGenerateColumns = true;
        /// dataGridView1.DataSource = dt;
        /// </summary>
        /// <param name="path">Excel路径</param>
        /// <returns></returns>
        public static DataTable ReadExcel(string path)
        {
            try
            {
                DataTable dt = new DataTable();
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    IWorkbook workbook = new HSSFWorkbook(fs);
                    ISheet sheet = workbook.GetSheetAt(0);
                    int rfirst = sheet.FirstRowNum;
                    int rlast = sheet.LastRowNum;
                    IRow row = sheet.GetRow(rfirst);
                    int cfirst = row.FirstCellNum;
                    int clast = row.LastCellNum;
                    for (int i = cfirst; i < clast; i++)
                    {
                        if (row.GetCell(i) != null)
                            dt.Columns.Add(row.GetCell(i).StringCellValue, System.Type.GetType("System.String"));
                    }
                    row = null;
                    for (int i = rfirst + 1; i <= rlast; i++)
                    {
                        DataRow r = dt.NewRow();
                        IRow ir = sheet.GetRow(i);
                        for (int j = cfirst; j < clast; j++)
                        {
                            if (ir.GetCell(j) != null)
                            {
                                r[j] = ir.GetCell(j).ToString();
                            }
                        }
                        dt.Rows.Add(r);
                        ir = null;
                        r = null;
                        fs.Close();
                    }
                    sheet = null;
                    workbook = null;
                }
                return dt;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Excel格式错误或者Excel正由另一进程在访问");
                Debug.WriteLine(ex);
                return null;
            }
        }
        #endregion

        









        #region 读取Excel文件到DataTable

        /// <summary>
        /// 读取指定excel表中的内容返回datatable
        /// </summary>
        /// <param name="fileName">文件地址</param>
        /// <returns>表中内容</returns>
        public DataTable ExcelUp(string fileName)
        {
            string filePath = fileName;//读取excel文件路径；

            DataTable dt = GetDataTable("Sheet1", filePath);

            return dt;

        }


        /// <summary>
        /// 读取excel指定页中的内容
        /// </summary>
        /// <param name="strSheetName">页名</param>
        /// <param name="strExcelFileName">excel路径</param>
        /// <returns></returns>
        protected DataTable GetDataTable(string strSheetName, string strExcelFileName)
        {
            //源的定义
            string strConn = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source={0};" + "Extended Properties='Excel 8.0;HDR=NO;IMEX=1';", strExcelFileName);

            //Sql语句
            string strExcel = string.Format("select * from [{0}$]", strSheetName);

            //定义存放的数据表
            DataSet ds = new DataSet();

            //连接数据源
            OleDbConnection conn = new OleDbConnection(strConn);

            try
            {
                conn.Open();
                //适配到数据源
                OleDbDataAdapter adapter = new OleDbDataAdapter(strExcel, strConn);
                adapter.Fill(ds, strSheetName);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conn.Close();
            }
            return ds.Tables[strSheetName];
        }

        public static DataSet LoadDataFromExcel(string filePath)
        {
            try
            {
                string strConn;
                strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties='Excel 8.0;HDR=False;IMEX=1'";
                OleDbConnection OleConn = new OleDbConnection(strConn);
                OleConn.Open();
                String sql = "SELECT * FROM  [Sheet1$]";//可是更改Sheet名称，比如sheet2，等等   

                OleDbDataAdapter OleDaExcel = new OleDbDataAdapter(sql, OleConn);
                DataSet OleDsExcle = new DataSet();
                OleDaExcel.Fill(OleDsExcle, "Sheet1");
                OleConn.Close();
                return OleDsExcle;
            }
            catch (Exception err)
            {
                MessageBox.Show("数据绑定Excel失败!失败原因：" + err.Message, "提示信息",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
        }


        //DataTabe中的数据以Excel的形式输出！
        public void TableToExcel(string excel, DataTable tb, string tbname)
        {
            try
            {
                OleDbConnection connex = null;// = GetConnFromExcel(excel); //获取到excel文件的oledb连接
                string ct = "CREATE TABLE " + tbname + " (";                //以下生成一个sql命令向excel中插入一个表
                foreach (DataColumn clmn in tb.Columns)
                {
                    switch (clmn.DataType.Name)                                     //根据不同数据类型分别处理
                    {
                        case "Decimal":
                            ct += clmn.ColumnName + " Decimal,";
                            break;
                        case "Double":
                            ct += clmn.ColumnName + " Double,";
                            break;
                        default:
                            ct += clmn.ColumnName + " string,";
                            break;
                    }
                }
                ct = ct.Substring(0, ct.Length - 1) + ")";
                OleDbCommand cmd1 = new OleDbCommand(ct, connex);
                cmd1.ExecuteNonQuery();                                                              //向excel中插入一个表


                foreach (DataRow r in tb.Rows)                                                       //下面向excel中一行一行写入数据
                {
                    string fs = "", vs = "";
                    foreach (DataColumn clmn in tb.Columns)
                    {
                        fs += clmn.ColumnName + ",";
                        if (r[clmn.ColumnName] == DBNull.Value)
                        {
                            vs += "null,";
                            continue;
                        }
                        switch (clmn.DataType.Name)                                                   //根据不同数据类型分别处理
                        {
                            case "Decimal":
                                vs += ((decimal)r[clmn.ColumnName]).ToString("0.00") + ",";
                                break;
                            case "Double":
                                vs += ((double)r[clmn.ColumnName]).ToString("0.00") + ",";
                                break;
                            case "DateTime":
                                vs += " + ((DateTime)r[clmn.ColumnName]).ToShortDateString() + ,";
                                break;
                            default:
                                vs += " + r[clmn.ColumnName].ToString() + ,";
                                break;
                        }
                    }
                    string sqlstr = "insert into [" + tbname + "$] (" + fs.Substring(0, fs.Length - 1) + ") values (" + vs.Substring(0, vs.Length - 1) + ")";
                    OleDbCommand cmd = new OleDbCommand(sqlstr, connex);
                    cmd.ExecuteNonQuery();                                            //向excel中插入数据
                }
                connex.Close();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        #endregion

        #region GetDgvToTable
        /// <summary>
        /// 方法实现把dgv里的数据完整的复制到一张内存表
        /// </summary>
        /// <param name="dgv">dgv控件作为参数</param>
        /// <returns>返回临时内存表</returns>
        public static DataTable GetDgvToTable(DataGridView dgv)
        {
            DataTable dt = new DataTable();
            //try
            //{
            //    for (int count = 0; count < dgv.Columns.Count; count++)
            //    {
            //        DataColumn dc = new DataColumn(dgv.Columns[count].Name.ToString());
            //        dt.Columns.Add(dc);
            //    }
            //    for (int count = 0; count < dgv.Rows.Count; count++)
            //    {
            //        try
            //        {
            //            DataRow dr = dt.NewRow();
            //            for (int countsub = 0; countsub < dgv.Columns.Count; countsub++)
            //            {
            //                dr[countsub] = dgv.Rows[count].Cells[countsub].Value.ToString();
            //            }
            //            dt.Rows.Add(dr);
            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show(ex.Message);
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //return dt;
            try
            {
                foreach (DataGridViewTextBoxColumn dcc in dgv.Columns)
                {
                    DataColumn dc = new DataColumn(dcc.Name.ToString());
                    dt.Columns.Add(dc);
                }
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    DataRow dr = dt.NewRow();
                    int i = 0;
                    foreach (DataGridViewTextBoxCell cell in row.Cells)
                    {
                        dr[i] = cell.Value;
                        i++;
                    }
                    if (!string.IsNullOrEmpty(dr[0].ToString()))
                        dt.Rows.Add(dr);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dt;
        }
        #endregion


        #region RenderDataTableToExcel
        /// <summary>
        /// 到处到Excel
        /// </summary>
        /// <param name="tmpDataTable"></param>
        /// <param name="strFileName"></param>
        private static void RenderDataTableToExcel(DataTable SourceTable)
        {
            HSSFWorkbook wk = new HSSFWorkbook();
            ISheet tb = wk.CreateSheet("mySheet");
            int i = 1;
            //设置表头
            IRow headerRow = tb.CreateRow(0);
            // handling header.
            headerRow.CreateCell(0).SetCellValue("序号");
            headerRow.CreateCell(1).SetCellValue("关键词");
            headerRow.CreateCell(2).SetCellValue("搜索人气");
            headerRow.CreateCell(3).SetCellValue("搜索指数");
            headerRow.CreateCell(4).SetCellValue("占比");
            headerRow.CreateCell(5).SetCellValue("点击指数");
            headerRow.CreateCell(6).SetCellValue("商城点击占比");
            headerRow.CreateCell(7).SetCellValue("点击率");
            headerRow.CreateCell(8).SetCellValue("当前宝贝数");
            headerRow.CreateCell(9).SetCellValue("转化率");
            headerRow.CreateCell(10).SetCellValue("直通车");
            headerRow.CreateCell(11).SetCellValue("转化率");
            headerRow.CreateCell(12).SetCellValue("转化率");

            foreach (DataRow r in SourceTable.Rows)
            {
                IRow row = tb.CreateRow(i); //添加一行
                int j = 0;
                foreach (object o in r.ItemArray)
                {
                    ICell cell = row.CreateCell(j);  //在第二行中创建单元格
                    cell.SetCellValue(o.ToString());//循环往第二行的单元格中添加数据
                    j++;
                }
                i++;
            }

            using (FileStream fs = File.OpenWrite(@"c:/myxls.xls")) //打开一个xls文件，如果没有则自行创建，如果存在myxls.xls文件则在创建是不要打开该文件！
            {
                wk.Write(fs);   //向打开的这个xls文件中写入mySheet表并保存。
                MessageBox.Show("OK!");
            }
        }

        #endregion


        #region DataGridViewToExcel
        /// <summary>
        /// DataGridView导出到Excel
        /// </summary>
        /// <param name="tmpDataTable"></param>
        /// <param name="strFileName"></param>
        public static void DataGridViewToExcel(DataGridView dgv,string fileurl)
        {
            HSSFWorkbook wk = new HSSFWorkbook();
            ISheet tb = wk.CreateSheet("mySheet");
            int i = 1;
            //设置表头
            IRow headerRow = tb.CreateRow(0);
            // handling header.
            for (int j = 0; j < dgv.ColumnCount; j++)
            {
                string name = dgv.Columns[j].HeaderText;
                headerRow.CreateCell(j).SetCellValue(name);
            }
            DataTable SourceTable = GetDgvToTable(dgv);

            foreach (DataRow r in SourceTable.Rows)
            {
                IRow row = tb.CreateRow(i); //添加一行
                int j = 0;
                foreach (object o in r.ItemArray)
                {
                    ICell cell = row.CreateCell(j);  //在第二行中创建单元格
                    cell.SetCellValue(o.ToString());//循环往第二行的单元格中添加数据
                    j++;
                }
                i++;
            }
            if (string.IsNullOrEmpty(fileurl))
            {
                fileurl = @"c:/myxls.xls";
            }
            using (FileStream fs = File.OpenWrite(fileurl)) //打开一个xls文件，如果没有则自行创建，如果存在myxls.xls文件则在创建是不要打开该文件！
            {
                wk.Write(fs);   //向打开的这个xls文件中写入mySheet表并保存。
                MessageBox.Show("成功导出到Excel!");
            }
        }

        #endregion





        /////////////////////////////////////////////////////////////////////////////////////////





        //public static void test()
        //{
        //    Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
        //    string myPath = @"Myfile\data.xlsx";
        //    excelApp.Workbooks.Open(myPath);
        //    excelApp.Workbooks.SaveAs("Myfile\data.csv", Microsoft.Office.Interop.Excel.XlFileFormat.xlCSV);
        //}


        /// <summary>
        /// 将Csv文件转换为XLS文件
        /// </summary>
        /// <param name="FilePath">文件全路路径</param>
        /// <returns>返回转换后的Xls文件名</returns>
        public static string CSVSaveasXLS(string FilePath)
        {
            QuertExcel();
            string _NewFilePath = "";

            Excel.Application excelApplication;
            Excel.Workbooks excelWorkBooks = null;
            Excel.Workbook excelWorkBook = null;
            Excel.Worksheet excelWorkSheet = null;

            try
            {
                excelApplication = new Excel.ApplicationClass();
                excelWorkBooks = excelApplication.Workbooks;
                excelWorkBook = ((Excel.Workbook)excelWorkBooks.Open(FilePath, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value));
                excelWorkSheet = (Excel.Worksheet)excelWorkBook.Worksheets[1];
                excelApplication.Visible = false;
                excelApplication.DisplayAlerts = false;
                _NewFilePath = FilePath.Replace(".csv", ".xls");
                excelWorkBook.SaveAs(_NewFilePath, Excel.XlFileFormat.xlAddIn8, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Excel.XlSaveAsAccessMode.xlNoChange, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                QuertExcel();
                // ExcelFormatHelper.DeleteFile(FilePath);
                //可以不用杀掉进程QuertExcel();

                //excelApplication.Quit();

                GC.WaitForPendingFinalizers();
                GC.Collect();



            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }

            finally
            {
                GC.Collect();
            }

            return _NewFilePath;
        }

        /// <summary>
        /// 将Csv文件转换为XLS文件
        /// </summary>
        /// <param name="FilePath">文件全路路径</param>
        /// <returns>返回转换后的Xls文件名</returns>
        public static void CSVSaveasXLS(string FilePath, string SaveFilePath)
        {
            QuertExcel();
            //string _NewFilePath = "";

            Excel.Application excelApplication;
            Excel.Workbooks excelWorkBooks = null;
            Excel.Workbook excelWorkBook = null;
            Excel.Worksheet excelWorkSheet = null;

            try
            {
                excelApplication = new Excel.ApplicationClass();
                excelWorkBooks = excelApplication.Workbooks;
                excelWorkBook = ((Excel.Workbook)excelWorkBooks.Open(FilePath, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value));
                excelWorkSheet = (Excel.Worksheet)excelWorkBook.Worksheets[1];
                excelApplication.Visible = false;
                excelApplication.DisplayAlerts = false;
                //_NewFilePath = FilePath.Replace(".csv", ".xls");
                excelWorkBook.SaveAs(SaveFilePath, Excel.XlFileFormat.xlAddIn8, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Excel.XlSaveAsAccessMode.xlNoChange, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                QuertExcel();
                // ExcelFormatHelper.DeleteFile(FilePath);
                //可以不用杀掉进程QuertExcel();

                //excelApplication.Quit();

                GC.WaitForPendingFinalizers();
                GC.Collect();



            }
            catch (Exception exc)
            {
                //throw new Exception(exc.Message);
                MessageBox.Show(exc.Message);
            }

            finally
            {
                GC.Collect();
            }

            //return _NewFilePath;
        }

        /// <summary>
        /// 将xls文件转换为csv文件
        /// </summary>
        /// <param name="FilePath">文件全路路径</param>
        /// <returns>返回转换后的csv文件名</returns>
        public static string XLSSavesaCSV(string FilePath)
        {
            QuertExcel();
            string _NewFilePath = "";

            Excel.Application excelApplication;
            Excel.Workbooks excelWorkBooks = null;
            Excel.Workbook excelWorkBook = null;
            Excel.Worksheet excelWorkSheet = null;

            try
            {
                excelApplication = new Excel.ApplicationClass();
                excelWorkBooks = excelApplication.Workbooks;
                excelWorkBook = ((Excel.Workbook)excelWorkBooks.Open(FilePath, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value));
                excelWorkSheet = (Excel.Worksheet)excelWorkBook.Worksheets[1];
                excelApplication.Visible = false;
                excelApplication.DisplayAlerts = false;
                _NewFilePath = FilePath.Replace(".xls", ".csv");
                // excelWorkSheet._SaveAs(FilePath, Excel.XlFileFormat.xlCSVWindows, Missing.Value, Missing.Value, Missing.Value,Missing.Value,Missing.Value, Missing.Value, Missing.Value);
                excelWorkBook.SaveAs(_NewFilePath, Excel.XlFileFormat.xlCSV, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                QuertExcel();
                //ExcelFormatHelper.DeleteFile(FilePath);
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
            return _NewFilePath;
        }

        /// <summary>
        /// 删除一个指定的文件
        /// </summary>
        /// <param name="FilePath">文件路径</param>
        /// <returns></returns>
        public static bool DeleteFile(string FilePath)
        {
            try
            {
                bool IsFind = File.Exists(FilePath);
                if (IsFind)
                {
                    File.Delete(FilePath);
                }
                else
                {
                    throw new IOException("指定的文件不存在");
                }
                return true;
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }

        }

        /// <summary>
        /// 执行过程中可能会打开多个EXCEL文件 所以杀掉
        /// </summary>
        private static void QuertExcel()
        {
            Process[] excels = Process.GetProcessesByName("EXCEL");
            foreach (var item in excels)
            {
                item.Kill();
            }
        }


        #endregion



    }
}
