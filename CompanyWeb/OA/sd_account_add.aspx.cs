using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entity;
using System.Text.RegularExpressions;


public partial class OA_sd_account_add : WebPage
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
                shuadan_account sa = BLL.shuadan_accountManager.SearchBysdaid(temp);
                if (sa != null)
                {
                    try
                    {
                        txt_name.Text = sa.sdaccount;
                        txt_pwd.Text = sa.sdapwd;
                        ddl_state.SelectedValue = sa.sdastate;
                        ddl_state_phone.SelectedValue = sa.sdastate_phone;
                        liter_date.Text = sa.sdadate.ToString();
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
            string state_phone = ddl_state_phone.SelectedValue.ToString();
            string pwd = txt_pwd.Text.Trim();

            shuadan_account sa = new shuadan_account();
            if (!string.IsNullOrEmpty(id))
            {
                sa = BLL.shuadan_accountManager.SearchBysdaid(Convert.ToInt32(id));
            }
            else
            {
                sa.sdadate = DateTime.Now;
            }

            sa.sdaccount = name;
            sa.sdapwd = pwd;
            sa.sdastate = state;
            sa.sdastate_phone = state_phone;


            int res = 0;
            if (string.IsNullOrEmpty(id))
            {
                if ((BLL.shuadan_accountManager.SearchNum(sa.sdaccount, "", "", new DateTime(), new DateTime())) < 1)
                {
                    res = BLL.shuadan_accountManager.Insert(sa);
                }
            }
            else
            {
                res = BLL.shuadan_accountManager.Update(sa);
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
                //if (s.IndexOf("成功") != -1)
                //{
                    string[] arry = s.Replace("----", "-").Split(new char[] { '-' });
                    int i = 1;
                    shuadan_account sa = new shuadan_account();
                    sa.sdadate = DateTime.Now;
                    sa.sdastate_phone = "0";
                    sa.sdastate = "0";

                    foreach (string temp in arry)
                    {
                        if (i == 1)
                        {
                            sa.sdaccount = temp;
                        }
                        else if (i == 2)
                        {
                            sa.sdapwd = temp;
                        }
                        i++;
                    }
                    if ((BLL.shuadan_accountManager.SearchNum(sa.sdaccount, "", "", new DateTime(), new DateTime())) < 1)
                    {
                        if (BLL.shuadan_accountManager.Insert(sa) == 1)
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
                //}
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