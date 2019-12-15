using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entity;
using System.Collections;


public partial class OA_huashu_type_list : WebPage
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
        GridView1.DataSource = BLL.huashuManager.SearchAll("");
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
                string State = GridView1.DataKeys[e.Row.RowIndex].Values["hstate"].ToString();
                LinkButton lb_state = e.Row.FindControl("lb_state") as LinkButton;
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


            }
            catch (Exception ex) { Common.ErrorLog.WriteEntry(ex); }
        }
    }




    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        TextBox txt_name = GridView1.Rows[e.RowIndex].FindControl("txt_name") as TextBox;
        TextBox txt_sort = GridView1.Rows[e.RowIndex].FindControl("txt_sort") as TextBox;

        int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values["hid"]);
        huashu dp = BLL.huashuManager.SearchByID(id);
        int sort = 0;
        string str_sort = txt_sort.Text.Trim();
        if (string.IsNullOrEmpty(str_sort))
        {
            AJAXManager.Alert(this.UpdatePanel1, "请输入排序");
            return;
        }
        else if (!int.TryParse(str_sort, out sort))
        {
            AJAXManager.Alert(this.UpdatePanel1, "请输入正确的排序");
            return;
        }
        dp.htitle = string.IsNullOrEmpty(txt_name.Text) ? "" : txt_name.Text.Trim();
        dp.hsort = sort;

        if (BLL.huashuManager.Update(dp) != 1)
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
            int id = Convert.ToInt32(GridView1.DataKeys[((e.CommandSource as LinkButton).NamingContainer as GridViewRow).RowIndex].Values["hid"].ToString());
            if (id != 0)
            {
                huashu dp = BLL.huashuManager.SearchByID(id);
                dp.hstate = dp.hstate == "1" ? "2" : "1";
                if (BLL.huashuManager.Update(dp) != 1)
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
        int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values["hid"]);
        if (BLL.huashuManager.Delete(id) != 1)
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
        try
        {
            IList<huashu> list = BLL.huashuManager.SearchAll("");
            int num = 1;
            foreach (huashu dp in list)
            {
                dp.hsort = num;
                BLL.huashuManager.Update(dp);
                num++;
            }
            AJAXManager.Alert(UpdatePanel1, "排序成功");
        }
        catch
        {
            AJAXManager.Alert(UpdatePanel1, "排序失败,请联系张建");
        }
        bind();
    }
    #endregion
}