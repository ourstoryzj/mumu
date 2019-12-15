<%@ Page Language="C#" AutoEventWireup="true" CodeFile="basic_order_record_list.aspx.cs"
    Inherits="OA_basic_order_record_list" ValidateRequest="false" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="control/loading.ascx" TagName="loading" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="js/Calendar.js" type="text/javascript"></script>
    <script src="js/jquery-1.4.3.min.js" type="text/javascript"></script>
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
                        ● 补单记录管理</div>
                    <div class="c_t_desc">
                        <ul>
                            <li>搜索： </li>
                            <li>开始时间
                                <asp:TextBox ID="txt_date1" runat="server" Width="80"></asp:TextBox>
                            </li>
                            <li>结束时间
                                <asp:TextBox ID="txt_date2" runat="server" Width="80"></asp:TextBox>
                            </li>
                            <li>店铺
                                <asp:DropDownList ID="ddl_dianpu" runat="server">
                                </asp:DropDownList>
                            </li>
                            <li>买家秀
                                <asp:DropDownList ID="ddl_maijiaxiu" runat="server">
                                    <asp:ListItem Text="- 请选择 -" Value=""></asp:ListItem>
                                    <asp:ListItem Text="是" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="否" Value="2"></asp:ListItem>
                                </asp:DropDownList>
                            </li>
                            <li>状态
                                <asp:DropDownList ID="ddl_state" runat="server">
                                    <asp:ListItem Text="- 请选择 -" Value=""></asp:ListItem>
                                    <asp:ListItem Text="已评价" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="未评价" Value="2"></asp:ListItem>
                                </asp:DropDownList>
                            </li>
                            <li>关键词
                                <asp:TextBox ID="txt_key" runat="server" Width="80"></asp:TextBox>
                            </li>
                            <li>
                                <asp:Button ID="btn_search" runat="server" Text="搜索" OnClick="btn_search_Click" />
                            </li>
                            <li>
                                <asp:Button ID="btn_toadd" runat="server" Text="添加记录" OnClientClick="window.location.href = 'basic_order_record_add.aspx';return false;" />
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
                        OnRowUpdating="GridView1_RowUpdating" DataKeyNames="orid,bgid,dpid,ormaijiaxiu,orprepare1"
                        OnRowDeleting="GridView1_RowDeleting">
                        <Columns>
                            <asp:TemplateField HeaderText="&lt;input type='checkbox' id='chk' name='chk' onclick='checkJs(this.checked);'/&gt;">
                                <ItemTemplate>
                                    <input type="checkbox" id="checkboxname" name="checkboxname" value='<%# DataBinder.Eval(Container.DataItem, "orid")%>'
                                        onclick='SingleCheckJs();' style="height: 12; width: 12" />
                                </ItemTemplate>
                                <ItemStyle Width="25" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="序号" SortExpression="shid">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_id" runat="server" Text='<%# Bind("orid") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="50px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="店铺">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_dianpu" runat="server" Text='<%# Bind("dpid") %>'> </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="商品名称">
                                <ItemTemplate>
                                    <%--<asp:Label ID="lbl_name" runat="server" Text='<%# Bind("bgname") %>'> </asp:Label>--%>
                                    <asp:HyperLink ID="hl_name" runat="server" Target="_blank" Text='<%# Bind("bgname") %>'
                                        NavigateUrl='<%# "basic_order_record_add.aspx?bgid="+Eval("bgid") %>'></asp:HyperLink>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_name" runat="server" Text='<%# Bind("bgname") %>' Width="150px"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="关键词">
                                <ItemTemplate>
                                    <%--<asp:Label ID="lbl_key" runat="server" Text='<%# Bind("gkname") %>'> </asp:Label>--%>
                                    <asp:HyperLink ID="hl_key" runat="server" Target="_blank" Text='<%# Bind("gkname") %>'
                                        NavigateUrl='<%# "https://s.taobao.com/search?q="+ Eval("gkname") %>'></asp:HyperLink>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_key" runat="server" Text='<%# Bind("gkname") %>' Width="150px"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="快递单号 (点击可查询)" HeaderStyle-ForeColor="Red" ControlStyle-ForeColor="Red">
                                <ItemTemplate>
                                    <asp:HyperLink ID="hl_wuliu" runat="server" Target="_blank" Text='<%# Bind("bgwuliu") %>'
                                        NavigateUrl='<%# "http://www.kiees.cn/yto.php?wen="+ Eval("bgwuliu") %>'></asp:HyperLink>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_wuliu" runat="server" Text='<%# Bind("bgwuliu") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemStyle Width="180px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="买家秀">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lb_maijiaxiu" runat="server" CommandName="maijiaxiu"></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle Width="60px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="旺旺【点击联系】" HeaderStyle-ForeColor="Blue">
                                <ItemTemplate>
                                    <asp:HyperLink ID="lb_wangwang" runat="server" Target="_blank" Text='<%# Bind("orwangwang") %>'
                                        NavigateUrl="#"></asp:HyperLink>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_wangwang" runat="server" Text='<%# Bind("orwangwang") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="QQ【点击联系】" SortExpression="orqq" HeaderStyle-ForeColor="Blue">
                                <ItemTemplate>
                                    <asp:HyperLink ID="lb_qq" runat="server" Target="_blank" Text='<%# Bind("orqq") %>'
                                        NavigateUrl="#"></asp:HyperLink>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_qq" runat="server" Text='<%# Bind("orqq") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="价格">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_price" runat="server" Text='<%# Bind("orprice") %>'> </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_price" runat="server" Text='<%# Bind("orprice") %>' Width="70px"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemStyle Width="80px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="状态">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lb_state" runat="server" CommandName="state"></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle Width="80px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="操作时间">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_date" runat="server" Text='<%# Convert.ToDateTime(Eval("ordate").ToString()).ToString("yyyy年MM月dd日") %>'> </asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="100px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="备注">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_remark" runat="server" Text='<%# Eval("orremark")!=null?(Eval("orremark").ToString().Length>15?Eval("orremark").ToString().Substring(0,14):Eval("orremark").ToString()):"" %>'
                                        ToolTip='<%# Eval("orremark") %>'> </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_remark" runat="server" Text='<%# Bind("orremark") %>' Width="180px"></asp:TextBox>
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
                                    <asp:LinkButton ID="lbtn_edit" runat="server" CausesValidation="False" CommandName="Edit"
                                        Text="编辑"></asp:LinkButton>
                                    <asp:HyperLink ID="hl_info" runat="server" Text="详细" NavigateUrl='<%# "basic_order_record_add.aspx?id="+ Eval("orid") %>'></asp:HyperLink>
                                    <asp:HyperLink ID="hl_add" runat="server" NavigateUrl='<%# "basic_order_record_add.aspx?bgid="+Eval("bgid") %>'
                                        Text="继续补单"> </asp:HyperLink>
                                    <asp:LinkButton ID="lbtn_del" runat="server" CausesValidation="False" CommandName="Delete"
                                        Text="删除" OnClientClick="return confirm('确定要删除么？');"></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle Width="140px" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <div class="page">
                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" FirstPageText="首页" LastPageText="尾页"
                            NextPageText="下一页" OnPageChanged="AspNetPager1_PageChanged" PageIndexBoxType="DropDownList"
                            PageSize="20" PagingButtonLayoutType="Span" PrevPageText="上一页" ShowPageIndexBox="Always"
                            SubmitButtonText="Go" TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到">
                        </webdiyer:AspNetPager>
                    </div>
                </div>
                <uc1:loading ID="loading1" runat="server" AssociatedUpdatePanelID1="UpdatePanel1" />
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
