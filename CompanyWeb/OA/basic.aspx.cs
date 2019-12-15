using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entity;


public partial class OA_basic : WebPage
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
        GridView1.DataSource = BLL.BasicManager.SearchAll();
        GridView1.DataBind();
    }
    #endregion

    #region btn_save_Click
    protected void btn_save_Click(object sender, EventArgs e)
    {
        string date1 = txt_1.Text.Trim();
        string date2 = txt_2.Text.Trim();
        string date3 = txt_3.Text.Trim();
        string date4 = txt_4.Text.Trim();

        Basic basic = new Basic();

        basic.Sign1 = date1;
        basic.Sign2 = date2;
        basic.Sign3 = date3;
        basic.Sign4 = date4;

        int res = 0;
        res = BLL.BasicManager.Insert(basic);
        if (res == 1)
        {
            Manager.Alert("保存成功", Page);
        }
        else
        {
            Manager.Alert("保存失败", Page);
        }

        Manager.page_href_reload(Page);

    }
    #endregion

    #region GridView1
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Manager.GridView_RowColor(e);
            string State = GridView1.DataKeys[e.Row.RowIndex].Values["State"].ToString();
            LinkButton lb_state = e.Row.FindControl("lb_state") as LinkButton;
            if (State == "1")
            {
                lb_state.Text = "启用";
                lb_state.ForeColor = System.Drawing.Color.Blue;
            }
            else
            {
                lb_state.Text = "禁用";
                lb_state.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        TextBox txt_sign1 = GridView1.Rows[e.RowIndex].FindControl("txt_sign1") as TextBox;
        TextBox txt_sign2 = GridView1.Rows[e.RowIndex].FindControl("txt_sign2") as TextBox;
        TextBox txt_sign3 = GridView1.Rows[e.RowIndex].FindControl("txt_sign3") as TextBox;
        TextBox txt_sign4 = GridView1.Rows[e.RowIndex].FindControl("txt_sign4") as TextBox;

        int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values["Id"]);
        Basic b = BLL.BasicManager.SearchById(id);
        b.Sign1 = txt_sign1.Text;
        b.Sign2 = txt_sign2.Text;
        b.Sign3 = txt_sign3.Text;
        b.Sign4 = txt_sign4.Text;

        if (BLL.BasicManager.Update(b) != 1)
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
            int id = Convert.ToInt32(GridView1.DataKeys[((e.CommandSource as LinkButton).NamingContainer as GridViewRow).RowIndex].Values["Id"].ToString());
            if (id != 0)
            {
                update_state();
                Basic b = BLL.BasicManager.SearchById(id);
                b.State = (b.State == "1" ? "2" : "1");
                if (BLL.BasicManager.Update(b) != 1)
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
    #endregion

    #region update_state
    void update_state()
    {
        IList<Basic> list = BLL.BasicManager.SearchAll();
        foreach (Basic b in list)
        {
            b.State = "2";
            BLL.BasicManager.Update(b);
        }
    }
    #endregion

}