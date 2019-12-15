using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entity;


public partial class OA_basic_goods_list : WebPage
{

    string date1;
    string date2;
    string date3;
    string date4;
    string dp;
    string state;
    string key;
    string iskey;
    string op;
    string hp;


    protected void Page_Load(object sender, EventArgs e)
    {
        date1 = string.IsNullOrEmpty(txt_date1.Text.Trim()) ? Request["date1"] : txt_date1.Text.Trim();
        date2 = string.IsNullOrEmpty(txt_date2.Text.Trim()) ? Request["date2"] : txt_date2.Text.Trim();
        date3 = string.IsNullOrEmpty(txt_date3.Text.Trim()) ? Request["date3"] : txt_date3.Text.Trim();
        date4 = string.IsNullOrEmpty(txt_date4.Text.Trim()) ? Request["date4"] : txt_date4.Text.Trim();
        dp = string.IsNullOrEmpty(ddl_dianpu.SelectedValue) ? Request["dp"] : ddl_dianpu.SelectedValue;
        state = string.IsNullOrEmpty(ddl_state.SelectedValue) ? Request["state"] : ddl_state.SelectedValue;
        key = string.IsNullOrEmpty(txt_key.Text.Trim()) ? Request["key"] : txt_key.Text.Trim();
        op = string.IsNullOrEmpty(ddl_order.SelectedValue) ? Request["op"] : ddl_order.SelectedValue;
        hp = string.IsNullOrEmpty(ddl_huodong.SelectedValue) ? Request["hp"] : ddl_huodong.SelectedValue;
        iskey = string.IsNullOrEmpty(ddl_iskey.SelectedValue) ? Request["iskey"] : ddl_iskey.SelectedValue;

        txt_date1.Text = date1;
        txt_date2.Text = date2;
        txt_key.Text = key;
        ddl_dianpu.SelectedValue = dp;
        ddl_state.SelectedValue = state;
        ddl_order.SelectedValue = op;
        ddl_huodong.SelectedValue = hp;
        ddl_iskey.SelectedValue = iskey;



        if (!IsPostBack)
        {
            Manager.Bind_DateTime(txt_date1);
            Manager.Bind_DateTime(txt_date2);
            Manager.Bind_DateTime(txt_date3);
            Manager.Bind_DateTime(txt_date4);
            BLL.dianpuManager.ddl_bind(ddl_dianpu, true);
            BLL.basic_huodongManager.ddl_bind(ddl_huodong, true);
            BLL.basic_order_planManager.ddl_bind(ddl_order, true);
            bind();
        }
    }


    #region bind
    void bind()
    {



        DateTime temp_date1 = new DateTime();
        DateTime temp_date2 = new DateTime();
        DateTime temp_date3 = new DateTime();
        DateTime temp_date4 = new DateTime();
        int temp_dp;
        int temp_op;
        int temp_hp;



        DateTime.TryParse(date1, out temp_date1);
        DateTime.TryParse(date2, out temp_date2);
        DateTime.TryParse(date3, out temp_date3);
        DateTime.TryParse(date4, out temp_date4);
        int.TryParse(dp, out temp_dp);
        int.TryParse(op, out temp_op);
        int.TryParse(hp, out temp_hp);

        //IList<basic_goods> list = BLL.basic_goodsManager.Search(AspNetPager1.StartRecordIndex, AspNetPager1.EndRecordIndex, key, temp_op, temp_hp, temp_dp, state, iskey, temp_date1, temp_date2, temp_date3, temp_date4, "");
        //AspNetPager1.RecordCount = list.Count;
        //lbl_count.Text = "(共" + AspNetPager1.RecordCount.ToString() + "条数据)";
        //GridView1.DataSource = list;
        //GridView1.DataBind();

        AspNetPager1.RecordCount = BLL.basic_goodsManager.SearchNum(key, temp_op, temp_hp, temp_dp, state, iskey, temp_date1, temp_date2, temp_date3, temp_date4);
        lbl_count.Text = "(共" + AspNetPager1.RecordCount.ToString() + "条数据)";
        GridView1.DataSource = AspNetPager1.RecordCount == 0 ? null : BLL.basic_goodsManager.Search(AspNetPager1.StartRecordIndex, AspNetPager1.EndRecordIndex, key, temp_op, temp_hp, temp_dp, state, iskey, temp_date1, temp_date2, temp_date3, temp_date4, "");
        GridView1.DataBind();



    }
    #endregion

    #region GridView1
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //try
        //{
        if (AJAXManager.GridView_ondblclick(e))
        {
            try
            {
                string State = GridView1.DataKeys[e.Row.RowIndex].Values["bgstate"].ToString();
                string dpid = GridView1.DataKeys[e.Row.RowIndex].Values["dpid"].ToString();
                string bgid = GridView1.DataKeys[e.Row.RowIndex].Values["bgid"].ToString();
                string hdid = GridView1.DataKeys[e.Row.RowIndex].Values["hdid"].ToString();
                string bgkey = GridView1.DataKeys[e.Row.RowIndex].Values["bgkey"].ToString();
                string opid = GridView1.DataKeys[e.Row.RowIndex].Values["opid"].ToString();
                string bgupdate = GridView1.DataKeys[e.Row.RowIndex].Values["bgupdate"].ToString();
                DateTime up_date = new DateTime();
                DateTime.TryParse(bgupdate, out up_date);

                LinkButton lb_state = e.Row.FindControl("lb_state") as LinkButton;
                LinkButton lb_key = e.Row.FindControl("lb_key") as LinkButton;
                Label lbl_dianpu = e.Row.FindControl("lbl_dianpu") as Label;
                Label lbl_order = e.Row.FindControl("lbl_order") as Label;
                Label lbl_huodong = e.Row.FindControl("lbl_huodong") as Label;


                //补单
                int temp_order = basic_order_planManager.GetNumInPlan(up_date, Convert.ToInt32(opid));
                int _order_count = BLL.basic_order_recordManager.SearchNum("", Convert.ToInt32(bgid), 0, 0, "", "", DateTime.Now, DateTime.Now);
                int res_count = temp_order - _order_count;
                if (res_count > 0)
                {
                    lbl_order.Text = "需补 " + (temp_order - _order_count).ToString() + " 单";
                    lbl_order.ForeColor = System.Drawing.Color.Red;
                    lbl_order.Font.Bold = true;
                }
                else
                {
                    lbl_order.Text = "无";
                    lbl_order.ForeColor = System.Drawing.Color.Black;
                }

                //活动提示
                basic_huodong hd = basic_huodongManager.SearchByID(Convert.ToInt32(hdid));
                int temp_huodong = Manager.DateDiff_GetInt(DateTime.Now, up_date) + 1;
                if (temp_huodong == hd.hdone || temp_huodong == hd.hdtwo)
                {
                    lbl_huodong.Text = "今日" + hd.hddate1.ToString("HH:mm") + "报名";
                    lbl_huodong.ForeColor = System.Drawing.Color.Red;
                    lbl_huodong.Font.Bold = true;
                }
                else
                {
                    lbl_huodong.Text = "无";
                    lbl_huodong.ForeColor = System.Drawing.Color.Black;
                }


                //状态
                if (State == "1")
                {
                    lb_state.Text = "启用";
                    lb_state.ForeColor = System.Drawing.Color.Red;
                    lb_state.Font.Bold = true;
                }
                else if (State == "2")
                {
                    lb_state.Text = "禁用";
                    lb_state.ForeColor = System.Drawing.Color.Blue;
                }

                //是否重点
                if (bgkey == "1")
                {
                    lb_key.Text = "是";
                    lb_key.ForeColor = System.Drawing.Color.Red;
                    lb_key.Font.Bold = true;
                }
                else if (bgkey == "2")
                {
                    lb_key.Text = "否";
                    lb_key.ForeColor = System.Drawing.Color.Blue;
                }

                //店铺
                dianpu dp = BLL.dianpuManager.GetInList(dpid);
                if (dp != null)
                {
                    lbl_dianpu.Text = dp.dpname;
                    lbl_dianpu.ForeColor = System.Drawing.Color.Green;
                    //    lb_account.NavigateUrl = "http://www.taobao.com/webww/ww.php?ver=3&touid=" + lb_account.Text + "&siteid=cntaobao&status=1&charset=utf-8";
                }


                //判断是否是编辑状态
                if (GridView1.EditIndex != e.Row.RowIndex)
                {
                    //LinkButton lb_zhifubao = e.Row.FindControl("lb_zhifubao") as LinkButton;

                    //HyperLink lb_account = e.Row.FindControl("lb_account") as HyperLink;
                    //lb_account.NavigateUrl = "http://www.taobao.com/webww/ww.php?ver=3&touid=" + lb_account.Text + "&siteid=cntaobao&status=1&charset=utf-8";
                    //lb_account.ForeColor = System.Drawing.Color.Blue;

                }

            }
            catch (Exception ex)
            {
                Common.ErrorLog.WriteEntry(ex);
            }
        }
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        TextBox txt_name = GridView1.Rows[e.RowIndex].FindControl("txt_name") as TextBox;
        TextBox txt_update = GridView1.Rows[e.RowIndex].FindControl("txt_update") as TextBox;
        TextBox txt_remark = GridView1.Rows[e.RowIndex].FindControl("txt_remark") as TextBox;

        int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values["bgid"]);
        basic_goods fx = BLL.basic_goodsManager.SearchByID(id);
        if (string.IsNullOrEmpty(txt_name.Text))
        {
            AJAXManager.Alert(this.UpdatePanel1, "请输入商品名称");
            return;
        }
        DateTime _dt = new DateTime();
        if (!DateTime.TryParse(txt_update.Text, out _dt))
        {
            AJAXManager.Alert(this.UpdatePanel1, "请输入正确的上架时间");
            return;
        }

        fx.bgname = txt_name.Text.Trim();
        fx.bgupdate = _dt;
        fx.bgremark = txt_remark.Text.Trim();
        //fx.bgdate = DateTime.Now;

        if (BLL.basic_goodsManager.Update(fx) != 1)
        {
            AJAXManager.Alert(this.UpdatePanel1, "修改失败");

        }
        else
        {
            GridView1.EditIndex = -1;
            bind();
        }
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        bind();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string state = e.CommandName;
        if (state == "state")
        {
            int id = Convert.ToInt32(GridView1.DataKeys[((e.CommandSource as LinkButton).NamingContainer as GridViewRow).RowIndex].Values["bgid"].ToString());
            if (id != 0)
            {
                basic_goods fx = BLL.basic_goodsManager.SearchByID(id);
                fx.bgstate = fx.bgstate == "1" ? "2" : "1";
                if (fx.bgstate == "2")
                {
                    //fx.bgdate = DateTime.Now;
                }
                if (BLL.basic_goodsManager.Update(fx) != 1)
                {
                    AJAXManager.Alert(this.UpdatePanel1, "修改失败");
                }
                else
                {
                    bind();
                }
            }
        }
        else if (state == "iskey")
        {
            int id = Convert.ToInt32(GridView1.DataKeys[((e.CommandSource as LinkButton).NamingContainer as GridViewRow).RowIndex].Values["bgid"].ToString());
            if (id != 0)
            {
                basic_goods fx = BLL.basic_goodsManager.SearchByID(id);
                fx.bgkey = fx.bgkey == "1" ? "2" : "1";
                //fx.bgdate = DateTime.Now;
                if (BLL.basic_goodsManager.Update(fx) != 1)
                {
                    AJAXManager.Alert(this.UpdatePanel1, "修改失败");
                }
                else
                {
                    bind();
                }
                //AJAXManager.Alert(UpdatePanel1, "test");
                //AJAXManager.Js(UpdatePanel1, "to_zhifubao('" + fx.fx_zhifubao + "','" + fx.fx_num + "')");
            }

        }
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        if (AJAXManager.GridView_ondblclick_Cancel(this.UpdatePanel1))
        {
            GridView1.EditIndex = -1;
            bind();
        }
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values["bgid"]);
        if (BLL.basic_goodsManager.Delete(id) != 1)
        {
            AJAXManager.Alert(this.UpdatePanel1, "删除失败");
        }
        else
        {
            AJAXManager.Alert(this.UpdatePanel1, "删除成功");
        }
        bind();
    }
    #endregion

    #region AspNetPager1_PageChanged
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        bind();
    }
    #endregion

    #region btn_save_Click
    protected void btn_save_Click(object sender, EventArgs e)
    {
        bind();
    }
    #endregion

    #region btn_del_Click
    protected void btn_del_Click(object sender, EventArgs e)
    {
        string temp_ckname = Request.Form.Get("checkboxname");
        string[] temp_id = temp_ckname.Split(new char[] { ',' });
        int res_ok = 0;
        int res_no = 0;
        foreach (string temp in temp_id)
        {
            int id = 0;
            if (int.TryParse(temp, out id))
            {
                if (BLL.basic_goodsManager.Delete(id) == 1)
                {
                    res_ok++;
                }
                else
                {
                    res_no++;
                }
            }
        }
        AJAXManager.Alert(this.UpdatePanel1, "批处理操作完成:\\n成功删除 " + res_ok.ToString() + " 条信息" + (res_no == 0 ? "" : "\\n删除失败" + res_no.ToString() + "条信息！请注意核实！"));
        bind();
    }

    #endregion

    #region btn_zong_Click
    //protected void btn_zong_Click(object sender, EventArgs e)
    //{
    //    double zong = BLL.basic_goodsManager.SearchSum();
    //    lbl_zong.Text = zong.ToString();
    //}
    #endregion
}