using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entity;
using System.Text.RegularExpressions;


public partial class OA_pages_type_add : WebPage
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
                pages_type dp = pages_typeManager.SearchByID(temp);
                if (dp != null)
                {
                    try
                    {
                        txt_name.Text = dp.ptname;
                        txt_remark.Text = dp.ptremark;
                        txt_sort.Text = dp.ptsort.ToString();
                        ddl_state.SelectedValue = dp.ptstate;
                        liter_date.Text = dp.ptdate.ToString();
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
            string remark = txt_remark.Text.Trim();
            string state = ddl_state.SelectedValue.ToString();
            string sort = txt_sort.Text.Trim();

            pages_type dp = new pages_type();


            if (!string.IsNullOrEmpty(id))
            {
                dp = BLL.pages_typeManager.SearchByID(Convert.ToInt32(id));
            }
            else
            {
                dp.ptdate = DateTime.Now;
            }

            dp.ptname = name;
            dp.ptremark = remark;
            dp.ptsort = Convert.ToInt32(sort);
            dp.ptstate = state;
            int res;
            if (string.IsNullOrEmpty(id))
            {
                res = BLL.pages_typeManager.Insert(dp);
            }
            else
            {
                res = BLL.pages_typeManager.Update(dp);
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
        }
        Manager.page_href_reload(Page);
    }
    #endregion




}