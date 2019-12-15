<%@ WebHandler Language="C#" Class="login" %>

using System;
using System.Web;
using Entity;
using BLL;

public class login : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        string acc = context.Request["acc"];
        string pwd = context.Request["pwd"];
        string pwd_statu = context.Request["statu"];
        if (string.IsNullOrEmpty(acc) || string.IsNullOrEmpty(pwd))
        {
            context.Response.Write("{'info':[{'statu':'2','mess':'系统错误，请稍后再试!'}]}");
            context.Response.End();
        }
        Users user = UsersManager.searchByAcc(acc);
        if (user == null)
        {
            context.Response.Write("{'info':[{'statu':'2','mess':'没有此账号!'}]}");
            context.Response.End();
        }
        else
        {
            if (user.Password != pwd)
            {
                context.Response.Write("{'info':[{'statu':'2','mess':'密码错误!'}]}");
                context.Response.End();
            }
            else
            {
                user.LoginTime = DateTime.Now;
                //BLL.UsersManager.Update(user);
                Manager.User = user;
                //System.Web.HttpContext.Current.Session[Manager.decl_User] = user;
                //是否记录密码
                if (pwd_statu == "1")
                {
                    System.Web.HttpCookie cookie_user = new System.Web.HttpCookie(Manager.decl_User);
                    cookie_user.Expires = DateTime.Now.AddDays(30);
                    cookie_user.Values[Manager.decl_User_Acc] = acc;
                    cookie_user.Values[Manager.decl_User_Pwd] = pwd;
                    HttpContext.Current.Response.Cookies.Add(cookie_user);
                }
                else
                {
                    HttpContext.Current.Response.Cookies[Manager.decl_User].Expires = DateTime.Now;
                }

                context.Response.Write("{'info':[{'statu':'1'}]}");
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