using System;
using System.Collections.Generic;
using Entity;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text.RegularExpressions;
using CefSharp.WinForms;
using System.Text;
using System.Net;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace excel_operation.CS
{
    public class CaiJi
    {



        //单品采集

        #region 根据WebBrowser商品详细页面采集店铺
        /// <summary>
        /// 根据WebBrowser商品详细页面采集店铺
        /// </summary>
        /// <param name="datenow">采集时间</param>
        /// <param name="webBrowser1">WebBrowser</param>
        /// <returns>opponent_dianpu</returns>
        public static opponent_dianpu CaijiDP(string datenow, WebBrowser webBrowser1)
        {

            Entity.opponent_dianpu dp = new Entity.opponent_dianpu();
            int st = GetShopType(webBrowser1);
            //如果是未知店铺类型
            if (st == 0)
            {
                return null;
            }
            try
            {
                string dpname = "";
                string dptbid = "";
                string wangwang = "";
                //如果是天猫
                if (st == 1)
                {
                    //Manager.SetJS_getMetaName(webBrowser1);
                    dpname = Browser.GetValueByClassName("slogo-shopname", 0, "innerText", webBrowser1);
                    dptbid = Browser.JS_WebBrowser(" getMetaName('microscope-data')[0].content; ", webBrowser1);
                    //pageId=995902768;prototypeId=3;siteCategory=3;siteInstanceId=295420826;shopId=116498224;userId=2392094571
                    string[] temp_1 = dptbid.Split(new char[1] { ';' });
                    if (temp_1.Length > 0)
                    {
                        foreach (string temp in temp_1)
                        {
                            string[] temp_3 = temp.Split(new char[1] { '=' });
                            string temp_4 = temp_3[0].Trim();
                            if (temp_4.Equals("shopId"))
                            {
                                dptbid = temp_3[1];
                            }
                        }

                    }
                    wangwang = dpname;
                }
                else
                {
                    //如果是企业店铺或者是普通店铺
                    dpname = Browser.JS_WebBrowser(" getClassName('shop-name')[0].getElementsByTagName('a')[0].innerText; ", webBrowser1);
                    dpname = dpname.Replace("进入店铺", "");
                    dptbid = Browser.JS_WebBrowser(" getClassName('shop-collect')[0].href ", webBrowser1);
                    dptbid = Manager.GetValueByURL(dptbid, "id");
                    wangwang = Browser.JS_WebBrowser("document.getElementsByClassName('info-item')[1].innerText ", webBrowser1);
                    wangwang = wangwang.Replace(" ", "");
                    wangwang = wangwang.Replace("掌柜：", "");
                }

                #region 2017年11月28日10:23:36删除
                /*
                //如果是企业店铺
                if (st == 2)
                {
                    #region 2017年11月28日10:23:36删除
                    //dpname = Browser.GetValueByClassName("shop-name-title", 0, "innerText", webBrowser1);
                    //dptbid = Browser.JS_WebBrowser(" getClassName('shop-collect')[0].href ", webBrowser1);
                    //dptbid = Manager.GetValueByURL(dptbid, "id");
                    //wangwang = Browser.JS_WebBrowser(" getClassName('ww-light')[0].getElementsByTagName('a')[0].href; ", webBrowser1);
                    //wangwang = Manager.GetURLParam(wangwang, "uid");
                    #endregion

                    dpname = Browser.JS_WebBrowser(" getClassName('shop-name')[0].getElementsByTagName('a')[0].innerText; ", webBrowser1);
                    dpname = dpname.Replace("进入店铺", "");
                    dptbid = Browser.JS_WebBrowser(" getClassName('shop-collect')[0].href ", webBrowser1);
                    dptbid = Manager.GetValueByURL(dptbid, "id");
                    wangwang = Browser.JS_WebBrowser("document.getElementsByClassName('info-item')[1].innerText ", webBrowser1);
                    wangwang = wangwang.Replace(" ", "");
                    wangwang = wangwang.Replace("掌柜：", "");
                }
                //如果是普通店铺
                if (st == 3)
                {
                    #region 2017年11月28日10:21:42 删除
                    //string isSearchPage = Browser.JS_WebBrowser(" getClassName('tb-shop-name').length;", webBrowser1);
                    ////如果是商品列表页面
                    //if (isSearchPage == "0")
                    //{
                    //    dpname = Browser.JS_WebBrowser(" getClassName('shop-name')[0].getElementsByTagName('a')[0].innerText; ", webBrowser1);
                    //    dpname = dpname.Replace("进入店铺", "");
                    //    dptbid = Browser.JS_WebBrowser(" getClassName('shop-collect')[0].href ", webBrowser1);
                    //    dptbid = Manager.GetValueByURL(dptbid, "id");
                    //    //wangwang = Browser.JS_WebBrowser(" getClassName('seller-name')[0].innerText; ", webBrowser1);
                    //    //wangwang = wangwang.Replace("掌柜：", "");
                    //    wangwang = Browser.JS_WebBrowser("document.getElementsByClassName('info-item')[1].innerText ", webBrowser1);
                    //    wangwang = wangwang.Replace(" ", "");
                    //    wangwang = wangwang.Replace("掌柜：", "");
                    //}
                    //else
                    //{
                    //    dpname = Browser.JS_WebBrowser(" getClassName('tb-shop-name')[0].getElementsByTagName('a')[0].title; ", webBrowser1);
                    //    dptbid = Browser.JS_WebBrowser(" getClassName('tb-booth')[0].getElementsByTagName('a')[0].href; ", webBrowser1);
                    //    dptbid = Manager.GetValueByURL(dptbid, "shopId");
                    //    wangwang = Browser.JS_WebBrowser(" getClassName('tb-shop-ww')[0].getElementsByTagName('a')[0].href; ", webBrowser1);
                    //    wangwang = Manager.GetURLParam(wangwang, "uid");

                    //}
                    #endregion

                    dpname = Browser.JS_WebBrowser(" getClassName('shop-name')[0].getElementsByTagName('a')[0].innerText; ", webBrowser1);
                    dpname = dpname.Replace("进入店铺", "");
                    dptbid = Browser.JS_WebBrowser(" getClassName('shop-collect')[0].href ", webBrowser1);
                    dptbid = Manager.GetValueByURL(dptbid, "id");
                    wangwang = Browser.JS_WebBrowser("document.getElementsByClassName('info-item')[1].innerText ", webBrowser1);
                    wangwang = wangwang.Replace(" ", "");
                    wangwang = wangwang.Replace("掌柜：", "");
                }*/
                #endregion


                dp.odcollectdate = datenow;
                dp.odpname = dpname;
                dp.odTBID = dptbid;
                dp.odwangwang = wangwang;
            }
            catch (Exception ex)
            {
                MessageBox.Show("采集店铺失败：" + ex.Message);
            }
            return dp;

        }

        #endregion

        #region 根据WebBrowser商品详细页面采集店铺信息
        /// <summary>
        /// 根据WebBrowser商品详细页面采集店铺信息
        /// </summary>
        /// <param name="datenow">采集时间</param>
        /// <param name="webBrowser1">WebBrowser</param>
        /// <returns>opponent_dianpu_info</returns>
        public static opponent_dianpu_info CaijiDPSDR(string datenow, WebBrowser webBrowser1)
        {

            opponent_dianpu_info dpinfo = new opponent_dianpu_info();
            int st = GetShopType(webBrowser1);
            //如果是未知店铺类型
            if (st == 0)
            {
                return null;
            }
            try
            {
                //string baozhangjin = Manager.GetValueByClassName("info-item", 3, "innerText", webBrowser1);
                //baozhangjin = Manager.Substring(baozhangjin, "：", "###");
                string baozhangjin = "";
                string SDRmiaoshu = "";
                string SDRzhiliang = "";
                string SDRwuliu = "";
                string dptbid = "";
                //如果是天猫
                if (st == 1)
                {
                    SDRmiaoshu = Browser.GetValueByClassName("shopdsr-score-con", 0, "innerText", webBrowser1);
                    SDRzhiliang = Browser.GetValueByClassName("shopdsr-score-con", 1, "innerText", webBrowser1);
                    SDRwuliu = Browser.GetValueByClassName("shopdsr-score-con", 2, "innerText", webBrowser1);
                    dptbid = Browser.JS_WebBrowser(" getMetaName('microscope-data')[0].content; ", webBrowser1);
                    //pageId=995902768;prototypeId=3;siteCategory=3;siteInstanceId=295420826;shopId=116498224;userId=2392094571
                    string[] temp_1 = dptbid.Split(new char[1] { ';' });
                    if (temp_1.Length > 0)
                    {
                        foreach (string temp in temp_1)
                        {
                            string[] temp_3 = temp.Split(new char[1] { '=' });
                            string temp_4 = temp_3[0].Trim();
                            if (temp_4.Equals("shopId"))
                            {
                                dptbid = temp_3[1];
                            }
                        }

                    }
                }
                else
                {
                    #region 2017年11月28日10:45:15删除
                    //else if (st == 2)//企业店铺count
                    //{
                    //    SDRmiaoshu = Browser.GetValueByClassName("count", 0, "title", webBrowser1);
                    //    SDRzhiliang = Browser.GetValueByClassName("count", 1, "title", webBrowser1);
                    //    SDRwuliu = Browser.GetValueByClassName("count", 2, "title", webBrowser1);

                    //    dptbid = Browser.JS_WebBrowser(" getClassName('shop-collect')[0].href ", webBrowser1);
                    //    dptbid = Manager.GetValueByURL(dptbid, "id");
                    //    //tb-seller-bail
                    //    baozhangjin = Browser.GetValueByClassName("tb-seller-bail", 0, "innerText", webBrowser1);
                    //    baozhangjin = baozhangjin.Replace("元", "");
                    //    baozhangjin = baozhangjin.Trim();
                    //}
                    //else if (st == 3)//普通店铺
                    //{
                    //    //orange J_TotalBailAmount判断是否是搜索页面
                    //    string temp = Browser.JS_WebBrowser(" getClassName('J_TotalBailAmount').length; ", webBrowser1);
                    //    if (temp == "0")//详情页面
                    //    {

                    //        //tb-seller-bail-text
                    //        baozhangjin = Browser.GetValueByClassName("tb-seller-bail-text", 0, "innerText", webBrowser1);
                    //        baozhangjin = baozhangjin.Replace("元", "");
                    //        baozhangjin = baozhangjin.Trim();
                    //        SDRmiaoshu = Browser.JS_WebBrowser(" getClassName('tb-shop-rate')[0].getElementsByTagName('dd')[0].innerText;  ", webBrowser1);
                    //        SDRzhiliang = Browser.JS_WebBrowser(" getClassName('tb-shop-rate')[0].getElementsByTagName('dd')[1].innerText;  ", webBrowser1);
                    //        SDRwuliu = Browser.JS_WebBrowser(" getClassName('tb-shop-rate')[0].getElementsByTagName('dd')[2].innerText;  ", webBrowser1);
                    //        dptbid = Browser.JS_WebBrowser(" getClassName('tb-booth')[0].getElementsByTagName('a')[0].href; ", webBrowser1);
                    //        dptbid = Manager.GetValueByURL(dptbid, "shopId");
                    //    }
                    //    else//商品列表页面
                    //    {
                    //        dptbid = Browser.JS_WebBrowser(" getClassName('shop-collect')[0].href ", webBrowser1);
                    //        dptbid = Manager.GetValueByURL(dptbid, "id");
                    //        SDRmiaoshu = Browser.GetValueByClassName("count", 0, "title", webBrowser1);
                    //        SDRzhiliang = Browser.GetValueByClassName("count", 1, "title", webBrowser1);
                    //        SDRwuliu = Browser.GetValueByClassName("count", 2, "title", webBrowser1);
                    //        baozhangjin = Browser.GetValueByClassName("J_TotalBailAmount", 0, "innerText", webBrowser1);
                    //        baozhangjin = baozhangjin.Replace("元", "");
                    //    }
                    //}
                    #endregion

                    baozhangjin = Browser.JS_WebBrowser("document.getElementsByClassName('tb-seller-bail')[0].innerText", webBrowser1);
                    baozhangjin = baozhangjin.Replace("元", "");
                    baozhangjin = baozhangjin.Trim();

                    SDRmiaoshu = Browser.JS_WebBrowser(" document.getElementsByClassName('count')[0].title ", webBrowser1);
                    SDRmiaoshu = SDRmiaoshu.Replace("分", "");
                    SDRmiaoshu = SDRmiaoshu.Trim();

                    SDRzhiliang = Browser.JS_WebBrowser(" document.getElementsByClassName('count')[1].title ", webBrowser1);
                    SDRzhiliang = SDRzhiliang.Replace("分", "");
                    SDRzhiliang = SDRzhiliang.Trim();

                    SDRwuliu = Browser.JS_WebBrowser(" document.getElementsByClassName('count')[2].title ", webBrowser1);
                    SDRwuliu = SDRwuliu.Replace("分", "");
                    SDRwuliu = SDRwuliu.Trim();

                    dptbid = Browser.JS_WebBrowser(" getClassName('shop-collect')[0].href ", webBrowser1);
                    dptbid = Manager.GetValueByURL(dptbid, "id");

                }


                dpinfo.ocollectdate = datenow;
                dpinfo.odibaozhangjin = baozhangjin;
                //dpinfo.odidongxiao = "";
                dpinfo.odiDSRmiaoshu = SDRmiaoshu;
                dpinfo.odiDSRwuliu = SDRwuliu;
                dpinfo.odiDSRzhiliang = SDRzhiliang;
                dpinfo.oshopid = dptbid;
                //bind_dianpu_info(dpinfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("采集店铺信息失败：" + ex.Message);
            }
            return dpinfo;

        }

        #endregion

        #region 根据WebBrowser商品详细页面采集商品信息
        /// <summary>
        /// 根据WebBrowser商品详细页面采集商品信息
        /// </summary>
        /// <param name="datenow">采集时间</param>
        /// <param name="webBrowser1">WebBrowser</param>
        /// <returns>opponent_goods</returns>
        public static opponent_goods CaijiGoods(string datenow, WebBrowser webBrowser1)
        {

            opponent_goods og = new opponent_goods();
            int st = GetShopType(webBrowser1);
            //如果是未知店铺类型
            if (st == 0)
            {
                return null;
            }
            try
            {
                string shoucang = "0";
                string pinglun = "0";
                string xiaoliang = "0";
                string img1 = "";
                string path = Application.StartupPath + "\\Image";
                string imgname = DateTime.Now.ToString("yyyyMMddhhmmss") + Manager.RandomNumber(1000, 99999).ToString() + ".jpg";
                string temp_priceNum = "";
                int temp_priceNum1 = 0;
                string price1 = "";
                string price2 = "";
                //邮费标签出现过问题
                string youfei = "";
                string SKUnum = "1";
                string name = "";
                string url = webBrowser1.Url.AbsoluteUri;
                string id = Manager.GetValueByURL(url, "id");
                string subtitle = "";
                string dptbid = "";
                //如果是天猫店铺
                if (st == 1)
                {
                    shoucang = GetRenQiByStr(Browser.GetValueById("J_CollectCount", "innerText", webBrowser1));
                    shoucang = shoucang.Replace("（", "");
                    shoucang = shoucang.Replace("人气）", "");
                    pinglun = Browser.JS_WebBrowser(" getClassName('tm-count')[1].innerText; ", webBrowser1);
                    xiaoliang = Browser.JS_WebBrowser(" getClassName('tm-count')[0].innerText; ", webBrowser1);
                    img1 = GetImgById("J_UlThumb", 0, webBrowser1);//J_UlThumb
                    //imgname = 
                    Manager.DownloadFile(img1, path, imgname, 5000);
                    //判断是否打折？
                    temp_priceNum = Browser.JS_WebBrowser(" getClassName('tm-price').length; ", webBrowser1);
                    int.TryParse(temp_priceNum, out temp_priceNum1);
                    if (temp_priceNum1 > 0)
                    {
                        price1 = Browser.GetValueByClassName("tm-price", 0, "innerText", webBrowser1);
                        if (temp_priceNum1 > 1)
                        {
                            price2 = Browser.GetValueByClassName("tm-price", 1, "innerText", webBrowser1);
                        }
                        else
                        {
                            price2 = price1;
                        }
                    }
                    //邮费标签出现过问题
                    youfei = Browser.GetValueById("J_PostageToggleCont", "innerText", webBrowser1);
                    youfei = youfei.Replace("快递:", "");
                    youfei = youfei.Trim();
                    if (Browser.JS_WebBrowser(" getClassName('J_TSaleProp').length", webBrowser1) == "1")
                        SKUnum = Browser.GetValueByClassName("J_TSaleProp", 0, "getElementsByTagName('li').length", webBrowser1);
                    else
                        SKUnum = "1";
                    name = Browser.GetValueByClassName("tb-detail-hd", 0, "getElementsByTagName('h1')[0].innerText ", webBrowser1);
                    subtitle = Browser.GetValueByClassName("newp", 0, "innerText", webBrowser1);
                    dptbid = Browser.JS_WebBrowser(" getMetaName('microscope-data')[0].content; ", webBrowser1);
                    //pageId=995902768;prototypeId=3;siteCategory=3;siteInstanceId=295420826;shopId=116498224;userId=2392094571
                    string[] temp_1 = dptbid.Split(new char[1] { ';' });
                    if (temp_1.Length > 0)
                    {
                        foreach (string temp in temp_1)
                        {
                            string[] temp_3 = temp.Split(new char[1] { '=' });
                            string temp_4 = temp_3[0].Trim();
                            if (temp_4.Equals("shopId"))
                            {
                                dptbid = temp_3[1];
                            }
                        }

                    }
                }
                else
                {
                    //如果是企业店铺普通店铺
                    if (Browser.JS_WebBrowser(" getClassName('J_FavCount').length", webBrowser1) == "1")
                    {
                        string temp_bool = Browser.JS_WebBrowser(" getClassName('J_FavCount')[0]==null;", webBrowser1);
                        //Convert.ToBoolean(temp_bool);
                        if (!Convert.ToBoolean(temp_bool))
                        {
                            shoucang = GetRenQiByStr(Browser.GetValueByClassName("J_FavCount", 0, "innerText", webBrowser1));
                            if (string.IsNullOrEmpty(shoucang))
                            {
                                shoucang = "0";
                            }
                            else
                            {
                                shoucang = shoucang.Replace("(", "");
                                shoucang = shoucang.Replace("人气）", "");
                                shoucang = shoucang.Trim();
                            }
                        }
                    }
                    pinglun = Browser.GetValueById("J_RateCounter", "innerText", webBrowser1);
                    //xiaoliang = Browser.GetValueById("J_SellCounter", "innerText", webBrowser1);
                    xiaoliang = Browser.JS_WebBrowser("document.getElementsByClassName('tb-sell-counter')[0].getElementsByTagName('a')[0].title", webBrowser1);
                    xiaoliang = Manager.SubString2(xiaoliang, "已售出", "件，其中");
                    img1 = GetImgById("J_UlThumb", 0, webBrowser1);
                    Manager.DownloadFile(img1, path, imgname, 5000);
                    //判断是否打折？
                    temp_priceNum = Browser.JS_WebBrowser(" getClassName('tb-rmb-num').length; ", webBrowser1);
                    int.TryParse(temp_priceNum, out temp_priceNum1);
                    if (temp_priceNum1 > 0)
                    {
                        price1 = Browser.GetValueByClassName("tb-rmb-num", 0, "innerText", webBrowser1);
                        if (temp_priceNum1 > 1)
                        {
                            price2 = Browser.GetValueByClassName("tb-rmb-num", 1, "innerText", webBrowser1);
                        }
                        else
                        {
                            price2 = price1;
                        }
                    }
                    //邮费标签出现过问题
                    if (Browser.JS_WebBrowser(" document.getElementById('J_WlServiceTitle')==null ", webBrowser1).ToLower() == "false")
                        youfei = Browser.GetValueById("J_WlServiceTitle", "innerText", webBrowser1);
                    else
                        youfei = "1";
                    youfei = youfei.Replace("快递 ", "");
                    if (Browser.JS_WebBrowser(" getClassName('J_TSaleProp').length", webBrowser1) == "1")
                        SKUnum = Browser.GetValueByClassName("J_TSaleProp", 0, "getElementsByTagName('li').length", webBrowser1);
                    else
                        SKUnum = "1";
                    name = Browser.GetValueByClassName("tb-main-title", 0, "innerText", webBrowser1);
                    if (Browser.JS_WebBrowser(" getClassName('tb-subtitle').length", webBrowser1) == "1")
                    {
                        if (Browser.JS_WebBrowser("document.getElementsByName('tb-subtitle')[0]==null;", webBrowser1).ToLower() == "false")
                        {
                            subtitle = Browser.GetValueByClassName("tb-subtitle", 0, "innerText ", webBrowser1);//
                        }
                    }
                    else
                    {
                        subtitle = "";
                    }
                    if (st == 2)
                    {
                        dptbid = Browser.JS_WebBrowser(" getClassName('shop-collect')[0].href ", webBrowser1);
                        dptbid = Manager.GetValueByURL(dptbid, "id");
                    }
                    else if (st == 3)
                    {
                        //orange J_TotalBailAmount判断是否是搜索页面
                        string temp = Browser.JS_WebBrowser(" getClassName('J_TotalBailAmount').length; ", webBrowser1);
                        if (temp == "0")//详情页面
                        {
                            dptbid = Browser.JS_WebBrowser(" getClassName('tb-booth')[0].getElementsByTagName('a')[0].href; ", webBrowser1);
                            dptbid = Manager.GetValueByURL(dptbid, "shopId");
                        }
                        else//商品列表页面
                        {
                            dptbid = Browser.JS_WebBrowser(" getClassName('shop-collect')[0].href ", webBrowser1);
                            dptbid = Manager.GetValueByURL(dptbid, "id");
                        }
                    }
                }
                #region 如果是普通店铺

                //else if (st == 3)
                //{
                //    //
                //    if (Manager.JS_WebBrowser(" getClassName('J_FavCount').length", webBrowser1) == "1")
                //    {
                //        if (Manager.JS_WebBrowser("getClassName('J_FavCount')[0]==null;", webBrowser1) == "false")
                //        {
                //            shoucang = GetRenQiByStr(Manager.GetValueByClassName("J_FavCount", 0, "innerText", webBrowser1));
                //            shoucang = shoucang.Replace("(", "");
                //            shoucang = shoucang.Replace("人气）", "");
                //            shoucang = shoucang.Trim();
                //        }
                //    }

                //    pinglun = Manager.GetValueById("J_RateCounter", "innerText", webBrowser1);
                //    xiaoliang = Manager.GetValueById("J_SellCounter", "innerText", webBrowser1);
                //    img1 = GetImgById("J_UlThumb", 0, webBrowser1);
                //    Manager.DownloadFile(img1, path, imgname, 5000);
                //    //判断是否打折？
                //    temp_priceNum = Manager.JS_WebBrowser(" getClassName('tb-rmb-num').length; ", webBrowser1);
                //    int.TryParse(temp_priceNum, out temp_priceNum1);
                //    if (temp_priceNum1 > 0)
                //    {
                //        price1 = Manager.GetValueByClassName("tb-rmb-num", 0, "innerText", webBrowser1);
                //        if (temp_priceNum1 > 1)
                //        {
                //            price2 = Manager.GetValueByClassName("tb-rmb-num", 1, "innerText", webBrowser1);
                //        }
                //        else
                //        {
                //            price2 = price1;
                //        }
                //    }
                //    //邮费标签出现过问题
                //    if (Manager.JS_WebBrowser(" document.getElementById('J_WlServiceTitle')==null ", webBrowser1) == "false")
                //        youfei = Manager.GetValueById("J_WlServiceTitle", "innerText", webBrowser1);
                //    else
                //        youfei = "1";
                //    youfei = youfei.Replace("快递 ", "");
                //    if (Manager.JS_WebBrowser(" getClassName('J_TSaleProp').length", webBrowser1) == "1")
                //        SKUnum = Manager.GetValueByClassName("J_TSaleProp", 0, "getElementsByTagName('li').length", webBrowser1);
                //    else
                //        SKUnum = "1";
                //    name = Manager.GetValueByClassName("tb-main-title", 0, "innerText", webBrowser1);
                //    if (Manager.JS_WebBrowser(" getClassName('tb-subtitle').length", webBrowser1) == "1")
                //    {
                //        if (Manager.JS_WebBrowser("document.getElementsByName('tb-subtitle')[0]==null;", webBrowser1) == "false")
                //        {
                //            subtitle = Manager.GetValueByClassName("tb-subtitle", 0, "innerText ", webBrowser1);//
                //        }
                //    }
                //    else
                //    {
                //        subtitle = "";
                //    }
                //    //orange J_TotalBailAmount判断是否是搜索页面
                //    string temp = Manager.JS_WebBrowser(" getClassName('J_TotalBailAmount').length; ", webBrowser1);
                //    if (temp == "0")//详情页面
                //    {
                //        dptbid = Manager.JS_WebBrowser(" getClassName('tb-booth')[0].getElementsByTagName('a')[0].href; ", webBrowser1);
                //        dptbid = Manager.GetValueByURL(dptbid, "shopId");
                //    }
                //    else//商品列表页面
                //    {
                //        dptbid = Manager.JS_WebBrowser(" getClassName('shop-collect')[0].href ", webBrowser1);
                //        dptbid = Manager.GetValueByURL(dptbid, "id");
                //    }
                //}

                #endregion

                og.ocollectdate = datenow;
                og.ogdiscount = Manager.GetZheKou(price1, price2).ToString();
                og.ogimg = img1;
                og.ogpostage = youfei;
                og.ogprice1 = price1;
                og.ogprice2 = price2;
                og.ogsales = xiaoliang;
                og.ogSKU = SKUnum;
                og.ogTBid = id;
                og.ogtittle = name;
                og.ogurl = url;
                og.ogshoucang = shoucang;
                og.ogxiaoliang = pinglun;
                og.ogremark = imgname;
                og.ogremark1 = subtitle;
                og.oshopid = dptbid;
            }
            catch (Exception ex)
            {
                //出错则不添加该商品
                og = null;
                Debug.WriteLine("==================================================");
                Debug.WriteLine("网址：" + Browser.urlstr);
                Debug.WriteLine("采集商品信息失败： " + ex.Message);
                //MessageBox.Show("采集商品信息失败：" + ex.Message);
            }
            return og;

        }

        #endregion




        //===============================================================================




        //全店采集


        #region 根据旺旺账号获取店铺网址
        /// <summary>
        /// 根据旺旺账号获取店铺网址
        /// </summary>
        /// <param name="wangwang">旺旺账号</param>
        /// <param name="webBrowser1">WebBrowser</param>
        /// <returns>店铺网址</returns>
        public static string GetShopUrlByWangWang(string wangwang, WebBrowser webBrowser1)
        {

            string str = "";
            //判断是否有该店铺
            Browser.jsstr = " getClassName('shop-info-list').length;";
            string temp = Browser.JS_WebBrowser(webBrowser1);
            if (temp == "0")
            {
                return str;
            }

            //找到该店铺信息
            Browser.jsstr = " getClassName('shop-info-list')[0].getElementsByTagName('a')[0].getElementsByTagName('span')[0].innerHTML;";

            string wangwang2 = Browser.JS_WebBrowser(webBrowser1);
            if (wangwang != wangwang2)
            {
                Debug.WriteLine("===============================================");
                Debug.WriteLine("没有找到店铺，搜索后的店铺信息是： " + wangwang2 + " ，和原店铺信息不匹配");
                return str;
            }
            else
            {
                //找到该店铺后
                //JS获取页面信息判断是否找到该店铺

                Browser.jsstr = " getClassName('shop-info-list')[0].getElementsByTagName('a')[0].href; ";
                str = Browser.JS_WebBrowser(webBrowser1);
            }
            //str = Manager.AddString_Http(str);
            //https://shop34354620.taobao.com/?spm=a230r.7195193.1997079397.4.Gp8r5W
            string[] strs = Regex.Split(str, ".taobao.com", RegexOptions.IgnoreCase);
            if (strs.Length > 0)
            {
                str = strs[0];
                str = Manager.Substring(str, new string[] { "http", "shop", ":", "s", "/" });
            }
            Debug.WriteLine(str);
            return str;

        }

        #endregion

        #region GetShopIDByURL
        /// <summary>
        /// 根据网址获取店铺ID
        /// </summary>
        /// <param name="wangwang">旺旺账号</param>
        /// <param name="webBrowser1">WebBrowser</param>
        /// <returns>店铺网址</returns>
        public static string GetShopIDByURL(string url)
        {

            string str = "";
            //str = Manager.AddString_Http(str);
            //https://shop34354620.taobao.com/?spm=a230r.7195193.1997079397.4.Gp8r5W
            string[] strs = Regex.Split(url, ".taobao.com", RegexOptions.IgnoreCase);
            if (strs.Length > 0)
            {
                str = strs[0];
                str = Manager.Substring(str, new string[] { "http", "shop", ":", "s", "/" });
            }
            Debug.WriteLine(str);
            return str;

        }

        #endregion

        #region GetShopIDByMate
        /// <summary>
        /// 根据Mate信息获取店铺ID
        /// </summary>
        /// <param name="webBrowser2">WebBrowser</param>
        /// <returns>店铺网址</returns>
        public static string GetShopIDByMate(ChromiumWebBrowser webBrowser2)
        {
            string res = "";
            string shopid_data = Browser.JS_CEFBrowser("document.getElementsByName('microscope-data')[0].content", webBrowser2);
            if (shopid_data.IndexOf("shopId") != -1)
            {
                string[] strs = shopid_data.Split(new char[] { ';' });
                foreach (string temp in strs)
                {
                    if (temp.IndexOf("shopId") != -1)
                    {
                        res = temp.Replace("shopId=", "");
                    }
                }
            }
            Debug.WriteLine(res);
            return res;

        }

        #endregion



        #region 获取当前搜索页面中所有商品网址
        /// <summary>
        /// 获取当前搜索页面中所有商品网址
        /// </summary>
        /// <param name="wangwang">旺旺账号</param>
        /// <param name="webBrowser1">WebBrowser</param>
        /// <returns>店铺网址</returns>
        public static List<string> GetGoodsUrlList(WebBrowser webBrowser1)
        {
            List<string> list = new List<string>();
            /*
            //string str = "";
            //JS获取页面信息判断是否找到该店铺
            jsstr = "  getClassName('item3line1').length; ";
            string res = Manager.JS_WebBrowser(webBrowser1);
            Debug.WriteLine(res);//输出
            int list_count1 = 0;
            //如果没有商品，则返回空
            if (!int.TryParse(res, out list_count1))
            {
                Debug.WriteLine("没有获取到商品");//输出
                return list;
            }
            else
            {
                //遍历每行
                for (int i = 0; i < list_count1; i++)
                {
                    //获取本行商品数量
                    jsstr = "   getClassName('item3line1')[" + i.ToString() + "].getElementsByTagName('dl').length;  ";
                    res = Manager.JS_WebBrowser(webBrowser1);
                    int list_count2 = 0;
                    Debug.WriteLine(res);//输出
                    //如果没有商品，则返回空
                    if (!int.TryParse(res, out list_count2))
                    {
                        Debug.WriteLine("没有获取到商品");//输出
                        return list;
                    }
                    else
                    {
                        //遍历每列
                        for (int ii = 0; ii < list_count1; ii++)
                        {
                            //获取本行商品数量
                            //jsstr = "   getClassName('item3line1')[" + i.ToString() + "].getElementsByTagName('dl').getElementsByTagName('a')[" + ii.ToString() + "].href;  "; getAttribute
                            jsstr = "   getClassName('item3line1')[" + i.ToString() + "].getElementsByTagName('dl').getAttribute('data-id');  "; 
                            res = Manager.JS_WebBrowser(webBrowser1);
                            Debug.WriteLine(res);//输出

                        }
                    }

                }

            }*/
            Browser.jsstr = "  getClassName('photo').length; ";
            string res = Browser.JS_WebBrowser(webBrowser1);
            Debug.WriteLine(res);//输出
            int list_count1 = 0;
            //如果没有商品，则返回空
            if (!int.TryParse(res, out list_count1))
            {
                Debug.WriteLine("没有获取到商品");//输出
                return list;
            }
            else
            {
                //遍历每个商品
                for (int i = 0; i < list_count1; i++)
                {
                    //获取本行商品数量
                    Browser.jsstr = "   getClassName('photo')[" + i.ToString() + "].getElementsByTagName('a')[0].href;  ";
                    res = Browser.JS_WebBrowser(webBrowser1);
                    Debug.WriteLine(res);//输出
                    list.Add(res);
                }

            }

            return list;

        }

        #endregion

        #region 获取页面中店铺类型
        /// <summary>
        /// 获取页面中店铺类型： 空：未获取到信息；1：天猫店铺；2：企业店铺；3：普通店铺；
        /// </summary>
        /// <param name="webBrowser1"></param>
        /// <returns></returns>
        public static string GetDianPuType(WebBrowser webBrowser1)
        {
            string res = "";
            if (CaiJi.IsTmall(webBrowser1))
            {
                res = "1";
            }
            else if (CaiJi.IsCompany(webBrowser1))
            {
                res = "2";
            }
            else if (CaiJi.IsCommony(webBrowser1))
            {
                res = "3";
            }
            return res;
        }
        #endregion

        #region 获取店铺等级网址
        /// <summary>
        /// 获取店铺等级网址
        /// </summary>
        /// <param name="webBrowser1">WebBrowser</param>
        /// <returns>店铺等级网址</returns>
        public static string GetRateUrl(WebBrowser webBrowser1)
        {
            string res = null;

            if (IsTmall(webBrowser1))
            {
                Browser.jsstr = " document.getElementById('dsr-ratelink').value ; ";
                //Manager.jsstr = "  getClassName('render-byjs')[0].getElementsByTagName('a')[0].href; ";
                res = Browser.JS_WebBrowser(webBrowser1);
            }
            //普通店铺
            else if (IsCommony(webBrowser1))
            {
                //Manager.jsstr = "  getClassName('tb-shop-rank')[0].getElementsByTagName('a')[0].href; ";
                Browser.jsstr = "  document.getElementById('miniDSR').href ; ";
                res = Browser.JS_WebBrowser(webBrowser1);
            }
            else if (IsCompany(webBrowser1))
            {
                Browser.jsstr = "  getClassName('shop-rank')[0].getElementsByTagName('a')[0].href; ";

                res = Browser.JS_WebBrowser(webBrowser1);
            }

            return res;

        }

        #endregion

        #region 获取店铺类型网址，0：未知店铺类型；1：天猫店铺；2：企业店铺；3：普通店铺
        /// <summary>
        /// 获取店铺类型网址，0：未知店铺类型；1：天猫店铺；2：企业店铺；3：普通店铺
        /// </summary>
        /// <param name="webBrowser1">WebBrowser</param>
        /// <returns>0：未知店铺类型；1：天猫店铺；2：企业店铺；3：普通店铺</returns>
        public static int GetShopType(WebBrowser webBrowser1)
        {
            int res = 0;

            if (IsTmall(webBrowser1))
            {
                res = 1;
            }
            else if (IsCompany(webBrowser1))
            {
                res = 2;
            }
            //普通店铺
            else if (IsCommony(webBrowser1))
            {
                res = 3;
            }


            return res;

        }

        #endregion


        #region 网供采集



        #region 根据商品搜索页面采集店铺信息
        /// <summary>
        /// 根据商品搜索页面采集店铺信息
        /// </summary>
        /// <param name="datenow">采集时间</param>
        /// <param name="webBrowser1">WebBrowser</param>
        /// <returns>wanggong_dianpu</returns>
        public static wanggong_dianpu SearchPage_DianPu(DateTime datenow, WebBrowser webBrowser1)
        {

            Entity.wanggong_dianpu dp = new Entity.wanggong_dianpu();
            int st = GetShopType(webBrowser1);
            //如果是未知店铺类型
            if (st == 0)
            {
                return null;
            }
            try
            {
                string dpname = "";
                string dptbid = "";
                string wangwang = "";

                //如果是普通店铺
                if (st == 3)
                {
                    string isSearchPage = Browser.JS_WebBrowser(" getClassName('tb-shop-name').length;", webBrowser1);
                    //如果是商品列表页面
                    if (isSearchPage == "0")
                    {
                        dpname = Browser.JS_WebBrowser(" getClassName('shop-name')[0].getElementsByTagName('a')[0].innerText; ", webBrowser1);
                        dpname = dpname.Replace("进入店铺", "");
                        dptbid = Browser.JS_WebBrowser(" getClassName('shop-collect')[0].href ", webBrowser1);
                        dptbid = Manager.GetValueByURL(dptbid, "id");
                        wangwang = Browser.JS_WebBrowser(" getClassName('seller-name')[0].innerText; ", webBrowser1);
                        wangwang = wangwang.Replace("掌柜：", "");
                    }
                    else
                    {
                        dpname = Browser.JS_WebBrowser(" getClassName('tb-shop-name')[0].getElementsByTagName('a')[0].title; ", webBrowser1);
                        dptbid = Browser.JS_WebBrowser(" getClassName('tb-booth')[0].getElementsByTagName('a')[0].href; ", webBrowser1);
                        dptbid = Manager.GetValueByURL(dptbid, "shopId");
                        wangwang = Browser.JS_WebBrowser(" getClassName('tb-shop-ww')[0].getElementsByTagName('a')[0].href; ", webBrowser1);
                        wangwang = Manager.GetURLParam(wangwang, "uid");

                    }
                }
                dp.wdcollectdate = datenow;
                dp.wdpname = dpname;
                dp.wdstate = "1";
                dp.wdTBID = dptbid;
                dp.wdwangwang = wangwang;
            }
            catch (Exception ex)
            {
                MessageBox.Show("采集店铺失败：" + ex.Message);
            }
            return dp;

        }

        #endregion


        #endregion

        #region 搜索页面采集信息



        #region SearchPage_GetGoodsUrl
        /// <summary>
        /// 淘宝店铺商品搜索页面-获取商品网址
        /// </summary>
        /// <param name="index">第几个商品</param>
        /// <param name="webBrowser1"></param>
        /// <returns></returns>
        public static string SearchPage_GetGoodsUrl(int index, WebBrowser webBrowser1)
        {
            Browser.jsstr = "   getClassName('photo')[" + index.ToString() + "].getElementsByTagName('a')[0].href;  ";
            return Browser.JS_WebBrowser(webBrowser1);
        }
        #endregion

        #region SearchPage_GetGoodsUrl
        /// <summary>
        /// 淘宝店铺商品搜索页面-获取商品网址
        /// </summary>
        /// <param name="index">第几个商品</param>
        /// <param name="webBrowser1"></param>
        /// <returns></returns>
        public static string SearchPage_GetGoodsUrl(int index, ChromiumWebBrowser webBrowser1)
        {
            Browser.jsstr = "   getClassName('photo')[" + index.ToString() + "].getElementsByTagName('a')[0].href;  ";
            return Browser.JS_CEFBrowser(Browser.jsstr, webBrowser1);
        }
        #endregion

        #region SearchPage_GetImgUrl
        /// <summary>
        /// 淘宝店铺商品搜索页面-获取商品图片网址
        /// </summary>
        /// <param name="index">第几个商品</param>
        /// <param name="webBrowser1"></param>
        /// <returns></returns>
        public static string SearchPage_GetImgUrl(int index, WebBrowser webBrowser1)
        {
            Browser.jsstr = "   getClassName('photo')[" + index.ToString() + "].getElementsByTagName('img')[0].src;  ";
            return Browser.JS_WebBrowser(webBrowser1);
        }
        #endregion

        #region SearchPage_GetTitle
        /// <summary>
        /// 淘宝店铺商品搜索页面-获取商品标题
        /// </summary>
        /// <param name="index">第几个商品</param>
        /// <param name="webBrowser1"></param>
        /// <returns></returns>
        public static string SearchPage_GetTitle(int index, WebBrowser webBrowser1)
        {
            Browser.jsstr = " getClassName('detail')[" + index.ToString() + "].getElementsByTagName('a')[0].innerText;  ";
            return Browser.JS_WebBrowser(webBrowser1);
        }
        #endregion

        #region SearchPage_GetPrice
        /// <summary>
        /// 淘宝店铺商品搜索页面-获取商品价格
        /// </summary>
        /// <param name="index">第几个商品</param>
        /// <param name="webBrowser1"></param>
        /// <returns></returns>
        public static string SearchPage_GetPrice(int index, WebBrowser webBrowser1)
        {
            Browser.jsstr = " getClassName('c-price')[" + index.ToString() + "].innerText;  ";
            return Browser.JS_WebBrowser(webBrowser1);
        }
        #endregion

        #region SearchPage_GetSales
        /// <summary>
        /// 淘宝店铺商品搜索页面-获取商品销量
        /// </summary>
        /// <param name="index">第几个商品</param>
        /// <param name="webBrowser1"></param>
        /// <returns></returns>
        public static string SearchPage_GetSales(int index, WebBrowser webBrowser1)
        {
            Browser.jsstr = " getClassName('sale-num')[" + index.ToString() + "].innerText;  ";
            return Browser.JS_WebBrowser(webBrowser1);
        }
        #endregion

        #region SearchPage_GetTBID
        /// <summary>
        /// 淘宝店铺商品搜索页面-获取商品淘宝ID
        /// </summary>
        /// <param name="index">第几个商品</param>
        /// <param name="webBrowser1"></param>
        /// <returns></returns>
        public static string SearchPage_GetTBID(int index, WebBrowser webBrowser1)
        {
            string id = "";
            Browser.jsstr = " getClassName('photo')[" + index.ToString() + "].getElementsByTagName('a')[0].href;  ";
            string url = Browser.JS_WebBrowser(webBrowser1);
            if (!string.IsNullOrEmpty(url))
                id = Manager.GetValueByURL(url, "id");
            return id;
        }
        #endregion




        #endregion

        //===============================================================================


        #region IsTmall
        /// <summary>
        /// 判断是否是天猫店铺,适用于店铺首页，搜索页，详情页
        /// </summary>
        /// <param name="webBrowser1">WebBrowser</param>
        /// <returns>bool</returns>
        public static bool IsTmall(WebBrowser webBrowser1)
        {

            bool res = false;
            Browser.jsstr = "   getClassName('mlogo').length; ";
            string temp = Browser.JS_WebBrowser(webBrowser1);
            if (temp != "0" && !string.IsNullOrEmpty(temp))
            {
                res = true;
            }
            return res;
        }
        #endregion

        #region IsCompany
        /// <summary>
        /// 判断是否是企业店铺,适用于店铺首页，搜索页，详情页
        /// </summary>
        /// <param name="webBrowser1">WebBrowser</param>
        /// <returns>bool</returns>
        public static bool IsCompany(WebBrowser webBrowser1)
        {
            bool res = false;
            Browser.jsstr = "  getClassName('shop-type').length; ";
            string temp = Browser.JS_WebBrowser(webBrowser1);
            if (temp != "0" && !string.IsNullOrEmpty(temp))
            {
                res = true;
            }
            return res;
        }
        #endregion

        #region IsCommony
        /// <summary>
        /// 判断是否是普通店铺,适用于店铺首页，搜索页，详情页
        /// </summary>
        /// <param name="webBrowser1">WebBrowser</param>
        /// <returns>bool</returns>
        public static bool IsCommony(WebBrowser webBrowser1)
        {
            bool res = false;
            Browser.jsstr = "  getClassName('shop-type').length + getClassName('mlogo').length; ";
            string temp = Browser.JS_WebBrowser(webBrowser1);
            if (temp == "0" && !string.IsNullOrEmpty(temp))
            {
                res = true;
            }
            return res;
        }
        #endregion




        #region 根据网页上的数据截取商品人气值，例如 (73750人气)
        /// <summary>
        /// 根据网页上的数据截取商品人气值，例如 (73750人气)
        /// </summary>
        /// <param name="str">网页上的数据</param>
        /// <returns></returns>
        public static string GetRenQiByStr(string str)
        {
            string temp = str.Replace("(", "");
            temp = str.Replace("人气)", "");
            return temp;
        }
        #endregion

        #region 商品详细页面中 根据ID获取商品图片
        /// <summary>
        /// 商品详细页面中 根据ID获取商品图片
        /// </summary>
        /// <param name="id">五张主图的ul的ID</param>
        /// <param name="index">第几张图片</param>
        /// <param name="webBrowser1">WebBrowser</param>
        /// <returns></returns>
        public static string GetImgById(string id, int index, WebBrowser webBrowser1)
        {
            string str = "";
            Browser.jsstr = "   document.getElementById('" + id + "').getElementsByTagName('li')[" + index + "].getElementsByTagName('img')[0].src;";
            //HtmlElement ele = webBrowser1.Document.CreateElement("script");
            //ele.SetAttribute("type", "text/javascript");
            //string funname = "GetImgById" + BLL2.Manager.RandomNumber(1000, 99999);
            ////如果出问题，就换成getElementsByTagName，因为childNodes不稳定:childNodes.item(" + index + ").innerHTML
            ////string temp = " function " + funname + "(){  return document.getElementById('" + id + "').getElementsByTagName('li')[" + index + "].innerHTML; }";
            //string temp = " function " + funname + "(){  return document.getElementById('" + id + "').getElementsByTagName('li')[" + index + "].getElementsByTagName('img')[0].src; }";
            //ele.SetAttribute("text", temp);
            //webBrowser1.Document.Body.AppendChild(ele);
            //str = webBrowser1.Document.InvokeScript(funname, new object[] { "webbrowser" }).ToString();
            str = Browser.JS_WebBrowser(webBrowser1);
            //Debug.WriteLine("===============================================");
            //Debug.WriteLine(str);
            //string temp1 = GetHtmlImageUrlList(str)[0];
            str = Manager.AddString_Http(str);
            //取消尾部放下载代码 例如：https://gd2.alicdn.com/imgextra/i2/TB1dg.DNVXXXXXrXXXXYXGcGpXX_M2.SS2_50x50.jpg_.webp
            str = str.Replace(".webp", "");
            //Debug.WriteLine("===============================================");
            //Debug.WriteLine(str);
            return str;

        }
        #endregion

        #region 根据淘宝图片URL获取该商品其他尺寸图片
        /// <summary>
        /// 根据淘宝图片URL获取该商品其他尺寸图片
        /// </summary>
        /// <param name="imgurl">商品图片URL</param>
        /// <param name="size">图片尺寸，例如800,店铺搜索240*240,详情页小图50*50</param>
        /// <returns></returns>
        public static string GetImgSizeByUrl(string imgurl, int size)
        {
            //img.alicdn.com/bao/uploaded/i1/1103850205/TB2zoLJdY4npuFjSZFmXXXl4FXa_!!1103850205.jpg_240x240.jpg

            //string s = size.ToString() + "x" + size.ToString();
            //int index1 = imgurl.LastIndexOf("_");
            //int index2 = imgurl.LastIndexOf(".");
            //string str1 = imgurl.Substring(0, index1 + 1);
            //string str2 = imgurl.Substring(index2);
            //return str1 + s + str2;
            //g-search3.alicdn.com/img/bao/uploaded/i4/i2/2586006830/O1CN01lwZkXK20KBeQS7wzY_!!2586006830.jpg_230x230.jpg_.webp
            string res = imgurl.Replace("_.webp", "");
            int index1 = imgurl.LastIndexOf("_");
            //if (index1 != -1)
            //res = imgurl.Substring(0, index1);
            res = res.Replace("_50x50.jpg", "");
            res = res.Replace("_120x120.jpg", "");
            res = res.Replace("_230x230.jpg", "");
            res = res.Replace("_250x250.jpg", "");
            res = res.Replace("_400x400.jpg", "");
            return res;
        }
        #endregion





        //===============================================================================



        #region URL


        #region 根据旺旺得到能够查询店铺网址的页面URL
        /// <summary>
        /// 根据旺旺得到能够查询店铺网址的页面URL
        /// </summary>
        /// <param name="wangwang">旺旺账号</param>
        /// <returns></returns>
        public static string GetShopSearchURL(string wangwang)
        {
            //wangwang = Manager.UrlEncode(wangwang, Encoding.UTF8);
            wangwang = Uri.EscapeDataString(wangwang);

            string temp = "https://shopsearch.taobao.com/search?app=shopsearch&q=" + wangwang + "&imgfile=&js=1&stats_click=search_radio_all%3A1&initiative_id=staobaoz_" + DateTime.Now.ToString("yyyyMMdd") + "&ie=utf8";
            Debug.WriteLine(temp);
            //temp = "https://shopsearch.taobao.com/search?app=shopsearch&q=niuniu%E8%A1%A3&imgfile=&commend=all&ssid=s5-e&search_type=shop&sourceId=tb.index&spm=a21bo.50862.201856-taobao-item.1&ie=utf8&initiative_id=tbindexz_20170101";
            temp = Browser.UrlEncode(temp, System.Text.Encoding.UTF8);
            return temp;
        }
        #endregion

        #region 根据店铺ID获取店铺商品列表页面URL
        /// <summary>
        /// 根据店铺ID获取店铺商品列表页面URL
        /// </summary>
        /// <param name="wangwang">旺旺账号</param>
        /// <param name="pageNo">第几页</param>
        /// <returns></returns>
        public static string GetShopGoodsListURL(string shopid, int pageNo)
        {
            //https://shop129016292.taobao.com/search.htm?spm=a1z10.3-c-s.w5002-14511775976.1.GUsE85&search=y
            //https://miss-dz.taobao.com/search.htm?orderType=hotsell_desc
            string yemian = "&pageNo=" + pageNo.ToString() + "#anchor";
            string temp = "https://shop" + shopid + ".taobao.com/search.htm?spm=a1z10.3-c-s.w5002-14511775976.1.GUsE85&search=y&orderType=hotsell_desc" + yemian;
            return temp;
        }
        #endregion

        #region 根据店铺ID获取店铺商品列表页面URL_新品排序
        /// <summary>
        /// 根据店铺ID获取店铺商品列表页面URL_新品排序
        /// </summary>
        /// <param name="wangwang">旺旺账号</param>
        /// <param name="pageNo">第几页</param>
        /// <returns></returns>
        public static string GetShopGoodsListURL_NewOn(string shopid, int pageNo)
        {
            //https://shop129016292.taobao.com/search.htm?spm=a1z10.3-c-s.w5002-14511775976.1.GUsE85&search=y
            //https://miss-dz.taobao.com/search.htm?orderType=hotsell_desc
            string yemian = "&pageNo=" + pageNo.ToString() + "#anchor";
            string temp = "https://shop" + shopid + ".taobao.com/search.htm?spm=a1z10.3-c-s.w5002-14511775976.1.GUsE85&search=y&orderType=newOn_desc" + yemian;
            return temp;
        }
        #endregion



        #endregion



        #region GetJsByXmlValue发货通用js方法==========================
        /// <summary>
        /// 通用js 方法，获取str
        /// </summary>
        /// <param name="jsname">js方法名称</param>
        /// <returns></returns>
        public static string JsXml(string jsname, ChromiumWebBrowser webBrowser1)
        {
            string js = XMLHelper_FaHuo.GetValue(jsname);
            return Browser.JS_CEFBrowser(js, webBrowser1);
        }
        /// <summary>
        /// 通用js 方法，获取str
        /// </summary>
        /// <param name="jsname">js方法名称</param>
        /// <param name="parameter">参数</param>
        /// <returns></returns>
        public static string JsXml(string jsname, string parameter, ChromiumWebBrowser webBrowser1)
        {
            string js = XMLHelper_FaHuo.GetValue(jsname);
            js = js.Replace("parameter", parameter);
            return Browser.JS_CEFBrowser(js, webBrowser1);
        }
        /// <summary>
        /// 通用js方法，不返回信息
        /// </summary>
        /// <param name="jsname">js方法名称</param>
        public static void JsXml_No(string jsname, ChromiumWebBrowser webBrowser1)
        {
            string js = XMLHelper_FaHuo.GetValue(jsname);
            Browser.JS_CEFBrowser_NoReturn(js, webBrowser1);
        }
        /// <summary>
        /// 通用js方法，不返回信息
        /// </summary>
        /// <param name="jsname">js方法名称</</param>
        /// <param name="parameter">参数</param>
        public static void JsXml_No(string jsname, string parameter, ChromiumWebBrowser webBrowser1)
        {
            string js = XMLHelper_FaHuo.GetValue(jsname);
            js = js.Replace("parameter", parameter);
            Browser.JS_CEFBrowser_NoReturn(js, webBrowser1);
        }
        #endregion



        //============================================================================


        #region 根据Url获取相应字符串HttpWebRequest+string GetStrByUrl(string url)
        /// <summary>
        /// 根据Url获取相应字符串,使用HttpWebRequest
        /// </summary>
        /// <param name="url">网址</param>
        /// <returns>网页html代码</returns>
        private static string GetStrByUrl(string url, string encodeing)
        {
            string str = "";
            Encoding ecd = string.IsNullOrEmpty(encodeing) ? Encoding.Default : Encoding.GetEncoding(encodeing);
            try
            {
                WebRequest request = HttpWebRequest.Create(url);
                WebResponse response = request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(encodeing));
                str = reader.ReadToEnd();
                reader.Close();
                reader.Dispose();
                response.Close();
            }
            catch (Exception ex)
            {
                str = ex.Message;
            }
            return str;
        }
        #endregion


        #region 浏览器根据url打开页面获取页面内容+StringBuilder GetStrByBorwserUrl(string url)
        /// <summary>
        /// 根据浏览器控件打开页面获取页面内容
        /// </summary>
        /// <param name="url"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        private static StringBuilder GetStrByBorwserUrl(string url)
        {
            StringBuilder sbHml = new StringBuilder();
            System.Windows.Forms.WebBrowser browser = new System.Windows.Forms.WebBrowser();
            browser.Navigate(url);
            while (!WaitWebPageLoad(browser))
            {
                WaitWebPageLoad(browser);
            }
            Encoding encoding = Encoding.GetEncoding(browser.Document.Encoding);
            StreamReader stream = new StreamReader(browser.DocumentStream, encoding);
            sbHml.Append(stream.ReadToEnd());
            return sbHml;
        }

        /// <summary>
        /// 延迟系统时间，但系统又能同时能执行其它任务；
        /// </summary>
        /// <param name="Millisecond"></param>
        private static void Delay(int Millisecond) //延迟系统时间，但系统又能同时能执行其它任务；
        {
            DateTime current = DateTime.Now;
            while (current.AddMilliseconds(Millisecond) > DateTime.Now)
            {
                Application.DoEvents();//转让控制权            
            }
            return;
        }

        /// <summary>
        /// 判断页面是否加载完毕
        /// </summary>
        /// <param name="webBrowser1"></param>
        /// <returns></returns>
        private static bool WaitWebPageLoad(WebBrowser webBrowser1)
        {
            int i = 0;
            string sUrl;
            while (true)
            {
                Delay(50);  //系统延迟50毫秒，够少了吧！             
                if (webBrowser1.ReadyState == WebBrowserReadyState.Complete) //先判断是否发生完成事件。
                {
                    if (!webBrowser1.IsBusy) //再判断是浏览器是否繁忙                  
                    {
                        i = i + 1;
                        if (i == 2)
                        {
                            sUrl = webBrowser1.Url.ToString();
                            if (sUrl.Contains("res")) //这是判断没有网络的情况下                           
                            {
                                return false;
                            }
                            else
                            {
                                return true;
                            }
                        }
                        continue;
                    }
                    i = 0;
                }
            }
        }
        #endregion


        #region 保存图片+void Get_img(string url, string saveFileName)
        /// <summary>
        /// 保存图片
        /// </summary>
        /// <returns></returns>
        public static void Get_img(string url, string saveFileName)
        {
            Bitmap img = null;
            HttpWebRequest req;
            HttpWebResponse res = null;
            try
            {
                System.Uri httpUrl = new System.Uri(url);
                req = (HttpWebRequest)(WebRequest.Create(httpUrl));
                req.Timeout = 180000; //设置超时值10秒
                req.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 2.0.50727)"; ;
                req.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";
                req.Method = "GET";
                res = (HttpWebResponse)(req.GetResponse());
                img = new Bitmap(res.GetResponseStream());//获取图片流                
                img.Save(saveFileName, ImageFormat.Jpeg);//随机名
            }

            catch (Exception ex)
            {
                string aa = ex.Message;
            }
            finally
            {
                if (res != null)
                {
                    res.Close();
                }
            }
        }
        #endregion

        #region 根据地址判断是否有网络+bool IsWebResourceAvailable(string webResourceAddress)
        /// <summary>
        /// 根据地址判断是否有网络
        /// </summary>
        /// <param name="webResourceAddress"></param>
        /// <returns></returns>
        public static bool IsWebResourceAvailable(string webResourceAddress)
        {
            if (string.IsNullOrEmpty(webResourceAddress))
            {
                webResourceAddress = "http://www.baidu.com";
            }
            try
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.CreateDefault(new Uri(webResourceAddress));
                req.Method = "HEAD";
                req.Timeout = 1000;
                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                return (res.StatusCode == HttpStatusCode.OK);
            }
            catch (WebException wex)
            {
                System.Diagnostics.Trace.Write(wex.Message);
                return false;
            }
        }
        #endregion


























    }
}
