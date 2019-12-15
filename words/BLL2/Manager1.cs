using System;
using System.Collections.Generic;
using System.Text;
using Entity;
using Common;
using IDAL;
using DALFactory;
using System.Text.RegularExpressions;
using System.Collections;
using System.IO;


namespace BLL2
{
    public class Manager1
    {


        #region 声明

        /// <summary>
        /// 管理员
        /// </summary>
        public static readonly string decl_Admin = "Session_Admin";
        /// <summary>
        /// 上传文件后保存文件名的Cookie的名称
        /// </summary>
        public static readonly string decl_UploadFileName = "UploadFileName";
        /// <summary>
        /// girdview编辑的行
        /// </summary>
        public static readonly string decl_EditIndex = "Edit";
        /// <summary>
        /// 存验证码的Cookie名称
        /// </summary>
        public static readonly string decl_Code = "Code";
        /// <summary>
        /// 重置密码
        /// </summary>
        public static readonly string decl_ResetPwd = "888888";
        /// <summary>
        /// 用户
        /// </summary>
        public static readonly string decl_User = "Session_User";
        /// <summary>
        /// 用户账号
        /// </summary>
        public static readonly string decl_User_Acc = "Session_User_Acc";
        /// <summary>
        /// 用户密码
        /// </summary>
        public static readonly string decl_User_Pwd = "Session_User_Pwd";
        /// <summary>
        /// 上下班时间
        /// </summary>
        public static readonly string decl_Basic = "Session_Basic";

        public static readonly string decl_dianpu = "Session_dianpu";

        public static readonly string decl_huashu = "decl_huashu";

        public static readonly string decl_courier = "Session_courier";

        public static readonly string decl_pagestype = "decl_pagestype";

        public static readonly string decl_goods_import = "decl_goods_import";

        public static readonly string decl_goodstype = "Session_goodstype";

        public static readonly string decl_order_plan = "Session_order_plan";

        public static readonly string decl_huodong_plan = "Session_huodong_plan";

        /// <summary>
        /// GridView中需要Edit的RowIndex
        /// </summary>
        public static readonly string decl_eindex = "Session_eindex";

        /// <summary>
        /// 声明随机数
        /// </summary>
        private static readonly Random random = new Random();
        /// <summary>
        /// 声明锁定线程,以获取随机数
        /// </summary>
        private static readonly object syncLock = new object();

        #endregion



        #region 私有方法

        #region factory
        /// <summary>
        /// 获取DAL抽象工厂实体类
        /// </summary>
        public static AbstractDALFactory factory = AbstractDALFactory.ChooseFactory();
        #endregion

        #region Admin
        /// <summary>
        /// Session中的管理员信息
        /// </summary>
        private static Admins _admin;
        
        public static Admins Admin
        {
          get { return Manager1._admin; }
          set { Manager1._admin = value; }
        } 
        
        #endregion

  

        #region Basic
        /// <summary>
        /// Session中的管理员信息
        /// </summary>
        private static Basic _basic;

        public static Basic Basic
        {
            get { return Manager1._basic; }
            set { Manager1._basic = value; }
        }
       
        #endregion

        #region User
        /// <summary>
        /// Session中的用户信息
        /// </summary>
        private static Users _users;


        public static Users Users
        {
            get { return Manager1._users; }
            set { Manager1._users = value; }
        }
         
        #endregion

        #endregion

       

        #region 字符串处理

        

        #region 取出文本中的图片地址
        ///   <summary>
        ///   取出文本中的图片地址
        ///   </summary>
        ///   <param   name="HTMLStr">HTMLStr</param>
        public static string GetImgUrl(string HTMLStr)
        {
            string str = string.Empty;
            //string sPattern = @"^<img\s+[^>]*>";
            Regex r = new Regex(@"<img\s+[^>]*\s*src\s*=\s*([']?)(?<url>\S+)'?[^>]*>",
              RegexOptions.Compiled);
            Match m = r.Match(HTMLStr.ToLower());
            if (m.Success)
                str = m.Result("${url}");
            return str;
        }

        #endregion

        #region 截取字符串
        public static string Substring(string str, int num)
        {
            str = str.Length > num ? str.Substring(0, (num - 1)) : str;
            return str;
        }
        #endregion

        #region 添加HTTP://字符串
        public static string AddString_Http(string str)
        {
            str = str.ToLower();
            if (str.IndexOf("http://") < 0)
            {
                str = "http://" + str;
            }
            return str;
        }
        #endregion
        #endregion

         

        #region 浏览记录


        #region GetHistory
        /// <summary>
        /// 获取浏览记录
        /// </summary>
        /// <returns>list</returns>
        //public static List<int> GetHistory()
        //{
        //    List<int> list = new List<int>();
        //    HttpCookie cookie = HttpContext.Current.Request.Cookies[Manager.Person != null ? decl_history_company : decl_history_company];
        //    if (cookie == null)
        //    {
        //        return list;
        //    }
        //    string[] strs = cookie.Value.Split(new char[] { '-' });
        //    int temp = 0;
        //    foreach (string str in strs)
        //    {
        //        if (int.TryParse(str, out temp))
        //        {
        //            list.Add(temp);
        //        }
        //    }
        //    return list;
        //}
        #endregion

        #region SetHistroy

        /// <summary>
        /// 设置浏览记录
        /// </summary>
        /// <param name="id"></param>
        public static void SetHistroy(int id)
        {
            try
            {
                //HttpCookie cookie = HttpContext.Current.Request.Cookies[Manager.Person != null ? decl_history_company : decl_history_company];
                //if (cookie == null)
                //{
                //    cookie = new HttpCookie(Manager.Person != null ? decl_history_company : decl_history_company);
                //    cookie.Value = id.ToString();
                //}
                //else
                //{
                //    string[] strs = cookie.Value.Split(new char[] { '-' });
                //    string res = id.ToString();
                //    bool ishas = false;
                //    for (int i = 0; i <= 8; i++)
                //    {
                //        try
                //        {
                //            //如果有改浏览记录则置顶
                //            if (strs[i] == res)
                //            {
                //                ishas = true;
                //            }
                //            if (ishas)
                //                res += "-" + strs[i + 1];
                //            else
                //                res += "-" + strs[i];
                //        }
                //        catch { }
                //    }
                //    cookie.Value = res;
                //}
                //cookie.Expires = DateTime.Now.AddDays(10);
                //HttpContext.Current.Response.Cookies.Add(cookie);
            }
            catch { }
        }
        #endregion


        #endregion

        

        #region 确认

        #region IsNumeric
        /// <summary>
        /// 查看是否为Int型
        /// </summary>
        /// <param name="str_int"></param>
        /// <returns></returns>
        public static bool IsNumeric(string str_int)
        {
            bool Res = false;
            int i;
            if (int.TryParse(str_int, out i))
            {
                Res = true;
            }
            return Res;
        }
        #endregion

        #region IsDecimal
        /// <summary>
        /// 查看是否为Int型
        /// </summary>
        /// <param name="str_int"></param>
        /// <returns></returns>
        public static bool IsDecimal(string str_Decimal)
        {
            bool Res = false;
            Decimal deci = new Decimal();
            if (Decimal.TryParse(str_Decimal, out deci))
            {
                Res = true;
            }
            return Res;
        }
        #endregion

        #region IsDateTime
        /// <summary>
        /// 查看是否为DateTime型
        /// </summary>
        /// <param name="str_date"></param>
        /// <returns></returns>
        public static bool IsDateTime(string str_date)
        {
            bool Res = false;
            DateTime date = new DateTime();
            if (DateTime.TryParse(str_date, out date))
            {
                Res = true;
            }
            return Res;
        }
        #endregion

        #region confirm_longth
        /// <summary>
        /// 判断字符串是否符合长度
        /// </summary>
        /// <param name="str">要判断的字符串</param>
        /// <param name="longth">长度</param>
        /// <returns>bool</returns>
        public static bool confirm_longth(string str, int longth)
        {
            bool res = false;
            int temp = str.Length;
            if (temp < longth)
                res = true;
            return res;
        }
        #endregion

        #region confirm
        /// <summary>
        /// 弹出confirm窗口
        /// </summary>
        /// <param name="mess">提示信息</param>
        /// <returns></returns>
        public static string confirm(string mess)
        {
            return "return confirm('" + mess + "');";
        }
        #endregion

        #endregion



        #region EnCodeCovert
        /// <summary>
        /// 首选编码的代码页名称
        /// </summary>
        /// <param name="srcName">原编码格式</param>
        /// <param name="convToName">要转换成的编码格式</param>
        /// <param name="value">需要转换的字符串</param>
        /// <returns>返回转换后的字符串</returns>
        public static string EnCodeCovert(string srcName, string convToName, string value)
        {
            System.Text.Encoding srcEncode = System.Text.Encoding.GetEncoding(srcName);
            System.Text.Encoding convToEncode = System.Text.Encoding.GetEncoding(convToName);
            byte[] bytes = srcEncode.GetBytes(value);
            System.Text.Encoding.Convert(srcEncode, convToEncode, bytes, 0, bytes.Length);
            return convToEncode.GetString(bytes);
        }
        #endregion

        #region RandomNumber
        /// <summary>
        /// 获取随机数
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static int RandomNumber(int min, int max)
        {
            lock (syncLock)
            { // synchronize
                return random.Next(min, max);
            }
        }
        #endregion



        #region 淘宝

        /// <summary>
        /// 根据旺旺得到能够查询店铺网址的页面URL
        /// </summary>
        /// <param name="wangwang"></param>
        /// <returns></returns>
        public static string GetDPurlByWangwang(string wangwang)
        {
            string temp = "https://shopsearch.taobao.com/search?app=shopsearch&q="+wangwang+"&imgfile=&commend=all&ssid=s5-e&search_type=shop&sourceId=tb.index&spm=a21bo.50862.201856-taobao-item.1&ie=utf8&initiative_id=tbindexz_20161225";
            return temp;
        }



        




       

        #endregion

    }
}
