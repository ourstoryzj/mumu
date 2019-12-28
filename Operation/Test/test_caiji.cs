using CefSharp;
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

namespace Operation.Test
{
    public partial class test_caiji : Form
    {
        //CefSharp.WinForms.ChromiumWebBrowser webBrowser1;
        ChromiumWebBrowser browser;



        public test_caiji()
        {
            InitializeComponent();
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;

            var settines = new CefSettings()
            {
                Locale = "zh-CN",
                AcceptLanguageList = "zh-CN",
                MultiThreadedMessageLoop = true
            };

            //Cef.Initialize(settines);
            //browser.Location = new Point(10,10);
            browser = new ChromiumWebBrowser("http://www.baidu.com");//指定初始化地址
            browser.Size = new Size(10, 10);
            browser.Location = new Point(10, 10);
            browser.Anchor = AnchorStyles.Left | AnchorStyles.Top ;
            browser.Dock = DockStyle.None;
            this.Controls.Add(browser);
            //browser.Hide();

            

           // Browser.Delay(3000);
            //txt_res.Text = browser.GetSourceAsync().ToString();
            //加载开始事件
            browser.FrameLoadStart += Browser_FrameLoadStart;

            //加载完成后事件
            browser.FrameLoadEnd += Web_FrameLoadEnd;
        }

        private async void Web_FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {
            //一个网页会调用多次,需要手动自己处理逻辑
            var url = e.Url;
            var result = await browser.GetSourceAsync();
            var html = result;
            txt_url.Text = url;
            Test.test_caiji.txt_res.Text = html;
            
        }

        private void Browser_FrameLoadStart(object sender, FrameLoadStartEventArgs e)
        {
            string url = e.Url;
            //txt_url.Text = url;
        }



        //执行js代码
        void test()
        {
            browser.GetBrowser().MainFrame.ExecuteJavaScriptAsync("alert('这是c#调用的js,给文本框赋值！')");

            browser.GetBrowser().MainFrame.ExecuteJavaScriptAsync("document.getElementById('kw').value='在C#里面给页面文本框进行赋值'");

            //你可以做你任何想做的事了
        }






        private void btn_test_Click(object sender, EventArgs e)
        {
            string url = txt_url.Text.Trim();
            if (string.IsNullOrEmpty(url))
            {
                //url = "http://mobile.yangkeduo.com/catgoods.html?opt_id=4090&opt_type=2&opt_name=女包&opt_g=1&refer_page_name=search&refer_page_id=10031_1558412456662_9rTjgTYncO&refer_page_sn=10031";
                url = "https://s.taobao.com/search?q=女包&imgfile=&js=1&stats_click=search_radio_all%3A1&initiative_id=staobaoz_" + DateTime.Now.ToString("yyyyMMdd") + "&ie=utf8&sort=sale-desc";
            }
            browser.Load(url);
            //webBrowser1 = new CefSharp.WinForms.ChromiumWebBrowser(url);
            ////webBrowser1.Navigate(url);.
            //webBrowser1.FrameLoadEnd += BrowserFrameLoadEnd;
            // webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(webBrowser1_DocumentCompleted);

            Browser.Delay(5000);
            browser.Delete();
            //browser.Dispose();

        }

        //private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        //{
        //    MessageBox.Show("ok");

        //    System.IO.StreamReader streamReader = new System.IO.StreamReader(this.webBrowser1.DocumentStream, System.Text.Encoding.GetEncoding("gb2312"));//如果web浏览页面乱码可以使用这个方法进行转码

        //    string strWebBrowserDocument = streamReader.ReadToEnd();

        //    txt_res.Text = strWebBrowserDocument;
        //}


        #region BrowserFrameLoadEnd
        /// <summary>
        /// 加载完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void BrowserFrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {
            ChromiumWebBrowser ww = sender as ChromiumWebBrowser;
            
            string res = "";
            if (e.Frame.IsMain)
            {

                //webisok = false;
                try
                {
                    //webBrowser1.FrameLoadEnd += WebBrowser1_FrameLoadEnd;
                    while (true)
                    {
                        Browser.Delay(50);  //系统延迟50毫秒，够少了吧！
                        if (!ww.IsLoading)
                        {

                            //System.IO.StreamReader streamReader = new System.IO.StreamReader(ww, System.Text.Encoding.GetEncoding("gb2312"));//如果web浏览页面乱码可以使用这个方法进行转码
                            res= Browser.JS_CEFBrowser("document.body.innerHTML",ww);
                            txt_res.Text = res;
                            //if (webisok) //先判断是否发生完成事件。  
                            //{
                            //webisok = false;
                            //return true;
                            //}
                            return;
                        }
                        else
                        {
                            //如果网页还在加载
                            while (ww.IsLoading)
                            {
                                Browser.Delay(50);
                                res = Browser.JS_CEFBrowser("document.body.innerHTML", ww);
                                Test.test_caiji.txt_res.Text = res;
                                //txt_res.Text = res;
                                //if (webisok && !webBrowser1.IsLoading) //先判断是否发生完成事件。  
                                //{
                                //    webisok = false;
                                //    return true;
                                //}
                            }
                        }
                    }
                }
                catch 
                {
                    //Debug.WriteLine(e.ToString());
                }
                finally
                {
                    //webisok = false;
                }
                


                //webisok = true;

                //Delay(1000);
                //if (!ww.IsLoading)
                //{
                //    webisok = true;
                //}
                //MessageBox.Show("加载完成");
                //ww.FrameLoadEnd -= BrowserFrameLoadEnd;
                //var task1 = ww.GetSourceAsync();
                //task1.Wait();
                //string html = task1.Result;n


                //CefExtension ce = new CefExtension("", "");
                //MessageBox.Show("加载完成");
                //SetJSFile(ww);
                //Debug.WriteLine("加载完成");

                // Wait for the screenshot to be taken.

                //var task = ww.ScreenshotAsync();
                //ww.RectangleToScreen
                //task.Wait();

                // Make a file to save it to (e.g. C:\Users\jan\Desktop\CefSharp screenshot.png)
                //var screenshotPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "CefSharp screenshot.png");

                //Console.WriteLine();
                //Console.WriteLine("Screenshot ready.  Saving to {0}", screenshotPath);

                // Save the Bitmap to the path.
                // The image type is auto-detected via the ".png" extension.
                //task.Result.Save(screenshotPath);

                // We no longer need the Bitmap.
                // Dispose it to avoid keeping the memory alive.  Especially important in 32-bit applications.
                //task.Result.Dispose();

                //Console.WriteLine("Screenshot saved.  Launching your default image viewer...");

                // Tell Windows to launch the saved image.
                //Process.Start(screenshotPath);

                //Console.WriteLine("Image viewer launched.  Press any key to exit.");
            }
        }
        #endregion
    }
}
