﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entity;
using System.Text.RegularExpressions;


public partial class OA_yh_keys_add : WebPage
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
                yh_keys k = BLL.yh_keysManager.SearchBykid(temp);
                if (k != null)
                {
                    try
                    {
                        txt_name.Text = k.kname;
                        txt_dianjilv.Text = k.kdianjilv.ToString();
                        txt_dianjizhanbi.Text = k.kscdianjizhanbi.ToString();
                        txt_dianjizhishu.Text = k.kdianjizhishu.ToString();
                        txt_remark.Text = k.kremark;
                        txt_shangpinshuliang.Text = k.kgoodsnum.ToString();
                        txt_sousuocishu.Text = k.kcishu.ToString();
                        txt_sousuorenshu.Text = k.krenshu.ToString();
                        txt_sousuozhanbi.Text = k.ksousuozhanbi.ToString();
                        txt_zhitongche.Text = k.kzhitongche.ToString();
                        txt_zhuanhualv.Text = k.kzhuanhualv.ToString();
                        lbl_dangebaobeisousuocishu.Text = k.kdgbbsscs.ToString();
                        lbl_qiangebaobeichengjiaocishu.Text = k.kqgbbcjcs.ToString();
                        lbl_date.Text = k.kdate.ToString();
                        ddl_state.SelectedValue = k.kstate;

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
            //string name = txt_name.Text.Trim();
            //string remark = txt_remark.Text.Trim();
            //txt_name.Text = k.kname;
            //txt_dianjilv.Text = k.kdianjilv.ToString();
            //txt_dianjizhanbi.Text = k.kscdianjizhanbi.ToString();
            //txt_dianjizhishu.Text = k.kdianjizhishu.ToString();
            //txt_remark.Text = k.kremark;
            //txt_shangpinshuliang.Text = k.kgoodsnum.ToString();
            //txt_sousuocishu.Text = k.kcishu.ToString();
            //txt_sousuorenshu.Text = k.krenshu.ToString();
            //txt_sousuozhanbi.Text = k.ksousuozhanbi.ToString();
            //txt_zhitongche.Text = k.kzhitongche.ToString();
            //txt_zhuanhualv.Text = k.kzhuanhualv.ToString();
            //lbl_dangebaobeisousuocishu.Text = k.kdgbbsscs.ToString();
            //lbl_qiangebaobeichengjiaocishu.Text = k.kqgbbcjcs.ToString();
            //lbl_date.Text = k.kdate.ToString();
            //ddl_state.SelectedValue = k.kstate;


            yh_corekeys ck = new yh_corekeys();


            if (!string.IsNullOrEmpty(id))
            {
                ck = BLL.yh_corekeysManager.SearchByckid(Convert.ToInt32(id));
            }
            else
            {
                ck.ckdate = DateTime.Now;
            }

            //ck.ckname = name;
            //ck.ckremark = remark;
            //ck.cksort = sort;
            //ck.ckstate = state;
            //ck.gtid = gt;

            int res;
            if (string.IsNullOrEmpty(id))
            {
                res = BLL.yh_corekeysManager.Insert(ck);
            }
            else
            {
                res = BLL.yh_corekeysManager.Update(ck);
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
            Manager.Alert(ex.ToString());
        }
        Manager.page_href_reload(Page);
    }
    #endregion



    #region btn_quickadd_Click
    protected void btn_quickadd_Click(object sender, EventArgs e)
    {
        //string str = txt_quickadd.Text.Trim();
        //string remark = txt_remark.Text.Trim();
        //string state = ddl_state.SelectedValue.ToString();
        //string gt = ddl_goodstype.SelectedValue;
        //string sort = txt_sort.Text.Trim();
        //yh_corekeys ck = new yh_corekeys();
        //ck.ckremark = remark;
        //ck.cksort = sort;
        //ck.ckstate = state;
        //ck.gtid = gt;


        //int res1 = 0;
        //int res2 = 0;

        //if (string.IsNullOrEmpty(str))
        //    return;
        //try
        //{
        //    string[] ss = str.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
        //    foreach (string s in ss)
        //    {
        //        string temp = s.Trim();
        //        if (!string.IsNullOrEmpty(temp))
        //        {
        //            ck.ckname = temp;
        //            ck.ckdate = DateTime.Now;
        //            if (BLL.yh_corekeysManager.Insert(ck) == 1)
        //            {
        //                res1++;
        //            }
        //            else
        //            {
        //                res2++;
        //            }
        //        }
        //    }
        //    Manager.Alert("批处理操作完成:\\n成功添加 " + res1.ToString() + " 条信息" + (res2 == 0 ? "" : "\\n添加失败" + res2.ToString() + "条信息！请注意核实！"), Page);
        //}
        //catch (Exception ex)
        //{
        //    Manager.Alert(ex.ToString(), Page);
        //}
    }
    #endregion
}