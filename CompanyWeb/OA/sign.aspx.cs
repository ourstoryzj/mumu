using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entity;

public partial class OA_sign : WebPage
{
    Basic b = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        b = Manager.Basic;
        if (b == null)
        {
            b = BLL.BasicManager.searchByState("1");
        }
        if (!IsPostBack)
        {
            bind();
        }
    }


    void bind()
    {

    }





}