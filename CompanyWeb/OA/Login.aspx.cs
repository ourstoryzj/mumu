using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

public partial class OA_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        bind();
    }

    void bind()
    {
        try
        {
            txt_acc.Value = Request.Cookies[Manager.decl_User].Values[Manager.decl_User_Acc].ToString();
            txt_pwd.Attributes.Add("value", Request.Cookies[Manager.decl_User].Values[Manager.decl_User_Pwd].ToString());
            if (!string.IsNullOrEmpty(txt_acc.Value))
            {
                div_state.Attributes["class"] = "l_s_button";
            }
        }
        catch
        {

        }
    }

}