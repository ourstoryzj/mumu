using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entity;
using System.IO;


public partial class OA_sd_record_list : WebPage
{

    string date1;
    string date2;
    string _type;
    string state;
    string key;

    protected void Page_Load(object sender, EventArgs e)
    {
        date1 = string.IsNullOrEmpty(txt_date1.Text.Trim()) ? Request["date1"] : txt_date1.Text.Trim();
        date2 = string.IsNullOrEmpty(txt_date2.Text.Trim()) ? Request["date2"] : txt_date2.Text.Trim();
        _type = string.IsNullOrEmpty(ddl_type.SelectedValue) ? Request["type"] : ddl_type.SelectedValue;
        state = string.IsNullOrEmpty(ddl_state.SelectedValue) ? Request["state"] : ddl_state.SelectedValue;
        key = string.IsNullOrEmpty(txt_key.Text.Trim()) ? Request["key"] : txt_key.Text.Trim();
        txt_date1.Text = date1;
        txt_date2.Text = date2;
        txt_key.Text = key;
        ddl_type.SelectedValue = _type;
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
        _type = ddl_type.SelectedValue;
        state = ddl_state.SelectedValue;
        key = txt_key.Text.Trim();

        DateTime temp_date1 = new DateTime();
        DateTime temp_date2 = new DateTime();
        DateTime.TryParse(date1, out temp_date1);
        DateTime.TryParse(date2, out temp_date2);

        AspNetPager1.RecordCount = BLL.shuadan_recordManager.SearchNum(key, state, _type, temp_date1, temp_date2);
        lbl_count.Text = "(共" + AspNetPager1.RecordCount.ToString() + "条数据)";
        GridView1.DataSource = AspNetPager1.RecordCount == 0 ? null : BLL.shuadan_recordManager.Search(AspNetPager1.StartRecordIndex, AspNetPager1.EndRecordIndex, key, state, _type, temp_date1, temp_date2);
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
                string srstate = GridView1.DataKeys[e.Row.RowIndex].Values["srstate"].ToString();
                string srtype = GridView1.DataKeys[e.Row.RowIndex].Values["srtype"].ToString();
                LinkButton lb_state = e.Row.FindControl("lb_state") as LinkButton;
                LinkButton lb_type = e.Row.FindControl("lb_type") as LinkButton;



                if (srstate == "1")
                {
                    lb_state.Text = "正常";
                    lb_state.ForeColor = System.Drawing.Color.Blue;
                }
                else if (srstate == "2")
                {
                    lb_state.Text = "失效";
                    lb_state.ForeColor = System.Drawing.Color.Red;
                }
                if (srtype == "1")
                {
                    lb_type.Text = "账号信息";
                    lb_type.ForeColor = System.Drawing.Color.Blue;
                }
                else if (srtype == "2")
                {
                    lb_type.Text = "导入收货信息";
                    lb_type.ForeColor = System.Drawing.Color.Green;
                }
                else if (srtype == "3")
                {
                    lb_type.Text = "生成收货信息";
                    lb_type.ForeColor = System.Drawing.Color.LawnGreen;
                }
                else if (srtype == "4")
                {
                    lb_type.Text = "评价信息";
                    lb_type.ForeColor = System.Drawing.Color.LightBlue;
                }
                else if (srtype == "5")
                {
                    lb_type.Text = "转换空包网格式";
                    lb_type.ForeColor = System.Drawing.Color.Crimson;
                }
                else if (srtype == "6")
                {
                    lb_type.Text = "自定义转换格式";
                    lb_type.ForeColor = System.Drawing.Color.Crimson;
                }

            }
            catch (Exception ex) { Common.ErrorLog.WriteEntry(ex); }

        }
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        TextBox txt_name = GridView1.Rows[e.RowIndex].FindControl("txt_name") as TextBox;
        TextBox txt_num = GridView1.Rows[e.RowIndex].FindControl("txt_num") as TextBox;
        TextBox txt_remark = GridView1.Rows[e.RowIndex].FindControl("txt_remark") as TextBox;

        int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values["srid"]);
        shuadan_record sr = BLL.shuadan_recordManager.SearchBysrid(id);
        sr.srname = txt_name.Text.Trim();
        sr.srnum = txt_num.Text.Trim();
        sr.srremark = txt_remark.Text.Trim();
        if (BLL.shuadan_recordManager.Update(sr) != 1)
        {
            Manager.Alert("修改失败", Page);
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
            int id = Convert.ToInt32(GridView1.DataKeys[((e.CommandSource as LinkButton).NamingContainer as GridViewRow).RowIndex].Values["srid"].ToString());
            if (id != 0)
            {
                shuadan_record sr = BLL.shuadan_recordManager.SearchBysrid(id);
                sr.srstate = sr.srstate == "1" ? "2" : "1";
                if (BLL.shuadan_recordManager.Update(sr) != 1)
                {
                    Manager.Alert("修改失败", Page);
                }
                else
                {
                    GridView1.EditIndex = -1;
                    bind();
                }
            }
        }
        else if (state == "type")
        {
            int id = Convert.ToInt32(GridView1.DataKeys[((e.CommandSource as LinkButton).NamingContainer as GridViewRow).RowIndex].Values["srid"].ToString());
            if (id != 0)
            {
                shuadan_record sr = BLL.shuadan_recordManager.SearchBysrid(id);
                sr.srtype = sr.srtype == "1" ? "2" : (sr.srtype == "2" ? "3" : (sr.srtype == "3" ? "4" : "1"));
                if (BLL.shuadan_recordManager.Update(sr) != 1)
                {
                    Manager.Alert("修改失败", Page);
                }
                else
                {
                    GridView1.EditIndex = -1;
                    bind();
                }
            }
        }
        else if (state == "Download")
        {
            int index = ((e.CommandSource as LinkButton).NamingContainer as GridViewRow).RowIndex;
            int id = Convert.ToInt32(GridView1.DataKeys[index].Values["srid"].ToString());
            shuadan_record sr = BLL.shuadan_recordManager.SearchBysrid(id);
            sr.srcount = sr.srcount + 1;
            Manager.FileDownload(sr.srpath, sr.srname, sr);
        }

    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        bind();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values["srid"]);
        if (BLL.shuadan_recordManager.Delete(id) != 1)
        {
            Manager.Alert("删除失败", Page);
        }
        else
        {
            Manager.Alert("删除成功", Page);
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
                if (BLL.shuadan_recordManager.Delete(id) == 1)
                {
                    res_ok++;
                }
                else
                {
                    res_no++;
                }
            }
        }
        Manager.Alert("批处理操作完成:\\n成功删除 " + res_ok.ToString() + " 条信息" + (res_no == 0 ? "" : "\\n删除失败" + res_no.ToString() + "条信息！请注意核实！"), Page);
        bind();
    }
    #endregion




}