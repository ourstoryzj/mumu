using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entity;


public partial class OA_fanxian_list : WebPage
{

    string date1;
    string date2;
    string date3;
    string date4;
    string dp;
    string state;
    string key;

    protected void Page_Load(object sender, EventArgs e)
    {
        date1 = string.IsNullOrEmpty(txt_date1.Text.Trim()) ? Request["date1"] : txt_date1.Text.Trim();
        date2 = string.IsNullOrEmpty(txt_date2.Text.Trim()) ? Request["date2"] : txt_date2.Text.Trim();
        date3 = string.IsNullOrEmpty(txt_date3.Text.Trim()) ? Request["date3"] : txt_date3.Text.Trim();
        date4 = string.IsNullOrEmpty(txt_date4.Text.Trim()) ? Request["date4"] : txt_date4.Text.Trim();
        dp = string.IsNullOrEmpty(ddl_dianpu.SelectedValue) ? Request["dp"] : ddl_dianpu.SelectedValue;
        state = string.IsNullOrEmpty(ddl_state.SelectedValue) ? Request["state"] : ddl_state.SelectedValue;
        key = string.IsNullOrEmpty(txt_key.Text.Trim()) ? Request["key"] : txt_key.Text.Trim();
        txt_date1.Text = date1;
        txt_date2.Text = date2;
        txt_key.Text = key;
        ddl_dianpu.SelectedValue = dp;
        ddl_state.SelectedValue = state;

        if (!IsPostBack)
        {
            Manager.Bind_DateTime(txt_date1);
            Manager.Bind_DateTime(txt_date2);
            Manager.Bind_DateTime(txt_date3);
            Manager.Bind_DateTime(txt_date4);
            BLL.dianpuManager.ddl_bind(ddl_dianpu, true);
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
        DateTime.TryParse(date1, out temp_date1);
        DateTime.TryParse(date2, out temp_date2);
        DateTime.TryParse(date3, out temp_date3);
        DateTime.TryParse(date4, out temp_date4);
        int.TryParse(dp, out temp_dp);

        AspNetPager1.RecordCount = BLL.fanxianManager.SearchNum(key, state, temp_dp, temp_date1, temp_date2, temp_date3, temp_date4);
        lbl_count.Text = "(共" + AspNetPager1.RecordCount.ToString()+ "条数据)";
        GridView1.DataSource = AspNetPager1.RecordCount == 0 ? null : BLL.fanxianManager.Search(AspNetPager1.StartRecordIndex, AspNetPager1.EndRecordIndex, key, state, temp_dp, temp_date1, temp_date2, temp_date2, temp_date3, "");
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
                string State = GridView1.DataKeys[e.Row.RowIndex].Values["fx_state"].ToString();
                string dianpu = GridView1.DataKeys[e.Row.RowIndex].Values["dpid"].ToString();
                string fxid = GridView1.DataKeys[e.Row.RowIndex].Values["fx_id"].ToString();
                string price = GridView1.DataKeys[e.Row.RowIndex].Values["fx_num"].ToString();
                LinkButton lb_state = e.Row.FindControl("lb_state") as LinkButton;
                Label lbl_dianpu = e.Row.FindControl("lbl_dianpu") as Label;


                if (State == "1")
                {
                    lb_state.Text = "未返现";
                    lb_state.ForeColor = System.Drawing.Color.Blue;
                }
                else if (State == "2")
                {
                    lb_state.Text = "已处理";
                    lb_state.ForeColor = System.Drawing.Color.Green;
                }
                else if (State == "3")
                {
                    lb_state.Text = "有问题";
                    lb_state.ForeColor = System.Drawing.Color.Red;
                }
                IList<dianpu> list = BLL.dianpuManager.GetList(false);
                foreach (dianpu dp in list)
                {
                    if (dp.dpid.ToString() == dianpu)
                    {
                        lbl_dianpu.Text = dp.dpname;
                        lbl_dianpu.ForeColor = System.Drawing.Color.Green;
                        //if (dp.dpremark.IndexOf("淘宝") > 0)
                        //{
                        //    lb_account.NavigateUrl = "http://www.taobao.com/webww/ww.php?ver=3&touid=" + lb_account.Text + "&siteid=cntaobao&status=1&charset=utf-8";
                        //    lb_account.ForeColor = System.Drawing.Color.Blue;
                        //}
                        break;
                    }
                }

                //判断是否是编辑状态
                if (GridView1.EditIndex != e.Row.RowIndex)
                {
                    //Label lbl_zhifubao = e.Row.FindControl("lbl_zhifubao") as Label;
                    LinkButton lb_zhifubao = e.Row.FindControl("lb_zhifubao") as LinkButton;

                    HyperLink lb_account = e.Row.FindControl("lb_account") as HyperLink;
                    lb_account.NavigateUrl = "http://www.taobao.com/webww/ww.php?ver=3&touid=" + lb_account.Text + "&siteid=cntaobao&status=1&charset=utf-8";
                    lb_account.ForeColor = System.Drawing.Color.Blue;

                    //支付宝打款
                    try
                    {

                        object obj = GridView1.DataKeys[e.Row.RowIndex].Values["fx_zhifubao"];
                        if (obj != null)
                        {
                            string zhifubao = obj.ToString();
                            if (!string.IsNullOrEmpty(zhifubao) && !string.IsNullOrEmpty(price))
                            {
                                //判断返现次数
                                int n = BLL.fanxianManager.SearchNum(zhifubao, "", 0, new DateTime(), new DateTime(), new DateTime(), new DateTime());
                                lb_zhifubao.ForeColor = System.Drawing.Color.Red;
                                if (n > 1)
                                {
                                    lb_zhifubao.ForeColor = System.Drawing.Color.Silver;
                                    lb_zhifubao.Font.Bold = true;
                                    lb_zhifubao.ToolTip = "该支付宝已经返现" + n.ToString() + "次，请留意！";
                                }

                                //添加返现功能
                                string js = n > 1 ? "alert('该用户已经返现" + n.ToString() + "次，确定要继续返现么？');to_zhifubao('" + zhifubao + "','" + price + "');" : "to_zhifubao('" + zhifubao + "','" + price + "');";
                                lb_zhifubao.Attributes["onclick"] = js;

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Common.ErrorLog.WriteEntry(ex);
                    }
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
        TextBox txt_account = GridView1.Rows[e.RowIndex].FindControl("txt_account") as TextBox;
        TextBox txt_zhifubao = GridView1.Rows[e.RowIndex].FindControl("txt_zhifubao") as TextBox;
        TextBox txt_num = GridView1.Rows[e.RowIndex].FindControl("txt_num") as TextBox;
        TextBox txt_remark = GridView1.Rows[e.RowIndex].FindControl("txt_remark") as TextBox;

        int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values["fx_id"]);
        fanxian fx = BLL.fanxianManager.SearchByfx_id(id);
        fx.fx_num = Convert.ToDecimal(txt_num.Text.Trim());
        fx.fx_remark = txt_remark.Text.Trim();
        fx.fx_zhifubao = txt_zhifubao.Text.Trim();
        fx.fx_account = txt_account.Text.Trim();

        if (BLL.fanxianManager.Update(fx) != 1)
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
            int id = Convert.ToInt32(GridView1.DataKeys[((e.CommandSource as LinkButton).NamingContainer as GridViewRow).RowIndex].Values["fx_id"].ToString());
            if (id != 0)
            {
                fanxian fx = BLL.fanxianManager.SearchByfx_id(id);
                fx.fx_state = fx.fx_state == "1" ? "2" : (fx.fx_state == "2" ? "3" : "1");
                if (fx.fx_state == "2")
                {
                    fx.fx_date2 = DateTime.Now;
                }
                if (BLL.fanxianManager.Update(fx) != 1)
                {
                    AJAXManager.Alert(this.UpdatePanel1, "修改失败");
                }
                else
                {
                    bind();
                }
            }
        }
        else if (state == "fanxian")
        {
            int id = Convert.ToInt32(GridView1.DataKeys[((e.CommandSource as LinkButton).NamingContainer as GridViewRow).RowIndex].Values["fx_id"].ToString());
            if (id != 0)
            {
                fanxian fx = BLL.fanxianManager.SearchByfx_id(id);
                fx.fx_state = "2";
                fx.fx_date2 = DateTime.Now;
                if (BLL.fanxianManager.Update(fx) != 1)
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
        int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values["fx_id"]);
        if (BLL.fanxianManager.Delete(id) != 1)
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
        int res_ok=0;
        int res_no=0;
        foreach (string temp in temp_id)
        {
            int id = 0;
            if (int.TryParse(temp, out id))
            {
                if (BLL.fanxianManager.Delete(id) == 1)
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
    protected void btn_zong_Click(object sender, EventArgs e)
    {
        double zong = BLL.fanxianManager.SearchSum();
        lbl_zong.Text = zong.ToString();
    }
    #endregion
}