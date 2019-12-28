using CefSharp.WinForms;
using System;
using System.Diagnostics;
using System.IO;

namespace Operation.CS
{
    public class TaoJiJiHelper
    {




        #region Login
        /// <summary>
        /// 拼多多登录方法
        /// </summary>
        /// <param name="acc">账号</param>
        /// <param name="pwd">密码</param>
        /// <param name="webBrowser1"></param>
        /// <returns></returns>
        public static bool LoginKeFu(string shopid,string account, string pwd, ChromiumWebBrowser webBrowser1)
        {
            try
            {
                string taobao_url = "https://cs.taojiji.com";
                //拼多多登录方法
                webBrowser1.Load(taobao_url);
                webBrowser1.Focus();
                if (Browser.WaitWebPageLoad("document.getElementsByClassName('el-input__inner')[0]", 2000, webBrowser1))
                {
                    //string shopid = XMLHelper.GetValue("TaoJiJi_ShopID1");
                    //string account = XMLHelper.GetValue("TaoJiJi_Account1");
                    //string pwd = XMLHelper.GetValue("aoJiJi_Account1");

                    //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('el-input__inner')[0].value='"+ shopid + "'",webBrowser1);
                    //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('el-input__inner')[1].value='" + account + "'", webBrowser1);
                    //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('el-input__inner')[2].value='" + pwd + "'", webBrowser1);
                    webBrowser1.ToMouseClick("document.getElementsByClassName('el-input__inner')[0]");
                    Auto.Ctrl_V(shopid);
                    webBrowser1.ToMouseClick("document.getElementsByClassName('el-input__inner')[1]");
                    Auto.Ctrl_V(account);
                    webBrowser1.ToMouseClick("document.getElementsByClassName('el-input__inner')[2]");
                    Auto.Ctrl_V(pwd);
                    webBrowser1.ToJs("document.getElementsByClassName('el-button')[0].click()");
                    
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine("淘集集客服登录失败" + ex.ToString());
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
 

    }
}
