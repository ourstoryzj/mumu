using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entity;
using System.Collections;


public partial class OA_pages_list : WebPage
{

    string date1;
    string date2;
    string state;
    string key;
    string ptid;
    IList<pages_type> ptlist;

    protected void Page_Load(object sender, EventArgs e)
    {
        date1 = string.IsNullOrEmpty(txt_date1.Text.Trim()) ? Request["date1"] : txt_date1.Text.Trim();
        date2 = string.IsNullOrEmpty(txt_date2.Text.Trim()) ? Request["date2"] : txt_date2.Text.Trim();
        state = string.IsNullOrEmpty(ddl_state.SelectedValue) ? Request["state"] : ddl_state.SelectedValue;
        key = string.IsNullOrEmpty(txt_key.Text.Trim()) ? Request["key"] : txt_key.Text.Trim();
        ptid = string.IsNullOrEmpty(ddl_pagestype.SelectedValue) ? Request["ptid"] : ddl_pagestype.SelectedValue;
        txt_date1.Text = date1;
        txt_date2.Text = date2;
        txt_key.Text = key;
        ddl_state.SelectedValue = state;
        ptlist = BLL.pages_typeManager.GetList("");
        if (!IsPostBack)
        {
            BLL.pages_typeManager.ddl_bind(ddl_pagestype, true);
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
        ptid = ddl_pagestype.SelectedValue;
        DateTime temp_date1 = new DateTime();
        DateTime temp_date2 = new DateTime();
        DateTime.TryParse(date1, out temp_date1);
        DateTime.TryParse(date2, out temp_date2);
        int _ptid = string.IsNullOrEmpty(ptid) ? 0 : Convert.ToInt32(ptid);


        AspNetPager1.RecordCount = BLL.pagesManager.SearchNum(key, state, _ptid, new DateTime(), new DateTime());
        lbl_count.Text = "(共" + AspNetPager1.RecordCount.ToString() + "条数据)";
        GridView1.DataSource = AspNetPager1.RecordCount == 0 ? null : BLL.pagesManager.Search(AspNetPager1.StartRecordIndex, AspNetPager1.EndRecordIndex, key, state, _ptid, temp_date1, temp_date2);
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
                string State = GridView1.DataKeys[e.Row.RowIndex].Values["pstate"].ToString();
                int ptid = Convert.ToInt32(GridView1.DataKeys[e.Row.RowIndex].Values["ptid"]);

                LinkButton lb_state = e.Row.FindControl("lb_state") as LinkButton;
                Label lbl_type = e.Row.FindControl("lbl_type") as Label;

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


                pages_type pt = BLL.pages_typeManager.SearchByID(ptid);
                if (pt != null)
                {
                    lbl_type.Text = pt.ptname;
                }




            }
            catch (Exception ex) { Common.ErrorLog.WriteEntry(ex); }
        }
    }




    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        TextBox txt_name = GridView1.Rows[e.RowIndex].FindControl("txt_name") as TextBox;
        TextBox txt_sort = GridView1.Rows[e.RowIndex].FindControl("txt_sort") as TextBox;

        int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values["pid"]);
        pages dp = BLL.pagesManager.SearchByID(id);
        dp.pname = string.IsNullOrEmpty(txt_name.Text) ? "" : txt_name.Text.Trim();
        dp.psort = string.IsNullOrEmpty(txt_sort.Text) ? 0 : Convert.ToInt32(txt_sort.Text.Trim());

        if (BLL.pagesManager.Update(dp) != 1)
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
            int id = Convert.ToInt32(GridView1.DataKeys[((e.CommandSource as LinkButton).NamingContainer as GridViewRow).RowIndex].Values["pid"].ToString());
            if (id != 0)
            {
                pages dp = BLL.pagesManager.SearchByID(id);
                dp.pstate = dp.pstate == "1" ? "2" : "1";
                if (BLL.pagesManager.Update(dp) != 1)
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
        int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values["pid"]);
        if (BLL.pagesManager.Delete(id) != 1)
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
        //System.Threading.Thread.Sleep(1000);
        try
        {
            IList<pages> list = BLL.pagesManager.SearchAll();
            int num = 1;
            foreach (pages dp in list)
            {
                dp.psort = num;
                BLL.pagesManager.Update(dp);
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
                if (BLL.pagesManager.Delete(id) == 1)
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

    #region btn_search_Click
    protected void btn_search_Click(object sender, EventArgs e)
    {
        bind();
    }
    #endregion
}