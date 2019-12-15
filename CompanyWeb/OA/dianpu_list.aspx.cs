using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entity;
using System.Collections;


public partial class OA_dianpu_list : WebPage
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
        GridView1.DataSource = BLL.dianpuManager.SearchAll();
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
                string State = GridView1.DataKeys[e.Row.RowIndex].Values["dpstate"].ToString();
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
        TextBox txt_remark = GridView1.Rows[e.RowIndex].FindControl("txt_remark") as TextBox;
        TextBox txt_sort = GridView1.Rows[e.RowIndex].FindControl("txt_sort") as TextBox;

        int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values["dpid"]);
        dianpu dp = BLL.dianpuManager.SearchBydpid(id);
        dp.dpname = string.IsNullOrEmpty(txt_name.Text) ? "" : txt_name.Text.Trim();
        dp.dpremark = string.IsNullOrEmpty(txt_name.Text) ? "" : txt_remark.Text.Trim();
        //dp.dpsort = string.IsNullOrEmpty(txt_sort.Text) ? "" : txt_sort.Text.Trim();

        if (BLL.dianpuManager.Update(dp) != 1)
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
            int id = Convert.ToInt32(GridView1.DataKeys[((e.CommandSource as LinkButton).NamingContainer as GridViewRow).RowIndex].Values["dpid"].ToString());
            if (id != 0)
            {
                dianpu dp = BLL.dianpuManager.SearchBydpid(id);
                dp.dpstate = dp.dpstate == "1" ? "2" : "1";
                if (BLL.dianpuManager.Update(dp) != 1)
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
        int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values["dpid"]);
        if (BLL.dianpuManager.Delete(id) != 1)
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
        System.Threading.Thread.Sleep(1000);
        try
        {
            IList<dianpu> list = BLL.dianpuManager.SearchAll();
            int num = 1;
            foreach (dianpu dp in list)
            {
                dp.dpsort = num;
                BLL.dianpuManager.Update(dp);
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