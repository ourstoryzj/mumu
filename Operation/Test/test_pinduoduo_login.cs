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

namespace excel_operation.Test
{
    public partial class test_pinduoduo_login : Form
    {
        ChromiumWebBrowser webBrowser1;
        public test_pinduoduo_login()
        {
            InitializeComponent();

            webBrowser1 = new ChromiumWebBrowser("https://mobile.yangkeduo.com/personal.html?refer_page_name=index&refer_page_id=10002_1574496288865_ZKZKA8HgWJ&refer_page_sn=10002&page_id=10001_1577246196934_4h0wdL6yBD&is_back=1");

            try
            {
                webBrowser1.RequestHandler = new MyRequestHandler();
            }
            catch (Exception ex)
            {
                ex.ToString().ToShow();
            }
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

            setcookies("api_uid", "rBQEGVyEcqajxSXXHdgWAg==");
            setcookies("_nano_fp", "XpdyX5gJXqU8X0Txl9_39owETlida0mp3wjs8IF4");
            setcookies("ua", "Mozilla%2F5.0%20(Windows%20NT%206.1%3B%20Win64%3B%20x64)%20AppleWebKit%2F537.36%20(KHTML%2C%20like%20Gecko)%20Chrome%2F74.0.3729.169%20Safari%2F537.36");
            setcookies("webp", "1");
            setcookies("pdd_user_id", "5472535098");
            setcookies("pdd_user_uin", "S2BYMXSYU3H7XKJEZP64VHHA6A_GEXDA");
            setcookies("PDDAccessToken", "DWOFZIRJVOWHSLARZFIP3OV5KT4QBYKQXT2NCO2L2AWDMQBES7BA1123a4a");
            setcookies("rec_list_orders", "rec_list_orders_ydAAn6");
            setcookies("msec", "1800000");
            setcookies("rec_list_personal", "rec_list_personal_tg7m2p");


            
            webBrowser1.FrameLoadStart += Browser.BrowserFrameLoadStart;
            webBrowser1.FrameLoadEnd += Browser.BrowserFrameLoadEnd;
            webBrowser1.Size = new Size(990, 725);
            webBrowser1.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            webBrowser1.Dock = DockStyle.Fill;
            
            //tabPage1.Controls.Add(webBrowser1);

            
            //Cef.
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



        private void button1_Click(object sender, EventArgs e)
        {
            //string path1 = Application.StartupPath + "\\1.zip";
            //string path2 = Application.StartupPath+"\\1" ;
            ////Common.RarHelper.ExeRAR(path1, "AutoUpdater.zip");
            ////Common.RarHelper.ExeRAR2(path1, path2);
            ////Common.RarHelper.CondenseRarOrZip(path1, path1 + ".rar", true, "");
            //MessageBox.Show("成功");
            //if (NetHelper.IsInternetAvailable())
            //    if (Common.WiFiHelper.HasNetWork())

            //    "有网络".ToShow();

            //else
            //    "无网络".ToShow();
            ToWebClient();
        }


        void ToWebClient()
        {
            try
            {
                WebClient MyWebClient = new WebClient();

                MyWebClient.Credentials = CredentialCache.DefaultCredentials;//获取或设置用于向Internet资源的请求进行身份验证的网络凭据
                Byte[] pageData = MyWebClient.DownloadData(txt_url.Text); //从指定网站下载数据
                string pageHtml = Encoding.Default.GetString(pageData);  //如果获取网站页面采用的是GB2312，则使用这句            
                                                                         //string pageHtml = Encoding.UTF8.GetString(pageData); //如果获取网站页面采用的是UTF-8，则使用这句
                Console.WriteLine(pageHtml);//在控制台输入获取的内容
                //using (StreamWriter sw = new StreamWriter("c:\\test\\ouput.html"))//将获取的内容写入文本
                //{
                //    sw.Write(pageHtml);
                //}
                txt_html.Text = pageHtml;

                Console.ReadLine(); //让控制台暂停,否则一闪而过了             
            }
            catch (WebException webEx)
            {
                Console.WriteLine(webEx.Message.ToString());
            }
            "成功".ToShow();
        }


        void ToWebBrowser()
        {
            WebBrowser web = new WebBrowser();
            web.Navigate(txt_url.Text);
            web.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(web_DocumentCompleted);
            "成功".ToShow();
        }
        void web_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser web = (WebBrowser)sender;
            HtmlElementCollection ElementCollection = web.Document.GetElementsByTagName("Body");

            foreach (HtmlElement item in ElementCollection)
            {
                //File.AppendAllText("Kaijiang_xj.txt", item.InnerText);
                txt_html.Text = txt_html.Text + item.InnerText;
            }
        }



        HttpWebRequest httpReq;
        HttpWebResponse httpResp;

        string strBuff = "";
        char[] cbuffer = new char[256];
        int byteRead = 0;

        //string filename = @"c:\log.txt";
        ///定义写入流操作 
        public void ToWriteStream()
        {
            Uri httpURL = new Uri(txt_url.Text);
            ///HttpWebRequest类继承于WebRequest，并没有自己的构造函数，需通过WebRequest的Creat方法 建立，并进行强制的类型转换 
            httpReq = (HttpWebRequest)WebRequest.Create(httpURL);
            ///通过HttpWebRequest的GetResponse()方法建立HttpWebResponse,强制类型转换
            httpResp = (HttpWebResponse)httpReq.GetResponse();
            ///GetResponseStream()方法获取HTTP响应的数据流,并尝试取得URL中所指定的网页内容
            ///若成功取得网页的内容，则以System.IO.Stream形式返回，若失败则产生ProtoclViolationException错 误。在此正确的做法应将以下的代码放到一个try块中处理。这里简单处理 
            Stream respStream = httpResp.GetResponseStream();
            ///返回的内容是Stream形式的，所以可以利用StreamReader类获取GetResponseStream的内容，并以StreamReader类的Read方法依次读取网页源程序代码每一行的内容，直至行尾（读取的编码格式：UTF8） 
            StreamReader respStreamReader = new StreamReader(respStream, Encoding.UTF8);
            //byteRead = respStreamReader.Read(cbuffer, 0, 256);

            //while (byteRead != 0)
            //{
            //    string strResp = new string(cbuffer, 0, byteRead);
            //    strBuff = strBuff + strResp;
            //    byteRead = respStreamReader.Read(cbuffer, 0, 256);
            //}
            txt_html.Text = respStreamReader.ReadToEnd();
            respStream.Close();
            //txt_html.Text = strBuff;
            "成功".ToShow();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ToWebBrowser();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ToWriteStream();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string strId = "guest";
            string strPassword = "123456";

            ASCIIEncoding encoding = new ASCIIEncoding();
            string postData = "userid=" + strId;
            postData += ("&password=" + strPassword);

            byte[] data = encoding.GetBytes(postData);

            // Prepare web request
            HttpWebRequest myRequest =
            (HttpWebRequest)WebRequest.Create("http://www.sina.com/login.asp");

            myRequest.Method = "POST";
            myRequest.ContentType = "application/x-www-form-urlencoded";
            myRequest.ContentLength = data.Length;
            Stream newStream = myRequest.GetRequestStream();

            // Send the data.
            newStream.Write(data, 0, data.Length);
            newStream.Close();

            // Get response
            //HttpWebResponse myResponse=(HttpWebResponse)myRequest.GetResponse();
            //StreamReader reader = new StreamReader(response.GetResponseStream(),Encoding.Default);
            //string content = reader.ReadToEnd();
            //Response.Write(content); 
        }

        private void txt_url_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
