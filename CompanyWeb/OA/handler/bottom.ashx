<%@ WebHandler Language="C#" Class="bottom" %>

using System;
using System.Web;

public class bottom : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        context.Response.Write("{'table':[{'account':'" + BLL.Manager.User.Account + "','logintime':'" + BLL.Manager.User.LoginTime.ToString("yyyy年MM月dd日 HH时mm分") + "'}]}");
        context.Response.End();
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}