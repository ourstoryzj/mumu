using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entity;
using System.Text.RegularExpressions;


public partial class OA_dianpu_add : WebPage
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
                dianpu dp = dianpuManager.SearchBydpid(temp);
                if (dp != null)
                {
                    try
                    {
                        txt_name.Text = dp.dpname;
                        txt_remark.Text = dp.dpremark;
                        txt_sort.Text = dp.dpsort.ToString();
                        ddl_state.SelectedValue = dp.dpstate;
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

            dianpu dp = new dianpu();


            if (!string.IsNullOrEmpty(id))
            {
                dp = BLL.dianpuManager.SearchBydpid(Convert.ToInt32(id));
            }
            int sort2 = 0;
            int.TryParse(sort, out sort2);

            dp.dpname = name;
            dp.dpremark = remark;
            dp.dpsort = sort2;
            dp.dpstate = state;
            int res;
            if (string.IsNullOrEmpty(id))
            {
                res = BLL.dianpuManager.Insert(dp);
            }
            else
            {
                res = BLL.dianpuManager.Update(dp);
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