using CefSharp.WinForms;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Web;
using Common;

namespace Operation.CS
{
    public class PinDuoDuo
    {




        #region Login
        /// <summary>
        /// 拼多多登录方法
        /// </summary>
        /// <param name="acc">账号</param>
        /// <param name="pwd">密码</param>
        /// <param name="webBrowser1"></param>
        /// <returns></returns>
        public static bool Login(string account, string pwd, ChromiumWebBrowser webBrowser1)
        {
            try
            {
                string taobao_url = "https://mms.pinduoduo.com/login/";
                //拼多多登录方法
                webBrowser1.Load(taobao_url);
                webBrowser1.Focus();
                if (Browser.WaitWebPageLoad(" document.getElementsByClassName('tab-operate')[0] ", 2000, webBrowser1))
                {

                    //去掉全部样式
                    //document.getElementsByClassName('login-center')[0].setAttribute('class','')
                    Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('login-center')[0].setAttribute('class','')", webBrowser1);
                    //删除图片
                    //document.getElementsByClassName('login-content')[0].getElementsByTagName('img')[0].src=''
                    Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('login-content')[0].getElementsByTagName('img')[0].src=''", webBrowser1);
                    //删除二维码广告
                    //var child_div1 = document.getElementsByClassName('info-footer-btn')[0]; child_div1.parentNode.removeChild(child_div1);
                    Browser.JS_CEFBrowser_NoReturn("var child_div1 = document.getElementsByClassName('info-footer-btn')[0]; child_div1.parentNode.removeChild(child_div1);", webBrowser1);
                    //点击账号密码登录
                    //document.getElementsByClassName('tab-operate')[0].getElementsByTagName('div')[1].click()
                    Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('tab-operate')[0].getElementsByTagName('div')[1].click()", webBrowser1);
                    //设置账号密码
                    //

                    //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('login-info-section')[0].setAttribute('class','')", webBrowser1);
                    //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('login-content')[0].setAttribute('class','')", webBrowser1);
                    //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('tab-operate')[0].getElementsByTagName('div')[1].click()", webBrowser1);

                    //Browser.MouseLeftByHtmlElement("document.getElementsByClassName('tab-operate')[0].getElementsByTagName('div')[1]", webBrowser1);

                    Browser.Delay(500);


                    Browser.MouseLeftByHtmlElement("document.getElementById('usernameId')", 10, 10, webBrowser1);
                    Auto.Ctrl_V(account);


                    Browser.MouseLeftByHtmlElement("document.getElementById('passwordId')", 10, 10, webBrowser1);
                    Auto.Ctrl_V(pwd);

                    //document.getElementsByClassName('info-content')[0].getElementsByTagName('button')[0]
                    Browser.MouseLeftByHtmlElement("document.getElementsByClassName('info-content')[0].getElementsByTagName('button')[0]", 10, 10, webBrowser1);
                    //Browser.MouseLeftByHtmlElement("document.getElementsByClassName('mui-input')[2]", 10, 10, webBrowser1);

                    //Browser.MouseMoveByHtmlElement("document.getElementsByClassName('mui-button')[1]", 10, 10, webBrowser1);

                    //Browser.JS_CEFBrowser_NoReturn("document.getElementById('usernameId').value='" + account + "'", webBrowser1);
                    //Browser.JS_CEFBrowser_NoReturn("document.getElementById('passwordId').value='" + pwd + "'", webBrowser1);

                    //Browser.MouseLeftByHtmlElement("document.getElementsByClassName('mui-input')[2]",webBrowser1);

                    //Browser.MouseLeftByHtmlElement("document.getElementById('passwordId')", 70, -70, webBrowser1);
                    ////设置可登陆按钮
                    //Browser.JS_CEFBrowser_NoReturn("document.getElementById('loginBtnId').setAttribute('data-click','true')  ", webBrowser1);
                    //Browser.JS_CEFBrowser_NoReturn("document.getElementById('loginBtnId').setAttribute('class','pdd-btn l-c-c-c-btn')  ", webBrowser1);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine("拼多多登录失败" + ex.ToString());
                return false;
            }
            return true;

            #region 备用



            //try
            //{
            //    string taobao_url = "http://mms.yangkeduo.com/Pdd.html#/index";
            //    //淘宝登录方法
            //    webBrowser1.Load(taobao_url);

            //    if (Browser.WaitWebPageLoad(" document.getElementById('usernameId') ", 2000, webBrowser1))
            //    {

            //        Browser.JS_CEFBrowser_NoReturn("document.getElementById('usernameId').value='" + account + "'", webBrowser1);
            //        Browser.JS_CEFBrowser_NoReturn("document.getElementById('passwordId').value='" + pwd + "'", webBrowser1);

            //        Browser.MouseLeftByHtmlElement("document.getElementById('passwordId')", 70, -180, webBrowser1);
            //        //设置可登陆按钮
            //        Browser.JS_CEFBrowser_NoReturn("document.getElementById('loginBtnId').setAttribute('data-click','true')  ", webBrowser1);
            //        Browser.JS_CEFBrowser_NoReturn("document.getElementById('loginBtnId').setAttribute('class','pdd-btn l-c-c-c-btn')  ", webBrowser1);
            //    }

            //}
            //catch (Exception ex)
            //{
            //    Debug.WriteLine("拼多多登录失败" + ex.ToString());
            //    return false;
            //}
            //return true;
            #endregion


        }
        #endregion

        #region Login
        /// <summary>
        /// 拼多多登录客服方法
        /// </summary>
        /// <param name="acc">账号</param>
        /// <param name="pwd">密码</param>
        /// <param name="webBrowser1"></param>
        /// <returns></returns>
        public static bool LoginKeFu(string account, string pwd, ChromiumWebBrowser webBrowser1)
        {
            try
            {
                string taobao_url = "https://mms.pinduoduo.com/login/";
                //拼多多登录方法
                webBrowser1.Load(taobao_url);
                webBrowser1.Focus();
                if (Browser.WaitWebPageLoad(" document.getElementsByClassName('tab-operate')[0] ", 2000, webBrowser1))
                {

                    //去掉全部样式
                    //document.getElementsByClassName('login-center')[0].setAttribute('class','')
                    Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('login-center')[0].setAttribute('class','')", webBrowser1);
                    //删除图片
                    //document.getElementsByClassName('login-content')[0].getElementsByTagName('img')[0].src=''
                    Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('login-content')[0].getElementsByTagName('img')[0].src=''", webBrowser1);
                    //删除二维码广告
                    //var child_div1 = document.getElementsByClassName('info-footer-btn')[0]; child_div1.parentNode.removeChild(child_div1);
                    Browser.JS_CEFBrowser_NoReturn("var child_div1 = document.getElementsByClassName('info-footer-btn')[0]; child_div1.parentNode.removeChild(child_div1);", webBrowser1);
                    //点击账号密码登录
                    //document.getElementsByClassName('tab-operate')[0].getElementsByTagName('div')[1].click()
                    Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('tab-operate')[0].getElementsByTagName('div')[1].click()", webBrowser1);
                    //设置账号密码
                    Browser.Delay(500);
                    Browser.MouseLeftByHtmlElement("document.getElementById('usernameId')", 10, 10, webBrowser1);
                    Auto.Ctrl_V(account);
                    Browser.MouseLeftByHtmlElement("document.getElementById('passwordId')", 10, 10, webBrowser1);
                    Auto.Ctrl_V(pwd);
                    //点击登录后台
                    Browser.MouseLeftByHtmlElement("document.getElementsByClassName('info-content')[0].getElementsByTagName('button')[0]", 10, 10, webBrowser1);
                    Browser.Delay(5000);
                    //if (!Browser.ElementIsNull("document.getElementsByClassName('verify-phone-container')[0].getElementsByTagName('input')[1]", webBrowser1))
                    //{
                    //    //有验证码
                    //    return false;
                    //}
                    if (Browser.WaitWebPageLoadByElement("document.getElementsByClassName('user-info-top')[0]", webBrowser1, 30000))
                    {
                        //登陆客服
                        webBrowser1.Load("https://mms.pinduoduo.com/assets/chat-merchant/dist/index.html?r=0.5309851365977418");
                        if (Browser.WaitWebPageLoad(XMLHelper_PDD.GetValue("client_shopid"), webBrowser1))
                        {
                            Browser.Delay(10000);
                            //Browser.JS_CEFBrowser_NoReturn("alert('开始关闭广告')", webBrowser1);
                            //取消对话框提示框
                            ClearAP(webBrowser1);
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine("拼多多登录失败" + ex.ToString());
                return false;
            }
            return true;

        }
        #endregion

        #region 清除客服广告

        /// <summary>
        /// 清除客服广告
        /// </summary>
        /// <param name="webBrowser1"></param>
        public static void ClearAP(ChromiumWebBrowser webBrowser1)
        {
            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('modal')[0].remove();", webBrowser1);
            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('content-list-item-msg')[0].remove();", webBrowser1);
            //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('v-modal')[0].parentElement.removeChild(document.getElementsByClassName('v-modal')[0])",webBrowser1);
            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('v-modal')[0].remove();", webBrowser1);
            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('fullscreen-dialog-manager')[0].remove();", webBrowser1);
        }
        #endregion

        #region 空包网



        #region Login_kongbao
        /// <summary>
        /// 拼多多登录方法
        /// </summary>
        /// <param name="acc">账号</param>
        /// <param name="pwd">密码</param>
        /// <param name="webBrowser1"></param>
        /// <returns></returns>
        public static bool Login_kongbao(string account, string pwd, ChromiumWebBrowser webBrowser1)
        {
            try
            {
                string taobao_url = "http://uu453.com.uu249.com:8888/Member/DanHaoSearch.aspx";
                //拼多多登录方法
                webBrowser1.Load(taobao_url);
                webBrowser1.Focus();
                if (Browser.WaitWebPageLoad(" document.getElementById('MainC_tbuserName') ", 2000, webBrowser1))
                {



                    //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('login-info-section')[0].setAttribute('class','')", webBrowser1);
                    //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('login-content')[0].setAttribute('class','')", webBrowser1);
                    //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('tab-operate')[0].getElementsByTagName('div')[1].click()", webBrowser1);

                    //Browser.MouseLeftByHtmlElement("document.getElementsByClassName('tab-operate')[0].getElementsByTagName('div')[1]", webBrowser1);

                    //Browser.Delay(500);


                    //Browser.MouseLeftByHtmlElement("document.getElementById('usernameId')", webBrowser1);
                    //Auto.Ctrl_V(account);


                    //Browser.MouseLeftByHtmlElement("document.getElementById('passwordId')", webBrowser1);
                    //Auto.Ctrl_V(pwd);


                    //Browser.MouseLeftByHtmlElement("document.getElementsByClassName('mui-input')[2]", webBrowser1);

                    //Browser.MouseMoveByHtmlElement("document.getElementsByClassName('mui-button')[1]", webBrowser1);

                    Browser.JS_CEFBrowser_NoReturn("document.getElementById('MainC_tbuserName').value='" + account + "'", webBrowser1);
                    Browser.JS_CEFBrowser_NoReturn("document.getElementById('MainC_Tbpwd').value='" + pwd + "'", webBrowser1);

                    //Browser.MouseLeftByHtmlElement("document.getElementsByClassName('mui-input')[2]",webBrowser1);

                    //Browser.MouseLeftByHtmlElement("document.getElementById('passwordId')", 70, -70, webBrowser1);
                    ////设置可登陆按钮
                    Browser.JS_CEFBrowser_NoReturn("document.getElementById('MainC_btnLogin').click() ", webBrowser1);
                    //Browser.JS_CEFBrowser_NoReturn("document.getElementById('loginBtnId').setAttribute('class','pdd-btn l-c-c-c-btn')  ", webBrowser1);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine("拼多多登录失败" + ex.ToString());
                return false;
            }
            return true;




        }
        #endregion

        #region Login_kongbao_12345pt
        /// <summary>
        /// 拼多多登录方法
        /// </summary>
        /// <param name="acc">账号</param>
        /// <param name="pwd">密码</param>
        /// <param name="webBrowser1"></param>
        /// <returns></returns>
        public static bool Login_kongbao_12345pt(string account, string pwd, ChromiumWebBrowser webBrowser1)
        {
            try
            {
                string taobao_url = "http://pg.315kb.wang/Login/";
                //拼多多登录方法
                webBrowser1.Load(taobao_url);
                webBrowser1.Focus();
                if (Browser.WaitWebPageLoad(" document.getElementById('userName') ", 2000, webBrowser1))
                {



                    //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('login-info-section')[0].setAttribute('class','')", webBrowser1);
                    //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('login-content')[0].setAttribute('class','')", webBrowser1);
                    //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('tab-operate')[0].getElementsByTagName('div')[1].click()", webBrowser1);

                    //Browser.MouseLeftByHtmlElement("document.getElementsByClassName('tab-operate')[0].getElementsByTagName('div')[1]", webBrowser1);

                    //Browser.Delay(500);


                    //Browser.MouseLeftByHtmlElement("document.getElementById('usernameId')", webBrowser1);
                    //Auto.Ctrl_V(account);


                    //Browser.MouseLeftByHtmlElement("document.getElementById('passwordId')", webBrowser1);
                    //Auto.Ctrl_V(pwd);


                    //Browser.MouseLeftByHtmlElement("document.getElementsByClassName('mui-input')[2]", webBrowser1);

                    //Browser.MouseMoveByHtmlElement("document.getElementsByClassName('mui-button')[1]", webBrowser1);

                    Browser.JS_CEFBrowser_NoReturn("document.getElementById('userName').value='" + account + "'", webBrowser1);
                    Browser.JS_CEFBrowser_NoReturn("document.getElementById('password').value='" + pwd + "'", webBrowser1);

                    //Browser.MouseLeftByHtmlElement("document.getElementsByClassName('mui-input')[2]",webBrowser1);

                    //Browser.MouseLeftByHtmlElement("document.getElementById('passwordId')", 70, -70, webBrowser1);
                    ////设置可登陆按钮
                    Browser.JS_CEFBrowser_NoReturn("document.getElementById('loginSubmit').click() ", webBrowser1);
                    //Browser.JS_CEFBrowser_NoReturn("document.getElementById('loginBtnId').setAttribute('class','pdd-btn l-c-c-c-btn')  ", webBrowser1);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine("空包网12345pt登录失败" + ex.ToString());
                return false;
            }
            return true;




        }
        #endregion

        #endregion

        #region GoDaiFaHuo
        /// <summary>
        /// 进入代发货
        /// </summary>
        /// <param name="webBrowser1"></param>
        public static void GoDaiFaHuo(ChromiumWebBrowser webBrowser1)
        {
            webBrowser1.Load("http://mms.pinduoduo.com/order.html#/orders/search/index?type=0");
        }
        #endregion

        #region GoOrderInfo
        /// <summary>
        /// 根据订单编号查看订单详情
        /// </summary>
        /// <param name="code"></param>
        /// <param name="webBrowser1"></param>
        public static void GoOrderInfo(string code, ChromiumWebBrowser webBrowser1)
        {
            webBrowser1.Load("https://www.baidu.com/");
            Browser.Delay(500);
            webBrowser1.Load(" http://mms.pinduoduo.com/order.html#/orders/order_detail/index?type=0&sn=" + code);
            //Browser.Delay(500);
            if (Browser.WaitWebPageLoad(XMLHelper_FaHuo.GetValue("PDDElementPhone"), 5000, webBrowser1))
            {

            }
        }
        #endregion

        #region getYanZhengMa
        /// <summary>
        /// 根据手机短信提取验证码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetYanZhengMa(string str)
        {

            //string y = txt_yanzhengma.Text.Trim();
            //string[] temp = y.Split('，');
            //if (temp.Length > 1)
            //{
            //    string yy = temp[0];
            //    temp = yy.Split('：');
            //    if (temp.Length > 1)
            //    {
            //        string res = temp[1];
            //        Auto.Clipboard_In(res);
            //        //MessageBox.Show(res);
            //        Browser.JS_CEFBrowser_NoReturn("document.getElementsByName('telcode')[0].value=" + res, webBrowser2);
            //        Browser.MouseLeftByHtmlElement("document.getElementsByClassName('sub')[0]", webBrowser2);
            //        //MSG&15158&17184515693&【拼多多】您的验证码是632588。请于5分钟内完成验证，若非本人操作，请忽略本短信。[End]﻿
            //    }
            //}

            string res = "";
            if (!string.IsNullOrEmpty(str))
            {
                str = str.Replace("，", ",");
                str = str.Replace("：", ":");
                str = str.Replace("。", ".");
                res = WebService.SubString(str, "您的验证码是", ".请于5分钟");
                //res = res.Replace("，", "");
                res = res.Replace(",", "");
            }
            return res;
        }
        #endregion

        #region 网页处理功能





        /// <summary>
        /// 获取订单数量
        /// </summary>
        /// <returns></returns>
        public static int GetOrderCount_Pdd(ChromiumWebBrowser webBrowser2)
        {
            return Browser.JS_CEFBrowserToInt("document.getElementsByClassName('o-o-t-l-c-list').length", webBrowser2);
        }

        /// <summary>
        /// 获取订单信息
        /// </summary>
        /// <returns></returns>
        public static string GetSearchRes_Pdd(ChromiumWebBrowser webBrowser2)
        {
            return Browser.JS_CEFBrowser("document.getElementsByClassName('o-o-t-l-c-list')[0].innerText", webBrowser2);
        }

        /// <summary>
        /// 等待查询结束-拼多多
        /// </summary>
        public static void SearchOver_Pdd(ChromiumWebBrowser webBrowser2)
        {


            //判断是否查询结束
            while (true)
            {
                Browser.Delay(5000);//系统延迟50毫秒，够少了吧！
                int searchcount = GetOrderCount_Pdd(webBrowser2);
                //找到订单了
                if (searchcount > 1)
                {
                    break;
                }
                //获取显示结果
                string temp = GetSearchRes_Pdd(webBrowser2);
                //没有查询到符合要求的订单数据
                if (temp.IndexOf("没有查询到") > -1)
                {
                    break;
                }

            }

        }

        /// <summary>
        /// 获取一行的订单编号
        /// </summary>
        /// <param name="indexx"></param>
        /// <returns></returns>
        public static string GetOrderCode_PDD(int indexx, ChromiumWebBrowser webBrowser2)
        {
            string info = Browser.JS_CEFBrowser("document.getElementsByClassName('o-o-t-l-c-list')[" + indexx.ToString() + "].getElementsByTagName('li')[0].innerText", webBrowser2);
            info = info.Replace("订单编号：", "");
            return info;
        }

        /// <summary>
        /// 点击查看手机
        /// </summary>
        public static void ClickLookPhone_PDD(ChromiumWebBrowser webBrowser2)
        {
            Browser.Delay(1000);
            CaiJi.JsXml_No("PDDClickPhone", webBrowser2);
            //Browser.JS_CEFBrowser_NoReturn(CaiJi.GetJsByXmlValue("PDDClickPhone"), webBrowser2);
            Browser.Delay(1000);
        }

        /// <summary>
        /// 获取收件人姓名
        /// </summary>
        public static string GetOrderName_PDD(ChromiumWebBrowser webBrowser2)
        {
            string name = Browser.JS_CEFBrowser("document.getElementsByClassName('o-d-b-i-c-people')[0].getElementsByTagName('span')[1].innerText", webBrowser2);
            //章香梅 13980739962
            try
            {
                name = Manager.Str_Split(name, " ")[0];
            }
            catch { }
            return name;
        }

        /// <summary>
        /// 获取收件人电话
        /// </summary>
        public static string GetOrderPhone_PDD(ChromiumWebBrowser webBrowser2)
        {
            string phone = Browser.JS_CEFBrowser("document.getElementsByClassName('o-d-b-i-c-people')[0].getElementsByTagName('span')[1].innerText", webBrowser2);
            //章香梅 13980739962
            try
            {
                phone = Manager.Str_Split(phone, " ")[1];
            }
            catch { }
            return phone;
            //return Browser.JS_CEFBrowser("document.getElementsByClassName('o-d-b-i-c-people')[0].getElementsByTagName('span')[2].innerText", webBrowser2);
        }

        /// <summary>
        /// 获取收件人收件地址
        /// </summary>
        public static string GetOrderAddress_PDD(ChromiumWebBrowser webBrowser2)
        {
            return Browser.JS_CEFBrowser(" document.getElementsByClassName('o-d-b-i-c-address')[0].getElementsByTagName('span')[1].innerText", webBrowser2);
        }

        /// <summary>
        /// 获取商品名称
        /// </summary>
        public static string GetGoodsName_PDD(ChromiumWebBrowser webBrowser2)
        {
            return Browser.JS_CEFBrowser(" document.getElementsByClassName('pdd-dui-table')[0].getElementsByTagName('td')[1].innerText", webBrowser2);
        }

        /// <summary>
        /// 获取商品SKU
        /// </summary>
        public static string GetGoodsSKU_PDD(ChromiumWebBrowser webBrowser2)
        {
            return Browser.JS_CEFBrowser("document.getElementsByClassName('pdd-dui-table')[0].getElementsByTagName('td')[2].innerText", webBrowser2);
        }
        /// <summary>
        /// 获取商品件数
        /// </summary>
        public static string GetGoodsCount_PDD(ChromiumWebBrowser webBrowser2)
        {
            return Browser.JS_CEFBrowser("document.getElementsByClassName('pdd-dui-table')[0].getElementsByTagName('td')[4].innerText", webBrowser2);
        }

        /// <summary>
        /// 采集列表页的商品名称
        /// </summary>
        /// <returns></returns>
        public static string GetListGoodsName(int indexx, ChromiumWebBrowser webBrowser2)
        {
            string info = Browser.JS_CEFBrowser("document.getElementsByClassName('o-o-t-l-c-list')[" + indexx.ToString() + "].getElementsByClassName('o-o-t-l-c-l-tr-two')[0].getElementsByTagName('p')[0].innerText", webBrowser2);
            return info;
        }
        /// <summary>
        /// 采集列表页的SKU
        /// </summary>
        /// <returns></returns>
        public static string GetListSKU(int indexx, ChromiumWebBrowser webBrowser2)
        {
            string info = Browser.JS_CEFBrowser("document.getElementsByClassName('o-o-t-l-c-list')[" + indexx.ToString() + "].getElementsByClassName('o-o-t-l-c-l-tr-two')[0].getElementsByTagName('p')[1].innerText", webBrowser2);
            return info;
        }
        /// <summary>
        /// 采集列表页的订单的订购数量
        /// </summary>
        /// <returns></returns>
        public static string GetListNum(int indexx, ChromiumWebBrowser webBrowser2)
        {
            string info = Browser.JS_CEFBrowser("document.getElementsByClassName('o-o-t-l-c-list')[" + indexx.ToString() + "].getElementsByTagName('td')[5].innerText", webBrowser2);
            return info;
        }




        #endregion

        #region DownloadImg
        /// <summary>
        /// 下载拼多多图片，返回图片保存位置
        /// </summary>
        /// <param name="saveurl">保存的网址</param>
        /// <param name="weburl">网址</param>
        /// <param name="webBrowser1">浏览器</param>
        public static string DownloadImg(string saveurl, string weburl, ChromiumWebBrowser webBrowser1)
        {
            string path = "";
            if (weburl.IndexOf("yangkeduo") > -1)
            {
                //webBrowser1.Load(weburl);
                //如果有就是拼多多的页面
                if (Browser.WaitWebPageLoad("document.getElementsByClassName('enable-select')[0]", webBrowser1))
                {
                    //截图
                    //ImageClass.bmp_backup = ImageClass.GetScreen(webBrowser1);

                    #region 拼多多下载
                    //移动到最下面
                    Browser.ScrollToBottom(webBrowser1);

                    //获取宝贝标题
                    string babyname = Browser.JS_CEFBrowser("document.getElementsByClassName('enable-select')[0].innerText", webBrowser1);
                    //网供名称
                    string wgname = Browser.JS_CEFBrowser("getElementsByInnerText2('商品数量')[0].parentElement.parentElement.getElementsByTagName('div')[0].innerText", webBrowser1);
                    //宝贝价格
                    string babyprice = Browser.JS_CEFBrowser("getElementsByInnerText('￥')[0].parentElement.innerText.replace('起','')", webBrowser1);
                    wgname = wgname.Replace("\n", "");
                    //文件名
                    string filename = babyprice + "_" + babyname + "_" + wgname;
                    filename = filename.Replace(" ", "");
                    //下载主图
                    //获取主图src
                    string imgurl = Browser.JS_CEFBrowser("document.getElementsByClassName('islider-outer')[0].getElementsByTagName('li')[1].getElementsByTagName('img')[0].src", webBrowser1);
                    string imgname = "主图.jpg";
                    path = saveurl + "\\" + filename + "\\";
                    Manager.DownloadFile(imgurl, path, imgname, 5000);
                    //获取商品描述并写道文件里
                    string goodsshow = Browser.JS_CEFBrowser("getElementsByInnerText2('商品详情')[0].parentElement.getElementsByTagName('div')[getElementsByInnerText2('商品详情')[0].parentElement.getElementsByTagName('div').length-1].innerText", webBrowser1);
                    StreamWriter sw = Manager.CreateFile(path, filename + ".txt");
                    sw.WriteLine(goodsshow);
                    sw.Close();

                    //创建快捷方式
                    ShortcutCreator.CreateShortcut(path, filename, weburl, null, null);

                    //下载详情图片

                    //移动到最下面
                    Browser.ScrollToBottom(200, 100, webBrowser1);
                    //Browser.ScrollToTop(10, webBrowser1);
                    //Browser.ScrollToBottom(10, webBrowser1);
                    Browser.Delay(3000);
                    int xiangqinglength = Browser.JS_CEFBrowserToInt("document.getElementsByClassName('goods-details-attr')[0].parentElement.getElementsByTagName('img').length", webBrowser1);
                    for (int i = 0; i < xiangqinglength; i++)
                    {
                        imgurl = Browser.JS_CEFBrowser("document.getElementsByClassName('goods-details-attr')[0].parentElement.getElementsByTagName('img')[" + i.ToString() + "].src", webBrowser1);
                        imgurl = CS.Taobao.PicUrlZuan(imgurl, "");
                        imgname = i.ToString() + filename + ".jpg";
                        path = saveurl + "\\" + filename + "\\详情图";

                        Manager.DownloadFile(imgurl, path, imgname, 5000);
                    }

                    #endregion

                }
            }
            return path;

        }
        #endregion

        #region DownloadImgByWebBrowser
        /// <summary>
        /// 下载拼多多图片，返回图片保存位置
        /// </summary>
        /// <param name="saveurl">保存的网址</param>
        /// <param name="weburl">网址</param>
        /// <param name="webBrowser1">浏览器</param>
        public static string DownloadImgByWebBrowser(string saveurl, string weburl, ChromiumWebBrowser webBrowser1)
        {
            string filename = "";
            string path = "";
            if (weburl.IndexOf("yangkeduo") > -1)
            {
                //如果有就是拼多多的页面
                if (webBrowser1.ToWait("document.getElementsByClassName('enable-select')[0]"))
                {
                    //移动到最下面
                    webBrowser1.ToBottom(500, 30, 800);

                    //开始采集拼多多的图片
                    //获取宝贝标题
                    string babyname = webBrowser1.ToJs("document.getElementsByClassName('enable-select')[0].innerText");
                    //网供名称
                    string wgname = webBrowser1.ToJs("getElementsByInnerText2('商品数量')[0].parentElement.parentElement.getElementsByTagName('div')[0].innerText");
                    //宝贝价格
                    string babyprice = webBrowser1.ToJs("getElementsByInnerText('￥')[0].parentElement.innerText.replace('起','')");
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
                    filename = babyprice + "_" + babyname + "_" + wgname;
                    filename = filename.Replace(" ", "");
                    path = saveurl + "\\" + filename + "\\";
                    Manager.CreateDirectory(path);
                    //-------------------------------------------------
                    //下载主图
                    //获取主图src
                    string imgurl = webBrowser1.ToJs("document.getElementsByClassName('islider-outer')[0].getElementsByTagName('li')[1].getElementsByTagName('img')[0].src");
                    string imgname = "主图.jpg";
                    //Manager.DownloadFile(imgurl, path, imgname, 5000);
                    //换方法
                    //string temp = "document.getElementsByClassName('islider-outer')[0].getElementsByTagName('li')[1].getElementsByTagName('img')[0]";
                    //webBrowser1.ToShowElement(temp);
                    //采集图片
                    Image img_zhu = imgurl.ToImageByWebBrowser();
                    if (img_zhu != null)
                    {
                        img_zhu.ToChangeMD5().Save(path + "\\" + imgname);
                    }

                    //-------------------------------------------------
                    //获取商品描述并写道文件里
                    string goodsshow = webBrowser1.ToJs("getElementsByInnerText2('商品详情')[0].parentElement.getElementsByTagName('div')[getElementsByInnerText2('商品详情')[0].parentElement.getElementsByTagName('div').length-1].innerText");
                    goodsshow.ToSave(path, filename);
                    //-------------------------------------------------

                    //开始下载详情图
                    path = saveurl + "\\" + filename + "\\详情图";
                    //创建文件夹
                    Manager.CreateDirectory(path);

                    //获取图片的数量
                    int count = webBrowser1.ToJsInt("getElementsByInnerText2('商品详情')[0].parentElement.getElementsByTagName('img').length");
                    //获取图片的位置,让鼠标移动到上面
                    for (int i = 0; i < count; i++)
                    {
                        imgurl = webBrowser1.ToJs("getElementsByInnerText2('商品详情')[0].parentElement.getElementsByTagName('img')[" + i.ToString() + "].src");
                        imgurl = CS.Taobao.PicUrlZuan(imgurl, "");
                        imgname = i.ToString() + filename + ".jpg";
                        //采集图片
                        Image img = imgurl.ToImageByWebBrowser();
                        if (img != null)
                        {
                            img.ToChangeMD5().Save(path + "\\" + imgname);
                        }
                    }
                }
                else
                {
                    "没有进入到拼多多商品页面".ToShow();
                }
            }
            return saveurl + "\\" + filename;

        }
        #endregion

        #region GetOrderIDByURL
        /// <summary>
        /// 根据订单支付宝支付网址获取订单编号
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string GetOrderIDByURL(string url)
        {
            string temp = Manager.GetValueByURL(url, "return_url");
            temp = HttpUtility.UrlDecode(temp, System.Text.Encoding.ASCII);
            //return Manager.GetValueByURL(url, "subject").Replace("%E8%AE%A2%E5%8D%95%E7%BC%96%E5%8F%B7", ""); ;
            temp = Manager.GetValueByURL(temp, "order_sn");
            return temp;
        }

        #endregion


        /// <summary>
        /// 解析地址并补全信息
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetALLAddressByStr(string str)
        {
            if (str.IndexOf(",") == -1)
            {
                string phone = str.ToGetPhone();
                str = str.Replace(phone, "," + phone + ",");
                str += ",000000";
            }
            else
            {
                str = str.ToSplit(",").Length == 3 ? (str + ",000000") : str;
            }

            return str;
        }

    }
}
