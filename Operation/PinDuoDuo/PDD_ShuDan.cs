using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using excel_operation.CS;
using System.Diagnostics;
using System.Threading;

namespace excel_operation.PinDuoDuo
{

    public partial class PDD_ShuDan : Form
    {

        CefSharp.WinForms.ChromiumWebBrowser webBrowser1;
        CefSharp.WinForms.ChromiumWebBrowser webBrowser2;

        public PDD_ShuDan()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            webBrowser1 = new ChromiumWebBrowser("http://www.ema666.com/Login.html");
            webBrowser1.FrameLoadStart += Browser.BrowserFrameLoadStart;
            webBrowser1.FrameLoadEnd += Browser.BrowserFrameLoadEnd;
            webBrowser1.Size = new Size(1000, 734);
            webBrowser1.Location = new Point(0, 0);
            webBrowser1.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            tabPage1.Controls.Add(webBrowser1);

            webBrowser2 = new ChromiumWebBrowser("http://www.baidu.com");
            webBrowser2.FrameLoadStart += Browser.BrowserFrameLoadStart;
            webBrowser2.FrameLoadEnd += Browser.BrowserFrameLoadEnd;
            webBrowser2.Size = new Size(1000, 734);
            webBrowser2.Location = new Point(0, 0);
            webBrowser2.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            tabPage3.Controls.Add(webBrowser2);


            //绑定数据后不会自动创建列
            dgv_title.AutoGenerateColumns = false;
            //不显示空白行
            dgv_title.AllowUserToAddRows = false;

            //激活第二个浏览器
            tag_control.SelectedTab = tabPage3;
            webBrowser2.Focus();
            Browser.Delay(500);
            tag_control.SelectedTab = tabPage1;
            webBrowser1.Focus();

        }


        #region btn_Phone_Click
        private void btn_Phone_Click(object sender, EventArgs e)
        {
            tag_control.SelectedTab = tabPage1;
            webBrowser1.Load("http://www.ema666.com/Login.html");
            if (Browser.WaitWebPageLoad(webBrowser1))
            {
                string access = XMLHelper.GetValue("PhoneCode_Access");
                string pwd = XMLHelper.GetValue("PhoneCode_Pwd");
                if (!string.IsNullOrEmpty(access))
                {
                    webBrowser1.Focus();
                    //Auto.Clipboard_In(access);
                    Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('lon')[0].value= '" + access + "'", webBrowser1);
                    //Auto.Ctrl_V(100);
                }
                if (!string.IsNullOrEmpty(pwd))
                {
                    webBrowser1.Focus();
                    //Auto.Clipboard_In(pwd);
                    Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('lon')[1].value=  '" + pwd + "'", webBrowser1);
                    //Auto.Ctrl_V(100);
                    Browser.MouseLeftByHtmlElement(" document.getElementsByClassName('lon')[2] ", webBrowser1);

                }
            }

        }
        #endregion

        #region btn_getphone_Click

        private void btn_getphone_Click(object sender, EventArgs e)
        {
            tag_control.SelectedTab = tabPage1;
            //http://www.ema666.com/userManage/GetCode.aspx
            webBrowser1.Load("http://www.ema666.com/userManage/GetCode.aspx");
            webBrowser1.Focus();
            if (Browser.WaitWebPageLoad(webBrowser1))
            {
                Browser.JS_CEFBrowser_NoReturn("document.getElementById('mobSelect').value='1'", webBrowser1);
                Browser.JS_CEFBrowser_NoReturn("document.getElementById('btnGetPhoneId').click()", webBrowser1);
                //Browser.MouseLeftByHtmlElement(" document.getElementById('btnGetPhoneId') ", webBrowser1);
                Browser.Delay(1000);
                string phone = Browser.JS_CEFBrowser(" document.getElementById('txtPhone').value ", webBrowser1);
                if (!string.IsNullOrEmpty(phone))
                {
                    txt_phone.Text = phone;
                }
            }
        }

        #endregion






        #region btn_ip_Click
        private void btn_ip_Click(object sender, EventArgs e)
        {
            tag_control.SelectedTab = tabPage3;
            webBrowser2.Focus();
            Browser.Delay(500);
            webBrowser2.Load("https://www.baidu.com/s?ie=UTF-8&wd=ip");
            if (Browser.WaitWebPageLoad(webBrowser2))
            {
                string ipadd = Browser.JS_CEFBrowser(" getClassName('op-ip-detail')[0].innerText ", webBrowser2);
                if (!string.IsNullOrEmpty(ipadd))
                {
                    txt_ip.Text = ipadd;
                }
            }

        }
        #endregion



        #region btn_save_Click
        private void btn_save_Click(object sender, EventArgs e)
        {
            //myorder
            tag_control.SelectedTab = tabPage3;
            webBrowser2.Focus();
            Browser.Delay(500);

            if (Browser.WaitWebPageLoad(webBrowser2))
            {

                ////点击订单详情
                //Browser.MouseLeftByHtmlElement("document.getElementsByClassName('go-detail-link')[0]", webBrowser2);
                //if (Browser.WaitWebPageLoad(webBrowser2))
                //{
                    //获取订单编号
                    //string orderid = Browser.JS_CEFBrowser("document.getElementsByClassName('mw')[0].innerText", webBrowser2);
                    //orderid = orderid.Replace("订单编号:", "");
                    //orderid = orderid.Trim();
                    ////订单时间
                    //string orderdate = Browser.JS_CEFBrowser("document.getElementsByClassName('md_process_tip_bt')[0].innerText", webBrowser2);
                    ////获取收件人姓名
                    //string ordername = Browser.JS_CEFBrowser("document.getElementsByClassName('mu_d_infolist')[0].getElementsByTagName('dd')[0].innerText", webBrowser2);
                    ////获取收件人地址
                    //string orderaddress = Browser.JS_CEFBrowser("document.getElementsByClassName('mu_d_infolist')[0].getElementsByTagName('dd')[1].innerText", webBrowser2);
                    ////获取收件人邮编
                    //string orderyoubian = Browser.JS_CEFBrowser("document.getElementsByClassName('mu_d_infolist')[0].getElementsByTagName('dd')[2].innerText", webBrowser2);
                    ////获取收件人电话
                    ////string orderphone = Browser.JS_CEFBrowser("document.getElementsByClassName('mu_d_infolist')[0].getElementsByTagName('dd')[3].innerText", webBrowser2);
                    //string orderphone = txt_phone.Text.Trim();
                    //orderaddress = orderaddress.Replace("?", " ");
                    //string order_shoujian = ordername + "," + orderphone + "," + orderaddress + "," + orderyoubian;


                    //string goodsurl = Browser.JS_CEFBrowser("document.getElementsByClassName('mo_orderitem_h')[0].getElementsByTagName('a')[0].href", webBrowser2);

                    string phone = txt_phone.Text;
                    //string phoneaddress = txt_phoneaddress.Text;
                    //string ipaddress = txt_ip.Text;
                    //string goodsname = txt_goodsname.Text;
                    DateTime dt = new DateTime();
                    //DateTime.TryParse(orderdate, out dt);

                    Entity.shuadan_records sd = new Entity.shuadan_records();
                    //sd.sdaddress = order_shoujian;
                    sd.sddate = DateTime.Now;
                    sd.sddptype = "1";
                    //sd.sdgoodsname = goodsname;
                    //sd.sdgoodsurl = goodsurl;
                    //sd.sdorderid = orderid;
                    sd.sdphone = phone;
                    //sd.sdvpn = ipaddress;
                    //sd.sdremark1 = phoneaddress;
                    sd.sdremark3 = "1";
                    sd.sdremark4 = "1";
                    if (BLL2.shuadan_recordsManager.Insert(sd) == 1)
                    {
                        MessageBox.Show("保存刷单信息成功！" + phone);
                    }
                //}


            }
        }
        #endregion

        #region clearnum 清除IP数字
        string clearnum(string yuan)
        {
            string[] templist = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", ".", "I", "P", ":" };
            foreach (string tl in templist)
            {
                yuan = yuan.Replace(tl, "");
            }
            return yuan;

        }
        #endregion

        #region btn_search_Click
        private void btn_search_Click(object sender, EventArgs e)
        {
            DateTime temp_date2 = new DateTime();
            DateTime.TryParse(dateTimePicker1.Text, out temp_date2);
            string key = txt_key.Text.Trim();
            string t = "1";
            dgv_title.DataSource = BLL2.shuadan_recordsManager.Search(1, 100, key, t, "", "", "", temp_date2, temp_date2, "");
        }
        #endregion

        #region dateTimePicker1_CloseUp
        private void dateTimePicker1_CloseUp(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Long;
        }
        #endregion

        #region btn_reset_dgv_Click
        private void btn_reset_dgv_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "请选择";
        }

        #endregion

        #region btn_weifahuo_Click
        private void btn_weifahuo_Click(object sender, EventArgs e)
        {
            dgv_title.DataSource = BLL2.shuadan_recordsManager.SearchWeiFaHuo("");
        }
        #endregion

        #region dgv_title_CellContentClick 排序
        private void dgv_title_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_title.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex > -1)
            {

            }
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
            }
        }
        #endregion

        #region dgv_title_RowPostPaint 序号
        private void dgv_title_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //添加行号
            SolidBrush b = new SolidBrush(this.dgv_title.RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), this.dgv_title.DefaultCellStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 10);
        }
        #endregion

        #region button1_Click 更换号码
        private void button1_Click(object sender, EventArgs e)
        {
            tag_control.SelectedTab = tabPage1;
            ////http://www.ema666.com/userManage/GetCode.aspx
            //webBrowser1.Load("http://www.ema666.com/userManage/GetCode.aspx");
            //webBrowser1.Focus();
            //if (Browser.WaitWebPageLoad(webBrowser1))
            //{

            //释放手机号码
            //btnAddBlackId
            //Browser.JS_CEFBrowser_NoReturn("document.getElementById('btnReleaseId').click()", webBrowser1);
            //加入黑名单
            Browser.JS_CEFBrowser_NoReturn("document.getElementById('btnReleaseId').click()", webBrowser1);
            Browser.Delay(1000);
            Browser.JS_CEFBrowser_NoReturn(" document.getElementById('btnGetPhoneId').click() ", webBrowser1);
            Browser.Delay(1000);
            string phone = Browser.JS_CEFBrowser(" document.getElementById('txtPhone').value ", webBrowser1);
            if (!string.IsNullOrEmpty(phone))
            {
                txt_phone.Text = phone;
            }
            //}
        }

        #endregion

        #region  btn_phone_open_Click 释放手机号码
        private void btn_phone_open_Click(object sender, EventArgs e)
        {
            //释放手机号码
            Browser.JS_CEFBrowser_NoReturn("document.getElementById('btnReleaseId').click()", webBrowser1);
        }
        #endregion


        #region btn_login_Click 登录蘑菇街

        private void btn_login_Click(object sender, EventArgs e)
        {
            tag_control.SelectedTab = tabPage3;
            webBrowser2.Focus();
            Browser.Delay(500);

            webBrowser1.Load("http://mms.pinduoduo.com/Pdd.html#/login");
            if (Browser.WaitWebPageLoad(webBrowser1))
            {
                string access = XMLHelper.GetValue("PinDuoDuo_Access1");
                string pwd = XMLHelper.GetValue("PinDuoDuo_Pwd1");

                Browser.JS_CEFBrowser_NoReturn("document.getElementById('usernameId').value='" + access + "'  ", webBrowser1);
                Browser.Delay(300);
                Browser.JS_CEFBrowser_NoReturn("document.getElementById('passwordId').value='" + pwd + "'  ", webBrowser1);
                Browser.JS_CEFBrowser_NoReturn("document.getElementById('tuxing').focus()  ", webBrowser1);
                Browser.JS_CEFBrowser_NoReturn("document.getElementById('loginBtnId').setAttribute('data-click','true')  ", webBrowser1);
                Browser.JS_CEFBrowser_NoReturn("document.getElementById('loginBtnId').setAttribute('class','pdd-btn l-c-c-c-btn')  ", webBrowser1);
                Browser.Delay(300);
                Browser.MouseLeftByHtmlElement("document.getElementById('tuxing')", webBrowser1);
                Browser.Delay(300);
                Browser.MouseMoveByHtmlElement("document.getElementById('loginBtnId')", webBrowser1);

            }
        }
        #endregion

        #region btn_index_Click
        private void btn_index_Click(object sender, EventArgs e)
        {
            webBrowser2.Load("http://www.mogujie.com");
        }
        #endregion


        #region btn_test_Click
        private void btn_test_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                //webBrowser1.Load("http://www.baidu.com");
                Debug.WriteLine(i.ToString());
                Thread.Sleep(1000);
            }
        }
        #endregion
    }
}
