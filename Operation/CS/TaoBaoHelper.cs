/// <summary>
/// 类说明：获取店铺所有商品ID,然后调用获取到ID可获得制定的商品数据
/// 编码日期：2014-01-13
/// 编 码 人：Lese
/// 联系方式：97354625  
/// </summary>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CsharpHttpHelper;

namespace Operation.CS
{
    public   class TaoBaoHelper
    {
        /// <summary>
        /// 店铺商品页数
        /// </summary>
        private static int page = 1;

        public static int Page
        {
            get { return TaoBaoHelper.page; }
            set { TaoBaoHelper.page = value; }
        }
        /// <summary>
        /// 循环判断
        /// </summary>
        private static bool b = false;

        public static bool B
        {
            get { return TaoBaoHelper.b; }
            set { TaoBaoHelper.b = value; }
        }
        /// <summary>
        /// 储存每页的商品ID
        /// </summary>
        private static StringBuilder sb = new StringBuilder();

        public static StringBuilder Sb
        {
            get { return TaoBaoHelper.sb; }
            set { TaoBaoHelper.sb = value; }
        }
        /// <summary>
        /// 返回的商品ID
        /// </summary>
        private static string[] id;

        public static string[] ID
        {
            get { return TaoBaoHelper.id; }
            set { TaoBaoHelper.id = value; }
        }
        /// <summary>
        /// 取文本中间内容
        /// </summary>
        /// <param name="url">店铺域名 例如:http://june23day.taobao.com/ 必须是这个格式,可以直接点击店铺中的“所有分类”获得</param>
        /// <returns>店铺所有商品</returns>
        public static string[] ReadID(string url)
        {
            HttpHelper http = new HttpHelper();
            while (B != true)
            {
                HttpItem item = new HttpItem()
                {
                    URL = url + "search.htm?pageNo=" + Page.ToString(),//URL     必需项    
                    Method = "get",//URL     可选项 默认为Get   
                    IsToLower = false,//得到的HTML代码是否转成小写     可选项默认转小写   
                    Cookie = "",//字符串Cookie     可选项   
                    Referer = "",//来源URL     可选项   
                    Postdata = "",//Post数据     可选项GET时不需要写   
                    Timeout = 10000,//连接超时时间     可选项默认为100000    
                    ReadWriteTimeout = 10000,//写入Post数据超时时间     可选项默认为30000   
                    UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Trident/5.0)",//用户的浏览器类型，版本，操作系统     可选项有默认值   
                    ContentType = "text/html",//返回类型    可选项有默认值   
                    Allowautoredirect = false,//是否根据301跳转     可选项   
                    ProxyIp = "",//代理服务器ID     可选项 不需要代理 时可以不设置这三个参数    

                };
                HttpResult result = http.GetHtml(item);
                string html = result.Html;
                if (html.IndexOf("J_SearchAsync next") == -1)
                {

                    foreach (String s in BetweenArr(html, "&itemIds=", "&source=shop\"/>"))
                    {
                        Sb.Append("," + s);

                    }
                    B = true;
                }
                else
                {
                    foreach (String s in BetweenArr(html, "&itemIds=", "&source=shop\"/>"))
                    {
                        Sb.Append("," + s);
                        Page++;
                    }
                }
            }
            string[] uid = Sb.ToString().Split(',');
            ID = RemoveLike(uid);
            return ID;
        }
        /// <summary>
        /// 获取商品数据
        /// </summary>
        /// <param name="ID">商品ID</param>
        /// <returns>返回商品数据HTML</returns>
        public static String ReadCommodity(string ID)
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
                Allowautoredirect = false,//是否根据301跳转     可选项   
            };
            HttpResult result = http.GetHtml(item);
            string html = result.Html;
            return html;
        }
        /// <summary>
        /// 过滤相同内容
        /// </summary>
        /// <param name="values">要过滤数组</param>
        /// <returns>过滤后的数组</returns>
        public static string[] RemoveLike(string[] values)
        {
            List<string> list = new List<string>();
            for (int i = 0; i < values.Length; i++)//遍历数组成员
            {
                if (values[i] != "")
                {
                    if (list.IndexOf(values[i].ToLower()) == -1)//对每个成员做一次新数组查询如果没有相等的则加到新数组
                        list.Add(values[i]);
                }

            }

            return list.ToArray();
        }
        /// <summary>
        /// 取文本中间内容
        /// </summary>
        /// <param name="str">原文本</param>
        /// <param name="leftstr">左边文本</param>
        /// <param name="rightstr">右边文本</param>
        /// <returns>返回中间文本内容</returns>
        public static string Between(string str, string leftstr, string rightstr)
        {
            int i = str.IndexOf(leftstr) + leftstr.Length;
            string temp = str.Substring(i, str.IndexOf(rightstr, i) - i);
            return temp;
        }
        /// <summary>
        /// 取文本中间到List集合
        /// </summary>
        /// <param name="str">文本字符串</param>
        /// <param name="leftstr">左边文本</param>
        /// <param name="rightstr">右边文本</param>
        /// <returns>List集合</returns>
        public static List<string> BetweenArr(string str, string leftstr, string rightstr)
        {
            List<string> list = new List<string>();
            int leftIndex = str.IndexOf(leftstr);//左文本起始位置
            int leftlength = leftstr.Length;//左文本长度
            int rightIndex = 0;
            string temp = "";
            while (leftIndex != -1)
            {
                rightIndex = str.IndexOf(rightstr, leftIndex + leftlength);
                if (rightIndex == -1)
                {
                    break;
                }
                temp = str.Substring(leftIndex + leftlength, rightIndex - leftIndex - leftlength);
                list.Add(temp);
                leftIndex = str.IndexOf(leftstr, rightIndex + 1);
            }
            return list;
        }
    }
}