using System;
using System.Collections.Generic;
using System.IO;

using System.Net;
using System.Text;

using System.Windows.Forms;

namespace Common
{
    public class MessageAPI
    {

        //static string webname = "yzm9";
        static string webname = "http://api.xinghe008.com:8000";


        #region GetToken
        /// <summary>
        /// 获取token
        /// </summary>
        /// <returns></returns>
        public static string GetToken()
        {
            string res = "";// WebService.GetHtml(CS.XMLHelper.GetValue("API_Login"));
            return res;
        }
        #endregion

        #region GetItemID
        /// <summary>
        /// 获取项目ID
        /// </summary>
        /// <returns></returns>
        public static string GetItemID()
        {
            return "";// CS.XMLHelper.GetValue("API_ItemID");
        }
        #endregion

        #region GetPhone
        /// <summary>
        /// 获取新的手机号码
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static string GetPhone(string token)
        {
            //string url = "http://api." + webname + ".com/Api/userGetPhone?ItemId=" + GetItemID() + "&token=" + token + "&PhoneType=0";
            string url = webname + "/Api/userGetPhone?ItemId=" + GetItemID() + "&token=" + token + "&PhoneType=0";
            string res = WebService.GetHtml(url);
            res = res.Replace(";", "");
            return res;
        }
        #endregion

        #region GetPhone
        /// <summary>
        /// 获取指定的手机号码
        /// </summary>
        /// <param name="token"></param>
        /// <param name="phone">指定的手机号码</param>
        /// <returns></returns>
        public static string GetPhone(string token, string phone)
        {
            //string url = "http://api." + webname + ".com/Api/userGetPhone?ItemId=" + GetItemID() + "&token=" + token + "&PhoneType=0&Phone=" + phone;
            string url = webname + "/Api/userGetPhone?ItemId=" + GetItemID() + "&token=" + token + "&PhoneType=0&Phone=" + phone;
            string res = WebService.GetHtml(url);
            res = res.Replace(";", "");
            return res;
        }
        #endregion

        #region GetMessage
        /// <summary>
        /// 获取指定的手机号码的短信
        /// </summary>
        /// <param name="token"></param>
        /// <param name="phone">指定的手机号码</param>
        /// <returns></returns>
        public static string GetMessage(string token, string phone)
        {
            //string url = "http://api." + webname + ".com/Api/userSingleGetMessage?token=" + token + "&itemId=" + GetItemID() + "&phone=" + phone;
            string url = webname + "/Api/userSingleGetMessage?token=" + token + "&itemId=" + GetItemID() + "&phone=" + phone;
            string res = WebService.GetHtml(url);
            return res;
        }
        #endregion


        #region GetMessage
        /// <summary>
        /// 获取所有的短信
        /// </summary>
        /// <param name="token"></param>
        /// <param name="phone">指定的手机号码</param>
        /// <returns></returns>
        public static string GetMessage(string token)
        {
            //string url = "http://api." + webname + ".com/Api/userGetMessage?token=" + token+ "&PhoneType=0&notPrefix=131|132|133|134|135|136|137|138|139|151|152|153|154|155|156|157|158|159 ";
            //string url = "http://api." + webname + ".com/Api/userGetMessage?token=" + token;
            string url = webname + "/Api/userGetMessage?token=" + token;
            string res = WebService.GetHtml(url);
            return res;
        }
        #endregion


        #region ClearPhone
        /// <summary>
        /// 释放所有手机
        /// </summary>
        /// <param name="token"></param>
        /// <param name="phone">指定的手机号码</param>
        /// <returns></returns>
        public static string ClearPhone(string token)
        {
            //释放全部手机号码 http://api." + webname + ".com/Api/userReleaseAllPhone?token=登陆token
            //url = "http://api." + webname + ".com/Api/userReleasePhone?token=" + token + "&phoneList=" + phone + ";";
            //string res = WebService.GetHtml(url);
            //txt_shifang.Text = res;
            //http://api.xinghe008.com:8000/Api/userReleaseAllPhone?token=登陆token
            //string url = "http://api." + webname + ".com/Api/userReleaseAllPhone?token=" + token;
            //string url = "http://api.xinghe008.com:8000/Api/userReleaseAllPhone?token=" + token;
            string url = webname + "/Api/userReleaseAllPhone?token=" + token;
            string res = WebService.GetHtml(url);
            return res;
        }
        #endregion

        #region ClearPhone
        /// <summary>
        /// 释放指定手机号码
        /// </summary>
        /// <param name="token"></param>
        /// <param name="phone">指定的手机号码</param>
        /// <returns></returns>
        public static string ClearPhone(string token, string phone)
        {
            //释放全部手机号码 http://api." + webname + ".com/Api/userReleaseAllPhone?token=登陆token
            //url = "http://api." + webname + ".com/Api/userReleasePhone?token=" + token + "&phoneList=" + phone + ";";
            //string res = WebService.GetHtml(url);
            //txt_shifang.Text = res;
            //http://api.xinghe008.com:8000/Api/userReleasePhone?token=登陆token&phoneList=phone-itemId;phone-itemId;
            //string url = "http://api." + webname + ".com/Api/userReleasePhone?token=" + token + "&phoneList=" + phone + ";";
            //string url = "http://api.xinghe008.com:8000/Api/userReleasePhone?token=" + token + "&phoneList=" + phone + ";";
            string url = webname + "/Api/userReleasePhone?token=" + token + "&phoneList=" + phone + ";";
            string res = WebService.GetHtml(url);
            return res;
        }
        #endregion

        #region AddBlack
        /// <summary>
        /// 加入黑名单
        /// </summary>
        /// <param name="token"></param>
        /// <param name="phone">指定的手机号码</param>
        /// <returns></returns>
        public static string AddBlack(string token, string phone)
        {
            //string url = "http://api." + webname + ".com/Api/userAddBlack?token=" + token + "&phoneList=" + phone + ";";
            string url = webname + "/Api/userAddBlack?token=" + token + "&phoneList=" + phone + ";";
            string res = WebService.GetHtml(url);
            return res;
        }
        #endregion


        #region Exit
        /// <summary>
        /// 退出token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static string Exit(string token)
        {
            string url = "http://api." + webname + ".com/Api/userExit?token=" + token;
            string res = WebService.GetHtml(url);
            return res;
        }
        #endregion



    }
}
