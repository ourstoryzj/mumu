using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity;
using BLL;

public partial class OA_main_top : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }


    protected void btn_do_Click(object sender, EventArgs e)
    {
        string key = txt_key.Text.Trim();
        if (string.IsNullOrEmpty(key))
        {
            AJAXManager.Alert(UpdatePanel1, "请输入关键词");
            txt_key.Focus();
            return;
        }
        IList<fanxian> list = BLL.fanxianManager.Search(1, 1, key, "", 0, new DateTime(), new DateTime(), new DateTime(), new DateTime(), "");
        if (list.Count > 0)
        {
            fanxian fx = (fanxian)list[0];
            if (fx != null)
            {
                fx.fx_remark = "支付宝打款失败";
                fx.fx_state = "3";
                if (BLL.fanxianManager.Update(fx) == 1)
                {
                    AJAXManager.Alert(UpdatePanel1, "处理成功");
                    return;
                }
                else
                {
                    AJAXManager.Alert(UpdatePanel1, "处理失败");
                    return;
                }
            }
        }
        AJAXManager.Alert(UpdatePanel1, "没有找到数据");

    }
}