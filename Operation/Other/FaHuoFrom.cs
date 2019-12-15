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

namespace excel_operation.Other
{
    public partial class FaHuoFrom : Form
    {
        CefSharp.WinForms.ChromiumWebBrowser webBrowser1;
        public FaHuoFrom()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            webBrowser1 = new ChromiumWebBrowser("http://www.baidu.com");
            webBrowser1.FrameLoadStart += Browser.BrowserFrameLoadStart;
            webBrowser1.FrameLoadEnd += Browser.BrowserFrameLoadEnd;
            webBrowser1.Size = new Size(990, 400);
            webBrowser1.Location = new Point(12, 350);
            webBrowser1.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            this.Controls.Add(webBrowser1);
            //webBrowser1.RequestContext = tb.webBrowser1.RequestContext;
            //tb.Close();
            //tb.Dispose();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            string access = CS.XMLHelper.GetValue("BaoNiuNiu_Access");
            string pwd = CS.XMLHelper.GetValue("BaoNiuNiu_Pwd");

            webBrowser1.Load("http://www.bao66.cn/user/login");
            if (Browser.WaitWebPageLoad2("document.getElementById('username')", webBrowser1))
            {
                Browser.JS_CEFBrowser_NoReturn("document.getElementById('username').value='" + access + "'", webBrowser1);
                Browser.JS_CEFBrowser_NoReturn("document.getElementById('password').value='" + pwd + "'", webBrowser1);
                Browser.JS_CEFBrowser_NoReturn("document.getElementById('inputcode').focus() ", webBrowser1);
            }

        }

        private void btn_js_Click(object sender, EventArgs e)
        {
            string js = txt_js.Text.Trim();
            Browser.JS_CEFBrowser_NoReturn("js", webBrowser1);
        }
    }
}
