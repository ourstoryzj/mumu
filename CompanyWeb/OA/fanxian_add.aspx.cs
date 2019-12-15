using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entity;


public partial class OA_fanxian_add : WebPage
{
    string id;
    protected void Page_Load(object sender, EventArgs e)
    {
        id = Request["id"];
        if (!IsPostBack)
        {
            BLL.dianpuManager.ddl_bind(ddl_dianpu, false);
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
                fanxian fx = fanxianManager.SearchByfx_id(temp);
                if (fx != null)
                {
                    try
                    {
                        txt_account.Text = fx.fx_account;
                        txt_remark.Text = fx.fx_remark;
                        txt_num.Text = fx.fx_num.ToString();
                        txt_zhifubao.Text = fx.fx_zhifubao;
                        lbl_date1.Text = fx.fx_date.ToString();
                        lbl_date2.Text = fx.fx_date2.ToString();
                        ddl_dianpu.SelectedValue = fx.dpid.ToString();
                        ddl_state.SelectedValue = fx.fx_state;
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

            DateTime dt = DateTime.Now;
            string account = txt_account.Text.Trim();
            string zhifubao = txt_zhifubao.Text.Trim();
            string num = txt_num.Text.Trim();


            string remark = txt_remark.Text.Trim();
            string state = ddl_state.SelectedValue.ToString();
            string dianpu = ddl_dianpu.SelectedValue != null ? ddl_dianpu.SelectedValue.ToString() : "";

            fanxian fx = new fanxian();

            if (!string.IsNullOrEmpty(id))
            {
                fx = BLL.fanxianManager.SearchByfx_id(Convert.ToInt32(id));
                if (state == "2")
                    fx.fx_date2 = DateTime.Now;
            }
            else
            {
                fx.fx_date = DateTime.Now;
            }

            decimal temp_num;
            if (!decimal.TryParse(num, out temp_num))
            {
                AJAXManager.Alert(UpdatePanel1, "请输入正确的金额");
                Manager.TextBox_Select(txt_num);
                return;
            }

            fx.dpid = dianpu;
            fx.fx_account = account;
            fx.fx_num = temp_num;
            fx.fx_remark = remark;
            fx.fx_state = state;
            fx.fx_zhifubao = zhifubao;

            int res;
            if (string.IsNullOrEmpty(id))
            {
                res = BLL.fanxianManager.Insert(fx);
            }
            else
            {
                res = BLL.fanxianManager.Update(fx);
            }
            if (res == 1)
            {
                AJAXManager.Alert(UpdatePanel1, "保存成功");
                if (string.IsNullOrEmpty(id))
                {
                    txt_account.Text = "";
                    txt_num.Text = "";
                    txt_remark.Text = "";
                    txt_zhifubao.Text = "";
                }
            }
            else
            {
                AJAXManager.Alert(UpdatePanel1, "保存失败");
            }
        }
        catch (Exception ex)
        {
            AJAXManager.Alert(UpdatePanel1, ex.ToString());
        }
    }
    #endregion



}