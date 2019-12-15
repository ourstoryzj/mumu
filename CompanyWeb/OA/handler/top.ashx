<%@ WebHandler Language="C#" Class="top" %>

using System;
using System.Web;
using BLL;
using Entity;

public class top : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        HttpContext.Current.Session.Clear();
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}