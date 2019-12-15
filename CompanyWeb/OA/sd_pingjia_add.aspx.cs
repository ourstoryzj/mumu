using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entity;
using System.Text.RegularExpressions;


public partial class OA_sd_pingjia_add : WebPage
{
    string id;
    protected void Page_Load(object sender, EventArgs e)
    {
        id = Request["id"];
        if (!IsPostBack)
        {
            bind();
        }
    }


    #region bind
    void bind()
    {
        if (!string.IsNullOrEmpty(id))
        {
            int temp = 0;
            if (int.TryParse(id, out temp))
            {
                shuadan_pingjia sp = BLL.shuadan_pingjiaManager.SearchByspid(temp);
                if (sp != null)
                {
                    try
                    {
                        txt_name.Text = sp.spname;
                        txt_remark.Text = sp.spremark;
                        ddl_state.SelectedValue = sp.spstate;
                        ddl_type.SelectedValue = sp.sptype;
                        liter_date.Text = sp.spdate.ToString();
                    }
                    catch { }
                }
            }
        }
    }
    #endregion

    #region btn_save_Click
    protected void btn_save_Click(object sender, EventArgs e)
    {
        try
        {
            string name = txt_name.Text.Trim();
            string state = ddl_state.SelectedValue.ToString();
            string _type = ddl_type.SelectedValue.ToString();
            string remark = txt_remark.Text.Trim();

            shuadan_pingjia sp = new shuadan_pingjia();
            if (!string.IsNullOrEmpty(id))
            {
                sp = BLL.shuadan_pingjiaManager.SearchByspid(Convert.ToInt32(id));
            }
            else
            {
                sp.spdate = DateTime.Now;
            }
            sp.spname = name;
            sp.spremark = remark;
            sp.spstate = state;
            sp.sptype = _type;


            int res = 0;
            if (string.IsNullOrEmpty(id))
            {
                if (BLL.shuadan_pingjiaManager.SearchNum(sp.spname, "", "", new DateTime(), new DateTime()) < 1)
                    res = BLL.shuadan_pingjiaManager.Insert(sp);
            }
            else
            {
                res = BLL.shuadan_pingjiaManager.Update(sp);
            }
            if (res == 1)
            {
                Manager.Alert("保存成功", Page);
            }
            else
            {
                Manager.Alert("保存失败", Page);
            }
        }
        catch (Exception ex)
        {
            Manager.Alert(ex.ToString(), Page);
        }
        Manager.page_href_reload(Page);
    }
    #endregion

    #region btn_save2_Click
    protected void btn_save2_Click(object sender, EventArgs e)
    {
        try
        {
            string data = txt_data.Text.Trim();
            string[] ss = data.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            int count_ok = 0;
            int count_no = 0;
            foreach (string s in ss)
            {
                if (!string.IsNullOrEmpty(s))
                {
                    shuadan_pingjia sp = new shuadan_pingjia();
                    string state = ddl_state.SelectedValue.ToString();
                    string _type = ddl_type.SelectedValue.ToString();
                    string remark = txt_remark.Text.Trim();
                    sp.spstate = state;
                    sp.sptype = _type;
                    sp.spremark = remark;
                    sp.spdate = DateTime.Now;
                    sp.spname = s;
                    if (BLL.shuadan_pingjiaManager.SearchNum(sp.spname, "", "", new DateTime(), new DateTime()) < 1)
                    {
                        if (BLL.shuadan_pingjiaManager.Insert(sp) == 1)
                        {
                            count_ok++;
                        }
                        else
                        {
                            count_no++;
                        }
                    }
                    else
                    {
                        count_no++;
                    }
                }
            }
            Manager.Alert("批处理操作完成:\\n成功添加 " + count_ok.ToString() + " 条信息" + (count_no == 0 ? "" : "\\n添加失败" + count_no.ToString() + "条信息！请注意核实！"), Page);
        }
        catch (Exception ex)
        {
            Manager.Alert(ex.ToString(), Page);
        }
        Manager.page_href_reload(Page);
    }
    #endregion
}