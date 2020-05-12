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
using System.IO;

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
            //Control.CheckForIllegalCrossThreadCalls = false;//不明作用，先注释


            
        }

        //绑定chrome
        void bind()
        {
            if (chrome == null)
            {
                chrome = new CefsharpHelper("th://empty");
                if (!Cef.IsInitialized)
                {
                    Random random = new Random();
                    int temp = random.Next(1000, 9999);
                    
                    var setting = new CefSharp.WinForms.CefSettings() {

                        //CachePath = Directory.GetCurrentDirectory() + @"\Cache\" + temp.ToString(),

                    };
                    //setting.RegisterScheme(new CefCustomScheme
                    //{
                    //    SchemeName = CefSharpSchemeHandlerFactory.SchemeName,
                    //    SchemeHandlerFactory = new CefSharpSchemeHandlerFactory()
                    //});

                    var ProxyAddress = "58.218.92.65:4442";
                    setting.CachePath = "cache";
                    setting.CefCommandLineArgs.Add("proxy-server", ProxyAddress);
                    // 设置语言
                    //setting.UserAgent = "Mozilla/5.0 (iPhone; CPU iPhone OS 7_0_4 like Mac OS X) AppleWebKit/537.51.1 (KHTML, like Gecko) Version/7.0 Mobile/11B554a Safari/9537.53";
                    setting.Locale = "zh-CN"; // en-US
                    setting.AcceptLanguageList = "zh-CN";
                    Cef.Initialize(setting);
                    //CefSharp.Cef.Initialize(setting, false, new CefsharpHelpers.BrowserProcessHandler());
                }

                var browser = chrome.CreateBrowser();
                //this.Invoke(new Action<Panel>(p =>
                //{
                //    p.Controls.Add(browser);
                //    p.Update();
                //}), this.panel1);
                Panel pan = new Panel();

                pan.Dock = DockStyle.Fill;
                panel1.Controls.Add(pan);
                panel1.Update();
                pan.Controls.Add(browser);
                pan.Update();


                //添加右键

                browser.MenuHandler = new  ContextMenuHandler();




            }
        }

        void ApplicationExit_CefSharp(object sender, EventArgs e)
        {
            Cef.Shutdown();
            chrome.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.chrome.Back();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Dictionary<string, string> header = new Dictionary<string, string>();
            //header.Add("Referer", "http://www.nuoren365.com/");
            //header.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/69.0.3497.100 Safari/537.36");
            //header.Add("Accept-Language", "zh-CN,zh;q=0.9,en;q=0.8");
            //header.Add("ourstoryzj","ok");
            //header.Add("Referer", "http://www.nuoren365.com/");
            //CefsharpHelpers.RequestHandler.headerDic = header;

            //chrome.SetCookies("www.nuoren365.com", "login", "cc696ba2246b461298b37c12bf557abb");
            //chrome.SetCookies("www.nuoren365.com", "Hm_lvt_dd24df68c4022926519e13123766f33c", "1578324793,1578373052");
            //chrome.SetCookies("www.nuoren365.com", "Hm_lpvt_dd24df68c4022926519e13123766f33c", "1578373052");
            bind();
            this.chrome.JumpUrl(this.txtUrl.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.chrome.Forward();
        }

        private void test_chrome_Load(object sender, EventArgs e)
        {
            //Application.ApplicationExit += ApplicationExit_CefSharp;
            bind();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            chrome.ClearCookie();
            chrome.Dispose();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            chrome.ShowTools();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            chrome.click(25, 23);

            //Cef.CefSharpVersion.ToShow();
            //chrome.browser.Dispose();
            //chrome.browser = null;
            //Cef.GetGlobalCookieManager().DeleteCookies();
            //System.Diagnostics.Process.GetCurrentProcess().Kill();
            //chrome.ClearCookie();
            //chrome.Dispose();
            //.Cef.Shutdown();
            //try
            //{
            //    chrome.browser.CloseDevTools();
            //    chrome.browser.GetBrowser().CloseBrowser(true);
            //}
            //catch { }

            //try
            //{
            //    if (chrome.browser != null)
            //    {
            //        chrome.browser.GetBrowser().CloseBrowser(false);
            //        //chrome.browser.GetBrowser().Dispose();
            //        chrome.browser.Parent.Dispose();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    ex.ToString().ToShow();
            //    //throw;
            //}

            //chrome.browser.Parent.Dispose();
            //try
            //{
            //    if (chrome.browser != null)
            //    {
            //        chrome.browser.Dispose();
            //        Cef.Shutdown();
            //    }
            //}
            //catch { }
        }
    }
}
