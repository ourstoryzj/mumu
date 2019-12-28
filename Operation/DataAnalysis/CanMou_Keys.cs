using System;
using System.Windows.Forms;
using Operation.CS;
using Operation.Other;
using CefSharp.WinForms;

namespace Operation.DataAnalysis
{
    public partial class CanMou_Keys : Form
    {
        CefSharp.WinForms.ChromiumWebBrowser webBrowser1;
        public CanMou_Keys()
        {
            Taobao_Login tb = new Taobao_Login();
            tb.Show();
            if (Manager.WaitTaobaoLogin(tb))
            {
                tb.Hide();
                InitializeComponent();

                this.StartPosition = FormStartPosition.CenterScreen;
                webBrowser1 = new ChromiumWebBrowser("http://www.taobao.com");
                webBrowser1.FrameLoadStart += Browser.BrowserFrameLoadStart;
                webBrowser1.FrameLoadEnd += Browser.BrowserFrameLoadEnd;
                webBrowser1.Dock = DockStyle.Fill;
                webBrowser1.Location = new System.Drawing.Point(3, 3);
                webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
                webBrowser1.Size = new System.Drawing.Size(969, 653);
                webBrowser1.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
                tabPage1.Controls.Add(webBrowser1);
                webBrowser1.RequestContext = tb.webBrowser1.RequestContext;
                tb.Close();
                tb.Dispose();


            }
        }


        #region btn_hangyelidu_Click
        private void btn_hangyelidu_Click(object sender, EventArgs e)
        {
            //设置鼠标原始位置
            Manager.MousePoint = Control.MousePosition;

            //卖家中心
            webBrowser1.Load("https://myseller.taobao.com/seller_admin.htm");
            if (Browser.WaitWebPageLoad("getElementsByDataSpm('d58')[0]", webBrowser1))
            {
                //在卖家中心找到生意参谋
                Browser.MouseLeftByHtmlElement("getElementsByDataSpm('d58')[0]", webBrowser1);
                //第一次点击进入浏览器，第二次点击开始操作
                Auto.Mouse_Left();
                if (Browser.WaitWebPageLoad("getElementsByDataSpm('d18')[0]", webBrowser1))
                {
                    //关闭提示窗口dialog-show
                    Browser.MouseLeftByHtmlElement(" getClassName('dialog-show')[0].getElementsByTagName('i')[0] ", webBrowser1);
                    //点击市场行情
                    Browser.MouseLeftByHtmlElement("getElementsByDataSpm('d18')[0]", webBrowser1);
                    //延迟-商品店铺榜
                    if (Browser.WaitWebPageLoad("getElementsByDataSpm('d342')[0]", webBrowser1))
                    {
                        //点击商品店铺榜
                        Browser.MouseLeftByHtmlElement("getElementsByDataSpm('d342')[0]", webBrowser1);
                        //点击行业粒度
                        Browser.MouseLeftByHtmlElement("getElementsByDataSpm('d343')[0]", webBrowser1);
                    }
                }
            }
        }
        #endregion



        private void btn_test_Click(object sender, EventArgs e)
        {
            string temp = textBox1.Text.Trim();
            Browser.JS_CEFBrowser(temp, webBrowser1);
        }



        #region btn_testmouse_Click
        private void btn_testmouse_Click(object sender, EventArgs e)
        {
            //设置鼠标原始位置
            Manager.MousePoint = Control.MousePosition;

            if (Browser.WaitWebPageLoad(webBrowser1))
            {
                //Debug.WriteLine(Manager.JS_WebBrowser("getAbsoluteOffsetTop( document.getElementById('forget-pw-safe') )", webBrowser1));
                //Debug.WriteLine(Manager.JS_WebBrowser("getAbsoluteOffsetLeft( document.getElementById('forget-pw-safe') )", webBrowser1));
                Browser.JS_CEFBrowser_NoReturn("removeElement( document.getElementById('forget-pw-safe') )", webBrowser1);
                //Manager.JS_WebBrowser("getAbsoluteOffsetLeft( document.getElementById('forget-pw-safe') )", webBrowser1);
            }



        }
        #endregion



    }
}
