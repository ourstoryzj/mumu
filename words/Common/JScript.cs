using System;
using System.Web.UI;

namespace Common
{
    public class JScript
    {
        #region JScript

        public JScript()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        #region 带Page

        /// <summary>
        /// 用于模态窗体返回
        /// </summary>
        /// <param name="message">提示信息</param>
        /// <param name="page">Page类</param>
        public static void LocationFrom(string toURL, Page page)
        {
            #region
            string js = "<Script language='JavaScript'>";
            js += "function formhref(url){var f = document.createElement('form');";
            js += "document.body.appendChild(f);f.action = " + toURL;
            js += ";f.method='post';f.submit();}";
            js += "</Script>";
            if (!page.ClientScript.IsStartupScriptRegistered(page.GetType(), "Alert"))
            {
                page.ClientScript.RegisterStartupScript(page.GetType(), "formhref", js);
            }
            #endregion
        }


        /// <summary>
        /// 弹出Alert提示框
        /// </summary>
        /// <param name="message">提示信息</param>
        /// <param name="page">Page类</param>
        public static void Alert(string message, Page page)
        {
            #region
            string js = "<Script language='JavaScript'>alert(\"" + message + "\");</Script>";
            if (!page.ClientScript.IsStartupScriptRegistered(page.GetType(), "Alert"))
            {
                page.ClientScript.RegisterStartupScript(page.GetType(), "Alert", js);
            }
            #endregion
        }

        /// <summary>
        /// 弹出Alert提示框，并跳转到新的URL
        /// </summary>
        /// <param name="message"></param>
        /// <param name="toURL">URL</param>
        /// <param name="page">Page类</param>
        public static void AlertAndRedirect(string message, string toURL, Page page)
        {
            #region
            string js = "<script language=javascript>alert(\"{0}\");window.location.replace(\"{1}\");</script>";
            if (!page.ClientScript.IsStartupScriptRegistered(page.GetType(), "AlertAndRedirect"))
            {
                page.ClientScript.RegisterStartupScript(page.GetType(), "AlertAndRedirect", string.Format(js, message, toURL));
            }
            #endregion
        }

        /// <summary>
        /// 返回
        /// </summary>
        /// <param name="page">Page类</param>
        public static void History(Page page)
        {
            #region
            string js = "<Script language='JavaScript'>history.back();</Script>";
            if (!page.ClientScript.IsStartupScriptRegistered(page.GetType(), "AlertAndHistory"))
            {
                page.ClientScript.RegisterStartupScript(page.GetType(), "AlertAndHistory", js);
                System.Web.HttpContext.Current.Response.End();
            }
            #endregion
        }

        /// <summary>
        /// 弹出Alert提示框，并返回
        /// </summary>
        /// <param name="message">提示信息</param>
        /// <param name="page">Page类</param>
        public static void AlertAndHistory(string message, Page page)
        {
            #region
            string js = "<Script language='JavaScript'>alert(\"" + message + "\");history.back();</Script>";
            if (!page.ClientScript.IsStartupScriptRegistered(page.GetType(), "AlertAndHistory"))
            {
                page.ClientScript.RegisterStartupScript(page.GetType(), "AlertAndHistory", js);
                System.Web.HttpContext.Current.Response.End();
            }
            #endregion
        }

        /// <summary>
        /// 回到历史页面
        /// </summary>
        /// <param name="value">历史页面参数(-1/1)</param>
        /// <param name="page">Page类</param>
        public static void GoHistory(int value, Page page)
        {
            #region
            string js = @"<script language='JavaScript'>history.go({0});</script>";
            if (!page.ClientScript.IsStartupScriptRegistered(page.GetType(), "GoHistory"))
            {
                page.ClientScript.RegisterStartupScript(page.GetType(), "GoHistory", string.Format(js, value));
            }
            #endregion
        }

        /// <summary>
        /// 关闭窗口
        /// </summary>
        /// <param name="flag">是否刷新:0和1</param>
        /// <param name="page">Page类</param>
        public static void CloseWindow(int flag, Page page)
        {
            #region
            string js = @"<Script language='JavaScript'>window.opener=null;if(" + flag + "==1){window.returnValue=1;}window.close();</Script>";
            if (!page.ClientScript.IsStartupScriptRegistered(page.GetType(), "CloseWindow"))
            {
                page.ClientScript.RegisterStartupScript(page.GetType(), "CloseWindow", js);
            }
            #endregion
        }

        /// <summary>
        /// 刷新父窗口
        /// </summary>
        /// <param name="page">Page类</param>
        public static void RefreshParent(Page page)
        {
            #region
            string js = @"<Script language='JavaScript'>parent.location.reload()';</Script>";
            if (!page.ClientScript.IsStartupScriptRegistered(page.GetType(), "RefreshParent"))
            {
                page.ClientScript.RegisterStartupScript(page.GetType(), "RefreshParent", js);
            }
            #endregion
        }

        /// <summary>
        /// 刷新打开窗口
        /// </summary>
        /// <param name="page">Page类</param>
        public static void RefreshOpener(Page page)
        {
            #region
            string js = @"<Script language='JavaScript'>opener.location.reload();</Script>";
            if (!page.ClientScript.IsStartupScriptRegistered(page.GetType(), "RefreshOpener"))
            {
                page.ClientScript.RegisterStartupScript(page.GetType(), "RefreshOpener", js);
            }
            #endregion
        }

        /// <summary>
        /// 打开指定大小的新窗体
        /// </summary>
        /// <param name="url">URL地址</param>
        /// <param name="width">宽</param>
        /// <param name="heigth">高</param>
        /// <param name="scrollbar">滚动条</param>
        /// <param name="page">Page类</param>
        public static void OpenWebFormSize(string url, int width, int heigth, string scrollbar, Page page)
        {
            #region
            string js = @"<Script language='JavaScript'>";
            js += "var myLeft = (screen.width-" + width + ")/2;var myTop = (screen.height-" + heigth + ")/2;";
            js += "window.open('" + url + "','','height=" + heigth + ",width=" + width + ",top='+myTop+',left='+myLeft+',location=no,menubar=no,resizable=no,scrollbars=" + scrollbar + ",status=no,titlebar=no,toolbar=no,directories=no');</Script>";
            if (!page.ClientScript.IsStartupScriptRegistered(page.GetType(), "OpenWebFormSize"))
            {
                page.ClientScript.RegisterStartupScript(page.GetType(), "OpenWebFormSize", js);
            }
            #endregion
        }

        /// <summary>
        /// 转向Url制定的页面
        /// </summary>
        /// <param name="url">URL地址</param>
        /// <param name="page">Page类</param>
        public static void JavaScriptLocationHref(string url, Page page)
        {
            #region
            string js = @"<Script language='JavaScript'>window.location.replace('{0}');</Script>";
            js = string.Format(js, url);
            if (!page.ClientScript.IsStartupScriptRegistered(page.GetType(), "JavaScriptLocationHref"))
            {
                page.ClientScript.RegisterStartupScript(page.GetType(), "JavaScriptLocationHref", js);
            }
            #endregion
        }


        /// <summary>
        /// 打开指定大小位置的模式对话框
        /// </summary>
        /// <param name="webFormUrl">URL</param>
        /// <param name="width">宽</param>
        /// <param name="height">高</param>
        /// <param name="scrollbar">滚动条</param>
        /// <param name="page">Page类</param>
        public static void ShowModalDialogWindow(string webFormUrl, int width, int height, string scrollbar, Page page)
        {
            #region
            string features = "dialogWidth:" + width.ToString() + "px" + ";dialogHeight:" + height.ToString() + "px" + ";center:yes;help=no;resizable:no;status:no;scroll=" + scrollbar;
            ShowModalDialogWindow(webFormUrl, features, page);
            #endregion
        }

        /// <summary>
        /// 弹出模态窗口
        /// </summary>
        /// <param name="webFormUrl">URL</param>
        /// <param name="features">参数</param>
        /// <param name="page">Page类</param>
        public static void ShowModalDialogWindow(string webFormUrl, string features, Page page)
        {
            #region
            string js = ShowModalDialogJavascript(webFormUrl, features);
            if (!page.ClientScript.IsStartupScriptRegistered(page.GetType(), "ShowModalDialogWindow"))
            {
                page.ClientScript.RegisterStartupScript(page.GetType(), "ShowModalDialogWindow", js);
            }
            #endregion
        }

        /// <summary>
        /// 弹出模态窗口
        /// </summary>
        /// <param name="webFormUrl">URL</param>
        /// <param name="features">参数</param>
        /// <returns>返回</returns>
        public static string ShowModalDialogJavascript(string webFormUrl, string features)
        {
            #region
            string js = "<script language=javascript>var returnValue=showModalDialog(\"" + webFormUrl + "\",'',\"" + features + "\");if(returnValue==1){window.location.reload();}</script>";
            return js;
            #endregion
        }


        #endregion 带Page

        #region 不带Page

        public static void Response(string msg)
        {
            System.Web.HttpContext.Current.Response.Write(msg);
        }

        /// <summary>
        /// 用于模态窗体返回
        /// </summary>
        /// <param name="message">提示信息</param>
        /// <param name="page">Page类</param>
        public static void LocationFrom(string toURL)
        {
            #region
            string js = "<Script language='JavaScript'>";
            js += "function formhref(url){var f = document.createElement('form');";
            js += "document.body.appendChild(f);f.action = " + toURL;
            js += ";f.method='post';f.submit();}";
            js += "</Script>";
            Response(js);
            #endregion
        }



        /// <summary>
        /// 弹出Alert提示框
        /// </summary>
        /// <param name="message">提示信息</param>
        public static void Alert(string message)
        {
            #region
            string js = "<Script language='JavaScript'>alert(\"" + message + "\");</Script>";
            Response(js);
            #endregion
        }

        /// <summary>
        /// 弹出Alert提示框，并跳转到新的URL
        /// </summary>
        /// <param name="message"></param>
        /// <param name="toURL">URL</param>
        public static void AlertAndRedirect(string message, string toURL)
        {
            #region
            string js = "<script language=javascript>alert(\"" + message + "\");window.location.replace(\"" + toURL + "\");</script>";
            Response(js);
            #endregion
        }

        /// <summary>
        /// 返回
        /// </summary>
        public static void History()
        {
            #region
            string js = "<Script language='JavaScript'>history.back();</Script>";
            Response(js);
            System.Web.HttpContext.Current.Response.End();
            #endregion
        }


        /// <summary>
        /// 弹出Alert提示框，并返回
        /// </summary>
        /// <param name="message">提示信息</param>
        public static void AlertAndHistory(string message)
        {
            #region
            string js = "<Script language='JavaScript'>alert(\"" + message + "\");history.back();</Script>";
            Response(js);
            System.Web.HttpContext.Current.Response.End();
            #endregion
        }

        /// <summary>
        /// 回到历史页面
        /// </summary>
        /// <param name="value">历史页面参数(-1/1)</param>
        public static void GoHistory(int value)
        {
            #region
            string js = @"<script language='JavaScript'>history.go({0});</script>";
            Response(js);
            #endregion
        }

        /// <summary>
        /// 关闭窗口
        /// </summary>
        /// <param name="flag">是否刷新:0和1</param>
        public static void CloseWindow(int flag)
        {
            #region
            string js = @"<Script language='JavaScript'>window.opener=null;if(" + flag + "==1){window.returnValue=1;}window.close();</Script>";
            Response(js);
            #endregion
        }

        /// <summary>
        /// 刷新父窗口
        /// </summary>
        public static void RefreshParent()
        {
            #region
            string js = @"<Script language='JavaScript'>parent.location.reload()';</Script>";
            Response(js);
            #endregion
        }

        /// <summary>
        /// 刷新打开窗口
        /// </summary>
        public static void RefreshOpener()
        {
            #region
            string js = @"<Script language='JavaScript'>opener.location.reload();</Script>";
            Response(js);
            #endregion
        }

        /// <summary>
        /// 打开指定大小的新窗体
        /// </summary>
        /// <param name="url">URL地址</param>
        /// <param name="width">宽</param>
        /// <param name="heigth">高</param>
        /// <param name="scrollbar">滚动条</param>
        public static void OpenWebFormSize(string url, int width, int heigth, string scrollbar)
        {
            #region
            string js = @"<Script language='JavaScript'>";
            js += "var myLeft = (screen.width-" + width + ")/2;var myTop = (screen.height-" + heigth + ")/2;";
            js += "window.open('" + url + "','','height=" + heigth + ",width=" + width + ",top='+myTop+',left='+myLeft+',location=no,menubar=no,resizable=no,scrollbars=" + scrollbar + ",status=no,titlebar=no,toolbar=no,directories=no');</Script>";
            Response(js);
            #endregion
        }

        /// <summary>
        /// 转向Url制定的页面
        /// </summary>
        /// <param name="url">URL地址</param>
        public static void JavaScriptLocationHref(string url)
        {
            #region
            string js = "<Script language='JavaScript'>window.location.replace(\"{0}\");</Script>";
            js = string.Format(js, url);
            Response(js);
            #endregion
        }


        /// <summary>
        /// 打开指定大小位置的模式对话框
        /// </summary>
        /// <param name="webFormUrl">URL</param>
        /// <param name="width">宽</param>
        /// <param name="height">高</param>
        /// <param name="scrollbar">滚动条</param>
        public static void ShowModalDialogWindow(string webFormUrl, int width, int height, string scrollbar)
        {
            #region
            string features = "dialogWidth:" + width.ToString() + "px" + ";dialogHeight:" + height.ToString() + "px" + ";center:yes;help=no;resizable:no;status:no;scroll=" + scrollbar;
            ShowModalDialogWindow(webFormUrl, features);
            #endregion
        }

        /// <summary>
        /// 弹出模态窗口
        /// </summary>
        /// <param name="webFormUrl">URL</param>
        /// <param name="features">参数</param>
        public static void ShowModalDialogWindow(string webFormUrl, string features)
        {
            #region
            string js = ShowModalDialogJavascript(webFormUrl, features);
            Response(js);
            #endregion
        }



        #endregion 不带Page




        #endregion JScript
    }
}
