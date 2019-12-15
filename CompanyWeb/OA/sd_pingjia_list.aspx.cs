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
    string _type;
    string state;
    string key;
    string num;

    protected void Page_Load(object sender, EventArgs e)
    {
        date1 = string.IsNullOrEmpty(txt_date1.Text.Trim()) ? Request["date1"] : txt_date1.Text.Trim();
        date2 = string.IsNullOrEmpty(txt_date2.Text.Trim()) ? Request["date2"] : txt_date2.Text.Trim();
        _type = string.IsNullOrEmpty(ddl_type.SelectedValue) ? Request["type"] : ddl_type.SelectedValue;
        state = string.IsNullOrEmpty(ddl_state.SelectedValue) ? Request["state"] : ddl_state.SelectedValue;
        key = string.IsNullOrEmpty(txt_key.Text.Trim()) ? Request["key"] : txt_key.Text.Trim();
        num = string.IsNullOrEmpty(txt_num.Text.Trim()) ? Request["num"] : txt_num.Text.Trim();
        txt_date1.Text = date1;
        txt_date2.Text = date2;
        txt_key.Text = key;
        ddl_type.SelectedValue = _type;
        ddl_state.SelectedValue = state;
        txt_num.Text = num;

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
        num = txt_num.Text.Trim();
        //判断是否是数字
        if (!string.IsNullOrEmpty(num))
        {
            int temp_num = 0;
            if (!int.TryParse(num, out temp_num))
            {
                AJAXManager.Alert(this.UpdatePanel1, "请输入正确的数量");
                return;
            }
        }

        DateTime temp_date1 = new DateTime();
        DateTime temp_date2 = new DateTime();
        DateTime.TryParse(date1, out temp_date1);
        DateTime.TryParse(date2, out temp_date2);

        AspNetPager1.RecordCount = BLL.shuadan_pingjiaManager.SearchNum(key, state, _type, temp_date1, temp_date2);
        lbl_count.Text = "(共" + AspNetPager1.RecordCount.ToString() + "条数据)";
        GridView1.DataSource = AspNetPager1.RecordCount == 0 ? null : BLL.shuadan_pingjiaManager.Search(AspNetPager1.StartRecordIndex, AspNetPager1.EndRecordIndex, key, state, _type, temp_date1, temp_date2, num);
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
                string spstate = GridView1.DataKeys[e.Row.RowIndex].Values["spstate"].ToString();
                string sptype = GridView1.DataKeys[e.Row.RowIndex].Values["sptype"].ToString();
                LinkButton lb_state = e.Row.FindControl("lb_state") as LinkButton;
                LinkButton lb_type = e.Row.FindControl("lb_type") as LinkButton;



                if (spstate == "1")
                {
                    lb_state.Text = "正常";
                    lb_state.ForeColor = System.Drawing.Color.Blue;
                }
                else if (spstate == "2")
                {
                    lb_state.Text = "禁用";
                    lb_state.ForeColor = System.Drawing.Color.Red;
                }
                if (sptype == "1")
                {
                    lb_type.Text = "普通评语";
                    lb_type.ForeColor = System.Drawing.Color.Blue;
                }
                else if (sptype == "2")
                {
                    lb_type.Text = "质量评语";
                    lb_type.ForeColor = System.Drawing.Color.Green;
                }
                else if (sptype == "3")
                {
                    lb_type.Text = "结束评语";
                    lb_type.ForeColor = System.Drawing.Color.Red;
                }
                //else if (sptype == "4")
                //{
                //    lb_type.Text = "价格评语";
                //    lb_type.ForeColor = System.Drawing.Color.Gainsboro;
                //}
                //else if (sptype == "5")
                //{
                //    lb_type.Text = "普通评语";
                //    lb_type.ForeColor = System.Drawing.Color.Green;
                //}
                //else if (sptype == "6")
                //{
                //    lb_type.Text = "结束评语";
                //    lb_type.ForeColor = System.Drawing.Color.Red;
                //}



            }
            catch (Exception ex) { Common.ErrorLog.WriteEntry(ex); }

        }
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        TextBox txt_name = GridView1.Rows[e.RowIndex].FindControl("txt_name") as TextBox;
        TextBox txt_remark = GridView1.Rows[e.RowIndex].FindControl("txt_remark") as TextBox;

        int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values["spid"]);
        shuadan_pingjia sa = BLL.shuadan_pingjiaManager.SearchByspid(id);
        sa.spname = txt_name.Text.Trim();
        sa.spremark = txt_remark.Text.Trim();
        if (BLL.shuadan_pingjiaManager.Update(sa) != 1)
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
            int id = Convert.ToInt32(GridView1.DataKeys[((e.CommandSource as LinkButton).NamingContainer as GridViewRow).RowIndex].Values["spid"].ToString());
            if (id != 0)
            {
                shuadan_pingjia sa = BLL.shuadan_pingjiaManager.SearchByspid(id);
                sa.spstate = sa.spstate == "1" ? "2" : "1";
                if (BLL.shuadan_pingjiaManager.Update(sa) != 1)
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
        else if (state == "type")
        {
            int id = Convert.ToInt32(GridView1.DataKeys[((e.CommandSource as LinkButton).NamingContainer as GridViewRow).RowIndex].Values["spid"].ToString());
            if (id != 0)
            {
                shuadan_pingjia sa = BLL.shuadan_pingjiaManager.SearchByspid(id);
                sa.sptype = sa.sptype == "1" ? "2" : (sa.sptype == "2" ? "3" : "1");
                if (BLL.shuadan_pingjiaManager.Update(sa) != 1)
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
        int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values["spid"]);
        if (BLL.shuadan_pingjiaManager.Delete(id) != 1)
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
                if (BLL.shuadan_pingjiaManager.Delete(id) == 1)
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
        int _temp = 0;
        if (!int.TryParse(txt_num2.Text.Trim(), out _temp))
        {
            Manager.Alert("请输入要到处的数据条数", Page);
            txt_num2.Focus();
            return;
        }
        List<string> list = BLL.shuadan_pingjiaManager.GetPingjia(_temp, 2, 9, new DateTime(), new DateTime());

        //开始写入txt

        ////手机号导入完毕,开始存储为txt文件
        Random ran = new Random();
        string filename = DateTime.Now.ToString("yyyy年MM月dd日HHmmss") + ran.Next(999, 9999).ToString() + ".txt";
        string filepath = Request.PhysicalApplicationPath + "OA\\upload\\shuadan\\pingjia\\";
        if (!System.IO.Directory.Exists(filepath))
        {
            System.IO.Directory.CreateDirectory(filepath);
        }
        FileStream fs_write = new FileStream(filepath + filename, FileMode.Create, FileAccess.ReadWrite);
        StreamWriter strmWriter = new StreamWriter(fs_write, System.Text.Encoding.Default);
        foreach (string s in list)
        {
            string str_write = s;
            strmWriter.Write(str_write);
            strmWriter.WriteLine(); //换行
        }

        strmWriter.Flush();
        strmWriter.Close();

        Entity.shuadan_record sr = new shuadan_record();
        sr.srcount = 1;
        sr.srdate = DateTime.Now;
        sr.srname = filename;
        sr.srnum = _temp.ToString();
        sr.srpath = "~/OA/upload/shuadan/pingjia/" + filename;
        sr.srremark = "";
        sr.srstate = "1";
        sr.srtype = "4";

        Manager.FileDownload("~/OA/upload/shuadan/pingjia/" + filename, filename, sr);
        bind();
    }
    #endregion
}