using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Collections.Specialized;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Drawing;
using System.Diagnostics;
using Entity;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Security.Principal;
using System.Security.AccessControl;
using CefSharp;
using CefSharp.WinForms;
using System.Threading.Tasks;
using mshtml;

namespace excel_operation
{
    public class Browser
    {

        #region 通用


        //JS代码
        public static string jsstr = null;
        //网址
        public static string urlstr = null;
        /// <summary>
        /// 判断网页是否加载完成
        /// </summary>
        public static bool webisok = false;

        #region Delay
        /// <summary>
        /// 延迟系统时间，但系统又能同时能执行其它任务； 
        /// </summary>
        /// <param name="Millisecond">毫秒数</param>
        public static void Delay(int Millisecond) //延迟系统时间，但系统又能同时能执行其它任务；  
        {
            DateTime current = DateTime.Now;
            while (current.AddMilliseconds(Millisecond) > DateTime.Now)
            {
                Application.DoEvents();//转让控制权              
            }
            return;
        }
        #endregion

        #region ScrollToBottom
        /// <summary>
        /// 自动浏览到页面底部
        /// </summary>
        /// <param name="times">每次下滑时间间隔</param>
        /// <param name="webBrowser2"></param>
        public static void ScrollToBottom(int times, ChromiumWebBrowser webBrowser2)
        {
            int clientHeight = 0;
            int.TryParse(Browser.JS_CEFBrowser(" document.body.clientHeight ", webBrowser2), out clientHeight);
            for (int i = 0; i < clientHeight; i++)
            {
                i = i + 200;
                Browser.JS_CEFBrowser_NoReturn(" window.scrollTo(0," + i.ToString() + ") ", webBrowser2);
                Browser.Delay(times);
            }
        }
        #endregion

        #region ScrollToElement
        /// <summary>
        /// 移动到元素的位置
        /// </summary>
        /// <param name="times">每次下滑时间间隔</param>
        /// <param name="count">一共下滑多少次</param>
        /// <param name="webBrowser2"></param>
        public static void ScrollToElement(string element, ChromiumWebBrowser webBrowser2)
        {
            Point temp_p = GetPointBrowserByHtmlElement(element, webBrowser2);
            JS_CEFBrowser_NoReturn("window.scrollTo(" + (temp_p.X).ToString() + ", " + (temp_p.Y).ToString() + ")", webBrowser2);
        }
        #endregion

        #region ScrollToBottom
        /// <summary>
        /// 自动浏览到页面底部
        /// </summary>
        /// <param name="times">每次下滑时间间隔</param>
        /// <param name="count">一共下滑多少次</param>
        /// <param name="webBrowser2"></param>
        public static void ScrollToBottom(int times, int count, ChromiumWebBrowser webBrowser2)
        {
            //int clientHeight = 0;
            //int.TryParse(Browser.JS_CEFBrowser(" document.body.clientHeight ", webBrowser2), out clientHeight);
            int temp = 100;
            for (int i = 0; i < count; i++)
            {
                temp = temp + 500;
                Browser.JS_CEFBrowser_NoReturn(" window.scrollTo(0," + temp.ToString() + ") ", webBrowser2);
                Browser.Delay(times);
            }
        }
        #endregion

        #region ScrollToBottom
        /// <summary>
        /// 自动浏览到页面底部
        /// </summary>
        /// <param name="webBrowser2"></param>
        public static void ScrollToBottom(ChromiumWebBrowser webBrowser2)
        {
            int clientHeight = 0;
            int.TryParse(Browser.JS_CEFBrowser(" document.body.clientHeight ", webBrowser2), out clientHeight);
            Browser.JS_CEFBrowser_NoReturn(" window.scrollTo(0," + clientHeight.ToString() + ") ", webBrowser2);

        }
        #endregion

        #region ScrollToTop
        /// <summary>
        /// 自动浏览到页面顶部
        /// </summary>
        /// <param name="webBrowser2"></param>
        public static void ScrollToTop(ChromiumWebBrowser webBrowser2)
        {
            //int clientHeight = 0;
            //int.TryParse(Browser.JS_CEFBrowser(" document.body.clientHeight ", webBrowser2), out clientHeight);
            Browser.JS_CEFBrowser_NoReturn(" window.scrollTo(0,0) ", webBrowser2);

        }
        #endregion

        #region ScrollToTop
        /// <summary>
        /// 自动浏览到页面顶部
        /// </summary>
        /// <param name="webBrowser2"></param>
        public static void ScrollToTop(int times, ChromiumWebBrowser webBrowser2)
        {
            ScrollToTop(webBrowser2);
            return;
            //int clientHeight = 0;
            //int.TryParse(Browser.JS_CEFBrowser(" document.body.clientHeight ", webBrowser2), out clientHeight);
            //for (int i = 0; i < clientHeight; i++)
            //{

            //    //出现错误，应该先计算滚动条位置
            //    i = i - 200;
            //    Browser.JS_CEFBrowser_NoReturn(" window.scrollTo(0," + i.ToString() + ") ", webBrowser2);
            //    Browser.Delay(times);
            //}

        }
        #endregion

        #endregion


        #region WebBrowser 方法

        #region  GetOffset
        /// <summary>
        /// 获取网页中元素的位置
        /// </summary>
        /// <param name="el">HtmlElement</param>
        /// <returns></returns>
        public static Point GetOffset(HtmlElement el)
        {
            //get element pos
            Point pos = new Point(el.OffsetRectangle.Left, el.OffsetRectangle.Top);

            //get the parents pos
            HtmlElement tempEl = el.OffsetParent;
            while (tempEl != null)
            {
                pos.X += tempEl.OffsetRectangle.Left;
                pos.Y += tempEl.OffsetRectangle.Top;
                tempEl = tempEl.OffsetParent;
            }

            return pos;
        }
        /* 使用方法
        Point point = GetOffset(element);
        var x = point.X;
        var y = point.Y;
        */
        #endregion





        #region JS_WebBrowser
        /// <summary>
        /// 在WebBrowser中使用JS代码
        /// </summary>
        /// <param name="webBrowser1">WebBrowser</param>
        /// <returns>只能返回字符串</returns>
        public static string JS_WebBrowser(WebBrowser webBrowser1)
        {
            return JS_WebBrowser(jsstr, webBrowser1);
        }
        #endregion

        #region JS_WebBrowser
        /// <summary>
        /// 在WebBrowser中使用JS代码
        /// </summary>
        /// <param name="js">JS代码</param>
        /// <param name="webBrowser1">WebBrowser</param>
        /// <returns>只能返回字符串</returns>
        public static string JS_WebBrowser(string js, WebBrowser webBrowser1)
        {
            string res = "";
            string funname = "JS_WebBrowser" + Manager.RandomNumber(1000, 99999);
            js = " function " + funname + "(){ return " + js + " }";
            try
            {
                if (WaitWebPageLoad(webBrowser1))
                {
                    HtmlElement ele = webBrowser1.Document.CreateElement("script");
                    ele.SetAttribute("type", "text/javascript");
                    //获取本页面商品数量
                    ele.SetAttribute("text", js);
                    webBrowser1.Document.Body.AppendChild(ele);
                    object obj = webBrowser1.Document.InvokeScript(funname, new object[] { "webbrowser" });
                    if (obj != null)
                    {
                        res = obj.ToString();
                        //Debug.WriteLine("======================================================");
                        //Debug.WriteLine("网址:" + urlstr);
                        //Debug.WriteLine("JS代码: " + js);
                        //Debug.WriteLine("采集结果:" + res);
                    }
                    else
                    {
                        Debug.WriteLine("======================================================");
                        Debug.WriteLine("WebBrowser中使用JS出现错误:");
                        Debug.WriteLine("网址:" + urlstr);
                        Debug.WriteLine("JS代码: " + js);
                        Debug.WriteLine("错误信息:没有获取到信息，object=null ");
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("======================================================");
                Debug.WriteLine("WebBrowser中使用JS出现错误:");
                Debug.WriteLine("网址:" + urlstr);
                Debug.WriteLine("方法名称: " + funname);
                Debug.WriteLine("JS代码: " + js);
                Debug.WriteLine("错误信息: " + ex.Message);
            }
            return res;
        }
        #endregion

        #region JS_WebBrowserToInt

        /// <summary>
        /// IE浏览器执行有返回值的JS脚本
        /// </summary>
        /// <param name="js"></param>
        /// <param name="wb"></param>
        public static int JS_WebBrowserToInt(string js, WebBrowser wb)
        {

            int res = 0;

            try
            {
                string temp = JS_WebBrowser(js, wb);
                if (int.TryParse(temp, out res))
                {

                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("IE浏览器执行有返回值的JS脚本出错：" + e.ToString());
            }
            return res;
        }
        #endregion

        #region JS_WebBrowser_NoReturn
        /// <summary>
        /// 在WebBrowser中使用JS代码
        /// </summary>
        /// <param name="js">JS代码</param>
        /// <param name="webBrowser1">WebBrowser</param>
        /// <returns>只能返回字符串</returns>
        public static void JS_WebBrowser_NoReturn(string js, WebBrowser webBrowser1)
        {

            string funname = "JS_WebBrowser" + Manager.RandomNumber(1000, 99999);
            js = " function " + funname + "(){   " + js + " }";
            try
            {
                if (WaitWebPageLoad(webBrowser1))
                {
                    HtmlElement ele = webBrowser1.Document.CreateElement("script");
                    ele.SetAttribute("type", "text/javascript");
                    //获取本页面商品数量
                    ele.SetAttribute("text", js);
                    webBrowser1.Document.Body.AppendChild(ele);
                    webBrowser1.Document.InvokeScript(funname, new object[] { "webbrowser" });
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("======================================================");
                Debug.WriteLine("WebBrowser中使用JS出现错误:");
                Debug.WriteLine("网址:" + urlstr);
                Debug.WriteLine("方法名称: " + funname);
                Debug.WriteLine("JS代码: " + js);
                Debug.WriteLine("错误信息: " + ex.Message);
            }

        }
        #endregion

        #region WaitWebPageLoad
        /// <summary>
        /// 判断是否已经完全加载完成,同时添加JS方法【getClassName】
        /// </summary>
        /// <param name="webBrowser1">web浏览器控件</param>
        /// <returns></returns>
        public static bool WaitWebPageLoad(WebBrowser webBrowser1)
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
                        if (i == 2)   //为什么 是2呢？因为每次加载frame完成时就会置IsBusy为false,未完成就就置IsBusy为false，你想一想，加载一次，然后再一次，再一次...... 最后一次.......  
                        {
                            sUrl = webBrowser1.Url.ToString();
                            if (sUrl.Contains("res")) //这是判断没有网络的情况下                             
                            {
                                return false;
                            }
                            else
                            {
                                //添加JScript文件
                                SetJSFile(webBrowser1);
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



        #region WaitWebPageLoad
        /// <summary>
        /// 判断标签是否加载完成,同时添加JS方法【getClassName】
        /// </summary>
        /// <param name="element">web元素</param>
        /// <param name="webBrowser1">web浏览器控件</param>
        /// <returns></returns>
        public static bool WaitWebPageLoad(string element, WebBrowser webBrowser1)
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
                        if (i == 2)   //为什么 是2呢？因为每次加载frame完成时就会置IsBusy为false,未完成就就置IsBusy为false，你想一想，加载一次，然后再一次，再一次...... 最后一次.......  
                        {
                            sUrl = webBrowser1.Url.ToString();
                            if (sUrl.Contains("res")) //这是判断没有网络的情况下                             
                            {
                                return false;
                            }
                            else
                            {
                                //添加getClassName方法
                                //SetJS_getClassName(webBrowser1);
                                //SetJS_getMetaName(webBrowser1);
                                //SetJS_getElementsByDataID(webBrowser1);
                                //SetJS_getElementsByDataSpm(webBrowser1);
                                //SetJS_getElementsByTitle(webBrowser1);
                                //SetJS_getRemoveElement(webBrowser1);

                                //添加JScript文件
                                SetJSFile(webBrowser1);

                                //判断元素存在后，返回true
                                while (true)
                                {
                                    Delay(50);
                                    string temp = JS_WebBrowser(element, webBrowser1);
                                    if (!string.IsNullOrEmpty(temp) && temp != "null")
                                    {
                                        Debug.WriteLine("找到了" + temp + " " + element);
                                        return true;
                                    }

                                }
                            }
                        }
                        continue;
                    }
                    i = 0;
                }
            }
        }
        #endregion

        #region WaitJS
        /// <summary>
        /// 只有js的返回值为ture时，才继续处理以后的代码
        /// </summary>
        /// <param name="js">判断的js代码是否为ture</param>
        /// <param name="webBrowser1">web浏览器控件</param>
        /// <returns></returns>
        public static bool WaitJS(string js, WebBrowser webBrowser1)
        {
            //判断元素存在后，返回true
            while (true)
            {
                Delay(50);
                string temp = JS_WebBrowser(js, webBrowser1);
                if (!string.IsNullOrEmpty(temp))
                {
                    if (temp.ToLower() == "true")
                    {
                        Debug.WriteLine("找到了" + temp + " " + js);
                        return true;
                    }
                }
            }
        }
        #endregion




        #region JS_WebBrowser_RemoveElement
        /// <summary>
        /// 删除html元素
        /// </summary>
        /// <param name="js">获取元素js代码,非数组</param>
        /// <param name="webBrowser1"></param>
        /// <returns></returns>
        public static bool JS_WebBrowser_RemoveElement(string js, WebBrowser webBrowser1)
        {
            bool res = false;
            try
            {
                string temp = JS_WebBrowser(js, webBrowser1);
                if (!string.IsNullOrEmpty(temp) && temp != "0")
                {
                    JS_WebBrowser_NoReturn(" removeElement(" + js + ") ;", webBrowser1);
                    res = true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("======================================================");
                Debug.WriteLine("使用removeElement方法删除" + js + "出错:");
                Debug.WriteLine("网址:" + urlstr);
                Debug.WriteLine("方法名称: JS_WebBrowser_RemoveElement");
                Debug.WriteLine("JS代码: " + js);
                Debug.WriteLine("错误信息: " + ex.Message);
            }
            return res;
        }
        #endregion

        #region IsWebOk
        /// <summary>
        /// 判断是否有网络
        /// </summary>
        /// <returns></returns>
        public static bool IsWebOk()
        {
            bool ress = false;
            System.Net.NetworkInformation.Ping ping;
            System.Net.NetworkInformation.PingReply res;
            ping = new System.Net.NetworkInformation.Ping();
            try
            {
                res = ping.Send("www.baidu.com");  //
                if (res.Status == System.Net.NetworkInformation.IPStatus.Success)
                {
                    //没有联上Internet哦，做下自己想做个事情咯
                    //MessageBox.Show("0");
                    ress = true;
                }
            }
            catch (Exception er)
            {
                //里你，仲系当你断网咯，做下自己想做个事情咯
                MessageBox.Show("判断网络出现问题" + er.Message);
            }
            return ress;
        }
        #endregion

        #region GetJSByClassName
        /// <summary>
        /// 根据ClassName获取innerText值
        /// </summary>
        /// <param name="funname">方法名称</param>
        /// <param name="className">ClassName</param>
        /// <param name="index">数组中第几个,第一个为0</param>
        /// <param name="js">JS操作，比如innerText</param>
        /// <returns>JS方法字符串</returns>
        public static string GetJSByClassName(string funname, string className, int index, string js)
        {
            string str = " function " + funname + "(){return getClassName('" + className + "')[" + index + "]." + js + ";}";
            return str;
        }
        #endregion

        #region GetValueByClassName
        /// <summary>
        /// 根据ClassName获取innerText值
        /// </summary>
        /// <param name="className">ClassName</param>
        /// <param name="index">数组中第几个,第一个为0</param>
        /// <param name="js">JS操作，比如innerText</param>
        /// <param name="webBrowser1">WebBrowser</param>
        /// <returns>JS方法字符串</returns>
        public static string GetValueByClassName(string className, int index, string js, WebBrowser webBrowser1)
        {
            jsstr = " getClassName('" + className + "')[" + index + "]." + js + "; ";
            return JS_WebBrowser(webBrowser1);
        }
        #endregion

        #region GetJSById
        /// <summary>
        /// 根据id获取innerText值
        /// </summary>
        /// <param name="funname">方法名称</param>
        /// <param name="id">id</param>
        /// <param name="js">JS操作，比如innerText</param>
        /// <returns>JS方法字符串</returns>
        public static string GetJSById(string funname, string id, string js)
        {
            string str = " function " + funname + "(){return document.getElementById('" + id + "')." + js + ";}";
            //string str = " function setHtml(){return document.getElementById('" + id + "').innerText;";
            return str;
        }
        #endregion

        #region GetValueById
        /// <summary>
        /// 根据id获取innerText值
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="js">JS操作，比如innerText</param>
        /// <param name="webBrowser1">WebBrowser控件</param>
        /// <returns>JS方法字符串</returns>
        public static string GetValueById(string id, string js, WebBrowser webBrowser1)
        {
            jsstr = "  document.getElementById('" + id + "')." + js + "; ";
            return JS_WebBrowser(webBrowser1);

        }
        #endregion

        #region GetValueByDataId
        /// <summary>
        /// 根据id获取html对象，然后进行操作，该方法会拍段是否获取信息
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="js">JS操作，比如.innerText</param>
        /// <param name="webBrowser1">WebBrowser控件</param>
        /// <returns>字符串，出错会返回空</returns>
        public static string GetValueByDataId(string id, string js, WebBrowser webBrowser1)
        {
            string temp = "";
            try
            {
                string temp2 = JS_WebBrowser(" getElementsByDataID('" + id + "').length; ", webBrowser1);
                if (temp2 != "0" && !string.IsNullOrEmpty(temp2))
                {
                    temp = JS_WebBrowser(" getElementsByDataID('" + id + "')" + js + "; ", webBrowser1);
                }
            }
            catch
            {
                temp = "";
                Debug.WriteLine("getElementsByDataID('" + id + "')没有获取到数据");
            }
            return temp;

        }
        #endregion

        #region UrlEncode
        /// <summary>
        /// 网址字符编码转换，汉字转换成UTF8
        /// </summary>
        /// <param name="url"></param>
        /// <param name="en">Encoding.UTF8</param>
        /// <returns></returns>
        public static string UrlEncode(string url, Encoding en)
        {
            //byte[] bs = Encoding.GetEncoding("GB2312").GetBytes(url);
            byte[] bs = en.GetBytes(url);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < bs.Length; i++)
            {
                if (bs[i] < 128)
                    sb.Append((char)bs[i]);
                else
                {
                    sb.Append("%" + bs[i++].ToString("x").PadLeft(2, '0'));
                    sb.Append("%" + bs[i].ToString("x").PadLeft(2, '0'));
                }
            }
            return sb.ToString();
        }
        #endregion

        #region JS方法

        #region SetJS_getClassName
        /// <summary>
        /// 添加getClassName方法
        /// </summary>
        /// <param name="webBrowser1">WebBrowser</param>
        public static void SetJS_getClassName(WebBrowser webBrowser1)
        {
            //string js = @"function getElementsByClassName(oElm, strTagName, strClassName){ var arrElements = (strTagName == '*' && oElm.all)? oElm.all : oElm.getElementsByTagName(strTagName); var arrReturnElements = new Array(); strClassName = strClassName.replace(/\-/g, '\\-'); var oRegExp = new RegExp('(^|\\s)' + strClassName + '(\\s|$)'); var oElement; for(var i=0; i < arrElements.length; i++){ oElement = arrElements[i]; if(oRegExp.test(oElement.className)){ arrReturnElements.push(oElement); } } return (arrReturnElements) }   ";
            string js = "function getClassName(abc){ if (!document.getElementsByClassName) { var list=document.getElementsByTagName('*');var arr=[];for (var i=0;i<list.length;i++) {if(list[i].className==abc){ arr.push(list[i]); }}return arr;} else{return document.getElementsByClassName(abc);}} ";
            //string js = "if (!document.getElementsByClassName) { document.getElementsByClassName = function (className, element) {   var children = (element || document).getElementsByTagName('*');  var elements = new Array();        for (var i = 0; i < children.length; i++) {            var child = children[i];            var classNames = child.className.split(' ');            for (var j = 0; j < classNames.length; j++) {                if (classNames[j] == className) {                    elements.push(child);                    break;                }            }        }        return elements;    };}";
            try
            {
                HtmlElement ele = webBrowser1.Document.CreateElement("script");
                ele.SetAttribute("type", "text/javascript");
                //获取本页面商品数量
                ele.SetAttribute("text", js);
                webBrowser1.Document.Body.AppendChild(ele);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("======================================================");
                Debug.WriteLine("WebBrowser中设置getElementsByClassName方法出错:");
                Debug.WriteLine("网址:" + urlstr);
                Debug.WriteLine("方法名称: SetJS_getClassName");
                Debug.WriteLine("JS代码: " + js);
                Debug.WriteLine("错误信息: " + ex.Message);
            }
        }
        #endregion

        #region SetJS_getMetaName
        /// <summary>
        /// 添加getMetaName方法
        /// </summary>
        /// <param name="webBrowser1">WebBrowser</param>
        public static void SetJS_getMetaName(WebBrowser webBrowser1)
        {

            string js = "function getMetaName(abc){ var list=document.getElementsByTagName('meta');var arr=[];for (var i=0;i<list.length;i++) {if(list[i].name==abc){ arr.push(list[i]); }}return arr;} ";
            try
            {
                HtmlElement ele = webBrowser1.Document.CreateElement("script");
                ele.SetAttribute("type", "text/javascript");
                //获取本页面商品数量
                ele.SetAttribute("text", js);
                webBrowser1.Document.Body.AppendChild(ele);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("======================================================");
                Debug.WriteLine("WebBrowser中设置getMetaName方法出错:");
                Debug.WriteLine("网址:" + urlstr);
                Debug.WriteLine("方法名称: SetJS_getMetaName");
                Debug.WriteLine("JS代码: " + js);
                Debug.WriteLine("错误信息: " + ex.Message);
            }
        }
        #endregion

        #region SetJS_getElementsByDataID
        /// <summary>
        /// 添加getElementsByDataID方法
        /// </summary>
        /// <param name="webBrowser1">WebBrowser</param>
        public static void SetJS_getElementsByDataID(WebBrowser webBrowser1)
        {

            //string js = "function getElementsByDataID(abc){ var list=document.getElementsByTagName('*');var arr=[];for (var i=0;i<list.length;i++) { try{ if(list[i].getAttribute('data-spm-anchor-id')==abc){ arr.push(list[i]);}catch(err){ alert(err); } }}return arr;} ";
            string js = "function getElementsByDataID(abc){ var list=document.getElementsByTagName('*');var arr=[];for (var i=0;i<list.length;i++) { if(list[i].getAttribute('data-spm-anchor-id')==abc){ arr.push(list[i]);}  }return arr;} ";
            try
            {
                HtmlElement ele = webBrowser1.Document.CreateElement("script");
                ele.SetAttribute("type", "text/javascript");
                //获取本页面商品数量
                ele.SetAttribute("text", js);
                webBrowser1.Document.Body.AppendChild(ele);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("======================================================");
                Debug.WriteLine("WebBrowser中设置getElementsByDataID方法出错:");
                Debug.WriteLine("网址:" + urlstr);
                Debug.WriteLine("方法名称: SetJS_getElementsByDataID");
                Debug.WriteLine("JS代码: " + js);
                Debug.WriteLine("错误信息: " + ex.Message);
            }
        }
        #endregion

        #region SetJS_getElementsByTitle
        /// <summary>
        /// 添加getElementsByTitle方法
        /// </summary>
        /// <param name="webBrowser1">WebBrowser</param>
        public static void SetJS_getElementsByTitle(WebBrowser webBrowser1)
        {

            string js = "function getElementsByTitle(abc){ var list=document.getElementsByTagName('*');var arr=[];for (var i=0;i<list.length;i++) { if(list[i].getAttribute('title')==abc){ arr.push(list[i]);}  }return arr;} ";
            try
            {
                HtmlElement ele = webBrowser1.Document.CreateElement("script");
                ele.SetAttribute("type", "text/javascript");
                //获取本页面商品数量
                ele.SetAttribute("text", js);
                webBrowser1.Document.Body.AppendChild(ele);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("======================================================");
                Debug.WriteLine("WebBrowser中设置getElementsByTitle方法出错:");
                Debug.WriteLine("网址:" + urlstr);
                Debug.WriteLine("方法名称: SetJS_getElementsByTitle");
                Debug.WriteLine("JS代码: " + js);
                Debug.WriteLine("错误信息: " + ex.Message);
            }
        }
        #endregion

        #region SetJS_getElementsByDataSpm
        /// <summary>
        /// 添加getElementsByDataSpm方法
        /// </summary>
        /// <param name="webBrowser1">WebBrowser</param>
        public static void SetJS_getElementsByDataSpm(WebBrowser webBrowser1)
        {

            string js = "function getElementsByDataSpm(abc){ var list=document.getElementsByTagName('*');var arr=[];for (var i=0;i<list.length;i++) { if(list[i].getAttribute('data-spm')==abc){ arr.push(list[i]);}  }return arr;} ";
            try
            {
                HtmlElement ele = webBrowser1.Document.CreateElement("script");
                ele.SetAttribute("type", "text/javascript");
                //获取本页面商品数量
                ele.SetAttribute("text", js);
                webBrowser1.Document.Body.AppendChild(ele);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("======================================================");
                Debug.WriteLine("WebBrowser中设置getElementsByDataSpm方法出错:");
                Debug.WriteLine("网址:" + urlstr);
                Debug.WriteLine("方法名称: SetJS_getElementsByDataSpm");
                Debug.WriteLine("JS代码: " + js);
                Debug.WriteLine("错误信息: " + ex.Message);
            }
        }
        #endregion

        #region SetJS_getRemoveElement
        /// <summary>
        /// 添加removeElement方法,用于删除元素
        /// </summary>
        /// <param name="webBrowser1">WebBrowser</param>
        public static void SetJS_getRemoveElement(WebBrowser webBrowser1)
        {

            string js = "function removeElement(_element){var _parentElement = _element.parentNode;if(_parentElement){  _parentElement.removeChild(_element);}    } ";
            try
            {
                HtmlElement ele = webBrowser1.Document.CreateElement("script");
                ele.SetAttribute("type", "text/javascript");
                //获取本页面商品数量
                ele.SetAttribute("text", js);
                webBrowser1.Document.Body.AppendChild(ele);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("======================================================");
                Debug.WriteLine("WebBrowser中设置removeElement方法出错:");
                Debug.WriteLine("网址:" + urlstr);
                Debug.WriteLine("方法名称: SetJS_getRemoveElement");
                Debug.WriteLine("JS代码: " + js);
                Debug.WriteLine("错误信息: " + ex.Message);
            }
        }
        #endregion

        #region SetJSFile
        /// <summary>
        /// 添加JS文件
        /// </summary>
        /// <param name="webBrowser1">WebBrowser</param>
        public static void SetJSFile(WebBrowser webBrowser1)
        {
            string js = "";
            try
            {
                string temp_path = Application.StartupPath + "\\JScript.js";
                if (File.Exists(@temp_path))
                {
                    using (FileStream file = new FileStream(@temp_path, FileMode.Open))
                    {
                        using (StreamReader sr = new StreamReader(file))
                        {
                            js = sr.ReadToEnd();
                            HtmlElement ele = webBrowser1.Document.CreateElement("script");
                            ele.SetAttribute("type", "text/javascript");
                            //获取本页面商品数量
                            ele.SetAttribute("text", js);
                            webBrowser1.Document.Body.AppendChild(ele);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("======================================================");
                Debug.WriteLine("WebBrowser中添加JS文件出错:");
                Debug.WriteLine("网址:" + urlstr);
                Debug.WriteLine("方法名称: SetJSFile");
                Debug.WriteLine("JS代码: " + js);
                Debug.WriteLine("错误信息: " + ex.Message);
            }
        }
        #endregion

        #endregion

        #region WebBrowser_ClearData

        private enum ShowCommands : int
        {

            SW_HIDE = 0,

            SW_SHOWNORMAL = 1,

            SW_NORMAL = 1,

            SW_SHOWMINIMIZED = 2,

            SW_SHOWMAXIMIZED = 3,

            SW_MAXIMIZE = 3,

            SW_SHOWNOACTIVATE = 4,

            SW_SHOW = 5,

            SW_MINIMIZE = 6,

            SW_SHOWMINNOACTIVE = 7,

            SW_SHOWNA = 8,

            SW_RESTORE = 9,

            SW_SHOWDEFAULT = 10,

            SW_FORCEMINIMIZE = 11,

            SW_MAX = 11

        }
        [DllImport("shell32.dll")]
        static extern IntPtr ShellExecute(IntPtr hwnd, string lpOperation, string lpFile, string lpParameters, string lpDirectory, ShowCommands nShowCmd);

        /// <summary>
        /// 清除所有临时文件、Session、Cookie等信息
        /// </summary>
        public static void ClearData()
        {
            ShellExecute(IntPtr.Zero, "open", "rundll32.exe", " InetCpl.cpl,ClearMyTracksByProcess 255", "", ShowCommands.SW_HIDE);
            /*
            其中ClearMyTracksByProcess 可进行选择设置 ：

             * Temporary Internet Files  （Internet临时文件）

             * RunDll32.exe InetCpl.cpl,ClearMyTracksByProcess 8

             * Cookies
             * 
             * RunDll32.exe InetCpl.cpl,ClearMyTracksByProcess 2

             * History (历史记录)

             * RunDll32.exe InetCpl.cpl,ClearMyTracksByProcess 1

                Form. Data （表单数据）

                RunDll32.exe InetCpl.cpl,ClearMyTracksByProcess 16

                Passwords (密码）

                RunDll32.exe InetCpl.cpl,ClearMyTracksByProcess 32

                Delete All  （全部删除）

                RunDll32.exe InetCpl.cpl,ClearMyTracksByProcess 255
             * 
             * 
             * 
             * */
        }
        #endregion


        #region GetWebBrowser
        /// <summary>
        /// 将webBrowser1中的Session、Cookie等信息赋予webBrowser2中
        /// </summary>
        /// <param name="webBrowser1">原始信息webBrowser</param>
        /// <param name="webBrowser2"></param>
        /// <returns>是否赋值成功</returns>
        public static bool GetWebBrowser(WebBrowser webBrowser1, WebBrowser webBrowser2)
        {
            bool isok = true;
            try
            {
                webBrowser2.ScriptErrorsSuppressed = true;
                webBrowser2.DocumentStream = webBrowser1.DocumentStream;
                webBrowser2.Document.Cookie = webBrowser1.Document.Cookie;
                webBrowser2.Url = webBrowser1.Url;
            }
            catch
            {
                isok = false;
            }
            return isok;
        }
        #endregion


        #region GetPointBrowserByHtmlElement
        /// <summary>
        /// 获取Web元素，在浏览器中的坐标
        /// </summary>
        /// <param name="element">获取Web元素，例如：getElementsByDataSpm('d58')[0]</param>
        /// <param name="webBrowser1">WebBrowser</param>
        /// <returns>Point</returns>
        public static Point GetPointBrowserByHtmlElement(string element, WebBrowser webBrowser1)
        {
            Point res = new Point();
            int x = 0;
            int y = 0;
            string temp = "";
            //int temp_fuyu = 5;
            try
            {
                temp = JS_WebBrowser(element, webBrowser1);
                if (!string.IsNullOrEmpty(temp))
                {
                    string temp_x = JS_WebBrowser(" getAbsoluteOffsetLeft(" + element + "); ", webBrowser1);
                    //string temp_x2 = JS_WebBrowser(" document.documentElement.scrollTop; ", webBrowser1);
                    string temp_y = JS_WebBrowser(" getAbsoluteOffsetTop(" + element + ")-document.documentElement.scrollTop;", webBrowser1);
                    if (int.TryParse(temp_x, out x) && int.TryParse(temp_y, out y))
                    {
                        res = new Point(x, y);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("获取网页中的元素位置失败");
                Debug.WriteLine("错误原因：" + ex.Message);
            }
            return res;
        }
        #endregion

        #region GetPointScreenByHtmlElement
        /// <summary>
        /// 获取Web元素，在屏幕中的坐标
        /// </summary>
        /// <param name="element">获取Web元素，例如：getElementsByDataSpm('d58')[0]</param>
        /// <param name="webBrowser1">WebBrowser</param>
        /// <returns>Point，如果出错则显示为IsEmpty</returns>
        public static Point GetPointScreenByHtmlElement(string element, WebBrowser webBrowser1)
        {
            Point res = new Point();
            Point p_web = GetPointBrowserByHtmlElement(element, webBrowser1);
            if (!p_web.IsEmpty)
            {
                res = webBrowser1.PointToScreen(new Point(0, 0));
                res.Offset(p_web);
            }
            return res;
        }
        #endregion

        #region GetTBUrlByElement_A
        /// <summary>
        /// 找到指定元素位置并模拟鼠标点击后过去A标签的URL
        /// </summary>
        /// <param name="webBrowser1">WebBrowser</param>
        /// <returns>返回url，如果没有获取到带参数的url则返回空</returns>
        public static string GetTBUrlByElement_A(string element, WebBrowser webBrowser1)
        {
            Point p = new Point();
            string url = "";
            try
            {
                p = GetPointScreenByHtmlElement(element, webBrowser1);
                if (!p.IsEmpty)
                {
                    Point temp_p = GetPointBrowserByHtmlElement(element, webBrowser1);
                    int webheight = webBrowser1.Height;
                    if (temp_p.Y >= webheight)
                    {
                        //滚动滑动条到底部
                        //webBrowser1.Document.Window.ScrollTo(0, webBrowser1.Document.Body.ScrollRectangle.Height);
                        //加100是为了流出富余
                        webBrowser1.Document.Window.ScrollTo(0, temp_p.Y - webheight + 100);
                        //if (WaitWebPageLoad(webBrowser1))
                        //{
                        p = GetPointScreenByHtmlElement(element, webBrowser1);
                        //}
                    }


                    JS_WebBrowser_NoReturn(element + ".setAttribute('onclick','return false');", webBrowser1);
                    p.Offset(Point_FuYu(element, webBrowser1));
                    Cursor.Position = p;
                    Debug.WriteLine(element + "的位置是" + p.ToString());
                    //尝试5次获取URL，因为引用外部鼠标点击，相当于异步操作，有延迟
                    for (int i = 0; i < 5; i++)
                    {
                        Auto.Mouse_Left();
                        url = JS_WebBrowser(element + ".href", webBrowser1);
                        //如果没有获取到带参数的url则返回空
                        if (!string.IsNullOrEmpty(Manager.GetURLParam(url, "spm")))
                        {
                            Debug.WriteLine("获取到具有淘宝规则的链接：" + url);
                            return url;
                        }
                        else
                        {
                            url = "";
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("在生意参谋首页定位市场行情坐标");
                Debug.WriteLine("错误原因：" + ex.Message);
            }
            return url;

        }
        #endregion

        #region MouseLeftByHtmlElement
        /// <summary>
        /// 找到指定元素位置并操纵鼠标点击
        /// </summary>
        /// <param name="webBrowser1">WebBrowser</param>
        /// <returns>返回url，如果没有获取到带参数的url则返回空</returns>
        public static void MouseLeftByHtmlElement(string element, WebBrowser webBrowser1)
        {
            Point p = new Point();
            try
            {
                //Delay(100);
                //在电脑屏幕中的位置
                p = GetPointScreenByHtmlElement(element, webBrowser1);
                if (!p.IsEmpty)
                {
                    //在浏览器中的位置
                    Point temp_p = GetPointBrowserByHtmlElement(element, webBrowser1);
                    //获取浏览器高度
                    int webheight = webBrowser1.Height;
                    //获取滚动条被卷去的高度
                    int temp_scroll_height = Convert.ToInt32(JS_WebBrowser("document.documentElement.scrollTop", webBrowser1));
                    //设置浏览器滑动条的高度：位置居中
                    webBrowser1.Document.Window.ScrollTo(0, temp_scroll_height + temp_p.Y - webheight / 2);
                    //获取元素在屏幕中的坐标
                    p = GetPointScreenByHtmlElement(element, webBrowser1);
                    //获取元素面积内的随机坐标，模仿真实点击
                    p.Offset(Point_FuYu(element, webBrowser1));
                    //移动鼠标
                    Cursor.Position = p;
                    //Delay(3000);
                    //点击左键
                    Auto.Mouse_Left();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("MouseLeftByHtmlElement方法错误");
                Debug.WriteLine("错误原因：" + ex.Message);
            }
        }
        #endregion

        #region SetScrollByHtmlElement
        /// <summary>
        /// 找到指定元素位置并在浏览器中居中显示
        /// </summary>
        /// <param name="webBrowser1">WebBrowser</param>
        /// <returns></returns>
        public static void SetScrollByHtmlElement(string element, WebBrowser webBrowser1)
        {
            try
            {
                //在浏览器中的位置
                Point temp_p = GetPointBrowserByHtmlElement(element, webBrowser1);
                //获取浏览器高度
                int webheight = webBrowser1.Height;
                //获取滚动条被卷去的高度
                int temp_scroll_height = Convert.ToInt32(JS_WebBrowser("document.documentElement.scrollTop", webBrowser1));
                //设置浏览器滑动条的高度：位置居中
                webBrowser1.Document.Window.ScrollTo(0, temp_scroll_height + temp_p.Y - webheight / 2);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("SetScrollByHtmlElement方法错误");
                Debug.WriteLine("错误原因：" + ex.Message);
            }
        }
        #endregion

        #region Point_FuYu
        /// <summary>
        /// 根据元素获取，模拟鼠标点击的指针
        /// </summary>
        /// <param name="element"></param>
        /// <param name="webBrowser1"></param>
        /// <returns></returns>
        public static Point Point_FuYu(string element, WebBrowser webBrowser1)
        {
            Point res = new Point();
            string x = JS_WebBrowser(element + ".offsetWidth;", webBrowser1);
            string y = JS_WebBrowser(element + ".offsetHeight;", webBrowser1);
            int xx = 0;
            int yy = 0;
            if (int.TryParse(x, out xx) && int.TryParse(y, out yy))
            {
                if (xx > 1 && yy > 1)
                {
                    //res = new Point(Manager.RandomNumber(1, xx - 1), Manager.RandomNumber(1, yy - 1));
                    res = new Point(Manager.RandomNumber(xx / 4, xx / 2), Manager.RandomNumber(yy / 4, yy / 2));
                }
            }
            return res;
        }
        #endregion

        #region MouseLeftByHtmlElement_Wait
        /// <summary>
        /// 等待元素出现后，找到指定元素位置并操纵鼠标点击
        /// </summary>
        /// <param name="element">HTML元素</param>
        /// <param name="webBrowser1">WebBrowser</param>
        /// <returns>bool是否成功</returns>
        public static bool MouseLeftByHtmlElement_Wait(string element, WebBrowser webBrowser1)
        {
            bool res = true;
            try
            {
                if (WaitWebPageLoad(element, webBrowser1))
                {
                    MouseMoveByHtmlElement(element, webBrowser1);
                    Auto.Mouse_Left();
                }
            }
            catch
            {
                res = false;
            }
            return res;
        }
        #endregion

        #region MouseMoveByHtmlElement
        /// <summary>
        /// 移动到指定元素位置并居中显示
        /// </summary>
        /// <param name="webBrowser1">WebBrowser</param>
        /// <returns>返回url，如果没有获取到带参数的url则返回空</returns>
        public static void MouseMoveByHtmlElement(string element, WebBrowser webBrowser1)
        {
            Point p = new Point();
            try
            {
                //在电脑屏幕中的位置
                p = GetPointScreenByHtmlElement(element, webBrowser1);
                if (!p.IsEmpty)
                {
                    SetScrollByHtmlElement(element, webBrowser1);
                    Browser.Delay(100);
                    //获取元素在屏幕中的坐标
                    p = GetPointScreenByHtmlElement(element, webBrowser1);
                    //获取元素面积内的随机坐标，模仿真实点击
                    p.Offset(Point_FuYu(element, webBrowser1));
                    //p.Offset(Manager.point_fuyu);
                    //移动鼠标
                    Cursor.Position = p;
                    //Delay(3000);
                    //点击左键
                    //Auto.Mouse_Left();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("MouseLeftByHtmlElement方法错误");
                Debug.WriteLine("错误原因：" + ex.Message);
            }
        }
        #endregion




        #endregion


        #region CEF谷歌浏览器

        #region GetJSFile

        /// <summary>
        /// 获取JS文件内容
        /// </summary>
        /// <returns></returns>
        public static string GetJSFile()
        {
            string res = "";
            try
            {
                string temp_path = Application.StartupPath + "\\JScript.js";
                if (File.Exists(@temp_path))
                {
                    using (FileStream file = new FileStream(@temp_path, FileMode.Open))
                    {
                        using (StreamReader sr = new StreamReader(file))
                        {
                            res = sr.ReadToEnd();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("获取JS文件出错：" + e.ToString());
            }
            return res;
        }

        #endregion

        #region JS_CEFBrowser_NoReturn

        /// <summary>
        /// 谷歌浏览器执行不返回值的JS脚本
        /// </summary>
        /// <param name="js"></param>
        /// <param name="wb"></param>
        public static void JS_CEFBrowser_NoReturn(string js, ChromiumWebBrowser wb)
        {
            string js_fun = GetJSFile();
            try
            {
                js = js.Trim();
                //设置位置
                //string temp_setscroll=js.Substring(0, js.LastIndexOf("."));
                //SetScrollByHtmlElement(temp_setscroll, wb);
                //设置位置
                wb.ExecuteScriptAsync(js_fun + " " + js);

            }
            catch (Exception e)
            {
                Debug.WriteLine("谷歌浏览器执行不返回值的JS脚本出错：" + e.ToString());
            }
        }
        #endregion

        #region JS_CEFBrowser

        /// <summary>
        /// 谷歌浏览器执行有返回值的JS脚本
        /// </summary>
        /// <param name="js"></param>
        /// <param name="wb"></param>
        public static string JS_CEFBrowser(string js, ChromiumWebBrowser wb)
        {

            string res = "";

            try
            {
                js = js.Trim();
                string js_fun = GetJSFile();
                //string js_fun = "";
                Task<CefSharp.JavascriptResponse> task = wb.EvaluateScriptAsync(js_fun + " " + js);
                task.Wait();
                if (task.Result.Result != null)
                {
                    res = task.Result.Result.ToString();
                }
                //task.ContinueWith(t =>
                //{
                //    if (!t.IsFaulted)
                //    {
                //        var response = t.Result;

                //        if (response.Success == true)
                //        {
                //            try
                //            {
                //                res = response.Result.ToString();
                //            }
                //            catch (Exception ex)
                //            {
                //                Debug.WriteLine("谷歌浏览器执行不返回值的JS脚本出错2：" + ex.ToString());
                //            }
                //        }
                //    }
                //}, TaskScheduler.FromCurrentSynchronizationContext());
            }
            catch (Exception e)
            {
                Debug.WriteLine("谷歌浏览器执行不返回值的JS脚本出错：" + e.ToString());
            }
            return res;
        }
        #endregion

        #region JS_CEFBrowser

        /// <summary>
        /// 等待元素加载完成，谷歌浏览器执行有返回值的JS脚本
        /// </summary>
        /// <param name="js"></param>
        /// <param name="element">元素</param>
        /// <param name="wb"></param>
        public static string JS_CEFBrowser(string js, string element, ChromiumWebBrowser wb)
        {

            string res = "";

            try
            {
                if (WaitWebPageLoad(element, wb))
                {
                    res = JS_CEFBrowser(js, wb);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("谷歌浏览器执行不返回值的JS脚本出错：" + e.ToString());
            }
            return res;
        }
        #endregion

        #region JS_CEFBrowser

        /// <summary>
        /// 谷歌浏览器执行有返回值的JS脚本
        /// </summary>
        /// <param name="js"></param>
        /// <param name="times">等待时间，默认10秒 10000</param>
        /// <param name="wb"></param>
        public static string JS_CEFBrowser(string js, int times, ChromiumWebBrowser wb)
        {

            string res = "";

            try
            {
                DateTime dt1 = DateTime.Now;
                //默认等待10秒
                times = times == 0 ? 10000 : times;
                while (true)
                {
                    //Delay(50);  
                    while (true)
                    {
                        Delay(300);//系统延迟50毫秒，够少了吧！
                        res = JS_CEFBrowser(js, wb);
                        if (!string.IsNullOrEmpty(res))
                        {
                            return res;
                        }
                        if (dt1.AddMilliseconds(times) < DateTime.Now)
                        {
                            Debug.WriteLine("到时间了，停止运行方法");
                            return res;
                        }
                    }
                }

            }
            catch (Exception e)
            {
                Debug.WriteLine("谷歌浏览器执行不返回值的JS脚本出错：" + e.ToString());
            }
            return res;
        }
        #endregion



        #region JS_CEFBrowserToInt

        /// <summary>
        /// 谷歌浏览器执行有返回值的JS脚本
        /// </summary>
        /// <param name="js"></param>
        /// <param name="wb"></param>
        public static int JS_CEFBrowserToInt(string js, ChromiumWebBrowser wb)
        {

            int res = 0;

            try
            {
                string temp = JS_CEFBrowser(js, wb);
                if (int.TryParse(temp, out res))
                {

                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("谷歌浏览器执行不返回值的JS脚本出错：" + e.ToString());
            }
            return res;
        }
        #endregion

        #region JS_CEFBrowserToDecimal

        /// <summary>
        /// 谷歌浏览器执行有返回值的JS脚本
        /// </summary>
        /// <param name="js"></param>
        /// <param name="wb"></param>
        public static decimal JS_CEFBrowserToDecimal(string js, ChromiumWebBrowser wb)
        {

            decimal res = 0;

            try
            {
                string temp = JS_CEFBrowser(js, wb);
                temp = temp.Replace("%", "");
                temp = temp.Replace(",", "");
                if (decimal.TryParse(temp, out res))
                {

                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("谷歌浏览器执行不返回值的JS脚本出错：" + e.ToString());
            }
            return res;
        }
        #endregion

        #region JS_CEFBrowserToDate

        /// <summary>
        /// 谷歌浏览器执行有返回值的JS脚本
        /// </summary>
        /// <param name="js"></param>
        /// <param name="wb"></param>
        public static DateTime JS_CEFBrowserToDate(string js, ChromiumWebBrowser wb)
        {
            DateTime res = new DateTime();
            string temp = JS_CEFBrowser(js, wb);
            DateTime.TryParse(temp, out res);
            return res;
        }
        #endregion

        #region JS_CEFBrowserHasElementToBool

        /// <summary>
        /// 是否有元素
        /// </summary>
        /// <param name="element"></param>
        /// <param name="wb"></param>
        public static bool JS_CEFBrowserHasElementToBool(string element, ChromiumWebBrowser wb)
        {

            bool res = false;

            try
            {
                string temp = JS_CEFBrowser(element + "!=null", wb);
                if (!string.IsNullOrEmpty(temp) && temp == "True")
                {
                    return true;
                }

            }
            catch (Exception e)
            {
                Debug.WriteLine("谷歌浏览器执行不返回值的JS脚本出错：" + e.ToString());
            }
            return res;
        }
        #endregion

        #region JS_CEFBrowserHasElementToBool

        /// <summary>
        /// 返回值转换成bool
        /// </summary>
        /// <param name="js"></param>
        /// <param name="wb"></param>
        public static bool JS_CEFBrowserToBool(string js, ChromiumWebBrowser wb)
        {

            bool res = false;

            try
            {
                string temp = JS_CEFBrowser(js, wb);
                bool.TryParse(temp, out res);
            }
            catch (Exception e)
            {
                Debug.WriteLine("谷歌浏览器执行不返回值的JS脚本出错：" + e.ToString());
            }
            return res;
        }
        #endregion



        #region BrowserFrameLoadStart
        /// <summary>
        /// 浏览器开始加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void BrowserFrameLoadStart(object sender, FrameLoadStartEventArgs e)
        {
            ChromiumWebBrowser ww = sender as ChromiumWebBrowser;
            if (e.Frame.IsMain)
            {
                webisok = false;
                //MessageBox.Show("开始加载");
            }
        }
        #endregion

        #region BrowserFrameLoadEnd
        /// <summary>
        /// 加载完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void BrowserFrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {
            ChromiumWebBrowser ww = sender as ChromiumWebBrowser;
            if (e.Frame.IsMain)
            {
                webisok = true;

                //Delay(1000);
                //if (!ww.IsLoading)
                //{
                //    webisok = true;
                //}
                //MessageBox.Show("加载完成");
                //ww.FrameLoadEnd -= BrowserFrameLoadEnd;
                //var task1 = ww.GetSourceAsync();
                //task1.Wait();
                //string html = task1.Result;n


                //CefExtension ce = new CefExtension("", "");
                //MessageBox.Show("加载完成");
                //SetJSFile(ww);
                //Debug.WriteLine("加载完成");

                // Wait for the screenshot to be taken.

                //var task = ww.ScreenshotAsync();
                //ww.RectangleToScreen
                //task.Wait();

                // Make a file to save it to (e.g. C:\Users\jan\Desktop\CefSharp screenshot.png)
                //var screenshotPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "CefSharp screenshot.png");

                //Console.WriteLine();
                //Console.WriteLine("Screenshot ready.  Saving to {0}", screenshotPath);

                // Save the Bitmap to the path.
                // The image type is auto-detected via the ".png" extension.
                //task.Result.Save(screenshotPath);

                // We no longer need the Bitmap.
                // Dispose it to avoid keeping the memory alive.  Especially important in 32-bit applications.
                //task.Result.Dispose();

                //Console.WriteLine("Screenshot saved.  Launching your default image viewer...");

                // Tell Windows to launch the saved image.
                //Process.Start(screenshotPath);

                //Console.WriteLine("Image viewer launched.  Press any key to exit.");
            }
        }
        #endregion

        #region WaitWebPageLoad
        /// <summary>
        /// 判断CefSharp浏览器加载完毕
        /// </summary>
        /// <param name="webBrowser1"></param>
        /// <returns></returns>
        public static bool WaitWebPageLoad(ChromiumWebBrowser webBrowser1)
        {
            //webisok = false;
            try
            {
                //现在时间
                DateTime dt1 = DateTime.Now;
                //超时时间
                int times = 1000 * 60 * 1;
                //webBrowser1.FrameLoadEnd += WebBrowser1_FrameLoadEnd;
                while (true)
                {
                    Delay(50);  //系统延迟50毫秒，够少了吧！
                    if (!webBrowser1.IsLoading)
                    {
                        return true;
                    }
                    //如果网页还在加载
                    while (webBrowser1.IsLoading)
                    {
                        Delay(50);
                        if (dt1.AddMilliseconds(times) < DateTime.Now)
                        {
                            Debug.WriteLine("到时间了，停止运行方法");
                            return false;
                        }
                    }

                }
            }
            catch  
            {
                //Debug.WriteLine(e.ToString());
            }
            finally
            {
                webisok = false;
            }
            return false;
        }
        #endregion

        #region WaitWebPageLoad
        /// <summary>
        /// 判断CefSharp浏览器加载完毕
        /// </summary>
        /// <param name="webBrowser1"></param>
        /// <returns></returns>
        public static bool WaitWebPageLoad(string element, ChromiumWebBrowser webBrowser1)
        {
            return WaitWebPageLoad(element, 1000 * 60 / 2, webBrowser1);
            #region 备注
            //webisok = false;
            //try
            //{
            //    //webBrowser1.FrameLoadEnd += WebBrowser1_FrameLoadEnd;
            //    while (true)
            //    {
            //        Delay(50);  //系统延迟50毫秒，够少了吧！
            //        if (!webBrowser1.IsLoading)
            //        {
            //            //if (webisok) //先判断是否发生完成事件。  
            //            //{
            //            //webisok = false;
            //            while (true)
            //            {
            //                Delay(50);
            //                string temp = JS_CEFBrowser(element + "!=null", webBrowser1);
            //                if (!string.IsNullOrEmpty(temp) && temp == "True")
            //                {
            //                    Debug.WriteLine("找到了" + temp + " " + element);
            //                    return true;
            //                }

            //            }
            //            //}
            //        }
            //        else
            //        {
            //            //如果网页还在加载
            //            while (webBrowser1.IsLoading)
            //            {
            //                Delay(50);
            //            }
            //        }
            //    }
            //}
            //catch (Exception e)
            //{
            //    Debug.WriteLine(e.ToString());
            //}
            //finally
            //{
            //    webisok = false;
            //}
            //return false;
            #endregion

        }
        #endregion

        #region WaitWebPageLoad
        /// <summary>
        /// 找到元素后 并且 览器是否加载完毕
        /// </summary>
        /// <param name="element"></param>
        /// <param name="webBrowser1"></param>
        /// <param name="times"></param>
        /// <returns></returns>
        public static bool WaitWebPageLoadByElement(string element, ChromiumWebBrowser webBrowser1, int times = 60000)
        {
            return WaitWebPageLoad(element, times, webBrowser1);
        }
        /// <summary>
        /// 判断CefSharp浏览器加载完毕
        /// </summary>
        /// <param name="element">HTML元素</param>
        /// <param name="times">多久超时，单位毫秒（千分之一秒）</param>
        /// <param name="webBrowser1"></param>
        /// <returns></returns>
        public static bool WaitWebPageLoad(string element, int times, ChromiumWebBrowser webBrowser1)
        {
            try
            {
                DateTime dt1 = DateTime.Now;
                while (true)
                {
                    #region 2019年7月2日 优化代码：优化先检索Element，然后检索IsLoading，如果超时（大约30秒）则直接返回true,测试结果，速度太快，容易被稽查
                    Delay(200);  //系统延迟50毫秒，够少了吧！
                    string temp = JS_CEFBrowser(element + "!=null", webBrowser1);
                    if (!string.IsNullOrEmpty(temp) && temp.ToLower() == "true")
                    {
                        while (true)
                        {
                            //如果找到，则查看是否IsLoading
                            if (!webBrowser1.IsLoading)
                            {
                                return true;
                            }
                            else
                            {
                                //如果网页还在加载
                                while (webBrowser1.IsLoading)
                                {
                                    Delay(200);
                                    if (dt1.AddMilliseconds(times) < DateTime.Now)
                                    {
                                        Delay(5000);
                                        Debug.WriteLine("到时间了，但是浏览器还在Loading，现在继续程序");
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                    if (dt1.AddMilliseconds(times) < DateTime.Now)
                    {
                        Debug.WriteLine("到时间了，停止运行方法");
                        return false;
                    }

                    #endregion

                    #region 优化前的代码，还是先要判断是否IsLoading ，然后判断是否有Element，优点是准确判断是否还在加载，缺点是有时候浏览器会一直加载，导致程序卡死
                    //Delay(50);  //系统延迟50毫秒，够少了吧！
                    //if (!webBrowser1.IsLoading)
                    //{
                    //    while (true)
                    //    {
                    //        Delay(50);
                    //        string temp = JS_CEFBrowser(element + "!=null", webBrowser1);
                    //        if (!string.IsNullOrEmpty(temp) && temp == "True")
                    //        {
                    //            return true;
                    //        }
                    //        if (dt1.AddMilliseconds(times) < DateTime.Now)
                    //        {
                    //            Debug.WriteLine("到时间了，停止运行方法");
                    //            return false;
                    //        }
                    //    }
                    //}
                    //else
                    //{
                    //    //如果网页还在加载
                    //    while (webBrowser1.IsLoading)
                    //    {
                    //        Delay(50);
                    //        if (dt1.AddMilliseconds(times) < DateTime.Now)
                    //        {
                    //            Debug.WriteLine("到时间了，停止运行方法");
                    //            return false;
                    //        }
                    //    }
                    //}
                    #endregion

                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
            finally
            {
                webisok = false;
            }
            return false;
        }
        #endregion

        #region WaitWebPageLoad2

        /// <summary>
        /// 找到元素后马上返回信息,不考虑浏览器是否加载完毕
        /// </summary>
        /// <param name="element"></param>
        /// <param name="webBrowser1"></param>
        /// <param name="times"></param>
        /// <returns></returns>
        public static bool WaitWebPageLoadByElementFast(string element, ChromiumWebBrowser webBrowser1, int times = 10000)
        {
            return WaitWebPageLoad2(element, times, webBrowser1);
        }

        /// <summary>
        /// 判断CefSharp浏览器加载完毕
        /// </summary>
        /// <param name="element">HTML元素</param>
        /// <param name="times">多久超时，单位毫秒（千分之一秒）默认10秒</param>
        /// <param name="webBrowser1"></param>
        /// <returns></returns>
        public static bool WaitWebPageLoad2(string element, int times, ChromiumWebBrowser webBrowser1)
        {
            try
            {
                DateTime dt1 = DateTime.Now;
                //默认等待10秒
                times = times == 0 ? 10000 : times;
                while (true)
                {
                    //Delay(50);  
                    while (true)
                    {
                        Delay(300);//系统延迟50毫秒，够少了吧！
                        string temp = JS_CEFBrowser(element + "!=null", webBrowser1);
                        if (!string.IsNullOrEmpty(temp) && temp.ToLower() == "true")
                        {
                            return true;
                        }
                        if (dt1.AddMilliseconds(times) < DateTime.Now)
                        {
                            Debug.WriteLine("到时间了，停止运行方法");
                            return false;
                        }
                    }
                }
            }
            catch 
            {
                //Debug.WriteLine(e.ToString());
            }
            finally
            {
                webisok = false;
            }
            return false;
        }
        #endregion

        #region ElementIsNull
        /// <summary>
        /// 判断element是否存在,如果存在返回false
        /// </summary>
        /// <param name="element">HTML元素</param>
        /// <param name="times">多久超时，单位毫秒（千分之一秒）默认10秒</param>
        /// <param name="webBrowser1"></param>
        /// <returns></returns>
        public static bool ElementIsNull(string element, ChromiumWebBrowser webBrowser1)
        {
            string temp = JS_CEFBrowser(element + "!=null", webBrowser1);
            if (!string.IsNullOrEmpty(temp) && temp.ToLower() == "true")
            {
                return false;
            }
            return true;
        }
        #endregion


        #region WaitWebPageLoad2
        /// <summary>
        /// 判断CefSharp浏览器是否有该元素(加载完毕)等待十秒
        /// </summary>
        /// <param name="element">HTML元素</param>
        /// <param name="webBrowser1"></param>
        /// <returns></returns>
        public static bool WaitWebPageLoad2(string element, ChromiumWebBrowser webBrowser1)
        {
            return WaitWebPageLoad2(element, 0, webBrowser1);
        }
        #endregion

        #region MouseLeftByHtmlElement
        /// <summary>
        /// 找到指定元素位置并操纵鼠标点击
        /// </summary>
        /// <param name="webBrowser1">WebBrowser</param>
        /// <returns>返回url，如果没有获取到带参数的url则返回空</returns>
        public static void MouseLeftByHtmlElement(string element, ChromiumWebBrowser webBrowser1)
        {
            string temp = JS_CEFBrowser(element + "!=null", webBrowser1);
            if (!string.IsNullOrEmpty(temp) && temp == "True")
            {
                MouseMoveByHtmlElement(element, webBrowser1);
                Browser.Delay(200);
                Auto.Mouse_Left();

            }
        }
        #endregion

        #region MouseLeftByHtmlElement
        /// <summary>
        /// 找到指定元素位置并操纵鼠标点击-双击
        /// </summary>
        /// <param name="webBrowser1">WebBrowser</param>
        /// <param name="isdouble">双击</param>
        /// <returns>返回url，如果没有获取到带参数的url则返回空</returns>
        public static void MouseLeftByHtmlElement(string element, ChromiumWebBrowser webBrowser1, bool isdouble)
        {
            MouseLeftByHtmlElement(element, webBrowser1);
            if (isdouble)
            {
                Browser.Delay(200);
                Auto.Mouse_Left();
            }
        }
        #endregion

        #region MouseLeftByHtmlElement
        /// <summary>
        /// 找到指定元素指定位置并操纵鼠标点击
        /// </summary>
        /// <param name="element"></param>
        /// <param name="x">元素中X坐标</param>
        /// <param name="y">元素中Y坐标</param>
        /// <param name="webBrowser1">返回url，如果没有获取到带参数的url则返回空</param>
        public static void MouseLeftByHtmlElement(string element, int x, int y, ChromiumWebBrowser webBrowser1)
        {
            string temp = JS_CEFBrowser(element + "!=null", webBrowser1);
            if (!string.IsNullOrEmpty(temp) && temp == "True")
            {
                MouseMoveByHtmlElement(element, x, y, webBrowser1);
                Auto.Mouse_Left();
            }
        }
        #endregion

        #region MouseLeftByHtmlElement_Wait
        /// <summary>
        /// 等待元素出现后，找到指定元素位置并操纵鼠标点击
        /// </summary>
        /// <param name="element">HTML元素</param>
        /// <param name="webBrowser1">WebBrowser</param>
        /// <returns>bool是否成功</returns>
        public static bool MouseLeftByHtmlElement_Wait(string element, ChromiumWebBrowser webBrowser1)
        {
            bool res = true;
            try
            {
                if (WaitWebPageLoad(element, webBrowser1))
                {
                    MouseMoveByHtmlElement(element, webBrowser1);
                    Auto.Mouse_Left();
                }
            }
            catch
            {
                res = false;
            }
            return res;
        }
        #endregion

        #region MouseMoveByHtmlElement
        /// <summary>
        /// 移动到指定元素位置并居中显示
        /// </summary>
        /// <param name="webBrowser1">WebBrowser</param>
        /// <returns>返回url，如果没有获取到带参数的url则返回空</returns>
        public static void MouseMoveByHtmlElement(string element, ChromiumWebBrowser webBrowser1)
        {
            Point p = new Point();
            try
            {
                //在电脑屏幕中的位置
                p = GetPointScreenByHtmlElement(element, webBrowser1);
                if (!p.IsEmpty)
                {
                    /*
                    //在浏览器中的位置
                    Point temp_p = GetPointBrowserByHtmlElement(element, webBrowser1);
                    //获取浏览器高度
                    int webheight = webBrowser1.Height;
                    //获取滚动条被卷去的高度
                    int temp_scroll_height = Convert.ToInt32(JS_CEFBrowser("document.body.scrollTop", webBrowser1));
                    //获取元素高度
                    //JS_CEFBrowser_NoReturn("alert(" + element + ".clientHeight" + ")", webBrowser1);
                    string height = JS_CEFBrowser(element + ".clientHeight;", webBrowser1);
                    int h = 0;
                    if (int.TryParse(height, out h))
                    {
                        h = h / 2;
                    }

                    /*新增宽度居中
                    //获取浏览器宽度
                    int webwidth = webBrowser1.Width;
                    //获取滚动条被卷去的高度
                    int temp_scroll_width = Convert.ToInt32(JS_CEFBrowser("document.body.scrollLeft", webBrowser1));
                    //获取元素高度
                    //JS_CEFBrowser_NoReturn("alert(" + element + ".clientHeight" + ")", webBrowser1);
                    string width = JS_CEFBrowser(element + ".clientWidth;", webBrowser1);
                    int w = 0;
                    if (int.TryParse(width, out w))
                    {
                        w = w / 2;
                    }

                    //设置浏览器滑动条的高度：位置居中
                    //webBrowser1.Document.Window.ScrollTo(0, temp_scroll_height + temp_p.Y - webheight / 2);
                    //JS_CEFBrowser_NoReturn("window.scrollTo(0, " + (temp_scroll_height + temp_p.Y - webheight / 2 + h).ToString() + ")", webBrowser1);
                    JS_CEFBrowser_NoReturn("window.scrollTo(" + (temp_scroll_width + temp_p.X - webwidth / 2 + w).ToString() + ", " + (temp_scroll_height + temp_p.Y - webheight / 2 + h).ToString() + ")", webBrowser1);*/
                    SetScrollByHtmlElement(element, webBrowser1);
                    Browser.Delay(100);
                    //获取元素在屏幕中的坐标
                    p = GetPointScreenByHtmlElement(element, webBrowser1);
                    //获取元素面积内的随机坐标，模仿真实点击
                    p.Offset(Point_FuYu(element, webBrowser1));
                    //p.Offset(Manager.point_fuyu);
                    //移动鼠标
                    Cursor.Position = p;
                    //Delay(3000);
                    //点击左键
                    //Auto.Mouse_Left();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("MouseLeftByHtmlElement方法错误");
                Debug.WriteLine("错误原因：" + ex.Message);
            }
        }
        #endregion

        #region MouseMoveByHtmlElement
        /// <summary>
        /// 移动到指定元素位置并居中显示
        /// </summary>
        /// <param name="webBrowser1">WebBrowser</param>
        /// <returns>返回url，如果没有获取到带参数的url则返回空</returns>
        public static void MouseMoveByHtmlElement(string element, int x, int y, ChromiumWebBrowser webBrowser1)
        {
            Point p = new Point();
            try
            {
                //在电脑屏幕中的位置
                p = GetPointScreenByHtmlElement(element, webBrowser1);
                if (!p.IsEmpty)
                {
                    SetScrollByHtmlElement(element, webBrowser1);
                    Browser.Delay(100);
                    //获取元素在屏幕中的坐标
                    p = GetPointScreenByHtmlElement(element, webBrowser1);
                    //获取元素面积内的随机坐标，模仿真实点击
                    p.Offset(new Point(x, y));
                    //移动鼠标
                    Cursor.Position = p;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("MouseLeftByHtmlElement方法错误");
                Debug.WriteLine("错误原因：" + ex.Message);
            }
        }
        #endregion

        #region GetPointScreenByHtmlElement
        /// <summary>
        /// 获取Web元素，在屏幕中的坐标
        /// </summary>
        /// <param name="element">获取Web元素，例如：getElementsByDataSpm('d58')[0]</param>
        /// <param name="webBrowser1">WebBrowser</param>
        /// <returns>Point，如果出错则显示为IsEmpty</returns>
        public static Point GetPointScreenByHtmlElement(string element, ChromiumWebBrowser webBrowser1)
        {
            Point res = new Point();
            Point p_web = GetPointBrowserByHtmlElement(element, webBrowser1);
            if (!p_web.IsEmpty)
            {
                res = webBrowser1.PointToScreen(new Point(0, 0));
                res.Offset(p_web);
            }
            return res;
        }
        #endregion

        #region GetPointBrowserByHtmlElement
        /// <summary>
        /// 获取Web元素，在浏览器中的坐标
        /// </summary>
        /// <param name="element">获取Web元素，例如：getElementsByDataSpm('d58')[0]</param>
        /// <param name="webBrowser1">WebBrowser</param>
        /// <returns>Point</returns>
        public static Point GetPointBrowserByHtmlElement(string element, ChromiumWebBrowser webBrowser1)
        {
            Point res = new Point();
            int x = 0;
            int y = 0;
            string temp = "";
            //int temp_fuyu = 5;
            try
            {
                temp = JS_CEFBrowser(element + "!=null", webBrowser1);
                if (!string.IsNullOrEmpty(temp) && temp == "True")
                {
                    string temp_x = JS_CEFBrowser(" getAbsoluteOffsetLeft(" + element + "); ", webBrowser1);
                    //string temp_x2 = JS_WebBrowser(" document.body.scrollTop; ", webBrowser1);
                    string temp_y = JS_CEFBrowser(" getAbsoluteOffsetTop(" + element + ")-document.body.scrollTop;", webBrowser1);
                    if (int.TryParse(temp_x, out x) && int.TryParse(temp_y, out y))
                    {
                        res = new Point(x, y);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("获取网页中的元素位置失败");
                Debug.WriteLine("错误原因：" + ex.Message);
            }
            return res;
        }
        #endregion

        #region Point_FuYu
        /// <summary>
        /// 根据元素获取，模拟鼠标点击的指针
        /// </summary>
        /// <param name="element"></param>
        /// <param name="webBrowser1"></param>
        /// <returns></returns>
        public static Point Point_FuYu(string element, ChromiumWebBrowser webBrowser1)
        {
            Point res = new Point();
            string x = JS_CEFBrowser(element + ".offsetWidth;", webBrowser1);
            string y = JS_CEFBrowser(element + ".offsetHeight;", webBrowser1);
            int xx = 0;
            int yy = 0;
            if (int.TryParse(x, out xx) && int.TryParse(y, out yy))
            {
                if (xx > 1 && yy > 1)
                {
                    //res = new Point(Manager.RandomNumber(1, xx - 1), Manager.RandomNumber(1, yy - 1));
                    res = new Point(Manager.RandomNumber(xx / 4, xx / 2), Manager.RandomNumber(yy / 4, yy / 2));
                }

            }
            return res;
        }
        #endregion

        #region WaitJS
        /// <summary>
        /// 只有js的返回值为ture时，才继续处理以后的代码
        /// </summary>
        /// <param name="js">判断的js代码是否为ture</param>
        /// <param name="webBrowser1">web浏览器控件</param>
        /// <returns></returns>
        public static bool WaitJS(string js, ChromiumWebBrowser webBrowser1)
        {
            //判断元素存在后，返回true
            while (true)
            {
                Delay(50);
                string temp = JS_CEFBrowser(js, webBrowser1);
                if (!string.IsNullOrEmpty(temp))
                {
                    if (temp.ToLower() == "true")
                    {
                        Debug.WriteLine("找到了" + temp + " " + js);
                        return true;
                    }
                }
            }
        }
        #endregion

        #region SetScrollByHtmlElement
        /// <summary>
        /// 找到指定元素位置并在浏览器中居中显示
        /// </summary>
        /// <param name="webBrowser1">WebBrowser</param>
        /// <returns></returns>
        public static void SetScrollByHtmlElement(string element, ChromiumWebBrowser webBrowser1)
        {
            try
            {
                //在浏览器中的位置
                Point temp_p = GetPointBrowserByHtmlElement(element, webBrowser1);
                //获取浏览器高度
                int webheight = webBrowser1.Height;
                //获取滚动条被卷去的高度
                int temp_scroll_height = Convert.ToInt32(JS_CEFBrowser("document.body.scrollTop", webBrowser1));
                //获取元素高度
                //JS_CEFBrowser_NoReturn("alert(" + element + ".clientHeight" + ")", webBrowser1);
                string height = JS_CEFBrowser(element + ".clientHeight;", webBrowser1);
                int h = 0;
                if (int.TryParse(height, out h))
                {
                    h = h / 2;
                }

                /*新增宽度居中*/
                //获取浏览器宽度
                int webwidth = webBrowser1.Width;
                //获取滚动条被卷去的高度
                int temp_scroll_width = Convert.ToInt32(JS_CEFBrowser("document.body.scrollLeft", webBrowser1));
                //获取元素高度
                //JS_CEFBrowser_NoReturn("alert(" + element + ".clientHeight" + ")", webBrowser1);
                string width = JS_CEFBrowser(element + ".clientWidth;", webBrowser1);
                int w = 0;
                if (int.TryParse(width, out w))
                {
                    w = w / 2;
                }

                //设置浏览器滑动条的高度：位置居中
                //webBrowser1.Document.Window.ScrollTo(0, temp_scroll_height + temp_p.Y - webheight / 2);
                //JS_CEFBrowser_NoReturn("window.scrollTo(0, " + (temp_scroll_height + temp_p.Y - webheight / 2 + h).ToString() + ")", webBrowser1);
                JS_CEFBrowser_NoReturn("window.scrollTo(" + (temp_scroll_width + temp_p.X - webwidth / 2 + w).ToString() + ", " + (temp_scroll_height + temp_p.Y - webheight / 2 + h).ToString() + ")", webBrowser1);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("SetScrollByHtmlElement方法错误");
                Debug.WriteLine("错误原因：" + ex.Message);
            }
        }
        #endregion

        #region SetScroll
        /// <summary>
        /// 设置浏览器滚动条位置
        /// </summary>
        /// <param name="x">X坐标</param>
        /// <param name="y">Y坐标</param>
        /// <param name="webBrowser1">谷歌浏览器</param>
        public static void SetScroll(int x, int y, ChromiumWebBrowser webBrowser1)
        {
            Browser.JS_CEFBrowser_NoReturn("window.scrollTo(" + x.ToString() + "," + y.ToString() + ");", webBrowser1);
        }
        #endregion


        #region GetWebBrowser
        /// <summary>
        /// 将webBrowser1中的Session、Cookie等信息赋予webBrowser2中
        /// </summary>
        /// <param name="webBrowser1">原始信息webBrowser</param>
        /// <param name="webBrowser2"></param>
        /// <returns>是否赋值成功</returns>
        public static bool GetWebBrowser(ChromiumWebBrowser webBrowser1, ChromiumWebBrowser webBrowser2)
        {
            bool isok = true;
            try
            {
                webBrowser2 = webBrowser1;
                //webBrowser2.ScriptErrorsSuppressed = true;
                //webBrowser2.DocumentStream = webBrowser1.DocumentStream;
                //webBrowser2.Document.Cookie = webBrowser1.Document.Cookie;
                //webBrowser2.Url = webBrowser1.Url;
            }
            catch
            {
                isok = false;
            }
            return isok;
        }
        #endregion


        #region SetJSFile
        /// <summary>
        /// 添加JS文件
        /// </summary>
        /// <param name="webBrowser1">WebBrowser</param>
        public static void SetJSFile(ChromiumWebBrowser webBrowser1)
        {
            string res = "";

            try
            {
                string js_fun = GetJSFile();
                Task<CefSharp.JavascriptResponse> task = webBrowser1.EvaluateScriptAsync(js_fun);
                task.Wait();
                if (task.Result.Result != null)
                {
                    res = task.Result.Result.ToString();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("谷歌浏览器执行不返回值的JS脚本出错：" + e.ToString());
            }
        }
        #endregion

        #region  BoolByHtmlElement
        /// <summary>
        /// 判断是否有该元素
        /// </summary>
        /// <param name="str"></param>
        /// <param name="webBrowser1"></param>
        /// <returns></returns>
        public static bool BoolByHtmlElement(string element, ChromiumWebBrowser webBrowser1)
        {
            bool res = false;
            //str = str.Trim();
            string temp = JS_CEFBrowser(element + "!=null", webBrowser1);
            if (!string.IsNullOrEmpty(temp) && temp == "True")
            {
                res = true;
            }
            //string temp = Browser.JS_CEFBrowser(str + ".length", webBrowser1);
            //if (temp != "0")
            //{
            //    res = true;
            //}
            return res;
        }
        #endregion


        #region OptionSearchIndex
        /// <summary>
        /// 遍历查找option的index,使用时-1，返回0则没有找到哦
        /// </summary>
        /// <param name="jss">例如：select元素：document.getElementsByName('cloudWlbSlt')[0]</param>
        /// <param name="count">需要遍历多少个</param>
        /// <param name="res">对比option的显示内容，例如：韵达</param>
        /// <param name="wb">ChromiumWebBrowser</param>
        /// <returns>结果+1</returns>
        public static int OptionSearchIndex(string jss, int count, string res, ChromiumWebBrowser wb)
        {
            int i = 0;
            for (i = 0; i < count; i++)
            {
                string temp = Browser.JS_CEFBrowser(jss + ".getElementsByTagName('option')[" + i.ToString() + "].innerText", wb);
                if (temp.IndexOf(res) != -1)
                {
                    //找到了
                    return i + 1;
                }
            }
            return i;
        }
        #endregion

        #region OptionSetSeleted
        /// <summary>
        /// 遍历查找option的并选中
        /// </summary>
        /// <param name="jss">例如：select元素：document.getElementsByName('cloudWlbSlt')[0]</param>
        /// <param name="count">需要遍历多少个</param>
        /// <param name="res">对比option的显示内容，例如：韵达</param>
        /// <param name="wb">ChromiumWebBrowser</param>
        /// <returns>结果+1</returns>
        public static void OptionSetSeleted(string jss, int count, string res, ChromiumWebBrowser wb)
        {
            int temp = OptionSearchIndex(jss, count, res, wb);
            string js = jss + ".getElementsByTagName('option')[" + (temp - 1).ToString() + "].selected =true;";
            Browser.JS_CEFBrowser_NoReturn(js, wb);
        }
        #endregion

        #region ClearContext
        /// <summary>
        /// 清空缓存
        /// </summary>
        /// <param name="wb"></param>
        public static void ClearContext(ChromiumWebBrowser wb)
        {
            try
            {
                //wb.RequestContext.Dispose();
                wb.RequestContext = new CefSharp.RequestContext();
            }
            catch { }
        }
        #endregion

        #region SaveHtml

        /// <summary>
        /// 保存页面
        /// </summary>
        /// <param name="wb"></param>
        public static void SaveHtml(ChromiumWebBrowser wb)
        {
            //string html = webBrowser1.RequestContext.ToString();
            string html = Browser.JS_CEFBrowser("document.body.innerHTML", wb);
            //// 创建文件
            //System.IO.FileStream fs = new FileStream("test.doc", FileMode.OpenOrCreate, FileAccess.ReadWrite); //可以指定盘符，也可以指定任意文件名，还可以为word等文件
            //StreamWriter sw = new StreamWriter(fs); // 创建写入流
            //sw.WriteLine("bob hu"); // 写入Hello World
            //sw.Close(); //关闭文件
            string path = "d:\\html" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";
            CS.FileHelper.Write(path, html);
            System.Diagnostics.Process.Start(path);
        }
        #endregion


        /// <summary>
        /// 获取图像内容
        /// </summary>
        /// <param name="browser">显示图像的浏览器控件</param>
        /// <param name="imgElement">从浏览器中读取到的img</param>
        public static Image GetImage2(WebBrowser browser, HtmlElement imgElement)
        {

            //HTMLDocument doc = (HTMLDocument)"";

            //js方法
            //string javaScriptCode = "";
            //javaScriptCode = "var div = document.getElementById('img'); div.contentEditable ='true'; var controlRange;if(document.body.createControlRange) {controlRange= document.body.createControlRange(); controlRange.addElement(div);controlRange.execCommand('Copy'); } div.contentEditable = 'false';";
            //ie.RunScript(javaScriptCode);




            //webbrowser方法 缓存
            HTMLDocument doc = (HTMLDocument)browser.Document.DomDocument;
            HTMLBody body = (HTMLBody)doc.body;
            IHTMLControlRange rang = (IHTMLControlRange)body.createControlRange();
            IHTMLControlElement img = (IHTMLControlElement)(imgElement.DomElement);
            rang.add(img);
            rang.execCommand("Copy", false, null);
            Image regImg = Clipboard.GetImage();
            Clipboard.Clear();
            return regImg;

            //webbrowser方法 缓存2
            //foreach (SHDocVw.InternetExplorer Browse in shellWindows)
            //{
            //    // filename = Path.GetFileNameWithoutExtension(Browse.FullName).ToLower();
            //    if (Browse.LocationURL.Contains("http://***********"))
            //    {

            //        Doc = Browse.Document as mshtml.IHTMLDocument2;
            //        mshtml.IHTMLControlElement item;
            //        HTMLBody body = (HTMLBody)Doc.body;
            //        mshtml.IHTMLControlRange range = (IHTMLControlRange)body.createControlRange();
            //        //if (Doc.domain == "http://************")
            //        //{

            //        all = Doc.all;
            //        element = all.item("image1", null) as mshtml.IHTMLElement;//不报错 ，但是element 无法实例化，，空的，，
            //                                                                  // element.click(); //模拟鼠标点击动作
            //                                                                  //System.Threading.Thread.Sleep(1000); //暂停1秒等ie响应
            //        item = all.item("image1", null) as mshtml.IHTMLControlElement;//不报错 ，但是item 无法实例化，，空的，，
            //        System.Threading.Thread.Sleep(1000);//
            //        range.add(item);
            //        range.execCommand("Copy", false, null);
            //        Img = new Bitmap(Clipboard.GetImage()); //从剪切板中获取验证码图片
            //        Clipboard.Clear();
            //        // }
            //    }
            //}
        }

        #endregion




    }
}
