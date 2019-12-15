using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

/// <summary>
///AJAXManager 的摘要说明
/// </summary>
public class AJAXManager
{
    public AJAXManager()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //

    }


    #region Js
    /// <summary>
    /// UpdatePanel控件中使用JS
    /// </summary>
    /// <param name="up">UpdatePanel</param>
    /// <param name="js">js代码</param>
    public static void Js(UpdatePanel up, string js)
    {
        ScriptManager.RegisterStartupScript(up, up.Page.GetType(), "updateScript", js, true);
    }
    #endregion

    #region Alert
    /// <summary>
    /// UpdatePanel控件中使用JS的Alert
    /// </summary>
    /// <param name="up">UpdatePanel</param>
    /// <param name="str">弹出内容</param>
    public static void Alert(UpdatePanel up, string str)
    {
        ScriptManager.RegisterStartupScript(up, up.Page.GetType(), "updateScript", "alert('" + str + "');", true);
    }
    #endregion

    #region GridView行双击进入编辑状态方法

    #region GridView_ondblclick
    /// <summary>
    /// 在GridView1_RowDataBound中使用该方法,集成荧光棒效果
    /// </summary>
    /// <param name="e">GridViewRowEventArgs</param>
    /// <returns>判断是否是数据行，是返回true，否返回false</returns>
    public static bool GridView_ondblclick(GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            //双击进入编辑模式
            GridView gv = (e.Row.Parent).Parent as GridView;
            e.Row.Attributes["ondblclick"] = e.Row.Page.ClientScript.GetPostBackEventReference(((e.Row.Parent).Parent as GridView), "Edit$" + e.Row.RowIndex.ToString(), true);
            e.Row.Attributes["style"] = "cursor:pointer";
            e.Row.Attributes["title"] = "双击进入编辑";
            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#FFFF66'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=''");
            return true;
        }
        else
        {
            return false;
        }

        #region 注释
        //protected override void Render(HtmlTextWriter writer)
        //{
        //    foreach (GridViewRow Row in GridView1.Rows)
        //    {
        //        if (Row.RowType == DataControlRowType.DataRow)
        //        {
        //            //双击进入编辑模式
        //            Row.Attributes["ondblclick"] = ClientScript.GetPostBackEventReference(GridView1, "Edit$" + Row.RowIndex.ToString(), true);
        //            Row.Attributes["style"] = "cursor:pointer";
        //            Row.Attributes["title"] = "双击进入编辑";
        //            if (Row.RowState == DataControlRowState.Edit)
        //            {
        //                Row.Attributes.Remove("ondblclick");
        //                Row.Attributes.Remove("style");
        //                Row.Attributes["title"] = "编辑行";
        //                for (Int32 i = 1; i < GridView1.Columns.Count; i++)
        //                {
        //                    ((TextBox)Row.Cells[i].Controls[1]).Attributes.Add("onmouseover", "this.select()");

        //                }
        //                //双击更新
        //                Row.Attributes["ondblclick"] = ClientScript.GetPostBackEventReference(GridView1, "Update$" + Row.RowIndex.ToString(), true);

        //            }
        //            //
        //            for (int i = 1; i < Row.Cells.Count; i++)
        //            {
        //                Page.ClientScript.RegisterForEventValidation(Row.UniqueID + "$ctl00", i.ToString());
        //            }
        //        }
        //    }
        //    base.Render(writer);
        //}
        #endregion
    }
    #endregion

    #region GridView_ondblclick_Cancel
    /// <summary>
    /// GirdView取消编辑行(URL)
    /// </summary>
    /// <param name="page"></param>
    /// <returns>是URL参数返回false,否则返回true</returns>
    public static bool GridView_ondblclick_Cancel(UpdatePanel up)
    {
        string temp = System.Web.HttpContext.Current.Request[Manager.decl_eindex];
        if (!string.IsNullOrEmpty(temp))
        {
            //Manager.Href_Minus(Manager.decl_eindex, page);
            string url = Href_Minus(Manager.decl_eindex);
            page_href(up, url);
            return false;
        }
        else
        {
            return true;
        }
    }
    #endregion

    #region Href_Minus
    /// <summary>
    /// 减去URL参数
    /// </summary>
    /// <param name="page"></param>
    public static string Href_Minus(string name)
    {
        string url_name = System.Web.HttpContext.Current.Request[name];
        string url = System.Web.HttpContext.Current.Request.Url.ToString();
        if (!string.IsNullOrEmpty(url_name))
        {
            int temp = url.IndexOf(name); //找到参数在url中开始的位置
            int temp2 = url.IndexOf("&", temp + 1); //查看后面还有没有参数
            if (temp2 == -1)
            {
                url = url.Substring(0, temp - 1);
            }
            else
            {
                url = url.Substring(0, temp) + url.Substring(temp2, url.Length - temp2);
            }
        }
        return url;
    }
    #endregion

    #region page_href
    /// <summary>
    /// 跳转页面到
    /// </summary>
    /// <param name="up">输入this.UpdatePanel1</param>
    /// <param name="t">输入this.GetType()</param>
    /// <param name="url">要跳转的页面</param>
    public static void page_href(UpdatePanel up, string url)
    {
        Js(up, "window.location.replace('" + url + "');");
    }
    #endregion



    #endregion

}