﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="basic_task_list.aspx.cs"
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
                        ● 任务列表</div>
                    <div class="c_t_desc">
                        <ul>
                            <li>搜索： </li>
                            <li>开始时间
                                <asp:TextBox ID="txt_date1" runat="server" Width="80"></asp:TextBox>
                            </li>
                            <li>结束时间
                                <asp:TextBox ID="txt_date2" runat="server" Width="80"></asp:TextBox>
                            </li>
                            <li>状态
                                <asp:DropDownList ID="ddl_state" runat="server">
                                    <asp:ListItem Text="- 请选择 -" Value=""></asp:ListItem>
                                    <asp:ListItem Text="未完成" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="已完成" Value="2"></asp:ListItem>
                                </asp:DropDownList>
                            </li>
                            <li>关键词
                                <asp:TextBox ID="txt_key" runat="server" Width="80"></asp:TextBox>
                            </li>
                            <li>
                                <asp:Button ID="btn_search" runat="server" Text="搜索" OnClick="btn_search_Click" />
                            </li>
                            <li>
                                <asp:Button ID="btn_del" runat="server" Text="批量删除" OnClientClick="return to_batch_do();"
                                    OnClick="btn_del_Click" />
                            </li>
                            <li>
                                <asp:Button ID="btn_toadd" runat="server" Text="添加任务" OnClientClick="window.location.href = 'basic_task_add.aspx';return false;" />
                            </li>
                        </ul>
                    </div>
                </div>
                <div>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="GridView1_RowCancelingEdit"
                        OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" OnRowEditing="GridView1_RowEditing"
                        OnRowUpdating="GridView1_RowUpdating" DataKeyNames="btid,btstate" OnRowDeleting="GridView1_RowDeleting">
                        <Columns>
                            <asp:TemplateField HeaderText="&lt;input type='checkbox' id='chk' name='chk' onclick='checkJs(this.checked);'/&gt;">
                                <ItemTemplate>
                                    <input type="checkbox" id="checkboxname" name="checkboxname" value='<%# DataBinder.Eval(Container.DataItem, "btid")%>'
                                        onclick='SingleCheckJs();' style="height: 12; width: 12" />
                                </ItemTemplate>
                                <ItemStyle Width="25" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="序号">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_id" runat="server" Text='<%# Bind("btid") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="50px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="任务名称">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_name" runat="server" Text='<%# Bind("btname") %>'> </asp:Label>
                                    <%--<asp:HyperLink ID="hl_name" runat="server" Target="_blank" Text='<%# Bind("btname") %>'
                                        NavigateUrl='<%# "basic_order_record_add.aspx?bgid="+Eval("bgid") %>'></asp:HyperLink>--%>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_name" runat="server" Text='<%# Bind("btname") %>' Width="150px"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="任务内容">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_remark" runat="server" Text='<%# Eval("btcontent")!=null?(Eval("btcontent").ToString().Length>50?Eval("btcontent").ToString().Substring(0,49):Eval("btcontent").ToString()):"" %>'
                                        ToolTip='<%# Eval("btcontent") %>'> </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_remark" runat="server" Text='<%# Bind("btcontent") %>' Width="180px"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="状态">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lb_state" runat="server" CommandName="state"></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle Width="80px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="执行时间">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_date" runat="server" Text='<%# Convert.ToDateTime(Eval("btdate").ToString()).ToString("yyyy年MM月dd日") %>'> </asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="100px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="操作时间">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_date2" runat="server" Text='<%# Convert.ToDateTime(Eval("btdate2").ToString()).ToString("yyyy年MM月dd日") %>'> </asp:Label>
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
                                    <asp:HyperLink ID="hl_info" runat="server" Text="详细" NavigateUrl='<%# "basic_task_add.aspx?id="+ Eval("btid") %>'></asp:HyperLink>
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
            </div>
            <uc1:loading ID="loading1" runat="server" AssociatedUpdatePanelID1="UpdatePanel1" />
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
