using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entity;
using System.Text.RegularExpressions;


public partial class OA_fanxian_add_batch : WebPage
{

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            BLL.dianpuManager.ddl_bind(ddl_dianpu, false);
            IList<dianpu> list = BLL.dianpuManager.GetList(true);
            foreach (dianpu dp in list)
            {
                if (dp.dpname.IndexOf("八零末妞") > -1)
                {
                    ddl_dianpu.SelectedValue = dp.dpid.ToString();
                    return;
                }
            }
        }
    }




    #region btn_save_Click
    protected void btn_save_Click(object sender, EventArgs e)
    {
        try
        {
            DateTime dt = DateTime.Now;
            string num = txt_num.Text.Trim();
            string remark = txt_remark.Text.Trim();
            string state = ddl_state.SelectedValue.ToString();
            string dianpu = ddl_dianpu.SelectedValue != null ? ddl_dianpu.SelectedValue.ToString() : "";
            string data = txt_data.Text;
            //data=data.Replace("\t","");
            fanxian fx = new fanxian();
            fx.fx_date = DateTime.Now;
            int res1 = 0;
            int res2 = 0;

            decimal temp_num;
            if (!decimal.TryParse(num, out temp_num))
            {
                Manager.Alert("请输入正确的金额", Page);
                Manager.TextBox_Select(txt_num);
                return;
            }

            fx.dpid = dianpu;
            fx.fx_num = temp_num;
            fx.fx_remark = remark;
            fx.fx_state = state;

            //批量数据处理
            string[] ss = data.Split(new char[2] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in ss)
            {
                string[] arry = Regex.Split(s, "\\s+", RegexOptions.IgnoreCase);
                int i = 1;
                List<string> arry2=new List<string>(); 
                foreach (string temp in arry)
                {
                    if (!string.IsNullOrEmpty(temp))
                    {
                        arry2.Add(temp);
                    }
                }
                foreach (string temp in arry2)
                {
                    if (i == 1)
                    {
                        fx.fx_account = temp;
                    }
                    else if (i == 2)
                    {
                        fx.fx_zhifubao = temp;
                    }
                    i++;
                }
                if(string.IsNullOrEmpty(fx.fx_account)||string.IsNullOrEmpty(fx.fx_zhifubao))
                {
                    continue;
                }
                if (BLL.fanxianManager.Insert(fx) == 1)
                {
                    res1++;
                }
                else
                {
                    res2++;
                }
                fx.fx_account = "";
                fx.fx_zhifubao = "";
            }
            Manager.Alert("批处理操作完成:\\n成功添加 " + res1.ToString() + " 条信息" + (res2 == 0 ? "" : "\\n添加失败" + res2.ToString() + "条信息！请注意核实！"), Page);
        }
        catch (Exception ex)
        {
            Manager.Alert(ex.ToString(), Page);
        }
        Manager.page_href_reload(Page);
    }
    #endregion



}