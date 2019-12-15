using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.Diagnostics;

using System.Text;
using System.Threading;



namespace Common
{
    public class Mogujie
    {

        #region login
        /// <summary>
        /// 登录方法鞍
        /// </summary>
        /// <param name="webBrowser1"></param>
        public static void login(ChromiumWebBrowser webBrowser1)
        {
            if (Browser.WaitWebPageLoad(webBrowser1))
            {
                string temp = Browser.JS_CEFBrowser("getElementsByDataReactid('.4.0.2.0').length;", webBrowser1);
                if (temp != null)
                {
                    //Manager.JS_CEFBrowser_NoReturn("alert(getElementsByDataReactid('.4.0.2.0')[0]);", webBrowser1);

                    Browser.JS_CEFBrowser_NoReturn("getElementsByDataReactid('.4.0.2.0')[0].value='青涩年华潮包';", webBrowser1);
                    Browser.JS_CEFBrowser_NoReturn("getElementsByDataReactid('.4.0.2.1')[0].value='zhangjiazhe123';", webBrowser1);

                    //JS_CEFBrowser_NoReturn("window.scrollTo(0, 260)", webBrowser1);
                    //MessageBox.Show(Manager.JS_CEFBrowser("getElementsByDataReactid('.4.0.2.1')[0]!=null; ", webBrowser1));
                    Browser.MouseLeftByHtmlElement(" getElementsByDataReactid('.4.0.2.5.1')[0] ", webBrowser1);
                    Auto.Mouse_Left();
                    Browser.Delay(500);

                    //Thread.Sleep(1000);

                    //if (Browser.WaitWebPageLoad(webBrowser1))
                    //Browser.JS_CEFBrowser_NoReturn("window.scrollTo(0, 320)", webBrowser1);
                    //Browser.Delay(1000);
                    Browser.MouseMoveByHtmlElement(" getElementsByDataReactid('.4.0.2.2.0.1')[0] ", webBrowser1);
                    //Auto.MoveMouseToPoint(" getElementsByDataReactid('.4.0.2.2.0.1')[0] ", webBrowser1);
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
                string mogujie_url = "http://www.xiaodian.com/user/login";
                //蘑菇街登录方法
                webBrowser1.Load(mogujie_url);
                if (Browser.WaitWebPageLoad(webBrowser1))
                {
                    //获取账号输入框,判断是否加载成功
                    string temp = Browser.JS_CEFBrowser("getElementsByDataReactid('.4.0.2.0').length;", webBrowser1);
                    if (temp != null)
                    {
                        //设置登录DIV位置，login-wrapper
                        Browser.JS_CEFBrowser_NoReturn("getElementsByDataReactid('.4.0')[0].style.margin='0';", webBrowser1);

                        Browser.JS_CEFBrowser_NoReturn("getElementsByDataReactid('.4.0.2.0')[0].value='" + account + "';", webBrowser1);
                        Browser.JS_CEFBrowser_NoReturn("getElementsByDataReactid('.4.0.2.1')[0].value='" + pwd + "';", webBrowser1);
                        //点击登录按钮
                        //Browser.SetScrollByHtmlElement(" getElementsByDataReactid('.4.0.2.5.1')[0] ", webBrowser1);
                        //Browser.MouseMoveByHtmlElement(" getElementsByDataReactid('.4.0.2.5.1')[0] ", webBrowser1);
                        Browser.MouseLeftByHtmlElement(" getElementsByDataReactid('.4.0.2.5.1')[0] ", webBrowser1);
                        Auto.Mouse_Left();
                        //等待点选验证图片
                        Browser.Delay(500);
                        //鼠标移动到登录按钮上
                        Browser.MouseMoveByHtmlElement(" getElementsByDataReactid('.4.0.2.2.0.1')[0] ", webBrowser1);

                        //验证码.4.0.5.3.0
                        if (Browser.WaitWebPageLoad(" getElementsByDataReactid('.4.0.5.3.0')[0] ", 10000, webBrowser1))
                        {
                            //验证码空间获取焦点
                            Browser.JS_CEFBrowser_NoReturn(" getElementsByDataReactid('.4.0.5.3.0')[0].focus() ", webBrowser1);
                            //鼠标移动到验证按钮上
                            Browser.MouseMoveByHtmlElement(" getElementsByDataReactid('.4.0.5.5.1')[0] ", webBrowser1);
                        }
                    }
                    //点击进入我的小店按钮.4.0.1.3
                    if (Browser.WaitWebPageLoad(" getElementsByDataReactid('.4.0.1.3')[0] ", 30000, webBrowser1))
                    {
                        Browser.MouseLeftByHtmlElement(" getElementsByDataReactid('.4.0.1.3')[0] ", webBrowser1);
                        Auto.Mouse_Left();
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


        #region getYanZhengMa
        /// <summary>
        /// 根据手机短信提取验证码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string getYanZhengMa(string str)
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
            //        //MSG & 750 & 17077604263 & 验证码：336063，菇凉你正在通过手机登录。30分钟内有效，请勿泄露。【蘑菇街】[End]
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



    }
}
