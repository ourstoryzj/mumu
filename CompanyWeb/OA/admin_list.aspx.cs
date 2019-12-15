using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entity;
using System.Collections;


public partial class OA_admin_list : WebPage
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind();
        }
    }


    #region bind
    void bind()
    {
        GridView1.DataSource = BLL.AdminsManager.SearchAll();
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
                string State = GridView1.DataKeys[e.Row.RowIndex].Values["astate"].ToString();
                LinkButton lb_state = e.Row.FindControl("lb_state") as LinkButton;
                string _type = GridView1.DataKeys[e.Row.RowIndex].Values["atype"].ToString();
                LinkButton lb_type = e.Row.FindControl("lb_type") as LinkButton;

                if (State == "1")
                {
                    lb_state.Text = "启用";
                    lb_state.ForeColor = System.Drawing.Color.Blue;
                }
                else if (State == "2")
                {
                    lb_state.Text = "禁用";
                    lb_state.ForeColor = System.Drawing.Color.Red;
                }

                if (_type == "1")
                {
                    lb_type.Text = "员工";
                    lb_type.ForeColor = System.Drawing.Color.Blue;
                }
                else if (_type == "2")
                {
                    lb_type.Text = "主管";
                    lb_type.ForeColor = System.Drawing.Color.Green;
                }
                else if (_type == "3")
                {
                    lb_type.Text = "经理";
                    lb_type.ForeColor = System.Drawing.Color.Red;
                }


            }
            catch (Exception ex) { Common.ErrorLog.WriteEntry(ex); }
        }
    }




    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        TextBox txt_account = GridView1.Rows[e.RowIndex].FindControl("txt_account") as TextBox;
        TextBox txt_pwd = GridView1.Rows[e.RowIndex].FindControl("txt_pwd") as TextBox;

        int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values["aid"]);
        Admins dp = BLL.AdminsManager.SearchByaid(id);
        dp.aaccount = string.IsNullOrEmpty(txt_account.Text) ? "" : txt_account.Text.Trim();
        dp.apassword = string.IsNullOrEmpty(txt_pwd.Text) ? "" : txt_pwd.Text.Trim();

        if (BLL.AdminsManager.Update(dp) != 1)
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
        string cmd = e.CommandName;
        if (cmd == "state")
        {
            int id = Convert.ToInt32(GridView1.DataKeys[((e.CommandSource as LinkButton).NamingContainer as GridViewRow).RowIndex].Values["aid"].ToString());
            if (id != 0)
            {
                Admins dp = BLL.AdminsManager.SearchByaid(id);
                dp.astate = dp.astate == "1" ? "2" : "1";
                if (BLL.AdminsManager.Update(dp) != 1)
                {
                    AJAXManager.Alert(this.UpdatePanel1, "修改失败");
                }
                else
                {
                    bind();
                }
            }
        }
        else if (cmd == "type")
        {
            int id = Convert.ToInt32(GridView1.DataKeys[((e.CommandSource as LinkButton).NamingContainer as GridViewRow).RowIndex].Values["aid"].ToString());
            if (id != 0)
            {
                Admins dp = BLL.AdminsManager.SearchByaid(id);
                if (dp.atype != "3")
                {
                    dp.atype = dp.atype == "1" ? "2" : "1";
                    if (BLL.AdminsManager.Update(dp) != 1)
                    {
                        AJAXManager.Alert(this.UpdatePanel1, "修改失败");
                    }
                    else
                    {
                        bind();
                    }
                }
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
    #endregion

    #region GridView1_RowDeleting
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values["aid"]);
        if (BLL.AdminsManager.Delete(id) != 1)
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

    #region btn_sort_Click
    //重新排序
    protected void btn_sort_Click(object sender, EventArgs e)
    {
    }
    #endregion
}