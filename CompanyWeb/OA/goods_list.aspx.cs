using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entity;


public partial class OA_goods_list : WebPage
{

    string date1;
    string date2;
    string state_img;
    string state_up;
    string state_title;
    string hasImg_tb;
    string hasImg_mgj;
    string key;
    string state_important;


    protected void Page_Load(object sender, EventArgs e)
    {
        date1 = string.IsNullOrEmpty(txt_date1.Text.Trim()) ? Request["date1"] : txt_date1.Text.Trim();
        date2 = string.IsNullOrEmpty(txt_date2.Text.Trim()) ? Request["date2"] : txt_date2.Text.Trim();
        state_img = string.IsNullOrEmpty(ddl_state_img.SelectedValue) ? Request["state_img"] : ddl_state_img.SelectedValue;
        state_up = string.IsNullOrEmpty(ddl_state_up.SelectedValue) ? Request["state_up"] : ddl_state_up.SelectedValue;
        state_title = string.IsNullOrEmpty(ddl_state_title.SelectedValue) ? Request["state_title"] : ddl_state_title.SelectedValue;
        hasImg_tb = string.IsNullOrEmpty(ddl_hasImg_tb.SelectedValue) ? Request["hasImg_tb"] : ddl_hasImg_tb.SelectedValue;
        hasImg_mgj = string.IsNullOrEmpty(ddl_hasImg_mgj.SelectedValue) ? Request["hasImg_mgj"] : ddl_hasImg_mgj.SelectedValue;
        key = string.IsNullOrEmpty(txt_key.Text.Trim()) ? Request["key"] : txt_key.Text.Trim();
        state_important = string.IsNullOrEmpty(ddl_state_important.SelectedValue) ? Request["state_important"] : ddl_state_important.SelectedValue;
        txt_date1.Text = date1;
        txt_date2.Text = date2;
        txt_key.Text = key;
        ddl_hasImg_mgj.SelectedValue = hasImg_mgj;
        ddl_hasImg_tb.SelectedValue = hasImg_tb;
        ddl_state_img.SelectedValue = state_img;
        ddl_state_title.SelectedValue = state_title;
        ddl_state_up.SelectedValue = state_up;
        ddl_state_important.SelectedValue = state_important;



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
        DateTime temp_date1 = new DateTime();
        DateTime temp_date2 = new DateTime();
        DateTime.TryParse(date1, out temp_date1);
        DateTime.TryParse(date2, out temp_date2);
        AspNetPager1.RecordCount = BLL.goodsManager.SearchNum(key, 0, state_img, state_up, state_title, hasImg_tb, hasImg_mgj, temp_date1, temp_date2, state_important);
        GridView1.DataSource = AspNetPager1.RecordCount == 0 ? null : BLL.goodsManager.Search(AspNetPager1.StartRecordIndex, AspNetPager1.EndRecordIndex, key, 0, state_img, state_up, state_title, hasImg_tb, hasImg_mgj, temp_date1, temp_date2, state_important);
        GridView1.DataBind();

        txt_date1.Text = date1;
        txt_date2.Text = date2;
        txt_key.Text = key;
        ddl_hasImg_mgj.SelectedValue = hasImg_mgj;
        ddl_hasImg_tb.SelectedValue = hasImg_tb;
        ddl_state_img.SelectedValue = state_img;
        ddl_state_title.SelectedValue = state_title;
        ddl_state_up.SelectedValue = state_up;
        ddl_state_important.SelectedValue = state_important;

    }
    #endregion

    #region GridView1
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //try
        //{
        if (AJAXManager.GridView_ondblclick(e))
        {

            object obj_gimg = GridView1.DataKeys[e.Row.RowIndex].Values["gimg"];
            object obj_gimg2 = GridView1.DataKeys[e.Row.RowIndex].Values["gimg2"];
            object obj_gurl = GridView1.DataKeys[e.Row.RowIndex].Values["gurl"];
            object obj_gurl2 = GridView1.DataKeys[e.Row.RowIndex].Values["gurl2"];
            object obj_gprice1 = GridView1.DataKeys[e.Row.RowIndex].Values["gprice1"];
            object obj_gprice2 = GridView1.DataKeys[e.Row.RowIndex].Values["gprice2"];
            object obj_gurl_yuan = GridView1.DataKeys[e.Row.RowIndex].Values["gurl_yuan"];

            string gimg = obj_gimg == null ? "" : obj_gimg.ToString();
            string gimg2 = obj_gimg2 == null ? "" : obj_gimg2.ToString();
            string gurl = obj_gurl == null ? "" : obj_gurl.ToString();
            string gurl2 = obj_gurl2 == null ? "" : obj_gurl2.ToString();
            string gprice1 = obj_gprice1 == null ? "" : obj_gprice1.ToString();
            string gprice2 = obj_gprice2 == null ? "" : obj_gprice2.ToString();
            string gurl_yuan = obj_gurl_yuan == null ? "" : obj_gurl_yuan.ToString();


            HyperLink hl_state_img_tb = e.Row.FindControl("hl_state_img_tb") as HyperLink;
            HyperLink hl_state_img_mgj = e.Row.FindControl("hl_state_img_mgj") as HyperLink;
            HyperLink hl_price_tb = e.Row.FindControl("hl_price_tb") as HyperLink;
            HyperLink hl_price_mgj = e.Row.FindControl("hl_price_mgj") as HyperLink;
            HyperLink hl_url_yuan = e.Row.FindControl("hl_url_yuan") as HyperLink;

            if (!string.IsNullOrEmpty(gimg))
            {
                hl_state_img_tb.Text = "有图";
                hl_state_img_tb.NavigateUrl = "~/OA/upload/" + gimg;
                hl_state_img_tb.ForeColor = System.Drawing.Color.Blue;
            }
            if (!string.IsNullOrEmpty(gimg2))
            {
                hl_state_img_mgj.Text = "有图";
                hl_state_img_mgj.NavigateUrl = "~/OA/upload/" + gimg2;
                hl_state_img_mgj.ForeColor = System.Drawing.Color.Blue;
            }



            object obj_gstate1 = GridView1.DataKeys[e.Row.RowIndex].Values["gstate1"];
            object obj_gstate2 = GridView1.DataKeys[e.Row.RowIndex].Values["gstate2"];
            object obj_gstate3 = GridView1.DataKeys[e.Row.RowIndex].Values["gstate3"];
            object obj_important = GridView1.DataKeys[e.Row.RowIndex].Values["g_standby1"];
            string gstate1 = obj_gstate1 == null ? "" : obj_gstate1.ToString();
            string gstate2 = obj_gstate2 == null ? "" : obj_gstate2.ToString();
            string gstate3 = obj_gstate3 == null ? "" : obj_gstate3.ToString();
            string gstate_important = obj_important == null ? "" : obj_important.ToString();
            LinkButton lb_state_up = e.Row.FindControl("lb_state_up") as LinkButton;
            LinkButton lb_state_img = e.Row.FindControl("lb_state_img") as LinkButton;
            LinkButton lb_state_yh = e.Row.FindControl("lb_state_yh") as LinkButton;
            LinkButton lb_state_important = e.Row.FindControl("lb_state_important") as LinkButton;
            //判断是否是编辑状态
            if (GridView1.EditIndex != e.Row.RowIndex)
            {

                hl_price_tb.Text = string.IsNullOrEmpty(gprice1) ? "暂无" : gprice1;
                if (!string.IsNullOrEmpty(gurl))
                {
                    hl_price_tb.NavigateUrl = Manager.AddString_Http(gurl);
                    hl_price_tb.ForeColor = System.Drawing.Color.Blue;
                }
                hl_price_mgj.Text = string.IsNullOrEmpty(gprice2) ? "暂无" : gprice2;
                if (!string.IsNullOrEmpty(gurl2))
                {
                    hl_price_mgj.NavigateUrl = Manager.AddString_Http(gurl2);
                    hl_price_mgj.ForeColor = System.Drawing.Color.Blue;
                }
                hl_url_yuan.Text = string.IsNullOrEmpty(gurl_yuan) ? "暂无" : "点击可查看";
                if (!string.IsNullOrEmpty(gurl_yuan))
                {
                    hl_url_yuan.NavigateUrl = Manager.AddString_Http(gurl_yuan);
                    hl_url_yuan.ForeColor = System.Drawing.Color.Blue;
                }
            }
            try
            {
                if (gstate1 == "1")
                {
                    lb_state_img.Text = "未上传";
                    lb_state_img.ForeColor = System.Drawing.Color.Red;
                }
                else if (gstate1 == "2")
                {
                    lb_state_img.Text = "已上传";
                    lb_state_img.ForeColor = System.Drawing.Color.Green;
                }

                if (gstate2 == "1")
                {
                    lb_state_up.Text = "未上架";
                    lb_state_up.ForeColor = System.Drawing.Color.Red;
                }
                else if (gstate2 == "2")
                {
                    lb_state_up.Text = "已上架";
                    lb_state_up.ForeColor = System.Drawing.Color.Green;
                }

                if (gstate3 == "1")
                {
                    lb_state_yh.Text = "未优化";
                    lb_state_yh.ForeColor = System.Drawing.Color.Red;
                }
                else if (gstate3 == "2")
                {
                    lb_state_yh.Text = "已优化";
                    lb_state_yh.ForeColor = System.Drawing.Color.Green;
                }
                if (gstate_important == "2")
                {
                    lb_state_important.Text = "是";
                    lb_state_important.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    lb_state_important.Text = "否";
                    lb_state_important.ForeColor = System.Drawing.Color.Green;
                }
            }
            catch (Exception ex)
            {
                Common.ErrorLog.WriteEntry(ex);
            }


        }
        //}
        //catch (Exception ex)
        //{
        //    Common.ErrorLog.WriteEntry(ex);
        //}
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        TextBox txt_name = GridView1.Rows[e.RowIndex].FindControl("txt_name") as TextBox;
        TextBox txt_price_tb = GridView1.Rows[e.RowIndex].FindControl("txt_price_tb") as TextBox;
        TextBox txt_price_mgj = GridView1.Rows[e.RowIndex].FindControl("txt_price_mgj") as TextBox;
        TextBox txt_remark = GridView1.Rows[e.RowIndex].FindControl("txt_remark") as TextBox;
        TextBox txt_url_yuan = GridView1.Rows[e.RowIndex].FindControl("txt_url_yuan") as TextBox;


        int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values["gid"]);
        goods g = BLL.goodsManager.SearchBygid(id);
        g.gname = txt_name.Text.Trim();
        g.gprice1 = txt_price_tb.Text.Trim();
        g.gprice2 = txt_price_mgj.Text.Trim();
        g.gremark1 = txt_remark.Text.Trim();
        g.gurl_yuan = txt_url_yuan.Text.Trim();

        if (BLL.goodsManager.Update(g) != 1)
        {
            AJAXManager.Alert(this.UpdatePanel1, "修改失败");
        }
        if (AJAXManager.GridView_ondblclick_Cancel(this.UpdatePanel1))
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
        if (state == "state_up")
        {
            int id = Convert.ToInt32(GridView1.DataKeys[((e.CommandSource as LinkButton).NamingContainer as GridViewRow).RowIndex].Values["gid"].ToString());
            if (id != 0)
            {
                goods g = BLL.goodsManager.SearchBygid(id);
                g.gstate2 = g.gstate2 == "1" ? "2" : "1";
                if (g.gstate2 == "2")
                {
                    g.gdate2 = DateTime.Now;
                }
                if (BLL.goodsManager.Update(g) != 1)
                {
                    AJAXManager.Alert(this.UpdatePanel1, "修改失败");
                }
                else
                {
                    bind();
                }
            }

        }
        if (state == "state_img")
        {
            int id = Convert.ToInt32(GridView1.DataKeys[((e.CommandSource as LinkButton).NamingContainer as GridViewRow).RowIndex].Values["gid"].ToString());
            if (id != 0)
            {
                goods g = BLL.goodsManager.SearchBygid(id);
                g.gstate1 = g.gstate1 == "1" ? "2" : "1";
                if (g.gstate1 == "2")
                {
                    g.gdate1 = DateTime.Now;
                }
                if (BLL.goodsManager.Update(g) != 1)
                {
                    AJAXManager.Alert(this.UpdatePanel1, "修改失败");
                }
                else
                {
                    bind();
                }
            }

        }
        if (state == "state_yh")
        {
            int id = Convert.ToInt32(GridView1.DataKeys[((e.CommandSource as LinkButton).NamingContainer as GridViewRow).RowIndex].Values["gid"].ToString());
            if (id != 0)
            {
                goods g = BLL.goodsManager.SearchBygid(id);
                g.gstate3 = g.gstate3 == "1" ? "2" : "1";
                if (g.gstate3 == "2")
                {
                    g.gdate3 = DateTime.Now;
                }
                if (BLL.goodsManager.Update(g) != 1)
                {
                    AJAXManager.Alert(this.UpdatePanel1, "修改失败");
                }
                else
                {
                    bind();
                }
            }
        }
        if (state == "state_important")
        {
            int id = Convert.ToInt32(GridView1.DataKeys[((e.CommandSource as LinkButton).NamingContainer as GridViewRow).RowIndex].Values["gid"].ToString());
            if (id != 0)
            {
                goods g = BLL.goodsManager.SearchBygid(id);
                g.g_standby1 = g.g_standby1 == "1" ? "2" : "1";
                if (BLL.goodsManager.Update(g) != 1)
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
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values["gid"]);
        if (BLL.goodsManager.Delete(id) != 1)
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

    #region btn_save_Click
    protected void btn_save_Click(object sender, EventArgs e)
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
                if (BLL.goodsManager.Delete(id) == 1)
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