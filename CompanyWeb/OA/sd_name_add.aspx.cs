using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entity;
using System.Text.RegularExpressions;


public partial class OA_sd_name_add : WebPage
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
                shuadan_names sn = BLL.shuadan_namesManager.SearchBynid(temp);
                if (sn != null)
                {
                    try
                    {
                        txt_name.Text = sn.nname;
                        liter_count.Text = sn.ncount.ToString();
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

            shuadan_names sn = new shuadan_names();
            if (!string.IsNullOrEmpty(id))
            {
                sn = BLL.shuadan_namesManager.SearchBynid(Convert.ToInt32(id));
            }
            else
            {
                sn.ncount = "0";
            }

            sn.nname = name;

            int res = 0;
            if (string.IsNullOrEmpty(id))
            {
                if (BLL.shuadan_namesManager.Search(1, 100, sn.nname).Count == 0)
                {
                    res = BLL.shuadan_namesManager.Insert(sn);
                }
            }
            else
            {
                res = BLL.shuadan_namesManager.Update(sn);
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
                string[] arry = Regex.Split(s, "\\s+", RegexOptions.IgnoreCase);
                string name2 = "";
                foreach (string temp in arry)
                {
                    shuadan_names sn = new shuadan_names();
                    sn.ncount = "0";
                    if (temp.Length == 1)
                    {
                        name2 = name2 + temp;
                        if (name2.Length == 2)
                        {
                            sn.nname = name2;
                            if (BLL.shuadan_namesManager.Search(1, 100, sn.nname).Count == 0)
                            {
                                if (BLL.shuadan_namesManager.Insert(sn) == 1)
                                {
                                    count_ok++;
                                }
                                else
                                {
                                    count_no++;
                                }
                            }
                        }
                    }
                    if (temp.Length == 3)
                    {
                        sn.nname = temp;
                        if (BLL.shuadan_namesManager.Search(1, 100, sn.nname).Count == 0)
                        {
                            if (BLL.shuadan_namesManager.Insert(sn) == 1)
                            {
                                count_ok++;
                            }
                            else
                            {
                                count_no++;
                            }
                        }
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