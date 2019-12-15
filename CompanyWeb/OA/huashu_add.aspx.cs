using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entity;
using System.Text.RegularExpressions;


public partial class OA_huashu_add : WebPage
{
    string id;
    protected void Page_Load(object sender, EventArgs e)
    {
        id = Request["id"];
        if (!IsPostBack)
        {
            bind();
            BLL.huashuManager.ddl_bind(ddl_type, true);
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
                huashu sp = BLL.huashuManager.SearchByID(temp);
                if (sp != null)
                {
                    try
                    {
                        txt_context.Text = sp.hcontext;
                        txt_count.Text = sp.hcount.ToString();
                        txt_sort.Text = sp.hsort.ToString();
                        txt_title.Text = sp.htitle;
                        ddl_state.SelectedValue = sp.hstate;
                        ddl_type.SelectedValue = sp.hfid.ToString();
                        liter_date.Text = sp.hdate.ToString();
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
            string _context = txt_context.Text.Trim();
            string state = ddl_state.SelectedValue.ToString();
            string _type = ddl_type.SelectedValue.ToString();
            string title = txt_title.Text.Trim();
            string count = txt_count.Text.Trim();
            string sort = txt_sort.Text.Trim();
            int _count = 0;
            int _sort = 0;
            if (string.IsNullOrEmpty(_type))
            {
                Manager.Alert("请选择话术分类", Page);
                return;
            }
            if (!int.TryParse(count, out _count))
            {
                Manager.Alert("请输入正确的点击次数", Page);
                Manager.TextBox_Select(txt_count);
                return;
            }
            if (!int.TryParse(sort, out _sort))
            {
                Manager.Alert("请输入正确的排序", Page);
                Manager.TextBox_Select(txt_count);
                return;
            }


            huashu sp = new huashu();
            if (!string.IsNullOrEmpty(id))
            {
                sp = BLL.huashuManager.SearchByID(Convert.ToInt32(id));
            }
            else
            {
                sp.hdate = DateTime.Now;
            }
            sp.hcontext = _context;
            sp.htitle = title;
            sp.hstate = state;
            sp.hfid = Convert.ToInt32(_type);
            sp.hcount = _count;
            sp.hsort = _sort;

            int res = 0;
            if (string.IsNullOrEmpty(id))
            {
                res = BLL.huashuManager.Insert(sp);
            }
            else
            {
                res = BLL.huashuManager.Update(sp);
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
        //try
        //{
        //    string data = txt_data.Text.Trim();
        //    string[] ss = data.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
        //    int count_ok = 0;
        //    int count_no = 0;
        //    foreach (string s in ss)
        //    {
        //        if (!string.IsNullOrEmpty(s))
        //        {
        //            shuadan_pingjia sp = new shuadan_pingjia();
        //            string state = ddl_state.SelectedValue.ToString();
        //            string _type = ddl_type.SelectedValue.ToString();
        //            string remark = txt_remark.Text.Trim();
        //            sp.spstate = state;
        //            sp.sptype = _type;
        //            sp.spremark = remark;
        //            sp.spdate = DateTime.Now;
        //            sp.spname = s;
        //            if (BLL.shuadan_pingjiaManager.SearchNum(sp.spname, "", "", new DateTime(), new DateTime()) < 1)
        //            {
        //                if (BLL.shuadan_pingjiaManager.Insert(sp) == 1)
        //                {
        //                    count_ok++;
        //                }
        //                else
        //                {
        //                    count_no++;
        //                }
        //            }
        //            else
        //            {
        //                count_no++;
        //            }
        //        }
        //    }
        //    Manager.Alert("批处理操作完成:\\n成功添加 " + count_ok.ToString() + " 条信息" + (count_no == 0 ? "" : "\\n添加失败" + count_no.ToString() + "条信息！请注意核实！"), Page);
        //}
        //catch (Exception ex)
        //{
        //    Manager.Alert(ex.ToString(), Page);
        //}
        //Manager.page_href_reload(Page);
    }
    #endregion
}