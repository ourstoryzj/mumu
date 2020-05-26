using System;
using System.Windows.Forms;
using Common;
using System.Net;
using System.Collections;
using System.Collections.Generic;
using CsharpHttpHelper;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Operation.Test
{
    public partial class test_pddkb : Form
    {
        public test_pddkb()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string url = "https://mms.pinduoduo.com/janus/api/checkLogin";
            string cookie = "anthor:ourstoryzj";
            string res = Common.WebService.GetHtml(url, out cookie);
            //WebService.GetHtmlByWebRequest()
            res.ToShow();
        }




        private void button2_Click(object sender, EventArgs e)
        {
            string guid = System.Guid.NewGuid().ToString();
            textBox1.Text = "sid = " + guid + "\r\n";
            string account = "ourstoryzj";
            string pwd = "zhangjian";
            string sign = (account + pwd + guid).ToMd5();
            textBox1.Text += "sign = " + sign + "\r\n";
            textBox1.Text += "用户名 = " + account + "\r\n";


            string url = "http://www.10000kb.cn/API/GetKd";

            string datastr = "{\"sign\":\"" + sign + "\",\"sid\":\"" + guid + "\",\"username\":\"" + account + "\"}";
            System.Net.CookieContainer cookie = new System.Net.CookieContainer();

            string res = Common.WebService.SendDataByPost(url, datastr, ref cookie);

            textBox1.Text += "返回结果 = " + res + "\r\n";

            textBox1.Text += "Md5 = " + (account + pwd + guid).ToMD5() + "\r\n";

        }

        private void button3_Click(object sender, EventArgs e)
        {



            //string account = "ourstoryzj";
            //string pwd = "zhangjian";
            //string url = "http://www.10000kb.cn/login/CheckLogin?action=user&name=" + account + "&pwd=" + pwd;
            //System.Net.CookieContainer cookie = new System.Net.CookieContainer();
            //string res = Common.WebService.SendDataByGET(url, "", ref cookie);
            //textBox1.Text += "返回结果 = " + res + "\r\n";

            //Uri uri = new Uri("http://www.10000kb.cn");

            //CookieCollection cc = cookie.GetCookies(new Uri("http://www.10000kb.cn"));
            //foreach (Cookie c in cc)
            //{
            //    textBox1.Text += "cookies: = " + c.Name + " " + c.Value + "\r\n";
            //}

            ////response.Cookies = request.CookieContainer.GetCookies(request.RequestUri);
            ////foreach (Cookie cook in response.Cookies)
            ////{
            ////    Console.WriteLine("Cookie:");
            ////    Console.WriteLine("{0} = {1}", cook.Name, cook.Value);
            ////}
            //string yue = Common.WebService.SendDataByGET("http://www.10000kb.cn/User", "", ref cookie);



            //textBox1.Text = GetCookie() + "\r\n";
            //textBox1.Text += ReadCommodity("583340660631") + "\r\n";



            string temp1 = "addrId=889523&kdId=139&content=%E7%8E%8B%E5%A4%A7%E5%8A%9B%2C132****5598%2C%E6%B9%96%E5%8C%97%E7%9C%81%E9%BB%84%E5%86%88%E5%B8%82%E5%9B%A2%E9%A3%8E%E5%8E%BF%E5%9C%9F%E7%9B%8E%E5%B0%8F%E5%8C%BA%2C240000%2C200523-034998355141708&kg=0.5&goodName=%E5%A5%B3%E5%8C%85&ispdd=1";

            string temp = "你好河北省";

            //byte[] bytestr =
            byte[] byteArray = System.Text.Encoding.Default.GetBytes(temp);
            textBox1.Text = byteArray.ToString() + "\r\n";


            // byte[] byteRequest = Encoding.GetEncoding("gb2312").GetBytes(postData);
            //string str =  Encoding.GetEncoding("gb2312").GetString(byteArray);
            string str = Encoding.UTF8.GetString(byteArray);
            textBox1.Text += str + "\r\n";


            string res = System.Web.HttpUtility.UrlDecode(temp1, System.Text.Encoding.UTF8);
            textBox1.Text += res + "\r\n";


            string temp2 = "addrId =889523&kdId=139&content=王大力,132****5598,湖北省黄冈市团风县土盎小区,240000,200523-034998355141708&kg=0.5&goodName=女包&ispdd=1";
            textBox1.Text += temp2.ToHTMLDataEncoding(Encoding.UTF8);


        }





        string GetYuE()
        {
            return "";
        }






        String GetCookie()
        {
            HttpHelper http = new HttpHelper();
            HttpItem item = new HttpItem()
            {
                URL = "http://www.10000kb.cn/User",//URL     必需项    
                Method = "get",//URL     可选项 默认为Get   
                IsToLower = false,//得到的HTML代码是否转成小写     可选项默认转小写   
                Cookie = "",//字符串Cookie     可选项   
                Referer = "",//来源URL     可选项   
                Postdata = "",//Post数据     可选项GET时不需要写   
                Timeout = 10000,//连接超时时间     可选项默认为100000    
                ReadWriteTimeout = 10000,//写入Post数据超时时间     可选项默认为30000   
                UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Trident/5.0)",//用户的浏览器类型，版本，操作系统     可选项有默认值   
                ContentType = "tehp/html",//返回类型    可选项有默认值   
                Allowautoredirect = false,//是否根据301跳转     可选项   
            };
            HttpResult result = http.GetHtml(item);
            return result.Cookie;
        }



        String ReadCommodity(string ID)
        {
            HttpHelper http = new HttpHelper();
            HttpItem item = new HttpItem()
            {
                URL = "http://item.taobao.com/item.htm?id=" + ID,//URL     必需项    
                Method = "get",//URL     可选项 默认为Get   
                IsToLower = false,//得到的HTML代码是否转成小写     可选项默认转小写   
                Cookie = "",//字符串Cookie     可选项   
                Referer = "",//来源URL     可选项   
                Postdata = "",//Post数据     可选项GET时不需要写   
                Timeout = 10000,//连接超时时间     可选项默认为100000    
                ReadWriteTimeout = 10000,//写入Post数据超时时间     可选项默认为30000   
                UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Trident/5.0)",//用户的浏览器类型，版本，操作系统     可选项有默认值   
                ContentType = "tehp/html",//返回类型    可选项有默认值   
                Allowautoredirect = true,//是否根据301跳转     可选项   
            };
            HttpResult result = http.GetHtml(item);
            string html = result.Html;
            return html;
        }








        public static List<Cookie> GetAllCookies(CookieContainer cc)
        {
            List<Cookie> lstCookies = new List<Cookie>();

            Hashtable table = (Hashtable)cc.GetType().InvokeMember("m_domainTable", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.GetField | System.Reflection.BindingFlags.Instance, null, cc, new object[] { });

            foreach (object pathList in table.Values)
            {
                SortedList lstCookieCol = (SortedList)pathList.GetType().InvokeMember("m_list", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.GetField | System.Reflection.BindingFlags.Instance, null, pathList, new object[] { });
                foreach (CookieCollection colCookies in lstCookieCol.Values)
                    foreach (Cookie c in colCookies) lstCookies.Add(c);
            }

            return lstCookies;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string cookie = GetCookie();

            //付掉13658975422湖北省黄石市下陆区天尊小区
            string url = "addrId =889523&kdId=139&content=付掉,13658975422,湖北省黄石市下陆区天尊小区,240000,200523-034998355141708&kg=0.4&goodName=女包&ispdd=1";
            url = url.ToHTMLDataEncoding(Encoding.UTF8);

            HttpHelper http = new HttpHelper();
            HttpItem item = new HttpItem()
            {
                URL = "http://www.10000kb.cn/UserAjaxHandle/AppBuy",//URL     必需项    
                Method = "post",//URL     可选项 默认为Get   
                IsToLower = false,//得到的HTML代码是否转成小写     可选项默认转小写   
                Cookie = cookie,//字符串Cookie     可选项   
                Referer = "http://www.10000kb.cn/User/Order",//来源URL     可选项   
                Postdata = url,//Post数据     可选项GET时不需要写   
                Timeout = 10000,//连接超时时间     可选项默认为100000    
                ReadWriteTimeout = 10000,//写入Post数据超时时间     可选项默认为30000   
                UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Trident/5.0)",//用户的浏览器类型，版本，操作系统     可选项有默认值   
                ContentType = "tehp/html",//返回类型    可选项有默认值   
                Allowautoredirect = true,//是否根据301跳转     可选项 
                Host = "www.10000kb.cn",
            };
            HttpResult result = http.GetHtml(item);
            string html = result.Html;
            textBox1.Text = html;
        }










        private void button5_Click(object sender, EventArgs e)
        {
            //登录获取cookie
            CookieContainer cookie = getCookie();

            //设置发货地址
            string addressid = GetAddressId(cookie);

            //发货


            //string cookie = GetCookie();

            //付掉13658975422湖北省黄石市下陆区天尊小区
            //string data = "addrId =889523&kdId=139&content=付掉,13658975422,湖北省黄石市下陆区天尊小区,240000,200523-034998355141708&kg=0.4&goodName=女包&ispdd=1";
            //data = data.ToHTMLDataEncoding(Encoding.UTF8);

            //string data1 = "付掉,13658975422,湖北省黄石市下陆区天尊小区,240000,200523-034998355141708";
            //data1 = data1.ToHTMLDataEncoding(Encoding.UTF8);
            //string data2 = "女包";
            //data2 = data2.ToHTMLDataEncoding(Encoding.UTF8);

            //string data3 = "addrId="+ addressid + "&kdId=139&content=" + data1 + "&kg=0.4&goodName=" + data2 + "&ispdd=1";
            //textBox1.Text = data3;
            //string yue = Common.WebService.SendDataByPost("http://www.10000kb.cn/UserAjaxHandle/AppBuy", data3, ref cookie);
            //textBox1.Text += yue;
            SendOrder();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //设置发货地址
            CookieContainer cookie = getCookie();
            string data_address = "postPhone=15931247210&postName=%E5%BC%A0%E5%BB%BA&provinces=%E6%B2%B3%E5%8C%97%E7%9C%81&cities=%E4%BF%9D%E5%AE%9A%E5%B8%82&areas=%E9%AB%98%E7%A2%91%E5%BA%97%E5%B8%82&postAddr=%E5%9B%A2%E7%BB%93%E4%B8%9C%E8%B7%AF%E5%B9%BF%E7%94%B5%E7%BD%91%E7%BB%9C%E5%85%AC%E5%8F%B8%E5%AE%B6%E5%B1%9E%E6%A5%BC%E5%8D%97%E6%A5%BC%E4%B8%9C%E5%8D%95%E5%85%83101";
            textBox1.Text = data_address.ToHTMLDataDecoding(Encoding.UTF8) + "\r\n";

            string res = Common.WebService.SendDataByPost("http://www.10000kb.cn/UserAjaxHandle/SaveAddress", data_address, ref cookie);
            textBox1.Text += res + "\r\n";

            string code = res.ToBetween("addrId\":", ",\"msg");
            textBox1.Text += code + "\r\n";

        }


        


        /// <summary>
        /// 获取空包网登录的cookie
        /// </summary>
        /// <returns></returns>
        CookieContainer getCookie()
        {

            //登录获取cookie
            string account = "ourstoryzj";
            string pwd = "zhangjian";
            string url = "http://www.10000kb.cn/login/CheckLogin?action=user&name=" + account + "&pwd=" + pwd;
            System.Net.CookieContainer cookie = new System.Net.CookieContainer();
            string res = Common.WebService.SendDataByGET(url, "", ref cookie);
            return cookie;
        }

        /// <summary>
        /// 设置发货地址并获得编号
        /// </summary>
        /// <returns></returns>
        string GetAddressId(CookieContainer cookie)
        {
            //设置发货地址
           // CookieContainer cookie = getCookie();
            string data_address = "postPhone=15931247210&postName=%E5%BC%A0%E5%BB%BA&provinces=%E6%B2%B3%E5%8C%97%E7%9C%81&cities=%E4%BF%9D%E5%AE%9A%E5%B8%82&areas=%E9%AB%98%E7%A2%91%E5%BA%97%E5%B8%82&postAddr=%E5%9B%A2%E7%BB%93%E4%B8%9C%E8%B7%AF%E5%B9%BF%E7%94%B5%E7%BD%91%E7%BB%9C%E5%85%AC%E5%8F%B8%E5%AE%B6%E5%B1%9E%E6%A5%BC%E5%8D%97%E6%A5%BC%E4%B8%9C%E5%8D%95%E5%85%83101";
            string res = Common.WebService.SendDataByPost("http://www.10000kb.cn/UserAjaxHandle/SaveAddress", data_address, ref cookie);
            string code = res.ToBetween("addrId\":", ",\"msg");
            return code;
        }

        string SendOrder()
        {

            //登录获取cookie
            CookieContainer cookie = getCookie();

            //设置发货地址
            //string addressid = GetAddressId(cookie);

            //发货
            string data1 = "星愿,13544565845,广东省东莞市虎门镇腾升小区,240000,200523-034998355141708";
            data1 = data1.ToHTMLDataEncoding(Encoding.UTF8);
            string data2 = "女包";
            data2 = data2.ToHTMLDataEncoding(Encoding.UTF8);
            string data3 = "addrId=889523&kdId=139&content=" + data1 + "&kg=0.4&goodName=" + data2 + "&ispdd=1";
            string json = Common.WebService.SendDataByPost("http://www.10000kb.cn/UserAjaxHandle/AppBuy", data3, ref cookie);
            textBox1.Text = json;
            var j = JObject.Parse(json);
            string res = j["kdNo"].ToString();
            textBox1.Text += res;
            return res;

        }


    }
}
