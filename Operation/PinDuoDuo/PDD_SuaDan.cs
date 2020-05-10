using System.Collections.Generic;
using System.Windows.Forms;
using Entity;
using CefSharp.WinForms;
using System.Drawing;
using System;

using Operation.CS;
using System.IO;
using System.Diagnostics;
using Common;
using System.Net;
using CefSharp;
using Operation.CefsharpHelpers;

namespace Operation.Other
{


    public partial class PDD_SuaDan : Form
    {


        private CefsharpHelper chrome = null;
        //ChromiumWebBrowser wb = null;

        Entity.shuadan_records srs = null;

        //ChromiumWebBrowser webBrowser1;
        //话术id
        int hid = 0;

        public PDD_SuaDan()
        {
            InitializeComponent();
            bind();
            //tp_shuadan.h
            //bind_chrome();

            //webBrowser1 = new ChromiumWebBrowser("https://mobile.yangkeduo.com/personal.html?refer_page_name=index&refer_page_id=10002_1574496288865_ZKZKA8HgWJ&refer_page_sn=10002&page_id=10001_1577246196934_4h0wdL6yBD&is_back=1");
            ////Cef.EnableHighDPISupport();
            ////webBrowser1.FrameLoadStart += Browser.BrowserFrameLoadStart;
            //webBrowser1.FrameLoadEnd += webbrowser_FrameLoadEnd;
            //webBrowser1.Size = new Size(990, 725);
            //webBrowser1.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            //webBrowser1.Dock = DockStyle.Fill;

            //panel1.Controls.Add(webBrowser1);
        }



        #region bind

        /// <summary>
        /// 获取代理ip
        /// </summary>
        /// <returns></returns>
        string GetProxyAddress()
        {
            if (cb_proxyip.Checked)
            {
                return txt_proxyaddress.Text;
            }
            else if (cb_proxyapi.Checked)
            {
                //if (!string.IsNullOrEmpty(txt_proxyaip.Text))
                //{
                //    string str = Common.WebService.GetHtmlByWebRequest(txt_proxyaip.Text);
                //    str = str.Replace("\r\n","");
                //    txt_proxyaddress.Text = str;
                //    return str;
                //}
                return GetProxyAddressByAPI();
            }

            return "";
        }
        string GetProxyAddressByAPI()
        {
            string str = "";
            if (!string.IsNullOrEmpty(txt_proxyaip.Text))
            {
                str = Common.WebService.GetHtmlByWebRequest(txt_proxyaip.Text);
                str = str.Replace("\r\n", "");
                txt_proxyaddress.Text = str;
                return str;
            }
            return str;
        }


        void bind_chrome()
        {
            if (chrome == null)
            {
                chrome = new CefsharpHelper("th://empty");
                string proxyip = GetProxyAddress();
                if (string.IsNullOrEmpty(proxyip))
                {
                    chrome.Init();
                }
                else
                {
                    chrome.Init(proxyip);
                }
                chrome.CreateBrowser();
                //this.Invoke(new Action<Panel>(p =>
                //{
                //    p.Controls.Add(browser);
                //    p.Update();
                //}), this.panel1);

                panel1.Controls.Add(chrome.browser);
                panel1.Update();
                chrome.SetHeader();
                chrome.browser.FrameLoadEnd += webbrowser_FrameLoadEnd;
            }
            else
            {
                panel1.Controls.Add(chrome.browser);
                panel1.Update();
            }
        }

        void bind_chrome_kongbao()
        {
            if (chrome == null)
            {
                chrome = new CefsharpHelper("http://uu453.com.uu249.com:8888/login.aspx");
                string proxyip = GetProxyAddress();
                chrome.Init();
                chrome.CreateBrowser();
                //this.Invoke(new Action<Panel>(p =>
                //{
                //    p.Controls.Add(browser);
                //    p.Update();
                //}), this.panel1);

                pan_kongbao.Controls.Add(chrome.browser);
                pan_kongbao.Update();
                chrome.SetHeader();
                chrome.browser.FrameLoadEnd += webbrowser_FrameLoadEnd;
            }
            else
            {
                pan_kongbao.Controls.Add(chrome.browser);
                pan_kongbao.Update();
            }
        }



        void bind()
        {
            dgv_type.DataSource = BLL.shuadan_accountManager.Search(1, 10000, "", "1", 0, new DateTime(), new DateTime(), "");
        }

        #endregion

        #region setcookies
        //void setcookies(string name, string value)
        //{
        //    var domain = "mobile.yangkeduo.com";
        //    var cookieManager = CefSharp.Cef.GetGlobalCookieManager();
        //    cookieManager.SetCookieAsync("http://" + domain, new CefSharp.Cookie()
        //    {
        //        Domain = domain,
        //        Name = name,
        //        Value = value,
        //        Expires = DateTime.MinValue
        //    });
        //}

        /// <summary>
        /// 登录账号
        /// </summary>
        /// <param name="id"></param>
        /// <param name="token"></param>
        void login(string id, string token)
        {
            //setcookies("pdd_user_id", id);
            //setcookies("PDDAccessToken", token);
            var domain = "mobile.yangkeduo.com";
            chrome.SetCookies(domain, "pdd_user_id", id);
            chrome.SetCookies(domain, "PDDAccessToken", token);
        }



        #endregion

        #region webbrowser_FrameLoadEnd
        void webbrowser_FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {

            ChromiumWebBrowser browser = (ChromiumWebBrowser)sender;
            //浏览器缩放比例
            //browser.SetZoomLevel(0.5);
            //Browser.SetJSFile(browser);

            try
            {
                //如果是支付宝页面自动生成二维码，如果不是则清空
                if (browser.Address.IndexOf("mclient.alipay.com/home/exterfaceAssign.htm?") != -1)
                {
                    pan_tool.BackgroundImage = CS.AlipayHelper.CreateQRCode(browser.Address, 200);
                    string orderid = CS.PinDuoDuo.GetOrderIDByURL(browser.Address);
                    if (!string.IsNullOrEmpty(orderid) && srs != null)
                    {
                        srs.sdorderid = orderid;
                    }
                }
                else
                { 
                    pan_tool.BackgroundImage = null;
                    pan_tool.Refresh();
                }

                //showurl();
                //txt_goodsurl.Text = webBrowser1.Address;
            }
            catch (Exception ex)
            {
                ex.ToString().ToShow();
            }


        }



        //void showurl()
        //{
        //    ThreadFunDelegate tfd = new ThreadFunDelegate(ThreadFun);
        //    tfd.Invoke();
        //}

        //delegate void ThreadFunDelegate();
        //void ThreadFun()
        //{
        //    txt_goodsurl.Text = webBrowser1.Address;
        //}


        #endregion

        /*2020年4月14日 17:33:05新加*/

        #region 添加账号

        private void btn_typesave_Click(object sender, EventArgs e)
        {
            string account = txt_account.Text.Trim();
            string remark = txt_remark.Text.Trim();
            string state = cb_state2.Text == "启用" ? "1" : "2";
            string pwd = txt_pwd.Text.Trim();
            string phone = txt_phone.Text.Trim();

            shuadan_account sa = new shuadan_account();

            sa.sdaccount = account;
            sa.sdadate = DateTime.Now;
            sa.sdaphone = phone;
            sa.sdapwd = pwd;
            sa.sdaremark = remark;
            sa.sdastate = state;

            BLL.shuadan_accountManager.Insert(sa);

            bind();
            "添加成功".ToShow();
        }
        #endregion

        #region 账号列表
        private void btn_typeadd_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tp_typeadd;
        }



        private void dgv_type_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //DataGridView dgv_type = (DataGridView)sender;
                Common.DataGridViewHelper dgv_type = (Common.DataGridViewHelper)sender;
                //如果不是首行
                if (e.RowIndex > -1)
                {
                    string colname = dgv_type.Columns[e.ColumnIndex].Name;
                    shuadan_account sa = (shuadan_account)dgv_type.CurrentRow.DataBoundItem;
                    if (colname == "col_state")
                    {
                        #region 修改状态
                        sa.sdastate = sa.sdastate == "1" ? "2" : "1";
                        BLL.shuadan_accountManager.Update(sa);
                        dgv_type.ToClearChecked();
                        #endregion
                    }
                    else if (colname == "col_del")
                    {
                        #region 修改状态
                        if (MessageBox.Show("确定要删除吗?", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            BLL.shuadan_accountManager.Delete(sa.sdaid);
                            dgv_type.ToAfterDelete(e.RowIndex);
                        }
                        #endregion
                    }
                    else if (colname == "col_login")
                    {
                        #region 登录账号
                        tabControl1.SelectedTab = tp_shuadan;
                        login(sa.sdaccount, sa.sdapwd);
                        srs = new Entity.shuadan_records();
                        srs.sdvpn = GetProxyAddress();
                        srs.sdgoodsurl = txt_openurl.Text;
                        srs.sdphone = sa.sdaccount;
                        srs.sdaddress = sa.sdapwd;
                        srs.sdremark6 = "2";
                        srs.sddptype = "3";
                        //srs.sdremark7 = addcount(srs.sdremark7);
                        btn_shuadan_geren.PerformClick();

                        //添加使用次数
                        sa.sdaremark1 = addcount(sa.sdaremark1);
                        BLL.shuadan_accountManager.Update(sa);
                        #endregion
                    }
                    else if (colname == "col_shuadan")
                    {
                        #region 外部浏览器刷单
                        string path = Manager.PathAppliction() + "\\Operation2.exe";

                        //自动下单
                        string agrs2 = cb_autoorder.Checked ? " true" : "";

                        System.Diagnostics.Process p = new System.Diagnostics.Process();
                        p.StartInfo.FileName = path;
                        p.StartInfo.UseShellExecute = true;
                        //序列化参数json
                        Entity.shuadan_records sr = new Entity.shuadan_records();
                        //sr.sdremark7 = addcount(sr.sdremark7);
                        //BLL2.shuadan_recordsManager.Update(sr);
                        sr.sdvpn = GetProxyAddress();
                        //.Replace("https://","").Replace("http://", "")
                        sr.sdgoodsurl = txt_openurl.Text.Replace("https://", "").Replace("http://", "");
                        sr.sdphone = sa.sdaccount;
                        sr.sdaddress = sa.sdapwd;
                        sr.sdremark6 = "2";
                        sr.sddptype = "3";


                        string agrs = Newtonsoft.Json.JsonConvert.SerializeObject(sr);
                        p.StartInfo.Arguments = agrs + agrs2;
                        p.Start();

                        //添加使用次数
                        sa.sdaremark1 = addcount(sa.sdaremark1);
                        BLL.shuadan_accountManager.Update(sa);

                        #endregion
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 设置使用次数
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        string addcount(string count)
        {
            string str = "";
            int i = 0;
            int.TryParse(count, out i);
            str = (i + 1).ToString();
            return str;
        }



        private void dgv_type_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //if (e.Value != null)
            //{
            //    if (dgv_type.DataSource != null)
            //    {

            //        if (dgv_type.Columns[e.ColumnIndex].Name.Equals("col_state"))
            //        {
            //            string name = e.Value.ToString();
            //            if (name == "1")
            //            {
            //                e.Value = "启用";
            //                e.CellStyle.ForeColor = Color.Green;
            //            }
            //            else
            //            {
            //                e.Value = "禁用";
            //                e.CellStyle.ForeColor = Color.Red;
            //            }

            //        }
            //    }
            //}
        }

        private void dgv_type_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            try
            {
                string colname = dgv_type.Columns[dgv_type.CurrentCell.ColumnIndex].Name;
                if (colname.Equals("col_account") || colname.Equals("col_pwd") || colname.Equals("col_phone") || colname.Equals("col_remark"))
                {
                    shuadan_account hs = (shuadan_account)dgv_type.CurrentRow.DataBoundItem;
                    if (hs != null)
                    {
                        string col_account = dgv_type["col_account", e.RowIndex].EditedFormattedValue == null ? "" : dgv_type["col_account", e.RowIndex].EditedFormattedValue.ToString();
                        string col_pwd = dgv_type["col_pwd", e.RowIndex].EditedFormattedValue == null ? "" : dgv_type["col_pwd", e.RowIndex].EditedFormattedValue.ToString();
                        string col_phone = dgv_type["col_phone", e.RowIndex].EditedFormattedValue == null ? "" : dgv_type["col_phone", e.RowIndex].EditedFormattedValue.ToString();
                        string col_remark = dgv_type["col_remark", e.RowIndex].EditedFormattedValue == null ? "" : dgv_type["col_remark", e.RowIndex].EditedFormattedValue.ToString();

                        hs.sdaccount = col_account;
                        hs.sdapwd = col_pwd;
                        hs.sdaphone = col_phone;
                        hs.sdaremark = col_remark;

                        BLL.shuadan_accountManager.Update(hs);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToLog();
            }
        }





        #endregion

        #region btn_delete_Click_1
        private void btn_delete_Click_1(object sender, EventArgs e)
        {
            List<int> list = dgv_type.GetDeleteCheckedIndex();
            if (list.Count > 0)
            {
                foreach (int i in list)
                {
                    shuadan_account hs = (shuadan_account)dgv_type.Rows[i].DataBoundItem;
                    BLL.shuadan_accountManager.Delete(hs.sdaid);
                    dgv_type.ToAfterDelete(i);
                }
                "删除成功".ToShow();
            }
            else
            {
                "请选择需要删除的信息".ToShow();
            }

        }
        #endregion

        #region btn_search_Click_1
        private void btn_search_Click_1(object sender, EventArgs e)
        {
            string key = txt_key.Text.Trim();



            string state = cb_state.Text;
            if (state == "启用")
                state = "1";
            else if (state == "禁用")
                state = "2";
            else
                state = "";

            dgv_type.DataSource = BLL.shuadan_accountManager.Search(1, 10000, key, state, 0, new DateTime(), new DateTime(), "");
        }
        #endregion

        #region btn_piliangsave_Click
        private void btn_piliangsave_Click(object sender, EventArgs e)
        {
            string fenge = txt_fenge.Text.Trim();
            List<string> list = txt_piliang.Text.ToListByLine();
            foreach (string str in list)
            {
                try
                {
                    string[] temp = str.ToSplit(fenge);
                    string phone = temp[0];
                    string account = temp[1];
                    string pwd = temp[2];

                    shuadan_account sa = new shuadan_account();
                    sa.sdaccount = account;
                    sa.sdadate = DateTime.Now;
                    sa.sdaphone = phone;
                    sa.sdapwd = pwd;
                    sa.sdastate = "1";

                    BLL.shuadan_accountManager.Insert(sa);
                }
                catch (Exception ex)
                {
                    ex.ToShow();
                }

            }

            ("保存成功,共" + list.Count.ToString() + "条信息").ToShow();
            bind();
            txt_piliang.Text = "";
        }
        #endregion

        #region chrome

        private void btn_shuadan_geren_Click(object sender, EventArgs e)
        {

            chrome.JumpUrl("https://mobile.yangkeduo.com/personal.html?refer_page_name=index&refer_page_id=10002_1574496288865_ZKZKA8HgWJ&refer_page_sn=10002&page_id=10001_1577246196934_4h0wdL6yBD&is_back=1");
        }

        private void btn_openurl_Click(object sender, EventArgs e)
        {
            bind_chrome();
            chrome.JumpUrl(txt_openurl.Text);
        }

        private void btn_f12_Click(object sender, EventArgs e)
        {
            chrome.ShowTools();
        }

        private void tp_shuadan_Click(object sender, EventArgs e)
        {

        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            chrome.Back();
        }

        private void btn_go_Click(object sender, EventArgs e)
        {
            chrome.Forward();
        }

        private void txt_proxyaddress_DoubleClick(object sender, EventArgs e)
        {
            this.Text = "";
        }

        private void btn_auto_Click(object sender, EventArgs e)
        {
            Common.Manager.ProcessKillByName("CefSharp.BrowserSubprocess");
        }

        private void btn_getproxyone_Click(object sender, EventArgs e)
        {
            GetProxyAddressByAPI();
        }
        #endregion

        #region btn_save_shuadan_Click
        private void btn_save_shuadan_Click(object sender, EventArgs e)
        {
            if (srs != null)
            {
                BLL2.shuadan_recordsManager.Insert(srs);
                "保存成功".ToShow();
            }
        }

        #endregion


        #region btn_pay_Click


        shuadan_records pay_sr = null;

        private void btn_pay_Click(object sender, EventArgs e)
        {
            IList<shuadan_records> list = BLL2.shuadan_recordsManager.Search("", "2", "");
            lbl_pay_message.Text = "共 " + list.Count.ToString() + " 条未付款订单";
            if (list.Count > 0)
            {
                shuadan_records sr = list[0];
                if (!string.IsNullOrEmpty(sr.sdorderid))
                {
                    pay_sr = sr;
                    string payurl = sr.sdgoodsname;
                    if (payurl.IndexOf("mclient.alipay.com/home/exterfaceAssign.htm?") != -1)
                    {
                        pan_pay.BackgroundImage = AlipayHelper.CreateQRCode(payurl, 300);
                    }
                }

            }
        }
        #endregion

        #region btn_pay_ok_Click
        private void btn_pay_ok_Click(object sender, EventArgs e)
        {
            if (pay_sr != null)
            {
                pay_sr.sdstatepay = "1";
                BLL2.shuadan_recordsManager.Update(pay_sr);
                lbl_pay_message.Text = "设置付款状态成功!";
                pan_pay.BackgroundImage = null;
                pan_pay.Refresh();
            }
        }
        #endregion


        #region 刷单列表


        private void PDD_SuaDan_Load(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }



        private void btn_weifahuo_Click(object sender, EventArgs e)
        {
            string t = cb_type.Text;
            if (t == "蘑菇街")
                t = "1";
            else if (t == "淘宝")
            {
                t = "2";
            }
            else if (t == "拼多多")
            {
                t = "3";
            }
            dgv_title.DataSource = BLL2.shuadan_recordsManager.SearchWeiFaHuo(t);
        }

        private void cb_type_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_CloseUp(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Long;
        }

        private void btn_reset_dgv_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "请选择";
            cb_fahuo.Text = "请选择";
            cb_kongbao.Text = "请选择";
        }

        private void btn_search_sdr_Click(object sender, EventArgs e)
        {
            DateTime temp_date2 = new DateTime();
            if (dateTimePicker1.Text != "请选择")
            {
                temp_date2 = dateTimePicker1.Value;
            }
            string key = txt_key_sdr.Text.Trim();

            string dptype = cb_type.Text;
            if (dptype == "蘑菇街")
                dptype = "1";
            else if (dptype == "淘宝")
                dptype = "2";
            else if (dptype == "拼多多")
                dptype = "3";
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
                        //fakongbao(sr);
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
                        //fahuo(sr);
                    }
                    else if (colname == "col_del_list")
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
                                //删除行 e.del();

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
                            //tabControl1.SelectedTab = tabPage4;
                            //webBrowser4.Focus();
                            //webBrowser4.Load("http://www.guoguo-app.com/");
                            //if (Browser.WaitWebPageLoad(webBrowser4))
                            //{
                            //    Browser.JS_CEFBrowser_NoReturn("document.getElementById('J_SearchInput').value='" + sr.sdwuliu + "'", webBrowser4);
                            //    Browser.JS_CEFBrowser_NoReturn("document.getElementById('J_SearchBtn').click()", webBrowser4);

                            //}
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

                        //token = MessageAPI.GetToken();
                        //Auto.Clipboard_In(sr.sdphone);
                        //txt_phone.Text = sr.sdphone;
                        //string res = MessageAPI.GetPhone(token, sr.sdphone);
                        //txt_phone.Text = res;
                        //phone = res;
                        //if (res == sr.sdphone)
                        //{
                        //    sr.sdremark2 = "2";
                        //    tabControl2.SelectedTab = tabPage6;
                        //}
                        //else
                        //{
                        //    sr.sdremark2 = "3";
                        //    sr.sdremark5 = res;
                        //}
                        //BLL2.shuadan_recordsManager.Update(sr);
                        //dgv_title.Refresh();
                        //MessageBox.Show(res);
                        #endregion
                        //fakongbao_pinduoduo(sr);

                    }
                    else if (colname == "col_goodsname")
                    {
                        //二维码
                        pan_pay.BackgroundImage = null;
                        pan_pay.Refresh();
                        pan_pay.BackgroundImage = CS.AlipayHelper.CreateQRCode(sr.sdgoodsname, 300);
                        tabControl1.SelectedTab = tp_records;
                        pay_sr = sr;
                    }

                }
                else if (e.RowIndex == -1)
                {
                    #region 全选
                    //如果是全选
                    //if (e.ColumnIndex == 0)
                    //{
                    //    foreach (DataGridViewRow row in dgv_title.Rows)
                    //    {
                    //        if (row.Index != -1)
                    //        {
                    //            DataGridViewCheckBoxCell cbx = (DataGridViewCheckBoxCell)row.Cells[0];
                    //            cbx.Value = allselect == 0 ? true : false;
                    //        }
                    //    }
                    //    allselect = allselect == 1 ? 0 : 1;
                    //}
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

        private void dgv_title_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //添加行号
            SolidBrush b = new SolidBrush(this.dgv_title.RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), this.dgv_title.DefaultCellStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 10);
        }

        private void btn_weifukuan_Click(object sender, EventArgs e)
        {
            dgv_title.DataSource = BLL2.shuadan_recordsManager.Search("", "2", "");
        }


        #endregion

        private void btn_login_kongbao_Click(object sender, EventArgs e)
        {
            bind_chrome_kongbao();
            var domain = "uu453.com.uu249.com:8888";
            chrome.SetCookies(domain, "safedog-flow-item","");
            //chrome.SetCookies(domain, "Cooperatives.User=userID", "369647");
            //chrome.SetCookies(domain, "adminid", "0");
            //chrome.SetCookies(domain, "userName", "ourstoryzj");
            //chrome.SetCookies(domain, "Lb", "1");
            //chrome.SetCookies(domain, "MemberTypes", "2");
            //chrome.SetCookies(domain, "Token", "47F58E0510FD651574448F137DF97A2F24F91C91");
            chrome.SetCookies(domain, "Cooperatives.User", "userID=369647&adminid=0&userName=ourstoryzj&Lb=1&MemberTypes=2&Token=47F58E0510FD651574448F137DF97A2F24F91C91");


            chrome.JumpUrl("uu453.com.uu249.com:8888/Member/DanHaoSearch.aspx");
            //if (chrome.WaitWebPageLoad())
            //{
            //    if (chrome.ElementIsNull("document.getElementById('MainC_tbuserName')"))
            //    {
            //        chrome.JS_CEFBrowser("document.getElementById('MainC_tbuserName').value='ourstoryzj';");
            //        chrome.JS_CEFBrowser("document.getElementById('MainC_Tbpwd').value='zhangjian';");
            //        chrome.JS_CEFBrowser("document.getElementById('MainC_btnLogin').click()");
            //    }
            //}
            

        }
    }


}
