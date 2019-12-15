<%@ WebHandler Language="C#" Class="fanxian" %>

using System;
using System.Web;
using Entity;
using BLL;

public class fanxian : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        string fxid = context.Request["fxid"];
        if (string.IsNullOrEmpty(fxid))
        {
            context.Response.Write("{'info':[{'statu':'2','mess':'系统错误，请稍后再试!'}]}");
            context.Response.End(); 
        }
        int id = 0;
        if (!int.TryParse(fxid,out id))
        {
            context.Response.Write("{'info':[{'statu':'2','mess':'数据错误!'}]}");
            context.Response.End();
        }
        Entity.fanxian fx = fanxianManager.SearchByfx_id(id);
        if (fx == null)
        {
            context.Response.Write("{'info':[{'statu':'2','mess':'没有此数据!'}]}");
            context.Response.End();
        }
        else
        {
            fx.fx_state = "2";
            fx.fx_date2 = DateTime.Now;
            if (fanxianManager.Update(fx) == 1)
            {
                context.Response.Write("{'info':[{'statu':'1'}]}");
                context.Response.End();
            }
            else
            {
                context.Response.Write("{'info':[{'statu':'2','mess':'更新失败!'}]}");
                context.Response.End();
            }
        }
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}