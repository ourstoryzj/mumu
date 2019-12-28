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

namespace Operation.Test
{
    public partial class test_webrequest : Form
    {
        public test_webrequest()
        {
            InitializeComponent();
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
    }
}
