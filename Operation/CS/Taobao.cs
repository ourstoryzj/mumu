using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace excel_operation.CS
{
    public class Taobao
    {


        #region WaitTaoBaoLogin
        /// <summary>
        /// 判断是否已经完全加载完成,同时添加JS方法【getClassName】
        /// </summary>
        /// <param name="webBrowser1">web浏览器控件</param>
        /// <returns></returns>
        public static bool WaitTaoBaoLogin(Login_TaoBao login)
        {
            while (true)
            {
                Browser.Delay(50);  //系统延迟50毫秒，够少了吧！ 
                if (login.isok || login.IsDisposed)
                {
                    return true;
                }
            }
        }
        #endregion

        #region Login
        /// <summary>
        /// 淘宝登录方法
        /// </summary>
        /// <param name="acc">账号</param>
        /// <param name="pwd">密码</param>
        /// <param name="webBrowser1"></param>
        /// <returns></returns>
        public static bool Login(string account, string pwd, ChromiumWebBrowser webBrowser1)
        {
            try
            {
                string taobao_url = "https://login.taobao.com/member/login.jhtml?f=top&redirectURL=https%3A%2F%2Fwww.taobao.com%2F&style=mini";
                //淘宝登录方法
                webBrowser1.Load(taobao_url);
                if (Browser.WaitWebPageLoad(webBrowser1))
                {
                    if (Browser.WaitWebPageLoad(" document.getElementById('TPL_username_1') ", 2000, webBrowser1))
                    {
                        Auto.Clipboard_In(account);
                        Browser.MouseLeftByHtmlElement(" document.getElementById('TPL_username_1') ", webBrowser1);
                        Auto.Clipboard_Out();

                        Auto.Clipboard_In(pwd);
                        Browser.MouseLeftByHtmlElement(" document.getElementById('TPL_password_1') ", webBrowser1);
                        Auto.Clipboard_Out();

                        Browser.MouseLeftByHtmlElement(" document.getElementById('J_SubmitStatic') ", webBrowser1);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("淘宝登录失败" + ex.ToString());
                return false;
            }
            return true;
        }
        #endregion

        #region PicUrlZuan

        /// <summary>
        /// 淘宝中的图片大小还原
        /// </summary>
        /// <param name="url"></param>
        /// <param name="sizes">如果要800x800则填800即可，不填直接还原</param>
        /// <returns></returns>
        public static string PicUrlZuan(string url, string sizes)
        {
            if (sizes == "800")
            {
                sizes = "800x800";
            }
            else
            {
                sizes = "";
            }
            url = url.Replace("_.webp", "");
            url = url.Replace("_230x230.jpg", sizes);
            url = url.Replace("_180x180.jpg", sizes);
            url = url.Replace("_250x250.jpg", sizes);
            url = url.Replace("_50x50.jpg", sizes);
            url = url.Replace("_150x150.jpg", sizes);
            url = url.Replace("_30x30.jpg", sizes);
            return url;
        }


        #endregion

        #region 进入超级店长
        /// <summary>
        /// 进入超级店长
        /// </summary>
        /// <returns></returns>
        public static bool GoChaoJiDianZhang(ChromiumWebBrowser wb)
        {
            bool res = false;
            //判断是否进入了超级店长
            if (Browser.BoolByHtmlElement(" document.getElementsByClassName('site-nav-item')[0] ", wb))
            {
                return true;
            }
            //如果没有则进入
            wb.Load("https://h5.m.taobao.com/qn/pc/2-03-00/plugin-guide.html?appkey=12011554");
            Browser.Delay(2000);
            if (Browser.WaitWebPageLoad2(" document.getElementsByClassName('site-nav-item')[0] ", wb))
            {
                Browser.Delay(1000);
                res = true;
            }

            #region 在服务中心进入

            //wb.Load("https://fuwu.taobao.com/ser/my_service.htm");
            //if (Browser.WaitWebPageLoad2(" document.getElementsByClassName('service-list-col-container')[0] ", wb))
            //{
            //    Browser.Delay(1000);
            //    //Browser.MouseLeftByHtmlElement(" getElementsByDataID('a1z13.1113649.54321-ddwd.1') ", webBrowser1);
            //    //获取服务数量
            //    string temp = Browser.JS_CEFBrowser("document.getElementsByClassName('service-list-col-container').length", wb);
            //    int fuwu_count = 0;
            //    if (int.TryParse(temp, out fuwu_count))
            //    {
            //        //遍历所有服务找到超级店长
            //        for (int i = 0; i < fuwu_count; i++)
            //        {

            //            string fuwu_name = Browser.JS_CEFBrowser("document.getElementsByClassName('service-list-col-container')[" + i + "].innerText", wb);

            //            if (fuwu_name.IndexOf("超级店长") > -1)
            //            {

            //                wb.Load("https://h5.m.taobao.com/qn/pc/2-03-00/plugin-guide.html?appkey=12011554");

            //                //点击使用
            //                //Browser.MouseLeftByHtmlElement("document.getElementsByClassName('service-list-col-container')[" + i + "].getElementsByTagName('a')[3]", wb);
            //                //Browser.MouseLeftByHtmlElement("document.getElementsByClassName('service-list-col-container')[" + i + "].getElementsByTagName('a')[3]", wb);
            //                Browser.Delay(2000);
            //                if (Browser.WaitWebPageLoad2(" document.getElementsByClassName('site-nav-item')[0] ", wb))
            //                {
            //                    Browser.Delay(1000);
            //                    res = true;
            //                }
            //                break;
            //            }

            //        }
            //    }

            //}
            #endregion

            #region 备份

            //wb.Load("https://home.superboss.cc/index.html#/");

            //if (Browser.WaitWebPageLoad(wb))
            //{
            //    Browser.Delay(2000);
            //    //判断是否进入超级店长
            //    if (Browser.BoolByHtmlElement("document.getElementsByClassName('site-nav-item')[0] ", wb))
            //    {
            //        res = true;
            //    }
            //    else
            //    {
            //        //点击去淘宝登录
            //        Browser.MouseLeftByHtmlElement("document.getElementsByClassName('time-button')[0].click()", wb);


            //    }
            //}
            #endregion

            return res;
        }
        #endregion

        #region GoUrl


        #region 进入买家秀
        /// <summary>
        /// 进入买家秀
        /// </summary>
        /// <param name="cb"></param>
        public static void Go_MaiJiaShow(ChromiumWebBrowser cb)
        {
            cb.Load("https://h5.m.taobao.com/ocean/bg/social-bg.html?page=qianniu");
        }
        #endregion

        #region 进入买家秀
        /// <summary>
        /// 进入生意参谋
        /// </summary>
        /// <param name="cb"></param>
        public static void Go_ShengYiCanMou(ChromiumWebBrowser cb)
        {
            cb.Load("https://sycm.taobao.com/portal/home.htm");
        }
        #endregion

        #region 进入关键词销量排序
        /// <summary>
        /// 进入关键词销量排序
        /// </summary>
        /// <param name="keyname"></param>
        /// <returns></returns>
        public static string Go_Sale_Url(string keyname)
        {
            return "https://s.taobao.com/search?q=" + keyname + "&imgfile=&js=1&stats_click=search_radio_all%3A1&initiative_id=staobaoz_" + DateTime.Now.ToString("yyyyMMdd") + "&ie=utf8&sort=sale-desc";
        }
        #endregion

        #region 获取商品url，根据id
        /// <summary>
        /// 获取商品url，根据id
        /// </summary>
        /// <param name="keyname"></param>
        /// <returns></returns>
        public static string Go_GoodsUrl(string id)
        {
            return "https://item.taobao.com/item.htm?id=" + id + "&ns=1&abbucket=10#detail";
        }
        #endregion




        #endregion

        #region 生意参谋



        #region 判断并等待是否更新词表

        /// <summary>
        /// 获取搜索结果的第一个数据
        /// </summary>
        public static string caijiKeyTemp = "";

        #region 采集第一个关键词,用于判断是否更新,然后再"采集"
        public static string GetKeyByNo1(ChromiumWebBrowser web)
        {
            return Browser.JS_CEFBrowser("document.getElementsByClassName('ant-table-row')[0].getElementsByTagName('td')[0].innerText", web);
        }
        #endregion

        #region DelayUpdateKey
        /// <summary>
        /// 判断是否更新了词表,如果没有更新则等待
        /// </summary>
        /// <param name="web"></param>
        public static void DelayUpdateKey(ChromiumWebBrowser web)
        {
            string nowKey;
            int count = 0;
            do
            {
                nowKey = GetKeyByNo1(web);
                if (nowKey != caijiKeyTemp)
                {
                    break;
                }
                Browser.Delay(500);
                count++;
                //如果循环了20次,则跳出,大概是10秒
                if (count == 20)
                {
                    break;
                }
            } while (1 == 1);
            caijiKeyTemp = nowKey;
        }
        #endregion

        #region DelayUpdateKey2
        /// <summary>
        /// 判断是否更新关键词,判断的是页面最左上角的显示内容
        /// </summary>
        /// <param name="web"></param>
        /// <param name="isRepeat">是否重复操作</param>
        public static void DelayUpdateKey2(ChromiumWebBrowser web, bool isRepeat)
        {
            string nowKey;
            int count = 0;
            do
            {
                nowKey = Browser.JS_CEFBrowser("document.getElementsByClassName('item-keyword')[0].innerText", web);
                if (isRepeat)
                {
                    if (nowKey != caijiKeyTemp)
                    {
                        break;
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(nowKey))
                        break;
                }
                Browser.Delay(500);
                count++;
                //如果循环了20次,则跳出,大概是10秒
                if (count == 20)
                {
                    break;
                }
            } while (1 == 1);
            caijiKeyTemp = nowKey;
        }
        #endregion

        #endregion


        #region 进入市场行情
        /// <summary>
        /// 进入市场行情
        /// </summary>
        /// <param name="cb"></param>
        public static void Go_ShiChangHangQing(ChromiumWebBrowser webBrowser1)
        {
            webBrowser1.Load("https://sycm.taobao.com/mc/mq/market_monitor");
            if (Browser.WaitWebPageLoad("document.getElementsByClassName('op-ebase-leftMenu')[0]", webBrowser1))
            {

            }
        }
        #endregion

        #region 进入市场行情-搜索分析并设置,进入相关分析，如果已经进入了，则跳出方法

        /// <summary>
        /// 返回搜索排行的页面网址,默认是箱包类目的一级类目
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string Go_ShiChangHangQing_SouSuoPaiHang_Url(string id)
        {
            if(string.IsNullOrEmpty(id))
                id = "50012010";
            return "https://sycm.taobao.com/mc/mq/search_rank?activeKey=searchWord&cateFlag=1&cateId=" + id + "&dateRange=" + DateTime.Now.ToString("yyyy-MM-dd") + "%7C" + DateTime.Now.ToString("yyyy-MM-dd") + "&dateType=day&device=0&parentCateId=0&spm=a21ag.11815247.LeftMenu.d1482.196a50a5r98iq2";
        }

        /// <summary>
        /// 进入市场行情-搜索排行,并设置，如果已经进入了，则跳出方法
        /// </summary>
        /// <param name="cb"></param>
        public static void Go_ShiChangHangQing_SouSuoPaiHang(ChromiumWebBrowser webBrowser1)
        {
         
            //获取网址
            string url = webBrowser1.Address;
            if (url.IndexOf("search_rank?activeKey=searchWord") > -1)
            {
                return;
            }
            webBrowser1.Load(Go_ShiChangHangQing_SouSuoPaiHang_Url(""));
            Browser.WaitWebPageLoad(webBrowser1);
               
        }
        #endregion

        #region 进入市场行情-搜索分析并设置,进入相关分析，如果已经进入了，则跳出方法
        /// <summary>
        /// 进入市场行情-搜索分析,并设置，如果已经进入了，则跳出方法
        /// </summary>
        /// <param name="cb"></param>
        public static void Go_ShiChangHangQing_SouSuoFenXi(ChromiumWebBrowser webBrowser1)
        {
            //webBrowser1.Load("https://sycm.taobao.com/mc/mq/market_monitor");
            //if (Browser.WaitWebPageLoad("document.getElementsByClassName('op-ebase-leftMenu')[0]", webBrowser1))
            //{
            //    //点击搜索分析
            //    Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('menuItem ')[7].getElementsByTagName('a')[0].click();",webBrowser1);
            //    //模拟输入关键词
            //    if (Browser.WaitWebPageLoad("document.getElementsByClassName('ant-input ')[0]", webBrowser1))
            //    {
            //        Browser.Delay(1500);
            //    }
            //}
            //如果已经进入了，则跳出方法(关键词输入框)
            //获取网址
            string url = webBrowser1.Address;
            if (url.IndexOf("search_analyze?activeKey") > -1)
            {
                return;
            }
            webBrowser1.Load("https://sycm.taobao.com/mc/mq/search_analyze?activeKey=relation&dateRange=" + DateTime.Now.ToString("yyyy-MM-dd") + "%7C" + DateTime.Now.ToString("yyyy-MM-dd") + "&dateType=day&device=0&keyword=书包女");
            if (Browser.WaitWebPageLoad(webBrowser1))
            {
                //设置展示数据
                Set_SouSuoFenXi_TiaoJian(webBrowser1);
                //查询一次关键词
                Set_SouSuoFenXi_Key(webBrowser1, "书包");
            }
        }
        #endregion

        #region 进入市场行情-搜索分析并设置,进入概括，如果已经进入了，则跳出方法
        /// <summary>
        /// 进入市场行情-搜索分析,并设置，如果已经进入了，则跳出方法
        /// </summary>
        /// <param name="cb"></param>
        public static void Go_ShiChangHangQing_SouSuoFenXi_GaiKuo(ChromiumWebBrowser webBrowser1)
        {

            string url = webBrowser1.Address;
            if (url.IndexOf("search_analyze?activeKey=overview") > -1)
            {
                return;
            }
            webBrowser1.Load("https://sycm.taobao.com/mc/mq/search_analyze?activeKey=overview&dateRange=" + DateTime.Now.ToString("yyyy-MM-dd") + "%7C" + DateTime.Now.ToString("yyyy-MM-dd") + "&dateType=day&device=0&keyword=书包女");
            Browser.WaitWebPageLoad(webBrowser1);

        }
        #endregion

        #region 设置数据条件
        /// <summary>
        /// 搜索分析设置数据条件
        /// </summary>
        /// <param name="webBrowser1"></param>
        public static void Set_SouSuoFenXi_TiaoJian(ChromiumWebBrowser webBrowser1)
        {
            //点击搜索热度
            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('oui-index-picker-text')[1].click()", webBrowser1);
            Browser.Delay(500);
            //点击率
            //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('oui-index-picker-text')[2].click()", webBrowser1);
            //Browser.Delay(500);
            //点击人气
            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('oui-index-picker-text')[3].click()", webBrowser1);
            Browser.Delay(500);
            //电机热度
            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('oui-index-picker-text')[4].click()", webBrowser1);
            Browser.Delay(500);
            //支付转化率
            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('oui-index-picker-text')[6].click()", webBrowser1);
            Browser.Delay(500);
            //在线商品数
            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('oui-index-picker-text')[7].click()", webBrowser1);
            Browser.Delay(500);
            //商城占比
            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('oui-index-picker-text')[8].click()", webBrowser1);
            Browser.Delay(500);
            //直通车参考价
            //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('oui-index-picker-text')[9].click()", webBrowser1);
            //Browser.Delay(500);
            //设置每页显示100条
            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('ant-select-selection__rendered')[1].click()", webBrowser1);
            //Browser.Delay(500);
            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('ant-select-dropdown-menu-item')[4].click()", webBrowser1);
            Browser.Delay(1000);
        }
        #endregion

        #region 设置市场行情中搜索分析关键词
        /// <summary>
        /// 设置市场行情中搜索分析关键词
        /// </summary>
        /// <param name="webBrowser1"></param>
        /// <param name="key"></param>
        public static void Set_SouSuoFenXi_Key(ChromiumWebBrowser webBrowser1, string key)
        {
            webBrowser1.Focus();
            //删除广告
            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('everywhere-widget-container')[0].innerHTML='';", webBrowser1);
            //清空关键词
            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('anticon-close-circle')[0].click()", webBrowser1);
            Browser.MouseLeftByHtmlElement("document.getElementsByClassName('ant-input')[0]", webBrowser1);
            Browser.MouseLeftByHtmlElement("document.getElementsByClassName('ant-input')[0]", webBrowser1);
            Auto.Ctrl_V(key);
            Browser.Delay(500);
            Auto.Key_Enter();
            //Browser.Delay(3000);
            Browser.Delay(1500);
        }
        #endregion


        #region 点击市场行情 搜索人气
        public static void SCHQ_Click_SSRQ(ChromiumWebBrowser web)
        {
            Browser.JS_CEFBrowser("document.getElementsByClassName('oui-index-cell-indexValue oui-num')[0].click();", web);
            Browser.Delay(1000);
        }
        #endregion

        #region 点击市场行情 支付转化率
        public static void SCHQ_Click_ZFZHL(ChromiumWebBrowser web)
        {
            Browser.JS_CEFBrowser("document.getElementsByClassName('oui-index-cell-indexValue oui-num')[6].click();", web);
            Browser.Delay(1000);
        }
        #endregion



        #region 搜索分析 采集数据
        /// <summary>
        /// 采集搜索分析的数据
        /// </summary>
        /// <param name="webBrowser1"></param>
        /// <param name="hid">行业id</param>
        /// <param name="rid">排行榜id</param>
        /// <returns>List<Entity.lh_keydata></returns>
        public static List<Entity.lh_keydata> CaiJi_SouSuoFenXi_Data(ChromiumWebBrowser webBrowser1, int hid, int rid)
        {

            Manager.ClearCache();

            List<Entity.lh_keydata> list = new List<Entity.lh_keydata>();
            //获取关键词页数
            int pageNum = Browser.JS_CEFBrowserToInt("document.getElementsByClassName('ant-pagination-item')[document.getElementsByClassName('ant-pagination-item').length-1].innerText", webBrowser1);
            if (pageNum == 0)
                pageNum = 1;
            //采集5次
            for (int i = 0; i < pageNum; i++)
            {
                //获取行数
                int length = Browser.JS_CEFBrowserToInt("document.getElementsByClassName('ant-table-row').length", webBrowser1);
                //根据行数遍历采集数据
                for (int j = 0; j < length; j++)
                {
                    string name = "";
                    int sousuorenqi = 0;
                    decimal zhifuzhuanhualv = 0;
                    int zaixianshangpinshu = 0;
                    decimal shangchengzhanbi = 0;
                    //改成了点击率
                    decimal zhitongchejiage = 0;

                    //采集数据
                    try
                    {
                        //备用字段
                        string temp = "";
                        //采集关键词名
                        name = _DoStr(Browser.JS_CEFBrowser("document.getElementsByClassName('ant-table-row')[" + j + "].getElementsByTagName('td')[0].innerText", webBrowser1));
                        //采集搜索人气
                        temp = _DoStr(Browser.JS_CEFBrowser("document.getElementsByClassName('ant-table-row')[" + j + "].getElementsByTagName('td')[1].innerText", webBrowser1));
                        int.TryParse(temp, out sousuorenqi);
                        //采集支付传化率,改成采集点击率
                        temp = _DoStr(Browser.JS_CEFBrowser("document.getElementsByClassName('ant-table-row')[" + j + "].getElementsByTagName('td')[2].innerText", webBrowser1));
                        //decimal.TryParse(temp, out zhifuzhuanhualv);
                        decimal.TryParse(temp, out zhitongchejiage);
                        //采集在线商品数,改成采集支付传化率
                        temp = _DoStr(Browser.JS_CEFBrowser("document.getElementsByClassName('ant-table-row')[" + j + "].getElementsByTagName('td')[3].innerText", webBrowser1));
                        //int.TryParse(temp, out zaixianshangpinshu);
                        decimal.TryParse(temp, out zhifuzhuanhualv);
                        //采集商城占比,改成采集在线商品数
                        temp = _DoStr(Browser.JS_CEFBrowser("document.getElementsByClassName('ant-table-row')[" + j + "].getElementsByTagName('td')[4].innerText", webBrowser1));
                        //decimal.TryParse(temp, out shangchengzhanbi);
                        int.TryParse(temp, out zaixianshangpinshu);
                        //采集支付传化率,改成采集商城占比
                        temp = _DoStr(Browser.JS_CEFBrowser("document.getElementsByClassName('ant-table-row')[" + j + "].getElementsByTagName('td')[5].innerText", webBrowser1));
                        //decimal.TryParse(temp, out zhitongchejiage);
                        decimal.TryParse(temp, out shangchengzhanbi);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("错误位置：第" + j + "行。" + ex.ToString());
                    }

                    //封装数据
                    Entity.lh_keydata kd = new Entity.lh_keydata();
                    kd.hid = hid;
                    kd.rid = rid;
                    kd.kdate = DateTime.Now;
                    kd.kname = name;
                    kd.kshangchengzhanbi = shangchengzhanbi;
                    kd.ksousuorenqi = sousuorenqi;
                    kd.kzaixianshangpinshu = zaixianshangpinshu;
                    kd.kzhifuzhuanhualv = zhifuzhuanhualv;
                    kd.kzhitongchejiage = zhitongchejiage;
                    kd.kstate = "1";
                    kd.kjingzheng = 0;
                    if (sousuorenqi != 0 && zaixianshangpinshu != 0)
                        kd.kjingzheng = (Convert.ToDecimal(sousuorenqi) * 1000 / Convert.ToDecimal(zaixianshangpinshu));
                    //保存到List中
                    list.Add(kd);
                }
                //点击下一页
                Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('ant-pagination-next')[0].click();", webBrowser1);

                Browser.Delay(XMLHelper.GetValue("CaijiKeyTime").ToInt());
            }

            return list;
        }

        /// <summary>
        /// 处理采集的字符，过滤不需要的符号
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private static string _DoStr(string str)
        {
            str = str.Replace("\"", "");
            str = str.Replace(",", "");
            str = str.Replace("，", "");
            str = str.Replace("%", "");
            return str;
        }

        #endregion

        #region 搜索排行 采集数据
        /// <summary>
        /// 采集搜索分析的数据
        /// </summary>
        /// <param name="webBrowser1"></param>
        /// <returns>List<lh_rankinglist></returns>
        public static List<Entity.lh_rankinglist> CaiJi_SouSuoPaiHang_Data(ChromiumWebBrowser webBrowser1)
        {
            List<Entity.lh_rankinglist> list = new List<Entity.lh_rankinglist>();
            //获取行数
            int length = Browser.JS_CEFBrowserToInt("document.getElementsByClassName('ant-table-row').length", webBrowser1);
            //根据行数遍历采集数据
            for (int j = 0; j < length; j++)
            {
                string name = "";
                //采集数据
                try
                {
                    //备用字段
                    string temp = "";
                    //采集关键词名
                    name = _DoStr(Browser.JS_CEFBrowser("document.getElementsByClassName('ant-table-row')[" + j + "].getElementsByTagName('td')[0].getElementsByTagName('span')[1].title", webBrowser1));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("错误位置：第" + j + "行。" + ex.ToString());
                }
                //封装数据
                Entity.lh_rankinglist ranking = new Entity.lh_rankinglist();
                ranking.rkey = name;
                //保存到List中
                list.Add(ranking);
            }
            return list;
        }
        #endregion

        #region 根据关键词列表,采集数据CaiJiByStr
        /// <summary>
        /// 根据关键词列表,采集数据CaiJiByStr
        /// </summary>
        /// <param name="list">关键词列表</param>
        /// <param name="hid">行业id</param>
        /// <param name="rid">排行榜id</param>
        /// <param name="webBrowser1"></param>
        /// <returns></returns>
        public static List<Entity.lh_keydata> CaiJiByStr(List<String> list, int hid, int rid, ChromiumWebBrowser webBrowser1)
        {
            List<Entity.lh_keydata> list_res = new List<Entity.lh_keydata>();
            try
            {
                //遍历所有搜索词，采集所有相关词数据
                foreach (string str in list)
                {
                    //把采集的数据追加到集合中
                    list_res.AddRange(Taobao.CaiJi_SouSuoFenXi_Data(webBrowser1, hid, rid));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("采集数据失败3" + ex.ToString());
            }
            return list_res;
        }
        #endregion


        #region 市场行情 搜索分析 曲线图 获取数据 GetKeyData10

        /// <summary>
        /// 市场行情 搜索分析 曲线图 获取数据 获取关键词近10天的数据,模拟不了获取不了值,直接用鼠标移动过去取值---
        /// </summary>
        /// <returns></returns>
        public static  List<decimal> GetKeyData10(ChromiumWebBrowser web)
        {
            
            List<decimal> list = new List<decimal>();
            try
            {
                Browser.Delay(500);
                //设置屏幕居中
                Browser.SetScrollByHtmlElement("document.getElementsByClassName('alife-one-design-sycm-indexes-trend-chart-container')[0]", web);
                Browser.Delay(500);

                //关键词节点的数量
                //int count = Browser.JS_CEFBrowserToInt("document.getElementsByClassName('recharts-cartesian-axis-ticks')[0].getElementsByTagName('g').length", web);
                //改成采集28次
                int count = 28;
                //获取曲线图的尺寸
                int pathMapWidth = Browser.JS_CEFBrowserToInt("document.getElementsByClassName('alife-one-design-sycm-indexes-trend-chart-container')[0].offsetWidth", web);
                int pathMapHeight = Browser.JS_CEFBrowserToInt("document.getElementsByClassName('alife-one-design-sycm-indexes-trend-chart-container')[0].offsetHeight", web);
                //获取曲线图的位置
                Point p = Browser.GetPointScreenByHtmlElement("document.getElementsByClassName('alife-one-design-sycm-indexes-trend-chart-container')[0]", web);
                //思路：点击曲线图的平均分的中心点

                //获取宽度平均分
                int pingjunWidth = pathMapWidth / count;
                //int pingjunHeight = pathMapHeight / 2;
                p.Y = p.Y + (pathMapHeight / 2);

                for (int i = 0; i < (count - 1); i++)
                {

                    #region bak 鼠标移动方法
                    //Browser.MouseMoveByHtmlElement("document.getElementsByClassName('recharts-cartesian-axis-ticks')[0].getElementsByTagName('g')[" + i + "]", 0, 30, webBrowser1);
                    #endregion

                    p.X = p.X + (i == 0 ? (pingjunWidth / 2) : pingjunWidth);

                    Auto.MoveMouseToPoint(p);
                    Browser.Delay(100);
                    decimal temp = Browser.JS_CEFBrowserToDecimal("document.getElementsByClassName('oui-pro-chart-component-tooltip-content-value')[0].innerText", web);
                    list.Add(temp);
                }
            }
            catch {
                return list;
            }

            return list;
        }
        #endregion


        #region 市场行情 搜索分析 曲线图 分析数据 judge_SSRQ

        /// <summary>
        /// 市场行情 搜索分析 曲线图 分析数据 判断搜索人气是否是假词
        /// </summary>
        /// <param name="list_date"></param>
        /// <returns>0:假词 1:待判断的词 2:好词 3:大好词必须做的 </returns>
        public static  int judge_SSRQ(List<decimal> listdate)
        {


            int res = 0;
            //搜索人气思路:
            //以第一个数据为准,如果大部分是高于第一个则是好词,如果是低于第一个则是坏词
            //如果第一个或前几个是0,有数据的第一个为准,如果大部分高于,则是大好词,如果大部分低于第一个则是假词,如果后面还有0的则肯定是假词

            //如果都是都0则直接返回0
            foreach (decimal d in listdate)
            {
                if (d > 0)
                {
                    res = 2;
                    break;
                }
            }
            if (res == 0)
                return 0;

            //判断有数据的,如果不是都是0
            //第一个有数据的,作为标准
            decimal no1 = 0;
            int zhengfuzhi = 0;
            for (int i = 0; i < listdate.Count; i++)
            {
                //第一个有数据的关键词
                if (listdate[i] > 0)
                {
                    //第一个有数据的关键词,作为标准
                    no1 = listdate[i];
                    //判断值,如果大于标准no1则+1,如果小于标准no1则-1
                    int val = 0;
                    //循环后面的数组
                    for (int j = i; j < listdate.Count; j++)
                    {
                        //如果后面还有0的则肯定是假词
                        if (listdate[j] == 0)
                        {
                            return 0;
                        }
                        //如果大部分高于,则是大好词,如果大部分低于第一个则是假词
                        if (listdate[j] >= no1)
                        {
                            zhengfuzhi++;
                        }
                        else
                        {
                            zhengfuzhi--;
                        }
                    }

                    //判断结束
                    //如果正负值大于0,则是好词
                    if (zhengfuzhi > 0)
                    {
                        return 2;
                    }
                    else
                    {
                        //如果正负值小于0,则是待判断的词
                        return 1;
                    }
                }
            }


            return res;
        }
        #endregion

        #region 采集数据,判断关键词是什么词 JudgeKey
        /// <summary>
        /// 采集数据,判断关键词是什么词
        /// </summary>
        /// <param name="zc"></param>
        /// <param name="webBrowser1"></param>
        /// <returns></returns>
        public static Entity.lh_keydata JudgeKey(Entity.lh_keydata zc, ChromiumWebBrowser webBrowser1)
        {
            //显示网页
            //tabControl1.SelectedTab = tp_schq;
            //进入搜索分析
            Taobao.Go_ShiChangHangQing_SouSuoFenXi_GaiKuo(webBrowser1);
            //输入关键词，搜索
            Taobao.Set_SouSuoFenXi_Key(webBrowser1, zc.kname);
            //等待数据更新
            CS.Taobao.DelayUpdateKey2(webBrowser1, false);
            //点击搜索人气
            //TaoBao.SCHQ_Click_SSRQ(webBrowser1);
            CS.Taobao.SCHQ_Click_SSRQ(webBrowser1);

            //支付传化率判断结果
            int res_ZFZHL = 0;


            List<decimal> list_RQ = CS.Taobao.GetKeyData10(webBrowser1);
            //判断10组数字
            int res_RQ = CS.Taobao.judge_SSRQ(list_RQ);

            zc.kremark = "搜索人气：" + list_RQ.ToStringZJ() + ";" + zc.kremark;

            //如果搜索人气没有问题,则查询支付转化率
            if (res_RQ != 0)
            {

                //转化率思路:
                //以第一个数据为准,如果大部分是高于第一个则是好词,如果是低于第一个则是坏词
                //如果第一个或前几个是0,有数据的第一个为准,如果大部分高于,则是大好词,如果后面还有0的则肯定是假词
                //如果都为0则肯定是假词

                //点击支付转化率
                CS.Taobao.SCHQ_Click_ZFZHL(webBrowser1);
                //获取数据
                List<decimal> list_ZFZHL = CS.Taobao.GetKeyData10(webBrowser1);
                //判断数据
                res_ZFZHL = CS.Taobao.judge_SSRQ(list_ZFZHL);
                zc.kremark = "转化率：" + list_ZFZHL.ToStringZJ() + ";" + zc.kremark;


                //如果转化率没有问题,则查询类目
                //if (res_ZFZHL != 0)
                //{
                //    //判断类目
                //    //点击类目构成
                //    Browser.JS_CEFBrowser("document.getElementsByClassName('oui-tab-switch-item')[2].click()", webBrowser1);
                //    Browser.Delay(1000);
                //    //获取类目名称
                //    string leimu = Browser.JS_CEFBrowser("document.getElementsByClassName('oui-tab-switch-item-custom oui-tab-switch-item-custom-active default')[0].getElementsByClassName('title')[0].innerText", webBrowser1);
                //    zc.kremark = "类目：" + leimu + ";" + zc.kremark;
                //}
            }

              

            //点击概括，然后才可以继续判断下一个词
           // Browser.JS_CEFBrowser("document.getElementsByClassName('oui-tab-switch-item')[0].click()", webBrowser1);
            //Browser.Delay(1000);

            //处理结果
            if (res_RQ == 0 || res_ZFZHL == 0)
            {
                zc.kbackup1 = "0";
                zc.kbackup2 = "1";
                zc.kremark = "假词;" + zc.kremark;

            }
            else if (res_RQ == 2 && res_ZFZHL == 2)
            {
                zc.kbackup1 = "2";
                zc.kbackup2 = "0";
                zc.kremark = "大好词;" + zc.kremark;
            }
            else if (res_RQ == 1 || res_ZFZHL == 1)
            {
                zc.kbackup1 = "1";
                zc.kbackup2 = "0";
                zc.kremark = "待检查词;" + zc.kremark;
            }


            BLL2.lh_keydataManager.Update(zc);

            return zc;
        }

        #endregion


        //高度18cm长度21cm底部厚度9cm

        #endregion

        #region 商品发布

        #region GoToPublish 进入商品发布页面


        /// <summary>
        /// 进入商品发布页面
        /// </summary>
        /// <param name="webBrowser1"></param>
        /// <returns></returns>
        public static bool GoToPublish(ChromiumWebBrowser webBrowser1)
        {
            webBrowser1.Load("https://router.publish.taobao.com/router/publish.htm");
            return Browser.WaitWebPageLoad(XMLHelper_TaoBao.GetValue("GetPublishSearchTXT"), webBrowser1);
        }
        #endregion

        #region ToDoPublish_Type 选择商品类目 数字1 = 双肩背包 数字2=女士包袋 数字3=书包（儿童）


        /// <summary>
        /// 选择商品类目 
        /// </summary>
        /// <param name="webBrowser1"></param>
        /// <param name="goodType">数字1 = 双肩背包 数字2=女士包袋 数字3=书包（儿童）</param>
        public static void ToDoPublish_Type(ChromiumWebBrowser webBrowser1, string goodType)
        {
            string gt = "双肩背包";
            if (goodType == "2")
            {
                gt = "女士包袋";
            }
            else if (goodType == "3")
            {
                gt = "书包";
            }
            Browser.MouseLeftByHtmlElement(XMLHelper_TaoBao.GetValue("GetPublishSearchTXT"), webBrowser1);
            Browser.MouseLeftByHtmlElement(XMLHelper_TaoBao.GetValue("GetPublishSearchTXT"), webBrowser1);
            Auto.Ctrl_V(gt);
            Browser.MouseLeftByHtmlElement(XMLHelper_TaoBao.GetValue("GetPublishSearchBtn"), webBrowser1);
            Browser.Delay(1500);
            if (goodType == "3")
                Browser.MouseLeftByHtmlElement(XMLHelper_TaoBao.GetValue("GetPublishSearchTXT"), 10, 120, webBrowser1);
            else
                Browser.MouseLeftByHtmlElement(XMLHelper_TaoBao.GetValue("GetPublishSearchTXT"), 10, 50, webBrowser1);
            Browser.Delay(2000);
            Browser.MouseLeftByHtmlElement(XMLHelper_TaoBao.GetValue("GetPublishGoodsBtn"), webBrowser1);
            Browser.WaitWebPageLoad(XMLHelper_TaoBao.GetValue("GetPublish_GoodsType"), webBrowser1);
        }
        #endregion


        static int Wait_UpNew = 500;


        #region 设置-宝贝类型:全新
        /// <summary>
        /// 设置-宝贝类型:全新
        /// </summary>
        /// <returns></returns>
        public static void SetShangPinLeiXing(ChromiumWebBrowser webBrowser1)
        {
            Browser.Delay(Wait_UpNew);
            //点击“双肩背包”类目
            Browser.JS_CEFBrowser_NoReturn(XMLHelper_TaoBao.GetValue("GetPublish_GoodsType") + ".click(); ", webBrowser1);
        }
        #endregion

        #region 设置-货号:时间
        /// <summary>
        /// 设置-货号:时间
        /// </summary>
        /// <returns></returns>
        public static void SetHuoHao(ChromiumWebBrowser webBrowser1)
        {
            Browser.Delay(Wait_UpNew);
            //货号
            string huohao = "ZZD" + DateTime.Now.ToString("MMdd");//+ Manager.RandomNumber(1, 9).ToString();
            Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('sell-catProp-item-input')[0].getElementsByTagName('input')[0].value='" + huohao + "' ", webBrowser1);
            //点击“双肩背包”类目
            //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('next-radio')[0].click(); ", webBrowser1);
        }
        #endregion

        #region 设置-大小:中
        /// <summary>
        /// 设置-大小:中
        /// </summary>
        /// <returns></returns>
        public static void SetDaXiao(ChromiumWebBrowser webBrowser1)
        {
            Browser.Delay(Wait_UpNew);
            Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('sell-catProp-item-select')[1].click(); ", webBrowser1);
            Browser.Delay(Wait_UpNew);
            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('options-item')[0].click(); ", webBrowser1);
        }
        #endregion

        #region 设置-电脑尺寸:8英寸
        /// <summary>
        /// 设置-电脑尺寸:8英寸
        /// </summary>
        /// <returns></returns>
        public static void SetDianNaoChiCun(ChromiumWebBrowser webBrowser1)
        {
            Browser.Delay(Wait_UpNew);
            Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('sell-catProp-item-select')[2].click(); ", webBrowser1);
            Browser.Delay(Wait_UpNew);
            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('options-item')[0].click(); ", webBrowser1);
        }
        #endregion

        #region 设置-缓冲棉:否
        /// <summary>
        /// 设置-缓冲棉:否
        /// </summary>
        /// <returns></returns>
        public static void SetHuanChongMian(ChromiumWebBrowser webBrowser1)
        {
            Browser.Delay(Wait_UpNew);
            Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('sell-catProp-item-select')[3].click(); ", webBrowser1);
            Browser.Delay(Wait_UpNew);
            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('options-item')[0].click(); ", webBrowser1);
        }
        #endregion

        #region 设置-适用对象:少年
        /// <summary>
        /// 设置-适用对象:少年
        /// </summary>
        /// <returns></returns>
        public static void SetShiYongDuiXiang(ChromiumWebBrowser webBrowser1)
        {
            Browser.Delay(Wait_UpNew);
            Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('sell-catProp-item-select')[4].click(); ", webBrowser1);
            Browser.Delay(Wait_UpNew);
            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('options-item')[4].click(); ", webBrowser1);
        }
        #endregion

        #region 设置-防水程度：防泼水
        /// <summary>
        /// 设置-防水程度：防泼水
        /// </summary>
        /// <returns></returns>
        public static void SetFangShui(ChromiumWebBrowser webBrowser1)
        {
            Browser.Delay(Wait_UpNew);
            Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('sell-catProp-item-select')[5].click(); ", webBrowser1);
            Browser.Delay(Wait_UpNew);
            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('options-item')[2].click(); ", webBrowser1);
        }
        #endregion

        #region 设置-性别：女
        /// <summary>
        /// 设置-性别：女
        /// </summary>
        /// <returns></returns>
        public static void SetXingBie(ChromiumWebBrowser webBrowser1)
        {
            Browser.Delay(Wait_UpNew);
            Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('sell-catProp-item-select')[6].click(); ", webBrowser1);
            Browser.Delay(Wait_UpNew);
            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('options-item')[1].click(); ", webBrowser1);
        }
        #endregion

        #region 设置-提拎部件类型：软把
        /// <summary>
        /// 设置-提拎部件类型：软把
        /// </summary>
        /// <returns></returns>
        public static void SetTiLin(ChromiumWebBrowser webBrowser1)
        {
            Browser.Delay(Wait_UpNew);
            Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('sell-catProp-item-select')[8].click(); ", webBrowser1);
            Browser.Delay(Wait_UpNew);
            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('options-item')[1].click(); ", webBrowser1);
        }
        #endregion

        #region 设置-闭合方式：拉链
        /// <summary>
        /// 设置-闭合方式：拉链
        /// </summary>
        /// <returns></returns>
        public static void SetBiHe(ChromiumWebBrowser webBrowser1)
        {
            Browser.Delay(Wait_UpNew);
            Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('sell-catProp-item-select')[9].click(); ", webBrowser1);
            Browser.Delay(Wait_UpNew);
            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('options-item')[0].click(); ", webBrowser1);
        }
        #endregion

        #region 设置-内部结构：拉链暗袋，手机袋，证件袋
        /// <summary>
        /// 设置-内部结构：拉链暗袋，手机袋，证件袋
        /// </summary>
        /// <returns></returns>
        public static void SetNeiBuJieGou(ChromiumWebBrowser webBrowser1)
        {
            Browser.Delay(Wait_UpNew);
            Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('next-btn-normal')[0].click(); ", webBrowser1);
            Browser.Delay(Wait_UpNew);
            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('sell-o-custom-base-checkbox')[0].getElementsByClassName('next-checkbox')[1].click(); ", webBrowser1);
            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('sell-o-custom-base-checkbox')[0].getElementsByClassName('next-checkbox')[2].click(); ", webBrowser1);
            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('sell-o-custom-base-checkbox')[0].getElementsByClassName('next-checkbox')[3].click(); ", webBrowser1);
            Browser.Delay(Wait_UpNew);
            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('checkbox-content')[0].getElementsByClassName('next-btn')[2].click(); ", webBrowser1);

        }
        #endregion

        #region 设置-箱包外袋种类:内贴袋
        /// <summary>
        /// 设置-箱包外袋种类:内贴袋
        /// </summary>
        /// <returns></returns>
        public static void SetWaiDaiZhongLei(ChromiumWebBrowser webBrowser1)
        {
            Browser.Delay(Wait_UpNew);
            Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('sell-catProp-item-select')[10].click(); ", webBrowser1);
            Browser.Delay(Wait_UpNew);
            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('options-item')[1].click(); ", webBrowser1);
        }
        #endregion

        #region 设置-流行元素:车缝线
        /// <summary>
        /// 设置-流行元素:车缝线
        /// </summary>
        /// <returns></returns>
        public static void SetLiuXingYuanSu(ChromiumWebBrowser webBrowser1)
        {
            Browser.Delay(Wait_UpNew);
            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('next-comobobox-arrow-wrapper')[0].click(); ", webBrowser1);
            Browser.Delay(Wait_UpNew);
            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('options-item')[12].click(); ", webBrowser1);
        }
        #endregion

        #region 设置-图案:纯色
        /// <summary>
        /// 设置-图案:纯色
        /// </summary>
        /// <returns></returns>
        public static void SetTuAn(ChromiumWebBrowser webBrowser1)
        {
            Browser.Delay(Wait_UpNew);
            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('next-comobobox-arrow-wrapper')[1].click(); ", webBrowser1);
            Browser.Delay(Wait_UpNew);
            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('options-item')[0].click(); ", webBrowser1);
        }
        #endregion

        #region 设置-有无夹层:无
        /// <summary>
        /// 设置-有无夹层:无
        /// </summary>
        /// <returns></returns>
        public static void SetJiaCeng(ChromiumWebBrowser webBrowser1)
        {
            Browser.Delay(Wait_UpNew);
            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('sell-catProp-item-select')[13].click(); ", webBrowser1);
            Browser.Delay(Wait_UpNew);
            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('options-item')[1].click(); ", webBrowser1);
        }
        #endregion

        #region 设置-箱包硬度:软
        /// <summary>
        /// 设置-箱包硬度:软
        /// </summary>
        /// <returns></returns>
        public static void SetYingDu(ChromiumWebBrowser webBrowser1)
        {
            Browser.Delay(Wait_UpNew);
            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('sell-catProp-item-select')[14].click(); ", webBrowser1);
            Browser.Delay(Wait_UpNew);
            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('options-item')[0].click(); ", webBrowser1);
        }
        #endregion

        #region 设置-可折叠：否
        /// <summary>
        /// 设置-可折叠：否 
        /// </summary>
        /// <returns></returns>
        public static void SetZheDie(ChromiumWebBrowser webBrowser1)
        {
            Browser.Delay(Wait_UpNew);
            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('sell-catProp-item-select')[15].click(); ", webBrowser1);
            Browser.Delay(Wait_UpNew);
            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('options-item')[1].click(); ", webBrowser1);
        }
        #endregion

        #region 设置-成色：全新
        /// <summary>
        /// 设置-成色：全新
        /// </summary>
        /// <returns></returns>
        public static void SetChengSe(ChromiumWebBrowser webBrowser1)
        {
            Browser.Delay(Wait_UpNew);
            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('sell-catProp-item-select')[16].click(); ", webBrowser1);
            Browser.Delay(Wait_UpNew);
            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('options-item')[0].click(); ", webBrowser1);
        }
        #endregion

        #region 设置-场景：休闲
        /// <summary>
        /// 设置-场景：休闲
        /// </summary>
        /// <returns></returns>
        public static void SetChangJing(ChromiumWebBrowser webBrowser1)
        {
            Browser.Delay(Wait_UpNew);
            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('sell-catProp-item-select')[17].click(); ", webBrowser1);
            Browser.Delay(Wait_UpNew);
            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('options-item')[1].click(); ", webBrowser1);
        }
        #endregion

        #region 设置-风格：日韩
        /// <summary>
        /// 设置-风格：日韩
        /// </summary>
        /// <returns></returns>
        public static void SetFengGe(ChromiumWebBrowser webBrowser1)
        {
            Browser.Delay(Wait_UpNew);
            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('sell-catProp-item-select')[18].click(); ", webBrowser1);
            Browser.Delay(Wait_UpNew);
            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('options-item')[1].click(); ", webBrowser1);
        }
        #endregion

        #region 设置-形状:竖款方形
        /// <summary>
        /// 设置-形状:竖款方形
        /// </summary>
        /// <returns></returns>
        public static void SetXingZhuang(ChromiumWebBrowser webBrowser1)
        {
            Browser.Delay(Wait_UpNew);
            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('next-comobobox-arrow-wrapper')[2].click(); ", webBrowser1);
            Browser.Delay(Wait_UpNew);
            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('options-item')[13].click(); ", webBrowser1);
        }
        #endregion

        #region 设置-肩带样式：双根
        /// <summary>
        /// 设置-肩带样式：双根
        /// </summary>
        /// <returns></returns>
        public static void SetJianDaiYangShi(ChromiumWebBrowser webBrowser1)
        {
            Browser.Delay(Wait_UpNew);
            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('sell-catProp-item-select')[20].click(); ", webBrowser1);
            Browser.Delay(Wait_UpNew);
            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('options-item')[1].click(); ", webBrowser1);
        }
        #endregion

        #region 设置-里料：涤棉
        /// <summary>
        /// 设置-里料：涤棉
        /// </summary>
        /// <returns></returns>
        public static void SetLiLiao(ChromiumWebBrowser webBrowser1)
        {
            Browser.Delay(Wait_UpNew);
            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('next-comobobox-arrow-wrapper')[3].click(); ", webBrowser1);
            Browser.Delay(Wait_UpNew);
            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('options-item')[7].click(); ", webBrowser1);
        }
        #endregion

        #region 设置-质地：PU
        /// <summary>
        /// 设置-质地：PU；材质工艺：软面
        /// </summary>
        /// <returns></returns>
        public static void SetZhiDi(ChromiumWebBrowser webBrowser1)
        {
            Browser.Delay(Wait_UpNew);
            Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('sell-catProp-item-select')[7].click(); ", webBrowser1);
            Browser.Delay(1200);
            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('options-item')[1].click(); ", webBrowser1);
            Browser.Delay(2000);
            Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('sell-catProp-item-select')[8].click(); ", webBrowser1);
            Browser.Delay(1200);
            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('options-item')[4].click(); ", webBrowser1);
        }
        #endregion

        #region 设置-品牌：其他
        /// <summary>
        /// 设置-品牌：其他
        /// </summary>
        /// <returns></returns>
        public static void SetPinPai(ChromiumWebBrowser webBrowser1)
        {
            Browser.Delay(Wait_UpNew);
            webBrowser1.Focus();
            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('sell-catProp-item-select')[0].click(); ", webBrowser1);
            Browser.Delay(1200);
            Browser.MouseLeftByHtmlElement("document.getElementsByClassName('options-search')[0].getElementsByTagName('input')[0]", webBrowser1);
            Auto.Ctrl_V("其他");
            Browser.Delay(1200);
            //Browser.MouseLeftByHtmlElement("document.getElementsByClassName('options-search')[0].getElementsByTagName('input')[0]", webBrowser1);
            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('options-item')[0].click(); ", webBrowser1);
        }
        #endregion

        #region 设置-双肩包
        /// <summary>
        /// 设置-双肩包
        /// </summary>
        /// <returns></returns>
        public static void SetShuangJian(ChromiumWebBrowser webBrowser1)
        {
            SetShangPinLeiXing(webBrowser1);
            SetHuoHao(webBrowser1);
            SetDaXiao(webBrowser1);
            SetDianNaoChiCun(webBrowser1);
            SetHuanChongMian(webBrowser1);
            SetShiYongDuiXiang(webBrowser1);
            SetFangShui(webBrowser1);
            SetXingBie(webBrowser1);
            SetTiLin(webBrowser1);
            SetBiHe(webBrowser1);
            SetNeiBuJieGou(webBrowser1);
            SetWaiDaiZhongLei(webBrowser1);
            SetLiuXingYuanSu(webBrowser1);
            SetTuAn(webBrowser1);
            SetJiaCeng(webBrowser1);
            SetYingDu(webBrowser1);
            SetZheDie(webBrowser1);
            SetChengSe(webBrowser1);
            SetChangJing(webBrowser1);
            SetFengGe(webBrowser1);
            SetXingZhuang(webBrowser1);
            SetJianDaiYangShi(webBrowser1);
            SetLiLiao(webBrowser1);
            SetZhiDi(webBrowser1);
            SetPinPai(webBrowser1);


        }
        #endregion



        #region 设置-下拉菜单
        /// <summary>
        /// 设置-下拉菜单
        /// </summary>
        /// <returns></returns>
        public static void SetSelect(int onenum, int twonum, ChromiumWebBrowser webBrowser1)
        {
            Browser.Delay(Wait_UpNew);
            Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('sell-catProp-item-select')[" + onenum.ToString() + "].click(); ", webBrowser1);
            Browser.Delay(Wait_UpNew);
            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('options-item')[" + twonum.ToString() + "].click(); ", webBrowser1);
        }
        #endregion

        #region 设置-下拉菜单——可输入的
        /// <summary>
        /// 设置-下拉菜单——可输入的
        /// </summary>
        /// <returns></returns>
        public static void SetSelectInput(int onenum, int twonum, ChromiumWebBrowser webBrowser1)
        {
            Browser.Delay(Wait_UpNew);
            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('next-comobobox-arrow-wrapper')[" + onenum.ToString() + "].click(); ", webBrowser1);
            Browser.Delay(Wait_UpNew);
            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('options-item')[" + twonum.ToString() + "].click(); ", webBrowser1);
        }
        #endregion


        #region 设置-女包
        /// <summary>
        /// 设置-女包
        /// </summary>
        /// <returns></returns>
        public static void SetNvBao(ChromiumWebBrowser webBrowser1)
        {
            SetShangPinLeiXing(webBrowser1);
            //设置货号
            SetHuoHao(webBrowser1);
            //大小
            SetSelect(1, 2, webBrowser1);
            //流行款式
            SetSelect(2, 6, webBrowser1);
            //适用对象
            SetSelect(3, 5, webBrowser1);
            //提拎部件类型:
            SetSelect(6, 2, webBrowser1);
            //闭合方式:
            SetSelect(7, 2, webBrowser1);
            //箱包外袋种类:
            SetSelect(8, 1, webBrowser1);
            //流行元素:
            SetSelectInput(0, 13, webBrowser1);
            //图案:
            SetSelectInput(1, 0, webBrowser1);
            //有无夹层:
            SetSelect(11, 1, webBrowser1);
            //箱包硬度:
            SetSelect(12, 0, webBrowser1);
            //是否可折叠:
            SetSelect(13, 1, webBrowser1);
            //是否可折叠:
            SetSelect(14, 0, webBrowser1);
            //适用场景:
            SetSelect(15, 0, webBrowser1);
            //风格:
            SetSelect(16, 1, webBrowser1);
            //形状:
            SetSelectInput(2, 13, webBrowser1);
            //肩带样式:
            SetSelect(18, 0, webBrowser1);
            //里料材质:
            SetSelectInput(3, 6, webBrowser1);

            //款式:
            SetSelect(4, 0, webBrowser1);
            //背包方式:
            SetSelect(5, 3, webBrowser1);
            //质地:
            SetSelect(6, 2, webBrowser1);
            //材质工艺:
            SetSelect(7, 9, webBrowser1);

            //设置结构
            SetNeiBuJieGou(webBrowser1);
            //设置品牌
            SetPinPai(webBrowser1);
        }
        #endregion

        #region 设置-儿童包
        /// <summary>
        /// 设置-儿童包
        /// </summary>
        /// <returns></returns>
        public static void SetErTongBao(ChromiumWebBrowser webBrowser1)
        {
            SetShangPinLeiXing(webBrowser1);
            //设置货号
            SetHuoHao(webBrowser1);
            //图案
            SetSelect(1, 18, webBrowser1);
            //是否有导购视频
            SetSelect(2, 1, webBrowser1);



            //设置结构
            Browser.Delay(Wait_UpNew);
            Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('next-btn-normal')[0].click(); ", webBrowser1);
            Browser.Delay(Wait_UpNew);
            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('select-all')[0].click(); ", webBrowser1);
            Browser.Delay(Wait_UpNew);
            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('checkbox-content')[0].getElementsByClassName('next-btn')[2].click(); ", webBrowser1);

            //设置品牌
            SetPinPai(webBrowser1);
        }
        #endregion


        #endregion

        #region 下载商品图片

        /// <summary>
        /// 下载淘宝店铺商品图片
        /// </summary>
        /// <param name="saveurl"></param>
        /// <param name="weburl"></param>
        /// <param name="webBrowser1"></param>
        /// <returns></returns>
        public static string DownLoadImg_TaoBao(string saveurl, string weburl, ChromiumWebBrowser webBrowser1, bool download_pc = true)
        {
            string path = "";
            if (weburl.IndexOf("taobao") > -1)
            {
               
                #region 淘宝处理
                //webBrowser1.Load(weburl);
                //检测主图
                if (Browser.WaitWebPageLoad2("document.getElementById('J_UlThumb')", webBrowser1))
                {
                    //截图
                    //ImageClass.bmp_backup = ImageClass.GetScreen(webBrowser1);
                    //移动到最下面
                    Browser.ScrollToBottom(webBrowser1);
                    try
                    {
                        //获取宝贝标题
                        string babyname = Browser.JS_CEFBrowser("document.getElementsByClassName('tb-main-title')[0].innerText", webBrowser1);
                        //网供名称
                        string wgname = Browser.JS_CEFBrowser("document.getElementsByClassName('tb-shop-name')[0].innerText", webBrowser1);
                        //宝贝价格
                        string babyprice = Browser.JS_CEFBrowser("document.getElementsByClassName('tb-rmb-num')[0].innerText", webBrowser1);
                        wgname = wgname.Replace("\n", "");
                        babyname = babyname.Replace("\n", "");
                        babyprice = babyprice.Replace("\n", "");
                        wgname = wgname.Replace("\\", "");
                        babyname = babyname.Replace("\\", "");
                        babyprice = babyprice.Replace("\\", "");
                        wgname = wgname.Replace("/", "");
                        babyname = babyname.Replace("/", "");
                        babyprice = babyprice.Replace("/", "");

                        //文件名
                        string filename = wgname + "_" + babyname + "_" + babyprice;
                        filename = filename.Replace(" ", "");
                        //主图存放位置
                        path = saveurl + "\\" + filename;
                        Manager.CreateDirectory(path);

                        //下载主图
                        int zhutulength = Browser.JS_CEFBrowserToInt("document.getElementById('J_UlThumb').getElementsByTagName('li').length", webBrowser1);
                        for (int i = 0; i < zhutulength; i++)
                        {
                            string imgurl = Browser.JS_CEFBrowser("document.getElementById('J_UlThumb').getElementsByTagName('img')[" + i.ToString() + "].src", webBrowser1);
                            imgurl = CS.Taobao.PicUrlZuan(imgurl, "");
                            string imgname = i.ToString() + filename + ".png";
                            
                            //采集图片
                            imgurl.ToImageSave(path + "\\" + imgname);
                        }
                        //创建快捷方式
                        //ShortcutCreator.CreateShortcut(saveurl, filename, weburl, null, null);


                        //SKU图存放位置
                        Manager.CreateDirectory(path + "\\SKU");
                        //下载SKU图片
                        int skulength = Browser.JS_CEFBrowserToInt("document.getElementsByClassName('J_TSaleProp')[0].getElementsByTagName('li').length", webBrowser1);
                        for (int i = 0; i < skulength; i++)
                        {
                            string imgurl = Browser.JS_CEFBrowser("document.getElementsByClassName('J_TSaleProp')[0].getElementsByTagName('a')[" + i.ToString() + "].style.backgroundImage", webBrowser1);
                            imgurl = imgurl.Replace("url(\"", "");
                            imgurl = imgurl.Replace("\")", "");
                            imgurl = CS.Taobao.PicUrlZuan(imgurl, "");
                            imgurl = "https:" + imgurl;
                            imgurl = imgurl.Replace("gd2", "img");
                            imgurl = imgurl.Replace("gd1", "img");
                            imgurl = imgurl.Replace("gd3", "img");
                            imgurl = imgurl.Replace("gd4", "img");

                            string imgname = filename+ "_" + Browser.JS_CEFBrowser("document.getElementsByClassName('J_TSaleProp')[0].getElementsByTagName('span')[" + i.ToString() + "].innerText", webBrowser1) + ".png";
                            imgurl.ToImageSave(path + "\\SKU\\" + imgname);
                        }

                        //详情图存放位置
                        Manager.CreateDirectory(path + "\\详情图");
                        //下载详情图片
                        if (download_pc)
                        {
                            Browser.ScrollToTop(webBrowser1);
                            webBrowser1.ToBottom(500,30,800);
                            int xiangqinglength = Browser.JS_CEFBrowserToInt("document.getElementsByClassName('content')[0].getElementsByTagName('img').length", webBrowser1);
                            for (int i = 0; i < xiangqinglength; i++)
                            {
                                string imgurl = Browser.JS_CEFBrowser("document.getElementsByClassName('content')[0].getElementsByTagName('img')[" + i.ToString() + "].src", webBrowser1);
                                imgurl = CS.Taobao.PicUrlZuan(imgurl, "");

                                string imgname = i.ToString() + filename + ".png";
                                imgurl.ToImageSave(path + "\\详情图\\" + imgname);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                }
                #endregion
            }
            return path;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="saveurl"></param>
        /// <param name="weburl"></param>
        /// <param name="webBrowser1"></param>
        /// <returns></returns>
        public static string DownLoadImg_Tmall(string saveurl, string weburl, ChromiumWebBrowser webBrowser1, bool download_pc = true)
        {
            string path = "";
            if (weburl.IndexOf("tmall") > -1)
            {
                #region 天猫处理
                //检测主图
                if (Browser.WaitWebPageLoad2("document.getElementById('J_UlThumb')", webBrowser1))
                {
                    //移动到最下面
                    Browser.ScrollToBottom(webBrowser1);
                    try
                    {
                        //获取宝贝标题
                        string babyname = Browser.JS_CEFBrowser("document.getElementsByClassName('tb-detail-hd')[0].getElementsByTagName('h1')[0].innerText", webBrowser1);
                        //店铺名称
                        string wgname = Browser.JS_CEFBrowser("document.getElementsByClassName('slogo-shopname')[0].innerText", webBrowser1);
                        //宝贝价格
                        string babyprice = Browser.JS_CEFBrowser("document.getElementsByClassName('tm-price')[1].innerText", webBrowser1);
                        wgname = wgname.Replace("\n", "");
                        babyname = babyname.Replace("\n", "");
                        babyprice = babyprice.Replace("\n", "");
                        wgname = wgname.Replace("\\", "");
                        babyname = babyname.Replace("\\", "");
                        babyprice = babyprice.Replace("\\", "");
                        wgname = wgname.Replace("/", "");
                        babyname = babyname.Replace("/", "");
                        babyprice = babyprice.Replace("/", "");

                        //文件名
                        string filename = wgname + "_" + babyname + "_" + babyprice;
                        filename = filename.Replace(" ", "");

                        //主图存放位置
                        path = saveurl + "\\" + filename;
                        Manager.CreateDirectory(path);
                        //下载主图
                        int zhutulength = Browser.JS_CEFBrowserToInt("document.getElementById('J_UlThumb').getElementsByTagName('li').length", webBrowser1);
                        for (int i = 0; i < zhutulength; i++)
                        {
                            string imgurl = Browser.JS_CEFBrowser("document.getElementById('J_UlThumb').getElementsByTagName('img')[" + i.ToString() + "].src", webBrowser1);
                            imgurl = CS.Taobao.PicUrlZuan(imgurl, "");
                            string imgname = i.ToString() + filename + ".png";
                            //采集图片
                            imgurl.ToImageSave(path + "\\" + imgname);
                        }
                        //创建快捷方式
                        //ShortcutCreator.CreateShortcut(path, filename, weburl, null, null);


                        //SKU图存放位置
                        Manager.CreateDirectory(path + "\\SKU");
                        //下载SKU图片
                        int skulength = Browser.JS_CEFBrowserToInt("document.getElementsByClassName('J_TSaleProp')[0].getElementsByTagName('li').length", webBrowser1);
                        for (int i = 0; i < skulength; i++)
                        {
                            string imgurl = Browser.JS_CEFBrowser("document.getElementsByClassName('J_TSaleProp')[0].getElementsByTagName('a')[" + i.ToString() + "].style.backgroundImage", webBrowser1);
                            imgurl = imgurl.Replace("url(\"", "");
                            imgurl = imgurl.Replace("\")", "");
                            imgurl = CS.Taobao.PicUrlZuan(imgurl, "");
                            imgurl = "https:" + imgurl;
                            imgurl = imgurl.Replace("gd2", "img");
                            imgurl = imgurl.Replace("gd1", "img");
                            imgurl = imgurl.Replace("gd3", "img");
                            imgurl = imgurl.Replace("gd4", "img");

                            string imgname = Browser.JS_CEFBrowser("document.getElementsByClassName('J_TSaleProp')[0].getElementsByTagName('span')[" + i.ToString() + "].innerText", webBrowser1) + "_" + filename + ".png";

                            imgurl.ToImageSave(path + "\\SKU\\" + imgname);
                        }

                        //详情图存放位置
                        Manager.CreateDirectory(path + "\\详情图");
                        //下载详情图片
                        if (download_pc)
                        {
                            Browser.ScrollToTop(webBrowser1);
                            webBrowser1.ToBottom(500, 30, 800);
                            int xiangqinglength = Browser.JS_CEFBrowserToInt("document.getElementsByClassName('content')[0].getElementsByTagName('img').length", webBrowser1);
                            for (int i = 0; i < xiangqinglength; i++)
                            {
                                string imgurl = Browser.JS_CEFBrowser("document.getElementsByClassName('content')[0].getElementsByTagName('img')[" + i.ToString() + "].src", webBrowser1);
                                //因为天猫的详情页夹杂着很多无用图片,所以过滤一下
                                if (imgurl.IndexOf("img.alicdn.com") > -1)
                                {
                                    imgurl = CS.Taobao.PicUrlZuan(imgurl, "");
                                    string imgname = i.ToString() + filename + ".png";
                                    imgurl.ToImageSave(path + "\\详情图\\" + imgname);
                                }
                                
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                }
                #endregion
            }
            return path;

        }

        //区分平台下载商品图片
        public static string DownLoadGoodsImg(string temp_save, string weburl, ChromiumWebBrowser webBrowser1)
        {
            string path_temp = "";
            if (weburl.IndexOf("yangkeduo") > -1)
            {
                path_temp = CS.PinDuoDuo.DownloadImg(temp_save, weburl, webBrowser1);
            }
            else if (weburl.IndexOf("taobao") > -1)
            {
                path_temp = CS.Taobao.DownLoadImg_TaoBao(temp_save, weburl, webBrowser1);
            }
            else if (weburl.IndexOf("tmall") > -1)
            {
                //天猫
                path_temp = CS.Taobao.DownLoadImg_Tmall(temp_save, weburl, webBrowser1);
            }
            else if (weburl.IndexOf("1688") > -1)
            {
                //1688
            }
            else if (weburl.IndexOf("bao66") > -1)
            {
                //包牛牛
                path_temp = CS.BaoNiuNiu.DownloadImg(temp_save, weburl, webBrowser1);
            }
            return path_temp;
        }

        #endregion

        #region CaijiGoodsNumByKey


        public static int CaijiGoodsNumByKey(string key)
        {
            int res = 0;
            WebBrowser wb = new WebBrowser();
            return res;

        }
        #endregion

    }
}
