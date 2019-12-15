<%@ Page Language="C#" AutoEventWireup="true" CodeFile="yh_zaoci_list.aspx.cs"
    Inherits="OA_yh_zaoci_list" ValidateRequest="false" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="js/Calendar.js" type="text/javascript"></script>
    <script src="js/jquery-1.4.3.min.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="content">
        <div class="c_title">
            <div class="c_t_name">
                ● 噪词管理</div>
            <div class="c_t_desc">
                <ul>
                    <li>（关键词可搜索核心关键词、备注）搜索： </li>
                    <li>开始时间
                        <asp:TextBox ID="txt_date1" runat="server" Width="80"></asp:TextBox>
                    </li>
                    <li>结束时间
                        <asp:TextBox ID="txt_date2" runat="server" Width="80"></asp:TextBox>
                    </li>
                    <li>商品类型
                        <asp:DropDownList ID="ddl_goodstype" runat="server">
                        </asp:DropDownList>
                    </li>
                    <li>状态
                        <asp:DropDownList ID="ddl_state" runat="server">
                            <asp:ListItem Text="- 请选择 -" Value=""></asp:ListItem>
                            <asp:ListItem Text="启用" Value="1"></asp:ListItem>
                            <asp:ListItem Text="禁用" Value="2"></asp:ListItem>
                        </asp:DropDownList>
                    </li>
                    <li>关键词
                        <asp:TextBox ID="txt_key" runat="server" Width="80"></asp:TextBox>
                    </li>
                    <li>
                        <asp:Button ID="btn_save" runat="server" Text="搜索" OnClientClick="return to_search();" />
                    </li>
                     <li>
                        <asp:Button ID="btn_tolist" runat="server" Text="添加噪词" OnClientClick="window.location.href = 'yh_zaoci_add.aspx';return false;" />
                    </li>
                </ul>
                <script>
                    function to_search() {
                        var url = 'yh_zaoci_list.aspx?date1=' + $("#txt_date1").val() + '&date2=' + $("#txt_date2").val() + '&gt=' + $("#ddl_goodstype").val() + '&state=' + $("#ddl_state").val() + '&key=' + $("#txt_key").val();
                        window.location.href = url;
                        return false;
                    }
                </script>
            </div>
        </div>
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="GridView1_RowCancelingEdit"
                OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" OnRowEditing="GridView1_RowEditing"
                OnRowUpdating="GridView1_RowUpdating" DataKeyNames="zid,gtid,zstate" OnRowDeleting="GridView1_RowDeleting">
                <Columns>
                    <asp:TemplateField HeaderText="序号" SortExpression="zid">
                        <ItemTemplate>
                            <asp:Label ID="lbl_id" runat="server" Text='<%# Bind("zid") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="50px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="商品类型">
                        <ItemTemplate>
                            <asp:Label ID="lbl_goodstype" runat="server" Text='<%# Bind("gtid") %>'> </asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="150px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="噪词" SortExpression="zname">
                        <ItemTemplate>
                            <asp:Label ID="lbl_name" runat="server" Text='<%# Bind("zname") %>'> </asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txt_name" runat="server" Text='<%# Bind("zname") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemStyle Width="180px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="备注" SortExpression="gtname">
                        <ItemTemplate>
                            <asp:Label ID="lbl_remark" runat="server" Text='<%# Bind("gtname") %>'> </asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txt_remark" runat="server" Text='<%# Bind("gtname") %>' Width="300"></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="状态" SortExpression="zstate">
                        <ItemTemplate>
                            <asp:LinkButton ID="lb_state" runat="server" CommandName="state"></asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="录入时间" SortExpression="zdate">
                        <ItemTemplate>
                            <asp:Label ID="lbl_date" runat="server" Text='<%# Convert.ToDateTime(Eval("zdate").ToString()).ToString("yyyy年MM月dd日") %>'> </asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="操作" ShowHeader="False" ItemStyle-Font-Bold="true" >
                        <EditItemTemplate>
                            <asp:LinkButton ID="lbtn_update" runat="server" CausesValidation="True" CommandName="Update"
                                Text="更新"></asp:LinkButton>
                            &nbsp;<asp:LinkButton ID="lbtn_clear" runat="server" CausesValidation="False" CommandName="Cancel"
                                Text="取消"></asp:LinkButton>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="lbtn_edit" runat="server" CausesValidation="False" CommandName="Edit"
                                Text="编辑"></asp:LinkButton>
                            <asp:HyperLink ID="hl_info" runat="server" Text="详细" NavigateUrl='<%# "yh_zaoci_list.aspx?id="+ Eval("zid") %>'></asp:HyperLink>
                            <asp:LinkButton ID="lbtn_del" runat="server" CausesValidation="False" CommandName="Delete"
                                Text="删除" OnClientClick="return confirm('确定要删除么？');"></asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle Width="150px" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <div class="page">
                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" FirstPageText="首页" LastPageText="尾页"
                    NextPageText="下一页" OnPageChanged="AspNetPager1_PageChanged" PageIndexBoxType="DropDownList"
                    PageSize="20" PagingButtonLayoutType="Span" PrevPageText="上一页" ShowPageIndexBox="Always"
                    SubmitButtonText="Go" TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到" UrlPaging="True">
                </webdiyer:AspNetPager>
            </div>
        </div>
    </form>
</body>
</html>
