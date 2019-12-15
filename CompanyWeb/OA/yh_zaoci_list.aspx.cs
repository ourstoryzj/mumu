using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entity;
using System.Collections;


public partial class OA_yh_zaoci_list : WebPage
{

    string date1;
    string date2;
    string gt;
    string state;
    string key;

    protected void Page_Load(object sender, EventArgs e)
    {
        date1 = Request["date1"];
        date2 = Request["date2"];
        gt = Request["gt"];
        state = Request["state"];
        key = Request["key"];


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
        
        AspNetPager1.RecordCount = BLL.yh_zaociManager.SearchNum("", "", temp_gt, new DateTime(), new DateTime());

        GridView1.DataSource = AspNetPager1.RecordCount == 0 ? null : BLL.yh_zaociManager.Search(AspNetPager1.StartRecordIndex, AspNetPager1.EndRecordIndex, key, state, temp_gt, temp_date1, temp_date2, "");
        GridView1.DataBind();

        txt_date1.Text = date1;
        txt_date2.Text = date2;
        txt_key.Text = key;
        ddl_goodstype.SelectedValue = gt;
        ddl_state.SelectedValue = state;
        Manager.GridView_ondblclick_Bind(GridView1);//双击事件

    }
    #endregion

    #region GridView1
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            try
            {
                Manager.GridView_RowColor(e);
                Manager.GridView_ondblclick(e);//双击事件
                string State = GridView1.DataKeys[e.Row.RowIndex].Values["zstate"].ToString();
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

        int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values["zid"]);
        yh_zaoci zc = BLL.yh_zaociManager.SearchByID(id);
        zc.zname = string.IsNullOrEmpty(txt_name.Text) ? "" : txt_name.Text.Trim();
        zc.gtname = string.IsNullOrEmpty(txt_name.Text) ? "" : txt_remark.Text.Trim();

        if (BLL.yh_zaociManager.Update(zc) != 1)
        {
            Manager.Alert("修改失败", Page);
        }
        Manager.GridView_ondblclick_Cancel(Page);
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
            int id = Convert.ToInt32(GridView1.DataKeys[((e.CommandSource as LinkButton).NamingContainer as GridViewRow).RowIndex].Values["zid"].ToString());
            if (id != 0)
            {
                yh_zaoci zc = BLL.yh_zaociManager.SearchByID(id);
                zc.zstate = zc.zstate == "1" ? "2" : "1";
                if (BLL.yh_zaociManager.Update(zc) != 1)
                {
                    Manager.Alert("修改失败", Page);
                }
            }
            Manager.page_href_reload(Page);
        }
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        Manager.GridView_ondblclick_Cancel(Page);
    }
    #endregion

    #region GridView1_RowDeleting
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values["zid"]);
        if (BLL.yh_zaociManager.Delete(id) != 1)
        {
            Manager.Alert("删除失败", Page);
        }
        else
        {
            Manager.Alert("删除成功", Page);
        }
        Manager.page_href_reload(Page);
    }
    #endregion

    #region AspNetPager1_PageChanged
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        bind();
    }
    #endregion

     
}