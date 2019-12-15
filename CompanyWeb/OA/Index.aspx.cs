using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entity;


public partial class OA_sh_problem_list : WebPage
{



    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            bind_task();
            bind_shouhou();
            bind_goods();
            bind_fanxian();
        }
    }


    #region 任务列表

    #region bind_task
    void bind_task()
    {
        DateTime temp_date1 = new DateTime();
        DateTime temp_date2 = new DateTime();
        string key = "";
        string state = "1";

        AspNetPager3.RecordCount = BLL.basic_taskManager.SearchNum(key, state, temp_date1, temp_date2, new DateTime(), new DateTime());
        GridView4.DataSource = AspNetPager3.RecordCount == 0 ? null : BLL.basic_taskManager.Search(AspNetPager3.StartRecordIndex, AspNetPager3.EndRecordIndex, key, state, temp_date1, temp_date2, new DateTime(), new DateTime(), "");
        GridView4.DataBind();
    }
    #endregion

    #region GridView4
    protected void GridView4_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (AJAXManager.GridView_ondblclick(e))
        {
            try
            {
                string State = GridView4.DataKeys[e.Row.RowIndex].Values["btstate"].ToString();



                LinkButton lb_state = e.Row.FindControl("lb_state") as LinkButton;


                //状态
                if (State == "1")
                {
                    lb_state.Text = "未处理";
                    lb_state.ForeColor = System.Drawing.Color.Blue;
                }
                else if (State == "2")
                {
                    lb_state.Text = "已完成";
                    lb_state.ForeColor = System.Drawing.Color.Red;
                    lb_state.Font.Bold = true;
                }


                //判断是否是编辑状态
                if (GridView4.EditIndex != e.Row.RowIndex)
                {



                }
            }
            catch (Exception ex) { Common.ErrorLog.WriteEntry(ex); }

        }
    }
    protected void GridView4_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        TextBox txt_name = GridView4.Rows[e.RowIndex].FindControl("txt_name") as TextBox;
        TextBox txt_remark = GridView4.Rows[e.RowIndex].FindControl("txt_remark") as TextBox;
        int id = Convert.ToInt32(GridView4.DataKeys[e.RowIndex].Values["btid"]);
        basic_task sh = basic_taskManager.SearchByID(id);
        sh.btname = txt_name.Text.Trim();
        sh.btcontent = txt_remark.Text.Trim();



        if (BLL.basic_taskManager.Update(sh) != 1)
        {
            AJAXManager.Alert(this.UpdatePanel1, "修改失败");
        }
        else
        {
            GridView4.EditIndex = -1;
            bind_task();
        }

    }
    protected void GridView4_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView4.EditIndex = e.NewEditIndex;
        bind_task();
    }
    protected void GridView4_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string state = e.CommandName;
        if (state == "state")
        {
            int id = Convert.ToInt32(GridView4.DataKeys[((e.CommandSource as LinkButton).NamingContainer as GridViewRow).RowIndex].Values["btid"].ToString());
            if (id != 0)
            {
                basic_task sh = BLL.basic_taskManager.SearchByID(id);
                sh.btstate = (sh.btstate == "1" ? "2" : "1");
                if (BLL.basic_taskManager.Update(sh) != 1)
                {
                    AJAXManager.Alert(this.UpdatePanel1, "修改失败");
                }
                else
                {
                    GridView4.EditIndex = -1;
                    bind_task();
                }
            }
        }

    }
    protected void GridView4_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView4.EditIndex = -1;
        bind_task();
    }
    protected void GridView4_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int id = Convert.ToInt32(GridView4.DataKeys[e.RowIndex].Values["btid"]);
        if (BLL.basic_taskManager.Delete(id) != 1)
        {
            AJAXManager.Alert(this.UpdatePanel1, "删除失败");
        }
        else
        {
            AJAXManager.Alert(this.UpdatePanel1, "删除成功");
            bind_task();
        }
    }
    #endregion

    #region AspNetPager1_PageChanged
    protected void AspNetPager3_PageChanged(object sender, EventArgs e)
    {
        bind_task();
    }
    #endregion

    #endregion

    #region 售后

    #region bind_shouhou
    void bind_shouhou()
    {
        DateTime temp_date1 = new DateTime();
        DateTime temp_date2 = new DateTime();
        int temp_dp = 0;
        string key = "";
        string state = "1";

        AspNetPager1.RecordCount = BLL.shouhouManager.SearchNum(key, temp_dp, temp_date1, temp_date2, state);
        GridView1.DataSource = AspNetPager1.RecordCount == 0 ? null : BLL.shouhouManager.Search(AspNetPager1.StartRecordIndex, AspNetPager1.EndRecordIndex, key, temp_dp, temp_date1, temp_date2, state, "");
        GridView1.DataBind();
    }
    #endregion

    #region GridView1
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (AJAXManager.GridView_ondblclick(e))
        {
            try
            {
                string State = GridView1.DataKeys[e.Row.RowIndex].Values["shstate"].ToString();
                string dianpu = GridView1.DataKeys[e.Row.RowIndex].Values["dpid"].ToString();
                LinkButton lb_state = e.Row.FindControl("lb_state") as LinkButton;

                Label lbl_dianpu = e.Row.FindControl("lbl_dianpu") as Label;

                if (State == "1")
                {
                    lb_state.Text = "未处理";
                    lb_state.ForeColor = System.Drawing.Color.Blue;
                }
                else if (State == "2")
                {
                    lb_state.Text = "已投诉";
                    lb_state.ForeColor = System.Drawing.Color.Red;
                }
                else if (State == "3")
                {
                    lb_state.Text = "已处理";
                    lb_state.ForeColor = System.Drawing.Color.Green;
                }

                IList<dianpu> list = BLL.dianpuManager.GetList(false);
                foreach (dianpu dp in list)
                {
                    if (dp.dpid.ToString() == dianpu)
                    {
                        lbl_dianpu.Text = dp.dpname;
                        lbl_dianpu.ForeColor = System.Drawing.Color.Green;
                        //if (dp.dpremark.IndexOf("淘宝") > 0)
                        //{
                        //    lb_account.NavigateUrl = "http://www.taobao.com/webww/ww.php?ver=3&touid=" + lb_account.Text + "&siteid=cntaobao&status=1&charset=utf-8";
                        //    lb_account.ForeColor = System.Drawing.Color.Blue;
                        //}
                        break;
                    }
                }

                //判断是否是编辑状态
                if (GridView1.EditIndex != e.Row.RowIndex)
                {
                    HyperLink lb_account = e.Row.FindControl("lb_account") as HyperLink;
                    lb_account.NavigateUrl = "http://www.taobao.com/webww/ww.php?ver=3&touid=" + lb_account.Text + "&siteid=cntaobao&status=1&charset=utf-8";
                    lb_account.ForeColor = System.Drawing.Color.Blue;
                }
            }
            catch (Exception ex) { Common.ErrorLog.WriteEntry(ex); }

        }
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        TextBox txt_ordercode = GridView1.Rows[e.RowIndex].FindControl("txt_ordercode") as TextBox;
        TextBox txt_name = GridView1.Rows[e.RowIndex].FindControl("txt_name") as TextBox;
        TextBox txt_account = GridView1.Rows[e.RowIndex].FindControl("txt_account") as TextBox;
        TextBox txt_yuanyin = GridView1.Rows[e.RowIndex].FindControl("txt_yuanyin") as TextBox;
        TextBox txt_kdcode = GridView1.Rows[e.RowIndex].FindControl("txt_kdcode") as TextBox;

        int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values["shid"]);
        shouhou sh = BLL.shouhouManager.SearchByshid(id);
        sh.shordercode = txt_ordercode.Text.Trim();
        sh.shname = txt_name.Text.Trim();
        sh.shaccount = txt_account.Text.Trim();
        sh.shkdcode = txt_kdcode.Text.Trim();
        sh.shyuanyin = txt_yuanyin.Text.Trim();

        if (BLL.shouhouManager.Update(sh) != 1)
        {
            AJAXManager.Alert(this.UpdatePanel1, "修改失败");
        }
        else
        {
            GridView1.EditIndex = -1;
            bind_shouhou();
        }

    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        bind_shouhou();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string state = e.CommandName;
        if (state == "state")
        {
            int id = Convert.ToInt32(GridView1.DataKeys[((e.CommandSource as LinkButton).NamingContainer as GridViewRow).RowIndex].Values["shid"].ToString());
            if (id != 0)
            {
                shouhou sh = BLL.shouhouManager.SearchByshid(id);
                sh.shstate = (sh.shstate == "1" ? "2" : (sh.shstate == "2" ? "3" : "1"));
                if (BLL.shouhouManager.Update(sh) != 1)
                {
                    AJAXManager.Alert(this.UpdatePanel1, "修改失败");
                }
                else
                {
                    GridView1.EditIndex = -1;
                    bind_shouhou();
                }
            }
        }
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        bind_shouhou();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values["shid"]);
        if (BLL.shouhouManager.Delete(id) != 1)
        {
            AJAXManager.Alert(this.UpdatePanel1, "删除失败");
        }
        else
        {
            AJAXManager.Alert(this.UpdatePanel1, "删除成功");
            bind_shouhou();
        }
    }
    #endregion

    #region AspNetPager1_PageChanged
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        bind_shouhou();
    }
    #endregion

    #endregion


    #region 补单商品


    #region bind_goods
    void bind_goods()
    {
        IList<basic_goods> list = BLL.basic_goodsManager.GetListByOrder();
        //AspNetPager2.RecordCount = list.Count;
        //lbl_count.Text = "(共" + list.Count.ToString() + "条数据)";
        GridView2.DataSource = list.Count == 0 ? null : list;
        GridView2.DataBind();


        //DateTime temp_date1 = new DateTime();
        //DateTime temp_date2 = new DateTime();
        //DateTime temp_date3 = new DateTime();
        //DateTime temp_date4 = new DateTime();
        //int temp_dp = 0;
        //int temp_op = 0;
        //int temp_hp = 0;
        //string state = "1";
        //string key = "";
        //string iskey = "";

        //IList<basic_goods> list = BLL.basic_goodsManager.Search(1, 10000, key, temp_op, temp_hp, temp_dp, state, iskey, temp_date1, temp_date2, temp_date3, temp_date4, "");
        ////AspNetPager2.RecordCount = list.Count;
        ////lbl_count.Text = "(共" + list.Count.ToString() + "条数据)";
        //GridView2.DataSource = list.Count == 0 ? null : list;
        //GridView2.DataBind();


        //AspNetPager1.RecordCount = BLL.basic_goodsManager.SearchNum(key, temp_op, temp_hp, temp_dp, state, iskey, temp_date1, temp_date2, temp_date3, temp_date4);
        //lbl_count.Text = "(共" + AspNetPager1.RecordCount.ToString() + "条数据)";
        //GridView1.DataSource = AspNetPager1.RecordCount == 0 ? null : BLL.basic_goodsManager.Search(AspNetPager1.StartRecordIndex, AspNetPager1.EndRecordIndex, key, temp_op, temp_hp, temp_dp, state, iskey, temp_date1, temp_date2, temp_date3, temp_date4, "");
        //GridView1.DataBind();



    }
    #endregion


    #region GridView2
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //try
        //{
        if (AJAXManager.GridView_ondblclick(e))
        {
            try
            {
                string State = GridView2.DataKeys[e.Row.RowIndex].Values["bgstate"].ToString();
                string dpid = GridView2.DataKeys[e.Row.RowIndex].Values["dpid"].ToString();
                string bgid = GridView2.DataKeys[e.Row.RowIndex].Values["bgid"].ToString();
                string hdid = GridView2.DataKeys[e.Row.RowIndex].Values["hdid"].ToString();
                string bgkey = GridView2.DataKeys[e.Row.RowIndex].Values["bgkey"].ToString();
                string opid = GridView2.DataKeys[e.Row.RowIndex].Values["opid"].ToString();
                string bgupdate = GridView2.DataKeys[e.Row.RowIndex].Values["bgupdate"].ToString();
                DateTime up_date = new DateTime();
                DateTime.TryParse(bgupdate, out up_date);

                LinkButton lb_state = e.Row.FindControl("lb_state") as LinkButton;
                LinkButton lb_key = e.Row.FindControl("lb_key") as LinkButton;
                Label lbl_dianpu = e.Row.FindControl("lbl_dianpu") as Label;
                Label lbl_order = e.Row.FindControl("lbl_order") as Label;
                Label lbl_huodong = e.Row.FindControl("lbl_huodong") as Label;


                //补单
                int temp_order = basic_order_planManager.GetNumInPlan(up_date, Convert.ToInt32(opid));
                int _order_count = BLL.basic_order_recordManager.SearchNum("", Convert.ToInt32(bgid), 0, 0, "", "", DateTime.Now, DateTime.Now);
                int res_count = temp_order - _order_count;
                if (res_count > 0)
                {
                    lbl_order.Text = "需补 " + (temp_order - _order_count).ToString() + " 单";
                    lbl_order.ForeColor = System.Drawing.Color.Red;
                    lbl_order.Font.Bold = true;
                }
                else
                {
                    lbl_order.Text = "无";
                    lbl_order.ForeColor = System.Drawing.Color.Black;
                }

                //活动提示
                basic_huodong hd = basic_huodongManager.SearchByID(Convert.ToInt32(hdid));
                int temp_huodong = Manager.DateDiff_GetInt(DateTime.Now, up_date) + 1;
                if (temp_huodong == hd.hdone || temp_huodong == hd.hdtwo)
                {
                    lbl_huodong.Text = "今日" + hd.hddate1.ToString("HH:mm") + "报名";
                    lbl_huodong.ForeColor = System.Drawing.Color.Red;
                    lbl_huodong.Font.Bold = true;
                }
                else
                {
                    lbl_huodong.Text = "无";
                    lbl_huodong.ForeColor = System.Drawing.Color.Black;
                }


                //状态
                if (State == "1")
                {
                    lb_state.Text = "启用";
                    lb_state.ForeColor = System.Drawing.Color.Red;
                    //lb_state.Font.Bold = true;
                }
                else if (State == "2")
                {
                    lb_state.Text = "禁用";
                    lb_state.ForeColor = System.Drawing.Color.Blue;
                }

                //是否重点
                if (bgkey == "1")
                {
                    lb_key.Text = "是";
                    lb_key.ForeColor = System.Drawing.Color.Red;
                    lb_key.Font.Bold = true;
                }
                else if (bgkey == "2")
                {
                    lb_key.Text = "否";
                    lb_key.ForeColor = System.Drawing.Color.Blue;
                }

                //店铺
                dianpu dp = BLL.dianpuManager.GetInList(dpid);
                if (dp != null)
                {
                    lbl_dianpu.Text = dp.dpname;
                    lbl_dianpu.ForeColor = System.Drawing.Color.Green;
                    //    lb_account.NavigateUrl = "http://www.taobao.com/webww/ww.php?ver=3&touid=" + lb_account.Text + "&siteid=cntaobao&status=1&charset=utf-8";
                }


                //判断是否是编辑状态
                if (GridView2.EditIndex != e.Row.RowIndex)
                {
                    //LinkButton lb_zhifubao = e.Row.FindControl("lb_zhifubao") as LinkButton;

                    //HyperLink lb_account = e.Row.FindControl("lb_account") as HyperLink;
                    //lb_account.NavigateUrl = "http://www.taobao.com/webww/ww.php?ver=3&touid=" + lb_account.Text + "&siteid=cntaobao&status=1&charset=utf-8";
                    //lb_account.ForeColor = System.Drawing.Color.Blue;

                }

            }
            catch (Exception ex)
            {
                Common.ErrorLog.WriteEntry(ex);
            }
        }
    }
    protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        TextBox txt_name = GridView2.Rows[e.RowIndex].FindControl("txt_name") as TextBox;
        TextBox txt_update = GridView2.Rows[e.RowIndex].FindControl("txt_update") as TextBox;
        TextBox txt_remark = GridView2.Rows[e.RowIndex].FindControl("txt_remark") as TextBox;

        int id = Convert.ToInt32(GridView2.DataKeys[e.RowIndex].Values["bgid"]);
        basic_goods fx = BLL.basic_goodsManager.SearchByID(id);
        if (string.IsNullOrEmpty(txt_name.Text))
        {
            AJAXManager.Alert(this.UpdatePanel1, "请输入商品名称");
            return;
        }
        DateTime _dt = new DateTime();
        if (!DateTime.TryParse(txt_update.Text, out _dt))
        {
            AJAXManager.Alert(this.UpdatePanel1, "请输入正确的上架时间");
            return;
        }

        fx.bgname = txt_name.Text.Trim();
        fx.bgupdate = _dt;
        fx.bgremark = txt_remark.Text.Trim();
        //fx.bgdate = DateTime.Now;

        if (BLL.basic_goodsManager.Update(fx) != 1)
        {
            AJAXManager.Alert(this.UpdatePanel1, "修改失败");

        }
        else
        {
            GridView2.EditIndex = -1;
            bind_goods();
        }
    }
    protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView2.EditIndex = e.NewEditIndex;
        bind_goods();
    }
    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string state = e.CommandName;
        if (state == "state")
        {
            int id = Convert.ToInt32(GridView2.DataKeys[((e.CommandSource as LinkButton).NamingContainer as GridViewRow).RowIndex].Values["bgid"].ToString());
            if (id != 0)
            {
                basic_goods fx = BLL.basic_goodsManager.SearchByID(id);
                fx.bgstate = fx.bgstate == "1" ? "2" : "1";
                if (fx.bgstate == "2")
                {
                    //fx.bgdate = DateTime.Now;
                }
                if (BLL.basic_goodsManager.Update(fx) != 1)
                {
                    AJAXManager.Alert(this.UpdatePanel1, "修改失败");
                }
                else
                {
                    bind_goods();
                }
            }
        }
        else if (state == "iskey")
        {
            int id = Convert.ToInt32(GridView2.DataKeys[((e.CommandSource as LinkButton).NamingContainer as GridViewRow).RowIndex].Values["bgid"].ToString());
            if (id != 0)
            {
                basic_goods fx = BLL.basic_goodsManager.SearchByID(id);
                fx.bgkey = fx.bgkey == "1" ? "2" : "1";
                //fx.bgdate = DateTime.Now;
                if (BLL.basic_goodsManager.Update(fx) != 1)
                {
                    AJAXManager.Alert(this.UpdatePanel1, "修改失败");
                }
                else
                {
                    bind_goods();
                }
                //AJAXManager.Alert(UpdatePanel1, "test");
                //AJAXManager.Js(UpdatePanel1, "to_zhifubao('" + fx.fx_zhifubao + "','" + fx.fx_num + "')");
            }

        }
    }
    protected void GridView2_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        if (AJAXManager.GridView_ondblclick_Cancel(this.UpdatePanel1))
        {
            GridView2.EditIndex = -1;
            bind_goods();
        }
    }
    protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int id = Convert.ToInt32(GridView2.DataKeys[e.RowIndex].Values["bgid"]);
        if (BLL.basic_goodsManager.Delete(id) != 1)
        {
            AJAXManager.Alert(this.UpdatePanel1, "删除失败");
        }
        else
        {
            AJAXManager.Alert(this.UpdatePanel1, "删除成功");
        }
        bind_goods();
    }
    #endregion







    #endregion



    #region 返现

    #region bind_fanxian
    void bind_fanxian()
    {
        DateTime temp_date1 = new DateTime();
        DateTime temp_date2 = new DateTime();
        DateTime temp_date3 = new DateTime();
        DateTime temp_date4 = new DateTime();
        int temp_dp = 0;
        string key = "";
        string state = "1";

        AspNetPager2.RecordCount = BLL.fanxianManager.SearchNum(key, state, temp_dp, temp_date1, temp_date2, temp_date3, temp_date4);
        GridView3.DataSource = AspNetPager2.RecordCount == 0 ? null : BLL.fanxianManager.Search(AspNetPager2.StartRecordIndex, AspNetPager2.EndRecordIndex, key, state, temp_dp, temp_date1, temp_date2, temp_date2, temp_date3, "");
        GridView3.DataBind();



    }
    #endregion

    #region GridView3
    protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //try
        //{
        if (AJAXManager.GridView_ondblclick(e))
        {
            try
            {
                string State = GridView3.DataKeys[e.Row.RowIndex].Values["fx_state"].ToString();
                string dianpu = GridView3.DataKeys[e.Row.RowIndex].Values["dpid"].ToString();
                string fxid = GridView3.DataKeys[e.Row.RowIndex].Values["fx_id"].ToString();
                string price = GridView3.DataKeys[e.Row.RowIndex].Values["fx_num"].ToString();
                LinkButton lb_state = e.Row.FindControl("lb_state") as LinkButton;
                Label lbl_dianpu = e.Row.FindControl("lbl_dianpu") as Label;


                if (State == "1")
                {
                    lb_state.Text = "未返现";
                    lb_state.ForeColor = System.Drawing.Color.Blue;
                }
                else if (State == "2")
                {
                    lb_state.Text = "已处理";
                    lb_state.ForeColor = System.Drawing.Color.Green;
                }
                else if (State == "3")
                {
                    lb_state.Text = "有问题";
                    lb_state.ForeColor = System.Drawing.Color.Red;
                }
                IList<dianpu> list = BLL.dianpuManager.GetList(false);
                foreach (dianpu dp in list)
                {
                    if (dp.dpid.ToString() == dianpu)
                    {
                        lbl_dianpu.Text = dp.dpname;
                        lbl_dianpu.ForeColor = System.Drawing.Color.Green;
                        //if (dp.dpremark.IndexOf("淘宝") > 0)
                        //{
                        //    lb_account.NavigateUrl = "http://www.taobao.com/webww/ww.php?ver=3&touid=" + lb_account.Text + "&siteid=cntaobao&status=1&charset=utf-8";
                        //    lb_account.ForeColor = System.Drawing.Color.Blue;
                        //}
                        break;
                    }
                }

                //判断是否是编辑状态
                if (GridView3.EditIndex != e.Row.RowIndex)
                {
                    //Label lbl_zhifubao = e.Row.FindControl("lbl_zhifubao") as Label;
                    LinkButton lb_zhifubao = e.Row.FindControl("lb_zhifubao") as LinkButton;

                    HyperLink lb_account = e.Row.FindControl("lb_account") as HyperLink;
                    lb_account.NavigateUrl = "http://www.taobao.com/webww/ww.php?ver=3&touid=" + lb_account.Text + "&siteid=cntaobao&status=1&charset=utf-8";
                    lb_account.ForeColor = System.Drawing.Color.Blue;

                    //支付宝打款
                    try
                    {

                        object obj = GridView3.DataKeys[e.Row.RowIndex].Values["fx_zhifubao"];
                        if (obj != null)
                        {
                            string zhifubao = obj.ToString();
                            if (!string.IsNullOrEmpty(zhifubao) && !string.IsNullOrEmpty(price))
                            {
                                //判断返现次数
                                int n = BLL.fanxianManager.SearchNum(zhifubao, "", 0, new DateTime(), new DateTime(), new DateTime(), new DateTime());
                                lb_zhifubao.ForeColor = System.Drawing.Color.Red;
                                if (n > 1)
                                {
                                    lb_zhifubao.ForeColor = System.Drawing.Color.Silver;
                                    lb_zhifubao.Font.Bold = true;
                                    lb_zhifubao.ToolTip = "该支付宝已经返现" + n.ToString() + "次，请留意！";
                                }

                                //添加返现功能
                                string js = n > 1 ? "alert('该用户已经返现" + n.ToString() + "次，确定要继续返现么？');to_zhifubao('" + zhifubao + "','" + price + "');" : "to_zhifubao('" + zhifubao + "','" + price + "');";
                                lb_zhifubao.Attributes["onclick"] = js;

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Common.ErrorLog.WriteEntry(ex);
                    }
                }

            }
            catch (Exception ex)
            {
                Common.ErrorLog.WriteEntry(ex);
            }
        }
    }
    protected void GridView3_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        TextBox txt_account = GridView3.Rows[e.RowIndex].FindControl("txt_account") as TextBox;
        TextBox txt_zhifubao = GridView3.Rows[e.RowIndex].FindControl("txt_zhifubao") as TextBox;
        TextBox txt_num = GridView3.Rows[e.RowIndex].FindControl("txt_num") as TextBox;
        TextBox txt_remark = GridView3.Rows[e.RowIndex].FindControl("txt_remark") as TextBox;

        int id = Convert.ToInt32(GridView3.DataKeys[e.RowIndex].Values["fx_id"]);
        fanxian fx = BLL.fanxianManager.SearchByfx_id(id);
        fx.fx_num = Convert.ToDecimal(txt_num.Text.Trim());
        fx.fx_remark = txt_remark.Text.Trim();
        fx.fx_zhifubao = txt_zhifubao.Text.Trim();
        fx.fx_account = txt_account.Text.Trim();

        if (BLL.fanxianManager.Update(fx) != 1)
        {
            AJAXManager.Alert(this.UpdatePanel1, "修改失败");

        }
        else
        {
            GridView3.EditIndex = -1;
            bind_fanxian();
        }
    }
    protected void GridView3_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView3.EditIndex = e.NewEditIndex;
        bind_fanxian();
    }
    protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string state = e.CommandName;
        if (state == "state")
        {
            int id = Convert.ToInt32(GridView3.DataKeys[((e.CommandSource as LinkButton).NamingContainer as GridViewRow).RowIndex].Values["fx_id"].ToString());
            if (id != 0)
            {
                fanxian fx = BLL.fanxianManager.SearchByfx_id(id);
                fx.fx_state = fx.fx_state == "1" ? "2" : (fx.fx_state == "2" ? "3" : "1");
                if (fx.fx_state == "2")
                {
                    fx.fx_date2 = DateTime.Now;
                }
                if (BLL.fanxianManager.Update(fx) != 1)
                {
                    AJAXManager.Alert(this.UpdatePanel1, "修改失败");
                }
                else
                {
                    bind_fanxian();
                }
            }
        }
        else if (state == "fanxian")
        {
            int id = Convert.ToInt32(GridView3.DataKeys[((e.CommandSource as LinkButton).NamingContainer as GridViewRow).RowIndex].Values["fx_id"].ToString());
            if (id != 0)
            {
                fanxian fx = BLL.fanxianManager.SearchByfx_id(id);
                fx.fx_state = "2";
                fx.fx_date2 = DateTime.Now;
                if (BLL.fanxianManager.Update(fx) != 1)
                {
                    AJAXManager.Alert(this.UpdatePanel1, "修改失败");
                }
                else
                {
                    bind_fanxian();
                }
                //AJAXManager.Alert(UpdatePanel1, "test");
                //AJAXManager.Js(UpdatePanel1, "to_zhifubao('" + fx.fx_zhifubao + "','" + fx.fx_num + "')");
            }

        }
    }
    protected void GridView3_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        if (AJAXManager.GridView_ondblclick_Cancel(this.UpdatePanel1))
        {
            GridView3.EditIndex = -1;
            bind_fanxian();
        }
    }
    protected void GridView3_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int id = Convert.ToInt32(GridView3.DataKeys[e.RowIndex].Values["fx_id"]);
        if (BLL.fanxianManager.Delete(id) != 1)
        {
            AJAXManager.Alert(this.UpdatePanel1, "删除失败");
        }
        else
        {
            AJAXManager.Alert(this.UpdatePanel1, "删除成功");
        }
        bind_fanxian();
    }
    #endregion

    #region AspNetPager2_PageChanged
    protected void AspNetPager2_PageChanged(object sender, EventArgs e)
    {
        bind_fanxian();
    }
    #endregion

    #endregion

}