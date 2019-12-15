using System.Collections.Generic;
using System.Windows.Forms;
using Entity;
using CefSharp.WinForms;
using System.Drawing;
using System;
using excel_operation.Common;
using excel_operation.CS;
using System.IO;
using System.Diagnostics;

namespace excel_operation.Common
{
    public partial class TaskWork : Form
    {
        /// <summary>
        /// 全选开关
        /// </summary>
        int allselect = 0;
        //任务id
        int taskid;

        public TaskWork()
        {
            //Login tb = new Login();
            //tb.Show();
            //if (Manager.WaitLogin(tb))
            //{
            //tb.Hide();
            InitializeComponent();


            //绑定数据后不会自动创建列
            dgv1.AutoGenerateColumns = false;
            //不显示空白行
            dgv1.AllowUserToAddRows = false;




            bind();
        }

        #region bind

        void bind()
        {
            dgv1.DataSource = BLL.basic_taskManager.Search(1, 1000, "", "1", new DateTime(), new DateTime(), new DateTime(), new DateTime(), "");

        }




        #endregion




        #region datagridview 方法

        #region btn_reset_dgv_Click
        /// <summary>
        /// 重置时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_reset_dgv_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "请选择";
            //cb_fahuo.Text = "请选择";
            cb_state1.Text = "请选择";
        }
        #endregion

        #region btn_search_Click
        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_search_Click(object sender, EventArgs e)
        {
            DateTime temp_date2 = new DateTime();
            if (dateTimePicker1.Text != "请选择")
            {
                temp_date2 = dateTimePicker1.Value;
            }
            string key = txt_key.Text.Trim();

            //string tixing = cb_tixing.Text;
            //if (tixing == "无")
            //    tixing = "0";
            //else if (tixing == "每天")
            //    tixing = "1";
            //else if (tixing == "每月")
            //    tixing = "2";
            //else if (tixing == "每年")
            //    tixing = "3";
            //else
            //    tixing = "";

            string state = cb_state1.Text;
            if (state == "未处理")
                state = "1";
            else if (state == "已完成")
                state = "2";
            else
                state = "";

            //string state_fahuo = cb_fahuo.Text;
            //if (state_fahuo == "未发货")
            //    state_fahuo = "1";
            //else if (state_fahuo == "已发货")
            //    state_fahuo = "2";
            //else
            //    state_fahuo = "";

            //string state_shoucai = cb_shoucai.Text;
            //if (state_shoucai == "未收菜")
            //    state_shoucai = "1";
            //else if (state_shoucai == "已收菜")
            //    state_shoucai = "2";
            //else if (state_shoucai == "有问题")
            //    state_shoucai = "3";
            //else
            //    state_shoucai = "";

            //dgv1.DataSource = BLL2.shuadan_recordsManager.Search(1, 1000, key, dptype, state_kongbao, state_fahuo, state_shoucai, temp_date2, temp_date2, "");
            dgv1.DataSource = BLL.basic_taskManager.Search(1, 1000, key, state, new DateTime(), new DateTime(), new DateTime(), new DateTime(), "");

        }



        #endregion

        #region dateTimePicker1_CloseUp

        /// <summary>
        /// 设置时间显示格式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void dateTimePicker1_CloseUp(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Long;
        }
        #endregion

        #region btn_delete_Click
        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否要删除选中数据?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {

                    foreach (DataGridViewRow row in dgv1.Rows)
                    {
                        if (row.Index != -1)
                        {
                            DataGridViewCheckBoxCell cbx = (DataGridViewCheckBoxCell)row.Cells[0];
                            if ((bool)cbx.FormattedValue)
                            {
                                basic_task sr = (basic_task)row.DataBoundItem;
                                BLL.basic_taskManager.Delete(sr.btid);
                            }
                        }
                    }

                    bind();
                    MessageBox.Show("批量删除关键词成功");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        #endregion


        #region dgv1_CellContentClick

        /// <summary>
        /// 点击单元格内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //如果不是首行
                if (e.RowIndex > -1)
                {
                    string colname = dgv1.Columns[e.ColumnIndex].Name;
                    basic_task sr = (basic_task)dgv1.CurrentRow.DataBoundItem;

                    if (colname == "col_dingshi")
                    {
                        #region 修改状态
                        //dp.dpstate = dp.dpstate == "1" ? "0" : "1";
                        //BLL2.dianpuManager.Update(dp);
                        //dataGridView1.CurrentCell = null;
                        //dataGridView1.Refresh();
                        #endregion
                    }
                    else if (colname == "col_state")
                    {
                        #region 修改状态
                        sr.btstate = sr.btstate == "1" ? "2" : "1";
                        BLL.basic_taskManager.Update(sr);
                        dgv1.CurrentCell = null;
                        dgv1.Refresh();
                        #endregion
                    }
                    else if (colname == "col_edit")
                    {
                        #region 修改状态
                        bindedit(sr);
                        #endregion
                    }
                    

                }
                else if (e.RowIndex == -1)
                {
                    //如果是首行
                    #region 全选
                    //如果是全选
                    if (e.ColumnIndex == 0)
                    {
                        foreach (DataGridViewRow row in dgv1.Rows)
                        {
                            if (row.Index != -1)
                            {
                                DataGridViewCheckBoxCell cbx = (DataGridViewCheckBoxCell)row.Cells[0];
                                cbx.Value = allselect == 0 ? true : false;
                            }
                        }
                        allselect = allselect == 1 ? 0 : 1;
                    }
                    #endregion
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void dgv1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //如果不是首行
                if (e.RowIndex > -1)
                {
                    string colname = dgv1.Columns[e.ColumnIndex].Name;
                    basic_task sr = (basic_task)dgv1.CurrentRow.DataBoundItem;
                    taskid = sr.btid;
                    tabControl1.SelectedTab = tabPage3;
                    bindedit(sr);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region dgv1_CellFormatting
        /// <summary>
        /// 修改单元格显示格式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.Value != null)
                {
                    if (dgv1.DataSource != null)
                    {

                        if (dgv1.Columns[e.ColumnIndex].Name.Equals("col_dingshi"))
                        {
                            string name = e.Value.ToString();
                            if (name == "0")
                            {
                                e.Value = "无";
                                //e.CellStyle.ForeColor = Color.Green;
                            }
                            else if (name == "1")
                            {
                                e.Value = "每天";
                                e.CellStyle.ForeColor = Color.Green;
                            }
                            else if (name == "2")
                            {
                                e.Value = "每月";
                                e.CellStyle.ForeColor = Color.GreenYellow;
                            }
                            else if (name == "3")
                            {
                                e.Value = "每年";
                                e.CellStyle.ForeColor = Color.LightGreen;
                            }
                        }
                        if (dgv1.Columns[e.ColumnIndex].Name.Equals("col_state"))
                        {
                            string name = e.Value.ToString();
                            if (name == "1")
                            {
                                e.Value = "未处理";
                                e.CellStyle.ForeColor = Color.Red;
                            }
                            else if (name == "2")
                            {
                                e.Value = "已完成";
                                e.CellStyle.ForeColor = Color.Green;
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("======================================================================");
                Debug.WriteLine("网址：" + Browser.urlstr);
                Debug.WriteLine(DateTime.Now.ToString());
                Debug.WriteLine("信息绑定失败：" + ex.Message);
            }
        }
        #endregion

        #region dgv1_CellParsing
        /// <summary>
        /// 自动保存 用户离开单元格时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv1_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            try
            {
                //int i = dgv_title.CurrentCell.ColumnIndex;
                string colname = dgv1.Columns[dgv1.CurrentCell.ColumnIndex].Name;


                if (colname.Equals("btname") || colname.Equals("btcontent")  )
                {
                    basic_task bt = (basic_task)dgv1.CurrentRow.DataBoundItem;
                    if (bt != null)
                    {


                        string btname = dgv1["btname", e.RowIndex].EditedFormattedValue == null ? "" : dgv1["btname", e.RowIndex].EditedFormattedValue.ToString();
                        string btcontent = dgv1["btcontent", e.RowIndex].EditedFormattedValue == null ? "" : dgv1["btcontent", e.RowIndex].EditedFormattedValue.ToString();
                         



                        bt.btname = btname;
                        bt.btcontent = btcontent;


                        BLL.basic_taskManager.Update(bt);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("修改信息失败 " + ex.Message);
            }
        }
        #endregion

        #region dgv1_RowPostPaint
        /// <summary>
        /// 添加行号-表格绘制完成之后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //添加行号
            SolidBrush b = new SolidBrush(this.dgv1.RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), this.dgv1.DefaultCellStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 10);
        }







        #endregion

        #endregion

        #region dateTimePicker1_CloseUp_1
        private void dateTimePicker1_CloseUp_1(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Long;
        }

        #endregion


        #region btn_save_Click


        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txt_name.Text.Trim();
                string chongfu = cb_chongfu.Text;
                string state = cb_state.Text;
                DateTime temp_date2 = new DateTime();
                if (dateTimePicker1.Text != "请选择")
                {
                    temp_date2 = dateTimePicker1.Value;
                }

                if (chongfu == "无")
                    chongfu = "0";
                else if (chongfu == "每天")
                    chongfu = "1";
                else if (chongfu == "每月")
                    chongfu = "2";
                else
                    chongfu = "3";

                if (state == "未处理")
                    state = "1";
                else if (state == "已完成")
                    state = "2";
                string content = txt_context.Text.Trim();

                basic_task bt = new basic_task();
                if (taskid != 0)
                    bt = BLL.basic_taskManager.SearchByID(taskid);
                bt.btcontent = content;
                bt.btdate = temp_date2;
                bt.btname = name;
                bt.btspare1 = chongfu;
                bt.btstate = state;

                if (taskid == 0)
                {
                    bt.btdate2 = DateTime.Now;
                    BLL.basic_taskManager.Insert(bt);

                }
                else
                {
                    BLL.basic_taskManager.Update(bt);
                }
                bind();
                MessageBox.Show("保存成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存错误" + ex.ToString());
            }
        }
        #endregion

        #region bindedit
        void bindedit(basic_task sr)
        {
            tabControl1.SelectedTab = tabPage3;

            taskid = sr.btid;
            txt_name.Text = sr.btname;
            txt_context.Text = sr.btcontent;
            string chongfu = sr.btspare1;
            if (chongfu == "0")
                chongfu = "无";
            else if (chongfu == "1")
                chongfu = "每天";
            else if (chongfu == "2")
                chongfu = "每月";
            else
                chongfu = "每年";
            cb_chongfu.SelectedItem = chongfu;

            string state = sr.btstate;
            if (state == "1")
                state = "未处理";
            else if (state == "2")
                state = "已完成";
            cb_state.SelectedItem = state;

            if (sr.btdate != new DateTime())
            {
                dateTimePicker1.Format = DateTimePickerFormat.Custom;
                dateTimePicker1.CustomFormat = sr.btdate.ToString("yyyy-MM-dd");
            }
        }
        #endregion

        #region reset
        void reset()
        {
            tabControl1.SelectedTab = tabPage3;

            txt_name.Text = "";
            txt_context.Text = "";
           
            cb_chongfu.Text = "无";

            
            cb_state.Text = "未处理";

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "请选择";
             
        }
        #endregion

        #region btn_weifahuo_Click
        private void btn_weifahuo_Click(object sender, EventArgs e)
        {
            bind();
        }
        #endregion

        #region btn_add_Click
        private void btn_add_Click(object sender, EventArgs e)
        {
            taskid = 0;
            reset();
            tabControl1.SelectedTab = tabPage3;
        }
        #endregion
    }


}
