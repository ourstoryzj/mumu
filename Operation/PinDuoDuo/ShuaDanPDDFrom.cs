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

namespace Operation.Other
{


    public partial class ShuaDanPDDFrom : Form
    {

        ChromiumWebBrowser webBrowser1;
        //话术id
        int hid = 0;

        public ShuaDanPDDFrom()
        {
            InitializeComponent();
            bind();

            webBrowser1 = new ChromiumWebBrowser("https://mobile.yangkeduo.com/personal.html?refer_page_name=index&refer_page_id=10002_1574496288865_ZKZKA8HgWJ&refer_page_sn=10002&page_id=10001_1577246196934_4h0wdL6yBD&is_back=1");
            //Cef.EnableHighDPISupport();
            //webBrowser1.FrameLoadStart += Browser.BrowserFrameLoadStart;
            webBrowser1.FrameLoadEnd += webbrowser_FrameLoadEnd;
            webBrowser1.Size = new Size(990, 725);
            webBrowser1.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            webBrowser1.Dock = DockStyle.Fill;

            panel1.Controls.Add(webBrowser1);
        }



        #region bind

        void bind()
        {
            dgv_type.DataSource = BLL.shuadan_accountManager.Search(1,10000,"","",0,new DateTime(),new DateTime(),"");
        }

        #endregion

        #region setcookies
        void setcookies(string name, string value)
        {
            var domain = "mobile.yangkeduo.com";
            var cookieManager = CefSharp.Cef.GetGlobalCookieManager();
            cookieManager.SetCookieAsync("http://" + domain, new CefSharp.Cookie()
            {
                Domain = domain,
                Name = name,
                Value = value,
                Expires = DateTime.MinValue
            });
        }

        /// <summary>
        /// 登录账号
        /// </summary>
        /// <param name="id"></param>
        /// <param name="token"></param>
        void login(string id, string token)
        {
            setcookies("pdd_user_id", id);
            setcookies("PDDAccessToken", token);
        }


        public static void SetCefCookies(string url, CookieCollection cookies)
        {
            //Cef.GetGlobalCookieManager().SetStoragePath(Environment.CurrentDirectory, true);
            //foreach (System.Net.Cookie c in cookies)
            //{
            //    var cookie = new CefSharp.Cookie
            //    {
            //        Creation = DateTime.Now,
            //        Domain = c.Domain,
            //        Name = c.Name,
            //        Value = c.Value,
            //        Expires = c.Expires
            //    };
            //    Task<bool> task = Cef.GetGlobalCookieManager().SetCookieAsync(url, cookie);
            //    while (!task.IsCompleted)
            //    {
            //        continue;
            //    }
            //    bool b = task.Result;
            //}
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
                    pan_tool.BackgroundImage = CS.AlipayHelper.CreateQRCode(browser.Address, 200);
                else
                    pan_tool.BackgroundImage = null;
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

        #region 添加话术类型

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
        }
        #endregion

        #region 话术类型列表
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
                        
                        btn_shuadan_geren.PerformClick();
                        #endregion
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        private void btn_shuadan_geren_Click(object sender, EventArgs e)
        {
            webBrowser1.Load("https://mobile.yangkeduo.com/personal.html?refer_page_name=index&refer_page_id=10002_1574496288865_ZKZKA8HgWJ&refer_page_sn=10002&page_id=10001_1577246196934_4h0wdL6yBD&is_back=1");
        }

        private void btn_openurl_Click(object sender, EventArgs e)
        {
            webBrowser1.Load(txt_openurl.Text);
        }
    }


}
