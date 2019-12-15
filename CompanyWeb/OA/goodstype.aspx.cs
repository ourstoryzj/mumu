using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entity;


public partial class OA_goodstype : WebPage
{

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {

            bind();
        }
    }


    #region bind
    void bind()
    {

        GridView1.DataSource = BLL.yh_goodstypeManager.SearchAll(true);
        GridView1.DataBind();


    }
    #endregion



    #region GridView1
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Manager.GridView_RowColor(e);
            string State = GridView1.DataKeys[e.Row.RowIndex].Values["gtstate"].ToString();
            string fxid = GridView1.DataKeys[e.Row.RowIndex].Values["gtid"].ToString();
            LinkButton lb_state = e.Row.FindControl("lb_state") as LinkButton;


            if (State == "1")
            {
                lb_state.Text = "启用";
                lb_state.ForeColor = System.Drawing.Color.Blue;
            }
            else if (State == "2")
            {
                lb_state.Text = "禁用";
                lb_state.ForeColor = System.Drawing.Color.Red;
            }


        }

    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        TextBox txt_sort = GridView1.Rows[e.RowIndex].FindControl("txt_sort") as TextBox;
        TextBox txt_name = GridView1.Rows[e.RowIndex].FindControl("txt_name") as TextBox;

        string name;
        string sort;
        decimal temp;

        if (string.IsNullOrEmpty(txt_name.Text))
        {
            Manager.Alert("请输入名称", Page);
            txt_name.Focus();
            return;
        }
        else
        {
            name = txt_name.Text.Trim();
        }
        if (string.IsNullOrEmpty(txt_sort.Text))
        {
            Manager.Alert("请输入排序", Page);
            txt_sort.Focus();
            return;
        }
        else
        {
            sort = txt_sort.Text.Trim();
        }
        if (!decimal.TryParse(sort, out temp))
        {
            Manager.Alert("请输入正确的排序", Page);
            txt_sort.Focus();
            return;
        }
        int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values["gtid"]);
        yh_goodstype gt = BLL.yh_goodstypeManager.SearchBygtid(id);
        gt.gtanme = name;
        gt.gtsort = sort;


        if (BLL.yh_goodstypeManager.Update(gt) != 1)
        {
            Manager.Alert("修改失败", Page);
        }
        Manager.page_href_reload(Page);
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        bind();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string state = e.CommandName;
        if (state == "state")
        {
            int id = Convert.ToInt32(GridView1.DataKeys[((e.CommandSource as LinkButton).NamingContainer as GridViewRow).RowIndex].Values["gtid"].ToString());
            if (id != 0)
            {
                yh_goodstype fx = BLL.yh_goodstypeManager.SearchBygtid(id);
                fx.gtstate = fx.gtstate == "1" ? "2" : "1";
                if (BLL.yh_goodstypeManager.Update(fx) != 1)
                {
                    Manager.Alert("修改失败", Page);
                }
            }
            Manager.page_href_reload(Page);
        }

    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        Manager.page_href_reload(Page);
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values["gtid"]);
        if (BLL.yh_goodstypeManager.Delete(id) != 1)
        {
            Manager.Alert("删除失败", Page);
        }
        else
        {
            Manager.Alert("删除成功", Page);
        }
        Manager.page_href_reload(Page);
    }
    #endregion






    #region AspNetPager1_PageChanged
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        bind();
    }
    #endregion


    protected void btn_save_Click(object sender, EventArgs e)
    {
        string name;
        string sort;
        decimal temp;
        if (string.IsNullOrEmpty(txt_name.Text))
        {
            Manager.Alert("请输入名称", Page);
            txt_name.Focus();
            return;
        }
        else
        {
            name = txt_name.Text.Trim();
        }
        if (string.IsNullOrEmpty(txt_sort.Text))
        {
            Manager.Alert("请输入排序", Page);
            txt_sort.Focus();
            return;
        }
        else
        {
            sort = txt_sort.Text.Trim();
        }
        if (!decimal.TryParse(sort, out temp))
        {
            Manager.Alert("请输入正确的排序", Page);
            txt_sort.Focus();
            return;
        }
        yh_goodstype gt = new yh_goodstype();
        gt.gtanme = name;
        gt.gtsort = sort;
        gt.gtdate = DateTime.Now;
        gt.gtstate = "1";


        if (BLL.yh_goodstypeManager.Insert(gt) != 1)
        {
            Manager.Alert("添加失败", Page);
        }
        else
        {
            Manager.Alert("添加成功", Page);
        }
        Manager.page_href_reload(Page);
    }



    protected void btn_sort_Click(object sender, EventArgs e)
    {
        IList<yh_goodstype> list = BLL.yh_goodstypeManager.GetList(false);
        int temp = 1;
        foreach (yh_goodstype gt in list)
        {
            gt.gtsort = temp.ToString();
            BLL.yh_goodstypeManager.Update(gt);
            temp++;
        }
        Manager.Alert("排序成功", Page);
        Manager.page_href_reload(Page);
    }
}