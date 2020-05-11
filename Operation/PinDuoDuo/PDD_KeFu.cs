using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Operation.PinDuoDuo
{
    public partial class PDD_KeFu : Form
    {

        CefSharp.WinForms.ChromiumWebBrowser webBrowser1;

        public PDD_KeFu()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            //http://mms.pinduoduo.com/assets/chat-merchant/dist/index.html?r=0.09165449552232374
            webBrowser1 = new ChromiumWebBrowser("http://mms.pinduoduo.com/assets/chat-merchant/dist/index.html");
            webBrowser1.FrameLoadStart += Browser.BrowserFrameLoadStart;
            webBrowser1.FrameLoadEnd += Browser.BrowserFrameLoadEnd;
            webBrowser1.Size = new Size(989, 723);
            //webBrowser1.Location = new Point(180, 12);
            webBrowser1.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            this.Controls.Add(webBrowser1);

            

            //test();
        }


        //    [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        //    public static extern bool InternetSetCookie(string lpszUrlName, string lbszCookieName, string lpszCookieData);

        //    void test()
        //    {
        //        InternetSetCookie("http://mms.pinduoduo.com/assets/chat-merchant/dist/index.html", "", Globals.ThisDocument.sessionID);
        //        CookieContainer myCookieContainer = new CookieContainer();

        //        string cookieStr = webBrowser1.Document.Cookie;
        //        webBrowser1
        //        string[] cookstr = cookieStr.Split(';');
        //        foreach (string str in cookstr)
        //        {
        //            string[] cookieNameValue = str.Split('=');
        //            Cookie ck = new Cookie(cookieNameValue[0].Trim().ToString(), cookieNameValue[1].Trim().ToString());
        //            myCookieContainer.Add(ck);
        //        }

        //    }




        public static void SetCefCookies(string url, CookieCollection cookies)
        {
            //Cef.GetGlobalCookieManager().SetStoragePath(Environment.CurrentDirectory, true);
            //foreach (System.Net.Cookie c in cookies)
            //{
            //    var cookie = new CefSharp.Cookie
            //    {
            //        Creation = DateTime.Now,
            //        Domain = c.Domain,
            //        Name = c.Name,
            //        Value = c.Value,
            //        Expires = c.Expires
            //    };
            //    Task<bool> task = Cef.GetGlobalCookieManager().SetCookieAsync(url, cookie);
            //    while (!task.IsCompleted)
            //    {
            //        continue;
            //    }
            //    bool b = task.Result;
            //}
        }









    }



}
