﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="sh_problem_list.aspx.cs"
    Inherits="OA_sh_problem_list" ValidateRequest="false" %>

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
                        ● 问题件管理</div>
                    <div class="c_t_desc">
                        <ul>
                            <li>（关键词可搜索买家姓名、账号、手机号、订单号、快递电话、快递单号、售后原因以及备注）搜索： </li>
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
                            <li>状态
                                <asp:DropDownList ID="ddl_state" runat="server">
                                    <asp:ListItem Text="- 请选择 -" Value=""></asp:ListItem>
                                    <asp:ListItem Text="未处理" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="已投诉" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="已处理" Value="3"></asp:ListItem>
                                </asp:DropDownList>
                            </li>
                            <li>关键词
                                <asp:TextBox ID="txt_key" runat="server" Width="80"></asp:TextBox>
                            </li>
                            <li>
                                <asp:Button ID="btn_search" runat="server" Text="搜索" OnClick="btn_search_Click" />
                            </li>
                            <li>
                                <asp:Button ID="btn_toadd" runat="server" Text="添加售后" OnClientClick="window.location.href = 'sh_problem_add.aspx';return false;" />
                            </li>
                        </ul>
                        <script>
                            function to_search() {
                                var url = 'sh_problem_list.aspx?date1=' + $("#txt_date1").val() + '&date2=' + $("#txt_date2").val() + '&dp=' + $("#ddl_dianpu").val() + '&state=' + $("#ddl_state").val() + '&key=' + $("#txt_key").val();
                                window.location.href = url;
                                return false;
                            }
                        </script>
                    </div>
                </div>
                <div>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="GridView1_RowCancelingEdit"
                        OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" OnRowEditing="GridView1_RowEditing"
                        OnRowUpdating="GridView1_RowUpdating" DataKeyNames="shid,shstate,dpid" OnRowDeleting="GridView1_RowDeleting">
                        <Columns>
                            <asp:TemplateField HeaderText="序号" SortExpression="shid">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_id" runat="server" Text='<%# Bind("shid") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="50px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="店铺">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_dianpu" runat="server" Text='<%# Bind("dpid") %>'> </asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="150px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="订单编号" SortExpression="shordercode">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_ordercode" runat="server" Text='<%# Bind("shordercode") %>'> </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_ordercode" runat="server" Text='<%# Bind("shordercode") %>'
                                        Width="150px"></asp:TextBox>
                                </EditItemTemplate>
                                 <ItemStyle Width="180px" />
                            </asp:TemplateField>
                           <%-- <asp:TemplateField HeaderText="买家姓名" SortExpression="shname" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_name" runat="server" Text='<%# Bind("shname") %>'> </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_name" runat="server" Text='<%# Bind("shname") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemStyle Width="180px" />
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="买家账号 (点击可联系)" SortExpression="shaccount" HeaderStyle-ForeColor="Red"
                                ControlStyle-ForeColor="Red">
                                <ItemTemplate>
                                    <asp:HyperLink ID="lb_account" runat="server" Target="_blank" Text='<%# Bind("shaccount") %>'
                                        NavigateUrl="#"></asp:HyperLink>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_account" runat="server" Text='<%# Bind("shaccount") %>'></asp:TextBox>
                                </EditItemTemplate>
                                 <ItemStyle Width="180px" />
                            </asp:TemplateField>
                            <%--<asp:TemplateField HeaderText="手机号码" SortExpression="shphone" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_phone" runat="server" Text='<%# Bind("shphone") %>'> </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_phone" runat="server" Text='<%# Bind("shphone") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemStyle Width="100px" />
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="快递单号 (点击可查询)" SortExpression="shkdcode" HeaderStyle-ForeColor="Red"
                                ControlStyle-ForeColor="Red">
                                <ItemTemplate>
                                    <asp:HyperLink ID="hl_state" runat="server" Target="_blank" Text='<%# Bind("shkdcode") %>'
                                        NavigateUrl='<%# "http://www.kiees.cn/yto.php?wen="+ Eval("shkdcode") %>'></asp:HyperLink>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_kdcode" runat="server" Text='<%# Bind("shkdcode") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemStyle Width="180px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="售后原因 (鼠标悬停可显示全部)">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_yuanyin" runat="server" Text='<%# Eval("shyuanyin")!=null?(Eval("shyuanyin").ToString().Length>15?Eval("shyuanyin").ToString().Substring(0,14):Eval("shyuanyin").ToString()):"" %>'
                                        ToolTip='<%# Eval("shyuanyin") %>'> </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_yuanyin" runat="server" Text='<%# Bind("shyuanyin") %>' Width="180px"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="售后状态" SortExpression="shstate">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lb_state" runat="server" CommandName="state"></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle Width="100px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="操作时间" SortExpression="shdate">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_date" runat="server" Text='<%# Convert.ToDateTime(Eval("shdate").ToString()).ToString("yyyy年MM月dd日") %>'> </asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="100px" />
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
                                    <asp:HyperLink ID="hl_info" runat="server" Text="详细" NavigateUrl='<%# "sh_problem_add.aspx?id="+ Eval("shid") %>'></asp:HyperLink>
                                    <asp:LinkButton ID="lbtn_del" runat="server" CausesValidation="False" CommandName="Delete"
                                        Text="删除" OnClientClick="return confirm('确定要删除么？');"></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle Width="100px" />
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
