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
    IList<pages_type> ptlist;

    protected void Page_Load(object sender, EventArgs e)
    {
        id = Request["id"];
        ptlist = BLL.pages_typeManager.GetList("1");
        if (!IsPostBack)
        {
            BLL.pages_typeManager.ddl_bind(ddl_pagestype, true);
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
                        txt_name.Text = dp.pname;
                        txt_context.Value = dp.pcontext;
                        txt_sort.Text = dp.psort.ToString();
                        ddl_state.SelectedValue = dp.pstate;
                        liter_date.Text = dp.pdate.ToString();
                        ddl_pagestype.SelectedValue = dp.ptid.ToString();
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
            string context = txt_context.Value;
            string state = ddl_state.SelectedValue.ToString();
            string sort = txt_sort.Text.Trim();
            string ptid = ddl_pagestype.SelectedValue;
            int _ptid = string.IsNullOrEmpty(ptid) ? 0 : Convert.ToInt32(ptid);

            pages dp = new pages();


            if (!string.IsNullOrEmpty(id))
            {
                dp = BLL.pagesManager.SearchByID(Convert.ToInt32(id));
            }
            else
            {
                dp.pdate = DateTime.Now;
            }

            dp.pname = name;
            dp.pcontext = context;
            dp.psort = Convert.ToInt32(sort);
            dp.pstate = state;
            dp.ptid = _ptid;
            int res;
            if (string.IsNullOrEmpty(id))
            {
                res = BLL.pagesManager.Insert(dp);
            }
            else
            {
                res = BLL.pagesManager.Update(dp);
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