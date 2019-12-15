using CefSharp.WinForms;
using Entity;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace excel_operation.CS
{
    public class CaiJi_MoGuJie
    {

        #region caiji_listpage 
        /// <summary>
        /// 根据蘑菇街列表页面采集商品信息
        /// </summary>
        /// <param name="urls">列表页网址</param>
        /// <param name="type">采集类型 1为单肩包列表页  2为双肩包列表页 </param>
        /// <param name="webBrowser1">谷歌浏览器</param>
        public static List<aotunew_title> caiji_listpage(string urls, string type, ChromiumWebBrowser webBrowser1)
        {


            List<aotunew_title> list = new List<aotunew_title>();
            //单肩包综合页面
            webBrowser1.Load(urls);

            try
            {
                if (Browser.WaitWebPageLoad(webBrowser1))
                {
                    //商品数量iwf goods_item
                    string temp = Browser.JS_CEFBrowser("getClassName('goods_item').length", webBrowser1);
                    int count = 0;
                    if (int.TryParse(temp, out count))
                    {

                        List<string> list_str = new List<string>();
                        for (int i = 0; i < count; i++)
                        {
                            string url = Browser.JS_CEFBrowser("getClassName('goods_item')[" + i + "].getElementsByTagName('a')[1].href;", webBrowser1);
                            list_str.Add(url);
                        }
                        foreach (string url in list_str)
                        {
                            webBrowser1.Load(url);
                            if (Browser.WaitWebPageLoad(webBrowser1))
                            {
                                string title = Browser.JS_CEFBrowser(" getClassName('goods-title')[0].innerText; ", webBrowser1);
                                string price = Browser.JS_CEFBrowser(" document.getElementById('J_NowPrice').innerText; ", webBrowser1);
                                string sells = Browser.JS_CEFBrowser(" getClassName('num J_SaleNum')[0].innerText; ", webBrowser1);
                                string likes = Browser.JS_CEFBrowser(" getClassName('fav-num')[0].innerText; ", webBrowser1);
                                string jianshu = Browser.JS_CEFBrowser(" getClassName('graphic-text')[0].innerText; ", webBrowser1);
                                string dpname = Browser.JS_CEFBrowser(" getClassName('name-wrap')[0].getElementsByTagName('a')[0].title ; ", webBrowser1);

                                aotunew_title at = new aotunew_title();
                                at.atdate = DateTime.Now;
                                at.atjieshao = jianshu;
                                at.atlike = likes;
                                at.atprice = price;
                                at.atsell = sells;
                                at.aturl = url;
                                at.attype1 = type;
                                at.atremark1 = dpname;
                                at.attitle = title;
                                list.Add(at);
                                //BLL2.aotunew_titleManager.Insert(at);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("采集蘑菇街列表页信息失败：" + ex.ToString());
                Debug.WriteLine("网址：" + urls);
                Debug.WriteLine(ex.ToString());
            }
            return list;
        }
        #endregion







    }
}
