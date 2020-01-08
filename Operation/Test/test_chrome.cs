using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Operation.CefsharpHelpers;
using CefSharp;

namespace Operation.Test
{
    public partial class test_chrome : Form
    {

        private CefsharpHelper chrome = null;
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
                chrome = new CefsharpHelper("th://empty");
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
            //header.Add("Referer", "http://www.nuoren365.com/");
            header.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/69.0.3497.100 Safari/537.36");
            header.Add("Accept-Language", "zh-CN,zh;q=0.9,en;q=0.8");
            header.Add("ourstoryzj","ok");
            header.Add("Referer", "http://www.nuoren365.com/");
            CefsharpHelpers.RequestHandler.headerDic = header;

            chrome.SetCookies("www.nuoren365.com", "login", "cc696ba2246b461298b37c12bf557abb");
            chrome.SetCookies("www.nuoren365.com", "Hm_lvt_dd24df68c4022926519e13123766f33c", "1578324793,1578373052");
            chrome.SetCookies("www.nuoren365.com", "Hm_lpvt_dd24df68c4022926519e13123766f33c", "1578373052");
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
