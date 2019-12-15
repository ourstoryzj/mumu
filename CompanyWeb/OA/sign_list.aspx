<%@ Page Language="C#" AutoEventWireup="true" CodeFile="sign_list.aspx.cs" Inherits="OA_sign_list"
    ValidateRequest="false" %>

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
                ● 签到记录</div>
            <div class="c_t_desc">
                <ul>
                    <li>关键词 </li>
                    <li>
                        <asp:TextBox ID="txt_key" runat="server" Width="80"></asp:TextBox>
                    </li>
                    <li>开始时间 </li>
                    <li>
                        <asp:TextBox ID="txt_start" runat="server" Width="80"></asp:TextBox>
                    </li>
                    <li>结束时间 </li>
                    <li>
                        <asp:TextBox ID="txt_end" runat="server" Width="80"></asp:TextBox>
                    </li>
                    <li>状态 </li>
                    <li>
                        <asp:DropDownList ID="ddl_state" runat="server">
                            <asp:ListItem Text="-请选择-" Value="0"></asp:ListItem>
                            <asp:ListItem Text="正常" Value="1"></asp:ListItem>
                            <asp:ListItem Text="迟到或早退" Value="2"></asp:ListItem>
                            <asp:ListItem Text="旷工" Value="3"></asp:ListItem>
                            <asp:ListItem Text="请假" Value="4"></asp:ListItem>
                        </asp:DropDownList>
                    </li>
                    <li>类型 </li>
                    <li>
                        <asp:DropDownList ID="ddl_type" runat="server">
                            <asp:ListItem Text="-请选择-" Value="0"></asp:ListItem>
                            <asp:ListItem Text="上午签到" Value="1"></asp:ListItem>
                            <asp:ListItem Text="上午签退" Value="2"></asp:ListItem>
                            <asp:ListItem Text="下午签到" Value="3"></asp:ListItem>
                            <asp:ListItem Text="下午签退" Value="4"></asp:ListItem>
                        </asp:DropDownList>
                    </li>
                    <li>
                        <asp:Button ID="btn_search" runat="server" Text="搜索" OnClientClick="to_search();return false;" />
                    </li>
                </ul>
            </div>
        </div>
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" EnableModelValidation="True"
                OnRowDataBound="GridView1_RowDataBound" DataKeyNames="Id,UId,UState,UType,SignTime">
                <Columns>
                    <asp:TemplateField HeaderText="编号" SortExpression="Id">
                        <ItemTemplate>
                            <asp:Label ID="lbl_id" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="50" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="用户名称" SortExpression="UName">
                        <ItemTemplate>
                            <asp:Label ID="lbl_uname" runat="server" Text='<%# Bind("UName") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="100" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="状态" SortExpression="UState">
                        <ItemTemplate>
                            <asp:Label ID="lbl_state" runat="server" Text='<%# Bind("UState") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="100" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="类型" SortExpression="UType">
                        <ItemTemplate>
                            <asp:Label ID="lbl_type" runat="server" Text='<%# Bind("UType") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="100" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="签到时间" SortExpression="SignTime">
                        <ItemTemplate>
                            <asp:Label ID="lbl_signtime" runat="server" Text='<%# Bind("SignTime") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="150" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="备注" SortExpression="Remark">
                        <ItemTemplate>
                            <asp:Label ID="lbl_remark" runat="server" Text='<%# Bind("Remark") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <div class="paginator">
                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" FirstPageText="首页" LastPageText="尾页"
                    NextPageText="下一页" OnPageChanged="AspNetPager1_PageChanged" PageIndexBoxType="DropDownList"
                    PageSize="20" PagingButtonLayoutType="Span" PrevPageText="上一页" ShowPageIndexBox="Always"
                    SubmitButtonText="Go" TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到" UrlPaging="True">
                </webdiyer:AspNetPager>
            </div>
        </div>
        <script>
            function to_search() {
                var k = $("#txt_key").val();
                var s = $("#txt_start").val();
                var e = $("#txt_end").val();
                var state = $("#ddl_state").val();
                var type = $("#ddl_type").val();

                window.location.href = "sign_list.aspx?key=" + k + "&start=" + s + "&end=" + e + "&state=" + state + "&type=" + type;
            }
           
        </script>
    </form>
</body>
</html>
