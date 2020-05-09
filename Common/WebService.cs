using System;
using System.Collections.Generic;
using System.IO;

using System.Net;
using System.Text;

using System.Windows.Forms;

namespace Common
{
    /// <summary>
    /// Web采集类
    /// </summary>
    public class WebService
    {

        #region GetHtml

        /// <summary> 
        ///  获取网址HTML 
        /// </summary> 
        /// <param name="URL">网址 </param> 
        /// <returns> </returns> 
        public static string GetHtml(string URL)
        {
            WebRequest wrt;
            wrt = WebRequest.Create(URL);
            wrt.Credentials = CredentialCache.DefaultCredentials;
            WebResponse wrp;
            wrp = wrt.GetResponse();
            string reader = new StreamReader(wrp.GetResponseStream(), Encoding.GetEncoding("gb2312")).ReadToEnd();
            try
            {
                wrt.GetResponse().Close();
            }
            catch (WebException ex)
            {
                throw ex;
            }
            return reader;
        }
        /// <summary> 
        /// 获取网站cookie 
        /// </summary> 
        /// <param name="URL">网址 </param> 
        /// <param name="cookie">cookie </param> 
        /// <returns> </returns> 
        public static string GetHtml(string URL, out string cookie)
        {
            WebRequest wrt;
            wrt = WebRequest.Create(URL);
            wrt.Credentials = CredentialCache.DefaultCredentials;
            WebResponse wrp;
            wrp = wrt.GetResponse();
            string html = new StreamReader(wrp.GetResponseStream(), Encoding.GetEncoding("gb2312")).ReadToEnd();
            try
            {
                wrt.GetResponse().Close();
            }
            catch (WebException ex)
            {
                throw ex;
            }
            cookie = wrp.Headers.Get("Set-Cookie");
            return html;
        }
        public static string GetHtml(string URL, string postData, string cookie, out string header, string server)
        {
            return GetHtml(server, URL, postData, cookie, out header);
        }
        public static string GetHtml(string server, string URL, string postData, string cookie, out string header)
        {
            byte[] byteRequest = Encoding.GetEncoding("gb2312").GetBytes(postData);
            return GetHtml(server, URL, byteRequest, cookie, out header);
        }
        public static string GetHtml(string server, string URL, byte[] byteRequest, string cookie, out string header)
        {
            byte[] bytes = GetHtmlByBytes(server, URL, byteRequest, cookie, out header);
            Stream getStream = new MemoryStream(bytes);
            StreamReader streamReader = new StreamReader(getStream, Encoding.GetEncoding("gb2312"));
            string getString = streamReader.ReadToEnd();
            streamReader.Close();
            getStream.Close();
            return getString;
        }
        /// <summary> 
        /// Post模式浏览 
        /// </summary> 
        /// <param name="server">服务器地址 </param> 
        /// <param name="URL">网址 </param> 
        /// <param name="byteRequest">流 </param> 
        /// <param name="cookie">cookie </param> 
        /// <param name="header">句柄 </param> 
        /// <returns> </returns> 
        public static byte[] GetHtmlByBytes(string server, string URL, byte[] byteRequest, string cookie, out string header)
        {
            long contentLength;
            HttpWebRequest httpWebRequest;
            HttpWebResponse webResponse;
            Stream getStream;
            httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(URL);
            CookieContainer co = new CookieContainer();
            co.SetCookies(new Uri(server), cookie);
            httpWebRequest.CookieContainer = co;
            httpWebRequest.ContentType = "application/x-www-form-urlencoded";
            httpWebRequest.Accept =
                "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";
            httpWebRequest.Referer = server;
            httpWebRequest.UserAgent =
                "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; Maxthon; .NET CLR 1.1.4322)";
            httpWebRequest.Method = "Post";
            httpWebRequest.ContentLength = byteRequest.Length;
            Stream stream;
            stream = httpWebRequest.GetRequestStream();
            stream.Write(byteRequest, 0, byteRequest.Length);
            stream.Close();
            webResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            header = webResponse.Headers.ToString();
            getStream = webResponse.GetResponseStream();
            contentLength = webResponse.ContentLength;
            byte[] outBytes = new byte[contentLength];
            outBytes = ReadFully(getStream);
            getStream.Close();
            return outBytes;
        }
        public static byte[] ReadFully(Stream stream)
        {
            byte[] buffer = new byte[128];
            using (MemoryStream ms = new MemoryStream())
            {
                while (true)
                {
                    int read = stream.Read(buffer, 0, buffer.Length);
                    if (read <= 0)
                        return ms.ToArray();
                    ms.Write(buffer, 0, read);
                }
            }
        }
        /// <summary> 
        /// Get模式 
        /// </summary> 
        /// <param name="URL">网址 </param> 
        /// <param name="cookie">cookies </param> 
        /// <param name="header">句柄 </param> 
        /// <param name="server">服务器 </param> 
        /// <param name="val">服务器 </param> 
        /// <returns> </returns> 
        public static string GetHtml(string URL, string cookie, out string header, string server)
        {
            return GetHtml(URL, cookie, out header, server, "");
        }
        /// <summary> 
        /// Get模式浏览 
        /// </summary> 
        /// <param name="URL">Get网址 </param> 
        /// <param name="cookie">cookie </param> 
        /// <param name="header">句柄 </param> 
        /// <param name="server">服务器地址 </param> 
        /// <param name="val"> </param> 
        /// <returns> </returns> 
        public static string GetHtml(string URL, string cookie, out string header, string server, string val)
        {
            HttpWebRequest httpWebRequest;
            HttpWebResponse webResponse;
            Stream getStream;
            StreamReader streamReader;
            string getString = "";
            httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(URL);
            httpWebRequest.Accept = "*/*";
            httpWebRequest.Referer = server;
            CookieContainer co = new CookieContainer();
            co.SetCookies(new Uri(server), cookie);
            httpWebRequest.CookieContainer = co;
            httpWebRequest.UserAgent =
                "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; Maxthon; .NET CLR 1.1.4322)";
            httpWebRequest.Method = "GET";
            webResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            header = webResponse.Headers.ToString();
            getStream = webResponse.GetResponseStream();
            streamReader = new StreamReader(getStream, Encoding.GetEncoding("gb2312"));
            getString = streamReader.ReadToEnd();
            streamReader.Close();
            getStream.Close();
            return getString;
        }

        #endregion

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////


        #region 同步通过POST方式发送数据
        /// <summary>
        /// 通过POST方式发送数据
        /// </summary>
        /// <param name="Url">url</param>
        /// <param name="postDataStr">Post数据</param>
        /// <param name="cookie">Cookie容器</param>
        /// <returns></returns>
        public static string SendDataByPost(string Url, string postDataStr, ref CookieContainer cookie)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            if (cookie.Count == 0)
            {
                request.CookieContainer = new CookieContainer();
                cookie = request.CookieContainer;
            }
            else
            {
                request.CookieContainer = cookie;
            }

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = postDataStr.Length;
            Stream myRequestStream = request.GetRequestStream();
            StreamWriter myStreamWriter = new StreamWriter(myRequestStream, Encoding.GetEncoding("gb2312"));
            myStreamWriter.Write(postDataStr);
            myStreamWriter.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();

            return retString;
        }
        #endregion

        #region 同步通过GET方式发送数据
        /// <summary>
        /// 通过GET方式发送数据
        /// </summary>
        /// <param name="Url">url</param>
        /// <param name="postDataStr">GET数据</param>
        /// <param name="cookie">GET容器</param>
        /// <returns></returns>
        public static string SendDataByGET(string Url, string postDataStr, ref CookieContainer cookie)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url + (postDataStr == "" ? "" : "?") + postDataStr);
            if (cookie.Count == 0)
            {
                request.CookieContainer = new CookieContainer();
                cookie = request.CookieContainer;
            }
            else
            {
                request.CookieContainer = cookie;
            }

            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();

            return retString;
        }
        #endregion

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////



        #region GetHtmlByWebRequest
        /// <summary>
        /// 速度快,解析全面
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string GetHtmlByWebRequest(string url)
        {
            HttpWebRequest httpReq;
            HttpWebResponse httpResp;

            string res = "";

            try
            {
                Uri httpURL = new Uri(url);
                ///HttpWebRequest类继承于WebRequest，并没有自己的构造函数，需通过WebRequest的Creat方法 建立，并进行强制的类型转换 
                httpReq = (HttpWebRequest)WebRequest.Create(httpURL);
                ///通过HttpWebRequest的GetResponse()方法建立HttpWebResponse,强制类型转换
                httpResp = (HttpWebResponse)httpReq.GetResponse();
                ///GetResponseStream()方法获取HTTP响应的数据流,并尝试取得URL中所指定的网页内容
                ///若成功取得网页的内容，则以System.IO.Stream形式返回，若失败则产生ProtoclViolationException错 误。在此正确的做法应将以下的代码放到一个try块中处理。这里简单处理 
                Stream respStream = httpResp.GetResponseStream();
                ///返回的内容是Stream形式的，所以可以利用StreamReader类获取GetResponseStream的内容，并以StreamReader类的Read方法依次读取网页源程序代码每一行的内容，直至行尾（读取的编码格式：UTF8） 
                StreamReader respStreamReader = new StreamReader(respStream, Encoding.GetEncoding("gb2312"));
                //byteRead = respStreamReader.Read(cbuffer, 0, 256);

                //while (byteRead != 0)
                //{
                //    string strResp = new string(cbuffer, 0, byteRead);
                //    strBuff = strBuff + strResp;
                //    byteRead = respStreamReader.Read(cbuffer, 0, 256);
                //}
                res = respStreamReader.ReadToEnd();
                respStream.Close();

            }
            catch (Exception ex)
            {
                ex.ToLog();
            }
            return res;
        }
        #endregion


        #region GetHtmlByWebBrowser

        public static string GetHtmlByWebBrowser_res = "";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string GetHtmlByWebBrowser(string url)
        {
            string res = string.Empty;

            WebBrowser web = new WebBrowser();
            web.Navigate(url);
            //web.DocumentCompleted += Web_DocumentCompleted;
            web.ToWait();

            return web.Document.ToString();
        }

        private static void Web_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser web = (WebBrowser)sender;
            //HtmlElementCollection ElementCollection = web.Document.GetElementsByTagName("Body");

            //ElementCollection.tostr
            //foreach (HtmlElement item in ElementCollection)
            //{
            //    //File.AppendAllText("Kaijiang_xj.txt", item.InnerText);
            //    GetHtmlByWebBrowser_res += item.InnerText;
            //}
            GetHtmlByWebBrowser_res = web.Document.ToString();
        }

        #endregion


        #region GetHtmlByWebClient
        /// <summary>
        /// 使用WebClient获取网站数据
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string GetHtmlByWebClient(string url)
        {
            string res = string.Empty;

            try
            {
                WebClient wc = new WebClient();
                //获取或设置用于向Internet资源的请求进行身份验证的网络凭据
                wc.Credentials = CredentialCache.DefaultCredentials;
                //从指定网站下载数据
                Byte[] pageData = wc.DownloadData(url);
                //编码转换 如果获取网站页面采用的是GB2312，则使用这句 
                res = Encoding.Default.GetString(pageData);
                //如果获取网站页面采用的是UTF-8，则使用这句
                //string pageHtml = Encoding.UTF8.GetString(pageData); 
            }
            catch (Exception ex)
            {

                ex.ToString();
            }

            return res;
        } 
        #endregion


        #region GetIP
        public static string GetIP()
        {
            //string res = "";
            //string hostName = Dns.GetHostName();//本机名  
                                                //System.Net.IPAddress[] addressList = Dns.GetHostByName(hostName).AddressList;//会警告GetHostByName()已过期，我运行时且只返回了一个IPv4的地址  
            
            //System.Net.IPAddress[] addressList = Dns.GetHostAddresses(hostName);//会返回所有地址，包括IPv4和IPv6  
            //foreach (IPAddress ip in addressList)
            //{
            //    res += ip.ToString();
            //}
            System.Net.IPHostEntry myEntry = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
            string ipAddress = myEntry.AddressList[2].ToString();
            return ipAddress;
        }
        #endregion


    }
}
