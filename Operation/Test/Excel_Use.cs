using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using NPOI.HSSF.Model;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;


namespace Operation
{
    public partial class form_main : Form
    {
        #region form_main
        public form_main()
        {
            InitializeComponent();
        }
        #endregion

        #region btn_xuanzewenjian_Click
        /// <summary>
        /// 选择文件按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_xuanzewenjian_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.txt_lujing.Text = this.openFileDialog1.FileName;
            }
        }
        #endregion

        #region btn_bangding_Click
        /// <summary>
        /// 点击导出excel按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_bangding_Click(object sender, EventArgs e)
        {
            string FileUrl = this.openFileDialog1.FileName;
            //DataTable dt = ExcelUp(File);
            // DataSet sd = LoadDataFromExcel(File);
            //dataGridView1.AutoGenerateColumns = false;
            //dataGridView1.DataSource = dt;
            //dataGridView1.DataSource = sd;
            DataTable dt = ReadExcel(FileUrl);
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = dt;

            //dataGridView1.DataBing();
            //dataGridView1.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;

        }
        #endregion

        #region ReadExcel
        /// <summary>
        /// 读取Excel[.xls](返回DataTable)
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
            catch
            {
                System.Windows.Forms.MessageBox.Show("Excel格式错误或者Excel正由另一进程在访问");
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

        #region btn_test_Click
        private void btn_test_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string changdu1 = txt_changdu1.Text.Trim();
            string changdu2 = txt_changdu2.Text.Trim();
            string cishu1 = txt_cishu1.Text.Trim();
            string cishu2 = txt_cishu2.Text.Trim();
            string dianjilv1 = txt_dianjilv1.Text.Trim();
            string dianjilv2 = txt_dianjilv2.Text.Trim();
            string renshu1 = txt_renshu1.Text.Trim();
            string renshu2 = txt_renshu2.Text.Trim();
            string shangcheng1 = txt_shangcheng1.Text.Trim();
            string shangcheng2 = txt_shangcheng2.Text.Trim();
            string zhitongche1 = txt_zhitongche1.Text.Trim();
            string zhitongche2 = txt_zhitongche2.Text.Trim();
            string zhuanhualv1 = txt_zhuanhualv1.Text.Trim();
            string zhuanhualv2 = txt_zhuanhualv2.Text.Trim();
            string temp1;
            decimal temp2;
            dt = GetDgvToTable(dataGridView1);
            List<DataRow> list = new List<DataRow>();

            try
            {
                //处理长度
                if (!string.IsNullOrEmpty(changdu1))
                {
                    if (decimal.TryParse(changdu1, out temp2))
                    {
                        if (temp2 != 0)
                        {
                            foreach (DataRow r in dt.Rows)
                            {
                                temp1 = r[1].ToString();
                                //DataRow r_temp = r;
                                if (temp1.Length < temp2)
                                {
                                    list.Add(r);
                                }
                            }
                            dt = toDelect(dt, list);
                        }
                    }
                    else
                    {
                        MessageBox.Show("筛选关键词长度的条件设置错误！1");
                        txt_changdu1.Focus();
                        txt_changdu1.SelectAll();
                        return;
                    }
                }
                if (!string.IsNullOrEmpty(changdu2))
                {
                    if (decimal.TryParse(changdu2, out temp2))
                    {
                        list.Clear();
                        if (temp2 != 0)
                        {
                            foreach (DataRow r in dt.Rows)
                            {
                                temp1 = r[1].ToString();
                                if (temp1.Length > temp2)
                                {
                                    list.Add(r);
                                }
                            }
                            dt = toDelect(dt, list);
                        }
                    }
                    else
                    {
                        MessageBox.Show("筛选关键词长度的条件设置错误！2");
                        txt_changdu2.Focus();
                        txt_changdu2.SelectAll();
                        return;
                    }
                }//处理长度结束
                //处理人数
                if (!string.IsNullOrEmpty(renshu1))
                {
                    if (decimal.TryParse(renshu1, out temp2))
                    {
                        list.Clear();
                        if (temp2 != 0)
                        {
                            foreach (DataRow r in dt.Rows)
                            {
                                temp1 = r[2].ToString();
                                if (Convert.ToDecimal(temp1) < temp2)
                                {
                                    list.Add(r);
                                }
                            }
                            dt = toDelect(dt, list);
                        }
                    }
                    else
                    {
                        MessageBox.Show("筛选人数的条件设置错误！1");
                        txt_renshu1.Focus();
                        txt_renshu1.SelectAll();
                        return;
                    }
                }
                if (!string.IsNullOrEmpty(renshu2))
                {
                    if (decimal.TryParse(renshu2, out temp2))
                    {
                        list.Clear();
                        if (temp2 != 0)
                        {
                            foreach (DataRow r in dt.Rows)
                            {
                                temp1 = r[2].ToString();
                                if (Convert.ToDecimal(temp1) > temp2)
                                {
                                    list.Add(r);
                                }
                            }
                            dt = toDelect(dt, list);
                        }
                    }
                    else
                    {
                        MessageBox.Show("筛选人数的条件设置错误！2");
                        txt_renshu2.Focus();
                        txt_renshu2.SelectAll();
                        return;
                    }
                }
                //处理人数结束
                //处理次数
                if (!string.IsNullOrEmpty(cishu1))
                {
                    if (decimal.TryParse(cishu1, out temp2))
                    {
                        list.Clear();
                        if (temp2 != 0)
                        {
                            foreach (DataRow r in dt.Rows)
                            {
                                temp1 = r[3].ToString();
                                if (Convert.ToDecimal(temp1) < temp2)
                                {
                                    list.Add(r);
                                }
                            }
                            dt = toDelect(dt, list);
                        }
                    }
                    else
                    {
                        MessageBox.Show("筛选次数的条件设置错误！1");
                        txt_cishu1.Focus();
                        txt_cishu1.SelectAll();
                        return;
                    }
                }
                if (!string.IsNullOrEmpty(cishu2))
                {
                    if (decimal.TryParse(cishu2, out temp2))
                    {
                        list.Clear();
                        if (temp2 != 0)
                        {
                            foreach (DataRow r in dt.Rows)
                            {
                                temp1 = r[3].ToString();
                                if (Convert.ToDecimal(temp1) > temp2)
                                {
                                    list.Add(r);
                                }
                            }
                            dt = toDelect(dt, list);
                        }
                    }
                    else
                    {
                        MessageBox.Show("筛选人数的条件设置错误！2");
                        txt_cishu2.Focus();
                        txt_cishu2.SelectAll();
                        return;
                    }
                }
                //处理次数结束

                //处理商城占比
                if (!string.IsNullOrEmpty(shangcheng1))
                {
                    if (decimal.TryParse(shangcheng1, out temp2))
                    {
                        list.Clear();
                        if (temp2 != 0)
                        {
                            foreach (DataRow r in dt.Rows)
                            {
                                temp1 = r[6].ToString();
                                temp1 = temp1.Substring(0, temp1.IndexOf("%"));
                                if (Convert.ToDecimal(temp1) < temp2)
                                {
                                    list.Add(r);
                                }
                            }
                            dt = toDelect(dt, list);
                        }
                    }
                    else
                    {
                        MessageBox.Show("筛选商城占比的条件设置错误！1");
                        txt_shangcheng1.Focus();
                        txt_shangcheng1.SelectAll();
                        return;
                    }
                }
                if (!string.IsNullOrEmpty(shangcheng2))
                {
                    if (decimal.TryParse(shangcheng2, out temp2))
                    {
                        list.Clear();
                        if (temp2 != 0)
                        {
                            foreach (DataRow r in dt.Rows)
                            {
                                temp1 = r[6].ToString();
                                temp1 = temp1.Substring(0, temp1.IndexOf("%"));
                                if (Convert.ToDecimal(temp1) > temp2)
                                {
                                    list.Add(r);
                                }
                            }
                            dt = toDelect(dt, list);
                        }
                    }
                    else
                    {
                        MessageBox.Show("筛选商城占比的条件设置错误！2");
                        txt_shangcheng2.Focus();
                        txt_shangcheng2.SelectAll();
                        return;
                    }
                }
                //处理商城占比结束

                //处理点击率
                if (!string.IsNullOrEmpty(dianjilv1))
                {
                    if (decimal.TryParse(dianjilv1, out temp2))
                    {
                        list.Clear();
                        if (temp2 != 0)
                        {
                            foreach (DataRow r in dt.Rows)
                            {
                                temp1 = r[7].ToString();
                                temp1 = temp1.Substring(0, temp1.IndexOf("%"));
                                if (Convert.ToDecimal(temp1) < temp2)
                                {
                                    list.Add(r);
                                }
                            }
                            dt = toDelect(dt, list);
                        }
                    }
                    else
                    {
                        MessageBox.Show("筛选点击率的条件设置错误！1");
                        txt_dianjilv1.Focus();
                        txt_dianjilv1.SelectAll();
                        return;
                    }
                }
                if (!string.IsNullOrEmpty(dianjilv2))
                {
                    if (decimal.TryParse(dianjilv2, out temp2))
                    {
                        list.Clear();
                        if (temp2 != 0)
                        {
                            foreach (DataRow r in dt.Rows)
                            {
                                temp1 = r[7].ToString();
                                temp1 = temp1.Substring(0, temp1.IndexOf("%"));
                                if (Convert.ToDecimal(temp1) > temp2)
                                {
                                    list.Add(r);
                                }
                            }
                            dt = toDelect(dt, list);
                        }
                    }
                    else
                    {
                        MessageBox.Show("筛选商城占比的条件设置错误！2");
                        txt_dianjilv2.Focus();
                        txt_dianjilv2.SelectAll();
                        return;
                    }
                }
                //处理点击率结束

                //处理转化率
                if (!string.IsNullOrEmpty(zhuanhualv1))
                {
                    if (decimal.TryParse(zhuanhualv1, out temp2))
                    {
                        list.Clear();
                        if (temp2 != 0)
                        {
                            foreach (DataRow r in dt.Rows)
                            {
                                temp1 = r[9].ToString();
                                temp1 = temp1.Substring(0, temp1.IndexOf("%"));
                                if (Convert.ToDecimal(temp1) < temp2)
                                {
                                    list.Add(r);
                                }
                            }
                            dt = toDelect(dt, list);
                        }
                    }
                    else
                    {
                        MessageBox.Show("筛选转化率的条件设置错误！1");
                        txt_zhuanhualv1.Focus();
                        txt_zhuanhualv1.SelectAll();
                        return;
                    }
                }
                if (!string.IsNullOrEmpty(zhuanhualv2))
                {
                    if (decimal.TryParse(zhuanhualv2, out temp2))
                    {
                        list.Clear();
                        if (temp2 != 0)
                        {
                            foreach (DataRow r in dt.Rows)
                            {
                                temp1 = r[9].ToString();
                                temp1 = temp1.Substring(0, temp1.IndexOf("%"));
                                if (Convert.ToDecimal(temp1) > temp2)
                                {
                                    list.Add(r);
                                }
                            }
                            dt = toDelect(dt, list);
                        }
                    }
                    else
                    {
                        MessageBox.Show("筛选转化率的条件设置错误！2");
                        txt_zhuanhualv2.Focus();
                        txt_zhuanhualv2.SelectAll();
                        return;
                    }
                }
                //处理点击率结束

                //处理直通车出价
                if (!string.IsNullOrEmpty(zhitongche1))
                {
                    if (decimal.TryParse(zhitongche1, out temp2))
                    {
                        list.Clear();
                        if (temp2 != 0)
                        {
                            foreach (DataRow r in dt.Rows)
                            {
                                temp1 = r[10].ToString();
                                if (Convert.ToDecimal(temp1) < temp2)
                                {
                                    list.Add(r);
                                }
                            }
                            dt = toDelect(dt, list);
                        }
                    }
                    else
                    {
                        MessageBox.Show("筛选直通车出价的条件设置错误！1");
                        txt_zhitongche1.Focus();
                        txt_zhitongche1.SelectAll();
                        return;
                    }
                }
                if (!string.IsNullOrEmpty(zhitongche2))
                {
                    if (decimal.TryParse(zhitongche2, out temp2))
                    {
                        list.Clear();
                        if (temp2 != 0)
                        {
                            foreach (DataRow r in dt.Rows)
                            {
                                temp1 = r[10].ToString();
                                if (Convert.ToDecimal(temp1) > temp2)
                                {
                                    list.Add(r);
                                }
                            }
                            dt = toDelect(dt, list);
                        }
                    }
                    else
                    {
                        MessageBox.Show("筛选直通车出价的条件设置错误！2");
                        txt_zhitongche2.Focus();
                        txt_zhitongche2.SelectAll();
                        return;
                    }
                }
                //处理直通车出价结束

                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }


        }


        /// <summary>
        /// 删除符合条件的数据
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public DataTable toDelect(DataTable dt, List<DataRow> list)
        {
            DataTable dt_res = dt.Clone();
            try
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (!list.Contains(dr))
                    {

                        DataRow dr_res = dt_res.NewRow();
                        int i = 0;
                        foreach (object cell in dr.ItemArray)
                        {
                            dr_res[i] = cell;
                            i++;
                        }
                        if (!string.IsNullOrEmpty(dr_res[0].ToString()))
                            dt_res.Rows.Add(dr_res);

                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("删除数据时出错" + e.Message + e.Source);
            }
            return dt_res;
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

        #region dataGridView1_Sorted
        private void dataGridView1_Sorted(object sender, EventArgs e)
        {
            MessageBox.Show("测试");
        }
        #endregion

        #region dataGridView1_DataSourceChanged
        private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
            {
                this.dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.Programmatic;
            }
        }
        #endregion

        #region 排序
        /// <summary>
        /// dataGridView1_ColumnHeaderMouseClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = GetDgvToTable(dataGridView1);
            int ci = e.ColumnIndex;

            //冒牌排序开始
            DataRow dr = dt.NewRow();
            DataGridViewRow row1 = new DataGridViewRow();
            //外循环
            //try
            //{
            for (int i = 0; i < dt.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dt.Rows.Count - i - 1; j++)
                {
                    object temp_obj = dt.Rows[j][ci];
                    object temp_obj2 = dt.Rows[j + 1][ci];
                    if (temp_obj != null && temp_obj2 != null)
                    {
                        decimal temp_db1;
                        decimal temp_db2;
                        object[] obj;
                        //如果是数值
                        if (decimal.TryParse(temp_obj.ToString(), out temp_db1) && temp_obj.ToString() != "-" && temp_obj2.ToString() != "-")
                        {
                            if (temp_obj2 != DBNull.Value)
                            {
                                temp_db2 = Convert.ToDecimal(temp_obj2);
                                if (temp_db1 < temp_db2)
                                {
                                    obj = dt.Rows[j + 1].ItemArray;
                                    dt.Rows[j + 1].ItemArray = dt.Rows[j].ItemArray;
                                    dt.Rows[j].ItemArray = obj;
                                }
                            }
                        }
                        //如果是百分比
                        else if (temp_obj.ToString().IndexOf("%") > 0)
                        {
                            temp_db1 = toDecimal(temp_obj.ToString());
                            temp_db2 = toDecimal(temp_obj2.ToString());
                            if (temp_db1 < temp_db2)
                            {
                                obj = dt.Rows[j + 1].ItemArray;
                                dt.Rows[j + 1].ItemArray = dt.Rows[j].ItemArray;
                                dt.Rows[j].ItemArray = obj;
                            }
                        }
                        else
                        {
                            string temp_str1 = temp_obj.ToString();
                            string temp_str2 = temp_obj2.ToString();

                            if (temp_str1.Length < temp_str2.Length)
                            {
                                obj = dt.Rows[j + 1].ItemArray;
                                dt.Rows[j + 1].ItemArray = dt.Rows[j].ItemArray;
                                dt.Rows[j].ItemArray = obj;
                            }
                        }
                    }
                }
            }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
            dataGridView1.DataSource = dt;

        }
        #endregion

        #region toDecimal
        /// <summary>
        /// 百分比转换为decimal
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private decimal toDecimal(string str)
        {
            string label = str.Substring(0, str.Length - 1);
            decimal decLabel = decimal.Parse(label) / 100;
            return decLabel;
        }
        #endregion

        #region openFileDialog1_FileOk
        /// <summary>
        /// 选择后自动绑定数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string FileUrl = this.openFileDialog1.FileName;
            DataTable dt = ReadExcel(FileUrl);
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = dt;
        }
        #endregion

        #region txt_lujing_Click
        /// <summary>
        /// 地址栏点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_lujing_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.txt_lujing.Text = this.openFileDialog1.FileName;
            }
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
            int i=1;
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

        private void btn_save_Click(object sender, EventArgs e)
        {
            RenderDataTableToExcel(GetDgvToTable(dataGridView1));
        }

       


    }
}
