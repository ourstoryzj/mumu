using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entity;
using System.Text.RegularExpressions;


public partial class OA_goods_add : WebPage
{
    string id;
    IList<yh_goodstype> dplist;
    protected void Page_Load(object sender, EventArgs e)
    {
        id = Request["id"];
        dplist = yh_goodstypeManager.GetList(true);
        if (!IsPostBack)
        {
            BLL.yh_goodstypeManager.ddl_bind(ddl_goodstype, true);
            bind();
            Manager.Bind_UpImg(fu_img, "div_img1", img_tu, "img_yulan1", 0, 0);
            Manager.Bind_UpImg(fu_img2, "div_img2", img_tu2, "img_yulan2", 0, 0);
        }
        PostBackTrigger trigger = new PostBackTrigger();
        trigger.ControlID = btn_save.UniqueID;
        UpdatePanel1.Triggers.Add(trigger);   
    }


    #region bind
    void bind()
    {
        if (!string.IsNullOrEmpty(id))
        {
            int temp = 0;
            if (int.TryParse(id, out temp))
            {
                goods g = goodsManager.SearchBygid(temp);
                if (g != null)
                {
                    try
                    {
                        txt_name.Text = g.gname;
                        txt_remark.Text = g.gremark1;
                        lbl_date.Text = g.gdate.ToString();
                        lbl_date_img.Text = g.gdate1.ToString();
                        lbl_date_up.Text = g.gdate2.ToString();
                        lbl_date_yh.Text = g.gdate3.ToString();
                        txt_price1.Text = g.gprice1;
                        txt_price2.Text = g.gprice2;
                        txt_title.Text = g.gtitle;
                        txt_url.Text = g.gurl;
                        txt_url2.Text = g.gurl2;
                        txt_url_yuan.Text = g.gurl_yuan;
                        ddl_goodstype.SelectedValue = g.gtid.ToString();
                        ddl_state_img.SelectedValue = g.gstate1;
                        ddl_state_up.SelectedValue = g.gstate2;
                        ddl_state_yh.SelectedValue = g.gstate3;
                        txt_price.Text = g.g_price_yuan;
                        ddl_important.SelectedValue = g.g_standby1;
                        if (string.IsNullOrEmpty(g.gimg))
                        {
                            img_tu.ImageUrl = "~/OA/images/noimg.jpg";
                        }
                        else
                        {
                            img_tu.ImageUrl = "~/OA/upload/" + g.gimg;
                            a_img1.HRef = "upload/" + g.gimg;
                        }
                        if (string.IsNullOrEmpty(g.gimg2))
                        {
                            img_tu2.ImageUrl = "~/OA/images/noimg.jpg";
                        }
                        else
                        {
                            img_tu2.ImageUrl = "~/OA/upload/" + g.gimg2;
                            a_img2.HRef = "upload/" + g.gimg2;
                        }
                    }
                    catch (Exception ex)
                    {
                        Common.ErrorLog.WriteEntry(ex);
                    }
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
            string gname = txt_name.Text.Trim();
            string gtitle = txt_title.Text.Trim();
            string gurl = txt_url.Text.Trim();
            string gurl2 = txt_url2.Text.Trim();
            string gimg = "";
            string gimg2 = "";
            string gstate1 = ddl_state_img.SelectedValue;
            string gstate2 = ddl_state_up.SelectedValue;
            string gstate3 = ddl_state_yh.SelectedValue;
            string gremark1 = txt_remark.Text.Trim();
            int gtid = int.Parse(ddl_goodstype.SelectedValue);
            string gprice1 = txt_price1.Text.Trim();
            string gprice2 = txt_price2.Text.Trim();
            string gurl_yuan = txt_url_yuan.Text.Trim();
            string gprice = txt_price.Text.Trim();
            string important = ddl_important.SelectedValue;

            goods g = new goods();

            if (!string.IsNullOrEmpty(id))
            {
                g = BLL.goodsManager.SearchBygid(Convert.ToInt32(id));
                gimg = g.gimg;
                gimg2 = g.gimg2;
            }
            else
            {
                g.gdate = dt;
            }

            if (string.IsNullOrEmpty(gname))
            {
                //Manager.Alert("请输入商品简称", Page);
                AJAXManager.Alert(UpdatePanel1, "请输入商品简称");
                Manager.TextBox_Select(txt_name);
                return;
            }
            if (gtid == 0)
            {
                //Manager.Alert("请选择店铺", Page);
                AJAXManager.Alert(UpdatePanel1, "请选择店铺");
                ddl_goodstype.Focus();
                return;
            }
            if (fu_img.HasFile && fu_img2.HasFile)
            {
                //Manager.Alert("暂时不能同时上传两个图片,请单独上传！", Page);
                AJAXManager.Alert(UpdatePanel1, "暂时不能同时上传两个图片,请单独上传！");
                return;
            }
            else
            {
                if (fu_img.HasFile)
                {
                    gimg = Manager.UpImage(fu_img, Request.PhysicalApplicationPath + "OA\\upload\\", Page);
                    if (string.IsNullOrEmpty(gimg))
                    {
                        //Manager.Alert("淘宝图片上传失败，请稍后再试", Page);
                        AJAXManager.Alert(UpdatePanel1, "淘宝图片上传失败，请稍后再试");
                        return;
                    }
                }
                if (fu_img2.HasFile)
                {
                    gimg2 = Manager.UpImage(fu_img2, Request.PhysicalApplicationPath + "OA\\upload\\", Page);
                    if (string.IsNullOrEmpty(gimg2))
                    {
                        //Manager.Alert("淘宝图片上传失败，请稍后再试", Page);
                        AJAXManager.Alert(UpdatePanel1, "淘宝图片上传失败，请稍后再试");
                        return;
                    }
                }
            }

            g.gdate1 = gstate1 == "2" ? dt : new DateTime();
            g.gdate2 = gstate2 == "2" ? dt : new DateTime();
            g.gdate3 = gstate3 == "2" ? dt : new DateTime();
            g.gimg = gimg;
            g.gimg2 = gimg2;
            g.gname = gname;
            g.gprice1 = gprice1;
            g.gprice2 = gprice2;
            g.gremark1 = gremark1;
            g.gstate1 = gstate1;
            g.gstate2 = gstate2;
            g.gstate3 = gstate3;
            g.gtid = gtid;
            g.gtitle = gtitle;
            g.gurl = gurl;
            g.gurl2 = gurl2;
            g.gurl_yuan = gurl_yuan;
            g.g_price_yuan = gprice;
            g.g_standby1 = important;


            int res;
            if (string.IsNullOrEmpty(id))
            {
                res = BLL.goodsManager.Insert(g);
            }
            else
            {
                res = BLL.goodsManager.Update(g);
            }
            if (res == 1)
            {
                //Manager.Alert("保存成功", Page);
                AJAXManager.Alert(UpdatePanel1, "保存成功");
                clear();
            }
            else
            {
                //Manager.Alert("保存失败", Page);
                AJAXManager.Alert(UpdatePanel1, "保存失败");
            }
        }
        catch (Exception ex)
        {
            //Manager.Alert(ex.ToString(), Page);
            AJAXManager.Alert(UpdatePanel1, ex.ToString());
        }
        //Manager.page_href_reload(Page);
    }
    #endregion


    #region
    void clear()
    {
        if (string.IsNullOrEmpty(id))
        {
            try
            {
                txt_name.Text = "";
                txt_remark.Text = "";
                lbl_date.Text = "";
                lbl_date_img.Text = "";
                lbl_date_up.Text = "";
                lbl_date_yh.Text = "";
                txt_price1.Text = "";
                txt_price2.Text = "";
                txt_title.Text = "";
                txt_url.Text = "";
                txt_url2.Text = "";
                txt_url_yuan.Text = "";
                ddl_goodstype.SelectedValue = "";
                ddl_state_img.SelectedValue = "";
                ddl_state_up.SelectedValue = "";
                ddl_state_yh.SelectedValue = "";
                img_tu.ImageUrl = "~/OA/images/noimg.jpg";
                img_tu2.ImageUrl = "~/OA/images/noimg.jpg";
                ddl_important.SelectedValue = "";
            }
            catch (Exception ex)
            {
                Common.ErrorLog.WriteEntry(ex);
            }
        }
    }
    #endregion



}