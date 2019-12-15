using CefSharp.WinForms;
using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace excel_operation.Other
{
    public partial class Login : Form
    {
        public CefSharp.WinForms.ChromiumWebBrowser webBrowser1;
        public bool isok = false;
        public string dpname = "";

        public Login()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            //this.MdiParent = MainForm.ActiveForm;
            try
            {
                webBrowser1 = new ChromiumWebBrowser("https://login.taobao.com/member/login.jhtml?f=top&redirectURL=https%3A%2F%2Fwww.taobao.com%2F&style=mini");
                webBrowser1.Dock = DockStyle.Fill;
                this.Controls.Add(webBrowser1);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }

            bind();

            Focus();
        }

        void bind()
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



        private void btn_logined_Click(object sender, EventArgs e)
        {
            isok = true;
        }

        #region cb_dianpu_SelectedIndexChanged

        private void cb_dianpu_SelectedIndexChanged(object sender, EventArgs e)
        {
            string dpid_temp = cb_dianpu.SelectedValue.ToString();
            int dpid = 0;
            if (dpid_temp != "0")
            {
                if (int.TryParse(dpid_temp, out dpid))
                {
                    dianpu dp = BLL2.dianpuManager.SearchBydpid(dpid);
                    if (dp != null)
                    {
                        dpname = dp.dpname;
                        //if (dp.dpname == "蘑菇街")
                        //{
                        //    //CS.Mogujie.Login(dp.dpaccount, dp.dppwd, webBrowser1);
                        //}
                        //else if (dp.dpname == "美丽说")
                        //{

                        //}
                        //else
                        //{
                        //CS.Taobao.Login(dp.dpaccount, dp.dppwd, webBrowser1);
                        try
                        {
                            lbl_account.Text = dp.dpaccount;
                            lbl_pwd.Text = dp.dppwd;
                        }
                        catch { }
                        //}
                        //鼠标移动到按钮上
                        //Auto.MoveMouseToPoint(btn_logined.PointToScreen(new Point(90, 15)));
                        Auto.MoveMouseToPoint(btn_account.PointToScreen(new Point(90, 15)));
                    }
                }
            }
        }


        #endregion

        #region btn_account_Click
        private void btn_account_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lbl_account.Text))
            {
                Auto.Clipboard_In(lbl_account.Text.Trim());

                if (Browser.WaitWebPageLoad(webBrowser1))
                {
                    if (Browser.WaitWebPageLoad(" document.getElementById('TPL_username_1') ", 2000, webBrowser1))
                    {
                        Browser.MouseLeftByHtmlElement(" document.getElementById('TPL_username_1') ", webBrowser1);
                        Auto.Ctrl_V();
                        
                    }
                }
            }
           
        }


        #endregion

        #region btn_pwd_Click
        private void btn_pwd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lbl_pwd.Text))
            {
                Auto.Clipboard_In(lbl_pwd.Text.Trim());
                if (Browser.WaitWebPageLoad(webBrowser1))
                {
                    if (Browser.WaitWebPageLoad(" document.getElementById('TPL_password_1') ", 2000, webBrowser1))
                    {
                        Browser.MouseLeftByHtmlElement(" document.getElementById('TPL_password_1') ", webBrowser1);
                        Auto.Ctrl_V();
                    }
                }
            }
        }
        #endregion

    }
}
