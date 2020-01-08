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
using System.Runtime.InteropServices;
using System.Web;
using System.Collections.Specialized;

namespace Operation.Test
{
    public partial class test_nuoren : Form
    {
        //ChromiumWebBrowser webBrowser1;
        public test_nuoren()
        {
            InitializeComponent();

            //webBrowser2.Navigate("http://www.nuoren365.com", "_self", null, "Referer: http://www.nuoren365.com/member/");



            //panel1.Controls.Add(webBrowser1);


            //Cef.
            //test();
        }

        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool InternetSetCookie(string lpszUrlName, string lbszCookieName, string lpszCookieData);
        private void test()
        {

            string cookie = "login=cc696ba2246b461298b37c12bf557abb; Hm_lvt_dd24df68c4022926519e13123766f33c=1578324793,1578373052;Hm_lpvt_dd24df68c4022926519e13123766f33c=1578373052";//需要设置到Webbrowser的Cookie信息
            string url = "http://www.nuoren365.com";//访问地址
            string domain = "www.nuoren365.com";//目标主机域名
            foreach (string c in cookie.Split(';'))
            {
                string[] item = c.Split('=');
                if (item.Length == 2)
                {
                    InternetSetCookie(url, null, new System.Net.Cookie(HttpUtility.UrlEncode(item[0]).Replace("+", ""), HttpUtility.UrlEncode(item[1]), "; expires = Session GMT", "/").ToString());
                }
            }
            //webBrowser2.Navigate(url);
            webBrowser2.Navigate("http://www.nuoren365.com", "_self", null, "Referer: http://www.nuoren365.com/member/");
        }


        void webbrowser_FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {

            ChromiumWebBrowser browser = (ChromiumWebBrowser)sender;
            //浏览器缩放比例
            browser.SetZoomLevel(3);

        }






        private void txt_url_TextChanged(object sender, EventArgs e)
        {

        }

        public static void SetHeaderValue(WebHeaderCollection header, string name, string value)
        {
            var property = typeof(WebHeaderCollection).GetProperty("InnerCollection",
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            if (property != null)
            {
                var collection = property.GetValue(header, null) as NameValueCollection;
                collection[name] = value;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            string cookie = "login=cc696ba2246b461298b37c12bf557abb; Hm_lvt_dd24df68c4022926519e13123766f33c=1578324793,1578373052;Hm_lpvt_dd24df68c4022926519e13123766f33c=1578373052";//需要设置到Webbrowser的Cookie信息
            #region MyRegion


            //string contentUrl = "http://www.nuoren365.com/member/#/public/extension-center/extension-link";
            //HttpWebRequest hwr = (HttpWebRequest)WebRequest.Create(contentUrl);
            //hwr.Method = "GET";
            ////hwr.Connection = "keep-alive";
            //SetHeaderValue(hwr.Headers, "Connection", "keep-alive");
            ////hwr.Headers.Add("Connection", "keep-alive");
            ////hwr.Headers.Add("Cache-Control", "max-age=0");
            ////hwr.Headers.Add("Upgrade-Insecure-Requests", "1");
            //SetHeaderValue(hwr.Headers, "Upgrade-Insecure-Requests", "1");
            ////hwr.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/69.0.3497.100 Safari/537.36");
            ////hwr.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/69.0.3497.100 Safari/537.36";
            //SetHeaderValue(hwr.Headers, "User-Agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/69.0.3497.100 Safari/537.36");
            ////hwr.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8");
            ////hwr.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8";
            //SetHeaderValue(hwr.Headers, "Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8");
            ////hwr.Headers.Add("Referer", "http://www.nuoren365.com/member/");
            //hwr.Referer = "http://www.nuoren365.com/member/";
            //hwr.Headers.Add("Accept-Encoding", "gzip, deflate");
            //hwr.Headers.Add("Accept-Language", "zh-CN,zh;q=0.9,en;q=0.8");
            ////hwr.Headers.Add("test", "test");
            ////hwr.Headers.Add("test", "test");
            ////hwr.Headers.Add("test", "test");


            //hwr.AllowAutoRedirect = false;
            //hwr.ContentType = "application/x-www-form-urlencoded";
            //hwr.CookieContainer = new CookieContainer();
            //hwr.CookieContainer.SetCookies(hwr.RequestUri, "login=cc696ba2246b461298b37c12bf557abb");
            //hwr.CookieContainer.SetCookies(hwr.RequestUri, "Hm_lvt_dd24df68c4022926519e13123766f33c=1578324793,1578373052");
            //hwr.CookieContainer.SetCookies(hwr.RequestUri, "Hm_lpvt_dd24df68c4022926519e13123766f33c=1578373052");
            //HttpWebResponse hwp = (HttpWebResponse)hwr.GetResponse();
            //string html = new StreamReader(hwp.GetResponseStream()).ReadToEnd();
            //textBox1.Text = html; 
            #endregion

            CookieContainer cc = new CookieContainer();
            string url = "http://www.nuoren365.com";

            cc.SetCookies(new System.Uri(url), "login=cc696ba2246b461298b37c12bf557abb");
            cc.SetCookies(new System.Uri(url), "Hm_lvt_dd24df68c4022926519e13123766f33c=1578324793,1578373052");
            cc.SetCookies(new System.Uri(url), "Hm_lpvt_dd24df68c4022926519e13123766f33c=1578373052");
            //cc.SetCookies(new System.Uri(url), cookie);

            string content = CS.HttpWeb.SendDataByGET(url, "", ref cc);
            content = CS.HttpWeb.SendDataByGET("http://www.nuoren365.com/member/#/public/extension-center/extension-link", "",ref cc);
            textBox1.Text = content;
            Console.WriteLine(content);
            Console.ReadLine();
        }
    }
}
