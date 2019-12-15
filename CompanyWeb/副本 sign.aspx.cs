using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entity;

public partial class sign : WebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind();
        }
    }

    #region bind
    void bind()
    {
        DateTime dt = DateTime.Now;
        DateTime dt2 = new DateTime();
        IList<Entity.Signs> list = BLL.SignsManager.search(1, 100, "", dt, dt, 0, 0, 0, "");
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
        //上午签到
        //判断是否签到
        if (s1 != null)
        {
            img_1.Attributes["src"] = "image/sign_3_1.jpg";
            img_1.Attributes["onclick"] = "";
        }
        else
        {
            dt2 = Convert.ToDateTime(dt.Year.ToString() + "-" + dt.Month.ToString() + "-" + dt.Day.ToString() + " 8:00");
            if (dt < dt2)
            {
                img_1.Attributes["src"] = "image/sign_1_1.jpg";
            }
            else if (dt >= dt2)
            {
                img_1.Attributes["src"] = "image/sign_2_1.jpg";
            }
        }
        //上午签退
        //判断是否签退
        if (s2 != null)
        {
            img_2.Attributes["src"] = "image/sign_3_2.jpg";
            img_2.Attributes["onclick"] = "";
        }
        else
        {
            dt2 = Convert.ToDateTime(dt.Year.ToString() + "-" + dt.Month.ToString() + "-" + dt.Day.ToString() + " 12:00");
            if (dt >= dt2)
            {
                if (s1 != null)
                    img_2.Attributes["src"] = "image/sign_1_2.jpg";
                else
                    img_2.Attributes["src"] = "image/sign_2_2.jpg";
            }
            else if (dt < dt2)
            {
                img_2.Attributes["src"] = "image/sign_2_2.jpg";
                img_2.Attributes["onclick"] = "if(confirm('确定要早退么？')){to_sign(2);}";
            }
        }
        //下午签到
        //判断是否签到
        if (s3 != null)
        {
            img_3.Attributes["src"] = "image/sign_3_3.jpg";
            img_3.Attributes["onclick"] = "";
        }
        else
        {
            dt2 = Convert.ToDateTime(dt.Year.ToString() + "-" + dt.Month.ToString() + "-" + dt.Day.ToString() + " 14:30");
            if (dt < dt2)
            {
                if (s2 != null)
                    img_3.Attributes["src"] = "image/sign_1_3.jpg";
                else
                {
                    img_3.Attributes["src"] = "image/sign_2_3.jpg";
                }
            }
            else if (dt >= dt2)
            {
                img_3.Attributes["src"] = "image/sign_2_3.jpg";
            }
        }
        //下午签退
        //判断是否签退
        if (s4 != null)
        {
            img_4.Attributes["src"] = "image/sign_3_4.jpg";
            img_4.Attributes["onclick"] = "";
        }
        else
        {
            dt2 = Convert.ToDateTime(dt.Year.ToString() + "-" + dt.Month.ToString() + "-" + dt.Day.ToString() + " 18:30");
            if (dt > dt2)
            {
                if (s3 != null)
                    img_4.Attributes["src"] = "image/sign_1_4.jpg";
                else
                    img_4.Attributes["src"] = "image/sign_2_4.jpg";
            }
            else if (dt <= dt2)
            {
                img_4.Attributes["src"] = "image/sign_2_4.jpg";
                img_4.Attributes["onclick"] = "if(confirm('确定要早退么？')){to_sign(4);}";
            }
        }


    }
    #endregion


}