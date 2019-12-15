using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entity;

public partial class OA_sign_list : WebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind();
            Manager.Bind_DateTime(txt_end);
            Manager.Bind_DateTime(txt_start);
        }
    }

    #region bind
    void bind()
    {
        string key = Request["key"];
        txt_key.Text = key;
        int t = 0;
        int s = 0;
        if (int.TryParse(Request["type"], out t))
        {
            ddl_type.SelectedValue = t.ToString();
        }
        if (int.TryParse(Request["state"], out t))
        {
            ddl_state.SelectedValue = s.ToString();
        }
        DateTime start = new DateTime();
        DateTime end = new DateTime();
        if (DateTime.TryParse(Request["start"], out start))
        {
            txt_start.Text = Request["start"];
        }
        if (DateTime.TryParse(Request["end"], out end))
        {
            txt_end.Text = Request["end"];
        }
        IList<Signs> list = null;
        AspNetPager1.RecordCount = SignsManager.searchNum(key, start, end, Manager.User.Id, s, t);
        list = SignsManager.search(AspNetPager1.StartRecordIndex, AspNetPager1.EndRecordIndex, key, start, end, Manager.User.Id, s, t, "");
        GridView1.DataSource = list;
        GridView1.DataBind();
    }
    #endregion

    #region GridView1_RowDataBound
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        BLL.Manager.GridView_RowColor(e);
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lbl_id = e.Row.FindControl("lbl_id") as Label;
            Label lbl_state = e.Row.FindControl("lbl_state") as Label;
            Label lbl_type = e.Row.FindControl("lbl_type") as Label;
            string s = GridView1.DataKeys[e.Row.RowIndex].Values["UState"].ToString();
            string t = GridView1.DataKeys[e.Row.RowIndex].Values["UType"].ToString();

            lbl_id.Text = (e.Row.RowIndex + 1).ToString();
            switch (s)
            {
                case "1":
                    lbl_state.Text = "正常";
                    break;
                case "2":
                    lbl_state.Text = "迟到";
                    lbl_state.ForeColor = System.Drawing.Color.Blue;
                    break;
                case "3":
                    lbl_state.Text = "旷工";
                    lbl_state.ForeColor = System.Drawing.Color.Red;
                    break;
                case "4":
                    lbl_state.Text = "请假";
                    lbl_state.ForeColor = System.Drawing.Color.Yellow;
                    break;
            }
            switch (t)
            {
                case "1":
                    lbl_type.Text = "上午签到";
                    lbl_type.ForeColor = System.Drawing.Color.BlueViolet;
                    break;
                case "2":
                    lbl_type.Text = "上午签退";
                    lbl_type.ForeColor = System.Drawing.Color.Violet;
                    break;
                case "3":
                    lbl_type.Text = "下午签到";
                    lbl_type.ForeColor = System.Drawing.Color.Aqua;
                    break;
                case "4":
                    lbl_type.Text = "下午签退";
                    lbl_type.ForeColor = System.Drawing.Color.Aquamarine;
                    break;
            }
        }
    }
    #endregion

    #region AspNetPager1_PageChanged
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        bind();
    }
    #endregion

 
}