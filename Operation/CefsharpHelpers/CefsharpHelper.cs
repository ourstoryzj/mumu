using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Operation.CefsharpHelpers
{
    public class CefsharpHelper
    {
        private string url = string.Empty;
        private Random random = new Random((int)DateTime.Now.ToFileTimeUtc());
        public ChromiumWebBrowser browser = null;
        public Image codeImage = null;
        private bool isCapture = false;

        #region 初始功能

        public void Init()
        {
            if (!Cef.IsInitialized)
            {
                var setting = new CefSharp.CefSettings();
                setting.RegisterScheme(new CefCustomScheme
                {
                    SchemeName = CefSharpSchemeHandlerFactory.SchemeName,
                    SchemeHandlerFactory = new CefSharpSchemeHandlerFactory()
                });

                // 设置语言
                setting.Locale = "zh-CN"; // en-US
                Cef.Initialize(setting);
                // CefSharp.Cef.Initialize(setting, true, false);
            }
        }


        /// <summary>
        /// 设置代理
        /// </summary>
        /// <param name="ProxyAddress"></param>
        public void Init(string ProxyAddress)
        {
            if (!Cef.IsInitialized)
            {
                var setting = new CefSharp.CefSettings();
                setting.RegisterScheme(new CefCustomScheme
                {
                    SchemeName = CefSharpSchemeHandlerFactory.SchemeName,
                    SchemeHandlerFactory = new CefSharpSchemeHandlerFactory()
                });
                setting.CachePath = "cache";//设置代理
                setting.CefCommandLineArgs.Add("proxy-server", ProxyAddress);//设置代理
                // 设置语言
                setting.Locale = "zh-CN"; // en-US
                Cef.Initialize(setting);
                // CefSharp.Cef.Initialize(setting, true, false);
            }
        }

        /// <summary>
        /// 操作构造函数
        /// </summary>
        /// <param name="url"></param>
        public CefsharpHelper(string url)
        {
            this.url = url;
        }

        public void ReLoad()
        {
            this.browser.Reload();
        }

        /// <summary>
        /// 初始化浏览器信息
        /// </summary>
        /// <returns></returns>
        public ChromiumWebBrowser CreateBrowser()
        {
            browser = new ChromiumWebBrowser(this.url);
            var requestHandler = new RequestHandler();
            //requestHandler.NotifyResult += requestHandler_NotifyResult;
            //browser.RequestHandler = requestHandler;
            //browser.LifeSpanHandler = new LifeSpanHandler();
            //browser.DownloadHandler = new DownloadHandler();
            browser.Dock = System.Windows.Forms.DockStyle.Fill;
            CefSharpSettings.ShutdownOnExit = true;

            return browser;
        }

        public void StartCapture()
        {
            isCapture = true;
        }

        public void StopCapture()
        {
            isCapture = false;
        }

        private void requestHandler_NotifyResult(string guid, string url, NameValueCollection request, NameValueCollection response, byte[] data)
        {
            if (isCapture)
            {
                LoadHelper.AddInfo(new LoadInfo()
                {
                    Key = guid,
                    Url = url,
                    RequestHeader = request,
                    ResponseHeader = response,
                    Data = data
                });
            }
        }

        private void NotifyImage(Image obj)
        {
            this.codeImage = obj;
        }

        public void Win32_Click(Point click_p)
        {
            // 1024*768的分辨率下
            var p = this.browser.PointToScreen(click_p);
            p = new Point() { X = p.X, Y = p.Y };
            Win32Api.MouseClick(p);
        }

        public void Win32_Write(string str)
        {
            Win32Api.KeyDownString(str);
        }

        public void Win32_WriteChs(string str)
        {
            // ^c+^v实现中文的输入         
            Clipboard.SetText(str);    // 将字符串复制到剪贴板，相当于^c

            Thread.Sleep(200);
            SendKeys.SendWait("^v");   // CTRL+V，粘贴
        }

        public void SendMainFrameJs(string js)
        {
            if (browser != null)
            {
                browser.GetBrowser().MainFrame.ExecuteJavaScriptAsync(js);
            }
        }

        public void SendOtherFrameJs(string frameName, string js)
        {
            if (browser != null)
            {
                IFrame frame = browser.GetBrowser().GetFrame(frameName);
                if (frame != null)
                {
                    frame.ExecuteJavaScriptAsync(js);
                }
            }
        }

        /// <summary>
        /// 跳转页面
        /// </summary>
        /// <param name="url"></param>
        public void JumpUrl(string url)
        {
            browser.Load(url);
        }

        public void Back()
        {
            browser.Back();
        }

        public void Forward()
        {
            browser.Forward();
        }

        public Point GetBrowserPoint()
        {
            return this.browser.PointToScreen(new Point(0, 0));
        }

        public void ClearCookie()
        {
            if (browser != null)
            {
                var cookieManager = Cef.GetGlobalCookieManager();

                // 都为空，清楚所有的cookie
                cookieManager.DeleteCookiesAsync("", "");
            }
        }

        public void Dispose()
        {
            try
            {
                if (browser != null)
                {
                    browser.GetBrowser().CloseBrowser(true);
                    browser.Dispose();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }


        /// <summary>
        /// 设置cookie
        /// </summary>
        /// <param name="domain">主机，例如：mobile.yangkeduo.com</param>
        /// <param name="name">cookie名称</param>
        /// <param name="value">值</param>
        public void SetCookies(string domain, string name, string value)
        {
            var cookieManager = CefSharp.Cef.GetGlobalCookieManager();
            cookieManager.SetCookieAsync("http://" + domain, new CefSharp.Cookie()
            {
                Domain = domain,
                Name = name,
                Value = value,
                Expires = DateTime.MinValue
            });
        }

        /// <summary>
        /// 调用F12 审查元素功能
        /// </summary>
        public void ShowTools()
        {
            browser.ShowDevTools();

        }

        /// <summary>
        /// 隔离Cookie
        /// </summary>
        public void IsolationCookie()
        {
            RequestContextSettings requestContextSettings = new RequestContextSettings();
            requestContextSettings.PersistSessionCookies = false;
            requestContextSettings.PersistUserPreferences = false;

            //string BaseUrl = "www.baidu.com";
            //web = new ChromiumWebBrowser(BaseUrl);
            browser.RequestContext = new RequestContext(requestContextSettings);
        }


        public void SetHeader()
        {
            Dictionary<string, string> header = new Dictionary<string, string>();
            //header.Add("Referer", "http://www.nuoren365.com/");
            //header.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/69.0.3497.100 Safari/537.36");
            //header.Add("User-Agent", "Apple Iphone 5");
            header.Add("User-Agent", "Android");
            header.Add("Accept-Language", "zh-CN,zh;q=0.9,en;q=0.8");
            header.Add("ourstoryzj", "ok");
            //header.Add("Referer", "http://www.nuoren365.com/");
            CefsharpHelpers.RequestHandler.headerDic = header;
        }
        #endregion


        #region 添加功能

        #region Delay
        /// <summary>
        /// 延迟系统时间，但系统又能同时能执行其它任务； 
        /// </summary>
        /// <param name="Millisecond">毫秒数</param>
        public void Delay(int Millisecond) //延迟系统时间，但系统又能同时能执行其它任务；  
        {
            DateTime current = DateTime.Now;
            while (current.AddMilliseconds(Millisecond) > DateTime.Now)
            {
                Application.DoEvents();//转让控制权              
            }
            return;
        }
        #endregion

        #region GetJSFile

        /// <summary>
        /// 获取JS文件内容
        /// </summary>
        /// <returns></returns>
        public string GetJSFile()
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
                //////Debug.WriteLine("获取JS文件出错：" + e.ToString());
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
        public Point Point_FuYu(string element)
        {
            Point res = new Point();
            string x = JS_CEFBrowser(element + ".offsetWidth;");
            string y = JS_CEFBrowser(element + ".offsetHeight;");
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


        #region JS_CEFBrowser
        public string JS_CEFBrowser(string js)
        {

            string res = "";

            try
            {
                js = js.Trim();
                string js_fun = GetJSFile();
                //string js_fun = "";
                Task<CefSharp.JavascriptResponse> task = browser.EvaluateScriptAsync(js_fun + " " + js);
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
                //                ////Debug.WriteLine("谷歌浏览器执行不返回值的JS脚本出错2：" + ex.ToString());
                //            }
                //        }
                //    }
                //}, TaskScheduler.FromCurrentSynchronizationContext());
            }
            catch (Exception e)
            {
                //////Debug.WriteLine("谷歌浏览器执行不返回值的JS脚本出错：" + e.ToString());

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
        public int JS_CEFBrowserToInt(string js)
        {

            int res = 0;

            try
            {
                string temp = JS_CEFBrowser(js);
                if (int.TryParse(temp, out res))
                {

                }
            }
            catch (Exception e)
            {
                //////Debug.WriteLine("谷歌浏览器执行不返回值的JS脚本出错：" + e.ToString());
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
        public decimal JS_CEFBrowserToDecimal(string js)
        {

            decimal res = 0;

            try
            {
                string temp = JS_CEFBrowser(js);
                temp = temp.Replace("%", "");
                temp = temp.Replace(",", "");
                if (decimal.TryParse(temp, out res))
                {

                }
            }
            catch (Exception e)
            {
                //////Debug.WriteLine("谷歌浏览器执行不返回值的JS脚本出错：" + e.ToString());
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
        public DateTime JS_CEFBrowserToDate(string js)
        {
            DateTime res = new DateTime();
            string temp = JS_CEFBrowser(js);
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
        public bool JS_CEFBrowserHasElementToBool(string element)
        {

            bool res = false;

            try
            {
                string temp = JS_CEFBrowser(element + "!=null");
                if (!string.IsNullOrEmpty(temp) && temp == "True")
                {
                    return true;
                }

            }
            catch (Exception e)
            {
                //////Debug.WriteLine("谷歌浏览器执行不返回值的JS脚本出错：" + e.ToString());
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
        public bool JS_CEFBrowserToBool(string js)
        {

            bool res = false;

            try
            {
                string temp = JS_CEFBrowser(js);
                bool.TryParse(temp, out res);
            }
            catch (Exception e)
            {
                //////Debug.WriteLine("谷歌浏览器执行不返回值的JS脚本出错：" + e.ToString());
            }
            return res;
        }
        #endregion


        #region WaitWebPageLoad
        /// <summary>
        /// 判断CefSharp浏览器加载完毕
        /// </summary>
        /// <param name="webBrowser1"></param>
        /// <returns></returns>
        public bool WaitWebPageLoad()
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
                    if (!browser.IsLoading)
                    {
                        return true;
                    }
                    //如果网页还在加载
                    while (browser.IsLoading)
                    {
                        Delay(50);
                        if (dt1.AddMilliseconds(times) < DateTime.Now)
                        {
                            //.WriteLine("到时间了，停止运行方法");
                            return false;
                        }
                    }

                }
            }
            catch
            {
                //////Debug.WriteLine(e.ToString());
            }
            finally
            {
                //webisok = false;
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
        public bool WaitWebPageLoad(string element)
        {
            return WaitWebPageLoad(element, 1000 * 60 / 2);
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
            //                string temp = JS_CEFBrowser(element + "!=null");
            //                if (!string.IsNullOrEmpty(temp) && temp == "True")
            //                {
            //                    ////Debug.WriteLine("找到了" + temp + " " + element);
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
            //    ////Debug.WriteLine(e.ToString());
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
        public bool WaitWebPageLoadByElement(string element, int times = 60000)
        {
            return WaitWebPageLoad(element, times);
        }
        /// <summary>
        /// 判断CefSharp浏览器加载完毕
        /// </summary>
        /// <param name="element">HTML元素</param>
        /// <param name="times">多久超时，单位毫秒（千分之一秒）</param>
        /// <param name="webBrowser1"></param>
        /// <returns></returns>
        public bool WaitWebPageLoad(string element, int times)
        {
            try
            {
                DateTime dt1 = DateTime.Now;
                while (true)
                {
                    #region 2019年7月2日 优化代码：优化先检索Element，然后检索IsLoading，如果超时（大约30秒）则直接返回true,测试结果，速度太快，容易被稽查
                    Delay(200);  //系统延迟50毫秒，够少了吧！
                    string temp = JS_CEFBrowser(element + "!=null");
                    if (!string.IsNullOrEmpty(temp) && temp.ToLower() == "true")
                    {
                        while (true)
                        {
                            //如果找到，则查看是否IsLoading
                            if (!browser.IsLoading)
                            {
                                return true;
                            }
                            else
                            {
                                //如果网页还在加载
                                while (browser.IsLoading)
                                {
                                    Delay(200);
                                    if (dt1.AddMilliseconds(times) < DateTime.Now)
                                    {
                                        Delay(5000);
                                        //////Debug.WriteLine("到时间了，但是浏览器还在Loading，现在继续程序");
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                    if (dt1.AddMilliseconds(times) < DateTime.Now)
                    {
                        //////Debug.WriteLine("到时间了，停止运行方法");
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
                    //        string temp = JS_CEFBrowser(element + "!=null");
                    //        if (!string.IsNullOrEmpty(temp) && temp == "True")
                    //        {
                    //            return true;
                    //        }
                    //        if (dt1.AddMilliseconds(times) < DateTime.Now)
                    //        {
                    //            ////Debug.WriteLine("到时间了，停止运行方法");
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
                    //            ////Debug.WriteLine("到时间了，停止运行方法");
                    //            return false;
                    //        }
                    //    }
                    //}
                    #endregion

                }
            }
            catch (Exception e)
            {
                //////Debug.WriteLine(e.ToString());
            }
            finally
            {
                //webisok = false;
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
        public bool WaitWebPageLoadByElementFast(string element, int times = 10000)
        {
            return WaitWebPageLoad2(element, times);
        }

        /// <summary>
        /// 判断CefSharp浏览器加载完毕
        /// </summary>
        /// <param name="element">HTML元素</param>
        /// <param name="times">多久超时，单位毫秒（千分之一秒）默认10秒</param>
        /// <param name="webBrowser1"></param>
        /// <returns></returns>
        public bool WaitWebPageLoad2(string element, int times)
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
                        string temp = JS_CEFBrowser(element + "!=null");
                        if (!string.IsNullOrEmpty(temp) && temp.ToLower() == "true")
                        {
                            return true;
                        }
                        if (dt1.AddMilliseconds(times) < DateTime.Now)
                        {
                            //////Debug.WriteLine("到时间了，停止运行方法");
                            return false;
                        }
                    }
                }
            }
            catch
            {
                //////Debug.WriteLine(e.ToString());
            }
            finally
            {
                //webisok = false;
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
        public bool ElementIsNull(string element)
        {
            string temp = JS_CEFBrowser(element + "!=null");
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
        public bool WaitWebPageLoad2(string element)
        {
            return WaitWebPageLoad2(element, 0);
        }
        #endregion


        #region MouseLeftByHtmlElement
        /// <summary>
        /// 找到指定元素位置并操纵鼠标点击
        /// </summary>
        /// <param name="webBrowser1">WebBrowser</param>
        /// <returns>返回url，如果没有获取到带参数的url则返回空</returns>
        public void MouseLeftByHtmlElement(string element)
        {
            string temp = JS_CEFBrowser(element + "!=null");
            if (!string.IsNullOrEmpty(temp) && temp == "True")
            {
                MouseMoveByHtmlElement(element);
                Delay(200);
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
        public void MouseLeftByHtmlElement(string element, bool isdouble)
        {
            MouseLeftByHtmlElement(element);
            if (isdouble)
            {
                Delay(200);
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
        public void MouseLeftByHtmlElement(string element, int x, int y)
        {
            string temp = JS_CEFBrowser(element + "!=null");
            if (!string.IsNullOrEmpty(temp) && temp == "True")
            {
                MouseMoveByHtmlElement(element, x, y);
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
        public bool MouseLeftByHtmlElement_Wait(string element)
        {
            bool res = true;
            try
            {
                if (WaitWebPageLoad(element))
                {
                    MouseMoveByHtmlElement(element);
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
        public void MouseMoveByHtmlElement(string element)
        {
            Point p = new Point();
            try
            {
                //在电脑屏幕中的位置
                p = GetPointScreenByHtmlElement(element);
                if (!p.IsEmpty)
                {
                    /*
                    //在浏览器中的位置
                    Point temp_p = GetPointBrowserByHtmlElement(element);
                    //获取浏览器高度
                    int webheight = webBrowser1.Height;
                    //获取滚动条被卷去的高度
                    int temp_scroll_height = Convert.ToInt32(JS_CEFBrowser("document.body.scrollTop"));
                    //获取元素高度
                    //JS_CEFBrowser_NoReturn("alert(" + element + ".clientHeight" + ")");
                    string height = JS_CEFBrowser(element + ".clientHeight;");
                    int h = 0;
                    if (int.TryParse(height, out h))
                    {
                        h = h / 2;
                    }

                    /*新增宽度居中
                    //获取浏览器宽度
                    int webwidth = webBrowser1.Width;
                    //获取滚动条被卷去的高度
                    int temp_scroll_width = Convert.ToInt32(JS_CEFBrowser("document.body.scrollLeft"));
                    //获取元素高度
                    //JS_CEFBrowser_NoReturn("alert(" + element + ".clientHeight" + ")");
                    string width = JS_CEFBrowser(element + ".clientWidth;");
                    int w = 0;
                    if (int.TryParse(width, out w))
                    {
                        w = w / 2;
                    }

                    //设置浏览器滑动条的高度：位置居中
                    //webBrowser1.Document.Window.ScrollTo(0, temp_scroll_height + temp_p.Y - webheight / 2);
                    //JS_CEFBrowser_NoReturn("window.scrollTo(0, " + (temp_scroll_height + temp_p.Y - webheight / 2 + h).ToString() + ")");
                    JS_CEFBrowser_NoReturn("window.scrollTo(" + (temp_scroll_width + temp_p.X - webwidth / 2 + w).ToString() + ", " + (temp_scroll_height + temp_p.Y - webheight / 2 + h).ToString() + ")");*/
                    SetScrollByHtmlElement(element);
                    Delay(100);
                    //获取元素在屏幕中的坐标
                    p = GetPointScreenByHtmlElement(element);
                    //获取元素面积内的随机坐标，模仿真实点击
                    p.Offset(Point_FuYu(element));
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
                ////Debug.WriteLine("MouseLeftByHtmlElement方法错误");
                ////Debug.WriteLine("错误原因：" + ex.Message);
            }
        }
        #endregion

        #region MouseMoveByHtmlElement
        /// <summary>
        /// 移动到指定元素位置并居中显示
        /// </summary>
        /// <param name="webBrowser1">WebBrowser</param>
        /// <returns>返回url，如果没有获取到带参数的url则返回空</returns>
        public void MouseMoveByHtmlElement(string element, int x, int y)
        {
            Point p = new Point();
            try
            {
                //在电脑屏幕中的位置
                p = GetPointScreenByHtmlElement(element);
                if (!p.IsEmpty)
                {
                    SetScrollByHtmlElement(element);
                    Delay(100);
                    //获取元素在屏幕中的坐标
                    p = GetPointScreenByHtmlElement(element);
                    //获取元素面积内的随机坐标，模仿真实点击
                    p.Offset(new Point(x, y));
                    //移动鼠标
                    Cursor.Position = p;
                }
            }
            catch (Exception ex)
            {
                ////Debug.WriteLine("MouseLeftByHtmlElement方法错误");
                ////Debug.WriteLine("错误原因：" + ex.Message);
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
        public Point GetPointScreenByHtmlElement(string element)
        {
            Point res = new Point();
            Point p_web = GetPointBrowserByHtmlElement(element);
            if (!p_web.IsEmpty)
            {
                res = browser.PointToScreen(new Point(0, 0));
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
        public Point GetPointBrowserByHtmlElement(string element)
        {
            Point res = new Point();
            int x = 0;
            int y = 0;
            string temp = "";
            //int temp_fuyu = 5;
            try
            {
                temp = JS_CEFBrowser(element + "!=null");
                if (!string.IsNullOrEmpty(temp) && temp == "True")
                {
                    string temp_x = JS_CEFBrowser(" getAbsoluteOffsetLeft(" + element + "); ");
                    //string temp_x2 = JS_WebBrowser(" document.body.scrollTop; ");
                    string temp_y = JS_CEFBrowser(" getAbsoluteOffsetTop(" + element + ")-document.body.scrollTop;");
                    if (int.TryParse(temp_x, out x) && int.TryParse(temp_y, out y))
                    {
                        res = new Point(x, y);
                    }
                }
            }
            catch (Exception ex)
            {
                ////Debug.WriteLine("获取网页中的元素位置失败");
                ////Debug.WriteLine("错误原因：" + ex.Message);
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
        public bool WaitJS(string js)
        {
            //判断元素存在后，返回true
            while (true)
            {
                Delay(50);
                string temp = JS_CEFBrowser(js);
                if (!string.IsNullOrEmpty(temp))
                {
                    if (temp.ToLower() == "true")
                    {
                        //Debug.WriteLine("找到了" + temp + " " + js);
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
        public void SetScrollByHtmlElement(string element)
        {
            try
            {
                //在浏览器中的位置
                Point temp_p = GetPointBrowserByHtmlElement(element);
                //获取浏览器高度
                int webheight = browser.Height;
                //获取滚动条被卷去的高度
                int temp_scroll_height = Convert.ToInt32(JS_CEFBrowser("document.body.scrollTop"));
                //获取元素高度
                //JS_CEFBrowser_NoReturn("alert(" + element + ".clientHeight" + ")");
                string height = JS_CEFBrowser(element + ".clientHeight;");
                int h = 0;
                if (int.TryParse(height, out h))
                {
                    h = h / 2;
                }

                /*新增宽度居中*/
                //获取浏览器宽度
                int webwidth = browser.Width;
                //获取滚动条被卷去的高度
                int temp_scroll_width = Convert.ToInt32(JS_CEFBrowser("document.body.scrollLeft"));
                //获取元素高度
                //JS_CEFBrowser_NoReturn("alert(" + element + ".clientHeight" + ")");
                string width = JS_CEFBrowser(element + ".clientWidth;");
                int w = 0;
                if (int.TryParse(width, out w))
                {
                    w = w / 2;
                }

                //设置浏览器滑动条的高度：位置居中
                //webBrowser1.Document.Window.ScrollTo(0, temp_scroll_height + temp_p.Y - webheight / 2);
                //JS_CEFBrowser_NoReturn("window.scrollTo(0, " + (temp_scroll_height + temp_p.Y - webheight / 2 + h).ToString() + ")");
                JS_CEFBrowser("window.scrollTo(" + (temp_scroll_width + temp_p.X - webwidth / 2 + w).ToString() + ", " + (temp_scroll_height + temp_p.Y - webheight / 2 + h).ToString() + ")");
            }
            catch (Exception ex)
            {
                //Debug.WriteLine("SetScrollByHtmlElement方法错误");
                //Debug.WriteLine("错误原因：" + ex.Message);
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
        public void SetScroll(int x, int y)
        {
            JS_CEFBrowser("window.scrollTo(" + x.ToString() + "," + y.ToString() + ");");
        }
        #endregion


        #region GetWebBrowser
        /// <summary>
        /// 将webBrowser1中的Session、Cookie等信息赋予webBrowser2中
        /// </summary>
        /// <param name="webBrowser1">原始信息webBrowser</param>
        /// <param name="webBrowser2"></param>
        /// <returns>是否赋值成功</returns>
        public bool GetWebBrowser(ChromiumWebBrowser webBrowser1, ChromiumWebBrowser webBrowser2)
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
        public void SetJSFile(ChromiumWebBrowser webBrowser1)
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
                //Debug.WriteLine("谷歌浏览器执行不返回值的JS脚本出错：" + e.ToString());
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
        public bool BoolByHtmlElement(string element)
        {
            bool res = false;
            //str = str.Trim();
            string temp = JS_CEFBrowser(element + "!=null");
            if (!string.IsNullOrEmpty(temp) && temp == "True")
            {
                res = true;
            }
            //string temp =JS_CEFBrowser(str + ".length");
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
        public int OptionSearchIndex(string jss, int count, string res)
        {
            int i = 0;
            for (i = 0; i < count; i++)
            {
                string temp = JS_CEFBrowser(jss + ".getElementsByTagName('option')[" + i.ToString() + "].innerText");
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
        public void OptionSetSeleted(string jss, int count, string res)
        {
            int temp = OptionSearchIndex(jss, count, res);
            string js = jss + ".getElementsByTagName('option')[" + (temp - 1).ToString() + "].selected =true;";
            JS_CEFBrowser(js);
        }
        #endregion

        #region ClearContext
        /// <summary>
        /// 清空缓存
        /// </summary>
        /// <param name="wb"></param>
        public void ClearContext()
        {
            try
            {
                //wb.RequestContext.Dispose();
                browser.RequestContext = new CefSharp.RequestContext();
            }
            catch { }
        }
        #endregion

        #region SaveHtml

        /// <summary>
        /// 保存页面
        /// </summary>
        /// <param name="wb"></param>
        public void SaveHtml()
        {
            //string html = webBrowser1.RequestContext.ToString();
            string html = JS_CEFBrowser("document.body.innerHTML");
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


        #endregion




    }

}
