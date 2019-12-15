using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// WebPage 的摘要说明
/// </summary>
public class WebPage:MyPage
{
    public WebPage()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    /// <summary>
    /// 初始化方法
    /// </summary>
    /// <param name="e"></param>
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        //BLL.UsersManager.User_Exit(true);
        try
        {
            this.Title = System.Configuration.ConfigurationManager.AppSettings["Title"];
        }
        catch { }
    }
}
