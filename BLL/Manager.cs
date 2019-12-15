using System;
using System.Collections.Generic;
using System.Text;
using Entity;
using Common;
using IDAL;
using DALFactory;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using System.Collections;
using System.IO;


namespace BLL
{
    public class Manager
    {


        #region 声明

        /// <summary>
        /// 管理员
        /// </summary>
        public static readonly string decl_Admin = "Session_Admin";
        /// <summary>
        /// 上传文件后保存文件名的Cookie的名称
        /// </summary>
        public static readonly string decl_UploadFileName = "UploadFileName";
        /// <summary>
        /// girdview编辑的行
        /// </summary>
        public static readonly string decl_EditIndex = "Edit";
        /// <summary>
        /// 存验证码的Cookie名称
        /// </summary>
        public static readonly string decl_Code = "Code";
        /// <summary>
        /// 重置密码
        /// </summary>
        public static readonly string decl_ResetPwd = "888888";
        /// <summary>
        /// 用户
        /// </summary>
        public static readonly string decl_User = "Session_User";
        /// <summary>
        /// 用户账号
        /// </summary>
        public static readonly string decl_User_Acc = "Session_User_Acc";
        /// <summary>
        /// 用户密码
        /// </summary>
        public static readonly string decl_User_Pwd = "Session_User_Pwd";
        /// <summary>
        /// 上下班时间
        /// </summary>
        public static readonly string decl_Basic = "Session_Basic";

        public static readonly string decl_dianpu = "Session_dianpu";

        public static readonly string decl_huashu = "decl_huashu";

        public static readonly string decl_courier = "Session_courier";

        public static readonly string decl_pagestype = "decl_pagestype";

        public static readonly string decl_goods_import = "decl_goods_import";

        public static readonly string decl_goodstype = "Session_goodstype";

        public static readonly string decl_order_plan = "Session_order_plan";

        public static readonly string decl_huodong_plan = "Session_huodong_plan";

        /// <summary>
        /// GridView中需要Edit的RowIndex
        /// </summary>
        public static readonly string decl_eindex = "Session_eindex";

        /// <summary>
        /// 声明随机数
        /// </summary>
        private static readonly Random random = new Random();
        /// <summary>
        /// 声明锁定线程,以获取随机数
        /// </summary>
        private static readonly object syncLock = new object();

        #endregion



        #region 私有方法

        #region factory
        /// <summary>
        /// 获取DAL抽象工厂实体类
        /// </summary>
        public static AbstractDALFactory factory = AbstractDALFactory.ChooseFactory();
        #endregion

        #region Admin
        /// <summary>
        /// Session中的管理员信息
        /// </summary>
        public static Admins Admin
        {
            get { return HttpContext.Current.Session[decl_Admin] == null ? null : (Admins)HttpContext.Current.Session[decl_Admin]; }
            set { HttpContext.Current.Session[decl_Admin] = value; }
        }
        #endregion

        #region List_dianpu
        /// <summary>
        /// Session中的管理员信息
        /// </summary>
        public static IList<dianpu> List_dianpu
        {
            get { return HttpContext.Current.Session[decl_dianpu] == null ? null : (IList<dianpu>)HttpContext.Current.Session[decl_dianpu]; }
            set { HttpContext.Current.Session[decl_dianpu] = value; }
        }
        #endregion

        #region List_order_plan
        /// <summary>
        /// Session中的订单方案信息
        /// </summary>
        public static IList<basic_order_plan> List_order_plan
        {
            get { return HttpContext.Current.Session[decl_order_plan] == null ? null : (IList<basic_order_plan>)HttpContext.Current.Session[decl_order_plan]; }
            set { HttpContext.Current.Session[decl_order_plan] = value; }
        }
        #endregion

        #region List_dianpu
        /// <summary>
        /// Session中的活动方案信息
        /// </summary>
        public static IList<basic_huodong> List_huodong_plan
        {
            get { return HttpContext.Current.Session[decl_huodong_plan] == null ? null : (IList<basic_huodong>)HttpContext.Current.Session[decl_huodong_plan]; }
            set { HttpContext.Current.Session[decl_huodong_plan] = value; }
        }
        #endregion

        #region List_huashu
        /// <summary>
        /// Session中的管理员信息
        /// </summary>
        public static IList<huashu> List_huashu
        {
            get { return HttpContext.Current.Session[decl_huashu] == null ? null : (IList<huashu>)HttpContext.Current.Session[decl_huashu]; }
            set { HttpContext.Current.Session[decl_huashu] = value; }
        }
        #endregion

        #region List_dianpu
        /// <summary>
        /// Session中的管理员信息
        /// </summary>
        public static IList<courier> List_courier
        {
            get { return HttpContext.Current.Session[decl_courier] == null ? null : (IList<courier>)HttpContext.Current.Session[decl_courier]; }
            set { HttpContext.Current.Session[decl_courier] = value; }
        }
        #endregion

        #region List_pagestype
        /// <summary>
        /// Session中的页面类型信息
        /// </summary>
        public static IList<pages_type> List_pagestype
        {
            get { return HttpContext.Current.Session[decl_pagestype] == null ? null : (IList<pages_type>)HttpContext.Current.Session[decl_pagestype]; }
            set { HttpContext.Current.Session[decl_pagestype] = value; }
        }
        #endregion

        #region List_goods_important
        /// <summary>
        /// Session中的管理员信息
        /// </summary>
        public static IList<goods> List_goods_important
        {
            get { return HttpContext.Current.Session[decl_goods_import] == null ? null : (IList<goods>)HttpContext.Current.Session[decl_goods_import]; }
            set { HttpContext.Current.Session[decl_goods_import] = value; }
        }
        #endregion

        #region List_goodstype
        /// <summary>
        /// Session中的商品类型
        /// </summary>
        public static IList<yh_goodstype> List_goodstype
        {
            get { return HttpContext.Current.Session[decl_goodstype] == null ? null : (IList<yh_goodstype>)HttpContext.Current.Session[decl_goodstype]; }
            set { HttpContext.Current.Session[decl_goodstype] = value; }
        }
        #endregion

        #region Basic
        /// <summary>
        /// Session中的管理员信息
        /// </summary>
        public static Basic Basic
        {
            get { return HttpContext.Current.Session[decl_Basic] == null ? null : (Basic)HttpContext.Current.Session[decl_Basic]; }
            set { HttpContext.Current.Session[decl_Basic] = value; }
        }
        #endregion

        #region User
        /// <summary>
        /// Session中的用户信息
        /// </summary>
        public static Users User
        {
            get { return HttpContext.Current.Session[decl_User] == null ? null : (Users)HttpContext.Current.Session[decl_User]; }
            set { HttpContext.Current.Session[decl_User] = value; }
        }
        #endregion

        #endregion

        #region 控件处理

        #region DropDownList

        #region DDL_BindFrist
        /// <summary>
        /// 绑定DropDownList 的第一个选项为"- 请选择 -",值为空
        /// </summary>
        /// <param name="ddl"></param>
        public static void DDL_BindFrist(DropDownList ddl)
        {
            if (ddl.Items.FindByValue("") == null)
            {
                ListItem item = new ListItem("- 请选择 -", "");
                item.Selected = true;
                ddl.Items.Insert(0, item);
            }
        }
        #endregion

        #region DDL_RemoveSelected()
        /// <summary>
        /// 移除DropDownList中得默认选择项的默认选择属性
        /// </summary>
        /// <param name="ddl"></param>
        public static void DDL_RemoveSelected(DropDownList ddl)
        {
            ListItem item = ddl.SelectedItem;
            if (item != null)
            {
                item.Selected = false;
            }
        }

        #endregion

        #region GetListItem(string txt)
        /// <summary>
        /// 获取一个ListItem,值为0,文本为"请选择"
        /// </summary>
        /// <returns></returns>
        public static ListItem GetListItem(string txt)
        {
            ListItem item = new ListItem();
            item.Text = string.IsNullOrEmpty(txt) ? "==请选择==" : txt;
            item.Value = "0";
            return item;
        }
        #endregion

        #region DDL_SetFirstItem(DropDownList ddl, string txt)
        public static void DDL_SetFirstItem(DropDownList ddl, string txt)
        {
            ddl.Items.Add(GetListItem(txt));
        }
        #endregion

        #endregion

        #region FileUpload

        #region Bind_UpShowImg
        /// <summary>
        /// 绑定即时预览的方法
        /// </summary>
        /// <param name="fu"></param>
        /// <param name="img"></param>
        /// <param name="width">图片最大宽度</param>
        /// <param name="height">图片最大高度</param>
        public static void Bind_UpShowImg(FileUpload fu, Image img, int width, int height)
        {
            fu.Attributes["onchange"] = "document.getElementById('" + img.ClientID + "').src=document.getElementById('" + fu.ClientID + "').value;";
            img.Attributes["onload"] = "javascript:DrawImage(this," + width.ToString() + "," + height.ToString() + ");";
        }
        #endregion

        #region UpImage
        /// <summary>
        /// 图片上传方法
        /// </summary>
        /// <param name="FileUpload1">FIleUpload控件</param>
        /// <param name="path">路径 例如:string path = Request.PhysicalApplicationPath+"upload\\advert\\"</param>
        /// <returns>bool</returns>
        public static string UpImage(FileUpload fu, string path, Page p)
        {
            string filetype;
            string res = "";
            if (!fu.HasFile)
            {
                Manager.Alert("请选择要上传的图片", p);
            }
            else
            {
                // filetype = FileUpload1.PostedFile.ContentType;
                filetype = System.IO.Path.GetExtension(fu.FileName).ToLower();
                //if (filetype != "image/bmp" && filetype != "image/gif" && filetype != "image/pjpeg")
                if (filetype != ".bmp" && filetype != ".gif" && filetype != ".jpg" && filetype != ".png")
                {
                    Manager.Alert("文件类型错误,请上传后缀名为:bmp,gif,jpg,png", p);
                }
                else
                {
                    //string path = Request.PhysicalApplicationPath;
                    //path += "upload\\advert\\";
                    if (!System.IO.Directory.Exists(path))
                    {
                        System.IO.Directory.CreateDirectory(path);
                    }

                    try
                    {
                        //string filename = FileUpload1.FileName;
                        //string[] temp = filename.Split(new char[] { '.' });
                        Random random = new Random(10000);
                        int filename = random.Next(9999999);
                        string name = Common.UseMethod.MD5(filename.ToString() + DateTime.Now.ToString()) + filetype;
                        //HttpContext.Current.Response.Cookies.Remove(decl_UploadFileName);
                        //HttpCookie cookie = new HttpCookie(decl_UploadFileName);
                        //cookie.Value = image;
                        //cookie.Expires = DateTime.Now.AddDays(-1);
                        //HttpContext.Current.Response.Cookies.Add(cookie);
                        //string name = image; // temp.GetValue(1);
                        fu.SaveAs(path + name);
                        res = name;
                    }
                    catch (Exception ex)
                    {
                        Manager.Alert(ex.Message, p);
                        throw ex;
                    }

                }
            }
            return res;
        }
        public static bool UpImage2(FileUpload FileUpload1, string path, Page p)
        {
            string filetype;
            bool res = false;
            if (!FileUpload1.HasFile)
            {
                Manager.Alert("请选择要上传的图片", p);
            }
            else
            {
                // filetype = FileUpload1.PostedFile.ContentType;
                filetype = System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();
                //if (filetype != "image/bmp" && filetype != "image/gif" && filetype != "image/pjpeg")
                if (filetype != ".bmp" && filetype != ".gif" && filetype != ".jpg" && filetype != ".png")
                {
                    Manager.Alert("文件类型错误,请上传后缀名为:bmp,gif,jpg,png", p);
                }
                else
                {
                    //string path = Request.PhysicalApplicationPath;
                    //path += "upload\\advert\\";
                    if (!System.IO.Directory.Exists(path))
                    {
                        System.IO.Directory.CreateDirectory(path);
                    }

                    try
                    {
                        //string filename = FileUpload1.FileName;
                        //string[] temp = filename.Split(new char[] { '.' });
                        Random random = new Random(10000);
                        int filename = random.Next(9999999);
                        string image = Common.UseMethod.MD5(filename.ToString() + DateTime.Now.ToString()) + filetype;
                        HttpContext.Current.Response.Cookies.Remove(decl_UploadFileName);
                        HttpCookie cookie = new HttpCookie(decl_UploadFileName);
                        cookie.Value = image;
                        cookie.Expires = DateTime.Now.AddDays(-1);
                        HttpContext.Current.Response.Cookies.Add(cookie);
                        string name = image; // temp.GetValue(1);
                        FileUpload1.SaveAs(path + name);
                        res = true;
                    }
                    catch (Exception ex)
                    {
                        Manager.Alert(ex.Message, p);
                        throw ex;
                    }

                }
            }
            return res;
        }
        #endregion

        #region UpFile
        /// <summary>
        /// 图片上传方法
        /// </summary>
        /// <param name="FileUpload1">FIleUpload控件</param>
        /// <param name="path">路径 例如:string path = Request.PhysicalApplicationPath+"upload\\advert\\"</param>
        /// <returns>bool</returns>
        public static bool UpFile(FileUpload FileUpload1, string[] type, string path, string filename)
        {
            string filetype;
            bool res = false;
            bool temp_type = false;
            string temp_types = string.Empty;
            if (!FileUpload1.HasFile)
            {
                Manager.Alert("请选择要上传的文件");
                return res;
            }
            else
            {
                //filetype = FileUpload1.PostedFile.ContentType;
                filetype = System.IO.Path.GetExtension(FileUpload1.FileName);
                for (int i = 0; i < type.Length; i++)
                {
                    temp_types += type.GetValue(i);
                    if ((i + 1) != type.Length)
                    {
                        temp_types += ",";
                    }
                    if (filetype == type.GetValue(i).ToString())
                    {
                        temp_type = true;
                    }
                }
                if (!temp_type)
                {
                    Manager.Alert("文件类型错误,请上传后缀名为:" + temp_types + "文件");
                    return res;
                }
                else
                {
                    //string path = Request.PhysicalApplicationPath;
                    //path += "upload\\advert\\";
                    if (!System.IO.Directory.Exists(path))
                    {
                        System.IO.Directory.CreateDirectory(path);
                    }

                    try
                    {
                        if (string.IsNullOrEmpty(filename))
                        {
                            Random random = new Random(10000);
                            int temp_filename = random.Next(9999999);
                            filename = Common.UseMethod.MD5(temp_filename.ToString() + DateTime.Now.ToString());
                            filename += filetype;
                            HttpCookie cookie = new HttpCookie(decl_UploadFileName);
                            cookie.Value = filename;
                            cookie.Expires = DateTime.Now.AddDays(-1);
                            HttpContext.Current.Response.Cookies.Add(cookie);
                        }
                        FileUpload1.SaveAs(path + filename);
                        res = true;
                        return res;
                    }
                    catch (Exception ex)
                    {
                        Manager.Alert(ex.Message);
                        //throw ex;
                        return res;
                    }

                }
            }
            return res;
        }
        #endregion

        #endregion

        #region TextBox

        #region TextBox绑定时间下拉菜单-Calendar.js
        /// <summary>
        /// TextBox绑定时间下拉菜单
        /// </summary>
        /// <param name="tb"></param>
        public static void Bind_DateTime(TextBox tb)
        {
            tb.Attributes["onfocus"] = "SelectDate(this)";
        }
        #endregion

        #region TextBox_Select
        public static void TextBox_Select(TextBox txt)
        {
            txt.Focus();
            txt.Attributes.Add("onfocus", "this.select()");
        }
        #endregion

        #endregion

        #region GridView


        #region GridView_RowColor
        /// <summary>
        /// 设置GridView的鼠标经过颜色
        /// </summary>
        /// <param name="e"></param>
        public static void GridView_RowColor(GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //e.Row.Attributes.Add("onclick", "this.style.backgroundColor='#FFFF66';");
                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#cbe9cf'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=''");
            }
        }
        #endregion

        #region GridView_Pageing_Add
        /// <summary>
        /// 分页:该方法须添加在数据绑定后和页面回传后
        /// </summary>
        /// <param name="gv"></param>
        /// <param name="this_page"></param>
        /// <param name="RecoderCount">信息总条数</param>
        /// /// <param name="show_page_text">显示根据输入框中的页数跳转的功能</param>
        public static void GridView_Pageing_Add(GridView gv, int recoder, bool show_page_text)
        {
            //当gridview只有一页的时候是否显示分页
            //if (recoder < gv.PageSize)
            //    return;
            if (recoder > 0)
            {
                try
                {
                    int PageSize = gv.PageSize;         //页面显示条数
                    int PageCount = gv.PageCount;       //总页数
                    int PageIndex = gv.PageIndex;       //当前第几页

                    LinkButton Frist = new LinkButton();
                    LinkButton Prev = new LinkButton();
                    LinkButton Next = new LinkButton();
                    LinkButton Last = new LinkButton();

                    Label lbl_Size = new Label();
                    lbl_Size.Text = PageSize.ToString();
                    lbl_Size.ForeColor = System.Drawing.Color.Red;
                    Label lbl_Count = new Label();
                    lbl_Count.Text = PageCount.ToString();
                    lbl_Count.ForeColor = System.Drawing.Color.Red;
                    Label lbl_Index = new Label();
                    lbl_Index.Text = (PageIndex + 1).ToString();
                    lbl_Index.ForeColor = System.Drawing.Color.Red;
                    Label lbl_Recoder = new Label();
                    lbl_Recoder.Text = recoder.ToString();
                    lbl_Recoder.ForeColor = System.Drawing.Color.Red;

                    GridViewRow Row = (GridViewRow)gv.BottomPagerRow;
                    if (Row == null)
                    {
                        Manager.Alert("找不到BottomPagerRow");
                        return;
                    }
                    if (Row.HasControls())
                    {
                        Row.Controls.Clear();
                    }

                    TableCell tc = new TableCell();
                    tc.Controls.Add(new LiteralControl("&nbsp;&nbsp;共"));
                    tc.Controls.Add(lbl_Recoder);
                    tc.Controls.Add(new LiteralControl("条记录&nbsp;&nbsp;共"));
                    tc.Controls.Add(lbl_Count);
                    tc.Controls.Add(new LiteralControl("页&nbsp;&nbsp;当前第"));
                    tc.Controls.Add(lbl_Index);
                    tc.Controls.Add(new LiteralControl("页&nbsp;&nbsp;每页"));
                    tc.Controls.Add(lbl_Size);
                    tc.Controls.Add(new LiteralControl("条记录&nbsp;&nbsp;"));

                    Frist.Text = "首页";
                    Frist.CommandName = "Page";
                    Frist.CommandArgument = "FirstZJ";
                    Frist.Font.Underline = false;

                    Prev.Text = "上一页";
                    Prev.ID = "Prve";
                    Prev.CommandName = "Page";
                    Prev.CommandArgument = "PrevZJ";
                    Prev.Font.Underline = false;

                    Next.Text = "下一页";
                    try
                    {
                        Next.Attributes["runat"] = "server";
                    }
                    catch (Exception eeee)
                    {
                        Common.JScript.Alert(eeee.Message);
                    }
                    Next.CommandName = "Page";
                    Next.CommandArgument = "NextZJ";
                    Next.Font.Underline = false;

                    Last.Text = "尾页";
                    Last.CommandName = "Page";
                    Last.CommandArgument = "LastZJ";
                    Last.Font.Underline = false;

                    if (PageIndex <= 0)
                    {
                        Frist.Enabled = false;
                        Prev.Enabled = false;
                    }

                    tc.Controls.Add(Frist);
                    tc.Controls.Add(new LiteralControl("&nbsp;&nbsp;"));
                    tc.Controls.Add(Prev);
                    tc.Controls.Add(new LiteralControl("&nbsp;&nbsp;"));

                    #region 跳转方式_以数字形式显示所有页
                    //for (int i = 0; i < PageCount; i++)
                    //{
                    //    if (i == PageIndex)
                    //    {
                    //        tc.Controls.Add(new LiteralControl(" <span style='color:red;font-weight:bold'>" + (i + 1).ToString() + " </span>"));

                    //    }
                    //    else
                    //    {
                    //        LinkButton lbBtn = new LinkButton();
                    //        lbBtn.Text = (i + 1).ToString();
                    //        lbBtn.CommandName = "Page";
                    //        lbBtn.CommandArgument = (i + 1).ToString();
                    //        lbBtn.Font.Underline = false;
                    //        tc.Controls.Add(lbBtn);
                    //    }
                    //    tc.Controls.Add(new LiteralControl("&nbsp;&nbsp;"));
                    //}
                    #endregion

                    if (PageIndex + 1 >= PageCount)
                    {
                        Next.Enabled = false;
                        Last.Enabled = false;
                    }

                    tc.Controls.Add(Next);
                    tc.Controls.Add(new LiteralControl("&nbsp;&nbsp;"));
                    tc.Controls.Add(Last);
                    tc.Controls.Add(new LiteralControl("&nbsp;&nbsp;"));


                    if (show_page_text)
                    {
                        TextBox txt_page = new TextBox();
                        txt_page.ID = "txt_page";
                        txt_page.Style.Add("width", "40px");
                        txt_page.Attributes.Add("onkeyup", "value=value.replace(/[^\\d]/g,'')");
                        if (!Row.Page.IsPostBack)
                        {
                            txt_page.Text = Convert.ToString(PageIndex + 1);
                        }
                        string client_txtid = txt_page.ClientID;

                        Button btn_page = new Button();
                        btn_page.ID = "btn_page";
                        btn_page.Text = "Go";
                        btn_page.CommandName = "Page";
                        btn_page.CommandArgument = "TextZJ";

                        tc.Controls.Add(new LiteralControl("&nbsp;&nbsp;"));
                        tc.Controls.Add(new LiteralControl("跳到第"));
                        tc.Controls.Add(txt_page);
                        tc.Controls.Add(new LiteralControl("页"));
                        tc.Controls.Add(new LiteralControl("&nbsp;&nbsp;"));
                        tc.Controls.Add(btn_page);
                        tc.Attributes["colspan"] = gv.Rows[0].Cells.Count.ToString();
                    }


                    Row.Controls.Add(tc);
                }
                catch (Exception e)
                {
                    Common.JScript.Alert("添加分页代码出错 原因:" + e.Message);
                }
            }
        }

        #endregion

        #region GridView_Pageing_Add
        /// <summary>
        /// 分页:该方法须添加在数据绑定后和页面回传后
        /// </summary>
        /// <param name="gv"></param>
        /// <param name="this_page"></param>
        /// <param name="show_page_text">显示根据输入框中的页数跳转的功能</param>
        public static void GridView_Pageing_Add(GridView gv, bool show_page_text)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["Pageing"];
            int recoder = 0;
            if (gv.DataSource == null && cookie == null)
                return;
            if (gv.DataSource != null)
            {
                Type type = gv.DataSource.GetType();
                if (!type.IsGenericType)
                {
                    return;
                }

                IList list = gv.DataSource as IList;
                if (list == null)
                {
                    return;
                }
                else
                {
                    recoder = list.Count;
                    cookie = new HttpCookie("Pageing");
                    cookie.Value = recoder.ToString();
                    HttpContext.Current.Response.Cookies.Add(cookie);
                }
            }
            else
            {
                if (!int.TryParse(cookie.Value, out recoder))
                {
                    return;
                }
            }
            if (recoder > 0)
            {
                try
                {
                    int PageSize = gv.PageSize;         //页面显示条数
                    int PageCount = gv.PageCount;       //总页数
                    int PageIndex = gv.PageIndex;       //当前第几页

                    LinkButton Frist = new LinkButton();
                    LinkButton Prev = new LinkButton();
                    LinkButton Next = new LinkButton();
                    LinkButton Last = new LinkButton();

                    Label lbl_Size = new Label();
                    lbl_Size.Text = PageSize.ToString();
                    lbl_Size.ForeColor = System.Drawing.Color.Red;
                    Label lbl_Count = new Label();
                    lbl_Count.Text = PageCount.ToString();
                    lbl_Count.ForeColor = System.Drawing.Color.Red;
                    Label lbl_Index = new Label();
                    lbl_Index.Text = (PageIndex + 1).ToString();
                    lbl_Index.ForeColor = System.Drawing.Color.Red;
                    Label lbl_Recoder = new Label();
                    lbl_Recoder.Text = recoder.ToString();
                    lbl_Recoder.ForeColor = System.Drawing.Color.Red;

                    GridViewRow Row = (GridViewRow)gv.BottomPagerRow;

                    if (Row == null)
                    {
                        Manager.Alert("找不到BottomPagerRow");
                        return;
                    }

                    if (Row.HasControls())
                    {
                        Row.Controls.Clear();
                    }

                    TableCell tc = new TableCell();
                    tc.Controls.Add(new LiteralControl("&nbsp;&nbsp;共"));
                    tc.Controls.Add(lbl_Recoder);
                    tc.Controls.Add(new LiteralControl("条记录&nbsp;&nbsp;共"));
                    tc.Controls.Add(lbl_Count);
                    tc.Controls.Add(new LiteralControl("页&nbsp;&nbsp;当前第"));
                    tc.Controls.Add(lbl_Index);
                    tc.Controls.Add(new LiteralControl("页&nbsp;&nbsp;每页"));
                    tc.Controls.Add(lbl_Size);
                    tc.Controls.Add(new LiteralControl("条记录&nbsp;&nbsp;"));

                    Frist.Text = "首页";
                    Frist.CommandName = "Page";
                    Frist.CommandArgument = "FirstZJ";
                    Frist.Font.Underline = false;

                    Prev.Text = "上一页";
                    Prev.ID = "Prve";
                    Prev.CommandName = "Page";
                    Prev.CommandArgument = "PrevZJ";
                    Prev.Font.Underline = false;

                    Next.Text = "下一页";
                    try
                    {
                        Next.Attributes["runat"] = "server";
                    }
                    catch (Exception eeee)
                    {
                        Common.JScript.Alert(eeee.Message);
                    }
                    Next.CommandName = "Page";
                    Next.CommandArgument = "NextZJ";
                    Next.Font.Underline = false;

                    Last.Text = "尾页";
                    Last.CommandName = "Page";
                    Last.CommandArgument = "LastZJ";
                    Last.Font.Underline = false;

                    if (PageIndex <= 0)
                    {
                        Frist.Enabled = false;
                        Prev.Enabled = false;
                    }

                    tc.Controls.Add(Frist);
                    tc.Controls.Add(new LiteralControl("&nbsp;&nbsp;"));
                    tc.Controls.Add(Prev);
                    tc.Controls.Add(new LiteralControl("&nbsp;&nbsp;"));

                    #region 跳转方式_以数字形式显示所有页
                    //for (int i = 0; i < PageCount; i++)
                    //{
                    //    if (i == PageIndex)
                    //    {
                    //        tc.Controls.Add(new LiteralControl(" <span style='color:red;font-weight:bold'>" + (i + 1).ToString() + " </span>"));

                    //    }
                    //    else
                    //    {
                    //        LinkButton lbBtn = new LinkButton();
                    //        lbBtn.Text = (i + 1).ToString();
                    //        lbBtn.CommandName = "Page";
                    //        lbBtn.CommandArgument = (i + 1).ToString();
                    //        lbBtn.Font.Underline = false;
                    //        tc.Controls.Add(lbBtn);
                    //    }
                    //    tc.Controls.Add(new LiteralControl("&nbsp;&nbsp;"));
                    //}
                    #endregion

                    if (PageIndex + 1 >= PageCount)
                    {
                        Next.Enabled = false;
                        Last.Enabled = false;
                    }

                    tc.Controls.Add(Next);
                    tc.Controls.Add(new LiteralControl("&nbsp;&nbsp;"));
                    tc.Controls.Add(Last);
                    tc.Controls.Add(new LiteralControl("&nbsp;&nbsp;"));


                    if (show_page_text)
                    {
                        TextBox txt_page = new TextBox();
                        txt_page.ID = "txt_page";
                        txt_page.Style.Add("width", "40px");
                        txt_page.Attributes.Add("onkeyup", "value=value.replace(/[^\\d]/g,'')");
                        if (!Row.Page.IsPostBack)
                        {
                            txt_page.Text = Convert.ToString(PageIndex + 1);
                        }
                        string client_txtid = txt_page.ClientID;

                        Button btn_page = new Button();
                        btn_page.ID = "btn_page";
                        btn_page.Text = "Go";
                        btn_page.CommandName = "Page";
                        btn_page.CommandArgument = "TextZJ";

                        tc.Controls.Add(new LiteralControl("&nbsp;&nbsp;"));
                        tc.Controls.Add(new LiteralControl("跳到第"));
                        tc.Controls.Add(txt_page);
                        tc.Controls.Add(new LiteralControl("页"));
                        tc.Controls.Add(new LiteralControl("&nbsp;&nbsp;"));
                        tc.Controls.Add(btn_page);
                        tc.Attributes["colspan"] = gv.Rows[0].Cells.Count.ToString();
                    }
                    Row.Controls.Add(tc);
                }
                catch (Exception e)
                {
                    Common.JScript.Alert("添加分页代码出错 原因:" + e.Message);
                }
            }
        }

        #endregion

        #region GridView_Pageing_Add
        public static void GridView_Pageing_Add(GridView gv)
        {
            GridView_Pageing_Add(gv, false);
        }
        #endregion

        #region GridView_Pageing_RowCommand
        /// <summary>
        /// 设置按钮事件
        /// </summary>
        /// <param name="gv"></param>
        /// <param name="e"></param>
        public static void GridView_Pageing_RowCommand(GridView gv, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Page")
            {
                int page_now = gv.PageIndex;
                int page_count = gv.PageCount;
                int to_page = 0;
                switch (e.CommandArgument.ToString())
                {
                    case "FirstZJ":
                        href(to_page.ToString());
                        break;
                    case "PrevZJ":
                        to_page = page_now - 1;
                        href(to_page.ToString());
                        break;
                    case "NextZJ":
                        to_page = page_now + 1;
                        href(to_page.ToString());
                        break;
                    case "LastZJ":
                        to_page = gv.PageCount - 1;
                        href(to_page.ToString());
                        break;
                    case "TextZJ":
                        try
                        {
                            int pageIndex = 0;
                            if (!int.TryParse(((gv.BottomPagerRow.FindControl("txt_page") as TextBox).Text), out pageIndex) || pageIndex == 0)
                            {
                                href(gv.PageIndex.ToString());
                                break;
                            }
                            if (page_count < pageIndex)
                            {
                                href((gv.PageCount - 1).ToString());
                                break;
                            }
                            else
                            {
                                to_page = pageIndex - 1;
                                href(to_page.ToString());
                                break;
                            }
                        }
                        catch (Exception ex)
                        {
                            Common.JScript.Alert("操作失误 原因:" + ex.Message);
                        }
                        break;
                }

            }
        }
        #endregion

        #region GridView_PageChange
        /// <summary>
        /// URL分页:设置GridView要显示的页数.该方法用于GridView绑定之前
        /// </summary>
        /// <param name="gv"></param>
        public static void GridView_PageChange(GridView gv)
        {
            if (!gv.Page.IsPostBack)
            {
                string temp = System.Web.HttpContext.Current.Request["page"];
                if (!string.IsNullOrEmpty(temp))
                {
                    int page = 0;
                    if (int.TryParse(temp, out page))
                        gv.PageIndex = Convert.ToInt32(page);
                }
            }
        }
        #endregion

        #region GridView_BindPageIndex
        /// <summary>
        /// 绑定GridView的时候在执行DataSource之前执行的绑定页面的方法
        /// </summary>
        /// <param name="GridView1"></param>
        public static void GridView_BindPageIndex(GridView GridView1)
        {
            string page = HttpContext.Current.Request["page"];
            int pageIndex = 0;
            if (int.TryParse(page, out pageIndex))
            {
                GridView1.PageIndex = pageIndex;
            }
        }
        #endregion

        #region GridView_Pageing_Add
        /// <summary>
        /// 分页:该方法须添加在数据绑定后和页面回传后
        /// </summary>
        /// <param name="gv"></param>
        /// <param name="this_page"></param>
        /// <param name="show_page_text">显示根据输入框中的页数跳转的功能</param>
        public static void GridView_Pageing_Add(GridView gv, bool show_page_text, int site)
        {



            HttpCookie cookie = HttpContext.Current.Request.Cookies["Pageing"];
            int recoder = 0;
            if (gv.DataSource == null && cookie == null)
                return;
            if (gv.DataSource != null)
            {
                //Type type = gv.DataSource.GetType();
                //if (!type.IsGenericType)
                //{
                //    return;
                //}

                IList list = gv.DataSource as IList;
                if (list == null)
                {
                    return;
                }
                else
                {
                    recoder = list.Count;
                    cookie = new HttpCookie("Pageing");
                    cookie.Value = recoder.ToString();
                    HttpContext.Current.Response.Cookies.Add(cookie);
                }
            }
            else
            {
                if (!int.TryParse(cookie.Value, out recoder))
                {
                    return;
                }
            }
            if (recoder > 0)
            {
                try
                {
                    int PageSize = gv.PageSize;         //页面显示条数
                    int PageCount = gv.PageCount;       //总页数
                    int PageIndex = gv.PageIndex;       //当前第几页

                    LinkButton Frist = new LinkButton();
                    LinkButton Prev = new LinkButton();
                    LinkButton Next = new LinkButton();
                    LinkButton Last = new LinkButton();

                    Label lbl_Size = new Label();
                    lbl_Size.Text = PageSize.ToString();
                    lbl_Size.ForeColor = System.Drawing.Color.Red;
                    Label lbl_Count = new Label();
                    lbl_Count.Text = PageCount.ToString();
                    lbl_Count.ForeColor = System.Drawing.Color.Red;
                    Label lbl_Index = new Label();
                    lbl_Index.Text = (PageIndex + 1).ToString();
                    lbl_Index.ForeColor = System.Drawing.Color.Red;
                    Label lbl_Recoder = new Label();
                    lbl_Recoder.Text = recoder.ToString();
                    lbl_Recoder.ForeColor = System.Drawing.Color.Red;

                    GridViewRow Row = (GridViewRow)gv.BottomPagerRow;

                    if (Row == null)
                    {
                        Manager.Alert("找不到BottomPagerRow");
                        return;
                    }

                    if (Row.HasControls())
                    {
                        Row.Controls.Clear();
                    }

                    TableCell tc = new TableCell();
                    tc.Controls.Add(new LiteralControl("&nbsp;&nbsp;共"));
                    tc.Controls.Add(lbl_Recoder);
                    tc.Controls.Add(new LiteralControl("条记录&nbsp;&nbsp;共"));
                    tc.Controls.Add(lbl_Count);
                    tc.Controls.Add(new LiteralControl("页&nbsp;&nbsp;当前第"));
                    tc.Controls.Add(lbl_Index);
                    tc.Controls.Add(new LiteralControl("页&nbsp;&nbsp;每页"));
                    tc.Controls.Add(lbl_Size);
                    tc.Controls.Add(new LiteralControl("条记录&nbsp;&nbsp;"));

                    Frist.Text = "首页";
                    Frist.CommandName = "Page";
                    Frist.CommandArgument = "FirstZJ";
                    Frist.Font.Underline = false;

                    Prev.Text = "上一页";
                    Prev.ID = "Prve";
                    Prev.CommandName = "Page";
                    Prev.CommandArgument = "PrevZJ";
                    Prev.Font.Underline = false;

                    Next.Text = "下一页";
                    try
                    {
                        Next.Attributes["runat"] = "server";
                    }
                    catch (Exception eeee)
                    {
                        Common.JScript.Alert(eeee.Message);
                    }
                    Next.CommandName = "Page";
                    Next.CommandArgument = "NextZJ";
                    Next.Font.Underline = false;

                    Last.Text = "尾页";
                    Last.CommandName = "Page";
                    Last.CommandArgument = "LastZJ";
                    Last.Font.Underline = false;

                    if (PageIndex <= 0)
                    {
                        Frist.Enabled = false;
                        Prev.Enabled = false;
                    }

                    tc.Controls.Add(Frist);
                    tc.Controls.Add(new LiteralControl("&nbsp;&nbsp;"));
                    tc.Controls.Add(Prev);
                    tc.Controls.Add(new LiteralControl("&nbsp;&nbsp;"));

                    #region 跳转方式_以数字形式显示所有页
                    //for (int i = 0; i < PageCount; i++)
                    //{
                    //    if (i == PageIndex)
                    //    {
                    //        tc.Controls.Add(new LiteralControl(" <span style='color:red;font-weight:bold'>" + (i + 1).ToString() + " </span>"));

                    //    }
                    //    else
                    //    {
                    //        LinkButton lbBtn = new LinkButton();
                    //        lbBtn.Text = (i + 1).ToString();
                    //        lbBtn.CommandName = "Page";
                    //        lbBtn.CommandArgument = (i + 1).ToString();
                    //        lbBtn.Font.Underline = false;
                    //        tc.Controls.Add(lbBtn);
                    //    }
                    //    tc.Controls.Add(new LiteralControl("&nbsp;&nbsp;"));
                    //}
                    #endregion

                    if (PageIndex + 1 >= PageCount)
                    {
                        Next.Enabled = false;
                        Last.Enabled = false;
                    }

                    tc.Controls.Add(Next);
                    tc.Controls.Add(new LiteralControl("&nbsp;&nbsp;"));
                    tc.Controls.Add(Last);
                    tc.Controls.Add(new LiteralControl("&nbsp;&nbsp;"));


                    if (show_page_text)
                    {
                        TextBox txt_page = new TextBox();
                        txt_page.ID = "txt_page";
                        txt_page.Style.Add("width", "40px");
                        txt_page.Attributes.Add("onkeyup", "value=value.replace(/[^\\d]/g,'')");
                        if (!Row.Page.IsPostBack)
                        {
                            txt_page.Text = Convert.ToString(PageIndex + 1);
                        }
                        string client_txtid = txt_page.ClientID;

                        Button btn_page = new Button();
                        btn_page.ID = "btn_page";
                        btn_page.Text = "Go";
                        btn_page.CommandName = "Page";
                        btn_page.CommandArgument = "TextZJ";

                        tc.Controls.Add(new LiteralControl("&nbsp;&nbsp;"));
                        tc.Controls.Add(new LiteralControl("跳到第"));
                        tc.Controls.Add(txt_page);
                        tc.Controls.Add(new LiteralControl("页"));
                        tc.Controls.Add(new LiteralControl("&nbsp;&nbsp;"));
                        tc.Controls.Add(btn_page);
                    }
                    //Row.Cells[0].Attributes["colspan"] = gv.Rows[1].Cells.Count.ToString();
                    string align = string.Empty;
                    if (site == 1)
                        align = "left";
                    else if (site == 2)
                        align = "center";
                    else
                        align = "right";
                    tc.Attributes["colspan"] = gv.Rows[0].Cells.Count.ToString();
                    tc.Attributes["align"] = align;
                    Row.Controls.Add(tc);
                }
                catch (Exception e)
                {
                    Common.JScript.Alert("添加分页代码出错 原因:" + e.Message);
                }
            }
        }

        #endregion

        #region href
        /// <summary>
        /// url分页:根据参数跳转
        /// </summary>
        /// <param name="page"></param>
        public static void href(string page)
        {
            string url = System.Web.HttpContext.Current.Request.Url.ToString();
            url = BuildUrl(url, "page", page);
            page_redirect(url);
        }
        #endregion

        #region Href_Add
        /// <summary>
        /// 添加URL参数
        /// </summary>
        /// <param name="page"></param>
        public static void Href_Add(string name, string value)
        {
            string url = System.Web.HttpContext.Current.Request.Url.ToString();
            url = BuildUrl(url, name, value);
            page_href(url);
        }

        /// <summary>
        /// 添加URL参数
        /// </summary>
        /// <param name="page"></param>
        public static void Href_Add(string name, string value, Page page)
        {
            string url = System.Web.HttpContext.Current.Request.Url.ToString();
            url = BuildUrl(url, name, value);
            page_href(url, page);
        }
        #endregion

        #region Href_Minus
        /// <summary>
        /// 减去URL参数
        /// </summary>
        /// <param name="page"></param>
        public static void Href_Minus(string name, Page page)
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
            page_href(url, page);
        }
        #endregion

        #region BuildUrl
        //url里有key的值，就替换为value,没有的话就追加.
        public static string BuildUrl(string url, string ParamText, string ParamValue)
        {
            Regex reg = new Regex(string.Format("{0}=[^&]*", ParamText), RegexOptions.IgnoreCase);
            Regex reg1 = new Regex("[&]{2,}", RegexOptions.IgnoreCase);
            string _url = reg.Replace(url, "");
            //_url = reg1.Replace(_url, "");
            if (_url.IndexOf("?") == -1)
                _url += string.Format("?{0}={1}", ParamText, ParamValue);//?
            else
                _url += string.Format("&{0}={1}", ParamText, ParamValue);//&
            _url = reg1.Replace(_url, "&");
            _url = _url.Replace("?&", "?");
            return _url;
        }
        #endregion

        #region GridView_Edit
        /// <summary>
        /// URL分页:设置GridView要编辑的行.该方法用于GridView绑定之前
        /// </summary>
        /// <param name="gv"></param>
        public static void GridView_Edit(GridView gv)
        {
            string temp = System.Web.HttpContext.Current.Request[decl_EditIndex];
            if (!string.IsNullOrEmpty(temp))
            {
                int edit = 0;
                if (int.TryParse(temp, out edit))
                    gv.EditIndex = edit;
            }
        }
        #endregion

        #region GridView_ondblclick
        /// <summary>
        /// GirdView绑定双击行事件
        /// </summary>
        /// <param name="e">GridViewRowEventArgs</param>
        /// <param name="js">javascript代码</param>
        public static void GridView_ondblclick(GridViewRowEventArgs e, string js)
        {
            e.Row.Attributes.Add("ondblclick", js);
        }
        #endregion

        #region GridView行双击进入编辑状态方法

        #region GridView_ondblclick
        /// <summary>
        /// GirdView绑定双击行事件(双击执行GridView1_RowEditing事件)(URL)
        /// </summary>
        /// <param name="e">GridViewRowEventArgs</param>
        /// <param name="js">javascript代码</param>
        public static void GridView_ondblclick(GridViewRowEventArgs e)
        {
            string url = BuildUrl(System.Web.HttpContext.Current.Request.Url.ToString(), decl_eindex, e.Row.RowIndex.ToString());
            e.Row.Attributes.Add("ondblclick", "window.location.href='" + url + "'");
        }
        #endregion

        #region GridView_ondblclick_Bind
        /// <summary>
        /// GridView绑定编辑行(URL)
        /// </summary>
        /// <param name="gv1"></param>
        public static void GridView_ondblclick_Bind(GridView gv1)
        {
            string temp = System.Web.HttpContext.Current.Request[decl_eindex];
            if (!string.IsNullOrEmpty(temp) && Manager.IsNumeric(temp))
            {
                gv1.EditIndex = Convert.ToInt32(temp);
            }
        }
        #endregion

        #region GridView_ondblclick_Cancel
        /// <summary>
        /// GirdView取消编辑行(URL)
        /// </summary>
        /// <param name="page">Page</param>
        public static void GridView_ondblclick_Cancel(Page page)
        {
            string temp = System.Web.HttpContext.Current.Request[decl_eindex];
            if (!string.IsNullOrEmpty(temp))
            {
                Manager.Href_Minus(Manager.decl_eindex, page);
            }
        }
        #endregion

        #endregion

        #endregion


        #endregion

        #region 字符串处理

        #region  去除HTML标记
        /**/
        ///   <summary>
        ///   去除HTML标记
        ///   </summary>
        ///   <param   name="NoHTML">包括HTML的源码   </param>
        ///   <returns>已经去除后的文字</returns>
        public static string NoHTML(string Htmlstring)
        {
            //删除脚本
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "",
              RegexOptions.IgnoreCase);
            //删除HTML
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", "   ",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "",
              RegexOptions.IgnoreCase);

            Htmlstring.Replace("<", "");
            Htmlstring.Replace(">", "");
            Htmlstring.Replace("\r\n", "");
            Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();

            return Htmlstring;
        }


        ///移除HTML标签
        /**/
        ///   <summary>
        ///   移除HTML标签
        ///   </summary>
        ///   <param   name="HTMLStr">HTMLStr</param>
        public static string NoHTML2(string HTMLStr)
        {
            return System.Text.RegularExpressions.Regex.Replace(HTMLStr, "<[^>]*>", "");
        }






        #endregion

        #region 取出文本中的图片地址
        ///   <summary>
        ///   取出文本中的图片地址
        ///   </summary>
        ///   <param   name="HTMLStr">HTMLStr</param>
        public static string GetImgUrl(string HTMLStr)
        {
            string str = string.Empty;
            string sPattern = @"^<img\s+[^>]*>";
            Regex r = new Regex(@"<img\s+[^>]*\s*src\s*=\s*([']?)(?<url>\S+)'?[^>]*>",
              RegexOptions.Compiled);
            Match m = r.Match(HTMLStr.ToLower());
            if (m.Success)
                str = m.Result("${url}");
            return str;
        }

        #endregion

        #region 截取字符串
        public static string Substring(string str, int num)
        {
            str = str.Length > num ? str.Substring(0, (num - 1)) : str;
            return str;
        }
        #endregion

        #region 添加HTTP://字符串
        public static string AddString_Http(string str)
        {
            str = str.ToLower();
            if (str.IndexOf("http://") < 0)
            {
                str = "http://" + str;
            }
            return str;
        }
        #endregion
        #endregion

        #region JavaScript

        #region Alert
        public static void Alert(string message)
        {
            JScript.Alert(message);
        }
        public static void Alert()
        {
            Alert("操作失败,请稍后再试");
        }
        public static void Alert(string message, System.Web.UI.Page page)
        {
            Common.JScript.Alert(message, page);
        }
        // ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "click", "alert('删除成功')", true);

        #region AlertByRes

        public static void AlertByRes(int res, string message)
        {
            if (res == 1)
            {
                Alert(message);
            }
            else
            {
                Alert();
            }
        }

        #endregion

        #endregion

        #region ResponseJS

        public static void ResponseJS(string msg)
        {
            System.Web.HttpContext.Current.Response.Write("<script>" + msg + "</script>");
        }

        #endregion

        #region OnKeyDown13
        public static void OnKeyDown13(TextBox txt, string ButtonID, Page page)
        {
            txt.Attributes.Add("onkeydown", "if(event.which || event.keyCode){   if ((event.which == 13) || (event.keyCode == 13)) {   document.getElementById('" + ButtonID + "').click();return false;}}    else {return true}; ");
            page.Form.DefaultButton = ButtonID;
        }
        #endregion

        #region SubStr
        public string SubStr(string sString, int nLeng)
        {
            if (sString.Length <= nLeng)
            {
                return sString;
            }
            string sNewStr = sString.Substring(0, nLeng);
            sNewStr = sNewStr + "...";
            return sNewStr;
        }
        #endregion

        #region GetShowModal

        /// <summary>
        /// 返回弹出窗口
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string GetShowModal(string url, string width, string height)
        {
            string s = "showModal('" + url + "'," + width + "," + height + ");return false;";
            return s;
        }

        #endregion

        #region GetShowModal_No_Return

        /// <summary>
        /// 返回弹出窗口 没有返回false
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string GetShowModal_No_Return(string url, string width, string height)
        {
            string s = "showModal('" + url + "'," + width + "," + height + ");";
            return s;
        }

        #endregion

        #region page

        #region page_redirect
        public static void page_redirect()
        {
            System.Web.HttpContext.Current.Response.Redirect(System.Web.HttpContext.Current.Request.Url.AbsolutePath);
        }
        #endregion

        #region page_redirect
        public static void page_redirect(string url)
        {
            System.Web.HttpContext.Current.Response.Redirect(url);
        }
        #endregion

        #region page_reload
        public static void page_reload()
        {
            ResponseJS("window.location.reload();");
        }
        #endregion

        #region page_redirect_reload
        public static void page_redirect_reload()
        {
            string url = System.Web.HttpContext.Current.Request.Url.ToString();
            System.Web.HttpContext.Current.Response.Redirect(url);
        }
        #endregion

        #region page_href_reload
        public static void page_href_reload()
        {
            string url = System.Web.HttpContext.Current.Request.Url.ToString();
            ResponseJS("window.location.href='" + url + "'");
        }
        public static void page_href_reload(System.Web.UI.Page page)
        {
            string url = System.Web.HttpContext.Current.Request.Url.ToString();
            Common.JScript.JavaScriptLocationHref(url, page);
        }
        #endregion

        #region page_href
        public static void page_href(string url)
        {
            ResponseJS("window.location.href='" + url + "'");
        }
        public static void page_href(string url, System.Web.UI.Page page)
        {
            Common.JScript.JavaScriptLocationHref(url, page);
        }
        #endregion



        #endregion

        #region FileUpload绑定选择后预览图片
        /// <summary>
        /// 绑定即时预览的方法
        /// </summary>
        /// <param name="fu">FileUpload控件</param>
        /// <param name="div_id">图片容器元素ID</param>
        /// <param name="img_id1">原始图片ID</param>
        /// <param name="img_id2">设置预览图片ID,ID随意设置,不同即可</param>
        /// <param name="width">图片最大宽度,为0则默认300</param>
        /// <param name="height">图片最大高度,为0则默认200</param>
        public static void Bind_UpImg(FileUpload fu, string div_id, Image img, string img_id2, int width, int height)
        {
            width = width == 0 ? 300 : width;
            height = height == 0 ? 200 : height;
            img.Attributes["onload"] = "setImgSize('" + img.ClientID + "'," + width.ToString() + "," + height.ToString() + ")";
            fu.Attributes["onchange"] = "previewImg('" + div_id + "','" + img.ClientID + "','" + img_id2 + "'," + width.ToString() + "," + height.ToString() + ")";
        }
        #endregion


        #region 图片比例缩小
        /// <summary>
        /// 绑定即时预览的方法
        /// </summary>
        /// <param name="fu"></param>
        /// <param name="img"></param>
        /// <param name="width">图片最大宽度</param>
        /// <param name="height">图片最大高度</param>
        public static void Bind_UpImg(Image img, int width, int height)
        {
            img.Attributes["onload"] = "javascript:DrawImage(this," + width.ToString() + "," + height.ToString() + ");";
        }
        #endregion







        #endregion

        #region 浏览记录


        #region GetHistory
        /// <summary>
        /// 获取浏览记录
        /// </summary>
        /// <returns>list</returns>
        //public static List<int> GetHistory()
        //{
        //    List<int> list = new List<int>();
        //    HttpCookie cookie = HttpContext.Current.Request.Cookies[Manager.Person != null ? decl_history_company : decl_history_company];
        //    if (cookie == null)
        //    {
        //        return list;
        //    }
        //    string[] strs = cookie.Value.Split(new char[] { '-' });
        //    int temp = 0;
        //    foreach (string str in strs)
        //    {
        //        if (int.TryParse(str, out temp))
        //        {
        //            list.Add(temp);
        //        }
        //    }
        //    return list;
        //}
        #endregion

        #region SetHistroy

        /// <summary>
        /// 设置浏览记录
        /// </summary>
        /// <param name="id"></param>
        public static void SetHistroy(int id)
        {
            try
            {
                //HttpCookie cookie = HttpContext.Current.Request.Cookies[Manager.Person != null ? decl_history_company : decl_history_company];
                //if (cookie == null)
                //{
                //    cookie = new HttpCookie(Manager.Person != null ? decl_history_company : decl_history_company);
                //    cookie.Value = id.ToString();
                //}
                //else
                //{
                //    string[] strs = cookie.Value.Split(new char[] { '-' });
                //    string res = id.ToString();
                //    bool ishas = false;
                //    for (int i = 0; i <= 8; i++)
                //    {
                //        try
                //        {
                //            //如果有改浏览记录则置顶
                //            if (strs[i] == res)
                //            {
                //                ishas = true;
                //            }
                //            if (ishas)
                //                res += "-" + strs[i + 1];
                //            else
                //                res += "-" + strs[i];
                //        }
                //        catch { }
                //    }
                //    cookie.Value = res;
                //}
                //cookie.Expires = DateTime.Now.AddDays(10);
                //HttpContext.Current.Response.Cookies.Add(cookie);
            }
            catch { }
        }
        #endregion


        #endregion

        #region copy
        public static void copy(string txt, System.Web.UI.Page page)
        {
            string js = "<Script language='JavaScript'>window.clipboardData.setData('text','" + txt + "');</Script>";
            if (!page.ClientScript.IsStartupScriptRegistered(page.GetType(), "copy"))
            {
                page.ClientScript.RegisterStartupScript(page.GetType(), "copy", js);
            }
        }

        #endregion

        #region 确认

        #region IsNumeric
        /// <summary>
        /// 查看是否为Int型
        /// </summary>
        /// <param name="str_int"></param>
        /// <returns></returns>
        public static bool IsNumeric(string str_int)
        {
            bool Res = false;
            int i;
            if (int.TryParse(str_int, out i))
            {
                Res = true;
            }
            return Res;
        }
        #endregion

        #region IsDecimal
        /// <summary>
        /// 查看是否为Int型
        /// </summary>
        /// <param name="str_int"></param>
        /// <returns></returns>
        public static bool IsDecimal(string str_Decimal)
        {
            bool Res = false;
            Decimal deci = new Decimal();
            if (Decimal.TryParse(str_Decimal, out deci))
            {
                Res = true;
            }
            return Res;
        }
        #endregion

        #region IsDateTime
        /// <summary>
        /// 查看是否为DateTime型
        /// </summary>
        /// <param name="str_date"></param>
        /// <returns></returns>
        public static bool IsDateTime(string str_date)
        {
            bool Res = false;
            DateTime date = new DateTime();
            if (DateTime.TryParse(str_date, out date))
            {
                Res = true;
            }
            return Res;
        }
        #endregion

        #region confirm_longth
        /// <summary>
        /// 判断字符串是否符合长度
        /// </summary>
        /// <param name="str">要判断的字符串</param>
        /// <param name="longth">长度</param>
        /// <returns>bool</returns>
        public static bool confirm_longth(string str, int longth)
        {
            bool res = false;
            int temp = str.Length;
            if (temp < longth)
                res = true;
            return res;
        }
        #endregion

        #region confirm
        /// <summary>
        /// 弹出confirm窗口
        /// </summary>
        /// <param name="mess">提示信息</param>
        /// <returns></returns>
        public static string confirm(string mess)
        {
            return "return confirm('" + mess + "');";
        }
        #endregion

        #endregion

        #region 下载文件FileDownload
        /// <summary>
        /// 下载代码
        /// </summary>
        /// <param name="FileName"></param>
        public static void FileDownload(string FileName, string name, shuadan_record sr)
        {
            String FullFileName = System.Web.HttpContext.Current.Server.MapPath(FileName);

            //记录下载
            if (sr.srid == 0)
            {
                BLL.shuadan_recordManager.Insert(sr);
            }
            else
            {
                BLL.shuadan_recordManager.Update(sr);
            }

            FileInfo DownloadFile = new FileInfo(FullFileName);
            System.Web.HttpContext.Current.Response.Clear();
            System.Web.HttpContext.Current.Response.ClearHeaders();
            System.Web.HttpContext.Current.Response.Buffer = false;
            System.Web.HttpContext.Current.Response.ContentType = "application/octet-stream";
            System.Web.HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=" + name);
            System.Web.HttpContext.Current.Response.AppendHeader("Content-Length", DownloadFile.Length.ToString());
            System.Web.HttpContext.Current.Response.WriteFile(DownloadFile.FullName);
            System.Web.HttpContext.Current.Response.Flush();
            System.Web.HttpContext.Current.Response.End();
        }
        #endregion

        #region GetCheckBoxName
        /// <summary>
        /// 获取页面多选的ID
        /// </summary>
        /// <param name="page"></param>
        /// <returns>ID数组</returns>
        public static string[] GetCheckBoxName(Page page)
        {
            string[] temp_id = null;
            string temp_ckname = page.Request.Form.Get("checkboxname");
            if (!string.IsNullOrEmpty(temp_ckname))
            {
                temp_id = temp_ckname.Split(new char[] { ',' });
            }
            return temp_id;
        }
        #endregion

        #region EnCodeCovert
        /// <summary>
        /// 首选编码的代码页名称
        /// </summary>
        /// <param name="srcName">原编码格式</param>
        /// <param name="convToName">要转换成的编码格式</param>
        /// <param name="value">需要转换的字符串</param>
        /// <returns>返回转换后的字符串</returns>
        public static string EnCodeCovert(string srcName, string convToName, string value)
        {
            System.Text.Encoding srcEncode = System.Text.Encoding.GetEncoding(srcName);
            System.Text.Encoding convToEncode = System.Text.Encoding.GetEncoding(convToName);
            byte[] bytes = srcEncode.GetBytes(value);
            System.Text.Encoding.Convert(srcEncode, convToEncode, bytes, 0, bytes.Length);
            return convToEncode.GetString(bytes);
        }
        #endregion

        #region RandomNumber
        /// <summary>
        /// 获取随机数
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static int RandomNumber(int min, int max)
        {
            lock (syncLock)
            { // synchronize
                return random.Next(min, max);
            }
        }
        #endregion


        #region DateDiff_GetInt
        /// <summary>
        /// 时间差
        /// </summary>
        /// <param name="DateTime1"></param>
        /// <param name="DateTime2"></param>
        /// <returns></returns>
        public static int DateDiff_GetInt(DateTime DateTime1, DateTime DateTime2)
        {
            //string dateDiff = null;
            TimeSpan ts1 = new TimeSpan(DateTime1.Ticks);
            TimeSpan ts2 = new TimeSpan(DateTime2.Ticks);
            TimeSpan ts = ts1.Subtract(ts2).Duration();
            //dateDiff = ts.Days.ToString() + "天" + ts.Hours.ToString() + "小时" + ts.Minutes.ToString() + "分钟" + ts.Seconds.ToString() + "秒";
            return ts.Days;
            #region note
            //C#中使用TimeSpan计算两个时间的差值
            //可以反加两个日期之间任何一个时间单位。
            //TimeSpan ts = Date1 - Date2;
            //double dDays = ts.TotalDays;//带小数的天数，比如1天12小时结果就是1.5 
            //int nDays = ts.Days;//整数天数，1天12小时或者1天20小时结果都是1  
            #endregion
        }
        #endregion
    }
}
