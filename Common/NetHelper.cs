﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace Common
{
    /// <summary> 
    ///  Http操作类 
    /// </summary> 
    public static class NetHelper
    {
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

        /// <summary>
        /// 判断是否有网
        /// </summary>
        /// <returns>true为有网，false为无网</returns>
        public static bool IsInternetAvailable()
        {
            try
            {
                Dns.GetHostEntry("www.baidu.com"); //using System.Net;
                return true;
            }
            catch (Exception ex)
            {
                ex.ToString().ToLog();
                return false;
            }
        }


        /// <summary>
        /// 解决Keep-Alive 和 Close 不能使用此属性设置
        /// 这样要设置相应的http头就简单很多了，上面所说的两个http头可以直接如下代码一样进行设置：
        /// SetHeaderValue(request.Headers, "Host", "hejingzong.cn");
        /// SetHeaderValue(request.Headers, "Connection", "keep-alive");
        /// </summary>
        /// <param name="header"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
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


    }
}