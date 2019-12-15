using CefSharp.WinForms;
using excel_operation.CS;
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

namespace excel_operation.ShuaDan
{
    public partial class ShuaDan_List : Form
    {

        CefSharp.WinForms.ChromiumWebBrowser webBrowser1;
        CefSharp.WinForms.ChromiumWebBrowser webBrowser2;
        CefSharp.WinForms.ChromiumWebBrowser webBrowser3;
        CefSharp.WinForms.ChromiumWebBrowser webBrowser4;

        public ShuaDan_List()
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
                        #endregion
                    }
                    else if (colname == "col_fahuo")
                    {
                        #region 发货

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
                                                Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('select-arrow')[0].click() ", webBrowser2);
                                                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('select-arrow')[0].click() ", webBrowser2);
                                                Browser.JS_CEFBrowser("document.getElementsByClassName('mc-text-input')[0].value='" + sr.sdwuliu + "'", webBrowser2);

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

                        #endregion
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



                }
                #region 全选


                /*
                else if (e.RowIndex == -1)
                {
                    //如果是全选
                    if (e.ColumnIndex == 0)
                    {
                        //foreach (DataGridViewRow row in dgv_title.Rows)
                        //{
                        //    if (row.Index != -1)
                        //    {
                        //        DataGridViewCheckBoxCell cbx = (DataGridViewCheckBoxCell)row.Cells[0];
                        //        cbx.Value = allselect == 0 ? true : false;
                        //    }
                        //}
                        //allselect = allselect == 1 ? 0 : 1;
                    }
                    else
                    {
                        try
                        {
                            //dgv_title.Sort(dgv_title.Columns[e.ColumnIndex], ListSortDirection.Descending);
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine("排序出错=========================" + ex.Message);
                        }
                    }
                }*/
                #endregion
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
                        string phone = dgv_title.Rows[e.RowIndex].Cells[2].EditedFormattedValue == null ? "" : dgv_title.Rows[e.RowIndex].Cells[2].EditedFormattedValue.ToString();
                        string orderid = dgv_title.Rows[e.RowIndex].Cells[3].EditedFormattedValue == null ? "" : dgv_title.Rows[e.RowIndex].Cells[3].EditedFormattedValue.ToString();
                        string wuliu = dgv_title.Rows[e.RowIndex].Cells[4].EditedFormattedValue == null ? "" : dgv_title.Rows[e.RowIndex].Cells[4].EditedFormattedValue.ToString();
                        string remark = dgv_title.Rows[e.RowIndex].Cells[10].EditedFormattedValue == null ? "" : dgv_title.Rows[e.RowIndex].Cells[10].EditedFormattedValue.ToString();
                        string vpnadd = dgv_title.Rows[e.RowIndex].Cells[11].EditedFormattedValue == null ? "" : dgv_title.Rows[e.RowIndex].Cells[11].EditedFormattedValue.ToString();
                        string dates = dgv_title.Rows[e.RowIndex].Cells[12].EditedFormattedValue == null ? "" : dgv_title.Rows[e.RowIndex].Cells[12].EditedFormattedValue.ToString();
                        string goodsname = dgv_title.Rows[e.RowIndex].Cells[13].EditedFormattedValue == null ? "" : dgv_title.Rows[e.RowIndex].Cells[13].EditedFormattedValue.ToString();
                        string address = dgv_title.Rows[e.RowIndex].Cells[14].EditedFormattedValue == null ? "" : dgv_title.Rows[e.RowIndex].Cells[14].EditedFormattedValue.ToString();


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



    }
}
