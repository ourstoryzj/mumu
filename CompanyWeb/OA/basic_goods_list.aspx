<%@ Page Language="C#" AutoEventWireup="true" CodeFile="basic_goods_list.aspx.cs"
    Inherits="OA_basic_goods_list" ValidateRequest="false" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="control/loading.ascx" TagName="loading" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="js/Calendar.js" type="text/javascript"></script>
    <script src="js/jquery-1.4.3.min.js" type="text/javascript"></script>
    <script src="js/JScript.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="content">
                <div class="c_title">
                    <div class="c_t_name">
                        ● 商品管理</div>
                    <div class="c_t_desc">
                        <ul>
                            <%--<li>搜索：</li>--%>
                            <li>上架开始时间
                                <asp:TextBox ID="txt_date1" runat="server" Width="70"></asp:TextBox>
                            </li>
                            <li>上架结束时间
                                <asp:TextBox ID="txt_date2" runat="server" Width="70"></asp:TextBox>
                            </li>
                            <li>录入开始时间
                                <asp:TextBox ID="txt_date3" runat="server" Width="70"></asp:TextBox>
                            </li>
                            <li>录入结束时间
                                <asp:TextBox ID="txt_date4" runat="server" Width="70"></asp:TextBox>
                            </li>
                            <li>店铺
                                <asp:DropDownList ID="ddl_dianpu" runat="server" Width="60">
                                </asp:DropDownList>
                            </li>
                            <li>补单方案
                                <asp:DropDownList ID="ddl_order" runat="server" Width="60">
                                </asp:DropDownList>
                            </li>
                            <li>活动方案
                                <asp:DropDownList ID="ddl_huodong" runat="server" Width="60">
                                </asp:DropDownList>
                            </li>
                            <li>重点
                                <asp:DropDownList ID="ddl_iskey" runat="server" Width="60">
                                    <asp:ListItem Text="- 请选择 -" Value=""></asp:ListItem>
                                    <asp:ListItem Text="是" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="否" Value="2"></asp:ListItem>
                                </asp:DropDownList>
                            </li>
                            <li>状态
                                <asp:DropDownList ID="ddl_state" runat="server" Width="60">
                                    <asp:ListItem Text="- 请选择 -" Value=""></asp:ListItem>
                                    <asp:ListItem Text="启用" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="禁用" Value="2"></asp:ListItem>
                                </asp:DropDownList>
                            </li>
                            <li>关键词
                                <asp:TextBox ID="txt_key" runat="server" Width="60"></asp:TextBox>
                            </li>
                            <li>
                                <asp:Button ID="btn_save" runat="server" Text="搜索" OnClick="btn_save_Click" />
                            </li>
                            <li>
                                <asp:Button ID="btn_toadd" runat="server" Text="添加商品" OnClientClick="window.location.href = 'basic_goods_add.aspx';return false;" />
                            </li>
                            <li>
                                <asp:Button ID="btn_del" runat="server" Text="批量删除" OnClientClick="return to_batch_do();"
                                    OnClick="btn_del_Click" />
                            </li>
                        </ul>
                    </div>
                </div>
                <div>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="GridView1_RowCancelingEdit"
                        OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" OnRowEditing="GridView1_RowEditing"
                        OnRowUpdating="GridView1_RowUpdating" DataKeyNames="bgid,opid,hdid,dpid,bgstate,bgkey,bgupdate"
                        OnRowDeleting="GridView1_RowDeleting">
                        <Columns>
                            <asp:TemplateField HeaderText="&lt;input type='checkbox' id='chk' name='chk' onclick='checkJs(this.checked);'/&gt;">
                                <ItemTemplate>
                                    <input type="checkbox" id="checkboxname" name="checkboxname" value='<%# DataBinder.Eval(Container.DataItem, "bgid")%>'
                                        onclick='SingleCheckJs();' style="height: 12; width: 12" />
                                </ItemTemplate>
                                <ItemStyle Width="25" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="序号" SortExpression="bgid">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_id" runat="server" Text='<%# Bind("bgid") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="50px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="店铺">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_dianpu" runat="server" Text='<%# Bind("dpname") %>'> </asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="150px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="商品名称">
                                <ItemTemplate>
                                    <asp:HyperLink ID="lb_account" runat="server" Target="_blank" Text='<%# Eval("bgname")!=null?(Eval("bgname").ToString().Length>20?Eval("bgname").ToString().Substring(0,19):Eval("bgname").ToString()):"" %>'
                                        ToolTip='<%# Eval("bgname") %>' NavigateUrl='<%# Eval("bgurl") %>' Font-Bold="true"
                                        ForeColor="Red"></asp:HyperLink>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_name" runat="server" Text='<%# Bind("bgname") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="还需补单" HeaderStyle-ForeColor="Red">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_order" runat="server" Text='<%# Bind("opid") %>'> </asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="80px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="活动提示" HeaderStyle-ForeColor="Red">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_huodong" runat="server" Text='<%# Bind("hdid") %>'> </asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="90px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="上架时间">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_update" runat="server" Text='<%# Convert.ToDateTime(Eval("bgupdate").ToString()).ToString("yyyy年MM月dd日 HH:mm") %>'
                                        ForeColor="Red"> </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_update" runat="server" Text='<%# Convert.ToDateTime(Eval("bgupdate").ToString()).ToString("yyyy年MM月dd日 HH:mm") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemStyle Width="130px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="重点">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lb_key" runat="server" CommandName="iskey"></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle Width="80px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="状态">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lb_state" runat="server" CommandName="state"></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle Width="80px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="添加时间">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_date" runat="server" Text='<%# Convert.ToDateTime(Eval("bgdate").ToString()).ToString("yyyy年MM月dd日 HH:mm") %>'> </asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="130px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="备注信息">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_remark" runat="server" Text='<%# Eval("bgremark")!=null?(Eval("bgremark").ToString().Length>10?Eval("bgremark").ToString().Substring(0,9)+"...":Eval("bgremark").ToString()):"" %>'
                                        ToolTip='<%# Eval("bgremark") %>'> </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_remark" runat="server" Text='<%# Eval("bgremark") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="操作" ShowHeader="False" ItemStyle-Font-Bold="true">
                                <EditItemTemplate>
                                    <asp:LinkButton ID="lbtn_update" runat="server" CausesValidation="True" CommandName="Update"
                                        Text="更新"></asp:LinkButton>
                                    &nbsp;<asp:LinkButton ID="lbtn_clear" runat="server" CausesValidation="False" CommandName="Cancel"
                                        Text="取消"></asp:LinkButton>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "basic_order_record_add.aspx?bgid="+Eval("bgid") %>'
                                        Text="添加补单"> </asp:HyperLink>
                                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# "basic_order_record_list.aspx?bgid="+Eval("bgid") %>'
                                        Text="查询补单"> </asp:HyperLink>
                                    <%-- <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# "basic_goods_add.aspx?id="+Eval("bgid") %>'
                                        Text="关键词"> </asp:HyperLink>--%>
                                    <asp:LinkButton ID="lbtn_edit" runat="server" CausesValidation="False" CommandName="Edit"
                                        Text="编辑"></asp:LinkButton>
                                    <%--<asp:HyperLink ID="hl_history" runat="server" Text="历史" NavigateUrl='<%# "fanxian_list.aspx?key="+ Eval("fx_zhifubao") %>'></asp:HyperLink>--%>
                                    <asp:HyperLink ID="hl_info" runat="server" NavigateUrl='<%# "basic_goods_add.aspx?id="+Eval("bgid") %>'
                                        Text="详细"> </asp:HyperLink>
                                    <asp:LinkButton ID="lbtn_del" runat="server" CausesValidation="False" CommandName="Delete"
                                        Text="删除" OnClientClick="return confirm('确定要删除么？');"></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle Width="200px" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <div class="page">
                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" FirstPageText="首页" LastPageText="尾页"
                            NextPageText="下一页" OnPageChanged="AspNetPager1_PageChanged" PageIndexBoxType="DropDownList"
                            PageSize="20" PagingButtonLayoutType="Span" PrevPageText="上一页" ShowPageIndexBox="Always"
                            SubmitButtonText="Go" TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到">
                        </webdiyer:AspNetPager>
                        <asp:Label ID="lbl_count" runat="server" Text="" ForeColor="Red"></asp:Label>
                        <%--<asp:Label ID="lbl_zong" runat="server" Text="" ForeColor="Red"></asp:Label>
                        <asp:Button ID="btn_zong" runat="server" Text="查看" OnClick="btn_zong_Click" />--%>
                    </div>
                </div>
            </div>
            <uc1:loading ID="loading1" runat="server" AssociatedUpdatePanelID1="UpdatePanel1" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <script>
        //        function to_edit(id) {
        //            window.parent.location.href = "fanxian_add.aspx?id=" + id;
        //        }
    </script>
    </form>
</body>
</html>
