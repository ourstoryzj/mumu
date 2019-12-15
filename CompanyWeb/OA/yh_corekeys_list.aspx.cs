using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entity;
using System.Collections;


public partial class OA_yh_corekeys_list : WebPage
{

    string date1;
    string date2;
    string gt;
    string state;
    string key;

    protected void Page_Load(object sender, EventArgs e)
    {
        date1 = string.IsNullOrEmpty(txt_date1.Text.Trim()) ? Request["date1"] : txt_date1.Text.Trim();
        date2 = string.IsNullOrEmpty(txt_date2.Text.Trim()) ? Request["date2"] : txt_date2.Text.Trim();
        gt = string.IsNullOrEmpty(ddl_goodstype.SelectedValue) ? Request["gt"] : ddl_goodstype.SelectedValue;
        state = string.IsNullOrEmpty(ddl_state.SelectedValue) ? Request["state"] : ddl_state.SelectedValue;
        key = string.IsNullOrEmpty(txt_key.Text.Trim()) ? Request["key"] : txt_key.Text.Trim();
        txt_date1.Text = date1;
        txt_date2.Text = date2;
        txt_key.Text = key;
        ddl_goodstype.SelectedValue = gt;
        ddl_state.SelectedValue = state;

        if (!IsPostBack)
        {
            Manager.Bind_DateTime(txt_date1);
            Manager.Bind_DateTime(txt_date2);
            BLL.yh_goodstypeManager.ddl_bind(ddl_goodstype, true);
            bind();
        }
    }


    #region bind
    void bind()
    {
        DateTime temp_date1 = new DateTime();
        DateTime temp_date2 = new DateTime();
        int temp_gt;
        DateTime.TryParse(date1, out temp_date1);
        DateTime.TryParse(date2, out temp_date2);
        int.TryParse(gt, out temp_gt);

        AspNetPager1.RecordCount = BLL.yh_corekeysManager.SearchNum(key, temp_gt, state, temp_date1, temp_date2);

        GridView1.DataSource = AspNetPager1.RecordCount == 0 ? null : BLL.yh_corekeysManager.Search(AspNetPager1.StartRecordIndex, AspNetPager1.EndRecordIndex, key, temp_gt, state, temp_date1, temp_date2, "");
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
                string State = GridView1.DataKeys[e.Row.RowIndex].Values["ckstate"].ToString();
                string gtid = GridView1.DataKeys[e.Row.RowIndex].Values["gtid"].ToString();
                LinkButton lb_state = e.Row.FindControl("lb_state") as LinkButton;

                Label lbl_goodstype = e.Row.FindControl("lbl_goodstype") as Label;

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

                IList<yh_goodstype> list = BLL.yh_goodstypeManager.GetList(true);
                foreach (yh_goodstype g in list)
                {
                    if (g.gtid.ToString() == gtid)
                    {
                        lbl_goodstype.Text = g.gtanme;
                        lbl_goodstype.ForeColor = System.Drawing.Color.Green;
                        break;
                    }
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

        int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values["ckid"]);
        yh_corekeys ck = BLL.yh_corekeysManager.SearchByckid(id);
        ck.ckname = string.IsNullOrEmpty(txt_name.Text) ? "" : txt_name.Text.Trim();
        ck.ckremark = string.IsNullOrEmpty(txt_name.Text) ? "" : txt_remark.Text.Trim();
        ck.cksort = string.IsNullOrEmpty(txt_sort.Text) ? "" : txt_sort.Text.Trim();

        if (BLL.yh_corekeysManager.Update(ck) != 1)
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
            int id = Convert.ToInt32(GridView1.DataKeys[((e.CommandSource as LinkButton).NamingContainer as GridViewRow).RowIndex].Values["ckid"].ToString());
            if (id != 0)
            {
                yh_corekeys ck = BLL.yh_corekeysManager.SearchByckid(id);
                ck.ckstate = ck.ckstate == "1" ? "2" : "1";
                if (BLL.yh_corekeysManager.Update(ck) != 1)
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
    #endregion

 

    #region GridView1_RowDeleting
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values["ckid"]);
        if (BLL.yh_corekeysManager.Delete(id) != 1)
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
            IList<yh_corekeys> list = BLL.yh_corekeysManager.SearchAll();
            int num = 1;
            foreach (yh_corekeys ck in list)
            {
                ck.cksort = num.ToString();
                BLL.yh_corekeysManager.Update(ck);
                num++;
            }
            AJAXManager.Alert(this.UpdatePanel1, "排序成功");
            bind();
        }
        catch {
            AJAXManager.Alert(this.UpdatePanel1, "排序失败,请联系张建");
        }
    }
    #endregion

    #region btn_save_Click
    protected void btn_save_Click(object sender, EventArgs e)
    {
        bind();
    }
    #endregion
}