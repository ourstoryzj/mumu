using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entity;
using System.IO;


public partial class OA_sd_account_list : WebPage
{

    string date1;
    string date2;
    string courier;
    string key;
    //IList<courier> list;

    protected void Page_Load(object sender, EventArgs e)
    {
        date1 = string.IsNullOrEmpty(txt_date1.Text.Trim()) ? Request["date1"] : txt_date1.Text.Trim();
        date2 = string.IsNullOrEmpty(txt_date2.Text.Trim()) ? Request["date2"] : txt_date2.Text.Trim();
        courier = string.IsNullOrEmpty(ddl_courier.SelectedValue) ? Request["courier"] : ddl_courier.SelectedValue;
        key = string.IsNullOrEmpty(txt_key.Text.Trim()) ? Request["key"] : txt_key.Text.Trim();
        txt_date1.Text = date1;
        txt_date2.Text = date2;
        txt_key.Text = key;
        ddl_courier.SelectedValue = courier;
        BLL.courierManager.ddl_bind(ddl_courier, true);
        //list = BLL.courierManager.GetList();

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
        courier = ddl_courier.SelectedValue;
        key = txt_key.Text.Trim();

        DateTime temp_date1 = new DateTime();
        DateTime temp_date2 = new DateTime();
        DateTime.TryParse(date1, out temp_date1);
        DateTime.TryParse(date2, out temp_date2);

        AspNetPager1.RecordCount = BLL.return_goodsManager.SearchNum(key,courier.ToString(), temp_date1, temp_date2);
        lbl_count.Text = "(共" + AspNetPager1.RecordCount.ToString() + "条数据)";
        GridView1.DataSource = AspNetPager1.RecordCount == 0 ? null : BLL.return_goodsManager.Search(AspNetPager1.StartRecordIndex, AspNetPager1.EndRecordIndex, key, courier.ToString(), temp_date1, temp_date2);
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
                string rgcode = GridView1.DataKeys[e.Row.RowIndex].Values["rgcode"].ToString();
                string cid = GridView1.DataKeys[e.Row.RowIndex].Values["cid"].ToString();
                HyperLink hl_code = e.Row.FindControl("hl_code") as HyperLink;


                if (cid == "1")
                {
                    hl_code.NavigateUrl = "http://www.kiees.cn/yto.php?wen=" + rgcode;
                }
                else if (cid == "2")
                {
                    hl_code.NavigateUrl = "http://www.kiees.cn/sto.php?wen=" + rgcode;
                }
                else  
                {
                     hl_code.NavigateUrl= "http://www.kiees.cn/xuan.php?wen=" + rgcode;
                }
                hl_code.ForeColor = System.Drawing.Color.Blue;
            }
            catch (Exception ex) { Common.ErrorLog.WriteEntry(ex); }

        }
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        TextBox txt_code = GridView1.Rows[e.RowIndex].FindControl("txt_code") as TextBox;
        TextBox txt_remark = GridView1.Rows[e.RowIndex].FindControl("txt_remark") as TextBox;

        int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values["rgid"]);
        return_goods sa = BLL.return_goodsManager.SearchByID(id);
        sa.rgcode = txt_code.Text.Trim();
        sa.rgremark = txt_remark.Text.Trim();
        if (BLL.return_goodsManager.Update(sa) != 1)
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
        //if (state == "state")
        //{
        //    int id = Convert.ToInt32(GridView1.DataKeys[((e.CommandSource as LinkButton).NamingContainer as GridViewRow).RowIndex].Values["spid"].ToString());
        //    if (id != 0)
        //    {
        //        shuadan_pingjia sa = BLL.shuadan_pingjiaManager.SearchByspid(id);
        //        sa.spstate = sa.spstate == "1" ? "2" : "1";
        //        if (BLL.shuadan_pingjiaManager.Update(sa) != 1)
        //        {
        //            AJAXManager.Alert(this.UpdatePanel1, "修改失败");
        //        }
        //        else
        //        {
        //            GridView1.EditIndex = -1;
        //            bind();
        //        }
        //    }
        //}
        //else if (state == "type")
        //{
        //    int id = Convert.ToInt32(GridView1.DataKeys[((e.CommandSource as LinkButton).NamingContainer as GridViewRow).RowIndex].Values["spid"].ToString());
        //    if (id != 0)
        //    {
        //        shuadan_pingjia sa = BLL.shuadan_pingjiaManager.SearchByspid(id);
        //        sa.sptype = sa.sptype == "1" ? "2" : (sa.sptype == "2" ? "3" : "1");
        //        if (BLL.shuadan_pingjiaManager.Update(sa) != 1)
        //        {
        //            AJAXManager.Alert(this.UpdatePanel1, "修改失败");
        //        }
        //        else
        //        {
        //            GridView1.EditIndex = -1;
        //            bind();
        //        }
        //    }
        //}

    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        bind();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values["rgid"]);
        if (BLL.return_goodsManager.Delete(id) != 1)
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
        //string temp_ckname = Request.Form.Get("checkboxname");
        //string[] temp_id = temp_ckname.Split(new char[] { ',' });
        string[] temp_id = Manager.GetCheckBoxName(Page);
        if (temp_id == null)
        {
            AJAXManager.Alert(this.UpdatePanel1,"请选择要删除的数据");
            return;
        }
        int res_ok = 0;
        int res_no = 0;
        foreach (string temp in temp_id)
        {
            int id = 0;
            if (int.TryParse(temp, out id))
            {
                if (BLL.return_goodsManager.Delete(id) == 1)
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