using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entity;


public partial class OA_basic_order_record_list : WebPage
{

    string date1;
    string date2;
    string dp;
    string state;
    string key;
    string maijiaxiu;
    int bgid;
    int gkid;

    protected void Page_Load(object sender, EventArgs e)
    {
        date1 = string.IsNullOrEmpty(txt_date1.Text.Trim()) ? Request["date1"] : txt_date1.Text.Trim();
        date2 = string.IsNullOrEmpty(txt_date2.Text.Trim()) ? Request["date2"] : txt_date2.Text.Trim();
        dp = string.IsNullOrEmpty(ddl_dianpu.SelectedValue) ? Request["dp"] : ddl_dianpu.SelectedValue;
        state = string.IsNullOrEmpty(ddl_state.SelectedValue) ? Request["state"] : ddl_state.SelectedValue;
        key = string.IsNullOrEmpty(txt_key.Text.Trim()) ? Request["key"] : txt_key.Text.Trim();
        maijiaxiu = string.IsNullOrEmpty(txt_key.Text.Trim()) ? Request["maijiaxiu"] : ddl_maijiaxiu.SelectedValue;
        txt_date1.Text = date1;
        txt_date2.Text = date2;
        txt_key.Text = key;
        ddl_dianpu.SelectedValue = dp;
        ddl_state.SelectedValue = state;
        int.TryParse(Request["bgid"], out bgid);
        int.TryParse(Request["gkid"], out gkid);

        if (!IsPostBack)
        {
            Manager.Bind_DateTime(txt_date1);
            Manager.Bind_DateTime(txt_date2);
            BLL.dianpuManager.ddl_bind(ddl_dianpu, true);
            bind();
        }
    }


    #region bind
    void bind()
    {

        date1 = txt_date1.Text.Trim();
        date2 = txt_date2.Text.Trim();
        dp = ddl_dianpu.SelectedValue;
        state = ddl_state.SelectedValue;
        key = txt_key.Text.Trim();
        maijiaxiu = ddl_maijiaxiu.SelectedValue;

        DateTime temp_date1 = new DateTime();
        DateTime temp_date2 = new DateTime();
        int temp_dp;
        DateTime.TryParse(date1, out temp_date1);
        DateTime.TryParse(date2, out temp_date2);
        int.TryParse(dp, out temp_dp);

        AspNetPager1.RecordCount = BLL.basic_order_recordManager.SearchNum(key, bgid, temp_dp, gkid, maijiaxiu, state, temp_date1, temp_date2);

        GridView1.DataSource = AspNetPager1.RecordCount == 0 ? null : BLL.basic_order_recordManager.Search(AspNetPager1.StartRecordIndex, AspNetPager1.EndRecordIndex, key, bgid, temp_dp, gkid, maijiaxiu, state, temp_date1, temp_date2, "");
        GridView1.DataBind();
    }
    #endregion

    #region GridView1
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (AJAXManager.GridView_ondblclick(e))
        {
            try
            {
                string State = GridView1.DataKeys[e.Row.RowIndex].Values["orprepare1"].ToString();
                string dianpu = GridView1.DataKeys[e.Row.RowIndex].Values["dpid"].ToString();
                //string orid = GridView1.DataKeys[e.Row.RowIndex].Values["orid"].ToString();
                //string bgid = GridView1.DataKeys[e.Row.RowIndex].Values["bgid"].ToString();
                string ormaijiaxiu = GridView1.DataKeys[e.Row.RowIndex].Values["ormaijiaxiu"].ToString();
                //string orqq = GridView1.DataKeys[e.Row.RowIndex].Values["orqq"].ToString();
                //string orwangwang = GridView1.DataKeys[e.Row.RowIndex].Values["orwangwang"].ToString();


                LinkButton lb_state = e.Row.FindControl("lb_state") as LinkButton;
                LinkButton lb_maijiaxiu = e.Row.FindControl("lb_maijiaxiu") as LinkButton;
                Label lbl_dianpu = e.Row.FindControl("lbl_dianpu") as Label;

                //状态
                if (State == "1")
                {
                    lb_state.Text = "已评价";
                    lb_state.ForeColor = System.Drawing.Color.Blue;
                }
                else if (State == "2")
                {
                    lb_state.Text = "未评价";
                    lb_state.ForeColor = System.Drawing.Color.Red;
                    lb_state.Font.Bold = true;
                }
                //买家秀
                if (ormaijiaxiu == "1")
                {
                    lb_maijiaxiu.Text = "是";
                    lb_maijiaxiu.ForeColor = System.Drawing.Color.Red;
                    lb_maijiaxiu.Font.Bold = true;
                }
                else if (ormaijiaxiu == "2")
                {
                    lb_maijiaxiu.Text = "否";
                    lb_maijiaxiu.ForeColor = System.Drawing.Color.Blue;
                }

                //店铺
                dianpu dp = dianpuManager.GetInList(dianpu);
                if (dp != null)
                {
                    lbl_dianpu.Text = dp.dpname;
                    lbl_dianpu.ForeColor = System.Drawing.Color.Green;
                }


                //判断是否是编辑状态
                if (GridView1.EditIndex != e.Row.RowIndex)
                {
                    HyperLink lb_wangwang = e.Row.FindControl("lb_wangwang") as HyperLink;
                    lb_wangwang.NavigateUrl = "http://www.taobao.com/webww/ww.php?ver=3&touid=" + lb_wangwang.Text + "&siteid=cntaobao&status=1&charset=utf-8";
                    lb_wangwang.ForeColor = System.Drawing.Color.Blue;
                    HyperLink lb_qq = e.Row.FindControl("lb_qq") as HyperLink;
                    lb_qq.NavigateUrl = "tencent://message/?uin=" + lb_qq.Text + "&Site=我的网站&Menu=yes";
                    lb_qq.ForeColor = System.Drawing.Color.Blue;


                }
            }
            catch (Exception ex) { Common.ErrorLog.WriteEntry(ex); }

        }
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        TextBox txt_name = GridView1.Rows[e.RowIndex].FindControl("txt_name") as TextBox;
        TextBox txt_key = GridView1.Rows[e.RowIndex].FindControl("txt_key") as TextBox;
        TextBox txt_wuliu = GridView1.Rows[e.RowIndex].FindControl("txt_wuliu") as TextBox;
        TextBox txt_wangwang = GridView1.Rows[e.RowIndex].FindControl("txt_wangwang") as TextBox;
        TextBox txt_qq = GridView1.Rows[e.RowIndex].FindControl("txt_qq") as TextBox;
        TextBox txt_price = GridView1.Rows[e.RowIndex].FindControl("txt_price") as TextBox;
        TextBox txt_remark = GridView1.Rows[e.RowIndex].FindControl("txt_remark") as TextBox;

        int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values["orid"]);
        basic_order_record sh = BLL.basic_order_recordManager.SearchByID(id);
        sh.bgname = txt_name.Text.Trim();
        sh.gkname = txt_key.Text.Trim();
        sh.bgwuliu = txt_wuliu.Text.Trim();
        sh.orprice = txt_price.Text.Trim();
        sh.orqq = txt_qq.Text.Trim();
        sh.orremark = txt_remark.Text.Trim();
        sh.orwangwang = txt_wangwang.Text.Trim();



        if (BLL.basic_order_recordManager.Update(sh) != 1)
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
            int id = Convert.ToInt32(GridView1.DataKeys[((e.CommandSource as LinkButton).NamingContainer as GridViewRow).RowIndex].Values["orid"].ToString());
            if (id != 0)
            {
                basic_order_record sh = BLL.basic_order_recordManager.SearchByID(id);
                sh.orprepare1 = (sh.orprepare1 == "1" ? "2" : "1");
                if (BLL.basic_order_recordManager.Update(sh) != 1)
                {
                    AJAXManager.Alert(this.UpdatePanel1, "修改失败");
                }
                else
                {
                    GridView1.EditIndex = -1;
                    bind();
                }
            }
        }
        else if (state == "maijiaxiu")
        {
            int id = Convert.ToInt32(GridView1.DataKeys[((e.CommandSource as LinkButton).NamingContainer as GridViewRow).RowIndex].Values["orid"].ToString());
            if (id != 0)
            {
                basic_order_record sh = BLL.basic_order_recordManager.SearchByID(id);
                sh.ormaijiaxiu = (sh.ormaijiaxiu == "1" ? "2" : "1");
                if (BLL.basic_order_recordManager.Update(sh) != 1)
                {
                    AJAXManager.Alert(this.UpdatePanel1, "修改失败");
                }
                else
                {
                    GridView1.EditIndex = -1;
                    bind();
                }
            }
        }
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        bind();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values["orid"]);
        if (BLL.basic_order_recordManager.Delete(id) != 1)
        {
            AJAXManager.Alert(this.UpdatePanel1, "删除失败");
        }
        else
        {
            AJAXManager.Alert(this.UpdatePanel1, "删除成功");
            bind();
        }
    }
    #endregion

    #region AspNetPager1_PageChanged
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        bind();
    }
    #endregion

    #region btn_search_Click
    protected void btn_search_Click(object sender, EventArgs e)
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
                if (BLL.basic_order_recordManager.Delete(id) == 1)
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
}