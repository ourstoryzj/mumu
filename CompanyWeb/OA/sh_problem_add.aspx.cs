using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entity;
using System.Text.RegularExpressions;


public partial class OA_sh_problem_add : WebPage
{
    string id;
    IList<dianpu> dplist;
    protected void Page_Load(object sender, EventArgs e)
    {
        id = Request["id"];
        dplist = dianpuManager.GetList(false);
        if (!IsPostBack)
        {
            BLL.dianpuManager.ddl_bind(ddl_dianpu, true);
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
                shouhou sh = shouhouManager.SearchByshid(temp);
                if (sh != null)
                {
                    try
                    {
                        txt_account.Text = sh.shaccount;
                        txt_kdcode.Text = sh.shkdcode;
                        txt_kdphone.Text = sh.shytphone;
                        txt_name.Text = sh.shname;
                        txt_ordercode.Text = sh.shordercode;
                        txt_phone.Text = sh.shphone;
                        txt_remark.Text = sh.shremark;
                        txt_yuanyin.Text = sh.shyuanyin;
                        lbl_date.Text = sh.shdate.ToString();
                        ddl_dianpu.SelectedValue = sh.dpid.ToString();
                        ddl_state.SelectedValue = sh.shstate;
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
            string because = txt_yuanyin.Text.Trim();
            string name = txt_name.Text.Trim();
            string phone = txt_phone.Text.Trim();
            string remark = txt_remark.Text.Trim();
            string state = ddl_state.SelectedValue.ToString();
            string dianpu = ddl_dianpu.SelectedValue != null ? ddl_dianpu.SelectedValue.ToString() : "";
            string code = txt_ordercode.Text.Trim();
            string ytphone = txt_kdphone.Text.Trim();
            string kdcode = txt_kdcode.Text.Trim();


            shouhou sh = new shouhou();

            if (!string.IsNullOrEmpty(id))
            {
                sh = BLL.shouhouManager.SearchByshid(Convert.ToInt32(id));
            }

            //if (string.IsNullOrEmpty(name))
            //{
            //    Manager.Alert("请输入买家姓名");
            //    Manager.TextBox_Select(txt_name);
            //    return;
            //}
            if (string.IsNullOrEmpty(account))
            {
                AJAXManager.Alert(UpdatePanel1, "请输入买家账号");
                Manager.TextBox_Select(txt_account);
                return;
            }
            //if (string.IsNullOrEmpty(phone))
            //{
            //    Manager.Alert("请输入买家电话号码");
            //    Manager.TextBox_Select(txt_phone);
            //    return;
            //}
            //if (string.IsNullOrEmpty(code))
            //{
            //    Manager.Alert("请输入订单号码");
            //    Manager.TextBox_Select(txt_ordercode);
            //    return;
            //}
            if (string.IsNullOrEmpty(dianpu))
            {
                AJAXManager.Alert(UpdatePanel1, "请选择店铺");
                ddl_dianpu.Focus();
                return;
            }



            sh.shaccount = account;
            sh.dpid = Convert.ToInt32(dianpu);
            sh.shname = name;
            sh.shordercode = code;
            sh.shphone = phone;
            sh.shremark = remark;
            sh.shstate = state;
            sh.shyuanyin = because;
            sh.shdate = dt;
            sh.shytphone = ytphone;
            sh.shkdcode = kdcode;

            int res;
            if (string.IsNullOrEmpty(id))
            {
                res = BLL.shouhouManager.Insert(sh);
                bind();
            }
            else
            {
                res = BLL.shouhouManager.Update(sh);
            }
            if (res == 1)
            {
                AJAXManager.Alert(UpdatePanel1, "保存成功");
                if (string.IsNullOrEmpty(id))
                {
                    clear();
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


    #region btn_quickadd_Click
    protected void btn_quickadd_Click(object sender, EventArgs e)
    {
        string str = txt_quickadd.Text.Trim();
        string temp = str;
        if (string.IsNullOrEmpty(str))
            return;
        str = Regex.Replace(str, @"[\n\r]", "");
        str = Regex.Replace(str, @"\s+", "");
        str = str.Replace(" ", "");
        int orderid_1;
        int orderid_2;
        string orderid = string.Empty;
        int account_1;
        int account_2;
        string account = string.Empty;
        int name_1;
        int name_2;
        string name = string.Empty;
        int phone_1;
        int phone_2;
        string phone = string.Empty;
        int kdcode_1;
        int kdcode_2;
        string kdcode = string.Empty;
        txt_quickadd.Text = str;

        try
        {
            if (str.IndexOf("蘑菇街") > -1)
            {
                //蘑菇街的
                orderid_1 = str.IndexOf("订单编号：");
                orderid_2 = str.IndexOf("成交时间：");
                if (orderid_1 > -1 && orderid_2 > -1 && orderid_2 > orderid_1)
                    orderid = str.Substring(orderid_1 + 5, orderid_2 - orderid_1 - 5);
                account_1 = str.IndexOf("买家：");
                account_2 = str.IndexOf("当前状态：");
                if (account_1 > -1 && account_2 > -1 && account_2 > account_1)
                    account = str.Substring(account_1 + 3, account_2 - account_1 - 3);
                name_1 = str.IndexOf("收货人：");
                name_2 = str.IndexOf("收货地址：");
                if (name_1 > -1 && name_2 > -1 && name_2 > name_1)
                    name = str.Substring(name_1 + 4, name_2 - name_1 - 4);
                phone_1 = str.IndexOf("联系电话：");
                phone_2 = str.IndexOf("修改地址", phone_1) > -1 ? str.IndexOf("修改地址", phone_1) : str.IndexOf("备注", phone_1);
                if (phone_1 > -1 && phone_2 > -1 && phone_2 > phone_1)
                    phone = str.Substring(phone_1 + 5, phone_2 - phone_1 - 5);
                kdcode_1 = str.IndexOf("快递单号：");
                kdcode_2 = str.IndexOf("修改", kdcode_1) > -1 ? str.IndexOf("修改", kdcode_1) : str.IndexOf("物流跟踪：");
                if (kdcode_1 > -1 && kdcode_2 > -1 && kdcode_2 > kdcode_1)
                    kdcode = str.Substring(kdcode_1 + 5, kdcode_2 - kdcode_1 - 5);

                foreach (dianpu dp in dplist)
                {
                    if (dp.dpname.IndexOf("蘑菇街") > -1)
                    {
                        ddl_dianpu.SelectedValue = dp.dpid.ToString();
                        break;
                    }
                }

            }
            else if (str.IndexOf("淘宝") > -1)
            {
                //淘宝的
                orderid_1 = str.IndexOf("订单编号：");
                orderid_2 = str.IndexOf("创建时间：");
                if (orderid_1 > -1 && orderid_2 > -1 && orderid_2 > orderid_1)
                    orderid = str.Substring(orderid_1 + 5, orderid_2 - orderid_1 - 5);
                account_1 = str.IndexOf("如果期间买家（");
                account_2 = str.IndexOf("）没有");
                if (account_1 > -1 && account_2 > -1 && account_2 > account_1)
                    account = str.Substring(account_1 + 7, account_2 - account_1 - 7);
                name_1 = str.IndexOf("收货地址：");
                name_2 = str.IndexOf("，", name_1);
                if (name_1 > -1 && name_2 > -1 && name_2 > name_1)
                    name = str.Substring(name_1 + 5, name_2 - name_1 - 5);
                phone_1 = name_2;
                phone_2 = str.IndexOf("，", name_2 + 1);
                if (phone_1 > -1 && phone_2 > -1 && phone_2 > phone_1)
                    phone = str.Substring(phone_1 + 1, phone_2 - phone_1 - 1);
                kdcode_1 = str.IndexOf("运单号：");
                kdcode_2 = str.IndexOf("查看物流信息");
                if (kdcode_1 > -1 && kdcode_2 > -1 && kdcode_2 > kdcode_1)
                    kdcode = str.Substring(kdcode_1 + 4, kdcode_2 - kdcode_1 - 4);
                //Manager.Alert(name_2.ToString(),);
                string dpname = str.Substring(str.IndexOf("手机版") + 3, str.IndexOf("淘宝网首页") - str.IndexOf("手机版") - 3);
                foreach (dianpu dp in dplist)
                {
                    if (dp.dpname.IndexOf(dpname) > -1)
                    {
                        ddl_dianpu.SelectedValue = dp.dpid.ToString();
                        break;
                    }
                }
            }
            else
            {
                AJAXManager.Alert(UpdatePanel1, "无法识别,请手动填写");
                Manager.TextBox_Select(txt_quickadd);
                return;
            }
            txt_account.Text = account;
            txt_kdcode.Text = kdcode;
            txt_phone.Text = phone;
            txt_name.Text = name;
            txt_ordercode.Text = orderid;
            txt_yuanyin.Focus();
        }
        catch (Exception ex)
        {
            AJAXManager.Alert(UpdatePanel1, ex.ToString());
        }
    }
    #endregion


    #region 
    void clear()
    {
        txt_account.Text = "";
        txt_kdcode.Text = "";
        txt_kdphone.Text = "";
        txt_name.Text = "";
        txt_ordercode.Text = "";
        txt_phone.Text = "";
        txt_remark.Text = "";
        txt_yuanyin.Text = "";
        lbl_date.Text = "";
        ddl_dianpu.SelectedValue = "";
        ddl_state.SelectedValue = "1";
    }
    #endregion
}