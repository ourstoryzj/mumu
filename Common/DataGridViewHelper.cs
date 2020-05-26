using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

using System.Text;

using System.Windows.Forms;

namespace Common
{
    public class DataGridViewHelper : DataGridView
    {
        public DataGridViewHelper()
        {
            //允许被删除
            base.AllowUserToDeleteRows = true;
            //绑定数据后不会自动创建列
            base.AutoGenerateColumns = false;
            //不显示空白行
            base.AllowUserToAddRows = false;

            base.RowPostPaint += Dgv_RowPostPaint;

            base.CellContentClick += Dgv_CellContentClick;

            base.CellFormatting += Dgv_CellFormatting;

        }

        #region ToExcel
        /// <summary>
        /// 导出到Excel
        /// </summary>
        /// <param name="dgvData"></param>
        /// <returns></returns>
        public bool ToExcel()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Execl files (*.xls)|*.xls";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.CreatePrompt = true;
            saveFileDialog.Title = "Export Excel File To";
            DialogResult dr = saveFileDialog.ShowDialog();
            if (dr != DialogResult.OK)
            {
                return false;
            }

            Stream myStream;
            myStream = saveFileDialog.OpenFile();
            //StreamWriter sw = new StreamWriter(myStream, System.Text.Encoding.GetEncoding("gb2312"));
            StreamWriter sw = new StreamWriter(myStream, System.Text.Encoding.GetEncoding(-0));
            string str = "";
            try
            {

                
                //写标题
                for (int i = 0; i < base.ColumnCount; i++)
                {
                    if (i > 0)
                    {
                        str += "\t";
                    }
                    str += base.Columns[i].HeaderText;
                }
                sw.WriteLine(str);
                //写内容
                for (int j = 0; j < base.Rows.Count; j++)
                {
                    string tempStr = "";
                    for (int k = 0; k < base.Columns.Count; k++)
                    {
                        if (k > 0)
                        {
                            tempStr += "\t";
                        }
                        string cellValue = "";
                        try
                        {
                            cellValue = base.Rows[j].Cells[k].Value.ToString();
                            cellValue = cellValue.Replace(" ", "");
                            cellValue = cellValue.Replace("\r", "");
                            cellValue = cellValue.Replace("\n", "");
                            cellValue = cellValue.Replace("\r\n", "");
                        }
                        catch { }
                        tempStr += cellValue;
                        // tempStr += dgvData.Rows[j].Cells[k].Value.ToString();
                    }

                    sw.WriteLine(tempStr);
                }
                sw.Close();
                myStream.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
            finally
            {
                sw.Close();
                myStream.Close();
            }

            return true;
        }
        #endregion

        #region Dgv_Init
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="dgv"></param>
        //public static void ToInit(this DataGridView dgv)
        //{
            
        //    //允许被删除
        //    dgv.AllowUserToDeleteRows = true;
        //    //绑定数据后不会自动创建列
        //    dgv.AutoGenerateColumns = false;
        //    //不显示空白行
        //    dgv.AllowUserToAddRows = false;

        //    dgv.RowPostPaint += Dgv_RowPostPaint;
        //    dgv.CellContentClick += Dgv_CellContentClick;
        //    dgv.CellFormatting += Dgv_CellFormatting;
        //} 
        #endregion

        #region Dgv_RowPostPaint 添加行号
        /// <summary>
        /// 添加行号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Dgv_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //DataGridView dgv1 = (DataGridView)sender;
            //添加行号
            SolidBrush b = new SolidBrush(base.RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), base.DefaultCellStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 10);
        }
        #endregion

        #region Dgv_CellContentClick 点击事件案例 多选
        /// <summary>
        /// 点击事件案例 多选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView dgv1 = (DataGridView)sender;
                //如果不是首行
                if (e.RowIndex > -1)
                {

                    //string colname = dgv1.Columns[e.ColumnIndex].Name;
                    ////basic_task sr = (basic_task)dgv1.CurrentRow.DataBoundItem;
                    //if (colname == "col_state")
                    //{
                    //    #region 修改状态
                    //    //sr.btstate = sr.btstate == "1" ? "2" : "1";
                    //    //BLL.basic_taskManager.Update(sr);
                    //    dgv1.CurrentCell = null;
                    //    dgv1.Refresh();
                    //    #endregion
                    //}
                    //else if (colname == "col_edit")
                    //{
                    //    #region 修改状态
                    //    //bindedit(sr);
                    //    #endregion
                    //}


                }
                else if (e.RowIndex == -1)
                {
                    //如果是首行
                    #region 全选
                    //如果是全选
                    try
                    {
                        if (e.ColumnIndex == 0)
                        {
                            //如果有没有选中的则全选,否则取消全选
                            bool hasfalse = false;
                            try
                            {
                                foreach (DataGridViewRow row in dgv1.Rows)
                                {
                                    if (row.Index != -1)
                                    {
                                        DataGridViewCheckBoxCell cbx = (DataGridViewCheckBoxCell)row.Cells[0];
                                        bool ischeck = false;
                                        if (cbx != null)
                                        {
                                            if (cbx.Value != null)
                                            {
                                                bool.TryParse(cbx.Value.ToString(), out ischeck);
                                                if (ischeck == false)
                                                {
                                                    hasfalse = true;
                                                    break;
                                                }
                                            }
                                            else { hasfalse = true; }
                                        }
                                        else { hasfalse = true; }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                ex.Message.ToShow();
                            }
                            ToClearChecked();
                            foreach (DataGridViewRow row in dgv1.Rows)
                            {
                                if (row.Index != -1)
                                {
                                    DataGridViewCheckBoxCell cbx = (DataGridViewCheckBoxCell)row.Cells[0];
                                    cbx.Value = hasfalse ? true : false;
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        ex.ToLog();
                    }
                    #endregion
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        #endregion

        #region Dgv_CellFormatting 修改单元格显示格式
        /// <summary>
        /// 修改单元格显示格式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView dgv1 = (DataGridView)sender;
            if (e.Value != null)
            {
                if (dgv1.DataSource != null)
                {
                    if (dgv1.Columns[e.ColumnIndex].Name.Equals("col_state"))
                    {
                        string name = e.Value.ToString();
                        if (name == "1")
                        {
                            e.Value = "启用";
                            e.CellStyle.ForeColor = Color.Red;
                        }
                        else if (name == "2")
                        {
                            e.Value = "禁用";
                            e.CellStyle.ForeColor = Color.Green;
                        }

                    }
                }
            }

        }
        #endregion

        #region Dgv_CellParsing
        /// <summary>
        /// 自动保存 用户离开单元格时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dgv_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            try
            {
                //int i = dgv_title.CurrentCell.ColumnIndex;
                //string colname = dgv1.Columns[dgv1.CurrentCell.ColumnIndex].Name;


                //if (colname.Equals("btname") || colname.Equals("btcontent"))
                //{
                //    basic_task bt = (basic_task)dgv1.CurrentRow.DataBoundItem;
                //    if (bt != null)
                //    {


                //        string btname = dgv1["btname", e.RowIndex].EditedFormattedValue == null ? "" : dgv1["btname", e.RowIndex].EditedFormattedValue.ToString();
                //        string btcontent = dgv1["btcontent", e.RowIndex].EditedFormattedValue == null ? "" : dgv1["btcontent", e.RowIndex].EditedFormattedValue.ToString();




                //        bt.btname = btname;
                //        bt.btcontent = btcontent;


                //        BLL.basic_taskManager.Update(bt);
                //    }
                //}
            }
            catch (Exception ex)
            {
                ex.ToShow();
                //Debug.WriteLine("修改信息失败 " + ex.Message);
            }
        }
        #endregion

        #region ToClearChecked
        /// <summary>
        /// 取消选中状态
        /// </summary>
        /// <param name="dgv"></param>
        public void ToClearChecked()
        {
            try
            {
                base.CurrentCell = null;
                base.Refresh();
            }
            catch
            {
            }
        }
        #endregion


        #region GetDeleteCheckedIndex
        /// <summary>
        /// 获取需要删除行列表
        /// </summary>
        /// <returns></returns>
        public List<int> GetDeleteCheckedIndex()
        {
            //List<int> list = new List<int>();
            //if (MessageBox.Show("是否要删除选中数据?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            //{
            //    try
            //    {
            //        foreach (DataGridViewRow row in base.Rows)
            //        {
            //            if (row.Index != -1)
            //            {
            //                DataGridViewCheckBoxCell cbx = (DataGridViewCheckBoxCell)row.Cells[0];
            //                if ((bool)cbx.FormattedValue)
            //                {
            //                    //basic_task sr = (basic_task)dgv1.CurrentRow.DataBoundItem;
            //                    //BLL.basic_taskManager.Delete(sr.btid);
            //                    list.Add(row.Index);
            //                }
            //            }
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.ToString());
            //    }
            //}
            //return list;
            return GetCheckedIndex("是否要删除选中数据?");
        }
 
        /// <summary>
        /// 获取需要删除行列表
        /// </summary>
        /// <returns></returns>
        public List<int> GetCheckedIndex(string mess)
        {
            List<int> list = new List<int>();
            if (MessageBox.Show(mess, "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    foreach (DataGridViewRow row in base.Rows)
                    {
                        if (row.Index != -1)
                        {
                            DataGridViewCheckBoxCell cbx = (DataGridViewCheckBoxCell)row.Cells[0];
                            if ((bool)cbx.FormattedValue)
                            {
                                list.Add(row.Index);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            return list;
        }
        #endregion


        #region ToAfterDelete
        /// <summary>
        /// 删除之后隐藏该条信息
        /// </summary>
        /// <param name="index"></param>
        public void ToAfterDelete(int index)
        {
            #region MyRegion
            CurrencyManager cm = (CurrencyManager)BindingContext[base.DataSource];
            cm.SuspendBinding();
            base.Rows[index].Visible = false;
            cm.ResumeBinding();
            ToClearChecked();
            #endregion
        } 
        #endregion

    }
}
