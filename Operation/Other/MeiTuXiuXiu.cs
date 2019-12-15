using System.Collections.Generic;
using System.Windows.Forms;
using Entity;
using CefSharp.WinForms;
using System.Drawing;
using System;

using excel_operation.CS;
using System.IO;
using System.Diagnostics;


namespace excel_operation.Other
{
    public partial class MeiTuXiuXiu : Form
    {
        //CefSharp.WinForms.ChromiumWebBrowser webBrowser1;



        public MeiTuXiuXiu()
        {
            //Login tb = new Login();
            //tb.Show();
            //if (Manager.WaitLogin(tb))
            //{
            //tb.Hide();
            InitializeComponent();

            //this.StartPosition = FormStartPosition.CenterScreen;
            //webBrowser1 = new ChromiumWebBrowser("http://xiuxiu.web.meitu.com/main.html");
            //webBrowser1.FrameLoadStart += Browser.BrowserFrameLoadStart;
            //webBrowser1.FrameLoadEnd += Browser.BrowserFrameLoadEnd;
            ////1203, 814
            //webBrowser1.Size = new Size(1200, 800);
            ////webBrowser1.Location = new Point(180, 12);
            //webBrowser1.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            //this.Controls.Add(webBrowser1);


        }

        #region btn_test_Click
        private void btn_test_Click(object sender, System.EventArgs e)
        {
            string js = txt_js.Text;
            //Browser.JS_CEFBrowser_NoReturn(js, webBrowser1);
        }
        #endregion

        #region btn_savehtml_Click
        private void btn_savehtml_Click(object sender, EventArgs e)
        {
            //string html = webBrowser1.RequestContext.ToString();
            //string html = Browser.JS_CEFBrowser("document.body.innerHTML", webBrowser1);
            ////// 创建文件
            ////System.IO.FileStream fs = new FileStream("test.doc", FileMode.OpenOrCreate, FileAccess.ReadWrite); //可以指定盘符，也可以指定任意文件名，还可以为word等文件
            ////StreamWriter sw = new StreamWriter(fs); // 创建写入流
            ////sw.WriteLine("bob hu"); // 写入Hello World
            ////sw.Close(); //关闭文件
            //string path = "d:\\html" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";
            //FileHelper.Write(path, html);
            //System.Diagnostics.Process.Start(path);
        }
        #endregion

        #region btn_addjs_Click
        private void btn_addjs_Click(object sender, EventArgs e)
        {
            //Browser.SetJSFile(webBrowser1);
        }
        #endregion

    }
}
