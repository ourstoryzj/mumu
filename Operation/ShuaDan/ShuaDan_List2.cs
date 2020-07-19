using CefSharp.WinForms;
using Operation.CS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity;
using Common;

namespace Operation.ShuaDan
{
    public partial class ShuaDan_List2 : Form
    {

        CefSharp.WinForms.ChromiumWebBrowser webBrowser1;
        CefSharp.WinForms.ChromiumWebBrowser webBrowser2;
        CefSharp.WinForms.ChromiumWebBrowser webBrowser3;
        CefSharp.WinForms.ChromiumWebBrowser webBrowser4;
        string token;
        string phone;
        /// <summary>
        /// 全选开关
        /// </summary>
        int allselect = 0;

        public ShuaDan_List2()
        {
            InitializeComponent();


            this.StartPosition = FormStartPosition.CenterScreen;
            webBrowser1 = new ChromiumWebBrowser("http://580kongbao.com/login.asp");
            webBrowser1.FrameLoadStart += Browser.BrowserFrameLoadStart;
            webBrowser1.FrameLoadEnd += Browser.BrowserFrameLoadEnd;
            webBrowser1.Size = new Size(1165, 296);
            webBrowser1.Location = new Point(0, 0);
            webBrowser1.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            tabPage1.Controls.Add(webBrowser1);

            webBrowser2 = new ChromiumWebBrowser("http://www.xiaodian.com/user/login?ptp=1.CmymMoKw._head.10.7CLag");
            webBrowser2.FrameLoadStart += Browser.BrowserFrameLoadStart;
            webBrowser2.FrameLoadEnd += Browser.BrowserFrameLoadEnd;
            webBrowser2.Size = new Size(1165, 296);
            webBrowser2.Location = new Point(0, 0);
            webBrowser2.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            tabPage2.Controls.Add(webBrowser2);

            webBrowser3 = new ChromiumWebBrowser("http://580kongbao.com/login.asp");
            webBrowser3.FrameLoadStart += Browser.BrowserFrameLoadStart;
            webBrowser3.FrameLoadEnd += Browser.BrowserFrameLoadEnd;
            webBrowser3.Size = new Size(1165, 296);
            webBrowser3.Location = new Point(0, 0);
            webBrowser3.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            tabPage3.Controls.Add(webBrowser3);

            webBrowser4 = new ChromiumWebBrowser("http://www.guoguo-app.com/");
            webBrowser4.FrameLoadStart += Browser.BrowserFrameLoadStart;
            webBrowser4.FrameLoadEnd += Browser.BrowserFrameLoadEnd;
            webBrowser4.Size = new Size(1165, 296);
            webBrowser4.Location = new Point(0, 0);
            webBrowser4.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            tabPage4.Controls.Add(webBrowser4);

            //绑定数据后不会自动创建列
            dgv_title.AutoGenerateColumns = false;
            //不显示空白行
            dgv_title.AllowUserToAddRows = false;

            txt_date.Text = DateTime.Now.ToString("yyyy-MM-dd");

        }





        #region btn_weifahuo_Click
        private void btn_weifahuo_Click(object sender, EventArgs e)
        {

            string t = cb_type.Text;
            if (t == "蘑菇街")
                t = "1";
            else
            {
                t = "2";
            }
            dgv_title.DataSource = BLL2.shuadan_recordsManager.SearchWeiFaHuo(t);
        }



        #endregion

        #region btn_reset_dgv_Click
        private void btn_reset_dgv_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "请选择";
            cb_fahuo.Text = "请选择";
            cb_kongbao.Text = "请选择";

        }



        #endregion

        #region btn_search_Click
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
            else
                dptype = "";

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

            dgv_title.DataSource = BLL2.shuadan_recordsManager.Search(1, 1000, key, dptype, state_kongbao, state_fahuo, state_shoucai, temp_date2, temp_date2, "");
        }
        #endregion

        #region dateTimePicker1_CloseUp
        private void dateTimePicker1_CloseUp(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Long;
        }
        #endregion

        #region dgv_title_CellContentClick 点击事件
        private void dgv_title_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1)
                {
                    string colname = dgv_title.Columns[e.ColumnIndex].Name;
                    shuadan_records sr = (shuadan_records)dgv_title.CurrentRow.DataBoundItem;

                    //if (dgv_title.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                    //{
                    //}
                    if (colname == "col_kongbao")
                    {
                        #region 发空包
                        //if (sr.sdremark3 == "2")
                        //{
                        //    MessageBox.Show("已经获取单号");
                        //    return;
                        //}

                        //tabControl1.SelectedTab = tabPage1;
                        //webBrowser1.Load("http://580kongbao.com/buykongbao.asp");
                        //if (Browser.WaitWebPageLoad(webBrowser1))
                        //{
                        //    //设置天天快递
                        //    string kuaidivalue = XMLHelper.GetValue("KuaiDiValue_MoGuJie");
                        //    //如果是淘宝
                        //    if (sr.sddptype == "2")
                        //    {
                        //        //设置申通快递
                        //        kuaidivalue = XMLHelper.GetValue("KuaiDiValue_TaoBao");
                        //    }
                        //    Browser.JS_CEFBrowser_NoReturn("jsSelectItemByValue(document.getElementById('typ'),'" + kuaidivalue + "')", webBrowser1);

                        //    //获取收件人信息
                        //    string userinfo = sr.sdaddress.Replace("?", " ");
                        //    Browser.JS_CEFBrowser_NoReturn("document.getElementById('content').value='" + userinfo + "'", webBrowser1);

                        //    //提交订单
                        //    Browser.JS_CEFBrowser_NoReturn("document.getElementById('button').click()", webBrowser1);

                        //    Browser.Delay(1000);

                        //    //弹出提示后按回车
                        //    Auto.Key_Enter();
                        //    Browser.Delay(1000);
                        //    webBrowser1.Load("http://580kongbao.com/waitforsend.asp");
                        //    if (Browser.WaitWebPageLoad(webBrowser1))
                        //    {
                        //        //获取姓名和快递单号
                        //        string name = Browser.JS_CEFBrowser("document.getElementsByClassName('tab2')[0].getElementsByTagName('tr')[1].getElementsByTagName('td')[3].innerText", webBrowser1);
                        //        string wuliu = Browser.JS_CEFBrowser("document.getElementsByClassName('tab2')[0].getElementsByTagName('tr')[1].getElementsByTagName('td')[1].innerText", webBrowser1);
                        //        //如果是对的
                        //        if (userinfo.IndexOf(name) != -1)
                        //        {
                        //            sr.sdwuliu = wuliu;
                        //            sr.sdremark3 = "2";
                        //            BLL2.shuadan_recordsManager.Update(sr);
                        //            //dgv_title.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = wuliu;
                        //            dgv_title.Refresh();

                        //        }
                        //        else
                        //        {
                        //            MessageBox.Show("没有找到该发货信息");
                        //        }
                        //    }

                        //}
                        #endregion
                        fakongbao(sr);
                    }
                    else if (colname == "col_fahuo")
                    {
                        #region 发货

                        //if (sr.sdremark4 == "2")
                        //{
                        //    MessageBox.Show("已经发货");
                        //    return;
                        //}

                        //if (string.IsNullOrEmpty(sr.sdwuliu))
                        //{
                        //    MessageBox.Show("该订单暂无快递单号");
                        //    return;
                        //}

                        ////如果是蘑菇街
                        //if (sr.sddptype == "1")
                        //{
                        //    tabControl1.SelectedTab = tabPage2;
                        //    webBrowser2.Focus();
                        //    webBrowser2.Load("http://www.xiaodian.com/pc/home");
                        //    if (Browser.WaitWebPageLoad(webBrowser2))
                        //    {
                        //        //webBrowser2.Focus();
                        //        //点击订单列表、
                        //        Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.1.$2.1.$0.0')[0].click() ", webBrowser2);
                        //        Browser.Delay(1500);
                        //        //Browser.MouseLeftByHtmlElement(" getElementsByDataReactid('.1.$2.1.$0')[0] ", webBrowser2);
                        //        //Browser.MouseLeftByHtmlElement(" getElementsByDataReactid('.1.$2.1.$0')[0] ", webBrowser2);
                        //        if (Browser.WaitWebPageLoad(webBrowser2))
                        //        {
                        //            webBrowser2.Focus();
                        //            Auto.Clipboard_In(sr.sdorderid);
                        //            //点击订单编号输入框
                        //            Browser.MouseLeftByHtmlElement(" getElementsByDataReactid('.4.1.0.0.0.2.1')[0] ", webBrowser2);
                        //            Browser.MouseLeftByHtmlElement(" getElementsByDataReactid('.4.1.0.0.0.2.1')[0] ", webBrowser2);
                        //            //Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.1.0.0.0.2.1')[0].value='" + sr.sdorderid + "' ", webBrowser2);
                        //            Auto.Ctrl_V();
                        //            //点击查询
                        //            Browser.MouseLeftByHtmlElement(" getElementsByDataReactid('.4.1.0.1.1')[0] ", webBrowser2);
                        //            Browser.MouseLeftByHtmlElement(" getElementsByDataReactid('.4.1.0.1.1')[0] ", webBrowser2);
                        //            Browser.Delay(1500);
                        //            if (Browser.WaitWebPageLoad(webBrowser2))
                        //            {
                        //                //获得订单编号并对比
                        //                string orderid = Browser.JS_CEFBrowser("document.getElementsByClassName('order-num')[0].getElementsByTagName('span')[1].innerText", webBrowser2);
                        //                if (orderid.Trim() == sr.sdorderid.Trim())
                        //                {
                        //                    Debug.WriteLine(orderid);
                        //                    //点击发货
                        //                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.1.0.4.$0.1.1.0:$0.7.0:$0.0')[0].click() ", webBrowser2);
                        //                    //Browser.MouseLeftByHtmlElement(" getElementsByDataReactid('.4.1.0.4.$0.1.1.0:$0.7.0:$0.0')[0] ", webBrowser2);
                        //                    if (Browser.WaitWebPageLoad(webBrowser2))
                        //                    {

                        //                        //点击整单发货
                        //                        Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.3.1.1.0.1.0:$100.3.0.0')[0].click() ", webBrowser2);
                        //                        //Browser.MouseLeftByHtmlElement(" getElementsByDataReactid('.3.1.1.0.1.0:$100.3.0.0')[0] ", webBrowser2);
                        //                        Browser.Delay(500);
                        //                        Auto.Clipboard_In(sr.sdwuliu);
                        //                        //点击快递列表
                        //                        Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('select-arrow')[0].click() ", webBrowser2);
                        //                        //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('select-arrow')[0].click() ", webBrowser2);
                        //                        //点击要发货的快递
                        //                        Browser.JS_CEFBrowser_NoReturn(" document.getElementsByName('liname1')[" + XMLHelper.GetValue("MoGuJie_KuaiDiID") + "].click() ", webBrowser2);
                        //                        //输入快递单号
                        //                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('mc-text-input')[0].value='" + sr.sdwuliu + "'", webBrowser2);
                        //                        //点击发货
                        //                        Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('xd-btn')[0].click() ", webBrowser2);

                        //                        //显示已经发货
                        //                        sr.sdremark4 = "2";
                        //                        BLL2.shuadan_recordsManager.Update(sr);
                        //                        dgv_title.Refresh();
                        //                    }
                        //                }
                        //                else
                        //                {
                        //                    MessageBox.Show("订单信息错误");
                        //                }
                        //            }
                        //        }
                        //    }
                        //}

                        #endregion
                        fahuo(sr);
                    }
                    else if (colname == "col_del")
                    {
                        #region 删除


                        DialogResult resault = MessageBox.Show("确定要删除么？", "删除", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        if (resault == DialogResult.OK)
                        {
                            if (BLL2.shuadan_recordsManager.Delete(sr.sdid) == 1)
                            {
                                MessageBox.Show("删除成功");
                                //dgv_title.Rows[e.RowIndex].Visible = false;
                                List<shuadan_records> list = (List<shuadan_records>)dgv_title.DataSource;
                                list.Remove(sr);
                                dgv_title.DataSource = null;
                                dgv_title.DataSource = list;
                                //dgv_title.Refresh();
                            }
                            else
                            {
                                MessageBox.Show("删除失败");
                            }
                        }
                        #endregion
                    }

                    else if (colname == "col_wuliu")
                    {
                        #region 查快递

                        if (!string.IsNullOrEmpty(sr.sdwuliu))
                        {
                            tabControl1.SelectedTab = tabPage4;
                            webBrowser4.Focus();
                            webBrowser4.Load("http://www.guoguo-app.com/");
                            if (Browser.WaitWebPageLoad(webBrowser4))
                            {
                                Browser.JS_CEFBrowser_NoReturn("document.getElementById('J_SearchInput').value='" + sr.sdwuliu + "'", webBrowser4);
                                Browser.JS_CEFBrowser_NoReturn("document.getElementById('J_SearchBtn').click()", webBrowser4);

                            }
                        }

                        #endregion
                    }
                    else if (colname == "col_kongbao2")
                    {
                        #region 发空包
                        sr.sdremark3 = sr.sdremark3 == "1" ? "2" : "1";
                        BLL2.shuadan_recordsManager.Update(sr);
                        dgv_title.Refresh();
                        #endregion
                    }
                    else if (colname == "col_fahuo2")
                    {
                        #region 发货
                        sr.sdremark4 = sr.sdremark4 == "1" ? "2" : "1";
                        BLL2.shuadan_recordsManager.Update(sr);
                        dgv_title.Refresh();
                        #endregion
                    }
                    else if (colname == "col_shoucai")
                    {
                        #region 收菜
                        sr.sdremark2 = sr.sdremark2 == "1" ? "2" : (sr.sdremark2 == "2" ? "3" : "1");
                        BLL2.shuadan_recordsManager.Update(sr);
                        dgv_title.Refresh();
                        #endregion
                    }
                    else if (colname == "col_orderid")
                    {
                        #region 复制订单编号
                        Auto.Clipboard_In(sr.sdorderid);
                        #endregion
                    }
                    else if (colname == "col_phone")
                    {
                        #region 复制手机号码
                        Auto.Clipboard_In(sr.sdphone);
                        #endregion
                    }
                    else if (colname == "col_shoucaiphone")
                    {
                        #region 指定手机号码收菜

                        token = MessageAPI.GetToken();
                        Auto.Clipboard_In(sr.sdphone);
                        txt_phone.Text = sr.sdphone;
                        string res = MessageAPI.GetPhone(token, sr.sdphone);
                        txt_phone.Text = res;
                        phone = res;
                        if (res == sr.sdphone)
                        {
                            sr.sdremark2 = "2";
                            tabControl2.SelectedTab = tabPage6;
                        }
                        else
                        {
                            sr.sdremark2 = "3";
                            sr.sdremark5 = res;
                        }
                        BLL2.shuadan_recordsManager.Update(sr);
                        dgv_title.Refresh();
                        MessageBox.Show(res);
                        #endregion
                    }

                }
                else if (e.RowIndex == -1)
                {
                    #region 全选
                    //如果是全选
                    if (e.ColumnIndex == 0)
                    {
                        foreach (DataGridViewRow row in dgv_title.Rows)
                        {
                            if (row.Index != -1)
                            {
                                DataGridViewCheckBoxCell cbx = (DataGridViewCheckBoxCell)row.Cells[0];
                                cbx.Value = allselect == 0 ? true : false;
                            }
                        }
                        allselect = allselect == 1 ? 0 : 1;
                    }
                    //else
                    //{
                    //    try
                    //    {
                    //        //dgv_title.Sort(dgv_title.Columns[e.ColumnIndex], ListSortDirection.Descending);
                    //    }
                    //    catch (Exception ex)
                    //    {
                    //        Debug.WriteLine("排序出错=========================" + ex.Message);
                    //    }
                    //}
                    #endregion
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region dgv_title_RowPostPaint 
        private void dgv_title_RowPostPaint_1(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //添加行号
            SolidBrush b = new SolidBrush(this.dgv_title.RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), this.dgv_title.DefaultCellStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 10);

        }
        #endregion

        #region btn_login_fahuo_Click
        private void btn_login_fahuo_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
            webBrowser1.Load("http://580kongbao.com/login.asp");
            webBrowser1.Focus();
            if (Browser.WaitWebPageLoad(webBrowser1))
            {
                string access = XMLHelper.GetValue("KongBao_Access");
                string pwd = XMLHelper.GetValue("KongBao_Pwd");


                if (!string.IsNullOrEmpty(access))
                {
                    webBrowser1.Focus();
                    Browser.JS_CEFBrowser_NoReturn(" document.getElementById('username').value= '" + access + "'", webBrowser1);
                }
                if (!string.IsNullOrEmpty(pwd))
                {
                    webBrowser1.Focus();
                    Browser.JS_CEFBrowser_NoReturn(" document.getElementById('userpassword').value=  '" + pwd + "'", webBrowser1);
                    Browser.MouseLeftByHtmlElement(" document.getElementById('checkcode') ", webBrowser1);

                }

            }
        }
        #endregion

        #region  dgv_title_CellFormatting 动态显示单元格的值
        private void dgv_title_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.Value != null)
                {
                    if (dgv_title.DataSource != null)
                    {


                        if (dgv_title.Columns[e.ColumnIndex].Name.Equals("col_shoptype"))
                        {
                            string name = e.Value.ToString();
                            if (name == "1")
                            {
                                e.Value = "蘑菇街";
                                e.CellStyle.ForeColor = Color.Green;
                            }
                            else
                            {
                                e.Value = "淘宝";
                                e.CellStyle.ForeColor = Color.Blue;
                            }
                        }
                        if (dgv_title.Columns[e.ColumnIndex].Name.Equals("col_kongbao"))
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
                        if (dgv_title.Columns[e.ColumnIndex].Name.Equals("col_fahuo"))
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
                        if (dgv_title.Columns[e.ColumnIndex].Name.Equals("col_kongbao2"))
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
                        if (dgv_title.Columns[e.ColumnIndex].Name.Equals("col_fahuo2"))
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
                        if (dgv_title.Columns[e.ColumnIndex].Name.Equals("col_shoucai"))
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

        #region dgv_title_CellParsing 数据修改
        private void dgv_title_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            try
            {
                //int i = dgv_title.CurrentCell.ColumnIndex;
                string colname = dgv_title.Columns[dgv_title.CurrentCell.ColumnIndex].Name;

                //if (dgv_title.CurrentCell.ColumnIndex == 1 || dgv_title.CurrentCell.ColumnIndex == 2 || dgv_title.CurrentCell.ColumnIndex == 3 || dgv_title.CurrentCell.ColumnIndex == 4 || dgv_title.CurrentCell.ColumnIndex == 7)

                if (colname.Equals("col_phone") || colname.Equals("col_orderid") || colname.Equals("col_wuliu") || colname.Equals("col_vpn") || colname.Equals("col_address") || colname.Equals("col_remark"))
                {
                    shuadan_records og = (shuadan_records)dgv_title.CurrentRow.DataBoundItem;
                    if (og != null)
                    {
                        //string phone = dgv_title.Rows[e.RowIndex].Cells[4].EditedFormattedValue == null ? "" : dgv_title.Rows[e.RowIndex].Cells[4].EditedFormattedValue.ToString();
                        //string orderid = dgv_title.Rows[e.RowIndex].Cells[5].EditedFormattedValue == null ? "" : dgv_title.Rows[e.RowIndex].Cells[5].EditedFormattedValue.ToString();
                        //string wuliu = dgv_title.Rows[e.RowIndex].Cells[6].EditedFormattedValue == null ? "" : dgv_title.Rows[e.RowIndex].Cells[6].EditedFormattedValue.ToString();
                        //string remark = dgv_title.Rows[e.RowIndex].Cells[12].EditedFormattedValue == null ? "" : dgv_title.Rows[e.RowIndex].Cells[12].EditedFormattedValue.ToString();
                        //string vpnadd = dgv_title.Rows[e.RowIndex].Cells[13].EditedFormattedValue == null ? "" : dgv_title.Rows[e.RowIndex].Cells[13].EditedFormattedValue.ToString();
                        //string dates = dgv_title.Rows[e.RowIndex].Cells[14].EditedFormattedValue == null ? "" : dgv_title.Rows[e.RowIndex].Cells[14].EditedFormattedValue.ToString();
                        //string goodsname = dgv_title.Rows[e.RowIndex].Cells[15].EditedFormattedValue == null ? "" : dgv_title.Rows[e.RowIndex].Cells[15].EditedFormattedValue.ToString();
                        //string address = dgv_title.Rows[e.RowIndex].Cells[16].EditedFormattedValue == null ? "" : dgv_title.Rows[e.RowIndex].Cells[16].EditedFormattedValue.ToString();

                        string phone = dgv_title["col_phone", e.RowIndex].EditedFormattedValue == null ? "" : dgv_title["col_phone", e.RowIndex].EditedFormattedValue.ToString();
                        string orderid = dgv_title["col_orderid", e.RowIndex].EditedFormattedValue == null ? "" : dgv_title["col_orderid", e.RowIndex].EditedFormattedValue.ToString();
                        string wuliu = dgv_title["col_wuliu", e.RowIndex].EditedFormattedValue == null ? "" : dgv_title["col_wuliu", e.RowIndex].EditedFormattedValue.ToString();
                        string remark = dgv_title["col_remark", e.RowIndex].EditedFormattedValue == null ? "" : dgv_title["col_remark", e.RowIndex].EditedFormattedValue.ToString();
                        string vpnadd = dgv_title["col_vpn", e.RowIndex].EditedFormattedValue == null ? "" : dgv_title["col_vpn", e.RowIndex].EditedFormattedValue.ToString();
                        //string dates = dgv_title["col_phone", e.RowIndex].EditedFormattedValue == null ? "" : dgv_title["col_phone", e.RowIndex].EditedFormattedValue.ToString();
                        //string goodsname = dgv_title["col_phone", e.RowIndex].EditedFormattedValue == null ? "" : dgv_title["col_phone", e.RowIndex].EditedFormattedValue.ToString();
                        string address = dgv_title["col_address", e.RowIndex].EditedFormattedValue == null ? "" : dgv_title["col_address", e.RowIndex].EditedFormattedValue.ToString();



                        og.sdaddress = address;
                        og.sdorderid = orderid;
                        og.sdphone = phone;
                        og.sdvpn = vpnadd;
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

        #region btn_login_mogujie_Click
        private void btn_login_mogujie_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
            webBrowser2.Focus();
            webBrowser2.Load("http://www.xiaodian.com/user/login?ptp=1.CmymMoKw._head.10.7CLag");
            if (Browser.WaitWebPageLoad(webBrowser2))
            {
                string acc = XMLHelper.GetValue("MoGuJie_Access");
                string pwd = XMLHelper.GetValue("MoGuJie_Pwd");
                Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('input')[0].value='" + acc + "'", webBrowser2);
                Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('input')[1].value='" + pwd + "'", webBrowser2);
            }
        }


        #endregion

        #region btn_getphone_Click 
        private void btn_getphone_Click(object sender, EventArgs e)
        {
            token = MessageAPI.GetToken();
            if (string.IsNullOrEmpty(phone))
            {
                MessageAPI.AddBlack(token, phone);
                MessageAPI.ClearPhone(token, phone);
            }
            string res = MessageAPI.GetPhone(token);
            txt_phone.Text = res;
            phone = res;
            Auto.Clipboard_In(res);
        }

        #endregion

        #region btn_phone_open_Click
        private void btn_phone_open_Click(object sender, EventArgs e)
        {
            string p = txt_phone.Text.Trim();
            Auto.Clipboard_In(p);
            string res = MessageAPI.GetPhone(token, p);
            txt_phone.Text = res;
            phone = res;
            MessageBox.Show(res);
        }

        #endregion

        #region btn_Phone_Click


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
            res = Mogujie.getYanZhengMa(res);
            Auto.Clipboard_In(res);
            //webBrowser2.Focus();
            //Browser.JS_CEFBrowser_NoReturn("document.getElementsByName('telcode')[0].value=" + getYanZhengMa(res), webBrowser2);
            ////MessageBox.Show(getYanZhengMa(res));
            //Browser.Delay(1000);
            //Browser.MouseLeftByHtmlElement("document.getElementsByClassName('sub')[0]", webBrowser2);18675992431
            btn_Phone.Enabled = true;
            //txt_yanzhengma.Text = res + " 如需再次获取验证码，请5秒后操作 " + Manager.RandomNumber(1000, 99999).ToString();
            //MessageBox.Show("如需再次获取验证码，请5秒后操作");
        }
























        #endregion

        #region txt_phone_MouseDown
        private void txt_phone_MouseDown(object sender, MouseEventArgs e)
        {
            string p = txt_phone.Text.Trim();
            Auto.Clipboard_In(p);
        }

        #endregion

        #region txt_yanzhengma_MouseDown

        private void txt_yanzhengma_MouseDown(object sender, MouseEventArgs e)
        {
            string res = txt_yanzhengma.Text;
            res = Mogujie.getYanZhengMa(res);
            Auto.Clipboard_In(res);
        }
        #endregion

        #region btn_save_Click
        private void btn_save_Click(object sender, EventArgs e)
        {
            string p = txt_savephone.Text;
            webBrowser2.Load("http://order.xiaodian.com/pc/trade/order/list/list4seller");
            //如果没有手机号
            if (string.IsNullOrEmpty(p))
            {
                //document.getElementsByClassName('tab-hover2')[0].click()
                if (Browser.WaitWebPageLoad2("document.getElementsByClassName('tab-hover2')[0]", webBrowser2))
                {
                    //点击等待发货
                    Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('tab-hover2')[0].click()", webBrowser2);

                }
            }
            else
            {
                //如果有手机号
                if (Browser.WaitWebPageLoad2("document.getElementsByClassName('xd-input')[3]", webBrowser2))
                {
                    //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('xd-input')[3].value=" + p, webBrowser2);
                    Browser.MouseLeftByHtmlElement("document.getElementsByClassName('xd-input')[3]", webBrowser2);
                    Browser.MouseLeftByHtmlElement("document.getElementsByClassName('xd-input')[3]", webBrowser2);
                    Auto.Clipboard_In(p);
                    Auto.Ctrl_V();
                    Browser.Delay(500);
                    //点击等待发货
                    Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('xd-btn')[1].click()", webBrowser2);
                }
            }
            Browser.Delay(2000);

            string temp = Browser.JS_CEFBrowser("document.getElementsByClassName('no-result')[0]!=null", webBrowser1);
            if (!string.IsNullOrEmpty(temp) && temp == "True")
            {

                MessageBox.Show("没有找到该订单");
                return;
            }

            Entity.shuadan_records sd = new Entity.shuadan_records();
            sd.sdaddress = Browser.JS_CEFBrowser("document.getElementsByClassName('copy_address')[0].getAttribute('data-clipboard-text')", webBrowser2) + ",000000";
            string temp_date = Browser.JS_CEFBrowser("document.getElementsByClassName('order-date')[0].getElementsByTagName('span')[1].innerText", webBrowser2);
            DateTime dt = new DateTime();
            DateTime.TryParse(temp_date, out dt);
            sd.sddate = dt;
            sd.sddptype = "1";
            sd.sdgoodsname = Browser.JS_CEFBrowser("document.getElementsByClassName('g-title')[0].getElementsByTagName('span')[0].innerText", webBrowser2);
            sd.sdgoodsurl = Browser.JS_CEFBrowser("document.getElementsByClassName('g-title')[0].href", webBrowser2); ;
            sd.sdorderid = Browser.JS_CEFBrowser("document.getElementsByClassName('order-num')[0].getElementsByTagName('span')[1].innerText", webBrowser2); ;
            sd.sdphone = phone;
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

        }
        #endregion

        #region btn_save2_Click


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
                MessageBox.Show("请输入正确的时间");
                txt_date.Focus();
                return;
            }

            if (shoptype == "蘑菇街")
            {
                shoptype = "1";
            }
            else
            {
                shoptype = "2";
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



            if (BLL2.shuadan_recordsManager.Insert(sd) == 1)
            {
                MessageBox.Show("保存成功");
            }

        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            txt_address.Clear();
            txt_date.Clear();
            txt_goodsname.Clear();
            txt_orderid.Clear();
            txt_phone2.Clear();
            txt_vpnadd.Clear();
            txt_wuliu.Clear();
            txt_url.Clear();
            cb_fahuo2.Text = "未发货";
            cb_kongbao2.Text = "未获取";
            cb_shoptype.Text = "蘑菇街";
            cb_shoucai2.Text = "未收菜";
            txt_date.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }
        #endregion

        #region  btn_fahuo_Click
        /// <summary>
        /// 根据多选批量发货
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_fahuo_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否要批量发货?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    foreach (DataGridViewRow row in dgv_title.Rows)
                    {
                        if (row.Index != -1)
                        {
                            DataGridViewCheckBoxCell cbx = (DataGridViewCheckBoxCell)row.Cells[0];
                            if ((bool)cbx.FormattedValue)
                            {
                                //如果选中
                                //string temp_1 = ((DataRowView)row.DataBoundItem)[0].ToString();
                                //shuadan_records sr = (shuadan_records)dgv_title.CurrentRow.DataBoundItem;
                                shuadan_records sr = (shuadan_records)row.DataBoundItem;
                                //int temp_id = 0;
                                //if (int.TryParse(temp_1, out temp_id))
                                //{
                                //shuadan_records sr = BLL2.shuadan_recordsManager.SearchByID(temp_id);
                                fakongbao(sr);
                                fahuo(sr);
                                dgv_title.Refresh();

                                //}
                            }
                        }
                    }
                    MessageBox.Show("批量发货完成");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        #endregion

        #region fakongbao发空包

        void fakongbao(shuadan_records sr)
        {
            if (sr.sdremark3 == "2")
            {
                MessageBox.Show("已经获取单号");
                return;
            }

            tabControl1.SelectedTab = tabPage1;
            webBrowser1.Load("http://580kongbao.com/buykongbao.asp");
            if (Browser.WaitWebPageLoad(webBrowser1))
            {
                //设置天天快递
                string kuaidivalue = XMLHelper.GetValue("KuaiDiValue_MoGuJie");
                //如果是淘宝
                if (sr.sddptype == "2")
                {
                    //设置申通快递
                    kuaidivalue = XMLHelper.GetValue("KuaiDiValue_TaoBao");
                }
                Browser.JS_CEFBrowser_NoReturn("jsSelectItemByValue(document.getElementById('typ'),'" + kuaidivalue + "')", webBrowser1);

                //获取收件人信息
                string userinfo = sr.sdaddress.Replace("?", " ");
                Browser.JS_CEFBrowser_NoReturn("document.getElementById('content').value='" + userinfo + "'", webBrowser1);

                //提交订单
                Browser.JS_CEFBrowser_NoReturn("document.getElementById('button').click()", webBrowser1);

                Browser.Delay(1000);

                //弹出提示后按回车
                Auto.Key_Enter();
                Browser.Delay(1000);
                webBrowser1.Load("http://580kongbao.com/waitforsend.asp");
                if (Browser.WaitWebPageLoad(webBrowser1))
                {
                    //获取姓名和快递单号
                    string name = Browser.JS_CEFBrowser("document.getElementsByClassName('tab2')[0].getElementsByTagName('tr')[1].getElementsByTagName('td')[3].innerText", webBrowser1);
                    string wuliu = Browser.JS_CEFBrowser("document.getElementsByClassName('tab2')[0].getElementsByTagName('tr')[1].getElementsByTagName('td')[1].innerText", webBrowser1);
                    //如果是对的
                    if (userinfo.IndexOf(name) != -1)
                    {
                        sr.sdwuliu = wuliu;
                        sr.sdremark3 = "2";
                        BLL2.shuadan_recordsManager.Update(sr);
                        //dgv_title.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = wuliu;
                        dgv_title.Refresh();

                    }
                    else
                    {
                        MessageBox.Show("没有找到该发货信息");
                    }
                }

            }

        }
        #endregion

        #region 发货
        void fahuo(shuadan_records sr)
        {
            if (sr.sdremark4 == "2")
            {
                MessageBox.Show("已经发货");
                return;
            }

            if (string.IsNullOrEmpty(sr.sdwuliu))
            {
                MessageBox.Show("该订单暂无快递单号");
                return;
            }

            //如果是蘑菇街
            if (sr.sddptype == "1")
            {
                tabControl1.SelectedTab = tabPage2;
                webBrowser2.Focus();
                webBrowser2.Load("http://www.xiaodian.com/pc/home");
                if (Browser.WaitWebPageLoad(webBrowser2))
                {
                    //webBrowser2.Focus();
                    //点击订单列表、
                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.1.$2.1.$0.0')[0].click() ", webBrowser2);
                    Browser.Delay(1500);
                    //Browser.MouseLeftByHtmlElement(" getElementsByDataReactid('.1.$2.1.$0')[0] ", webBrowser2);
                    //Browser.MouseLeftByHtmlElement(" getElementsByDataReactid('.1.$2.1.$0')[0] ", webBrowser2);
                    if (Browser.WaitWebPageLoad(webBrowser2))
                    {
                        webBrowser2.Focus();
                        Auto.Clipboard_In(sr.sdorderid);
                        //点击订单编号输入框
                        Browser.MouseLeftByHtmlElement(" getElementsByDataReactid('.4.1.0.0.0.2.1')[0] ", webBrowser2);
                        Browser.MouseLeftByHtmlElement(" getElementsByDataReactid('.4.1.0.0.0.2.1')[0] ", webBrowser2);
                        //Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.1.0.0.0.2.1')[0].value='" + sr.sdorderid + "' ", webBrowser2);
                        Auto.Ctrl_V();
                        //点击查询
                        Browser.MouseLeftByHtmlElement(" getElementsByDataReactid('.4.1.0.1.1')[0] ", webBrowser2);
                        Browser.MouseLeftByHtmlElement(" getElementsByDataReactid('.4.1.0.1.1')[0] ", webBrowser2);
                        Browser.Delay(1500);
                        if (Browser.WaitWebPageLoad(webBrowser2))
                        {
                            //获得订单编号并对比
                            string orderid = Browser.JS_CEFBrowser("document.getElementsByClassName('order-num')[0].getElementsByTagName('span')[1].innerText", webBrowser2);
                            if (orderid.Trim() == sr.sdorderid.Trim())
                            {
                                Debug.WriteLine(orderid);
                                //点击发货
                                Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.1.0.4.$0.1.1.0:$0.7.0:$0.0')[0].click() ", webBrowser2);
                                //Browser.MouseLeftByHtmlElement(" getElementsByDataReactid('.4.1.0.4.$0.1.1.0:$0.7.0:$0.0')[0] ", webBrowser2);
                                if (Browser.WaitWebPageLoad(webBrowser2))
                                {

                                    //点击整单发货
                                    Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.3.1.1.0.1.0:$100.3.0.0')[0].click() ", webBrowser2);
                                    //Browser.MouseLeftByHtmlElement(" getElementsByDataReactid('.3.1.1.0.1.0:$100.3.0.0')[0] ", webBrowser2);
                                    Browser.Delay(500);
                                    Auto.Clipboard_In(sr.sdwuliu);
                                    //点击快递列表
                                    Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('select-arrow')[0].click() ", webBrowser2);
                                    //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('select-arrow')[0].click() ", webBrowser2);
                                    //点击要发货的快递
                                    Browser.JS_CEFBrowser_NoReturn(" document.getElementsByName('liname1')[" + XMLHelper.GetValue("MoGuJie_KuaiDiID") + "].click() ", webBrowser2);
                                    //输入快递单号
                                    //Browser.JS_CEFBrowser_NoReturn("document.getElementById('field_1').value='" + sr.sdwuliu + "'", webBrowser2);
                                    Auto.Clipboard_In(sr.sdwuliu);
                                    //Browser.MouseLeftByHtmlElement("document.getElementById('field_1')", webBrowser2);
                                    //Browser.MouseLeftByHtmlElement("document.getElementById('field_1')", webBrowser2);
                                    //Point p = Browser.GetPointScreenByHtmlElement("document.getElementById('field_1')", webBrowser2);
                                    //Debug.WriteLine(p.ToString());
                                    //return;
                                    //p.Offset(0,100);

                                    Point p = webBrowser2.PointToScreen(new Point(0, 0));
                                    //计算空间位置
                                    int h_temp=webBrowser2.Height / 2 + 138;
                                    p.Offset(760, h_temp);
                                    Cursor.Position = p;
                                    Auto.Mouse_Left();
                                    Browser.Delay(100);
                                    Auto.Ctrl_V();
                                    Browser.Delay(200);
                                    //点击发货
                                    Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('xd-btn')[0].click() ", webBrowser2);

                                    //显示已经发货
                                    sr.sdremark4 = "2";
                                    BLL2.shuadan_recordsManager.Update(sr);
                                    dgv_title.Refresh();
                                }
                            }
                            else
                            {
                                MessageBox.Show("订单信息错误");
                            }
                        }
                    }
                }
            }
        }








        #endregion

        private void btn_test_Click(object sender, EventArgs e)
        {
            string str = txt_savephone.Text;
            MessageBox.Show(Mogujie.getYanZhengMa(str));
        }
    }



}
