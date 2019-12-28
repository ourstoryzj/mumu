using Operation.CS;
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

namespace Operation.ShuaDan
{
    public partial class MessageTest : Form
    {

        /// <summary>
        /// 借口网址
        /// </summary>
        //string url;
        /// <summary>
        /// 手机号码
        /// </summary>
        string phone;
        /// <summary>
        /// Token
        /// </summary>
        string token;
        /// <summary>
        /// 短信信息
        /// </summary>
        string message;
        /// <summary>
        /// 项目ID
        /// </summary>
        string itemid;



        public MessageTest()
        {
            InitializeComponent();
            itemid = MessageAPI.GetItemID();
        }


        #region button1_Click
        private void button1_Click(object sender, EventArgs e)
        {
            string test = MessageAPI.GetToken();
            txt_token.Text = test;
            token = test;
        }
        #endregion

        #region GetHtml
        /// <summary> 
        ///  获取网址HTML 
        /// </summary> 
        /// <param name="URL">网址 </param> 
        /// <returns> </returns> 
        public static string GetHtml(string URL)
        {
            string reader = "";
            try
            {
                WebRequest wrt;
                wrt = WebRequest.Create(URL);
                wrt.Credentials = CredentialCache.DefaultCredentials;
                WebResponse wrp;
                wrp = wrt.GetResponse();
                reader = new StreamReader(wrp.GetResponseStream(), Encoding.GetEncoding("gb2312")).ReadToEnd();
                wrt.GetResponse().Close();
            }
            catch (WebException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return reader;
        }
        #endregion

        #region button2_Click
        private void button2_Click(object sender, EventArgs e)
        {
            //指定获取号码：Phone(可以不填写该参数，如空则随机获取新号码) 
            //url = "http://api.ema666.com/Api/userGetPhone?ItemId=" + itemid + "&token=" + token + "&PhoneType=0";
            //string res = GetHtml(url);
            string res = MessageAPI.GetPhone(token);
            //res = res.Replace(";", "");
            phone = res;
            txt_phone.Text = res;
        }

        #endregion

        #region button3_Click
        private void button3_Click(object sender, EventArgs e)
        {
            //url = "http://api.ema666.com/Api/userSingleGetMessage?token=" + token + "&itemId=" + itemid + "&phone=" + phone;
            //url = "http://api.ema666.com/Api/userSingleGetMessage?token=" + token;
            //string res = GetHtml(url);
            string res = MessageAPI.GetMessage(token);
            message = res;
            txt_message.Text = res;

        }
        #endregion

        #region button4_Click
        private void button4_Click(object sender, EventArgs e)
        {
            //释放全部手机号码 http://api.ema666.com/Api/userReleaseAllPhone?token=登陆token
            //url = "http://api.ema666.com/Api/userReleasePhone?token=" + token + "&phoneList=" + phone + ";";
            //string res = GetHtml(url);
            string res = MessageAPI.ClearPhone(token, phone);
            txt_shifang.Text = res;
        }
        #endregion

        #region button5_Click
        private void button5_Click(object sender, EventArgs e)
        {
            //url = "http://api.ema666.com/Api/userExit?token=" + token;
            //string res = GetHtml(url);
            string res = MessageAPI.Exit(token);
            txt_exit.Text = res;
        }
        #endregion

        #region button6_Click
        private void button6_Click(object sender, EventArgs e)
        {

            //url = "http://api.ema666.com/Api/userAddBlack?token=" + token + "&phoneList=" + phone + ";";
            //string res = GetHtml(url);

            string res = MessageAPI.AddBlack(token, phone);
            txt_heimingdan.Text = res;
        }
        #endregion

        private void button7_Click(object sender, EventArgs e)
        {
            string p = txt_phone2.Text.Trim();
            string res = MessageAPI.GetPhone(token, p);
            phone = p;
            txt_phone.Text = p;
            txt_phone2.Text = res;
        }
    }
}
