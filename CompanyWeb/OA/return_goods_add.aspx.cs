using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entity;
using System.Text.RegularExpressions;


public partial class OA_return_goods_add : WebPage
{
    string id;
    protected void Page_Load(object sender, EventArgs e)
    {
        id = Request["id"];
       
        if (!IsPostBack)
        {
            bind();
            courierManager.ddl_bind(ddl_courier, false);
            Manager.TextBox_Select(txt_name);
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
                return_goods rg = BLL.return_goodsManager.SearchByID(temp);
                if (rg != null)
                {
                    try
                    {
                        ddl_courier.SelectedValue = rg.cid.ToString();
                        txt_name.Text = rg.rgcode;
                        txt_remark.Text = rg.rgremark;
                        liter_date.Text = rg.rgdate.ToString();
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
            string courier = ddl_courier.SelectedValue.ToString();
            string remark = txt_remark.Text.Trim();

            return_goods sp = new return_goods();
            if (!string.IsNullOrEmpty(id))
            {
                sp = BLL.return_goodsManager.SearchByID(Convert.ToInt32(id));
            }
            else
            {
                sp.rgdate = DateTime.Now;
            }
            sp.rgcode = name;
            sp.rgremark = remark;
            sp.cid = Convert.ToInt32(courier);
            sp.cname = ddl_courier.SelectedItem.Text;


            int res = 0;
            if (string.IsNullOrEmpty(id))
            {
                res = BLL.return_goodsManager.Insert(sp);
            }
            else
            {
                res = BLL.return_goodsManager.Update(sp);
            }
            if (res == 1)
            {
                //AJAXManager.Alert(UpdatePanel1, "保存成功");
                lbl_message.Text = "快递单号: "+name+" <br/>信息状态: 保存成功! ";
            }
            else
            {
                //AJAXManager.Alert(UpdatePanel1, "保存失败");
                lbl_message.Text = "保存失败,请联系张建";
            }
            Manager.TextBox_Select(txt_name);
        }
        catch (Exception ex)
        {
            Manager.Alert(ex.ToString(), Page);
        }
        Manager.page_href_reload(Page);
    }
    #endregion


}