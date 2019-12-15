using System;
using System.Web.UI;
using System.IO;
using BLL;
using System.Web;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Entity;


public partial class OA_sd_add_import : WebPage
{

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            int count = BLL.shuadan_accountManager.SearchNum("", "0", "", new DateTime(), new DateTime());
            lbl_account.Text = count.ToString();
        }

    }




    #region btn_save_Click
    protected void btn_save_Click(object sender, EventArgs e)
    {
        BLL.shuadanManager.import(FileUpload1, Page);
        //Manager.page_href_reload(Page);
    }
    #endregion








}