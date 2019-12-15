using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entity;
using System.Text.RegularExpressions;


public partial class OA_basic_order_record_add : WebPage
{
    string id;
    string bgid;
    protected void Page_Load(object sender, EventArgs e)
    {
        id = Request["id"];
        bgid = Request["bgid"];

        if (!IsPostBack)
        {
            Manager.Bind_DateTime(txt_date1);
            BLL.dianpuManager.ddl_bind(ddl_dianpu, false);
            bind();
        }
    }


    #region bind
    void bind()
    {
        int temp_bgid = 0;
        if (!string.IsNullOrEmpty(id))
        {
            int temp = 0;

            if (int.TryParse(id, out temp))
            {
                basic_order_record dp = basic_order_recordManager.SearchByID(temp);
                if (dp != null)
                {
                    try
                    {
                        ddl_dianpu.SelectedValue = dp.dpid.ToString();
                        ddl_maijiaxiu.SelectedValue = dp.ormaijiaxiu;
                        ddl_state.SelectedValue = dp.orprepare1;
                        txt_key.Text = dp.gkname;
                        txt_price.Text = dp.orprice;
                        txt_qq.Text = dp.orqq;
                        txt_remark.Text = dp.orremark;
                        txt_title.Text = dp.bgname;
                        txt_wangwang.Text = dp.orwangwang;
                        txt_wuliu.Text = dp.bgwuliu;
                        txt_date1.Text = dp.ordate.ToString("yyyy-MM-dd");
                        txt_code.Text = dp.orcode;

                    }
                    catch { }
                }
            }

        }
        else if (int.TryParse(bgid, out temp_bgid))
        {
            basic_goods bg = BLL.basic_goodsManager.SearchByID(Convert.ToInt32(bgid));
            ddl_dianpu.SelectedValue = bg.dpid.ToString();
            txt_title.Text = bg.bgname;
        }
        else
        {
            Manager.Alert("请先选择商品", Page);
            return;
        }
    }
    #endregion

    #region btn_save_Click
    protected void btn_save_Click(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(bgid) && string.IsNullOrEmpty(id))
            {
                Manager.Alert("请先选择商品2", Page);
                return;
            }
            else
            {
                basic_order_record or = new basic_order_record();
                if (!string.IsNullOrEmpty(id))
                {
                    or = BLL.basic_order_recordManager.SearchByID(Convert.ToInt32(id));
                }
                else
                {
                    or.ordate = DateTime.Now;
                }

                basic_goods bg = new basic_goods();
                if (!string.IsNullOrEmpty(bgid))
                {
                    bg = BLL.basic_goodsManager.SearchByID(Convert.ToInt32(bgid));
                }
                //else if (!string.IsNullOrEmpty(id))
                //{
                //    bg = BLL.basic_goodsManager.SearchByID(or.bgid);
                //}
                //else if (string.IsNullOrEmpty(id))
                //{
                //    Manager.Alert("请先选择商品3", Page);
                //    return;
                //}

                DateTime dt = new DateTime();
                

                string _dianpu = ddl_dianpu.SelectedValue;
                string remark = txt_remark.Text.Trim();
                string title = txt_title.Text.Trim();
                string state = ddl_state.SelectedValue;
                string maijiaxiu = ddl_maijiaxiu.SelectedValue;
                string _key = txt_key.Text.Trim();
                string price = txt_price.Text.Trim();
                string qq = txt_qq.Text.Trim();
                string wangwang = txt_wangwang.Text.Trim();
                string wuliu = txt_wuliu.Text.Trim();
                string code = txt_code.Text.Trim();
                string dt1 = txt_date1.Text.Trim();

                int dianpu = 0;
                int.TryParse(_dianpu, out dianpu);
                if (!DateTime.TryParse(dt1, out dt))
                {
                    Manager.Alert("请输入正确的补单时间", Page);
                    return;
                }



                or.bgid = bg.bgid;
                or.bgname = title;
                or.dpid = bg.dpid;
                or.dpname = bg.dpname;
                or.gkname = _key;
                or.bgwuliu = wuliu;
                or.ormaijiaxiu = maijiaxiu;
                or.orprepare1 = state;
                or.orprice = price;
                or.orqq = qq;
                or.orremark = remark;
                or.orwangwang = wangwang;
                or.orcode = code;
                or.ordate = dt;


                int res;
                if (string.IsNullOrEmpty(id))
                {
                    res = BLL.basic_order_recordManager.Insert(or);
                }
                else
                {
                    res = BLL.basic_order_recordManager.Update(or);
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

        }
        catch (Exception ex)
        {
            Manager.Alert(ex.ToString(), Page);
        }
        Manager.page_href_reload(Page);
    }
    #endregion




}