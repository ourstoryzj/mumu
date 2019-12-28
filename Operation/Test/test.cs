using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace Operation
{
    //通过webBrowser实现C#和javascript互调
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    public partial class test : Form
    {
        public test()
        {
            InitializeComponent();

        }




        //public void Load()
        //{
        //    Image img = Image.FromStream(Info("ftp://211.145.1.137/feibiht/upLoad/img/", "noimg.gif"));
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="ftpUrl">FTP地址</param>
        ///// <param name="fileName">文件名</param>
        ///// <returns></returns>
        //public Stream Info(string ftpUrl, string fileName)
        //{
        //    try
        //    {
        //        System.Net.HttpWebRequest reqFtp = (System.Net.HttpWebRequest)FtpWebRequest.Create(new Uri(ftpUrl + "" + fileName));
        //        reqFtp.UseBinary = true;
        //        FtpWebResponse respFtp = (FtpWebResponse)reqFtp.GetResponse();
        //        Stream stream = respFtp.GetResponseStream();
        //        return stream;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}



        private void btn_caiji_Click(object sender, EventArgs e)
        {

            //string yuanma = GetHtml("https://item.taobao.com/item.htm?id=543453514423&abbucket=0");
            //string name = cb_name.Text;
            //string url = GetURL_gaojisousuo(name);
            //string nameHtml = GetHtml2(url);
            ////textBox1.Text = nameHtml;
            //webBrowser2.DocumentText = nameHtml;
            //webBrowser1.Navigate(url);
            //textBox1.Text = url;


            try
            {
                if (webBrowser1.Document != null)
                {

                    HtmlElement elem = webBrowser1.Document.GetElementById("J_RateCounter");//加载完成后才有的标签
                    //HtmlElement elem = webBrowser1.Document
                    if (elem != null)
                    {
                        //webBrowser1.Document.
                        //webBrowser2.DocumentText = webBrowser1.Document.Body.OuterHtml;
                        //C#调用JS代码
                        //object returnvalue = EXEC_JS(webBrowser1, "js_fun|参数字符串");
                        //MessageBox.Show("js方法返回值是：" + returnvalue.ToString());
                        //webBrowser1.Document.InvokeScript(
                        //string jsfile = Path.Combine(Environment.CurrentDirectory, "mzwucom.js");
                        //HtmlElement element = webBrowser1.Document.CreateElement("script");
                        //element.InnerHtml = "function test(){return ss;}";
                        //element
                        //webBrowser2.DocumentText = webBrowser1.DocumentText;
                        //string s = webBrowser1.Document.InvokeScript("test").ToString();
                        //MessageBox.Show(s);
                        //IHTMLDocument2 vDocument = (mshtml.IHTMLDocument2)webBrowser1.Document.DomDocument;
                        //vDocument.parentWindow.execScript(
                        //        "function   alert(str){if(str== 'zswang ')confirm(str);} ", "javaScript ");

                        //先添加JQuery
                        // <script src="js/jquery-1.4.3.min.js" type="text/javascript"></script>
                        //HtmlElement he_jpuery = webBrowser1.Document.CreateElement("script");
                        //he_jpuery.SetAttribute("src", "js/jquery-1.4.3.min.js");
                        //he_jpuery.SetAttribute("type", "text/javascript");
                        //webBrowser1.Document.Body.AppendChild(he_jpuery);
                        /*
                         function getElementByClassName(className){
               var elems = [];
               if(!getClassName){
                   alert("no exit");
                   var dom = document.getElementByTagName('*');
                   for(var i = 0;i<dom.length;i++){
                       if(dom[i].className == className)
                         {
                            elems.push(dom[i]);
                         }
                   }
                }else{
                    elems = getClassName(className);
                    alert('exit');
                }
                return elems;
           }*/

                        //先添加getElementsByClassName
                        //HtmlElement he_class = webBrowser1.Document.CreateElement("script");
                        //he_class.SetAttribute("type", "text/javascript");
                        //he_class.SetAttribute("text", " function getElementByClassName(className) {   var elems = [];if (!getClassName) {alert('no exit'); var dom = document.getElementByTagName('*'); for (var i = 0; i < dom.length; i++) {if (dom[i].className == className) {elems.push(dom[i]); }}}else {elems = getClassName(className);alert('exit'); }return elems;}             ");
                        //webBrowser1.Document.Body.AppendChild(he_class);


                        HtmlElement ele = webBrowser1.Document.CreateElement("script");
                        ele.SetAttribute("type", "text/javascript");
                        ele.SetAttribute("text", "function setHtml(){alert(getClassName('J_FavCount')[0].innerText);}");
                        //ele.SetAttribute("text", "function setHtml(){   alert(document.getElementById('J_RateCounter').innerText);alert(getElementByClassName('J_FavCount')[0].innerText    );     }");
                        webBrowser1.Document.Body.AppendChild(ele);
                        webBrowser1.Document.InvokeScript("setHtml");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




        }


        /// <summary>
        /// 根据店铺账号获取淘宝高级搜索页面网址
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string GetURL_gaojisousuo(string name)
        {
            string url = "https://list.taobao.com/itemlist/default.htm?atype=b&cat=0&style=list&nick=" + name + "&as=0&viewIndex=1&same_info=1&isnew=2&tid=0&_input_charset=utf-8";
            //url = "https://shopsearch.taobao.com/search?app=shopsearch&q=" + name + "&commend=all&ssid=s5-e&search_type=shop&atype=&filterFineness=";
            //商品列表页面
            url = "https://miss-dz.taobao.com/search.htm?spm=a1z10.3-c-s.w4002-14460596614.18.lMdjBy&_ksTS=1482480337437_474&callback=jsonp475&mid=w-14460596614-0&wid=14460596614&path=%2Fsearch.htm&qq-pf-to=pcqq.group&orderType=hotsell_desc";
            //商品详细页面
            url = "https://item.taobao.com/item.htm?spm=a1z10.3-c-s.w4002-14460596614.23.Dbj1Be&id=540733715384";
            return url;
        }





        #region  获取页面源码

        /// <summary>
        /// 三、使用HttpWebRequest/HttpWebResponse获取网页内容
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public string GetHtml3(string url)
        {
            //var url = "http://www.360doc.com/content/11/0427/03/1947337_112596569.shtml";  
            string strBuff = "";//定义文本字符串，用来保存下载的html  
            int byteRead = 0;

            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
            //若成功取得网页的内容，则以System.IO.Stream形式返回，若失败则产生ProtoclViolationException错 误。在此正确的做法应将以下的代码放到一个try块中处理。这里简单处理   
            Stream reader = webResponse.GetResponseStream();
            //返回的内容是Stream形式的，所以可以利用StreamReader类获取GetResponseStream的内容，并以StreamReader类的Read方法依次读取网页源程序代码每一行的内容，直至行尾（读取的编码格式：UTF8）  
            StreamReader respStreamReader = new StreamReader(reader, Encoding.Default);

            //分段，分批次获取网页源码  
            char[] cbuffer = new char[1024];
            byteRead = respStreamReader.Read(cbuffer, 0, 256);

            while (byteRead != 0)
            {
                string strResp = new string(cbuffer, 0, byteRead);
                strBuff = strBuff + strResp;
                byteRead = respStreamReader.Read(cbuffer, 0, 256);
            }
            reader.Close();
            return strBuff;
            //using (StreamWriter sw = new StreamWriter("e:\\ouput.txt"))//将获取的内容写入文本  
            //{  
            //    htm = sw.ToString();//测试StreamWriter流的输出状态，非必须  
            //    sw.Write(strBuff);  
            //}  
        }


        /// <summary>
        /// 一、通过WebClient获取网页内容
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public string GetHtml1(string url)
        {
            string pageHtml = "";
            try
            {
                WebClient webClient = new WebClient();
                webClient.Credentials = CredentialCache.DefaultCredentials;//获取或设置用于向Internet资源的请求进行身份验证的网络凭据  
                Byte[] pageData = webClient.DownloadData(url);
                pageHtml = Encoding.Default.GetString(pageData);  //如果获取网站页面采用的是GB2312，则使用这句         
                //pageHtml = Encoding.UTF8.GetString(pageData); //如果获取网站页面采用的是UTF-8，则使用这句  
                //using (StreamWriter sw = new StreamWriter("e:\\ouput.txt"))//将获取的内容写入文本  
                //{  
                //    htm = sw.ToString();//测试StreamWriter流的输出状态，非必须  
                //    sw.Write(pageHtml);  
                //}  

            }
            catch (WebException webEx)
            {
                //Console.W;
                MessageBox.Show(webEx.Message);
            }
            return pageHtml;
        }


        //void web_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        //{
        //    WebBrowser web = (WebBrowser)sender;
        //    HtmlElementCollection ElementCollection = web.Document.GetElementsByTagName("Table");
        //    foreach (HtmlElement item in ElementCollection)
        //    {
        //        //File.AppendAllText("Kaijiang_xj.txt", item.InnerText);
        //    }
        //}

        public string GetHtml2(string url)
        {
            //WebBrowser web = new WebBrowser();
            //web.Navigate(url);
            //web.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(web_DocumentCompleted);

            //1
            WebBrowser web = new WebBrowser();
            web.Navigate(url);







            web.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(web_DocumentCompleted); //当网页加载完成时触发该事件，获取网页数据

            //----------------------------------

            //3、使用HttpWebRequest/HttpWebResponse
            HttpWebRequest httpReq;
            HttpWebResponse httpResp;
            Uri httpURL = new Uri(url);
            httpReq = (HttpWebRequest)WebRequest.Create(httpURL);
            httpResp = (HttpWebResponse)httpReq.GetResponse();
            Stream reader = httpResp.GetResponseStream(); //得到数据流，再把数据流转化为特定的数据（图片，文本。。。）

            //4
            StreamReader respStreamReader = new StreamReader(reader, Encoding.Default);
            string strBuff = "";//定义文本字符串，用来保存下载的html  
            int byteRead = 0;
            //分段，分批次获取网页源码  
            char[] cbuffer = new char[1024];
            byteRead = respStreamReader.Read(cbuffer, 0, 256);

            while (byteRead != 0)
            {
                string strResp = new string(cbuffer, 0, byteRead);
                strBuff = strBuff + strResp;
                byteRead = respStreamReader.Read(cbuffer, 0, 256);
            }
            reader.Close();
            return strBuff;


        }
        void web_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {//2获取该html页面内的Table标签的内容
            WebBrowser web = (WebBrowser)sender;
            HtmlElementCollection ElementCollection = web.Document.GetElementsByTagName("Table");
            foreach (HtmlElement item in ElementCollection)
            {
                textBox1.AppendText(item.InnerText + "\n");
            }

        }


        public string GetHtml4(string url)
        {
            string res = "";
            //WebBrowser web = new WebBrowser();
            //web.DocumentCompleted;


            return res;
        }


        #endregion




        private void test_Load(object sender, EventArgs e)
        {
            //string URL = "网址";//网址
            webBrowser1.Navigate(GetURL_gaojisousuo("test"));
            webBrowser1.ObjectForScripting = this;  //这句必须，不然js不能调用C#
        }

        #region 调用脚本方法
        /// <summary>
        /// 脚本方法
        /// </summary>
        /// <param name="webBrowser"></param>
        /// <param name="tag">JS函数名|参数1|参数2</param>
        /// <returns></returns>
        private object EXEC_JS(System.Windows.Forms.WebBrowser webBrowser, string tag)
        {
            string[] args = tag.Split('|');
            if (args.Length == 1)
            {
                return webBrowser.Document.InvokeScript(args[0], null);
            }
            else
            {
                object[] objects = new object[args.Length - 1];
                Array.Copy(args, 1, objects, 0, objects.Length);
                return webBrowser.Document.InvokeScript(args[0], objects);
            }
        }
        #endregion


        private void timer1_Tick(object sender, EventArgs e)
        {

            try
            {
                if (webBrowser1.Document != null)
                {

                    HtmlElement elem = webBrowser1.Document.GetElementById("J_RateCounter");//加载完成后才有的标签
                    //HtmlElement elem = webBrowser1.Document
                    if (elem != null)
                    {
                        //webBrowser1.Document.
                        //webBrowser2.DocumentText = webBrowser1.Document.Body.OuterHtml;
                        //C#调用JS代码
                        //object returnvalue = EXEC_JS(webBrowser1, "js_fun|参数字符串");
                        //MessageBox.Show("js方法返回值是：" + returnvalue.ToString());
                        //webBrowser1.Document.InvokeScript(
                        //string jsfile = Path.Combine(Environment.CurrentDirectory, "mzwucom.js");
                        //HtmlElement element = webBrowser1.Document.CreateElement("script");
                        //element.InnerHtml = "function test(){return ss;}";
                        //element
                        //webBrowser2.DocumentText = webBrowser1.DocumentText;
                        //string s = webBrowser1.Document.InvokeScript("test").ToString();
                        //MessageBox.Show(s);
                        //IHTMLDocument2 vDocument = (mshtml.IHTMLDocument2)webBrowser1.Document.DomDocument;
                        //vDocument.parentWindow.execScript(
                        //        "function   alert(str){if(str== 'zswang ')confirm(str);} ", "javaScript ");

                        HtmlElement ele = webBrowser1.Document.CreateElement("script");
                        ele.SetAttribute("type", "text/javascript");
                        ele.SetAttribute("text", "function setHtml(){alert(getElementById('J_RateCounter').innerText);var aaa='1234';alert('1235');}");
                        webBrowser1.Document.Body.AppendChild(ele);
                        webBrowser1.Document.InvokeScript("setHtml");

                        timer1.Enabled = false;
                        //timer1.Stop();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //timer1.Stop();

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            webBrowser1.Document.InvokeScript("setHtml");
            string test = BLL2.Manager1.decl_Admin;
        }


    }



}
