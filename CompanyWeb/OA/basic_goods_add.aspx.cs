using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entity;
using System.Text.RegularExpressions;


public partial class OA_basic_goods_add : WebPage
{
    string id;
    protected void Page_Load(object sender, EventArgs e)
    {
        id = Request["id"];
        if (!IsPostBack)
        {
            BLL.dianpuManager.ddl_bind(ddl_dianpu, false);
            BLL.basic_huodongManager.ddl_bind(ddl_basic_huodong, false);
            BLL.basic_order_planManager.ddl_bind(ddl_order_plan, false);
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
                basic_goods dp = basic_goodsManager.SearchByID(temp);
                if (dp != null)
                {
                    try
                    {
                        ddl_basic_huodong.SelectedValue = dp.hdid.ToString();
                        ddl_dianpu.SelectedValue = dp.dpid.ToString();
                        ddl_order_plan.SelectedValue = dp.opid.ToString();
                        txt_remark.Text = dp.bgremark;
                        txt_time.Text = dp.bgupdate.ToString("yyyy-MM-dd HH:mm");
                        txt_title.Text = dp.bgname;
                        txt_url.Text = dp.bgurl;
                        ddl_state.SelectedValue = dp.bgstate;
                        lb_date.Text = dp.bgdate.ToString();
                        ddl_key.SelectedValue = dp.bgkey;


                    }
                    catch { }
                }
            }
        }
        else
        {
            txt_time.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
        }
    }
    #endregion

    #region btn_save_Click
    protected void btn_save_Click(object sender, EventArgs e)
    {
        try
        {
            string _huodong = ddl_basic_huodong.SelectedValue;
            string _dianpu = ddl_dianpu.SelectedValue;
            string dianpu_name = ddl_dianpu.Text;
            string _order_plan = ddl_order_plan.SelectedValue;
            string remark = txt_remark.Text.Trim();
            string uptime = txt_time.Text.Trim();
            string title = txt_title.Text.Trim();
            string url = txt_url.Text.Trim();
            string state = ddl_state.SelectedValue;
            string key = ddl_key.SelectedValue;




            if (string.IsNullOrEmpty(title))
            {
                Manager.Alert("请输入商品名称", Page);
                Manager.TextBox_Select(txt_title);
                return;
            }

            DateTime date1 = new DateTime();
            if (!DateTime.TryParse(uptime, out date1))
            {
                Manager.Alert("请输入正确的时间", Page);
                Manager.TextBox_Select(txt_time);
                return;
            }
            int huodong = 0;
            int dianpu = 0;
            int order_plan = 0;
            int.TryParse(_huodong, out huodong);
            int.TryParse(_dianpu, out dianpu);
            int.TryParse(_order_plan, out order_plan);


            basic_goods dp = new basic_goods();


            if (!string.IsNullOrEmpty(id))
            {
                dp = BLL.basic_goodsManager.SearchByID(Convert.ToInt32(id));
            }
            else
            {
                dp.bgdate = DateTime.Now;
            }



            dp.bgkey = key;
            dp.bgname = title;
            dp.bgremark = remark;
            dp.bgstate = state;
            dp.bgupdate = date1;
            dp.bgurl = url;
            dp.dpid = dianpu;
            dp.dpname = dianpu_name;
            dp.hdid = huodong;
            dp.opid = order_plan;




            int res;
            if (string.IsNullOrEmpty(id))
            {
                res = BLL.basic_goodsManager.Insert(dp);
            }
            else
            {
                res = BLL.basic_goodsManager.Update(dp);
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