using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entity;
using System.Text.RegularExpressions;


public partial class OA_basic_huodong_add : WebPage
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
                basic_huodong dp = basic_huodongManager.SearchByID(temp);
                if (dp != null)
                {
                    try
                    {

                        ddl_type.SelectedValue = dp.hdtype;
                        txt_1.Text = dp.hdone.ToString();
                        txt_2.Text = dp.hdtwo.ToString();
                        txt_date1.Text = dp.hddate1.ToString("HH:mm");
                        txt_date2.Text = dp.hddate2.ToString("HH:mm");
                        txt_remark.Text = dp.hdremark;
                        txt_name.Text = dp.hdname;
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
            string _type = ddl_type.SelectedValue;
            int one = 0;
            if (!int.TryParse(txt_1.Text.Trim(), out one))
            {
                Manager.Alert("请输入正确的天数", Page);
                Manager.TextBox_Select(txt_1);
                return;
            }
            int two = 0;
            if (!int.TryParse(txt_2.Text.Trim(), out two))
            {
                Manager.Alert("请输入正确的天数", Page);
                Manager.TextBox_Select(txt_2);
                return;
            }
            DateTime date1 = new DateTime();
            if (!DateTime.TryParse(DateTime.Now.ToString("yyyy-MM-dd ") + txt_date1.Text.Trim(), out date1))
            {
                Manager.Alert("请输入正确的时间", Page);
                Manager.TextBox_Select(txt_date1);
                return;
            }
            DateTime date2 = new DateTime();
            if (!DateTime.TryParse(DateTime.Now.ToString("yyyy-MM-dd ") + txt_date2.Text.Trim(), out date2))
            {
                Manager.Alert("请输入正确的时间", Page);
                Manager.TextBox_Select(txt_date2);
                return;
            }

            string name = txt_name.Text.Trim();
            string remark = txt_remark.Text.Trim();
            basic_huodong dp = new basic_huodong();


            if (!string.IsNullOrEmpty(id))
            {
                dp = BLL.basic_huodongManager.SearchByID(Convert.ToInt32(id));
            }

            dp.hddate1 = date1;
            dp.hddate2 = date2;
            dp.hdone = one;
            dp.hdtwo = two;
            dp.hdremark = remark;
            dp.hdname = name;


            int res;
            if (string.IsNullOrEmpty(id))
            {
                res = BLL.basic_huodongManager.Insert(dp);
            }
            else
            {
                res = BLL.basic_huodongManager.Update(dp);
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




}