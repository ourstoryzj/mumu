using System.Collections.Generic;
using System.Windows.Forms;
using Entity;
using CefSharp.WinForms;
using System.Drawing;
using System;
using Operation.Other;
using Operation.CS;
using System.IO;
using System.Diagnostics;
using System.ComponentModel;
using System.Text;

namespace Operation.TaoBao
{
    public partial class TB_FaHuo : Form
    {
        CefSharp.WinForms.ChromiumWebBrowser webBrowser1;
        CefSharp.WinForms.ChromiumWebBrowser webBrowser2;
        CefSharp.WinForms.ChromiumWebBrowser webBrowser3;
        CefSharp.WinForms.ChromiumWebBrowser webBrowser4;
        CefSharp.WinForms.ChromiumWebBrowser webBrowser5;

        //白沟货源列表
        List<string> list_baigou = new List<string>();
        //本地货源列表
        List<string> list_bendi = new List<string>();
        //特殊地区列表
        List<string> list_diqu = new List<string>();
        //记货Email
        List<string> list_email = new List<string>();
        //发红包暂时实例
        shuadan_records sr_temp = new shuadan_records();
        //发红包暂时实例list
        List<shuadan_records> list_sr = new List<shuadan_records>();

        XMLHelpers xh_taobao = new XMLHelpers("JS");
        XMLHelpers xml_js = new XMLHelpers("JS");

        /// <summary>
        /// 短信平台的token
        /// </summary>
        string token;

        /// <summary>
        /// 获取手机号码
        /// </summary>
        string phone;

        /// <summary>
        /// 临时获取订单信息，以便发淘宝空包
        /// </summary>
        string orderinfo_temp;

        //拼多多
        //特殊地区列表
        List<string> list_pdd_order = new List<string>();

        /// <summary>
        /// 全选开关
        /// </summary>
        int allselect = 0;

        /// <summary>
        /// 空包包代发空包查询开关 0:重新查询 1:继续查询
        /// </summary>
        int switch_pdd = 0;

        /// <summary>
        /// 发空包时,点击处理下一个订单,需要排除的订单列表(处理有问题订单)
        /// </summary>
        List<shuadan_records> list_kongbao = new List<shuadan_records>();


        public TB_FaHuo()
        {
            //Login tb = new Login();
            //tb.Show();
            //if (Manager.WaitLogin(tb))
            //{
            //tb.Hide();
            InitializeComponent();
            //this.WindowState = FormWindowState.Maximized;

            this.StartPosition = FormStartPosition.CenterScreen;
            webBrowser1 = new ChromiumWebBrowser("http://www.taobao.com");
            webBrowser1.FrameLoadStart += Browser.BrowserFrameLoadStart;
            webBrowser1.FrameLoadEnd += Browser.BrowserFrameLoadEnd;
            webBrowser1.Size = new Size(1130, 725);
            //webBrowser1.Location = new Point(180, 12);
            webBrowser1.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            tabPage1.Controls.Add(webBrowser1);
            //webBrowser1.RequestContext = tb.webBrowser1.RequestContext;
            //tb.Close();
            //tb.Dispose();

            //添加拼多多
            webBrowser2 = new ChromiumWebBrowser("https://mms.pinduoduo.com/login");
            webBrowser2.FrameLoadStart += Browser.BrowserFrameLoadStart;
            webBrowser2.FrameLoadEnd += Browser.BrowserFrameLoadEnd;
            webBrowser2.Size = new Size(1130, 665);
            webBrowser2.Location = new Point(0, 60);
            webBrowser2.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            //webBrowser2.RequestContext = webBrowser1.RequestContext;
            tp_pdd.Controls.Add(webBrowser2);

            //添加白沟发货
            webBrowser3 = new ChromiumWebBrowser("http://www.yikuaifa.com/Login.aspx");
            webBrowser3.FrameLoadStart += Browser.BrowserFrameLoadStart;
            webBrowser3.FrameLoadEnd += Browser.BrowserFrameLoadEnd;
            webBrowser3.Size = new Size(1130, 665);
            webBrowser3.Location = new Point(0, 60);
            webBrowser3.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            //webBrowser2.RequestContext = webBrowser1.RequestContext;
            tabPage5.Controls.Add(webBrowser3);

            webBrowser4 = new ChromiumWebBrowser("http://www.uu338.com/login.aspx");
            webBrowser4.FrameLoadStart += Browser.BrowserFrameLoadStart;
            webBrowser4.FrameLoadEnd += Browser.BrowserFrameLoadEnd;
            webBrowser4.Size = new Size(1130, 665);
            webBrowser4.Location = new Point(0, 60);
            webBrowser4.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            tp_pddkb.Controls.Add(webBrowser4);


            webBrowser5 = new ChromiumWebBrowser("http://mobile.yangkeduo.com/");
            webBrowser5.FrameLoadStart += Browser.BrowserFrameLoadStart;
            webBrowser5.FrameLoadEnd += Browser.BrowserFrameLoadEnd;
            webBrowser5.Size = new Size(650, 700);
            webBrowser5.Location = new Point(750, 40);
            webBrowser5.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;
            tp_pddbd.Controls.Add(webBrowser5);



            //}

            //绑定数据后不会自动创建列
            dgv1.AutoGenerateColumns = false;
            //不显示空白行
            dgv1.AllowUserToAddRows = false;


            bind_dianpu();
            txt_beizhu.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            bind_config();

            tabControl1.SelectedTab = tp_pdd;

        }

        #region bind

        void bind()
        {

        }


        /// <summary>
        /// 绑定店铺
        /// </summary>
        void bind_dianpu()
        {
            IList<dianpu> list = BLL2.dianpuManager.SearchAll(true);
            //cb_dianpu.DataSource = list;
            dianpu dp = new dianpu();
            dp.dpname = "请选择";
            dp.dpid = 0;
            list.Insert(0, dp);
            cb_dianpu.DataSource = list;
            cb_dianpu.DisplayMember = "dpname";//绑定泛型中类的属性
            cb_dianpu.ValueMember = "dpid";
        }


        void bind_config()
        {
            string temp_bendi = XMLHelper.GetValue("FaHuo_Config_BenDi");
            string temp_baigou = XMLHelper.GetValue("FaHuo_Config_BaiGou");
            string temp_diqu = XMLHelper.GetValue("FaHuo_Config_DiQu");
            string temp_email = XMLHelper.GetValue("FaHuo_Config_Email");

            list_baigou = Manager.StrToList(temp_baigou, ',');
            list_bendi = Manager.StrToList(temp_bendi, ',');
            list_diqu = Manager.StrToList(temp_diqu, ',');
            list_email = Manager.StrToList(temp_email, ',');

            txt_config_baigou.Text = temp_baigou.Replace(",", "\r\n");
            txt_config_bendi.Text = temp_bendi.Replace(",", "\r\n");
            txt_config_diqu.Text = temp_diqu.Replace(",", "\r\n");
            txt_config_email.Text = temp_email.Replace(",", "\r\n");

        }

        #endregion

        #region 基础

        #region

        #region btn_xiaofeizhe_Click
        private void btn_xiaofeizhe_Click(object sender, System.EventArgs e)
        {
            //webBrowser1.Load("https://xiaobao.taobao.com/contract/user_contract.htm");
            //打开退货承诺页面
            webBrowser1.Load("https://xiaobao.taobao.com/contract/item_contract.htm?crtId=2");
            if (Browser.WaitWebPageLoad(" getClassName('J_CatSearch')[0] ", webBrowser1))
            {
                //打开类目下拉菜单
                Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('J_CatSearch')[0].click(); ", webBrowser1);
                //下拉列表容器class=bf-contentbox，选择箱包类目
                Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('bf-contentbox')[0].getElementsByTagName('div')[78].click(); ", webBrowser1);
                //点击搜索
                Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('search-btn')[0].click();", webBrowser1);
                Browser.Delay(500);
                if (Browser.WaitWebPageLoad(webBrowser1))
                {
                    //判断是否有商品
                    if (Browser.JS_CEFBrowser(" document.getElementById('J_GoodsList').getElementsByTagName('tr').length ", webBrowser1) != "1")
                    {
                        //选择全部
                        Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('all-goods')[0].getElementsByTagName('input')[0].click(); ", webBrowser1);
                        //选择批量操作
                        Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('batch-ctr')[0].click(); ", webBrowser1);
                        //点击确定
                        Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('J_Sure')[0].click(); ", webBrowser1);
                    }
                }
            }
        }



        #endregion



        #region btn_dp_huan_Click
        private void btn_dp_huan_Click(object sender, System.EventArgs e)
        {
            Manager.dianpu_huan(webBrowser1);
        }

        #endregion

        #endregion

        #region btn_addjs_Click
        private void btn_addjs_Click(object sender, EventArgs e)
        {
            //Browser.SetJSFile(webBrowser1);
            BLL.SendEmail.send2("181193051@qq.com", "记货", "ceshi");
            //BLL.SendEmail.send();
        }
        #endregion

        #region btn_test_Click
        private void btn_test_Click(object sender, System.EventArgs e)
        {
            string js = txt_js.Text;
            Browser.JS_CEFBrowser_NoReturn(js, webBrowser1);
        }
        #endregion

        #region btn_savehtml_Click
        private void btn_savehtml_Click(object sender, EventArgs e)
        {
            //Browser.SaveHtml(webBrowser2);
            string js = "document.location.href";
            js = Browser.JS_CEFBrowser(js, webBrowser2);
            txt_js.Text = js;
        }









        #endregion


        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            //标签背景填充颜色
            SolidBrush BackBrush = new SolidBrush(Color.Green);
            //标签文字填充颜色
            SolidBrush FrontBrush = new SolidBrush(Color.Black);
            StringFormat StringF = new StringFormat();
            //设置文字对齐方式
            StringF.Alignment = StringAlignment.Center;
            StringF.LineAlignment = StringAlignment.Center;

            for (int i = 0; i < tabControl1.TabPages.Count; i++)
            {
                //获取标签头工作区域
                Rectangle Rec = tabControl1.GetTabRect(i);
                //绘制标签头背景颜色
                e.Graphics.FillRectangle(BackBrush, Rec);
                //绘制标签头文字
                e.Graphics.DrawString(tabControl1.TabPages[i].Text, new Font("宋体", 12), FrontBrush, Rec, StringF);
            }
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
            cb_fahuo.Text = "请选择";
            cb_kongbao.Text = "请选择";
            cb_ordertype.Text = "请选择";
            cb_shoucai.Text = "请选择";
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

            string dptype = cb_type.Text;
            if (dptype == "蘑菇街")
                dptype = "1";
            else if (dptype == "淘宝")
                dptype = "2";
            else if (dptype == "拼多多")
                dptype = "3";
            else
                dptype = "";

            string ordertype = cb_ordertype.Text;
            if (ordertype == "正常单")
                ordertype = "1";
            else if (ordertype == "补单")
                ordertype = "2";
            else if (ordertype == "问题单")
                ordertype = "3";
            else
                ordertype = "";

            string state_kongbao = cb_kongbao.Text;
            if (state_kongbao == "未获取")
                state_kongbao = "1";
            else if (state_kongbao == "已获取")
                state_kongbao = "2";
            else
                state_kongbao = "";

            string state_fahuo = cb_fahuo.Text;
            if (state_fahuo == "未发货")
                state_fahuo = "1";
            else if (state_fahuo == "已发货")
                state_fahuo = "2";
            else
                state_fahuo = "";

            string state_shoucai = cb_shoucai.Text;
            if (state_shoucai == "未收菜")
                state_shoucai = "1";
            else if (state_shoucai == "已收菜")
                state_shoucai = "2";
            else if (state_shoucai == "有问题")
                state_shoucai = "3";
            else
                state_shoucai = "";

            dgv1.DataSource = BLL2.shuadan_recordsManager.Search(1, 1000, key, dptype, ordertype, state_kongbao, state_fahuo, state_shoucai, temp_date2, temp_date2, "");
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
                                shuadan_records sr = (shuadan_records)row.DataBoundItem;
                                BLL2.shuadan_recordsManager.Delete(sr.sdid);
                            }
                        }
                    }

                    dgv1.Refresh();
                    MessageBox.Show("批量删除关键词成功");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        #endregion

        ////////////////////////////////////////////////////////////////////////////////////////////////////


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
                if (e.RowIndex == -1)
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
                    else
                    {
                        try
                        {
                            dgv1.Sort(dgv1.Columns[e.ColumnIndex], ListSortDirection.Descending);
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine("排序出错=========================" + ex.Message);
                        }
                    }
                }
                //如果不是首行
                else if (e.RowIndex > -1)
                {
                    string colname = dgv1.Columns[e.ColumnIndex].Name;
                    shuadan_records sr = (shuadan_records)dgv1.CurrentRow.DataBoundItem;

                    if (colname == "col_ordertype")
                    {
                        #region 修改订单类型
                        sr.sdremark6 = sr.sdremark6 == "1" ? "2" : (sr.sdremark6 == "2" ? "3" : "1");
                        BLL2.shuadan_recordsManager.Update(sr);
                        //取消选中
                        //dgv1.Columns[e.ColumnIndex].Selected = false;
                        dgv1.CurrentCell = null;
                        //DataGridView.CurrentCell = null;
                        dgv1.Refresh();
                        #endregion
                    }
                    else if (colname == "col_kongbao2")
                    {
                        #region 修改空包发货状态
                        sr.sdremark3 = sr.sdremark3 == "1" ? "2" : "1";
                        BLL2.shuadan_recordsManager.Update(sr);
                        //取消选中
                        dgv1.Columns[e.ColumnIndex].Selected = false;
                        dgv1.Refresh();
                        #endregion
                    }
                    else if (colname == "col_kongbao")
                    {
                        #region 发空包
                        tabControl1.SelectedTab = tp_pdd;
                        string temp_orderid = sr.sdorderid;
                        CS.PinDuoDuo.GoOrderInfo(sr.sdorderid, webBrowser2);
                        CS.PinDuoDuo.ClickLookPhone_PDD(webBrowser2);
                        Browser.Delay(500);
                        string address = CS.PinDuoDuo.GetOrderAddress_PDD(webBrowser2);
                        string state = Browser.JS_CEFBrowser("document.getElementsByClassName('o-d-i-c-span')[2].innerText", "document.getElementsByClassName('o-d-i-c-span')[2]", webBrowser2);
                        string datetemp = Browser.JS_CEFBrowser("document.getElementsByClassName('o-d-i-c-span')[6].innerText", "document.getElementsByClassName('o-d-i-c-span')[6]", webBrowser2);
                        if (state.IndexOf("待发货") > -1)
                        {
                            sr_temp = sr;
                            if (!string.IsNullOrEmpty(address))
                            {
                                tabControl1.SelectedTab = tp_pddkb;
                                string tempinfo = temp_orderid + "-" + address + "-" + state + System.Environment.NewLine + datetemp;
                                txt_kbinfo.Text = tempinfo;
                                kongbaowang_set(address);
                            }
                        }
                        else
                        {
                            tabControl1.SelectedTab = tp_list;
                            MessageBox.Show("订单状态异常: " + state);

                        }

                        #endregion
                    }
                    else if (colname == "col_fahuo2")
                    {
                        #region 发货
                        sr.sdremark4 = sr.sdremark4 == "1" ? "2" : "1";
                        BLL2.shuadan_recordsManager.Update(sr);
                        //取消选中
                        dgv1.Columns[e.ColumnIndex].Selected = false;
                        dgv1.Refresh();
                        #endregion
                    }
                    else if (colname == "col_pingjia")
                    {
                        #region 发货淘宝空包
                        //string wangwang = sr.sdvpn ;
                        orderinfo_temp = "";
                        KB_GetOrderInfo(sr);
                        tabControl1.SelectedTab = tabPage5;
                        KB_GoPiLiang();

                        Auto.Ctrl_V(orderinfo_temp);

                        //if (!string.IsNullOrEmpty(phone_temp))
                        //{
                        //    txt_phone.Text = phone_temp;
                        //    btn_phone_open.PerformClick();
                        //    tabControl1.SelectedTab = tp_pddbd;
                        //}
                        //取消选中
                        //dgv1.Columns[e.ColumnIndex].Selected = false;
                        //dgv1.Refresh();
                        #endregion
                    }
                    else if (colname == "col_shoucai")
                    {
                        #region 收菜
                        sr.sdremark2 = sr.sdremark2 == "1" ? "2" : (sr.sdremark2 == "2" ? "3" : "1");
                        BLL2.shuadan_recordsManager.Update(sr);
                        //取消选中
                        dgv1.Columns[e.ColumnIndex].Selected = false;
                        dgv1.Refresh();
                        #endregion
                    }
                    else if (colname == "col_orderid")
                    {
                        #region 复制订单编号
                        //Auto.Clipboard_In(sr.sdorderid);
                        #endregion
                    }
                    else if (colname == "col_phone")
                    {
                        #region 复制手机号码
                        //Auto.Clipboard_In(sr.sdphone);
                        #endregion
                    }
                    else if (colname == "col_goodsname")
                    {
                        //DataGridViewLinkColumn lc = (DataGridViewLinkColumn)sender;
                        if (!string.IsNullOrEmpty(sr.sdgoodsurl))
                        {
                            System.Diagnostics.Process.Start(sr.sdgoodsurl);
                        }
                    }

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
                        string colname = dgv1.Columns[e.ColumnIndex].Name;
                        if (colname == "col_shoptype")
                        {
                            string name = e.Value.ToString();
                            if (name == "1")
                            {
                                e.Value = "蘑菇街";
                                e.CellStyle.ForeColor = Color.Green;
                            }
                            else if (name == "2")
                            {
                                e.Value = "淘宝";
                                e.CellStyle.ForeColor = Color.Blue;
                            }
                            else if (name == "3")
                            {
                                e.Value = "拼多多";
                                e.CellStyle.ForeColor = Color.Red;
                            }
                        }
                        if (colname == "col_ordertype")
                        {
                            string name = e.Value.ToString();
                            if (name == "1")
                            {
                                e.Value = "正常单";
                                e.CellStyle.ForeColor = Color.Green;
                            }
                            else if (name == "2")
                            {
                                e.Value = "补单";
                                e.CellStyle.ForeColor = Color.Blue;
                            }
                            else if (name == "3")
                            {
                                e.Value = "问题单";
                                e.CellStyle.ForeColor = Color.Red;
                            }
                        }
                        if (colname == "col_kongbao")
                        {
                            string name = e.Value.ToString();
                            if (name == "1")
                            {
                                e.Value = "未获取";
                                e.CellStyle.ForeColor = Color.Red;
                            }
                            else
                            {
                                e.Value = "已获取";
                                e.CellStyle.ForeColor = Color.Green;
                            }
                        }

                        if (colname == "col_fahuo")
                        {
                            string name = e.Value.ToString();
                            if (name == "1")
                            {
                                e.Value = "未发货";
                                e.CellStyle.ForeColor = Color.Red;
                            }
                            else
                            {
                                e.Value = "已发货";
                                e.CellStyle.ForeColor = Color.Green;
                            }
                        }
                        if (colname == "col_kongbao2")
                        {
                            string name = e.Value.ToString();
                            if (name == "1")
                            {
                                e.Value = "未获取";
                                e.CellStyle.ForeColor = Color.Red;
                            }
                            else
                            {
                                e.Value = "已获取";
                                e.CellStyle.ForeColor = Color.Green;
                            }
                        }
                        if (colname == "col_fahuo2")
                        {
                            string name = e.Value.ToString();
                            if (name == "1")
                            {
                                e.Value = "未发货";
                                e.CellStyle.ForeColor = Color.Red;
                            }
                            else
                            {
                                e.Value = "已发货";
                                e.CellStyle.ForeColor = Color.Green;
                                //e.CellStyle.f
                            }
                        }
                        if (colname == "col_shoucai")
                        {
                            string name = e.Value.ToString();
                            if (name == "1")
                            {
                                e.Value = "未收菜";
                                e.CellStyle.ForeColor = Color.Red;
                            }
                            else if (name == "2")
                            {
                                e.Value = "已收菜";
                                e.CellStyle.ForeColor = Color.Green;
                            }
                            else
                            {
                                e.Value = "有问题";
                                e.CellStyle.ForeColor = Color.Blue;
                            }
                        }
                        if (colname == "col_pingjia")
                        {
                            string name = e.Value.ToString();
                            if (name == "1")
                            {
                                e.Value = "未收菜";
                                e.CellStyle.ForeColor = Color.Red;
                            }
                            else if (name == "2")
                            {
                                e.Value = "已收菜";
                                e.CellStyle.ForeColor = Color.Green;

                            }
                            else
                            {
                                e.Value = "有问题";
                                e.CellStyle.ForeColor = Color.Blue;
                            }


                        }
                        if (colname == "col_date")
                        {
                            //shuadan_records sr = (shuadan_records)dgv1.CurrentRow.DataBoundItem;
                            //DateTime dt_temp = new DateTime();
                            //if (DateTime.TryParse(e.Value.ToString(), out dt_temp))
                            //{
                            //    //shuadan_records sr = (shuadan_records)dgv1.CurrentRow.DataBoundItem;
                            //    e.Value
                            //}
                            //e.Value = sr.sddate.ToString("yyyy-MM-dd HH:mm:ss");
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


                if (colname.Equals("col_phone") || colname.Equals("col_orderid") || colname.Equals("col_wuliu") || colname.Equals("col_vpn") || colname.Equals("col_address") || colname.Equals("col_remark"))
                {
                    shuadan_records og = (shuadan_records)dgv1.CurrentRow.DataBoundItem;
                    if (og != null)
                    {


                        string orderid = dgv1["col_orderid", e.RowIndex].EditedFormattedValue == null ? "" : dgv1["col_orderid", e.RowIndex].EditedFormattedValue.ToString();
                        string wangwang = dgv1["col_vpn", e.RowIndex].EditedFormattedValue == null ? "" : dgv1["col_vpn", e.RowIndex].EditedFormattedValue.ToString();
                        string phone = dgv1["col_phone", e.RowIndex].EditedFormattedValue == null ? "" : dgv1["col_phone", e.RowIndex].EditedFormattedValue.ToString();
                        string wuliu = dgv1["col_wuliu", e.RowIndex].EditedFormattedValue == null ? "" : dgv1["col_wuliu", e.RowIndex].EditedFormattedValue.ToString();
                        string address = dgv1["col_address", e.RowIndex].EditedFormattedValue == null ? "" : dgv1["col_address", e.RowIndex].EditedFormattedValue.ToString();
                        string remark = dgv1["col_remark", e.RowIndex].EditedFormattedValue == null ? "" : dgv1["col_remark", e.RowIndex].EditedFormattedValue.ToString();


                        og.sdorderid = orderid;
                        og.sdvpn = wangwang;
                        og.sdaddress = address;
                        og.sdphone = phone;
                        og.sdwuliu = wuliu;
                        og.sdremark5 = remark;


                        BLL2.shuadan_recordsManager.Update(og);
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


        ////////////////////////////////////////////////////////////////////////////////////////////////////


        #region 主面板功能

        #region btn_dazhe_Click
        private void btn_dazhe_Click(object sender, EventArgs e)
        {
            if (CS.Taobao.GoChaoJiDianZhang(webBrowser1))
            {
                //进入打单发货
                string url = Browser.JS_CEFBrowser(XMLHelper_FaHuo.GetValue("url_dadanfahuo"), webBrowser1);
                webBrowser1.Load(url);


                //webBrowser1.Load("http://f.superboss.cc/ProductUsingServlet?kind=105&ftrace=0");
                //ProductUsingServlet?kind=106&ftrace=3#/trade/list/?pKuaidiStatus=0&isElec=0&status=SELLER_CONSIGNED_PART,WAIT_SELLER_SEND_GOODS&current=pKuaidiStatus&refundStatus=WAIT_SELLER_AGREE
                //ProductUsingServlet?kind=106&ftrace=3#/trade/list/?pKuaidiStatus=0&isElec=0&status=SELLER_CONSIGNED_PART,WAIT_SELLER_SEND_GOODS&current=pKuaidiStatus&refundStatus=WAIT_SELLER_AGREE
                //webBrowser1.Load("ProductUsingServlet?kind=106&ftrace=3#/trade/list/?pKuaidiStatus=0&isElec=0&status=SELLER_CONSIGNED_PART,WAIT_SELLER_SEND_GOODS&current=pKuaidiStatus&refundStatus=WAIT_SELLER_AGREE");
                //https://nfh9.superboss.cc/v8.html#/trade/list/?pKuaidiStatus=0&isElec=0&status=SELLER_CONSIGNED_PART,WAIT_SELLER_SEND_GOODS&current=pKuaidiStatus&refundStatus=WAIT_SELLER_AGREE
            }
        }

        #endregion

        #region btn_reset_Click

        private void btn_reset_Click(object sender, EventArgs e)
        {
            reset();
        }



        #endregion


        #region btn_dayin_budan_Click
        private void btn_dayin_budan_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
            //判断是否进入打单发货界面
            if (Browser.BoolByHtmlElement(XMLHelper_FaHuo.GetValue("ishas"), webBrowser1))
            {
                try
                {
                    reset();
                    //设置快递单打印状态
                    SelectKuaiDiState();
                    //设置订单发货
                    SelectOrderState();
                    //设置备注信息为：有卖家备注
                    //SelectRemarkState2();
                    string beizhu = txt_beizhu.Text.Trim(); ;
                    SetSearchRemark(beizhu);

                    Browser.Delay(500);

                    ClickSearch2();

                    SearchOver();

                    //获取查询订单后，显示的订单数量
                    int searchcount = GetGoodsCount();

                    //循环添加
                    for (int i = 0; i < searchcount; i++)
                    {
                        //开始操作
                        //shuadan_records sr = new shuadan_records();
                        //sr = CaiJiOrderInfo(sr, i);

                        //sr.sddptype = "2";
                        //sr.sddate = DateTime.Now;
                        //sr.sdremark2 = "1";
                        //sr.sdremark3 = "1";
                        ////sr.sdremark4 = "1";
                        //sr.sdremark6 = "1";
                        //sr.sdremark4 = "2";



                        //设置选中
                        SelectedOrder(i);

                        //添加信息
                        //BLL2.shuadan_recordsManager.Insert(sr);

                    }

                    MessageBox.Show("选择完成");

                    //Browser.Delay(1000);
                    //DaYin();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("一件打印补单失败 " + ex.ToString());
                }



            }
        }

        #endregion


        #region 打印韵达快递
        /// <summary>
        /// 打印韵达快递
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_dayin_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
            //判断是否进入打单发货界面
            if (Browser.BoolByHtmlElement(XMLHelper_FaHuo.GetValue("ishas"), webBrowser1))
            {
                try
                {
                    reset();
                    //设置快递单打印状态
                    SelectKuaiDiState();
                    //设置订单发货
                    SelectOrderState();
                    //设置备注信息为：无留言备注
                    SelectRemarkState();

                    Browser.Delay(500);

                    ClickSearch2();

                    SearchOver();

                    //过滤退款
                    SelectTuiKuan();



                    //获取查询订单后，显示的订单数量
                    int searchcount = GetGoodsCount();

                    //循环添加
                    for (int i = 0; i < searchcount; i++)
                    {
                        //开始操作
                        shuadan_records sr = new shuadan_records();
                        sr = CaiJiOrderInfo(sr, i);

                        sr.sddptype = "2";
                        sr.sddate = DateTime.Now;
                        sr.sdremark2 = "1";
                        sr.sdremark3 = "1";
                        sr.sdremark4 = "2";
                        sr.sdremark6 = "1";

                        //判断白沟货源
                        if (HasBaiGou(i))
                        {
                            EditOrderRemark(i, "白沟");
                        }
                        //判断特殊地区
                        else if (HasTeShuDiQu(i))
                        {
                            EditOrderRemark(i, "其他快递");
                        }
                        else
                        {
                            //sr.sdremark4 = "2";
                            //设置选中
                            SelectedOrder(i);
                        }

                        //添加信息
                        BLL2.shuadan_recordsManager.Insert(sr);

                    }

                    Browser.Delay(1000);
                    MessageBox.Show("完成");
                    //DaYin();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("打印韵达失败 " + ex.ToString());
                }



            }

        }




        #endregion

        #region 打印其他快递
        private void btn_dayin_other_Click(object sender, EventArgs e)
        {

            tabControl1.SelectedTab = tabPage1;
            //判断是否进入打单发货界面
            if (Browser.BoolByHtmlElement(XMLHelper_FaHuo.GetValue("ishas"), webBrowser1))
            {
                try
                {
                    reset();
                    //设置快递单打印状态
                    SelectKuaiDiState();
                    //设置订单发货
                    SelectOrderState();
                    //设置备注信息为：有卖家备注
                    SelectRemarkState2();

                    Browser.Delay(500);

                    ClickSearch2();

                    SearchOver();

                    SelectTuiKuan();

                    SearchOver();

                    //获取查询订单后，显示的订单数量
                    int searchcount = GetGoodsCount();

                    //循环添加
                    for (int i = 0; i < searchcount; i++)
                    {
                        //开始操作
                        shuadan_records sr = new shuadan_records();
                        sr = CaiJiOrderInfo(sr, i);

                        sr.sddptype = "2";
                        sr.sddate = DateTime.Now;
                        sr.sdremark2 = "1";
                        sr.sdremark3 = "1";
                        //sr.sdremark4 = "1";
                        sr.sdremark6 = "1";
                        sr.sdremark4 = "2";

                        //判断白沟货源
                        //if (HasBaiGou(i))
                        //{
                        //    EditOrderRemark(i, "白沟");
                        //}
                        //判断特殊地区
                        if (HasTeShuDiQu(i))
                        {
                            //设置选中
                            SelectedOrder(i);
                        }


                        //添加信息
                        BLL2.shuadan_recordsManager.Insert(sr);

                    }

                    MessageBox.Show("选择完成，请筛选");
                    //DaYin();


                }
                catch (Exception ex)
                {
                    MessageBox.Show("打印韵达失败 " + ex.ToString());
                }



            }

        }


        #endregion

        #region 一键选择白沟
        private void btn_dayin_baigou_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
            //判断是否进入打单发货界面
            if (Browser.BoolByHtmlElement(xh_taobao.GetValue("cjdz_gengxindingdan"), webBrowser1))
            {
                try
                {
                    reset();
                    //设置快递单打印状态
                    SelectKuaiDiState();
                    //设置订单发货
                    SelectOrderState();
                    //设置备注信息为：有卖家备注
                    //SelectRemarkState2();
                    SetSearchRemark("白沟");

                    Browser.Delay(500);

                    ClickSearch2();

                    SearchOver();

                    SelectTuiKuan();

                    //获取查询订单后，显示的订单数量
                    int searchcount = GetGoodsCount();

                    //循环添加
                    for (int i = 0; i < searchcount; i++)
                    {
                        //开始操作
                        shuadan_records sr = new shuadan_records();
                        sr = CaiJiOrderInfo(sr, i);

                        sr.sddptype = "2";
                        sr.sddate = DateTime.Now;
                        sr.sdremark2 = "1";
                        sr.sdremark3 = "1";
                        //sr.sdremark4 = "1";
                        sr.sdremark6 = "1";
                        sr.sdremark4 = "2";

                        //判断白沟货源
                        if (HasBaiGou(i))
                        {
                            //设置选中
                            SelectedOrder(i);
                        }



                        //添加信息
                        BLL2.shuadan_recordsManager.Insert(sr);

                    }

                    MessageBox.Show("选择完成，请筛选");

                    //Browser.Delay(1000);
                    //DaYin("圆通");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("打印韵达失败 " + ex.ToString());
                }



            }
        }




        #endregion

        #region btn_setbudan_Click
        /// <summary>
        /// 设置为补单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_setbudan_Click(object sender, EventArgs e)
        {
            int ordercount = GetGoodsCount();
            if (ordercount > 0)
            {
                string beizhu = txt_beizhu.Text.Trim();
                ClickEdit(0, beizhu);
            }

        }
        #endregion


        #region 随机获取10条收件信息
        private void btn_budan_getaddress_Click(object sender, EventArgs e)
        {
            //获取基础配置
            //获取每次获取信息的条数
            string num = XMLHelper.GetValue("FaHuo_BuDan_GetAddress_num");
            //获取信息的位置，从这里开始获取
            string indexx = XMLHelper.GetValue("FaHuo_BuDan_GetAddress_index");

            //转换数据
            int temp_num = 0;
            int.TryParse(num, out temp_num);
            int temp_indexx = 0;
            int.TryParse(indexx, out temp_indexx);

            //获取数据
            IList<shuadan_records> list = BLL2.shuadan_recordsManager.SearchToBuDan_GetAddress(temp_num, temp_indexx);

            //获取桌面地址，并添加一个文件夹
            string strDesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\收件信息\\";
            //判断是否有这个文件夹
            if (!System.IO.Directory.Exists(strDesktopPath))
            {
                //如果没有这个文件夹则创建一个
                System.IO.Directory.CreateDirectory(strDesktopPath);

            }
            //设置文件的名称和绝对路径
            string files = strDesktopPath + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";

            //写入ansi 格式的文件

            //创建一个StreamWriter，用于在文件里写内容
            StreamWriter sw;
            //判断这个文件是否存在
            if (File.Exists(files))
            {
                //FileStream，用于读取文件中的内容
                FileStream fs = new FileStream(files, FileMode.Append);
                sw = new StreamWriter(fs, System.Text.Encoding.Default);
            }
            else
            {
                sw = new StreamWriter(files, false, System.Text.Encoding.Default);
            }



            ////创建一个StreamWriter，用于在文件里写内容
            //System.IO.StreamWriter sw;
            ////判断这个文件是否存在
            //if (System.IO.File.Exists(files))
            //{
            //    //如果存在则继续写
            //    sw = System.IO.File.AppendText(files);
            //}
            //else
            //{
            //    //如果不存在则创建这个文件
            //    sw = System.IO.File.CreateText(files);
            //}

            //处理数据
            //便利list获取地址信息
            foreach (shuadan_records sr in list)
            {
                string address = sr.sdaddress;
                //取消共有字符串
                address = address.Replace("联系方式：", "");
                //中英文逗号转换
                address = address.Replace("，", ",");
                //去掉最后的邮编
                address = address.Substring(0, address.LastIndexOf(","));
                //逗号转换成空格
                address = address.Replace(",", " ");
                //问号转换成空格
                address = address.Replace("？", " ");
                address = address.Replace("?", " ");
                //取消首尾空格
                address = address.Trim();
                //添加必要格式：尾部加(000000)
                //address = address + "(000000)";

                //写入地址信息
                sw.WriteLine(address);

            }
            //关掉StreamWriter
            sw.Close();

            //设置下次的起始位置
            temp_indexx = temp_num + temp_indexx;
            XMLHelper.SetValue("FaHuo_BuDan_GetAddress_index", temp_indexx.ToString());

            MessageBox.Show("数据获取完毕");
            System.Diagnostics.Process.Start(strDesktopPath);

        }
        #endregion

        #endregion

        #region 添加补单记录

        private void btn_pdd_reset_Click(object sender, EventArgs e)
        {
            txt_pdd_list.Text = "";
        }

        private void btn_pdd_count_Click(object sender, EventArgs e)
        {
            string temp = txt_pdd_list.Text;
            if (string.IsNullOrEmpty(temp))
            {
                MessageBox.Show("请输入要添加的订单编号");
                return;
            }


            MessageBox.Show("共 " + Manager.StrToList(temp).Count.ToString() + " 条记录");
        }

        private void btn_pdd_add_Click(object sender, EventArgs e)
        {
            string temp = txt_pdd_list.Text;
            if (string.IsNullOrEmpty(temp))
            {
                MessageBox.Show("请输入要添加的订单编号");
                return;
            }
            List<string> list = Manager.StrToList(temp);
            if (list.Count == 0)
            {
                MessageBox.Show("请输入要添加的订单编号");
                return;
            }
            dianpu dp = GetDianPu();
            if (dp == null)
            {
                MessageBox.Show("请选择补单的店铺");
                return;
            }

            int doubleorder = 0;


            foreach (string str in list)
            {
                //拼多多的
                if (string.IsNullOrEmpty(str))
                    break;
                shuadan_records sr = new shuadan_records();
                sr.sddptype = "3";
                sr.sddate = DateTime.Now;
                sr.sdorderid = str;
                //sr.sdvpn = str;
                sr.sdremark2 = "1";
                sr.sdremark3 = "1";
                sr.sdremark4 = "1";
                sr.sdremark5 = dp.dpname;
                sr.sdremark6 = "2";

                /* 淘宝的
                 if (string.IsNullOrEmpty(str))
                    break;
                shuadan_records sr = new shuadan_records();
                sr.sddptype = "3";
                sr.sddate = DateTime.Now;
                //sr.sdorderid = str;
                sr.sdvpn = str;
                sr.sdremark2 = "1";
                sr.sdremark3 = "1";
                sr.sdremark4 = "1";
                sr.sdremark5 = dp.dpname;
                sr.sdremark6 = "2";
                 */

                //判断是否已经做过单
                if (BLL2.shuadan_recordsManager.SearchNum(str, "", "", "", "", new DateTime(), new DateTime()) > 0)
                {
                    sr.sdremark5 += " 该账户多次下单";
                    doubleorder++;
                }



                BLL2.shuadan_recordsManager.Insert(sr);
            }
            if (doubleorder > 0)
            {
                MessageBox.Show("共 " + doubleorder.ToString() + " 个账号多次下单，请留意");
            }
            MessageBox.Show("成功添加共 " + list.Count.ToString() + " 条记录");
        }


        #endregion



        #region 补单列表


        #region btn_weifahuo_taobao_Click
        private void btn_weifahuo_taobao_Click(object sender, EventArgs e)
        {
            dgv1.DataSource = BLL2.shuadan_recordsManager.SearchWeiFaHuo("2");
        }
        #endregion

        #region btn_weifahuo_pinduoduo_Click
        private void btn_weifahuo_pinduoduo_Click(object sender, EventArgs e)
        {
            dgv1.DataSource = BLL2.shuadan_recordsManager.SearchWeiFaHuo("3");
        }

        #endregion


        #region 记货功能
        private void btn_fahuo_Click(object sender, EventArgs e)
        {

            DateTime temp_date2 = new DateTime();
            if (dateTimePicker1.Text != "请选择")
            {
                temp_date2 = dateTimePicker1.Value;
            }
            else
            {
                //MessageBox.Show("请选择记货日期");
                temp_date2 = DateTime.Now;
            }


            List<shuadan_records> list = (List<shuadan_records>)BLL2.shuadan_recordsManager.Search(1, 1000, "", "", "1", "", "", "", temp_date2, temp_date2, "");
            dgv1.DataSource = list;

            List<order> list_order = new List<order>();
            //List<string> list_sku2 = new List<string>();
            //先模拟添加一个，用于遍历
            //order temp = new order();
            //temp.Name = "测试，用于遍历";
            //temp.Num = 1;
            //list_order.Add(temp);

            try
            {
                //开始记货
                //遍历所有订单
                foreach (shuadan_records sr in list)
                {

                    try
                    {
                        string temp_sku = sr.sdremark1.Replace("颜色分类:", "");
                        temp_sku = temp_sku.Replace("XR", "");
                        temp_sku = temp_sku.Replace("MF", "");
                        temp_sku = temp_sku.Replace("大号", "");
                        temp_sku = temp_sku.Replace("大版", "");
                        string[] temporder = Manager.Str_Split(temp_sku, ",");
                        //获取商品编号和颜色名称
                        string temporder_name = temporder[0];
                        temporder_name = Manager.Str_Split(temporder_name, "【")[0];
                        //获取商品数量
                        string temporder_countstr = temporder[1];
                        int temporder_count = 0;
                        int.TryParse(temporder_countstr, out temporder_count);

                        order temp = new order();
                        temp.Name = temporder_name;
                        temp.Num = temporder_count;

                        //如果商品名称为空，则直接添加原信息
                        if (string.IsNullOrEmpty(temporder_name))
                        {
                            temp.Name = sr.sdremark1;
                            list_order.Add(temp);
                            continue;
                        }

                        //如果是第一次遍历，则直接添加
                        if (list_order.Count == 0)
                        {
                            list_order.Add(temp);
                            continue;
                            //break;
                        }
                        //是否找到
                        bool isnofind = true;

                        for (int i = 0; i < list_order.Count; i++)
                        {
                            //找到了
                            if (list_order[i].Name.Trim() == temporder_name.Trim())
                            {
                                isnofind = false;
                                list_order[i].Num = list_order[i].Num + temporder_count;
                            }
                        }
                        if (isnofind)
                        {
                            list_order.Add(temp);
                        }

                    }
                    catch { }

                }
            }
            catch { }
            //排序
            //list_order.Sort();

            list_order.Sort(delegate (order p1, order p2) { return p1.Name.CompareTo(p2.Name); });


            int zongnum = 0;

            //内容
            string content = "";
            foreach (order ord in list_order)
            {
                content += ord.Name + " : " + ord.Num.ToString() + "</br>";
                zongnum += ord.Num;
            }
            content += "总计商品：" + list_order.Count.ToString() + "种；共" + zongnum.ToString() + "件";

            foreach (string emails in list_email)
            {
                //发送寄货信息
                //BLL.SendEmail.send2("181193051@qq.com", DateTime.Now.ToString("yyyy-MM-dd HHmmss") + "记货", content);
                BLL.SendEmail.send2(emails, temp_date2.ToString("yyyy-MM-dd HHmmss") + "记货单", content);
            }



            #region 发货功能 备注2018年7月3日 23:16:38


            /*
            if (MessageBox.Show("是否要批量发货选中数据?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                tabControl1.SelectedTab = tabPage1;
                //判断是否进入打单发货界面
                if (Browser.BoolByHtmlElement(xh_taobao.GetValue("cjdz_gengxindingdan"), webBrowser1))
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
                                    //开始操作
                                    shuadan_records sr = (shuadan_records)row.DataBoundItem;
                                    //设置昵称
                                    Browser.JS_CEFBrowser_NoReturn("document.getElementsByName('buyerNick')[0].value='" + sr.sdvpn + "'", webBrowser1);
                                    Browser.Delay(500);
                                    //点击查询
                                    Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('serach2-btn')[0].click()", webBrowser1);
                                    Browser.Delay(1000);
                                    //获取查询订单后，显示的订单数量
                                    int searchcount = Browser.JS_CEFBrowserToInt("document.getElementsByClassName('order-info').length", webBrowser1);
                                    //如果没有找到，或者订单大于1则提示，并停止
                                    if (searchcount == 0 || searchcount > 1)
                                    {
                                        sr.sdremark5 += " 没有找到或者订单较多，请留意";
                                        sr.sdremark2 = "3";//设置收菜有问题
                                        BLL2.shuadan_recordsManager.Update(sr);
                                        MessageBox.Show("没有找到或者订单较多，请留意");
                                        return;
                                    }
                                    //获取昵称
                                    string nicheng = Browser.JS_CEFBrowser("document.getElementsByClassName('order-info')[0].getElementsByTagName('a')[0].innerText", webBrowser1);
                                    if (nicheng != sr.sdvpn)
                                    {
                                        sr.sdremark5 += " 昵称错误，请查看";
                                        sr.sdremark2 = "3";//设置收菜有问题
                                        BLL2.shuadan_recordsManager.Update(sr);
                                        MessageBox.Show("昵称错误，请查看");
                                        return;
                                    }
                                    //获取发货状态 :"未发货";韵达 3952259529459[单号回收]
                                    string fahuostate = Browser.JS_CEFBrowser("document.getElementsByClassName('fahuo-status')[0].innerText", webBrowser1);
                                    //判断是否发货
                                    if (fahuostate.IndexOf("单号回收") != -1)
                                    {
                                        sr.sdremark5 += " 该订单已发货，请留意";
                                        sr.sdremark2 = "3";//设置收菜有问题
                                        BLL2.shuadan_recordsManager.Update(sr);
                                        MessageBox.Show(" 该订单已发货，请留意");
                                        return;
                                    }

                                    //点击选中
                                    Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('order-info')[0].getElementsByClassName('rc-checked')[0].click()", webBrowser1);
                                    Browser.Delay(500);


                                    //点击打印快递单
                                    Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('btn-danger')[0].click()", webBrowser1);
                                    Browser.Delay(500);

                                    //点击电子面单（新）
                                    Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('ui-tab-change')[2].click()", webBrowser1);
                                    Browser.Delay(500);

                                    //设置option选中 选择快递
                                    //document.getElementsByName('cloudWlbSlt')[0].getElementsByTagName('option')[2].selected=true
                                    int optionindex = Browser.OptionSearchIndex("document.getElementsByName('cloudWlbSlt')[0].getElementsByTagName('option')", 10, "韵达", webBrowser1);
                                    Browser.JS_CEFBrowser_NoReturn("ocument.getElementsByName('cloudWlbSlt')[0].getElementsByTagName('option')[" + optionindex.ToString() + "].selected=true", webBrowser1);
                                    Browser.Delay(500);

                                    //设置option选中 选择打印机
                                    //document.getElementsByName('cloudWlbSlt')[0].getElementsByTagName('option')[2].selected=true
                                    optionindex = Browser.OptionSearchIndex("document.getElementsByName('printerCloudWlb')[0].getElementsByTagName('option')", 10, "118", webBrowser1);
                                    Browser.JS_CEFBrowser_NoReturn("ocument.getElementsByName('printerCloudWlb')[0].getElementsByTagName('option')[" + optionindex.ToString() + "].selected=true", webBrowser1);
                                    Browser.Delay(500);

                                    //点击打印
                                    Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('preventdbclick')[1].click()", webBrowser1);
                                }
                            }
                        }

                        dgv1.Refresh();
                        MessageBox.Show("批量发货成功");

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("请先登录超级店长并打开打单发货页面");

                }
            }*/

            #endregion
        }
        #endregion




        #region btn_shezhifahuo_Click
        private void btn_shezhifahuo_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否要批量发货选中数据?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
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
                                shuadan_records sr = (shuadan_records)row.DataBoundItem;
                                sr.sdremark4 = "2";
                                BLL2.shuadan_recordsManager.Update(sr);
                            }
                        }
                    }

                    dgv1.Refresh();
                    MessageBox.Show("批量发货成功");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        #endregion

        #region 批量备注功能
        private void btn_beizhu_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("是否要批量备注选中数据?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                tabControl1.SelectedTab = tabPage1;

                string beizhutxt = txt_beizhu.Text.Trim();
                if (string.IsNullOrEmpty(beizhutxt))
                {
                    MessageBox.Show("请输入备注信息");
                    return;
                }

                //判断是否进入打单发货界面
                if (Browser.BoolByHtmlElement(XMLHelper_FaHuo.GetValue("ishas"), webBrowser1))
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

                                    reset();

                                    //开始操作
                                    shuadan_records sr = (shuadan_records)row.DataBoundItem;
                                    //设置昵称
                                    SetBuyer(sr.sdvpn);
                                    Browser.Delay(500);
                                    //点击查询
                                    ClickSearch();

                                    Browser.Delay(1000);

                                    //等待搜索结束
                                    SearchOver();

                                    //获取查询订单后，显示的订单数量
                                    int searchcount = GetGoodsCount();
                                    //取消选中
                                    cbx.Value = false;

                                    //如果没有找到，或者订单大于1则提示，并停止
                                    if (searchcount == 0 || searchcount > 1)
                                    {
                                        sr.sdremark5 += " 没有找到或者订单较多，请留意";
                                        sr.sdremark6 = "3";//设置收菜有问题
                                        BLL2.shuadan_recordsManager.Update(sr);
                                        MessageBox.Show("没有找到或者订单较多，请留意");
                                        return;
                                    }

                                    //采集订单信息
                                    sr = CaiJiOrderInfo(sr, 0);

                                    //获取发货状态 :"未发货";韵达 3952259529459[单号回收]
                                    string fahuostate = GetSendState(0);
                                    //判断是否发货
                                    if (!string.IsNullOrEmpty(fahuostate))
                                    {
                                        sr.sdremark5 += " 该订单已发货，请留意";
                                        sr.sdremark6 = "3";//设置收菜有问题
                                        BLL2.shuadan_recordsManager.Update(sr);
                                        MessageBox.Show(" 该订单已发货，请留意");
                                        return;
                                    }







                                    //获取昵称
                                    //string nicheng = GetBuyer(0);
                                    //if (nicheng.Trim() != sr.sdvpn.Trim())
                                    //{
                                    //    sr.sdremark5 += " 昵称错误，请查看";
                                    //    sr.sdremark6 = "3";//设置收菜有问题
                                    //    BLL2.shuadan_recordsManager.Update(sr);
                                    //    MessageBox.Show("昵称错误，请查看");
                                    //    return;
                                    //}


                                    //编辑备注
                                    EditOrderRemark(beizhutxt);



                                    //判断白沟货源
                                    //string goodsinfo = GetGoodsInfo(0);
                                    if (HasBaiGou(0))
                                    {
                                        sr.sdremark5 += " 白沟货源，请留意";
                                        sr.sdremark6 = "3";//设置收菜有问题
                                        BLL2.shuadan_recordsManager.Update(sr);
                                        MessageBox.Show(" 白沟货源，请留意");
                                        return;
                                    }
                                    //判断特殊地区
                                    if (HasTeShuDiQu(sr.sdaddress))
                                    {
                                        sr.sdremark5 += " 特殊地区，请留意";
                                        sr.sdremark6 = "3";//设置收菜有问题
                                        BLL2.shuadan_recordsManager.Update(sr);
                                        MessageBox.Show(" 特殊地区，请留意");
                                        return;
                                    }

                                    Browser.Delay(500);

                                    string res = GetRemark(1);
                                    if (res.IndexOf(beizhutxt) > -1)
                                    {

                                        sr.sdremark5 += " 批量备注成功";
                                        BLL2.shuadan_recordsManager.Update(sr);

                                    }
                                    else
                                    {

                                        sr.sdremark5 += " 批量备注失败";
                                        sr.sdremark6 = "3";//设置收菜有问题
                                        BLL2.shuadan_recordsManager.Update(sr);
                                        //MessageBox.Show(" 批量备注失败，请留意");
                                        //return;

                                    }

                                }
                            }
                        }

                        dgv1.Refresh();
                        MessageBox.Show("批量发货成功");

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("请先登录超级店长并打开打单发货页面");

                }
            }
        }
        #endregion


        #region 采集淘宝信息，已经没有用



        private void btn_caijitaobaoinof_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否要批量备注选中数据?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                tabControl1.SelectedTab = tabPage1;

                string beizhutxt = txt_beizhu.Text.Trim();
                if (string.IsNullOrEmpty(beizhutxt))
                {
                    MessageBox.Show("请输入备注信息");
                    return;
                }

                //判断是否进入打单发货界面
                if (Browser.BoolByHtmlElement(XMLHelper_FaHuo.GetValue("ishas"), webBrowser1))
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

                                    reset();

                                    //开始操作
                                    shuadan_records sr = (shuadan_records)row.DataBoundItem;
                                    //设置昵称
                                    SetBuyer(sr.sdvpn);
                                    Browser.Delay(500);
                                    //点击查询
                                    ClickSearch();



                                    //等待搜索结束
                                    SearchOver();

                                    //获取查询订单后，显示的订单数量
                                    int searchcount = GetGoodsCount();
                                    //取消选中
                                    cbx.Value = false;

                                    //如果没有找到，或者订单大于1则提示，并停止
                                    if (searchcount == 0 || searchcount > 1)
                                    {
                                        sr.sdremark5 += " 没有找到或者订单较多，请留意";
                                        sr.sdremark6 = "3";//设置收菜有问题
                                        BLL2.shuadan_recordsManager.Update(sr);
                                        MessageBox.Show("没有找到或者订单较多，请留意");
                                        return;
                                    }

                                    //采集订单信息
                                    sr = CaiJiOrderInfo(sr, 0);

                                    //获取发货状态 :"未发货";韵达 3952259529459[单号回收]
                                    string fahuostate = GetSendState(0);
                                    //判断是否发货
                                    if (fahuostate.IndexOf("单号回收") != -1)
                                    {
                                        sr.sdremark5 += " 该订单已发货，请留意";
                                        sr.sdremark6 = "3";//设置收菜有问题
                                        BLL2.shuadan_recordsManager.Update(sr);
                                        MessageBox.Show(" 该订单已发货，请留意");
                                        return;
                                    }







                                    //获取昵称
                                    //string nicheng = GetBuyer(0);
                                    //if (nicheng.Trim() != sr.sdvpn.Trim())
                                    //{
                                    //    sr.sdremark5 += " 昵称错误，请查看";
                                    //    sr.sdremark6 = "3";//设置收菜有问题
                                    //    BLL2.shuadan_recordsManager.Update(sr);
                                    //    MessageBox.Show("昵称错误，请查看");
                                    //    return;
                                    //}


                                    //编辑备注
                                    EditOrderRemark(beizhutxt);



                                    //判断白沟货源
                                    //string goodsinfo = GetGoodsInfo(0);
                                    if (HasBaiGou(0))
                                    {
                                        sr.sdremark5 += " 白沟货源，请留意";
                                        sr.sdremark6 = "3";//设置收菜有问题
                                        BLL2.shuadan_recordsManager.Update(sr);
                                        MessageBox.Show(" 白沟货源，请留意");
                                        return;
                                    }
                                    //判断特殊地区
                                    if (HasTeShuDiQu(sr.sdaddress))
                                    {
                                        sr.sdremark5 += " 特殊地区，请留意";
                                        sr.sdremark6 = "3";//设置收菜有问题
                                        BLL2.shuadan_recordsManager.Update(sr);
                                        MessageBox.Show(" 特殊地区，请留意");
                                        return;
                                    }

                                    Browser.Delay(500);

                                    string res = GetRemark(1);
                                    if (res.IndexOf(beizhutxt) > -1)
                                    {

                                        sr.sdremark5 += " 批量备注成功";
                                        BLL2.shuadan_recordsManager.Update(sr);

                                    }
                                    else
                                    {

                                        sr.sdremark5 += " 批量备注失败";
                                        sr.sdremark6 = "3";//设置收菜有问题
                                        BLL2.shuadan_recordsManager.Update(sr);
                                        //MessageBox.Show(" 批量备注失败，请留意");
                                        //return;

                                    }

                                }
                            }
                        }

                        dgv1.Refresh();
                        MessageBox.Show("批量发货成功");

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("请先登录超级店长并打开打单发货页面");

                }
            }
        }


        #endregion

        #endregion

        #region 网页处理功能



        /// <summary>
        /// 获取收件信息地址
        /// </summary>
        /// <param name="indexx"></param>
        /// <returns></returns>
        string GetAddress(int indexx)
        {
            string js = XMLHelper_FaHuo.GetValue("GetAddress");
            js = js.Replace("parameter", indexx.ToString());
            string res = Browser.JS_CEFBrowser(js, webBrowser1);
            res = res.Replace("[编辑]", "");
            res = res.Replace("联系方式：", "");
            res = res.Substring(0, res.LastIndexOf("，"));
            return res;
        }

        /// <summary>
        /// 获取订单编号
        /// </summary>
        /// <param name="indexx"></param>
        /// <returns></returns>
        string GetOrderCode(int indexx)
        {

            string js = XMLHelper_FaHuo.GetValue("GetOrderCode");
            js = js.Replace("parameter", indexx.ToString());
            string res = Browser.JS_CEFBrowser(js, webBrowser1);
            res = res.Replace("订单编号：", "");
            return res;

        }

        /// <summary>
        /// 获取手机号码
        /// </summary>
        /// <param name="indexx"></param>
        /// <returns></returns>
        string GetPhone(int indexx)
        {
            string info_temp = GetAddress(indexx);
            string phone = Manager.Str_Split(info_temp, "，")[1];
            return phone;
        }

        /// <summary>
        /// 获取商品网址
        /// </summary>
        /// <param name="indexx"></param>
        /// <returns></returns>
        string GetGoodsName(int indexx)
        {
            string js = XMLHelper_FaHuo.GetValue("GetGoodsName");
            js = js.Replace("parameter", indexx.ToString());
            return Browser.JS_CEFBrowser(js, webBrowser1);
        }

        /// <summary>
        /// 获取商品网址
        /// </summary>
        /// <param name="indexx"></param>
        /// <returns></returns>
        string GetGoodsUrl(int indexx)
        {
            string js = XMLHelper_FaHuo.GetValue("GetGoodsUrl");
            js = js.Replace("parameter", indexx.ToString());
            return Browser.JS_CEFBrowser(js, webBrowser1);
        }

        /// <summary>
        /// 设置搜索-昵称
        /// </summary>
        /// <param name="str"></param>
        void SetBuyer(string str)
        {
            tabControl1.SelectedTab = tabPage1;
            webBrowser1.Focus();
            reset();
            Browser.Delay(1000);
            Browser.MouseLeftByHtmlElement(XMLHelper_FaHuo.GetValue("SetBuyer2"), 5, 5, webBrowser1);
            Browser.MouseLeftByHtmlElement(XMLHelper_FaHuo.GetValue("SetBuyer2"), 5, 5, webBrowser1);
            Auto.Ctrl_V(str);

            //js_fahuo_noreturn("ClickSearchHeightShow");
            //js_fahuo_noreturn("SetBuyer", str);
            //string js = XMLHelper_FaHuo.GetValue("SetBuyer");
            //js = js.Replace("parameter", str);
            //Browser.JS_CEFBrowser_NoReturn(js, webBrowser1);
        }

        /// <summary>
        /// 点击查询
        /// </summary>
        void ClickSearch()
        {
            string js = XMLHelper_FaHuo.GetValue("ClickSearch");
            Browser.JS_CEFBrowser_NoReturn(js, webBrowser1);
        }

        /// <summary>
        /// 点击高级查询2
        /// </summary>
        void ClickSearch2()
        {
            string js = xml_js.GetValue("cjdz_clicksearch2");
            Browser.JS_CEFBrowser_NoReturn(js, webBrowser1);
        }

        /// <summary>
        /// 获取订单数量
        /// </summary>
        /// <returns></returns>
        int GetGoodsCount()
        {
            string js = xml_js.GetValue("GetGoodsCount");
            return Browser.JS_CEFBrowserToInt(js, webBrowser1);
        }

        /// <summary>
        /// 获取显示结果
        /// </summary>
        /// <returns></returns>
        string GetSearchRes()
        {
            string js = xml_js.GetValue("GetSearchRes");
            return Browser.JS_CEFBrowser(js, webBrowser1);
        }

        /// <summary>
        /// 获取昵称
        /// </summary>
        /// <param name="indexx"></param>
        /// <returns></returns>
        string GetBuyer(int indexx)
        {
            string js = XMLHelper_FaHuo.GetValue("GetBuyer");
            js = js.Replace("parameter", indexx.ToString());
            return Browser.JS_CEFBrowser(js, webBrowser1);
        }

        /// <summary>
        /// 获取发货状态
        /// </summary>
        /// <param name="indexx"></param>
        /// <returns></returns>
        string GetSendState(int indexx)
        {
            string js = XMLHelper_FaHuo.GetValue("GetSendState");
            js = js.Replace("parameter", indexx.ToString());
            return Browser.JS_CEFBrowser(js, webBrowser1);
        }

        /// <summary>
        /// 点击编辑按钮
        /// </summary>
        //void ClickEdit()
        //{
        //    Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('fc-blue')[2].click()", webBrowser1);
        //}
        /// <summary>
        /// 点击编辑按钮，可设置编辑第几个
        /// </summary>
        /// <param name="indexx"></param>
        void ClickEdit(int indexx)
        {
            string js = XMLHelper_FaHuo.GetValue("ClickEdit");
            js = js.Replace("parameter", indexx.ToString());
            Browser.JS_CEFBrowser_NoReturn(js, webBrowser1);
            //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('order-item')[" + indexx.ToString() + "].getElementsByClassName('fc-blue')[2].click()", webBrowser1);

        }

        /// <summary>
        /// 编辑备注
        /// </summary>
        /// <param name="str"></param>
        void ClickEdit(int indexx, string str)
        {
            ClickEdit(indexx);
            SetEditRemark(str);
            ClickEditOk();
        }


        #region 发货通用js方法==========================
        /// <summary>
        /// 通用js 方法，获取str
        /// </summary>
        /// <param name="jsname">js方法名称</param>
        /// <returns></returns>
        string js_fahuo(string jsname)
        {
            string js = XMLHelper_FaHuo.GetValue(jsname);
            return Browser.JS_CEFBrowser(js, webBrowser1);
        }
        /// <summary>
        /// 通用js 方法，获取str
        /// </summary>
        /// <param name="jsname">js方法名称</param>
        /// <param name="parameter">参数</param>
        /// <returns></returns>
        string js_fahuo(string jsname, string parameter)
        {
            string js = xml_js.GetValue(jsname);
            js = js.Replace("parameter", parameter);
            return Browser.JS_CEFBrowser(js, webBrowser1);
        }
        /// <summary>
        /// 通用js方法，不返回信息
        /// </summary>
        /// <param name="jsname">js方法名称</param>
        void js_fahuo_noreturn(string jsname)
        {
            string js = xml_js.GetValue(jsname);
            Browser.JS_CEFBrowser_NoReturn(js, webBrowser1);
        }
        /// <summary>
        /// 通用js方法，不返回信息
        /// </summary>
        /// <param name="jsname">js方法名称</</param>
        /// <param name="parameter">参数</param>
        void js_fahuo_noreturn(string jsname, string parameter)
        {
            string js = xml_js.GetValue(jsname);
            js = js.Replace("parameter", parameter);
            Browser.JS_CEFBrowser_NoReturn(js, webBrowser1);
        }
        #endregion

        /// <summary>
        /// 设置备注
        /// </summary>
        /// <param name="str"></param>
        void SetEditRemark(string str)
        {
            //string remark = Browser.JS_CEFBrowser("document.getElementsByName('sellerMemo')[0].value", webBrowser1);
            //Browser.JS_CEFBrowser_NoReturn("document.getElementsByName('sellerMemo')[0].value='" + remark + ";" + str + "'", webBrowser1);
            string remark = js_fahuo("GetEditRemark");
            remark = remark + ";" + str;
            //js_fahuo_noreturn("SetEditRemark", remark);
            Browser.MouseLeftByHtmlElement(XMLHelper_FaHuo.GetValue("SetEditRemark"), 5, 5, webBrowser1);
            Browser.MouseLeftByHtmlElement(XMLHelper_FaHuo.GetValue("SetEditRemark"), 5, 5, webBrowser1);
            Auto.Ctrl_V(remark);
        }

        /// <summary>
        /// 点击编辑框的确定按钮
        /// </summary>
        void ClickEditOk()
        {
            js_fahuo_noreturn("ClickEditOk");
            //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('J_save')[0].click()", webBrowser1);
        }

        /// <summary>
        /// 获取备注信息
        /// </summary>
        /// <param name="indexx"></param>
        /// <returns></returns>
        //string GetRemark(int indexx)
        //{
        //    return Browser.JS_CEFBrowser("document.getElementsByClassName('trade-font')[" + indexx.ToString() + "].innerText", webBrowser1);
        //}

        /// <summary>
        /// 获取宝贝信息
        /// </summary>
        /// <param name="indexx"></param>
        /// <returns></returns>
        string GetGoodsInfo(int indexx)
        {
            return js_fahuo("GetGoodsInfo", indexx.ToString());
            //return Browser.JS_CEFBrowser("document.getElementsByClassName('order-item')[" + indexx.ToString() + "].getElementsByClassName('ui-table')[0].innerText", webBrowser1);
            //return Browser.JS_CEFBrowser("document.getElementsByName('orders')[" + indexx.ToString() + "].innerText", webBrowser1);
        }

        /// <summary>
        /// 获取商品颜色分类
        /// </summary>
        /// <param name="indexx"></param>
        /// <returns></returns>
        string GetGoodsSKU(int indexx)
        {
            return js_fahuo("GetGoodsSKU", indexx.ToString());
            //return Browser.JS_CEFBrowser("document.getElementsByClassName('order-item')['" + indexx.ToString() + "'].getElementsByClassName('ui-table')[0].getElementsByTagName('td')[2].innerText", webBrowser1);
        }

        /// <summary>
        /// 获取商品数量
        /// </summary>
        /// <param name="indexx"></param>
        /// <returns></returns>
        string GetGoodsNum(int indexx)
        {
            return js_fahuo("GetGoodsNum", indexx.ToString());
            //return Browser.JS_CEFBrowser("document.getElementsByClassName('order-item')['" + indexx.ToString() + "'].getElementsByClassName('ui-table')[0].getElementsByTagName('td')[4].innerText", webBrowser1);
        }


        /// <summary>
        /// 判断订单信息是否包括白沟货源
        /// </summary>
        /// <param name="indexx"></param>
        /// <returns></returns>
        bool HasBaiGou(int indexx)
        {
            bool res = false;
            string goodsinfo = GetGoodsInfo(indexx);
            foreach (string str in list_baigou)
            {
                //如果商品信息里包括白沟的订单编号
                if (goodsinfo.IndexOf(str) > -1)
                {
                    return true;
                }
            }
            return res;
        }


        /// <summary>
        /// 判断订单信息是否包括特殊地区
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        bool HasTeShuDiQu(string address)
        {
            bool res = false;
            foreach (string str in list_diqu)
            {
                //如果商品信息里包括特殊地区
                if (address.IndexOf(str) > -1)
                {
                    return true;
                }
            }
            return res;
        }
        /// <summary>
        /// 判断订单信息是否包括特殊地区
        /// </summary>
        /// <param name="indexx"></param>
        /// <returns></returns>
        bool HasTeShuDiQu(int indexx)
        {
            bool res = false;
            string address = GetAddress(indexx);
            foreach (string str in list_diqu)
            {
                //如果商品信息里包括特殊地区
                if (address.IndexOf(str) > -1)
                {
                    return true;
                }
            }
            return res;
        }


        /// <summary>
        /// 等待查询结束
        /// </summary>
        void SearchOver()
        {

            //判断是否查询结束
            while (true)
            {
                Browser.Delay(300);//系统延迟50毫秒，够少了吧！
                int searchcount = GetGoodsCount();
                //找到订单了
                if (searchcount > 0)
                {
                    break;
                }
                //获取显示结果
                string temp = GetSearchRes();
                //如果查询结果显示没有订单
                if (temp.IndexOf("没有查询到订单信息") > -1)
                {
                    break;
                }

            }

        }

        /// <summary>
        /// 采集订单信息
        /// </summary>
        /// <param name="sr">实例</param>
        /// <param name="indexx"></param>
        /// <returns></returns>
        shuadan_records CaiJiOrderInfo(shuadan_records sr, int indexx)
        {
            //采集信息
            string address = GetAddress(indexx);
            string phonecode = GetPhone(indexx);
            string goodsname = GetGoodsName(indexx);
            string goodsurl = GetGoodsUrl(indexx);
            string ordercode = GetOrderCode(indexx);
            string wangwang = GetBuyer(indexx);
            string sku = GetGoodsSKU(indexx);
            string num = GetGoodsNum(indexx);

            sr.sdaddress = address;
            sr.sdphone = phonecode;
            sr.sdgoodsname = goodsname;
            sr.sdgoodsurl = goodsurl;
            sr.sdorderid = ordercode;
            sr.sdvpn = wangwang;
            sr.sdremark1 = sku + "," + num;



            return sr;
        }

        /// <summary>
        /// 获取备注信息
        /// </summary>
        /// <param name="indexx">获取index</param>
        string GetRemark(int indexx)
        {
            //可以考虑获取三次  买家留言 卖家备注 系统备注
            return js_fahuo("GetRemark", indexx.ToString());
            //return Browser.JS_CEFBrowser("document.getElementsByName('sellerMemoTr')[" + indexx.ToString() + "].innerText", webBrowser1);
        }

        /// <summary>
        /// 编辑第一个备注
        /// </summary>
        /// <param name="str">备注内容</param>
        void EditOrderRemark(string str)
        {

            EditOrderRemark(0, str);
        }

        /// <summary>
        /// 编辑备注
        /// </summary>
        /// <param name="indexx">第几个备注</param>
        /// <param name="str">备注内容</param>
        void EditOrderRemark(int indexx, string str)
        {

            //获取卖家备注
            string rem = GetRemark(indexx);
            //如果已经备注则跳出
            if (rem.IndexOf(str) != -1)
            {
                return;
            }

            //点击编辑按钮
            ClickEdit(indexx);
            Browser.Delay(500);
            //设置备注内容
            SetEditRemark(str);
            Browser.Delay(200);
            //确定
            ClickEditOk();
            Browser.Delay(1000);

            //关闭窗口
            ClickCloseRemark();
        }

        /// <summary>
        /// 点击关闭备注窗口
        /// </summary>
        void ClickCloseRemark()
        {
            js_fahuo_noreturn("ClickCloseRemark");
            js_fahuo_noreturn("ClickCloseRemark");
            //int temp_index = Browser.JS_CEFBrowserToInt("document.getElementsByClassName( 'next-icon-close').length", webBrowser1);

            //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('ui_close')[0].click()", webBrowser1);
        }

        /// <summary>
        /// 选中订单
        /// </summary>
        /// <param name="indexx"></param>
        void SelectedOrder(int indexx)
        {
            js_fahuo_noreturn("SelectedOrder", indexx.ToString());
            //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('order-item')[" + indexx.ToString() + "].getElementsByClassName('rc-checked')[0].checked=true;", webBrowser1);
            Browser.Delay(200);
        }

        /// <summary>
        /// 是否选中了订单
        /// </summary>
        /// <param name="indexx"></param>
        bool IsSelectedOrder(int indexx)
        {
            bool res = false;
            string temp = js_fahuo("IsSelectedOrder", indexx.ToString());
            //string temp = Browser.JS_CEFBrowser("document.getElementsByClassName('order-item')[" + indexx.ToString() + "].getElementsByClassName('rc-checked')[0].checked;", webBrowser1);
            if (temp.ToUpper().IndexOf("TRUE") > -1)
            {
                return true;
            }
            return res;
        }

        /// <summary>
        /// 获取选中的第一个订单index，如果没有则反馈10000
        /// </summary>
        /// <returns></returns>
        int GetSelectedOrder()
        {
            int i = 0;
            int count = GetGoodsCount();
            for (i = 0; i < count; i++)
            {
                if (IsSelectedOrder(i))
                {
                    return i;
                }
            }
            return 10000;
        }

        /// <summary>
        /// 点击打印预览
        /// </summary>
        void ClickDaYin()
        {
            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('btn-danger')[0].click()", webBrowser1);
        }

        /// <summary>
        /// 点击电子面板新
        /// </summary>
        void ClickDianZiMianBanXin()
        {
            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('btn ui-tab-change')[2].click()", webBrowser1);
        }

        /// <summary>
        /// 选择打印快递-韵达
        /// </summary>
        void SelectKuaiDi()
        {
            //选择打印快递-韵达
            Browser.OptionSetSeleted("document.getElementsByName('cloudWlbSlt')[0]", 10, "韵达", webBrowser1);
        }

        /// <summary>
        /// 选择打印快递
        /// </summary>
        /// <param name="str">输入：韵达 圆通 邮政，默认韵达</param>
        void SelectKuaiDi_YunDa(string str)
        {
            //点击快递公司
            Browser.MouseLeftByHtmlElement("document.getElementsByName('cloudWlbSlt')[0]", webBrowser1);
            Browser.Delay(500);
            if (string.IsNullOrEmpty(str))
                str = "韵达";
            int temp = Browser.OptionSearchIndex("document.getElementsByName('cloudWlbSlt')[0]", 10, str, webBrowser1);
            //点击快递
            Browser.MouseLeftByHtmlElement("document.getElementsByName('cloudWlbSlt')[0].getElementsByTagName('option')[" + (temp - 1).ToString() + "]", webBrowser1);
            //选择打印快递-韵达
            //Browser.OptionSetSeleted("document.getElementsByName('cloudWlbSlt')[0]", 10, "韵达", webBrowser1);
        }

        /// <summary>
        /// 选择打印机-118
        /// </summary>
        void SelectDaYinJi_118()
        {
            //选择打印机-118
            Browser.OptionSetSeleted("document.getElementsByName('printerCloudWlb')[0]", 10, "118", webBrowser1);
        }

        /// <summary>
        /// 选择打印机-888
        /// </summary>
        void SelectDaYinJi_888()
        {
            //选择打印机-888
            Browser.OptionSetSeleted("document.getElementsByName('printerCloudWlb')[0]", 10, "888", webBrowser1);
        }

        /// <summary>
        /// 设置快递单打印状态-未打印
        /// </summary>
        void SelectKuaiDiState()
        {
            string js = xml_js.GetValue("cjdz_kuaidistate");
            //设置快递单打印状态
            Browser.OptionSetSeleted(js, 10, "未打印", webBrowser1);
        }

        /// <summary>
        /// 设置订单状态-未发货
        /// </summary>
        void SelectOrderState()
        {
            string js = xml_js.GetValue("cjdz_orderstate");
            //设置订单状态-未发货
            Browser.OptionSetSeleted(js, 10, "未发货", webBrowser1);
        }

        /// <summary>
        /// 设置备注信息为：无留言备注
        /// </summary>
        void SelectRemarkState()
        {
            string js = xml_js.GetValue("cjdz_remarkstate");
            //设置备注信息为：无留言备注
            Browser.OptionSetSeleted(js, 10, "无留言备注", webBrowser1);
        }

        /// <summary>
        /// 设置备注信息为：有卖加备注
        /// </summary>
        void SelectRemarkState2()
        {
            //设置备注信息为：有卖加备注
            Browser.OptionSetSeleted(xml_js.GetValue("cjdz_remarkstate"), 10, "有卖家备注", webBrowser1);
        }

        /// <summary>
        /// 设置有卖家备注，备注内容为。。。
        /// </summary>
        /// <param name="str"></param>
        void SetSearchRemark(string str)
        {
            SelectRemarkState2();
            Browser.Delay(200);
            js_fahuo_noreturn("SetSearchRemark", str);
            //Browser.JS_CEFBrowser_NoReturn("document.getElementsByName('memoInfoInput')[0].value='" + str + "'", webBrowser1);
        }

        /// <summary>
        /// 打印韵达快递
        /// </summary>
        /// <param name="str">输入：韵达，圆通，邮政</param>
        void DaYin(string str)
        {
            ClickDaYin();
            Browser.Delay(500);
            ClickDianZiMianBanXin();
            Browser.Delay(500);
            SelectKuaiDi_YunDa(str);
            Browser.Delay(500);
            if (str == "韵达")
                SelectDaYinJi_118();
            else
                SelectDaYinJi_888();
        }
        void DaYin()
        {
            ClickDaYin();
            Browser.Delay(500);
            ClickDianZiMianBanXin();
        }

        /// <summary>
        /// 进入自定义打单页面
        /// </summary>
        void GoZiDingYi()
        {
            if (CS.Taobao.GoChaoJiDianZhang(webBrowser1))
            {
                string js = js_fahuo("GoZiDingYi");
                //进入打单发货
                string url = Browser.JS_CEFBrowser(js, webBrowser1);
                webBrowser1.Load(url);

            }
        }

        /// <summary>
        /// 选中 过滤退款单
        /// </summary>
        void SelectTuiKuan()
        {
            js_fahuo_noreturn("SelectTuiKuan");
            //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('order-tools')[0].getElementsByTagName('span')[3].click()", webBrowser1);
            Browser.Delay(500);
            SearchOver();
        }




        #endregion

        #region 基础配置

        #region btn_save_config_Click

        private void btn_save_config_Click(object sender, EventArgs e)
        {

            string temp_baigou = txt_config_baigou.Text;
            string temp_bendi = txt_config_bendi.Text;
            string temp_diqu = txt_config_diqu.Text;
            string temp_email = txt_config_email.Text;

            temp_bendi = temp_bendi.Replace("\r\n", ",");
            temp_baigou = temp_baigou.Replace("\r\n", ",");
            temp_diqu = temp_diqu.Replace("\r\n", ",");
            temp_email = temp_email.Replace("\r\n", ",");

            XMLHelper.SetValue("FaHuo_Config_BenDi", temp_bendi);
            XMLHelper.SetValue("FaHuo_Config_BaiGou", temp_baigou);
            XMLHelper.SetValue("FaHuo_Config_DiQu", temp_diqu);
            XMLHelper.SetValue("FaHuo_Config_Email", temp_email);

            bind_config();
            MessageBox.Show("保存成功");

        }
        #endregion

        #region  btn_reset_config_Click
        private void btn_reset_config_Click(object sender, EventArgs e)
        {
            bind_config();
        }




        #endregion

        #endregion

        #region 拼多多

        #region 登录7210
        private void btn_pdd_login7210_Click(object sender, EventArgs e)
        {
            Browser.ClearContext(webBrowser2);
            string access = XMLHelper.GetValue("PinDuoDuo_Access1");
            string pwd = XMLHelper.GetValue("PinDuoDuo_Pwd1");
            CS.PinDuoDuo.Login(access, pwd, webBrowser2);

        }
        #endregion

        #region 登录8323
        private void btn_pdd_login8323_Click(object sender, EventArgs e)
        {
            Browser.ClearContext(webBrowser2);
            string access = XMLHelper.GetValue("PinDuoDuo_Access2");
            string pwd = XMLHelper.GetValue("PinDuoDuo_Pwd2");
            CS.PinDuoDuo.Login(access, pwd, webBrowser2);
        }


        #endregion

        #region 带拼团
        private void btn_pdd_daipintuan_Click(object sender, EventArgs e)
        {
            webBrowser2.Load("http://mms.pinduoduo.com/Pdd.html#/group/nogroup");
        }

        #endregion

        #region 订单页面
        private void btn_pdd_orderlist_Click(object sender, EventArgs e)
        {
            CS.PinDuoDuo.GoDaiFaHuo(webBrowser2);
        }


        #endregion





        #region btn_pdd_caiji_Click


        private void btn_pdd_caiji_Click(object sender, EventArgs e)
        {
            //list_pdd_order = new List<string>();
            List<shuadan_records> list_pdd_order2 = new List<shuadan_records>();

            CS.PinDuoDuo.GoDaiFaHuo(webBrowser2);
            CS.PinDuoDuo.SearchOver_Pdd(webBrowser2);
            //如果还有下一页

            webBrowser2.Focus();


            //模拟100页数据
            for (int i = 0; i < 100; i++)
            {
                //获取数据，处理数据
                //查看本页面有多少条
                int searchcount = CS.PinDuoDuo.GetOrderCount_Pdd(webBrowser2) - 1;
                //获取本页面所有订单编号
                for (int j = 0; j < searchcount; j++)
                {
                    string ordercode = CS.PinDuoDuo.GetOrderCode_PDD(j, webBrowser2);
                    string goodsname = CS.PinDuoDuo.GetListGoodsName(j, webBrowser2);
                    string goodssku = CS.PinDuoDuo.GetListSKU(j, webBrowser2);
                    string goodsnum = CS.PinDuoDuo.GetListNum(j, webBrowser2);
                    if (!string.IsNullOrEmpty(ordercode))
                    {
                        shuadan_records sr = new shuadan_records();
                        sr.sdorderid = ordercode;
                        sr.sddate = DateTime.Now;
                        sr.sddptype = "3";
                        sr.sdremark2 = "1";
                        sr.sdremark3 = "1";
                        sr.sdremark4 = "1";
                        sr.sdremark6 = "1";

                        //sr.sdaddress = GetOrderName_PDD() + "," + GetOrderPhone_PDD() + "," + GetOrderAddress_PDD() + ",000000";
                        sr.sdgoodsname = goodsname;
                        //sr.sdphone = GetOrderPhone_PDD();
                        sr.sdremark1 = goodssku + "," + goodsnum;

                        list_pdd_order2.Add(sr);
                    }

                }


                //判断，点击下一页
                //如果还有下一页
                if (Browser.BoolByHtmlElement("document.getElementsByClassName('pdd-pagination-next')[0]", webBrowser2))
                {
                    //点击下一页
                    Browser.MouseLeftByHtmlElement("document.getElementsByClassName('pdd-pagination-next')[0]", webBrowser2);
                    CS.PinDuoDuo.SearchOver_Pdd(webBrowser2);
                }
                else
                {
                    //如果没有下一页，跳出循环
                    break;
                }
            }
            //http://mms.pinduoduo.com/order.html#/orders/order_detail/index?type=0&sn=180705-185654969512095
            //while (Browser.BoolByHtmlElement("document.getElementsByClassName('pdd-pagination-next')[0]", webBrowser2))
            //{
            //    //查看本页面有多少条
            //    int searchcount = GetOrderCount_Pdd() - 1;
            //    //获取本页面所有订单编号
            //    for (int i = 0; i < searchcount; i++)
            //    {
            //        string ordercode = GetOrderCode_PDD(i);
            //        if (string.IsNullOrEmpty(ordercode))
            //            list_pdd_order.Add(ordercode);
            //    }

            //    //点击下一页
            //    Browser.MouseLeftByHtmlElement("document.getElementsByClassName('pdd-pagination-next')[0]", webBrowser2);
            //}

            //订单编号获取完毕

            //查看详情，获取订单所有信息

            foreach (shuadan_records sr in list_pdd_order2)
            {
                CS.PinDuoDuo.GoOrderInfo(sr.sdorderid, webBrowser2);
                CS.PinDuoDuo.ClickLookPhone_PDD(webBrowser2);
                Browser.Delay(500);




                //sr.sdvpn = str+","+GetGoodsSKU_PDD();
                sr.sdaddress = CS.PinDuoDuo.GetOrderName_PDD(webBrowser2) + "," + CS.PinDuoDuo.GetOrderPhone_PDD(webBrowser2) + "," + CS.PinDuoDuo.GetOrderAddress_PDD(webBrowser2) + ",000000";
                //sr.sdgoodsname = GetGoodsName_PDD();
                sr.sdphone = CS.PinDuoDuo.GetOrderPhone_PDD(webBrowser2);
                //sr.sdremark1 = GetGoodsSKU_PDD() + "," + GetGoodsCount_PDD();

                BLL2.shuadan_recordsManager.Insert(sr);

            }
            MessageBox.Show("采集成功");


            tabControl1.SelectedTab = tp_list;
            dgv1.DataSource = BLL2.shuadan_recordsManager.SearchWeiFaHuo("3");
        }
        #endregion



        #region btn_page_zidingyi_Click
        private void btn_page_zidingyi_Click(object sender, EventArgs e)
        {
            GoZiDingYi();
        }



        #endregion

        #endregion

        #region 白沟



        #region 登录一块发
        private void btn_login_yikuaifa_Click(object sender, EventArgs e)
        {
            try
            {
                string taobao_url = "http://www.yikuaifa.com/Login.aspx";
                //淘宝登录方法
                webBrowser3.Load(taobao_url);

                if (Browser.WaitWebPageLoad(" document.getElementById('UserName') ", 2000, webBrowser3))
                {

                    Browser.JS_CEFBrowser_NoReturn("document.getElementById('UserName').value='405773378@qq.com'", webBrowser3);
                    Browser.JS_CEFBrowser_NoReturn("document.getElementById('Password').value='zhangjian'", webBrowser3);

                    Browser.MouseLeftByHtmlElement("document.getElementById('YanZheng')", webBrowser3);
                    Browser.MouseLeftByHtmlElement("document.getElementById('YanZheng')", webBrowser3);
                    Browser.MouseMoveByHtmlElement("document.getElementById('btnReg')", webBrowser3);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine("一块发登录失败" + ex.ToString());

            }

        }
        #endregion

        #region  其他快递打印功能
        private void btn_shougong_yikuaifa_Click(object sender, EventArgs e)
        {
            try
            {
                string taobao_url = "http://www.yikuaifa.com/VIPCenter/ShopCart.aspx";
                webBrowser3.Load(taobao_url);

                if (Browser.WaitWebPageLoad(" document.getElementById('Select1') ", 2000, webBrowser3))
                {
                    Browser.OptionSetSeleted("document.getElementById('Select1')", 10, "老联运", webBrowser3);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine("一块发登录失败" + ex.ToString());

            }
        }
        #endregion


        #region btn_copyaddress_yikuaifa_Click
        private void btn_copyaddress_yikuaifa_Click(object sender, EventArgs e)
        {

            int indexx = GetSelectedOrder();
            if (indexx == 10000)
            {
                MessageBox.Show("请先勾选需要发货的订单");
                return;
            }
            string buyerinfo = GetAddress(indexx);
            if (string.IsNullOrEmpty(buyerinfo))
            {
                MessageBox.Show("未获取到收件人信息");
                return;
            }
            webBrowser3.Focus();

            Browser.MouseLeftByHtmlElement("document.getElementsByClassName('newordertable')[1].getElementsByTagName('textarea')[0]", webBrowser3);
            Auto.Mouse_Left();
            buyerinfo = buyerinfo.Replace("联系方式：", "");
            Auto.Ctrl_V(buyerinfo);

            EditOrderRemark(indexx, " 已安排代发 ");

        }




        #endregion

        #region btn_kb_qiliang_Click  白沟发货-批量下单
        /// <summary>
        /// 批量下单页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_kb_qiliang_Click(object sender, EventArgs e)
        {
            KB_GoPiLiang();
        }
        #endregion

        #endregion

        #region 空包网

        #region 发空包方法

        void SendKongBao(Entity.shuadan_records sr)
        {
            #region 发空包
            try
            {
                tabControl1.SelectedTab = tp_pdd;
                string temp_orderid = sr.sdorderid;
                CS.PinDuoDuo.GoOrderInfo(sr.sdorderid, webBrowser2);
                CS.PinDuoDuo.ClickLookPhone_PDD(webBrowser2);
                Browser.Delay(500);
                string address = CS.PinDuoDuo.GetOrderAddress_PDD(webBrowser2);
                string state = Browser.JS_CEFBrowser("document.getElementsByClassName('o-d-i-c-span')[2].innerText", "document.getElementsByClassName('o-d-i-c-span')[2]", webBrowser2);
                string datetemp = Browser.JS_CEFBrowser("document.getElementsByClassName('o-d-i-c-span')[6].innerText", "document.getElementsByClassName('o-d-i-c-span')[6]", webBrowser2);
                if (state.IndexOf("待发货") > -1)
                {
                    sr_temp = sr;
                    if (!string.IsNullOrEmpty(address))
                    {
                        tabControl1.SelectedTab = tp_pddkb;
                        string tempinfo = temp_orderid + "-" + address + "-" + state + System.Environment.NewLine + datetemp;
                        txt_kbinfo.Text = tempinfo;
                        kongbaowang_set(address);
                        //判断省市是否正确
                        string temp_address = Manager.SubString2(address, "省", "市");
                        //等待3秒钟
                        Browser.Delay(XMLHelper_FaHuo.GetValue("KB_SearchResDelay").ToInt());
                        //获取查询结果并对比
                        string temp_address_res = Browser.JS_CEFBrowser(XMLHelper_FaHuo.GetValue("KB_SearchResAddress"), webBrowser4);
                        if (temp_address_res.IndexOf(temp_address) > -1)
                        {
                            //如果确认是查询正确的结果
                            //点击随机的前几个的数据的其中一个
                            int temp_count = Browser.JS_CEFBrowserToInt(XMLHelper_FaHuo.GetValue("KB_SearchResCount"), webBrowser4);
                            if (temp_count > 0)
                            {
                                int temp_index = Manager.RandomNumber(1, temp_count);
                                //点击购买
                                string js = XMLHelper_FaHuo.GetValue("KB_SearchResBuy");
                                js = js.Replace("parameter", temp_index.ToString());
                                Browser.JS_CEFBrowser_NoReturn(js, webBrowser4);
                                Browser.Delay(1000);
                                //点击确认购买按钮
                                Browser.JS_CEFBrowser_NoReturn(XMLHelper_FaHuo.GetValue("KB_SearchResOK2"), webBrowser4);

                                Auto.MoveMouseToPoint(btn_kbtiandanhao.PointToScreen(new Point(5, 5)));
                            }



                        }



                    }
                }
                else
                {
                    tabControl1.SelectedTab = tp_list;
                    MessageBox.Show("订单状态异常: " + state);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("发空包出错" + ex.ToString());
            }

            #endregion
        }

        /// <summary>
        /// 全自动发货拼多多电子面单
        /// </summary>
        /// <param name="sr"></param>
        void SendKongBao2(Entity.shuadan_records sr)
        {
            #region 发空包
            try
            {
                tabControl1.SelectedTab = tp_pdd;
                string temp_orderid = sr.sdorderid;
                CS.PinDuoDuo.GoOrderInfo(sr.sdorderid, webBrowser2);
                CS.PinDuoDuo.ClickLookPhone_PDD(webBrowser2);
                Browser.Delay(500);
                string address = CS.PinDuoDuo.GetOrderAddress_PDD(webBrowser2);
                string state = Browser.JS_CEFBrowser("document.getElementsByClassName('o-d-i-c-span')[2].innerText", webBrowser2);
                //string datetemp = Browser.JS_CEFBrowser("document.getElementsByClassName('o-d-i-c-span')[6].innerText", "document.getElementsByClassName('o-d-i-c-span')[6]", webBrowser2);
                if (state.IndexOf("待发货") > -1)
                {
                    sr_temp = sr;
                    if (!string.IsNullOrEmpty(address))
                    {
                        string phone = CS.PinDuoDuo.GetOrderPhone_PDD(webBrowser2);
                        string name = CS.PinDuoDuo.GetOrderName_PDD(webBrowser2);
                        address = address.Replace("省", "省 ");
                        address = address.Replace("市", "市 ");
                        address = address.Replace("区", "区 ");
                        address = address.Replace("县", "县 ");
                        address = address.Replace("自治区", "自治区 ");
                        address = address.Replace("自治州", "自治州 ");
                        address = address.Replace("镇", "镇 ");
                        address = address.Replace("乡", "乡 ");
                        address = address.Replace(",", "");
                        address = address.Replace(".", "");
                        address = address.Replace("。", "");
                        string ok = name + "," + phone + "," + address + ",000000";
                        txt_kbinfo.Text = ok;
                        Auto.Ctrl_V(ok);
                        txt_pddstate.Text = ok;

                        tabControl1.SelectedTab = tp_pddkb;
                        webBrowser4.Load("http://pg.315kb.wang/business/pdd.html");
                        if (Browser.WaitWebPageLoad("document.getElementById('address_res')", webBrowser4))
                        {
                            //设置地址
                            Browser.JS_CEFBrowser("document.getElementById('address_res').value='" + ok + "'", webBrowser4);
                            Browser.Delay(500);
                            //点击验证地址
                            Browser.JS_CEFBrowser("document.getElementById('checkAddress').click()", webBrowser4);
                            Browser.Delay(500);
                            //点击购买
                            Browser.JS_CEFBrowser("document.getElementById('EmytpSubmit').click()", webBrowser4);
                            Browser.Delay(500);
                            //点击确认
                            Browser.JS_CEFBrowser("document.getElementsByClassName('aui_state_highlight')[0].click()", webBrowser4);
                            Browser.Delay(500);
                            //移动到按钮上
                            //Auto.MoveMouseToButton(btn_kbtiandanhao);
                            btn_kbtiandanhao.PerformClick();
                            btn_pdd_fahuo.PerformClick();
                        }

                    }
                }
                else
                {
                    //tabControl1.SelectedTab = tp_list;
                    // MessageBox.Show("订单状态异常: " + state);
                    txt_pddstate.Text = "订单状态异常: " + state;
                    btn_pdd_fahuo.PerformClick();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("发空包出错" + ex.ToString());
            }

            #endregion
        }


        void SetDanHao()
        {
            txt_js.Text = "";
            //获取单号
            string danhao = "";
            if (webBrowser4.Address.IndexOf("315kb") > -1)
            {
                Browser.Delay(2000);
                if (Browser.WaitWebPageLoad("document.getElementsByClassName('text-orange')[0].getElementsByTagName('input')[0]", 5000, webBrowser4))
                {
                    danhao = Browser.JS_CEFBrowser("document.getElementsByClassName('text-orange')[0].getElementsByTagName('input')[0].value", webBrowser4);
                }
            }
            else
            {
                danhao = Browser.JS_CEFBrowser("document.getElementById('xubox_iframe1').contentWindow.document.getElementById('Label5').innerText", webBrowser4);
            }
            //如果没有单号则直接跳出
            if (string.IsNullOrEmpty(danhao))
            {
                return;
            }
            //复制单号
            Auto.Ctrl_C(danhao);
            txt_js.Text = danhao;

            //填单号
            tabControl1.SelectedTab = tp_pdd;

            webBrowser2.Focus();
            //点击发货
            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('express-import')[0].click()", webBrowser2);


            //点击自己联系物流
            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('tab-border-bottom')[0].click()", webBrowser2);
            Browser.Delay(1000);
            //取消提示框样式
            Browser.JS_CEFBrowser_NoReturn("document.getElementById('single_order_ship_modal').getElementsByTagName('div')[0].setAttribute('class','')", webBrowser2);
            Browser.Delay(500);
            //点击退货地址
            Browser.MouseLeftByHtmlElement("document.getElementsByClassName('pdd-form-input')[2]", 10, 105, webBrowser2);
            Browser.Delay(500);
            //点击退货地址
            Browser.MouseLeftByHtmlElement("document.getElementsByClassName('pdd-form-input')[2]", 10, 180, webBrowser2);
            //Browser.Delay(500);
            //填快递单号
            string temp_order = System.Windows.Forms.Clipboard.GetText();
            Browser.MouseLeftByHtmlElement("document.getElementsByClassName('pdd-form-input')[2]", webBrowser2);
            //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('pdd-form-input')[2].value='" + temp_order + "'", webBrowser2);
            //粘贴
            if (!string.IsNullOrEmpty(temp_order))
                Auto.Ctrl_V();
            //修改状态
            //string state = Browser.JS_CEFBrowser("document.getElementsByClassName('o-d-i-c-span')[0].innerText", webBrowser2);
            //shuadan_records sr=BLL2.shuadan_recordsManager.Search()
            if (sr_temp != new shuadan_records())
            {
                sr_temp.sdremark4 = "2";
                BLL2.shuadan_recordsManager.Update(sr_temp);
                dgv1.DataSource = BLL2.shuadan_recordsManager.SearchWeiFaHuo("3");
                sr_temp = new shuadan_records();
            }

            //设置选定空包
            if (webBrowser4.Address.IndexOf("315kb") > -1)
            {
                Browser.MouseLeftByHtmlElement("document.getElementsByClassName('pdd-form-input')[2]", 0, 55, webBrowser2);
                Browser.Delay(500);
                Browser.MouseLeftByHtmlElement("document.getElementsByClassName('order-express-group')[7].getElementsByClassName('pdd-btn')[0]", webBrowser2);
                Auto.MoveMouseToButton(btn_pdd_fahuo);
            }
        }


        #endregion

        void kongbaowang_set()
        {
            //关闭提示窗
            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('xubox_close')[0].click()", webBrowser4);
            //选择模式三
            Browser.JS_CEFBrowser_NoReturn("document.getElementById('moshisan').click()", webBrowser4);
            Browser.JS_CEFBrowser_NoReturn("document.getElementById('MainC_tb_sendCity').value='高碑店'", webBrowser4);
        }

        void kongbaowang_set(string temp_add)
        {
            kongbaowang_set();
            //设置地址
            if (temp_add.IndexOf("省") != -1 || temp_add.IndexOf("市") != -1)
            {
                temp_add = Manager.SubString2(temp_add, "省", "市");
            }
            Browser.JS_CEFBrowser_NoReturn("document.getElementById('MainC_tb_arriveCity').value='" + temp_add + "'", webBrowser4);
            Browser.JS_CEFBrowser_NoReturn("document.getElementById('MainC_btnSearchM3').click()", webBrowser4);

        }

        #region 登录拼多多空包网账号
        private void button5_Click(object sender, EventArgs e)
        {
            CS.PinDuoDuo.Login_kongbao("ourstoryzj", "zhangjian", webBrowser4);
        }
        #endregion

        private void button4_Click(object sender, EventArgs e)
        {
            kongbaowang_set();
            //Browser.Delay(1000);
            //Browser.MouseLeftByHtmlElement("document.getElemnetById('MainC_tb_arriveCity')", webBrowser4);
            //Browser.MouseLeftByHtmlElement("document.getElemnetById('MainC_tb_arriveCity')", webBrowser4);
            //Browser.MouseMoveByHtmlElement("document.getElemnetById('MainC_btnSearchM3')", webBrowser4);
        }

        private void btn_kblogin12345_Click(object sender, EventArgs e)
        {
            CS.PinDuoDuo.Login_kongbao_12345pt("15176238323", "zhangjian", webBrowser4);
        }

        private void btn_kb12345_fahuo_Click(object sender, EventArgs e)
        {
            //webBrowser4.Load("http://vip.12345pt.com/business/pdd.html");
            webBrowser4.Load("http://pg.315kb.wang/business/pdd.html");
        }

        private void btn_kbtiandanhao_Click(object sender, EventArgs e)
        {
            SetDanHao();
        }
        #endregion

        #region 私有方法

        #region GetDianPu
        /// <summary>
        /// 获取下拉菜单中店铺的信息
        /// </summary>
        /// <returns></returns>
        dianpu GetDianPu()
        {
            dianpu dp = null;

            string dpid_temp = cb_dianpu.SelectedValue.ToString();
            int dpid = 0;
            if (dpid_temp != "0")
            {
                if (int.TryParse(dpid_temp, out dpid))
                {
                    dp = BLL2.dianpuManager.SearchBydpid(dpid);
                }
            }

            return dp;
        }



        #endregion

        #region reset设置搜索条件重置
        /// <summary>
        /// reset设置搜索条件重置
        /// </summary>
        void reset()
        {
            Browser.JS_CEFBrowser_NoReturn(xml_js.GetValue("cjdz_reset"), webBrowser1);
            Browser.JS_CEFBrowser_NoReturn(xml_js.GetValue("cjdz_reset"), webBrowser1);
            Browser.Delay(500);

        }
        #endregion

        #region 采集所有订单



        //新增

        /// <summary>
        /// 直接获取订单后面显示的商品数量
        /// </summary>
        /// <param name="indexx"></param>
        /// <returns></returns>
        int GetOrderGoodsCount1(int indexx)
        {
            string res = Browser.JS_CEFBrowser(xml_js.GetValue("cjdz_ordergoodsnum"), webBrowser1);
            res = res.Replace("商品总数：", "");
            int count = 0;
            int.TryParse(res, out count);
            return count;
        }

        /// <summary>
        /// 获取订单中商品列表的数量
        /// </summary>
        /// <param name="indexx"></param>
        /// <returns></returns>
        int GetOrderGoodsCount2(int indexx)
        {
            int count = Browser.JS_CEFBrowserToInt("document.getElementsByName('orders')[" + indexx.ToString() + "].getElementsByTagName('tr').length-1", webBrowser1);
            return count;
        }

        /// <summary>
        /// 获取第几行第几个商品名称
        /// </summary>
        /// <param name="indexx"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        string GetGoodsName(int indexx, int number)
        {
            number = number + 1;
            string gn = Browser.JS_CEFBrowser("document.getElementsByClassName('order-item')[" + indexx.ToString() + "].getElementsByTagName('tr')[" + number.ToString() + "].getElementsByClassName('o-title')[0].innerText", webBrowser1);
            return gn;
        }

        /// <summary>
        /// 获取第几行第几个商品链接
        /// </summary>
        /// <param name="indexx"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        string GetGoodsUrl(int indexx, int number)
        {
            number = number + 1;
            string gn = Browser.JS_CEFBrowser("document.getElementsByClassName('order-item')[" + indexx.ToString() + "].getElementsByTagName('tr')[" + number.ToString() + "].getElementsByClassName('o-title')[0].href", webBrowser1);
            return gn;
        }

        /// <summary>
        /// 获取第几行第几个商品SKU
        /// </summary>
        /// <param name="indexx"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        string GetGoodsSKU(int indexx, int number)
        {
            int td = 2 + GetGoodsTbIndex(indexx);
            number = number + 1;
            string gn = Browser.JS_CEFBrowser("document.getElementsByClassName('order-item')[" + indexx.ToString() + "].getElementsByTagName('tr')[" + number.ToString() + "].getElementsByTagName('td')[" + td.ToString() + "].innerText", webBrowser1);
            return gn;
        }
        /// <summary>
        /// 获取第几行第几个商品数量
        /// </summary>
        /// <param name="indexx"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        string GetGoodsNum(int indexx, int number)
        {
            int td = 4 + GetGoodsTbIndex(indexx);
            number = number + 1;
            string gn = Browser.JS_CEFBrowser("document.getElementsByClassName('order-item')[" + indexx.ToString() + "].getElementsByTagName('tr')[" + number.ToString() + "].getElementsByTagName('td')[" + td.ToString() + "].innerText", webBrowser1);
            return gn;
        }

        /// <summary>
        /// 判断是否是多件，然后如果是多件td的index需要+1，主要用于SKU和商品数量的获取
        /// </summary>
        /// <param name="indexx"></param>
        /// <returns></returns>
        int GetGoodsTbIndex(int indexx)
        {
            int res = 0;
            int ordernum = GetOrderGoodsCount1(indexx);
            if (ordernum > 1)
            {
                res = 1;
            }
            return res;
        }

        /// <summary>
        /// 采集特殊订单1
        /// </summary>
        /// <param name="indexx"></param>
        /// <returns></returns>
        bool CaiJiOther1(int indexx)
        {
            #region 特殊订单一：一单多件，不同SKU

            bool res = false;

            //特殊订单一：一单多件，不同SKU
            //获取商品订单数量
            int goodscount = GetOrderGoodsCount1(indexx);
            //判断是否有多件
            if (goodscount > 1)
            {
                //备注多件
                EditOrderRemark(indexx, "多件");
                int trs = GetOrderGoodsCount2(indexx);
                res = true;
                for (int j = 0; j < trs; j++)
                {

                    shuadan_records sr = new shuadan_records();

                    string address = GetAddress(indexx);
                    string phonecode = GetPhone(indexx);
                    string ordercode = GetOrderCode(indexx);
                    string wangwang = GetBuyer(indexx);
                    string goodsname = GetGoodsName(indexx, j);
                    string goodsurl = GetGoodsUrl(indexx, j);
                    string sku = GetGoodsSKU(indexx, j);
                    string num = GetGoodsNum(indexx, j);

                    sr.sdaddress = address;
                    sr.sdphone = phonecode;
                    sr.sdgoodsname = goodsname;
                    sr.sdgoodsurl = goodsurl;
                    sr.sdorderid = ordercode + (j != 0 ? ("-" + j.ToString()) : "");
                    sr.sdvpn = wangwang;
                    sr.sdremark1 = sku + "," + num;
                    sr.sddptype = "2";
                    sr.sddate = DateTime.Now;
                    sr.sdremark2 = "1";
                    sr.sdremark3 = "1";
                    sr.sdremark4 = "2";
                    sr.sdremark6 = "1";

                    SelectedOrder(indexx);

                    //sr.sddate = DateTime.Now.AddDays(1);

                    BLL2.shuadan_recordsManager.Insert(sr);

                }
            }

            return res;

            #endregion
        }


        private void btn_caijiall_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;

            //判断是否进入打单发货界面
            if (Browser.BoolByHtmlElement(xml_js.GetValue("cjdz_gengxindingdan"), webBrowser1))
            {
                try
                {
                    reset();

                    //设置搜索条件

                    //设置快递单打印状态
                    SelectKuaiDiState();
                    //设置订单发货
                    SelectOrderState();
                    //设置备注信息为：无留言备注
                    //SelectRemarkState();

                    Browser.Delay(500);

                    ClickSearch2();

                    SearchOver();

                    //过滤退款
                    SelectTuiKuan();

                    //添加失败订单数量
                    int resres = 0;

                    while (1 == 1)
                    {

                        SearchOver();

                        //获取查询订单后，显示的订单数量
                        int searchcount = GetGoodsCount();


                        //循环添加
                        for (int i = 0; i < searchcount; i++)
                        {
                            //开始操作
                            shuadan_records sr = new shuadan_records();

                            //采集特殊订单
                            if (CaiJiOther1(i))
                            {
                                //如果是特殊订单，则采集下一个
                                continue;
                            }




                            sr = CaiJiOrderInfo(sr, i);
                            sr.sddptype = "2";
                            sr.sddate = DateTime.Now;
                            sr.sdremark2 = "1";
                            sr.sdremark3 = "1";
                            sr.sdremark4 = "2";
                            sr.sdremark6 = "1";

                            //sr.sddate = DateTime.Now.AddDays(1);


                            //int goodscount = GetOrderGoodsCount1(i);
                            //判断白沟货源
                            if (HasBaiGou(i))
                            {

                                EditOrderRemark(i, "白沟");
                            }
                            //判断特殊地区
                            else if (HasTeShuDiQu(i))
                            {

                                EditOrderRemark(i, "其他快递");
                            }
                            //else if (GetOrderGoodsCount1(i) > 1)
                            //{
                            //    sr.sdremark1 = GetGoodsSKU(i, 0) + "," + GetGoodsNum(i, 0);
                            //    EditOrderRemark(i, "多件");
                            //    //sr.sdremark4 = "2";
                            //    //设置选中
                            //    SelectedOrder(i);
                            //}

                            SelectedOrder(i);

                            //添加信息
                            if (BLL2.shuadan_recordsManager.Insert(sr) == 0)
                                resres = resres + 1;

                        }

                        Browser.Delay(1000);

                        string res = Browser.JS_CEFBrowser("document.getElementsByClassName('disable')[document.getElementsByClassName('disable').length-1].innerText", webBrowser1);
                        if (!string.IsNullOrEmpty(res))
                        {
                            //如果没有下一页
                            if (res.IndexOf("下") > -1)
                            {
                                break;
                            }
                        }
                        //点击下一页
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('page-next')[0].getElementsByTagName('a')[0].click()", webBrowser1);


                    }

                    MessageBox.Show("采集所有订单完成 " + (resres == 0 ? "" : " 添加失败订单数量： " + resres.ToString()));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("采集所有订单出错 " + ex.ToString());
                }



            }
        }
        #endregion

        #region Print_Remark打印备注


        /// <summary>
        /// 打印备注
        /// </summary>
        /// <param name="remark">备注内容</param>
        void Print_Remark(string remark)
        {
            tabControl1.SelectedTab = tabPage1;
            //判断是否进入打单发货界面
            if (Browser.BoolByHtmlElement(XMLHelper_FaHuo.GetValue("ishas"), webBrowser1))
            {
                try
                {
                    reset();
                    //设置快递单打印状态
                    SelectKuaiDiState();
                    //设置订单发货
                    SelectOrderState();
                    //设置备注信息为：有卖家备注
                    //SelectRemarkState2();
                    string beizhu = txt_beizhu.Text.Trim(); ;
                    SetSearchRemark(remark);

                    Browser.Delay(500);

                    ClickSearch2();

                    SearchOver();

                    //获取查询订单后，显示的订单数量
                    int searchcount = GetGoodsCount();

                    //循环添加
                    for (int i = 0; i < searchcount; i++)
                    {
                        //开始操作
                        //shuadan_records sr = new shuadan_records();
                        //sr = CaiJiOrderInfo(sr, i);

                        //sr.sddptype = "2";
                        //sr.sddate = DateTime.Now;
                        //sr.sdremark2 = "1";
                        //sr.sdremark3 = "1";
                        ////sr.sdremark4 = "1";
                        //sr.sdremark6 = "1";
                        //sr.sdremark4 = "2";



                        //设置选中
                        SelectedOrder(i);

                        //添加信息
                        //BLL2.shuadan_recordsManager.Insert(sr);

                    }

                    MessageBox.Show("选择完成");

                    //Browser.Delay(1000);
                    //DaYin();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(" 打印 " + remark + " 失败: " + ex.ToString());
                }



            }
        }

        #endregion

        #region btn_print_duojian_Click
        private void btn_print_duojian_Click(object sender, EventArgs e)
        {
            Print_Remark("多件");
        }

        #endregion



        #region KB_GetOrderInfo
        /// <summary>
        /// 获取订单信息 用于发空包
        /// </summary>
        /// <param name="sr"></param>
        void KB_GetOrderInfo(shuadan_records sr)
        {
            //设置昵称
            SetBuyer(sr.sdvpn);
            Browser.Delay(500);
            //点击查询
            ClickSearch();
            Browser.Delay(1000);
            //等待搜索结束
            SearchOver();

            //获取查询订单后，显示的订单数量
            int searchcount = GetGoodsCount();
            //取消选中
            //cbx.Value = false;

            //如果没有找到，或者订单大于1则提示，并停止
            if (searchcount == 0)
            {
                sr.sdremark5 += " 没有找到或者订单较多，请留意";
                sr.sdremark6 = "3";//设置收菜有问题
                BLL2.shuadan_recordsManager.Update(sr);
                MessageBox.Show("没有找到，请留意");
                return;
            }

            //采集订单信息
            sr = CaiJiOrderInfo(sr, 0);
            sr.sdremark2 = "2";
            BLL2.shuadan_recordsManager.Update(sr);
            //string codes = GetOrderCode(0);
            //string address = GetAddress(0);
            orderinfo_temp = orderinfo_temp + sr.sdorderid + "," + sr.sdaddress + "\r\n";
            //string info_temp = codes + "," + 0;


        }
        #endregion

        #region 进入批量发货
        /// <summary>
        /// 进入批量发货
        /// </summary>
        void KB_GoPiLiang()
        {
            string taobao_url = "http://www.ppq999.com/PlaceOrder/Batch";
            //淘宝登录方法
            webBrowser3.Load(taobao_url);
            if (Browser.WaitWebPageLoad(XMLHelper_FaHuo.GetValue("KB_ZhongLiang1"), 5000, webBrowser3))
            {
                webBrowser3.Focus();
                string js = XMLHelper_FaHuo.GetValue("KB_ClickKuaiDiType");
                Browser.JS_CEFBrowser_NoReturn(js, webBrowser3);
                js = XMLHelper_FaHuo.GetValue("KB_ClickYuanTong");
                Browser.JS_CEFBrowser_NoReturn(js, webBrowser3);
                js = XMLHelper_FaHuo.GetValue("KB_ClickOrderLaiYuan");
                Browser.JS_CEFBrowser_NoReturn(js, webBrowser3);
                js = XMLHelper_FaHuo.GetValue("KB_ClickTaoBao");
                Browser.JS_CEFBrowser_NoReturn(js, webBrowser3);
                js = XMLHelper_FaHuo.GetValue("KB_ClickDiZhi");
                Browser.JS_CEFBrowser_NoReturn(js, webBrowser3);
                js = XMLHelper_FaHuo.GetValue("KB_ClickDiZhi2");
                Browser.JS_CEFBrowser_NoReturn(js, webBrowser3);

                Browser.MouseLeftByHtmlElement(XMLHelper_FaHuo.GetValue("KB_ZhongLiang1"), 5, 5, webBrowser3);
                Browser.MouseLeftByHtmlElement(XMLHelper_FaHuo.GetValue("KB_ZhongLiang1"), 5, 5, webBrowser3);
                Auto.Ctrl_V(XMLHelper_FaHuo.GetValue("KB_ZhongLiang3"));
                Browser.MouseLeftByHtmlElement(XMLHelper_FaHuo.GetValue("KB_ZhongLiang2"), 5, 5, webBrowser3);
                Auto.Ctrl_V(XMLHelper_FaHuo.GetValue("KB_ZhongLiang4"));

                Browser.MouseLeftByHtmlElement(XMLHelper_FaHuo.GetValue("KB_OrderInfo"), 5, 5, webBrowser3);


            }
        }
        #endregion

        #endregion

        #region 拼多多补单







        private void btn_pddbd_reset_Click(object sender, EventArgs e)
        {
            pddbd_reset();
            //Music.play_1();
            //System.Media.SystemSounds.Asterisk.Play();
        }

        void pddbd_reset()
        {
            txt_address.Clear();
            txt_date.Clear();
            //txt_goodsname.Clear();
            txt_orderid.Clear();
            txt_phone2.Clear();
            txt_vpnadd.Clear();
            txt_wuliu.Clear();
            txt_url.Clear();
            cb_fahuo2.Text = "未发货";
            cb_kongbao2.Text = "未获取";
            cb_shoptype.Text = "拼多多";
            cb_shoucai2.Text = "未收菜";
            txt_date.Text = "不输入则表示当下时间";
        }

        private void btn_save2_Click(object sender, EventArgs e)
        {
            string address = txt_address.Text;
            string dates = txt_date.Text.Trim();
            string goodsname = txt_goodsname.Text.Trim();
            string orderid = txt_orderid.Text.Trim();
            string phone = txt_phone2.Text.Trim();
            string vpnadd = txt_vpnadd.Text.Trim();
            string wuliu = txt_wuliu.Text.Trim();
            string shoptype = cb_shoptype.Text;
            string kongbao = cb_kongbao2.Text;
            string fahuo = cb_fahuo2.Text;
            string shoucai = cb_shoucai2.Text;
            string url = txt_url.Text.Trim();
            string remark = txt_remark.Text.Trim();
            DateTime dt = new DateTime();
            if (!DateTime.TryParse(dates, out dt))
            {
                //MessageBox.Show("请输入正确的时间");
                //txt_date.Focus();
                //return;
                dt = DateTime.Now;
            }

            if (shoptype == "蘑菇街")
            {
                shoptype = "1";
            }
            else if (shoptype == "淘宝")
            {
                shoptype = "2";
            }
            else if (shoptype == "拼多多")
            {
                shoptype = "3";
            }
            if (kongbao == "未获取")
            {
                kongbao = "1";
            }
            else
            {
                kongbao = "2";
            }
            if (fahuo == "未发货")
            {
                fahuo = "1";
            }
            else
            {
                fahuo = "2";
            }
            if (shoucai == "未收菜")
            {
                shoucai = "1";
            }
            else if (shoucai == "已收菜")
            {
                shoucai = "2";
            }
            else
            {
                shoucai = "3";
            }




            Entity.shuadan_records sd = new Entity.shuadan_records();
            sd.sdaddress = address;
            sd.sddate = dt;
            sd.sddptype = shoptype;
            sd.sdgoodsname = goodsname;
            sd.sdgoodsurl = url;
            sd.sdorderid = orderid;
            sd.sdphone = phone;
            sd.sdvpn = vpnadd;
            sd.sdwuliu = wuliu;
            sd.sdremark3 = kongbao;
            sd.sdremark4 = fahuo;
            sd.sdremark2 = shoucai;
            sd.sdremark5 = remark;
            sd.sdremark6 = "2";



            if (BLL2.shuadan_recordsManager.Insert(sd) == 1)
            {
                MessageBox.Show("保存成功");
                pddbd_reset();
            }
        }




        private void btn_getphone_Click(object sender, EventArgs e)
        {
            txt_savephone.Text = "";
            token = MessageAPI.GetToken();

            if (!string.IsNullOrEmpty(phone))
            {
                txt_savephone.Text = MessageAPI.ClearPhone(token, phone);
                txt_savephone.Text = txt_savephone.Text + MessageAPI.AddBlack(token, phone);
                //MessageAPI.ClearPhone(token, phone);

            }
            string res = MessageAPI.GetPhone(token);
            txt_phone.Text = res;
            phone = res;
            Auto.Clipboard_In(res);
        }

        private void btn_Phone_Click(object sender, EventArgs e)
        {
            btn_Phone.Enabled = false;
            string res = "";
            int i = 0;
            //每3秒循环获取验证码
            do
            {

                txt_yanzhengma.Text = "正在获取验证码，请稍后。。。 " + Manager.RandomNumber(1000, 99999).ToString();
                res = MessageAPI.GetMessage(token);
                if (res.IndexOf("验证码") == -1)
                {
                    //Thread.Sleep(3000);
                    Browser.Delay(5000);
                }
                //获取10次
                i++;
                if (i == 10)
                {
                    btn_Phone.Enabled = true;
                    MessageBox.Show("没有获取到验证码");
                    return;
                }
            } while (res.IndexOf("验证码") == -1);
            //得到验证码
            txt_yanzhengma.Text = res;
            res = CS.PinDuoDuo.GetYanZhengMa(res);
            //res = Mogujie.getYanZhengMa(res);
            Auto.Clipboard_In(res);
            txt_savephone.Text = phone;
            txt_phone2.Text = phone;
            //webBrowser2.Focus();
            //Browser.JS_CEFBrowser_NoReturn("document.getElementsByName('telcode')[0].value=" + getYanZhengMa(res), webBrowser2);
            ////MessageBox.Show(getYanZhengMa(res));
            //Browser.Delay(1000);
            //Browser.MouseLeftByHtmlElement("document.getElementsByClassName('sub')[0]", webBrowser2);18675992431
            btn_Phone.Enabled = true;
            Music.play_1();
            //txt_yanzhengma.Text = res + " 如需再次获取验证码，请5秒后操作 " + Manager.RandomNumber(1000, 99999).ToString();
            //MessageBox.Show("如需再次获取验证码，请5秒后操作");
        }

        private void btn_save_pinduoduo_Click(object sender, EventArgs e)
        {
            #region 拼多多

            string p = txt_savephone.Text;
            //webBrowser2.Load("http://order.xiaodian.com/pc/trade/order/list/list4seller");
            //如果没有手机号
            if (string.IsNullOrEmpty(p))
            {
                //document.getElementsByClassName('tab-hover2')[0].click()
                //if (Browser.WaitWebPageLoad2("document.getElementsByClassName('tab-hover2')[0]", webBrowser2))
                //{
                //    //点击等待发货
                //    Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('tab-hover2')[0].click()", webBrowser2);

                //}
                MessageBox.Show("请添加手机号码");
                return;
            }
            //else
            //{
            //    //如果有手机号
            //    if (Browser.WaitWebPageLoad2("document.getElementsByClassName('xd-input')[3]", webBrowser2))
            //    {
            //        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('xd-input')[3].value=" + p, webBrowser2);
            //        Browser.MouseLeftByHtmlElement("document.getElementsByClassName('xd-input')[3]", webBrowser2);
            //        Browser.MouseLeftByHtmlElement("document.getElementsByClassName('xd-input')[3]", webBrowser2);
            //        Auto.Clipboard_In(p);
            //        Auto.Ctrl_V();
            //        Browser.Delay(500);
            //        //点击等待发货
            //        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('xd-btn')[1].click()", webBrowser2);
            //    }
            //}
            //Browser.Delay(2000);

            //string temp = Browser.JS_CEFBrowser("document.getElementsByClassName('no-result')[0]!=null", webBrowser1);
            //if (!string.IsNullOrEmpty(temp) && temp == "True")
            //{

            //    MessageBox.Show("没有找到该订单");
            //    return;
            //}

            Entity.shuadan_records sd = new Entity.shuadan_records();
            //sd.sdaddress = Browser.JS_CEFBrowser("document.getElementsByClassName('copy_address')[0].getAttribute('data-clipboard-text')", webBrowser2) + ",000000";
            //string temp_date = Browser.JS_CEFBrowser("document.getElementsByClassName('order-date')[0].getElementsByTagName('span')[1].innerText", webBrowser2);
            //DateTime dt = new DateTime();
            //DateTime.TryParse(temp_date, out dt);
            sd.sddate = DateTime.Now;
            sd.sddptype = "3";
            //sd.sdgoodsname = Browser.JS_CEFBrowser("document.getElementsByClassName('g-title')[0].getElementsByTagName('span')[0].innerText", webBrowser2);
            //sd.sdgoodsurl = Browser.JS_CEFBrowser("document.getElementsByClassName('g-title')[0].href", webBrowser2); ;
            //sd.sdorderid = Browser.JS_CEFBrowser("document.getElementsByClassName('order-num')[0].getElementsByTagName('span')[1].innerText", webBrowser2); ;
            sd.sdphone = p;
            sd.sdvpn = "";
            sd.sdwuliu = "";
            sd.sdremark3 = "1";
            sd.sdremark4 = "1";
            sd.sdremark2 = "1";
            sd.sdremark5 = "手机";




            if (BLL2.shuadan_recordsManager.Insert(sd) == 1)
            {
                MessageBox.Show("保存成功");
            }

            #endregion
        }

        private void btn_phone_open_Click(object sender, EventArgs e)
        {

            token = MessageAPI.GetToken();
            string pp = txt_savephone.Text;
            txt_savephone.Text = "";
            if (!string.IsNullOrEmpty(pp))
            {
                txt_savephone.Text = MessageAPI.ClearPhone(token, phone);
                txt_savephone.Text = txt_savephone.Text + MessageAPI.AddBlack(token, phone);
            }
            string ps = txt_phone.Text.Trim();
            Auto.Clipboard_In(ps);
            string res = MessageAPI.GetPhone(token, ps);
            txt_phone.Text = res;
            phone = res;
            Auto.Clipboard_In(res);

        }

        private void button7_Click(object sender, EventArgs e)
        {

            string str = txt_yanzhengma.Text;
            Auto.Clipboard_In(str);
            MessageBox.Show(CS.PinDuoDuo.GetYanZhengMa(str));
        }


        private void txt_phone_Click(object sender, EventArgs e)
        {
            string str = txt_phone.Text;
            Auto.Clipboard_In(str);
        }




        private void txt_yanzhengma_TextChanged(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// 处理下一个补单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_pdd_fahuo_Click(object sender, EventArgs e)
        {
            //int col = 6;
            //string colname = dgv1.Columns[col].Name;
            //if (colname == "col_kongbao")
            //{
            //    DataGridViewButtonCell cell = (DataGridViewButtonCell)dgv1.Rows[1].Cells[col];
            //    cell.Style.BackColor = Color.Red;
            //    int a1 = 1;
            //}
            //tabControl1.SelectedTab = tp_list;


            IList<shuadan_records> list = BLL2.shuadan_recordsManager.SearchWeiFaHuo("3");

            if (list.Count > 0)
            {
                shuadan_records sr = null;
                int indexx = 0;
                foreach (shuadan_records sr1 in list)
                {
                    indexx++;
                    bool isok = true;
                    foreach (shuadan_records sr2 in list_kongbao)
                    {
                        if (sr1.sdid == sr2.sdid)
                        {
                            isok = false;
                            break;
                        }
                    }
                    if (isok)
                    {
                        sr = sr1;
                        break;
                    }
                }
                list_kongbao.Add(sr);

                btn_pdd_fahuo.Text = "处理下一个补单_剩余" + (list.Count - indexx + 1).ToString();

                if (sr != null)
                {
                    SendKongBao2(sr);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            webBrowser2.Focus();
            //点击发货
            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('express-import')[0].click()", webBrowser2);


            //点击自己联系物流
            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('tab-border-bottom')[0].click()", webBrowser2);
            Browser.Delay(1000);
            //取消提示框样式
            Browser.JS_CEFBrowser_NoReturn("document.getElementById('single_order_ship_modal').getElementsByTagName('div')[0].setAttribute('class','')", webBrowser2);
            Browser.Delay(500);
            //点击退货地址
            Browser.MouseLeftByHtmlElement("document.getElementsByClassName('pdd-form-input')[2]", 10, 105, webBrowser2);
            Browser.Delay(500);
            //点击退货地址
            Browser.MouseLeftByHtmlElement("document.getElementsByClassName('pdd-form-input')[2]", 10, 180, webBrowser2);
            //Browser.Delay(500);
            //填快递单号
            string temp_order = System.Windows.Forms.Clipboard.GetText();
            Browser.MouseLeftByHtmlElement("document.getElementsByClassName('pdd-form-input')[2]", webBrowser2);
            //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('pdd-form-input')[2].value='" + temp_order + "'", webBrowser2);
            //粘贴
            if (!string.IsNullOrEmpty(temp_order))
                Auto.Ctrl_V();
            //修改状态
            //string state = Browser.JS_CEFBrowser("document.getElementsByClassName('o-d-i-c-span')[0].innerText", webBrowser2);
            //shuadan_records sr=BLL2.shuadan_recordsManager.Search()



            if (sr_temp != new shuadan_records())
            {
                sr_temp.sdremark4 = "2";
                BLL2.shuadan_recordsManager.Update(sr_temp);
                dgv1.DataSource = BLL2.shuadan_recordsManager.SearchWeiFaHuo("3");
                sr_temp = new shuadan_records();
            }

        }



        private void btn_searchdaifa_Click(object sender, EventArgs e)
        {
            searchdaifahuo();
        }

        /// <summary>
        /// 查询代发货
        /// </summary>
        void searchdaifahuo()
        {

            IList<shuadan_records> list = BLL2.shuadan_recordsManager.SearchWeiFaHuo("3");
            dgv1.DataSource = list;
            foreach (shuadan_records sr in list)
            {
                //如果是继续查询模式
                if (switch_pdd != 0)
                {
                    bool ishas = false;
                    //如果是继续查询模式
                    foreach (shuadan_records srs in list_sr)
                    {
                        if (srs.sdorderid == sr.sdorderid)
                        {
                            //跳出
                            ishas = true; ;
                        }
                    }
                    if (ishas == true)
                    {
                        //跳出并继续
                        continue;
                    }
                }


                #region 发空包
                tabControl1.SelectedTab = tp_pdd;
                string temp_orderid = sr.sdorderid;
                CS.PinDuoDuo.GoOrderInfo(sr.sdorderid, webBrowser2);
                //CS.PinDuoDuo.ClickLookPhone_PDD(webBrowser2);


                Browser.WaitWebPageLoad2(XMLHelper_FaHuo.GetValue("PDDElementSendState"), webBrowser2);
                Browser.Delay(500);
                // string state = Browser.JS_CEFBrowser("document.getElementsByClassName('o-d-i-c-span')[2].innerText", "document.getElementsByClassName('o-d-i-c-span')[2]", webBrowser2);
                string state = CaiJi.JsXml("PDDGetSendState", webBrowser2);
                txt_pddstate.Text = txt_pddstate.Text + "+" + state;
                if (string.IsNullOrEmpty(state))
                {
                    MessageBox.Show("订单状态未获取到");
                    return;
                }
                //state=Browser.JS_CEFBrowser_NoReturn
                //string datetemp = Browser.JS_CEFBrowser("document.getElementsByClassName('o-d-i-c-span')[6].innerText", 0, webBrowser2);
                string datetemp = Browser.JS_CEFBrowser("document.getElementsByClassName('o-d-i-c-span')[6].innerText", "document.getElementsByClassName('o-d-i-c-span')[6]", webBrowser2);
                if (state.IndexOf("待发货") > -1)
                {
                    string address = CS.PinDuoDuo.GetOrderAddress_PDD(webBrowser2);
                    sr_temp = sr;
                    if (!string.IsNullOrEmpty(address))
                    {

                        tabControl1.SelectedTab = tp_pddkb;
                        string tempinfo = temp_orderid + "-     " + address + "-     " + state + System.Environment.NewLine + datetemp;
                        txt_kbinfo.Text = tempinfo;
                        kongbaowang_set(address);
                        return;
                    }
                }
                else if (string.IsNullOrEmpty(state))
                {
                    MessageBox.Show("订单信息没有获取到");
                    return;
                }
                else if (state.IndexOf("已发货") > -1)
                {
                    //tabControl1.SelectedTab = tp_list;
                    MessageBox.Show("订单状态异常: " + state);
                    return;
                }
                else
                {
                    list_sr.Add(sr);
                }

                #endregion
            }

            MessageBox.Show("操作完成");
        }

        #region btn_pdd_back_Click
        private void btn_pdd_back_Click(object sender, EventArgs e)
        {
            Browser.JS_CEFBrowser_NoReturn(" window.history.back(-1);  ", webBrowser5);
        }
        #endregion

        #region btn_pddkaiguan_Click

        /// <summary>
        /// 拼多多查询带发空包开关
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_pddkaiguan_Click(object sender, EventArgs e)
        {
            if (switch_pdd == 0)
            {
                switch_pdd = 1;

                btn_pddkaiguan.ForeColor = System.Drawing.Color.Green;
                btn_pddkaiguan.Text = "继续查询模式";
            }
            else
            {
                switch_pdd = 0;
                btn_pddkaiguan.ForeColor = System.Drawing.Color.Red;
                btn_pddkaiguan.Text = "重新查询模式";
                list_sr = new List<shuadan_records>();
            }
        }








        #endregion

        #endregion

        #region 拼多多评价



        private void btn_pddlogin_Click(object sender, EventArgs e)
        {
            Browser.ClearContext(webBrowser3);
            webBrowser5.Load("http://mobile.yangkeduo.com/login.html");
        }

        private void btn_index_Click(object sender, EventArgs e)
        {
            webBrowser5.Load("http://mobile.yangkeduo.com/");
        }

        private void btn_geren_Click(object sender, EventArgs e)
        {
            webBrowser5.Load(" http://mobile.yangkeduo.com/personal.html?refer_page_name=index&refer_page_sn=10002");
        }

        private void btn_pddorders_Click(object sender, EventArgs e)
        {
            webBrowser5.Load("http://mobile.yangkeduo.com/orders.html?type=0&refer_page_name=personal&&refer_page_sn=10001");
        }


        #endregion


        #region 淘宝空包网发货


        private void btn_getorderinfoforkongbao_Click(object sender, EventArgs e)
        {
            int indexx = GetSelectedOrder();
            if (indexx != 10000)
            {
                string codes = GetOrderCode(indexx);
                string address = GetAddress(indexx);
                string info_temp = codes + "," + address;
                Auto.Ctrl_C(info_temp);
            }
        }
        /// <summary>
        /// 登录空包网
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_kongbao_tb_Click(object sender, EventArgs e)
        {
            //http://www.ppq999.com/user/login
            try
            {
                string taobao_url = "http://www.ppq999.com/user/login";
                //淘宝登录方法
                webBrowser3.Load(taobao_url);
                webBrowser3.Focus();
                //if (Browser.WaitWebPageLoad(XMLHelper_FaHuo.GetValue("SetKongBaoBool"), 2000, webBrowser3))
                if (Browser.WaitWebPageLoad(XMLHelper_FaHuo.GetValue("KB_GetBool"), 15000, webBrowser3))
                {
                    Browser.MouseLeftByHtmlElement(XMLHelper_FaHuo.GetValue("KB_GetAccount"), 10, 10, webBrowser3);
                    Auto.Ctrl_V("ourstoryqw");
                    Browser.MouseLeftByHtmlElement(XMLHelper_FaHuo.GetValue("KB_GetPwd"), 10, 10, webBrowser3);
                    Auto.Ctrl_V("zhangjian");

                    //Browser.JS_CEFBrowser_NoReturn(XMLHelper_FaHuo.GetValue("KB_SetAccount"), webBrowser3);
                    //Browser.JS_CEFBrowser_NoReturn(XMLHelper_FaHuo.GetValue("KB_SetPwd"), webBrowser3);
                    Browser.Delay(200);
                    Browser.JS_CEFBrowser_NoReturn(XMLHelper_FaHuo.GetValue("KB_ClickOK"), webBrowser3);
                    //Browser.MouseLeftByHtmlElement("document.getElementById('YanZheng')", webBrowser3);
                    //Browser.MouseLeftByHtmlElement("document.getElementById('YanZheng')", webBrowser3);
                    //Browser.MouseMoveByHtmlElement("document.getElementById('btnReg')", webBrowser3);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine("一块发登录失败" + ex.ToString());

            }
        }






        #endregion



        private void button1_Click(object sender, EventArgs e)
        {

        }


    }


    #region order



    class order
    {
        /// <summary>
        /// 商品名称
        /// </summary>
        private string name;
        /// <summary>
        /// 商品数量
        /// </summary>
        private int num;


        /// <summary>
        /// 商品名称
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }


        /// <summary>
        /// 商品数量
        /// </summary>
        public int Num
        {
            get
            {
                return num;
            }

            set
            {
                num = value;
            }
        }
    }

    #endregion



}
