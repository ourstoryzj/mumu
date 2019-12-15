using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entity;
using System.Text.RegularExpressions;


public partial class OA_courier_add : WebPage
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
                courier dp = courierManager.SearchByID(temp);
                if (dp != null)
                {
                    try
                    {
                        txt_name.Text = dp.cname;
                        txt_remark.Text = dp.cremark;
                        txt_sort.Text = dp.csort.ToString();
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
            string sort = txt_sort.Text.Trim();
            int temp_sort = 0;
            if (!int.TryParse(sort, out temp_sort))
            {
                Manager.Alert("请输入正确的排序", Page);
                return;
            }

            courier dp = new courier();


            if (!string.IsNullOrEmpty(id))
            {
                dp = BLL.courierManager.SearchByID(Convert.ToInt32(id));
            }
            

            dp.cname = name;
            dp.cremark = remark;
            dp.csort = temp_sort;
            int res;
            if (string.IsNullOrEmpty(id))
            {
                res = BLL.courierManager.Insert(dp);
            }
            else
            {
                res = BLL.courierManager.Update(dp);
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