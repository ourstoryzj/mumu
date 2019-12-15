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

    protected void Page_Load(object sender, EventArgs e)
    {
        date1 = string.IsNullOrEmpty(txt_date1.Text.Trim()) ? Request["date1"] : txt_date1.Text.Trim();
        date2 = string.IsNullOrEmpty(txt_date2.Text.Trim()) ? Request["date2"] : txt_date2.Text.Trim();
        state = string.IsNullOrEmpty(ddl_state.SelectedValue) ? Request["state"] : ddl_state.SelectedValue;
        key = string.IsNullOrEmpty(txt_key.Text.Trim()) ? Request["key"] : txt_key.Text.Trim();
        txt_date1.Text = date1;
        txt_date2.Text = date2;
        txt_key.Text = key;
        ddl_state.SelectedValue = state;

        if (!IsPostBack)
        {
            Manager.Bind_DateTime(txt_date1);
            Manager.Bind_DateTime(txt_date2);
            bind();
        }
    }


    #region bind
    void bind()
    {

        date1 = txt_date1.Text.Trim();
        date2 = txt_date2.Text.Trim();
        state = ddl_state.SelectedValue;
        key = txt_key.Text.Trim();

        DateTime temp_date1 = new DateTime();
        DateTime temp_date2 = new DateTime();
        int temp_dp;
        DateTime.TryParse(date1, out temp_date1);
        DateTime.TryParse(date2, out temp_date2);
        int.TryParse(dp, out temp_dp);

        AspNetPager1.RecordCount = BLL.basic_taskManager.SearchNum(key, state, temp_date1, temp_date2, new DateTime(), new DateTime());
        GridView1.DataSource = AspNetPager1.RecordCount == 0 ? null : BLL.basic_taskManager.Search(AspNetPager1.StartRecordIndex, AspNetPager1.EndRecordIndex, key, state, temp_date1, temp_date2, new DateTime(), new DateTime(), "");
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
                string State = GridView1.DataKeys[e.Row.RowIndex].Values["btstate"].ToString();
                 


                LinkButton lb_state = e.Row.FindControl("lb_state") as LinkButton;
                

                //状态
                if (State == "1")
                {
                    lb_state.Text = "未处理";
                    lb_state.ForeColor = System.Drawing.Color.Blue;
                }
                else if (State == "2")
                {
                    lb_state.Text = "已完成";
                    lb_state.ForeColor = System.Drawing.Color.Red;
                    lb_state.Font.Bold = true;
                }
                

                //判断是否是编辑状态
                if (GridView1.EditIndex != e.Row.RowIndex)
                {
                     


                }
            }
            catch (Exception ex) { Common.ErrorLog.WriteEntry(ex); }

        }
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        TextBox txt_name = GridView1.Rows[e.RowIndex].FindControl("txt_name") as TextBox;
        TextBox txt_remark = GridView1.Rows[e.RowIndex].FindControl("txt_remark") as TextBox;
        int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values["btid"]);
        basic_task sh = basic_taskManager.SearchByID(id);
        sh.btname = txt_name.Text.Trim();
        sh.btcontent = txt_remark.Text.Trim();



        if (BLL.basic_taskManager.Update(sh) != 1)
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
            int id = Convert.ToInt32(GridView1.DataKeys[((e.CommandSource as LinkButton).NamingContainer as GridViewRow).RowIndex].Values["btid"].ToString());
            if (id != 0)
            {
                basic_task sh = BLL.basic_taskManager.SearchByID(id);
                sh.btstate = (sh.btstate == "1" ? "2" : "1");
                if (BLL.basic_taskManager.Update(sh) != 1)
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
        int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values["btid"]);
        if (BLL.basic_taskManager.Delete(id) != 1)
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
                if (BLL.basic_taskManager.Delete(id) == 1)
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