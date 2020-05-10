using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;

namespace Operation.Test
{
    public partial class test_getpddorderlist : Form
    {
        public test_getpddorderlist()
        {
            InitializeComponent();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox4.Text = requestMM();
        }




        public string requestMM()
        {

            HttpWebRequest request = null;
            HttpWebResponse response = null;
            try
            {
                request = (HttpWebRequest)HttpWebRequest.Create("https://mms.pinduoduo.com/express_waybill/shop/orderList");
                request.Method = "Post";
                request.ContentType = "application/json; charset=UTF-8";
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/79.0.3942.0 Safari/537.36 Edg/79.0.305.0";
                //request.AllowAutoRedirect = true;
                //request.CookieContainer = container;//获取验证码时候取到的cookie 会附加到这个容器里面
                request.KeepAlive = true;//建立持久性链接
                request.Accept = "application/json, text/javascript, */*; q=0.01";
                request.Referer = "https://mms.pinduoduo.com/order.html";
                request.Host = "mms.pinduoduo.com";

                //Accept-Encoding
                //Accept-Language
                //Origin
                CookieContainer co = new CookieContainer();
                string cookie = "JSESSIONID=43A36356B6E5E3A343AB88ABC68C54C3; PASS_ID=1-iHuRrOQq/tnIiIgIkAOI4zM06lG/nTjdLCxqjdjwpAdVyOs8FbKtOuSOKuXUpAZKyzyaLIlreaSgkt2TCqB8Nw_240505030_28686518; _nano_fp=XpdJlp9qnpXbn0doX9_7qedY3JvCGkow4efVvIiA; api_uid=rBQR2V62wksnBA1JFdKBAg==";
                //co.SetCookies(new Uri("https://mms.pinduoduo.com"), "JSESSIONID=43A36356B6E5E3A343AB88ABC68C54C3");
                //co.SetCookies(new Uri("https://mms.pinduoduo.com"), "");
                //request.CookieContainer = co;
                request.Headers.Add("Cookie", cookie);
                request.Headers.Add("Accept-Encoding", "gzip, deflate, br");
                request.Headers.Add("Accept-Language", "zh-CN,zh;q=0.9,en-US;q=0.8,en;q=0.7");
                //request.Headers.Add("Connection", "Keep-Alive");
                //request.Connection = "Keep-Alive";
                //Common.NetHelper.SetHeaderValue(request.Headers, "Connection", "Keep-Alive");

                long dt1 = DateTime.Now.ToTimeStamp();//当前时间时间戳
                long dt2 = DateTime.Now.AddDays(-30).ToTimeStamp();//30天前时间戳
                
                //数据
                //string postData = "{ 'orderOnlineType':0,'groupEndTime':"+dt1.ToString()+",'groupStartTime':"+dt2.ToString()+",'pageNumber':1,'pageSize':50,'afterSaleType':1}";
                string postData = "{\"orderOnlineType\":0,\"groupEndTime\":" + dt1.ToString() + ",\"groupStartTime\":" + dt2.ToString() + ",\"pageNumber\":1,\"pageSize\":50,\"afterSaleType\":1}";
                ASCIIEncoding encoding = new ASCIIEncoding();
                byte[] bytepostDate = encoding.GetBytes(postData);
                request.ContentLength = bytepostDate.Length;

                //发送数据 using结束时释放代码
                using (Stream requestS = request.GetRequestStream())
                {
                    requestS.Write(bytepostDate, 0, bytepostDate.Length);
                }

                ////响应
                //response = (HttpWebResponse)request.GetResponse();
                //string text = string.Empty;
                //using (Stream responseS = response.GetResponseStream())
                //{
                //    StreamReader reader = new StreamReader(responseS, Encoding.UTF8);
                //    text = reader.ReadToEnd();
                //}

                string text = string.Empty;
                response = (HttpWebResponse)request.GetResponse();
                Stream getStream = response.GetResponseStream();
                //如果是使用Gzip的流的方式
                var ce = response.ContentEncoding;
                if (ce.ToLower() == "gzip")
                {
                    getStream = new Ionic.Zlib.GZipStream(getStream, Ionic.Zlib.CompressionMode.Decompress);
                }
                StreamReader streamReader = new StreamReader(getStream, Encoding.UTF8);
                //StreamReader streamReader = new StreamReader(getStream, Encoding.GetEncoding("gb2312"));
                text = streamReader.ReadToEnd();
                streamReader.Close();
                getStream.Close();

                return text;
            }
            catch (Exception e)
            {

                e.ToShow();
            }
            return "";
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
