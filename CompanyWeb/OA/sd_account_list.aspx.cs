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
    string state_phone;
    string state;
    string key;
    string num;

    protected void Page_Load(object sender, EventArgs e)
    {
        date1 = string.IsNullOrEmpty(txt_date1.Text.Trim()) ? Request["date1"] : txt_date1.Text.Trim();
        date2 = string.IsNullOrEmpty(txt_date2.Text.Trim()) ? Request["date2"] : txt_date2.Text.Trim();
        state_phone = string.IsNullOrEmpty(ddl_state_phone.SelectedValue) ? Request["state_phone"] : ddl_state_phone.SelectedValue;
        state = string.IsNullOrEmpty(ddl_state.SelectedValue) ? Request["state"] : ddl_state.SelectedValue;
        key = string.IsNullOrEmpty(txt_key.Text.Trim()) ? Request["key"] : txt_key.Text.Trim();
        num = string.IsNullOrEmpty(txt_num.Text.Trim()) ? Request["num"] : txt_num.Text.Trim();
        txt_date1.Text = date1;
        txt_date2.Text = date2;
        txt_key.Text = key;
        ddl_state_phone.SelectedValue = state_phone;
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
        state_phone = ddl_state_phone.SelectedValue;
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

        AspNetPager1.RecordCount = BLL.shuadan_accountManager.SearchNum(key, state, state_phone, temp_date1, temp_date2);
        lbl_count.Text = "(共" + AspNetPager1.RecordCount.ToString() + "条数据)";
        GridView1.DataSource = AspNetPager1.RecordCount == 0 ? null : BLL.shuadan_accountManager.Search(AspNetPager1.StartRecordIndex, AspNetPager1.EndRecordIndex, key, state, state_phone, temp_date1, temp_date2, num);
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
                string sdastate = GridView1.DataKeys[e.Row.RowIndex].Values["sdastate"].ToString();
                //string sdastate_phone = GridView1.DataKeys[e.Row.RowIndex].Values["sdastate_phone"].ToString();
                LinkButton lb_state = e.Row.FindControl("lb_state") as LinkButton;
                //LinkButton lb_state_phone = e.Row.FindControl("lb_state_phone") as LinkButton;



                if (sdastate == "0")
                {
                    lb_state.Text = "未使用";
                    lb_state.ForeColor = System.Drawing.Color.Blue;
                }
                else if (sdastate == "1")
                {
                    lb_state.Text = "已使用";
                    lb_state.ForeColor = System.Drawing.Color.Red;
                }
                //if (sdastate_phone == "0")
                //{
                //    lb_state_phone.Text = "未使用";
                //    lb_state_phone.ForeColor = System.Drawing.Color.Blue;
                //}
                //else if (sdastate_phone == "1")
                //{
                //    lb_state_phone.Text = "已使用";
                //    lb_state_phone.ForeColor = System.Drawing.Color.Red;
                //}



            }
            catch (Exception ex) { Common.ErrorLog.WriteEntry(ex); }

        }
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        TextBox txt_account = GridView1.Rows[e.RowIndex].FindControl("txt_account") as TextBox;
        TextBox txt_pwd = GridView1.Rows[e.RowIndex].FindControl("txt_pwd") as TextBox;

        int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values["sdaid"]);
        shuadan_account sa = BLL.shuadan_accountManager.SearchBysdaid(id);
        sa.sdaccount = txt_account.Text.Trim();
        sa.sdapwd = txt_pwd.Text.Trim();
        if (BLL.shuadan_accountManager.Update(sa) != 1)
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
            int id = Convert.ToInt32(GridView1.DataKeys[((e.CommandSource as LinkButton).NamingContainer as GridViewRow).RowIndex].Values["sdaid"].ToString());
            if (id != 0)
            {
                shuadan_account sa = BLL.shuadan_accountManager.SearchBysdaid(id);
                sa.sdastate = sa.sdastate == "1" ? "0" : "1";
                if (BLL.shuadan_accountManager.Update(sa) != 1)
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
        else if (state == "state_phone")
        {
            int id = Convert.ToInt32(GridView1.DataKeys[((e.CommandSource as LinkButton).NamingContainer as GridViewRow).RowIndex].Values["sdaid"].ToString());
            if (id != 0)
            {
                shuadan_account sa = BLL.shuadan_accountManager.SearchBysdaid(id);
                sa.sdastate_phone = sa.sdastate_phone == "1" ? "0" : "1";
                if (BLL.shuadan_accountManager.Update(sa) != 1)
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
        int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values["sdaid"]);
        if (BLL.shuadan_accountManager.Delete(id) != 1)
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
        string temp_ckname = Request.Form.Get("checkboxname");
        string[] temp_id = temp_ckname.Split(new char[] { ',' });
        int res_ok = 0;
        int res_no = 0;
        foreach (string temp in temp_id)
        {
            int id = 0;
            if (int.TryParse(temp, out id))
            {
                if (BLL.shuadan_accountManager.Delete(id) == 1)
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
        string _temp = txt_num.Text.Trim();
        IList<shuadan_account> list = new List<shuadan_account>();
        //根据数量导出
        if (!string.IsNullOrEmpty(_temp))
        {
            int _num = 0;
            if (!int.TryParse(_temp, out _num))
            {
                AJAXManager.Alert(UpdatePanel1, "请输入正确的数量");
                return;
            }
            else
            {
                //开始导出
                date1 = txt_date1.Text.Trim();
                date2 = txt_date2.Text.Trim();
                state_phone = ddl_state_phone.SelectedValue;
                state = ddl_state.SelectedValue;
                key = txt_key.Text.Trim();
                num = txt_num.Text.Trim();

                DateTime temp_date1 = new DateTime();
                DateTime temp_date2 = new DateTime();
                DateTime.TryParse(date1, out temp_date1);
                DateTime.TryParse(date2, out temp_date2);

                list = BLL.shuadan_accountManager.Search(1, _num, key, state, state_phone, temp_date1, temp_date2, num);
            }
        }
        else
        {
            //根据多选导出
            string temp_ckname = Request.Form.Get("checkboxname");
            if (string.IsNullOrEmpty(temp_ckname))
            {
                AJAXManager.Alert(UpdatePanel1, "请输入正确的数量");
                return;
            }
            string[] temp_id = temp_ckname.Split(new char[] { ',' });
            if (temp_id.Length == 0)
            {
                AJAXManager.Alert(UpdatePanel1, "请输入正确的数量");
                return;
            }
            foreach (string temp in temp_id)
            {
                int id = 0;
                if (int.TryParse(temp, out id))
                {
                    list.Add(BLL.shuadan_accountManager.SearchBysdaid(id));
                }
            }
        }

        if (list.Count < 1)
        {
            AJAXManager.Alert(UpdatePanel1, "请输入正确的数量");
            return;
        }


        //开始写入txt

        ////手机号导入完毕,开始存储为txt文件
        Random ran = new Random();
        string filename = DateTime.Now.ToString("yyyy年MM月dd日HHmmss") + ran.Next(999, 9999).ToString() + ".txt";
        string filepath = Request.PhysicalApplicationPath + "OA\\upload\\shuadan\\account\\";
        if (!System.IO.Directory.Exists(filepath))
        {
            System.IO.Directory.CreateDirectory(filepath);
        }
        FileStream fs_write = new FileStream(filepath + filename, FileMode.Create, FileAccess.ReadWrite);
        StreamWriter strmWriter = new StreamWriter(fs_write, System.Text.Encoding.Default);
        //strmWriter.Write(dt.Columns[i].ColumnName + " ");
        //    strmWriter.WriteLine(); //换行
        foreach (shuadan_account sda in list)
        {
            sda.sdastate = "1";
            BLL.shuadan_accountManager.Update(sda);
            string info = sda.sdaccount + "----" + sda.sdapwd + "----恭喜您，上传成功";
            string str_write = info;
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
        sr.srpath = "~/OA/upload/shuadan/account/" + filename;
        sr.srremark = "";
        sr.srstate = "1";
        sr.srtype = "1";


        Manager.FileDownload("~/OA/upload/shuadan/account/" + filename, filename, sr);
        bind();
    }
    #endregion


}