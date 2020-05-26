using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Common;
using Newtonsoft.Json.Linq;

namespace Operation.CS
{
    public class KongBaoHelper
    {


        /// <summary>
        /// 获取空包网登录的cookie
        /// </summary>
        /// <returns></returns>
        public static CookieContainer getCookie()
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
        public static string GetAddressId(CookieContainer cookie)
        {
            //设置发货地址
            // CookieContainer cookie = getCookie();
            string data_address = "postPhone=15931247210&postName=%E5%BC%A0%E5%BB%BA&provinces=%E6%B2%B3%E5%8C%97%E7%9C%81&cities=%E4%BF%9D%E5%AE%9A%E5%B8%82&areas=%E9%AB%98%E7%A2%91%E5%BA%97%E5%B8%82&postAddr=%E5%9B%A2%E7%BB%93%E4%B8%9C%E8%B7%AF%E5%B9%BF%E7%94%B5%E7%BD%91%E7%BB%9C%E5%85%AC%E5%8F%B8%E5%AE%B6%E5%B1%9E%E6%A5%BC%E5%8D%97%E6%A5%BC%E4%B8%9C%E5%8D%95%E5%85%83101";
            string res = Common.WebService.SendDataByPost("http://www.10000kb.cn/UserAjaxHandle/SaveAddress", data_address, ref cookie);
            string code = res.ToBetween("addrId\":", ",\"msg");
            return code;
        }


        private string SendOrder()
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
            var j = JObject.Parse(json);
            string res = j["kdNo"].ToString();
            return res;

        }


        /// <summary>
        /// 获取快递单号
        /// </summary>
        /// <param name="orderInfo">地址信息,例如:星愿,13544565845,广东省东莞市虎门镇腾升小区,240000,200523-034998355141708</param>
        /// <returns></returns>
        public static string SendOrder(string orderInfo)
        {

            //登录获取cookie
            CookieContainer cookie = getCookie();

            //设置发货地址
            //string addressid = GetAddressId(cookie);

            //订单编号,用于返回快递单号
            string orderid = DateTime.Now.ToString("yyyyMMddHHmmss") + new Random().Next(999999);
            //string orderid = "200523-600103486582832";

            //发货
            string data1 = orderInfo + "," + orderid;
            data1 = data1.ToHTMLDataEncoding(Encoding.UTF8);
            string data2 = "女包";
            data2 = data2.ToHTMLDataEncoding(Encoding.UTF8);
            //139为速尔快递
            string data3 = "addrId=889523&kdId=139&content=" + data1 + "&kg=0.6&goodName=" + data2 + "&ispdd=1";
            string json = Common.WebService.SendDataByPost("http://www.10000kb.cn/UserAjaxHandle/AppBuy", data3, ref cookie);
            var j = JObject.Parse(json);
            string res = j["kdNo"].ToString();
            return res;

        }

    }
}
