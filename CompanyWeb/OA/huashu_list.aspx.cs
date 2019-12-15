using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entity;
using System.IO;


public partial class OA_huashu_list : WebPage
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
        BLL.huashuManager.ddl_bind(ddl_type, true);
        date1 = txt_date1.Text.Trim();
        date2 = txt_date2.Text.Trim();
        _type = ddl_type.SelectedValue;
        state = ddl_state.SelectedValue;
        key = txt_key.Text.Trim();

        DateTime temp_date1 = new DateTime();
        DateTime temp_date2 = new DateTime();
        DateTime.TryParse(date1, out temp_date1);
        DateTime.TryParse(date2, out temp_date2);

        AspNetPager1.RecordCount = BLL.huashuManager.SearchNum(key, state, _type, temp_date1, temp_date2);
        lbl_count.Text = "(共" + AspNetPager1.RecordCount.ToString() + "条数据)";
        GridView1.DataSource = AspNetPager1.RecordCount == 0 ? null : BLL.huashuManager.Search(AspNetPager1.StartRecordIndex, AspNetPager1.EndRecordIndex, key, state, _type, temp_date1, temp_date2);
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
                string hstate = GridView1.DataKeys[e.Row.RowIndex].Values["hstate"].ToString();
                string hfid = GridView1.DataKeys[e.Row.RowIndex].Values["hfid"].ToString();
                string hemail = GridView1.DataKeys[e.Row.RowIndex].Values["hsendemail"] !=null ? GridView1.DataKeys[e.Row.RowIndex].Values["hsendemail"].ToString():"2";
                //string hemail = GridView1.DataKeys[e.Row.RowIndex].Values["hsendemail"].ToString();
                LinkButton lb_state = e.Row.FindControl("lb_state") as LinkButton;
                LinkButton lb_email = e.Row.FindControl("lb_email") as LinkButton;
                Label lbl_type = e.Row.FindControl("lbl_type") as Label;


                if (hstate == "1")
                {
                    lb_state.Text = "正常";
                    lb_state.ForeColor = System.Drawing.Color.Blue;
                }
                else if (hstate == "2")
                {
                    lb_state.Text = "禁用";
                    lb_state.ForeColor = System.Drawing.Color.Red;
                }
                //lb_email.Text = hemail;
                if (hemail == "1")
                {
                    lb_email.Text = "发送";
                    lb_email.ForeColor = System.Drawing.Color.Blue;
                }
                else
                {
                    lb_email.Text = "不发送";
                    lb_email.ForeColor = System.Drawing.Color.Red;
                }

                foreach (huashu hs in BLL.huashuManager.GetList())
                {
                    if (hs.hid.ToString() == hfid)
                    {
                        lbl_type.Text = hs.htitle;
                        lbl_type.ForeColor = System.Drawing.Color.Blue;
                        break;
                    }
                }
            }
            catch (Exception ex) {
                
                Common.ErrorLog.WriteEntry(ex); }

        }
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        TextBox txt_title = GridView1.Rows[e.RowIndex].FindControl("txt_title") as TextBox;
        TextBox txt_context = GridView1.Rows[e.RowIndex].FindControl("txt_context") as TextBox;
        TextBox txt_sort = GridView1.Rows[e.RowIndex].FindControl("txt_sort") as TextBox;
        int _sort=0;
        if (!int.TryParse(txt_sort.Text.Trim(), out _sort))
        {
            AJAXManager.Alert(this.UpdatePanel1, "请输入正确的排序");
            return;
        }

        int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values["hid"]);
        huashu sa = BLL.huashuManager.SearchByID(id);
        sa.htitle = txt_title.Text.Trim();
        sa.hcontext = txt_context.Text.Trim();
        sa.hsort = _sort;
        if (BLL.huashuManager.Update(sa) != 1)
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
                huashu sa = BLL.huashuManager.SearchByID(id);
                sa.hstate = sa.hstate == "1" ? "2" : "1";
                if (BLL.huashuManager.Update(sa) != 1)
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
        else if (state == "email")
        {
            int id = Convert.ToInt32(GridView1.DataKeys[((e.CommandSource as LinkButton).NamingContainer as GridViewRow).RowIndex].Values["hid"].ToString());
            if (id != 0)
            {
                huashu sa = BLL.huashuManager.SearchByID(id);
                sa.hsendemail = sa.hsendemail == "1" ? "2" : "1";
                if (BLL.huashuManager.Update(sa) != 1)
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
        int res_ok = 0;
        int res_no = 0;
        foreach (string temp in temp_id)
        {
            int id = 0;
            if (int.TryParse(temp, out id))
            {
                if (BLL.huashuManager.Delete(id) == 1)
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

    #region btn_out_Click
    protected void btn_out_Click(object sender, EventArgs e)
    {
        //int _temp = 0;
        //if (!int.TryParse(txt_num2.Text.Trim(), out _temp))
        //{
        //    Manager.Alert("请输入要到处的数据条数", Page);
        //    txt_num2.Focus();
        //    return;
        //}
        //List<string> list = BLL.shuadan_pingjiaManager.GetPingjia(_temp, 2, 9, new DateTime(), new DateTime());

        ////开始写入txt

        //////手机号导入完毕,开始存储为txt文件
        //Random ran = new Random();
        //string filename = DateTime.Now.ToString("yyyy年MM月dd日HHmmss") + ran.Next(999, 9999).ToString() + ".txt";
        //string filepath = Request.PhysicalApplicationPath + "OA\\upload\\shuadan\\pingjia\\";
        //if (!System.IO.Directory.Exists(filepath))
        //{
        //    System.IO.Directory.CreateDirectory(filepath);
        //}
        //FileStream fs_write = new FileStream(filepath + filename, FileMode.Create, FileAccess.ReadWrite);
        //StreamWriter strmWriter = new StreamWriter(fs_write, System.Text.Encoding.Default);
        //foreach (string s in list)
        //{
        //    string str_write = s;
        //    strmWriter.Write(str_write);
        //    strmWriter.WriteLine(); //换行
        //}

        //strmWriter.Flush();
        //strmWriter.Close();

        //Entity.shuadan_record sr = new shuadan_record();
        //sr.srcount = 1;
        //sr.srdate = DateTime.Now;
        //sr.srname = filename;
        //sr.srnum = _temp.ToString();
        //sr.srpath = "~/OA/upload/shuadan/pingjia/" + filename;
        //sr.srremark = "";
        //sr.srstate = "1";
        //sr.srtype = "4";

        //Manager.FileDownload("~/OA/upload/shuadan/pingjia/" + filename, filename, sr);
        //bind();
    }
    #endregion
}