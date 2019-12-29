using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;
using System.Net;
using System.IO;
using CefSharp.WinForms;
using CefSharp;

namespace Operation.Test
{
    public partial class test_pinduoduo_login : Form
    {
        ChromiumWebBrowser webBrowser1;
        public test_pinduoduo_login()
        {
            InitializeComponent();

            webBrowser1 = new ChromiumWebBrowser("https://mobile.yangkeduo.com/personal.html?refer_page_name=index&refer_page_id=10002_1574496288865_ZKZKA8HgWJ&refer_page_sn=10002&page_id=10001_1577246196934_4h0wdL6yBD&is_back=1");

            //try
            //{
            //    webBrowser1.RequestHandler = new MyRequestHandler();
            //}
            //catch (Exception ex)
            //{
            //    ex.ToString().ToShow();
            //}
            // webBrowser1.KeyboardHandler = new CefKeyboardHandler();
            //var setting = new CefSharp.CefSettings();
            //setting.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/74.0.3729.169 Safari/537.36";
            ////setting
            //CefSharp.Cef.Initialize(setting);
            // CookieCollection cc = new CookieCollection();
            //cc.Add()
            //Task<bool> SetCookieAsync("http://mobile.yangkeduo.com", cc);
            //var cookieManager = CefSharp.Cef.GetGlobalCookieManager();
            //var domain = "mobile.yangkeduo.com";

            //cookieManager.SetCookieAsync("http://" + domain, new CefSharp.Cookie()
            //{
            //    Domain = domain,
            //    Name = "api_uid",
            //    Value = "rBQEGVyEcqajxSXXHdgWAg==",
            //    Expires = DateTime.MinValue
            //});

            //cookieManager.SetCookieAsync("http://" + domain, new CefSharp.Cookie()
            //{
            //    Domain = domain,
            //    Name = "_nano_fp",
            //    Value = "XpdyX5gJXqU8X0Txl9_39owETlida0mp3wjs8IF4",
            //    Expires = DateTime.MinValue
            //});

            bind();

            Cef.EnableHighDPISupport();
            webBrowser1.FrameLoadStart += Browser.BrowserFrameLoadStart;
            webBrowser1.FrameLoadEnd += webbrowser_FrameLoadEnd;
            webBrowser1.Size = new Size(990, 725);
            webBrowser1.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            webBrowser1.Dock = DockStyle.Fill;  
            //webBrowser1.SetZoomLevel(1.25);
            
            panel1.Controls.Add(webBrowser1);

            
            //Cef.
        }

        void bind()
        {
            //setcookies("api_uid", "rBQEGVyEcqajxSXXHdgWAg==");
            //setcookies("Hm_lvt_96d9d92b8a4aac83bc206b6c9fb2844a", "1557407896,1557408269,1557499888,1557544239");
            //setcookies("UM_distinctid", "16c90459b2227-0151cd9b7dd60e-43450521-1fa400-16c90459b24c7");
            //setcookies("ua", "Mozilla%2F5.0%20(Windows%20NT%206.1%3B%20WOW64)%20AppleWebKit%2F537.36%20(KHTML%2C%20like%20Gecko)%20Chrome%2F69.0.3497.100%20Safari%2F537.36");
            //setcookies("webp", "1");
            //setcookies("CNZZDATA1256793290", "1526114749-1566392675-https%253A%252F%252Fmobile.yangkeduo.com%252F%7C1574561620");
            //setcookies("msec", "1800000");
            //setcookies("rec_list_mall_bottom", "rec_list_mall_bottom_hjpSJh");//测试是否需要
            //setcookies("rec_list_orders", "rec_list_orders_Lm90jL");//测试是否需要
            //setcookies("group_rec_list", "group_rec_list_EJkdal");//测试是否需要
            //setcookies("group_rec_list", "group_rec_list_EJkdal");//测试是否需要







            //setcookies("JSESSIONID", "B115F172C0F9B3C67121C14B91022390");//测试是否需要

            //需要改变的
            //setcookies("_nano_fp", "XpdYXp9JXpmbXqdynC_wnc3izkRTuCCIwjlXTMPM");
            //setcookies("pdd_user_uin", "S2BYMXSYU3H7XKJEZP64VHHA6A_GEXDA");
            //setcookies("pdd_user_id", "5472535098");
            //setcookies("PDDAccessToken", "2MESFI6BWGU5ML7VBPXYO6VWY2U4IO5SS7QDLQKGCDUMHXWFZXAA1123a4a");

            setcookies("pdd_user_id", "6217302188028");
            setcookies("PDDAccessToken", "SW26IAYOQRYSRYUHI72VGGKCYDH7ULUCHDTGYJVUGJFEPBH3FQVQ103fcbe");


        }

        void webbrowser_FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {

            ChromiumWebBrowser browser = (ChromiumWebBrowser)sender;

            browser.SetZoomLevel(3);

        }


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

        
        public static void SetCefCookies(string url, CookieCollection cookies)
        {
            Cef.GetGlobalCookieManager().SetStoragePath(Environment.CurrentDirectory, true);
            foreach (System.Net.Cookie c in cookies)
            {
                var cookie = new CefSharp.Cookie
                {
                    Creation = DateTime.Now,
                    Domain = c.Domain,
                    Name = c.Name,
                    Value = c.Value,
                    Expires = c.Expires
                };
                Task<bool> task = Cef.GetGlobalCookieManager().SetCookieAsync(url, cookie);
                while (!task.IsCompleted)
                {
                    continue;
                }
                bool b = task.Result;
            }
        }
 
        private void txt_url_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            bind();
            webBrowser1.Load("https://mobile.yangkeduo.com/personal.html?refer_page_name=index&refer_page_id=10002_1574496288865_ZKZKA8HgWJ&refer_page_sn=10002&page_id=10001_1577246196934_4h0wdL6yBD&is_back=1");
            
        }
    }
}
