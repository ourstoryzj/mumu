using CefSharp.WinForms;
using Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Operation
{
    public partial class Taobao_Login : Form
    {
        public CefSharp.WinForms.ChromiumWebBrowser webBrowser1;
        public bool isok = false;
        public string dpname = "";
        string account = "";
        string pwd = "";

        public Taobao_Login()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            //this.MdiParent = MainForm.ActiveForm;
            try
            {
                webBrowser1 = new ChromiumWebBrowser("https://login.taobao.com/member/login.jhtml?spm=a21bo.2017.754894437.1.5af911d93kUo91&f=top&redirectURL=https%3A%2F%2Fwww.taobao.com%2F");
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
                            account = dp.dpaccount;
                            pwd = dp.dppwd;
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
            if (!string.IsNullOrEmpty(account) && !string.IsNullOrEmpty(pwd))
            {

                if (Browser.WaitWebPageLoad(" document.getElementsByTagName('form')[0].getElementsByTagName('input')[0] ", 2000, webBrowser1))
                {
                    webBrowser1.ToJs(" document.getElementsByTagName('form')[0].getElementsByTagName('input')[0].value = '" + account + "';");
                    webBrowser1.ToJs(" document.getElementsByTagName('form')[0].getElementsByTagName('input')[1].value = '" + pwd + "';");
                    webBrowser1.ToJs(" document.getElementsByTagName('form')[0].getElementsByTagName('button')[0].click(); ");
                    
                }


                #region bak
                /*
                if (Browser.WaitWebPageLoad(" document.getElementById('TPL_username_1') ", 2000, webBrowser1))
                {
                    webBrowser1.ToJs("var username = document.getElementById('TPL_username_1'); username.focus();username.value = '" + account + "';");
                    webBrowser1.ToJs("var password = document.getElementById('TPL_password_1');password.focus();password.value = '" + pwd + "';");
                    webBrowser1.ToJs("document.getElementById('J_SubmitStatic').focus();");
                    Browser.Delay(2000);
                    string temp_classname = webBrowser1.ToJs("document.getElementById('nocaptcha').className");
                    string temp_style = webBrowser1.ToJs("document.getElementById('nocaptcha').style.display");
                    if (temp_classname == "nc-container tb-login" && temp_style != "block")
                    {
                        webBrowser1.ToJs("document.getElementById('J_SubmitStatic').click();");
                    }
                } */
                #endregion
            }

        }


        #endregion



    }
}
