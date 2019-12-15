using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entity;
using System.Text.RegularExpressions;


public partial class OA_basic_order_record_add : WebPage
{
    string id;

    protected void Page_Load(object sender, EventArgs e)
    {
        id = Request["id"];


        if (!IsPostBack)
        {
            Manager.Bind_DateTime(txt_date1);
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
                basic_task dp = basic_taskManager.SearchByID(temp);
                if (dp != null)
                {
                    try
                    {

                        ddl_state.SelectedValue = dp.btstate;

                        txt_remark.Text = dp.btcontent;
                        txt_title.Text = dp.btname;

                        txt_date1.Text = dp.btdate.ToString("yyyy-MM-dd");
                        lb_date.Text = dp.btdate2.ToString();

                        ddl_chongfu.SelectedValue = dp.btspare1;

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

            basic_task or = new basic_task();
            if (!string.IsNullOrEmpty(id))
            {
                or = BLL.basic_taskManager.SearchByID(Convert.ToInt32(id));
            }
            else
            {
                or.btdate2 = DateTime.Now;
            }



            DateTime dt = new DateTime();



            string remark = txt_remark.Text.Trim();
            string title = txt_title.Text.Trim();
            string state = ddl_state.SelectedValue;
            string chongfu = ddl_chongfu.SelectedValue;
            string dt1 = txt_date1.Text.Trim();
            DateTime.TryParse(dt1, out dt);
            
            or.btcontent = remark;
            or.btdate = dt;
            or.btname = title; 
            or.btstate = state;
            or.btspare1 = chongfu;

            int res;
            if (string.IsNullOrEmpty(id))
            {
                res = BLL.basic_taskManager.Insert(or);
            }
            else
            {
                res = BLL.basic_taskManager.Update(or);
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