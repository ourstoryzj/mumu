using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entity;
using System.Text.RegularExpressions;


public partial class OA_huashu_type_add : WebPage
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
                huashu dp = huashuManager.SearchByID(temp);
                if (dp != null)
                {
                    try
                    {
                        txt_name.Text = dp.htitle;
                        txt_sort.Text = dp.hsort.ToString();
                        ddl_state.SelectedValue = dp.hstate;
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
            string name = txt_name.Text.Trim();
            string state = ddl_state.SelectedValue.ToString();
            string sort = txt_sort.Text.Trim();
            int int_sort = 0;
            if (!int.TryParse(sort, out int_sort))
            {
                Manager.Alert("请输入正确的排序", Page);
                Manager.TextBox_Select(txt_sort);
                return;
            }
            huashu dp = new huashu();


            if (!string.IsNullOrEmpty(id))
            {
                dp = BLL.huashuManager.SearchByID(Convert.ToInt32(id));
            }
            else
            {
                dp.hdate = DateTime.Now;
                dp.hcount = 0;
            }

            dp.htitle = name;
            dp.hsort = int_sort;
            dp.hstate = state;
            dp.hfid = 0;
            int res;
            if (string.IsNullOrEmpty(id))
            {
                res = BLL.huashuManager.Insert(dp);
            }
            else
            {
                res = BLL.huashuManager.Update(dp);
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
            Manager.Alert(ex.ToString(), Page);
            return;
        }
        Manager.page_href_reload(Page);
    }
    #endregion




}