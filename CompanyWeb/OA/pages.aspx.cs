using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entity;
using System.Text.RegularExpressions;


public partial class OA_pages_add : WebPage
{
    string id;


    protected void Page_Load(object sender, EventArgs e)
    {
        id = Request["id"];

        if (!IsPostBack)
        {

            bind();
        }
    }


    #region bind
    void bind()
    {
        if (!string.IsNullOrEmpty(id))
        {
            int temp = 0;
            if (int.TryParse(id, out temp))
            {
                pages dp = pagesManager.SearchByID(temp);
                if (dp != null)
                {
                    try
                    {
                        lbl_name.Text = dp.pname;
                        lbl_date.Text = dp.pdate.ToString();
                        liter_context.Text = dp.pcontext;
                    }
                    catch { }
                }
            }
        }
    }
    #endregion






}