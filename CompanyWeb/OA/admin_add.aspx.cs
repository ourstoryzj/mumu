using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entity;
using System.Text.RegularExpressions;


public partial class OA_admin_add : WebPage
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
                Admins dp = AdminsManager.SearchByaid(temp);
                if (dp != null)
                {
                    try
                    {
                        txt_account.Text = dp.aaccount;
                        txt_pwd.Text = dp.apassword;
                        ddl_state.SelectedValue = dp.astate;
                        ddl_type.SelectedValue = dp.atype;
                        liter_date.Text = dp.alogintime.ToString();
                    }
                    catch { }
                }
            }
        }
    }
    #endregion

    #region btn_save_Click
    protected void btn_save_Click(object sender, EventArgs e)
    {
        try
        {
            string account = txt_account.Text.Trim();
            string pwd = txt_pwd.Text.Trim();
            string state = ddl_state.SelectedValue.ToString();
            string _type = ddl_type.SelectedValue.ToString();


            Admins dp = new Admins();


            if (!string.IsNullOrEmpty(id))
            {
                dp = BLL.AdminsManager.SearchByaid(Convert.ToInt32(id));
            }


            dp.aaccount = account;
            dp.apassword = pwd;
            dp.atype = _type;
            dp.astate = state;
            int res;
            if (string.IsNullOrEmpty(id))
            {
                dp.alogintime = DateTime.Now;
                res = BLL.AdminsManager.Insert(dp);
            }
            else
            {
                res = BLL.AdminsManager.Update(dp);
            }
            if (res == 1)
            {
                Manager.Alert("保存成功", Page);
            }
            else
            {
                Manager.Alert("保存失败", Page);
            }
        }
        catch (Exception ex)
        {
            Manager.Alert(ex.ToString(),Page);
        }
        Manager.page_href_reload(Page);
    }
    #endregion



     
}