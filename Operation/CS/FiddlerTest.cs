using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using System.Net;
using System.IO;
using System.Collections;

namespace excel_operation
{
    public class FiddlerTest
    {
        private string timestamp = null;
        private CookieContainer cookie = null;
        private string phone = "18064146272";
        private string PWS = "zv1k0bfyi";

         publicForm1()
        {
            InitializeComponent();

            cookie = newCookieContainer();
            this.GetHtmlData("http://cp.wanlitong.com/?act=ucenter&st=login", cookie);

            TimeSpants = DateTime.UtcNow - newDateTime(1970, 01, 01, 00, 00, 00, 00000);
            timestamp = Convert.ToInt64(ts.TotalMilliseconds).ToString();

            DowloadCheckImg("http://www.wanlitong.com/paic/common/vcode.do?timestamp=" + timestamp,
            cookie, "d:\\sss.jpg");

            this.pictureBox1.Image = Image.FromFile("d:\\sss.jpg");

        }


privatevoidbutton1_Click(objectsender, EventArgse)
        {
            doPostMethod();

        }


privatevoiddoPostMethod()
        {
            MethodOptionoption = newMethodOption();
            stringsign = null;
            stringpsw = null;

            IDictionary<string, string> parameters = newDictionary<string, string>();
            parameters.Add("action", "loginIn");


            stringresult = option.common(parameters, "http://cp.wanlitong.com/?act=index&st=wltSign");


            Console.WriteLine(result);


            while ("".Equals(result) || null == result)
            {
                Thread.Sleep(1000);
            }
            sign = result;

            parameters = newDictionary<string, string>();
            parameters.Add("str_encrypt", PWS);


            result = option.common(parameters, "http://cp.wanlitong.com/?act=index&st=getRSA");

            psw = result;

            Console.WriteLine(psw);

            parameters = newDictionary<string, string>();
            parameters.Add("sign", sign);
            parameters.Add("timestamp", timestamp);
            parameters.Add("authType", "md5");
            parameters.Add("psw", psw);
            parameters.Add("uname", phone);
            parameters.Add("validCode", this.textBox1.Text);

            StringpostData = "timestamp=" + timestamp + "&sign=" + sign + "&authType=md5" + "&psw=" + psw + "&uname=" + phone
            + "&validCode=" + this.textBox1.Text;
            postData = "sign=" + sign + "&loginId=" + phone + "&memberId=010000056964867&authType=md5&count=15";
            Console.WriteLine(postData);

            ArrayListlist = PostData(postData, "http://www.wanlitong.com/mobileapi/shake/bonusPoints.do", cookie);

            Console.WriteLine(list[1].ToString());


        }


publicboolDowloadCheckImg(stringUrl, CookieContainercookCon, stringsavePath)
        {
            boolbol = true;
            HttpWebRequestwebRequest = (HttpWebRequest)WebRequest.Create(Url);

            webRequest.AllowWriteStreamBuffering = true;
            webRequest.Credentials = System.Net.CredentialCache.DefaultCredentials;
            webRequest.MaximumResponseHeadersLength = -1;

            webRequest.UserAgent = "Dalvik/1.4.0(Linux;U;Android2.3.4;GT-I9100Build/GRJ22)";
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.Method = "GET";
            webRequest.Headers.Add("Accept-Language", "zh-cn");
            webRequest.Headers.Add("Accept-Encoding", "gzip,deflate");
            webRequest.Headers.Add("screenSize", "320x480");
            webRequest.Headers.Add("platform", "android");
            webRequest.Headers.Add("udid", "842526320413656");
            webRequest.Headers.Add("protocolVer", "1.0.0");
            webRequest.Headers.Add("model", "GT-I9100");
            webRequest.Headers.Add("clientVer", "2.2.0");
            webRequest.KeepAlive = true;
            webRequest.CookieContainer = cookCon;
            try
            {
                using (HttpWebResponsewebResponse = (HttpWebResponse)webRequest.GetResponse())
                {
                    using (Streamsream = webResponse.GetResponseStream())
                    {
                        List<byte> list = newList<byte>();
                        while (true)
                        {
                            intdata = sream.ReadByte();
                            if (data == -1)
                                break;
                            list.Add((byte)data);
                        }
                        File.WriteAllBytes(savePath, list.ToArray());
                    }
                }
            }
            catch (WebExceptionex)
            {
                bol = false;
            }
            catch (Exceptionex)
            {
                bol = false;
            }
            returnbol;
        }
publicArrayListGetHtmlData(stringpostUrl, CookieContainercookie)
        {
            HttpWebRequestrequest;
            HttpWebResponseresponse;
            ArrayListlist = newArrayList();
            request = WebRequest.Create(postUrl)asHttpWebRequest;
            request.Method = "GET";

            request.UserAgent = "Dalvik/1.4.0(Linux;U;Android2.3.4;GT-I9100Build/GRJ22)";
            request.ContentType = "application/x-www-form-urlencoded";

            request.Headers.Add("Accept-Language", "zh-cn");
            request.Headers.Add("Accept-Encoding", "gzip,deflate");
            request.Headers.Add("screenSize", "320x480");
            request.Headers.Add("platform", "android");
            request.Headers.Add("udid", "842526320413656");
            request.Headers.Add("protocolVer", "1.0.0");
            request.Headers.Add("model", "GT-I9100");
            request.Headers.Add("clientVer", "2.2.0");
            request.Headers.Add("Accept-Encoding", "gzip");

            request.CookieContainer = cookie;
            request.KeepAlive = true;

            request.CookieContainer = cookie;
            try
            {
                using (response = (HttpWebResponse)request.GetResponse())
                {
                    using (StreamReaderreader = newStreamReader(response.GetResponseStream(), Encoding.Default))
                    {
                        cookie.Add(response.Cookies);

                        list.Add(cookie);
                        list.Add(reader.ReadToEnd());
                        list.Add(Guid.NewGuid().ToString());
                    }
                }
            }
            catch (WebExceptionex)
            {
                list.Clear();
                list.Add("发生异常/n/r");
                WebResponsewr = ex.Response;
                using (Streamst = wr.GetResponseStream())
                {
                    using (StreamReadersr = newStreamReader(st, System.Text.Encoding.Default))
                    {
                        list.Add(sr.ReadToEnd());
                    }
                }
            }
            catch (Exceptionex)
            {
                list.Clear();
                list.Add("5");
                list.Add("发生异常：" + ex.Message);
            }
            returnlist;
        }




publicArrayListPostData(stringpostData, stringpostUrl, CookieContainercookie)
        {
            ArrayListlist = newArrayList();
            HttpWebRequestrequest;
            HttpWebResponseresponse;
            ASCIIEncodingencoding = newASCIIEncoding();
            request = WebRequest.Create(postUrl)asHttpWebRequest;
            byte[] b = encoding.GetBytes(postData);
            request.Method = "POST";

            request.UserAgent = "Dalvik/1.4.0(Linux;U;Android2.3.4;GT-I9100Build/GRJ22)";
            request.ContentType = "application/x-www-form-urlencoded";

            request.Headers.Add("Accept-Language", "zh-cn");
            request.Headers.Add("Accept-Encoding", "gzip,deflate");
            request.Headers.Add("screenSize", "320x480");
            request.Headers.Add("platform", "android");
            request.Headers.Add("udid", "842526320413656");
            request.Headers.Add("protocolVer", "1.0.0");
            request.Headers.Add("model", "GT-I9100");
            request.Headers.Add("clientVer", "2.2.0");
            request.Headers.Add("Accept-Encoding", "gzip");

            request.CookieContainer = cookie;
            request.ContentLength = b.Length;
            using (Streamstream = request.GetRequestStream())
            {
                stream.Write(b, 0, b.Length);
            }

            try
            {

                using (response = request.GetResponse()asHttpWebResponse)
{
                    using (StreamReaderreader = newStreamReader(response.GetResponseStream(), Encoding.UTF8))
                    {
                        if (response.Cookies.Count > 0)
                            cookie.Add(response.Cookies);
                        list.Add(cookie);
                        list.Add(reader.ReadToEnd());
                    }
                }
            }
            catch (WebExceptionwex)
            {
                WebResponsewr = wex.Response;
                using (Streamst = wr.GetResponseStream())
                {
                    using (StreamReadersr = newStreamReader(st, System.Text.Encoding.Default))
                    {
                        list.Add(sr.ReadToEnd());
                    }
                }
            }
            catch (Exceptionex)
            {
                list.Add("发生异常/n/r" + ex.Message);
            }
            returnlist;
        }
    }
}
}
