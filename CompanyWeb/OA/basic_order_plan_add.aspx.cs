using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entity;
using System.Text.RegularExpressions;


public partial class OA_basic_order_plan_add : WebPage
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
                basic_order_plan dp = basic_order_planManager.SearchByID(temp);
                if (dp != null)
                {
                    try
                    {

                        ddl_optype.SelectedValue = dp.optype;
                        txt_1.Text = dp.opday1.ToString();
                        txt_2.Text = dp.opday2.ToString();
                        txt_3.Text = dp.opday3.ToString();
                        txt_4.Text = dp.opday4.ToString();
                        txt_5.Text = dp.opday5.ToString();
                        txt_6.Text = dp.opday6.ToString();
                        txt_7.Text = dp.opday7.ToString();
                        txt_8.Text = dp.opday8.ToString();
                        txt_9.Text = dp.opday9.ToString();
                        txt_10.Text = dp.opday10.ToString();
                        txt_11.Text = dp.opday11.ToString();
                        txt_12.Text = dp.opday12.ToString();
                        txt_13.Text = dp.opday13.ToString();
                        txt_14.Text = dp.opday14.ToString();
                        txt_name.Text = dp.opname;
                        txt_remark.Text = dp.opremark;
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
            string _type = ddl_optype.SelectedValue;
            int op1 = 0;
            if (!int.TryParse(txt_1.Text.Trim(), out op1))
            {
                Manager.Alert("请输入正确的数量", Page);
                Manager.TextBox_Select(txt_1);
                return;
            }
            int op2 = 0;
            if (!int.TryParse(txt_2.Text.Trim(), out op2))
            {
                Manager.Alert("请输入正确的数量", Page);
                Manager.TextBox_Select(txt_1);
                return;
            }
            int op3 = 0;
            if (!int.TryParse(txt_3.Text.Trim(), out op3))
            {
                Manager.Alert("请输入正确的数量", Page);
                Manager.TextBox_Select(txt_3);
                return;
            }
            int op4 = 0;
            if (!int.TryParse(txt_4.Text.Trim(), out op4))
            {
                Manager.Alert("请输入正确的数量", Page);
                Manager.TextBox_Select(txt_4);
                return;
            }
            int op5 = 0;
            if (!int.TryParse(txt_5.Text.Trim(), out op5))
            {
                Manager.Alert("请输入正确的数量", Page);
                Manager.TextBox_Select(txt_5);
                return;
            }
            int op6 = 0;
            if (!int.TryParse(txt_6.Text.Trim(), out op6))
            {
                Manager.Alert("请输入正确的数量", Page);
                Manager.TextBox_Select(txt_6);
                return;
            }
            int op7 = 0;
            if (!int.TryParse(txt_7.Text.Trim(), out op7))
            {
                Manager.Alert("请输入正确的数量", Page);
                Manager.TextBox_Select(txt_7);
                return;
            }
            int op8 = 0;
            if (!int.TryParse(txt_8.Text.Trim(), out op8))
            {
                Manager.Alert("请输入正确的数量", Page);
                Manager.TextBox_Select(txt_8);
                return;
            }
            int op9 = 0;
            if (!int.TryParse(txt_9.Text.Trim(), out op9))
            {
                Manager.Alert("请输入正确的数量", Page);
                Manager.TextBox_Select(txt_9);
                return;
            }
            int op10 = 0;
            if (!int.TryParse(txt_10.Text.Trim(), out op10))
            {
                Manager.Alert("请输入正确的数量", Page);
                Manager.TextBox_Select(txt_10);
                return;
            }
            int op11 = 0;
            if (!int.TryParse(txt_11.Text.Trim(), out op11))
            {
                Manager.Alert("请输入正确的数量", Page);
                Manager.TextBox_Select(txt_11);
                return;
            }
            int op12 = 0;
            if (!int.TryParse(txt_12.Text.Trim(), out op12))
            {
                Manager.Alert("请输入正确的数量", Page);
                Manager.TextBox_Select(txt_12);
                return;
            }
            int op13 = 0;
            if (!int.TryParse(txt_13.Text.Trim(), out op13))
            {
                Manager.Alert("请输入正确的数量", Page);
                Manager.TextBox_Select(txt_13);
                return;
            }
            int op14 = 0;
            if (!int.TryParse(txt_14.Text.Trim(), out op14))
            {
                Manager.Alert("请输入正确的数量", Page);
                Manager.TextBox_Select(txt_14);
                return;
            }



            string name = txt_name.Text.Trim();
            string remark = txt_remark.Text.Trim();

            basic_order_plan dp = new basic_order_plan();


            if (!string.IsNullOrEmpty(id))
            {
                dp = BLL.basic_order_planManager.SearchByID(Convert.ToInt32(id));
            }


            dp.optype = _type;
            dp.opremark = remark;
            dp.opday1 = op1;
            dp.opday2 = op2;
            dp.opday3 = op3;
            dp.opday4 = op4;
            dp.opday5 = op5;
            dp.opday6 = op6;
            dp.opday7 = op7;
            dp.opday8 = op8;
            dp.opday9 = op9;
            dp.opday10 = op10;
            dp.opday11 = op11;
            dp.opday12 = op12;
            dp.opday13 = op13;
            dp.opday14 = op14;
            dp.opname = name;



            int res;
            if (string.IsNullOrEmpty(id))
            {
                res = BLL.basic_order_planManager.Insert(dp);
            }
            else
            {
                res = BLL.basic_order_planManager.Update(dp);
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