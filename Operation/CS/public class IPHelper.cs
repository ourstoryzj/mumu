using Ionic.Zlib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace excel_operation.CS
{
    public class IPHelper
    {
        /// <summary>
        /// 使用代理ip案例
        /// </summary>
        /// <param name="phonenumber"></param>
        /// <returns></returns>
        public String sendpost(String phonenumber)
        {
            WebProxy proxyObject = new WebProxy("114.212.12.4", 3128);//str为IP地址 port为端口号
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://reg.email.163.com/unireg/call.do?cmd=added.mobilemail.checkBinding");
            request.Proxy = proxyObject; //设置代理 
            CookieContainer cookieContainer = new CookieContainer();
            request.CookieContainer = cookieContainer;

            CookieContainer cookie = request.CookieContainer;//如果用不到Cookie，删去即可
                                                             //以下是发送的http头，随便加，其中referer挺重要的，有些网站会根据这个来反盗链
            request.Referer = "http://reg.email.163.com/unireg/call.do?cmd=register.entrance&from=126mail";
            request.Accept = "Accept:text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            request.Headers["Accept-Language"] = "zh-CN,zh;q=0.";
            request.Headers["Accept-Charset"] = "GBK,utf-8;q=0.7,*;q=0.3";
            request.UserAgent = "User-Agent:Mozilla/5.0 (Windows NT 5.1) AppleWebKit/535.1 (KHTML, like Gecko) Chrome/14.0.835.202 Safari/535.1";
            request.KeepAlive = true;
            //上面的http头看情况而定，但是下面俩必须加
            request.ContentType = "application/x-www-form-urlencoded";
            request.Method = "POST";

            Encoding encoding = Encoding.UTF8;//根据网站的编码自定义
            string postDataStr = "mobile=" + phonenumber;
            byte[] postData = encoding.GetBytes(postDataStr);
            request.ContentLength = postData.Length;
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(postData, 0, postData.Length);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            //如果http头中接受gzip的话，这里就要判断是否为有压缩，有的话，直接解压缩即可
            if (response.Headers["Content-Encoding"] != null && response.Headers["Content-Encoding"].ToLower().Contains("gzip"))
            {
                responseStream = new GZipStream(responseStream, CompressionMode.Decompress);
            }

            StreamReader streamReader = new StreamReader(responseStream, encoding);
            string retString = streamReader.ReadToEnd();

            streamReader.Close();
            responseStream.Close();
            return retString;
        }
    }
}
