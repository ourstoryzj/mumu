using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Operation.CefsharpHelper;
using CefSharp;

namespace Operation.Test
{
    public partial class test_chrome : Form
    {

        private ChromeHelper chrome = null;
        //private CaptureListFrm captureFrm = null;//抓包
        //private DownLoadFrm downFrm = null;//下载


        public test_chrome()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;//不明作用，先注释

            
        }

        //绑定chrome
        void bind()
        {
            if (chrome == null)
            {
                chrome = new ChromeHelper("th://empty");
                chrome.Init();
                var browser = chrome.CreateBrowser();
                this.Invoke(new Action<Panel>(p => 
                {
                    p.Controls.Add(browser);
                    p.Update();
                }),this.panel1);
            }
        }

        void ApplicationExit_CefSharp(object sender, EventArgs e)
        {
            Cef.Shutdown();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.chrome.Back();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> header = new Dictionary<string, string>();
            header.Add("anthor","zj");
            header.Add("anthors", "zjs");
            CefsharpHelper.RequestHandler.headerDic = header;
            this.chrome.JumpUrl(this.txtUrl.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.chrome.Forward();
        }

        private void test_chrome_Load(object sender, EventArgs e)
        {
            Application.ApplicationExit += ApplicationExit_CefSharp;
            bind();
        }
    }
}
