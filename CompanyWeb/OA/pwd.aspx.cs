using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity;
using BLL;

public partial class OA_pwd : WebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    #region btn_save_Click
    protected void btn_save_Click(object sender, EventArgs e)
    {
        string pwd = txt_pwd.Text.Trim();
        string pwd1 = txt_pwd2.Text.Trim();

        Users user = BLL.Manager.User;

        if (user.Password == pwd)
        {
            user.Password = pwd1;
            if (BLL.UsersManager.Update(user) == 1)
            {
                Manager.Alert("保存成功", Page);
                Manager.User = user;
            }
            else
            {
                Manager.Alert("保存失败", Page);
            }
        }
        else
        {
            Manager.Alert("原始密码错误", Page);
        }
        Manager.page_href_reload(Page);
    }
    #endregion
}