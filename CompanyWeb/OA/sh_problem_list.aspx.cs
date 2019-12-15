using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entity;


public partial class OA_sh_problem_list : WebPage
{

    string date1;
    string date2;
    string dp;
    string state;
    string key;

    protected void Page_Load(object sender, EventArgs e)
    {
        date1 = string.IsNullOrEmpty(txt_date1.Text.Trim()) ? Request["date1"] : txt_date1.Text.Trim();
        date2 = string.IsNullOrEmpty(txt_date2.Text.Trim()) ? Request["date2"] : txt_date2.Text.Trim();
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

        DateTime temp_date1 = new DateTime();
        DateTime temp_date2 = new DateTime();
        int temp_dp;
        DateTime.TryParse(date1, out temp_date1);
        DateTime.TryParse(date2, out temp_date2);
        int.TryParse(dp, out temp_dp);

        AspNetPager1.RecordCount = BLL.shouhouManager.SearchNum(key, temp_dp, temp_date1, temp_date2, state);

        GridView1.DataSource = AspNetPager1.RecordCount == 0 ? null : BLL.shouhouManager.Search(AspNetPager1.StartRecordIndex, AspNetPager1.EndRecordIndex, key, temp_dp, temp_date1, temp_date2, state, "");
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
                string State = GridView1.DataKeys[e.Row.RowIndex].Values["shstate"].ToString();
                string dianpu = GridView1.DataKeys[e.Row.RowIndex].Values["dpid"].ToString();
                LinkButton lb_state = e.Row.FindControl("lb_state") as LinkButton;

                Label lbl_dianpu = e.Row.FindControl("lbl_dianpu") as Label;

                if (State == "1")
                {
                    lb_state.Text = "未处理";
                    lb_state.ForeColor = System.Drawing.Color.Blue;
                }
                else if (State == "2")
                {
                    lb_state.Text = "已投诉";
                    lb_state.ForeColor = System.Drawing.Color.Red;
                }
                else if (State == "3")
                {
                    lb_state.Text = "已处理";
                    lb_state.ForeColor = System.Drawing.Color.Green;
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
                    HyperLink lb_account = e.Row.FindControl("lb_account") as HyperLink;
                    lb_account.NavigateUrl = "http://www.taobao.com/webww/ww.php?ver=3&touid=" + lb_account.Text + "&siteid=cntaobao&status=1&charset=utf-8";
                    lb_account.ForeColor = System.Drawing.Color.Blue;
                }
            }
            catch (Exception ex) { Common.ErrorLog.WriteEntry(ex); }

        }
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        TextBox txt_ordercode = GridView1.Rows[e.RowIndex].FindControl("txt_ordercode") as TextBox;
        //TextBox txt_name = GridView1.Rows[e.RowIndex].FindControl("txt_name") as TextBox;
        TextBox txt_account = GridView1.Rows[e.RowIndex].FindControl("txt_account") as TextBox;
        TextBox txt_yuanyin = GridView1.Rows[e.RowIndex].FindControl("txt_yuanyin") as TextBox;
        TextBox txt_kdcode = GridView1.Rows[e.RowIndex].FindControl("txt_kdcode") as TextBox;

        int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values["shid"]);
        shouhou sh = BLL.shouhouManager.SearchByshid(id);
        sh.shordercode = txt_ordercode.Text.Trim();
        //sh.shname = txt_name.Text.Trim();
        sh.shaccount = txt_account.Text.Trim();
        sh.shkdcode = txt_kdcode.Text.Trim();
        sh.shyuanyin = txt_yuanyin.Text.Trim();

        if (BLL.shouhouManager.Update(sh) != 1)
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
            int id = Convert.ToInt32(GridView1.DataKeys[((e.CommandSource as LinkButton).NamingContainer as GridViewRow).RowIndex].Values["shid"].ToString());
            if (id != 0)
            {
                shouhou sh = BLL.shouhouManager.SearchByshid(id);
                sh.shstate = (sh.shstate == "1" ? "2" : (sh.shstate == "2" ? "3" : "1"));
                if (BLL.shouhouManager.Update(sh) != 1)
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
        int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values["shid"]);
        if (BLL.shouhouManager.Delete(id) != 1)
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
}