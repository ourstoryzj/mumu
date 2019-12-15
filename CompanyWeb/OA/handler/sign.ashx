<%@ WebHandler Language="C#" Class="sign" %>

using System;
using System.Web;
using Entity;
using BLL;

public class sign : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        context.Response.HeaderEncoding = System.Text.Encoding.UTF8;
        HttpRequest r = context.Request;

        Basic b = Manager.Basic;
        if (b == null)
        {
            b = BLL.BasicManager.searchByState("1");
        }
        if (b == null)
        {
            context.Response.Write("0");
            context.Response.End();
        }
        string t = r["type"];
        string fun = r["fun"];


        DateTime dt = DateTime.Now;
        DateTime dt2;

        System.Collections.Generic.IList<Entity.Signs> list = BLL.SignsManager.search(1, 100, "", dt, dt, 0, 0, 0, "");
        Signs s1 = null;
        Signs s2 = null;
        Signs s3 = null;
        Signs s4 = null;
        foreach (Signs s in list)
        {
            if (s.UType == "1")
            {
                s1 = s;
            }
            if (s.UType == "2")
            {
                s2 = s;
            }
            if (s.UType == "3")
            {
                s3 = s;
            }
            if (s.UType == "4")
            {
                s4 = s;
            }
        }

        #region to_bind
        if (fun == "to_bind")
        {
            string to_bind_res = "{\'Table\':[{";

            //上午上班
            if (s1 == null)
            {
                to_bind_res += "\'s1\':\'0\'";
            }
            else
            {
                to_bind_res += "\'s1\':\'1\'";
            }
            dt2 = Convert.ToDateTime(dt.Year.ToString() + "-" + dt.Month.ToString() + "-" + dt.Day.ToString() + " " + b.Sign1);
            if (dt >= dt2)
            {
                to_bind_res += ",\'s1_s\':\'2\'";
            }
            else
            {
                to_bind_res += ",\'s1_s\':\'1\'";
            }

            //上午下班
            if (s2 == null)
            {
                to_bind_res += ",\'s2\':\'0\'";
            }
            else
            {
                to_bind_res += ",\'s2\':\'1\'";
            }
            dt2 = Convert.ToDateTime(dt.Year.ToString() + "-" + dt.Month.ToString() + "-" + dt.Day.ToString() + " " + b.Sign2);
            if (dt < dt2)
            {
                to_bind_res += ",\'s2_s\':\'2\'";
            }
            else
            {
                to_bind_res += ",\'s2_s\':\'1\'";
            }

            //下午上班
            if (s3 == null)
            {
                to_bind_res += ",\'s3\':\'0\'";
            }
            else
            {
                to_bind_res += ",\'s3\':\'1\'";
            }
            dt2 = Convert.ToDateTime(dt.Year.ToString() + "-" + dt.Month.ToString() + "-" + dt.Day.ToString() + " " + b.Sign3);
            if (dt >= dt2)
            {
                to_bind_res += ",\'s3_s\':\'2\'";
            }
            else
            {
                to_bind_res += ",\'s3_s\':\'1\'";
            }

            //下午下班
            if (s4 == null)
            {
                to_bind_res += ",\'s4\':\'0\'";
            }
            else
            {
                to_bind_res += ",\'s4\':\'1\'";
            }
            dt2 = Convert.ToDateTime(dt.Year.ToString() + "-" + dt.Month.ToString() + "-" + dt.Day.ToString() + " " + b.Sign4);
            if (dt < dt2)
            {
                to_bind_res += ",\'s4_s\':\'2\'";
            }
            else
            {
                to_bind_res += ",\'s4_s\':\'1\'";
            }

            to_bind_res += "}]}";

            context.Response.Write(to_bind_res);
            context.Response.End();
        }
        #endregion

        #region to_bind
        if (fun == "to_add")
        {
            string jiekou = r["jiekou"];
            Users user = Manager.User;
            Signs s = new Signs();
            s.SignTime = DateTime.Now;
            s.UId = user.Id;
            s.UName = user.Name;
            s.UType = t;
            switch (t)
            {
                case "1":
                    dt2 = Convert.ToDateTime(dt.Year.ToString() + "-" + dt.Month.ToString() + "-" + dt.Day.ToString() + " " + b.Sign1);
                    if (dt >= dt2)
                    {
                        s.UState = "2";
                    }
                    else
                    {
                        s.UState = "1";
                    }
                    break;
                case "2":
                    dt2 = Convert.ToDateTime(dt.Year.ToString() + "-" + dt.Month.ToString() + "-" + dt.Day.ToString() + " " + b.Sign2);
                    if (dt < dt2)
                    {
                        s.UState = "2";
                    }
                    else
                    {
                        s.UState = "1";
                    }
                    break;
                case "3":
                    dt2 = Convert.ToDateTime(dt.Year.ToString() + "-" + dt.Month.ToString() + "-" + dt.Day.ToString() + " " + b.Sign3);
                    if (dt >= dt2)
                    {
                        s.UState = "2";
                    }
                    else
                    {
                        s.UState = "1";
                    }
                    break;
                case "4":
                    dt2 = Convert.ToDateTime(dt.Year.ToString() + "-" + dt.Month.ToString() + "-" + dt.Day.ToString() + " " + b.Sign4);
                    if (dt < dt2)
                    {
                        s.UState = "2";
                    }
                    else
                    {
                        s.UState = "1";
                    }
                    break;
            }

            if (!string.IsNullOrEmpty(jiekou))
            {
                s.Remark = jiekou;
            }

            int to_add_res = BLL.SignsManager.Insert(s);
            context.Response.Write(to_add_res.ToString());
            context.Response.End();
        }
        #endregion

    }


    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}