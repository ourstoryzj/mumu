using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entity;
using System.Text.RegularExpressions;


public partial class OA_yh_zaoci_add : WebPage
{
    string id;
    protected void Page_Load(object sender, EventArgs e)
    {
        id = Request["id"];
        if (!IsPostBack)
        {
            BLL.yh_goodstypeManager.ddl_bind(ddl_goodstype, true);
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
                yh_zaoci zc = yh_zaociManager.SearchByID(temp);
                if (zc != null)
                {
                    try
                    {
                        txt_name.Text = zc.zname;
                        txt_remark.Text = zc.gtname;
                        lbl_date.Text = zc.zdate.ToString();
                        ddl_goodstype.SelectedValue = zc.gtid.ToString();
                        ddl_state.SelectedValue = zc.zstate;
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
            string remark = txt_remark.Text.Trim();
            string state = ddl_state.SelectedValue.ToString();
            string gt = ddl_goodstype.SelectedValue;

            yh_zaoci zc = new yh_zaoci();
            if (!string.IsNullOrEmpty(id))
            {
                zc = BLL.yh_zaociManager.SearchByID(Convert.ToInt32(id));
            }
            else
            {
                zc.zdate = DateTime.Now;
            }
            zc.gtid =Convert.ToInt32( gt);
            zc.gtname = remark;
            zc.zname = name;
            zc.zstate = state;

            int res;
            if (string.IsNullOrEmpty(id))
            {
                res = BLL.yh_zaociManager.Insert(zc);
            }
            else
            {
                res = BLL.yh_zaociManager.Update(zc);
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
            Manager.Alert(ex.ToString());
        }
        Manager.page_href_reload(Page);
    }
    #endregion



    #region btn_quickadd_Click
    protected void btn_quickadd_Click(object sender, EventArgs e)
    {
        string str = txt_quickadd.Text.Trim();
        string remark = txt_remark.Text.Trim();
        string state = ddl_state.SelectedValue.ToString();
        string gt = ddl_goodstype.SelectedValue;
        yh_zaoci zc = new yh_zaoci();
        zc.gtid = Convert.ToInt32(gt);
        zc.gtname = remark;
        zc.zstate = state;
         
        

        int res1 = 0;
        int res2 = 0;

        if (string.IsNullOrEmpty(str))
            return;
        try
        {
            string[] ss = str.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in ss)
            {
                string temp = s.Trim();
                if (!string.IsNullOrEmpty(temp))
                {
                    zc.zname = temp;
                    zc.zdate = DateTime.Now;
                    if (BLL.yh_zaociManager.Insert(zc) == 1)
                    {
                        res1++;
                    }
                    else
                    {
                        res2++;
                    }
                }
            }
            Manager.Alert("批处理操作完成:\\n成功添加 " + res1.ToString() + " 条信息" + (res2 == 0 ? "" : "\\n添加失败" + res2.ToString() + "条信息！请注意核实！"),Page);
        }
        catch (Exception ex)
        {
            Manager.Alert(ex.ToString(), Page);
        }
    }
    #endregion
}