using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using Operation.CefsharpHelpers;

namespace Operation.Test
{
    public partial class test_chrome_header : Form
    {

        //private CefsharpHelper chrome = null;
        //private CaptureListFrm captureFrm = null;//抓包
        //private DownLoadFrm downFrm = null;//下载

        CefSharp.WinForms.ChromiumWebBrowser webBrowser1;

        public test_chrome_header()
        {
            InitializeComponent();
            //Control.CheckForIllegalCrossThreadCalls = false;//不明作用，先注释

            this.StartPosition = FormStartPosition.CenterScreen;

            InitCef();



            webBrowser1 = new ChromiumWebBrowser("www.baidu.com");
            webBrowser1.FrameLoadStart += Browser.BrowserFrameLoadStart;
            webBrowser1.FrameLoadEnd += Browser.BrowserFrameLoadEnd;
            //webBrowser1.Size = new Size(1130, 725);
            //webBrowser1.Location = new Point(180, 12);
            webBrowser1.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;

            

            panel1.Controls.Add(webBrowser1);
        }

        //绑定chrome

        public static void InitCef()
        {
            if (!Cef.IsInitialized)
            {
                var settings = new CefSettings();
                settings.RegisterScheme(new CefCustomScheme
                {
                    SchemeName = CefSharpSchemeHandlerFactory.SchemeName,
                    SchemeHandlerFactory = new CefSharpSchemeHandlerFactory()
                });

                //settings.CachePath = "cache";
                //settings.CefCommandLineArgs.Add("enable-media-stream", "1");
                //settings.CefCommandLineArgs.Add("no-proxy-server", "1");
                settings.CefCommandLineArgs.Add("name", "zhangjian");

                var ProxyAddress = "58.218.92.65:3261";
                settings.CachePath = "cache";
                settings.CefCommandLineArgs.Add("proxy-server", ProxyAddress);
                //settings.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/61.0.3163.79 Safari/537.36";
                settings.UserAgent = "Mozilla/5.0 (iPhone; CPU iPhone OS 7_0_4 like Mac OS X) AppleWebKit/537.51.1 (KHTML, like Gecko) Version/7.0 Mobile/11B554a Safari/9537.53";


                settings.Locale = "zh-CN";
                settings.AcceptLanguageList = "zh-CN";
                Cef.Initialize(settings);
                //Cef.Initialize(settings, true, null);
            }
            //if (!Cef.IsInitialized)
            //{
            //    var setting = new CefSharp.CefSettings();
            //    setting.RegisterScheme(new CefCustomScheme
            //    {
            //        SchemeName = CefSharpSchemeHandlerFactory.SchemeName,
            //        SchemeHandlerFactory = new CefSharpSchemeHandlerFactory()
            //    });

            //    //var ProxyAddress = "58.54.50.134:22213";
            //    //setting.CachePath = "cache";
            //    //setting.CefCommandLineArgs.Add("proxy-server", ProxyAddress);
            //    // 设置语言
            //    setting.Locale = "zh-CN"; // en-US
            //    Cef.Initialize(setting);
            //    // CefSharp.Cef.Initialize(setting, true, false);
            //}

        }


        void ApplicationExit_CefSharp(object sender, EventArgs e)
        {
            Cef.Shutdown();
            //chrome.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //this.chrome.Back();
        }

        private void button1_Click(object sender, EventArgs e)
        {

  

            webBrowser1.Load(this.txtUrl.Text);


            //Dictionary<string, string> header = new Dictionary<string, string>();
            ////header.Add("Referer", "http://www.nuoren365.com/");
            //header.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/69.0.3497.100 Safari/537.36");
            //header.Add("Accept-Language", "zh-CN,zh;q=0.9,en;q=0.8");
            //header.Add("ourstoryzj","ok");
            //header.Add("Referer", "http://www.nuoren365.com/");
            //CefsharpHelpers.RequestHandler.headerDic = header;

            //chrome.SetCookies("www.nuoren365.com", "login", "cc696ba2246b461298b37c12bf557abb");
            //chrome.SetCookies("www.nuoren365.com", "Hm_lvt_dd24df68c4022926519e13123766f33c", "1578324793,1578373052");
            //chrome.SetCookies("www.nuoren365.com", "Hm_lpvt_dd24df68c4022926519e13123766f33c", "1578373052");
            //this.chrome.JumpUrl(this.txtUrl.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //this.chrome.Forward();
        }

        private void test_chrome_Load(object sender, EventArgs e)
        {
            //Application.ApplicationExit += ApplicationExit_CefSharp;
            //bind();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //chrome.ClearCookie();
            //chrome.Dispose();


        }

        private void button5_Click(object sender, EventArgs e)
        {
            //chrome.ShowTools();
        }
    }
}
