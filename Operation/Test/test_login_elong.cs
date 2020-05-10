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
    public partial class test_login_elong : Form
    {

        public static CookieContainer container = null; //存储验证码cookie

        public test_login_elong()
        {
            InitializeComponent();
            bind_vaildate();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox4.Text = requestMM(txt_account.Text, txt_pwd.Text, txt_code.Text);
        }

        public string requestMM(string account, string pwd, string vaildate)
        {

            HttpWebRequest request = null;
            HttpWebResponse response = null;
            try
            {
                request = (HttpWebRequest)HttpWebRequest.Create("https://secure.elong.com/passport/ajax/elongLogin");
                request.Method = "Post";
                request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/78.0.3904.108 Safari/537.36";
                request.AllowAutoRedirect = true;
                request.CookieContainer = container;//获取验证码时候取到的cookie 会附加到这个容器里面
                request.KeepAlive = true;//建立持久性链接
                //数据
                string postData = string.Format("userName={0}&passwd={1}&validateCode={2}&rememberMe=true", account, pwd, vaildate);
                ASCIIEncoding encoding = new ASCIIEncoding();
                byte[] bytepostDate = encoding.GetBytes(postData);
                request.ContentLength = bytepostDate.Length;

                //发送数据 using结束时释放代码
                using (Stream requestS = request.GetRequestStream())
                {
                    requestS.Write(bytepostDate, 0, bytepostDate.Length);
                }

                //响应
                response = (HttpWebResponse)request.GetResponse();
                string text = string.Empty;
                using (Stream responseS = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseS, Encoding.UTF8);
                    text = reader.ReadToEnd();
                }
                return text;
            }
            catch (Exception e)
            {

                e.ToShow();
            }
            return "";
        }


        #region 登录
        public string requestM(string uName, string passwd, string vaildate)
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            try
            {
                request = (HttpWebRequest)HttpWebRequest.Create("https://secure.elong.com/passport/ajax/elongLogin");
                request.Method = "Post";
                request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/78.0.3904.108 Safari/537.36";
                request.AllowAutoRedirect = true;
                request.CookieContainer = container;//获取验证码时候获取到的cookie会附加在这个容器里面
                request.KeepAlive = true;//建立持久性连接
                //整数据
                string postData = string.Format("userName={0}&passwd={1}&validateCode={2}&rememberMe=true", uName, passwd, vaildate);
                ASCIIEncoding encoding = new ASCIIEncoding();
                byte[] bytepostData = encoding.GetBytes(postData);
                request.ContentLength = bytepostData.Length;

                //发送数据  using结束代码段释放
                using (Stream requestStm = request.GetRequestStream())
                {
                    requestStm.Write(bytepostData, 0, bytepostData.Length);
                }

                //响应
                response = (HttpWebResponse)request.GetResponse();
                string text = string.Empty;
                using (Stream responseStm = response.GetResponseStream())
                {
                    StreamReader redStm = new StreamReader(responseStm, Encoding.UTF8);
                    text = redStm.ReadToEnd();
                }

                return text;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                return msg;
            }

        }
        #endregion

        public Stream getCode(string codUrl)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(codUrl);
            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded";
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/78.0.3904.108 Safari/537.36";
            request.Accept = "image/webp,*/*;q=0.8";
            request.CookieContainer = new CookieContainer();
            container = request.CookieContainer;
            var c = request.CookieContainer.GetCookies(request.RequestUri);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            response.Cookies = container.GetCookies(request.RequestUri);
            return response.GetResponseStream();
        }


        #region 获取验证码
        public Stream getCodeStream(string codeUrl)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            //验证码请求
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(codeUrl);
            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded";
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:5.0.1) Gecko/20100101 Firefox/5.0.1";
            request.Accept = "image/webp,*/*;q=0.8";
            request.CookieContainer = new CookieContainer();//!Very Important.!!!
            container = request.CookieContainer;
            var c = request.CookieContainer.GetCookies(request.RequestUri);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            response.Cookies = container.GetCookies(request.RequestUri);

            Stream stream = response.GetResponseStream();
            return stream;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        void bind_vaildate()
        {
            string codeUrl = "https://secure.elong.com/passport/getValidateCode";
            panel1.BackgroundImage = Image.FromStream(getCodeStream(codeUrl));
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
    #endregion



}

