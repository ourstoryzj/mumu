using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entity;


public partial class OA_sd_address_list : WebPage
{
    string state;
    string key;
    string count;

    protected void Page_Load(object sender, EventArgs e)
    {

        state = string.IsNullOrEmpty(ddl_state.SelectedValue) ? Request["state"] : ddl_state.SelectedValue;
        key = string.IsNullOrEmpty(txt_key.Text.Trim()) ? Request["key"] : txt_key.Text.Trim();
        count = string.IsNullOrEmpty(txt_count.Text.Trim()) ? Request["count"] : txt_count.Text.Trim();
        txt_key.Text = key;
        ddl_state.SelectedValue = state;
        txt_count.Text = count;

        if (!IsPostBack)
        {
            bind();
        }
    }


    #region bind
    void bind()
    {

        state = ddl_state.SelectedValue;
        key = txt_key.Text.Trim();
        int _count = 0;
        if (!int.TryParse(count, out _count))
        {
            AspNetPager1.RecordCount = BLL.addressManager.SearchNum(key, state);
        }
        else
        {
            AspNetPager1.RecordCount = _count;
        }
        lbl_count.Text = "(共" + AspNetPager1.RecordCount.ToString() + "条数据)";
        GridView1.DataSource = AspNetPager1.RecordCount == 0 ? null : BLL.addressManager.Search(AspNetPager1.StartRecordIndex, AspNetPager1.EndRecordIndex, key, state, _count == 0 ? "" : _count.ToString());
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
                string sdastate = GridView1.DataKeys[e.Row.RowIndex].Values["astate"].ToString();
                LinkButton lb_state = e.Row.FindControl("lb_state") as LinkButton;



                if (sdastate == "1")
                {
                    lb_state.Text = "未使用";
                    lb_state.ForeColor = System.Drawing.Color.Blue;
                }
                else if (sdastate == "2")
                {
                    lb_state.Text = "已使用";
                    lb_state.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex) { Common.ErrorLog.WriteEntry(ex); }

        }
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        TextBox txt_remark = GridView1.Rows[e.RowIndex].FindControl("txt_remark") as TextBox;

        int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values["aid"]);
        address sa = BLL.addressManager.SearchByaid(id);
        sa.aremark = txt_remark.Text.Trim();
        if (BLL.addressManager.Update(sa) != 1)
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
            int id = Convert.ToInt32(GridView1.DataKeys[((e.CommandSource as LinkButton).NamingContainer as GridViewRow).RowIndex].Values["aid"].ToString());
            if (id != 0)
            {
                address sa = BLL.addressManager.SearchByaid(id);
                sa.astate = sa.astate == "1" ? "2" : "1";
                if (BLL.addressManager.Update(sa) != 1)
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
        int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values["aid"]);
        if (BLL.addressManager.Delete(id) != 1)
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
                if (BLL.addressManager.Delete(id) == 1)
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