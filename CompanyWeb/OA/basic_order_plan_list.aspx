<%@ Page Language="C#" AutoEventWireup="true" CodeFile="basic_order_plan_list.aspx.cs"
    Inherits="OA_basic_order_plan_list" ValidateRequest="false" %>

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
                        ● 订单计划管理</div>
                    <div class="c_t_desc">
                        <ul>
                            <%--   <li>
                                <asp:Button ID="btn_sort" runat="server" Text="重新排序" OnClick="btn_sort_Click" />
                            </li>--%>
                            <li>
                                <asp:Button ID="btn_toadd" runat="server" Text="添加订单计划" OnClientClick="window.location.href = 'basic_order_plan_add.aspx';return false;" />
                            </li>
                        </ul>
                    </div>
                </div>
                <div>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="GridView1_RowCancelingEdit"
                        OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" OnRowEditing="GridView1_RowEditing"
                        OnRowUpdating="GridView1_RowUpdating" DataKeyNames="opid" OnRowDeleting="GridView1_RowDeleting">
                        <Columns>
                            <asp:TemplateField HeaderText="序号" SortExpression="opid">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_id" runat="server" Text='<%# Bind("opid") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="50px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="类型" SortExpression="optype">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_name" runat="server" Text='<%# Eval("optype").ToString()=="1"?"淘宝":"蘑菇街" %>'> </asp:Label>
                                </ItemTemplate>
                                <%--<EditItemTemplate>
                                    <asp:TextBox ID="txt_name" runat="server" Text='<%# Bind("optype") %>'></asp:TextBox>
                                </EditItemTemplate>--%>
                                <ItemStyle Width="50px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="方案名称">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_name" runat="server" Text='<%# Eval("opname") %>'> </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="第一天" SortExpression="opday1">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_1" runat="server" Text='<%# Eval("opday1") %>'> </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="第二天" SortExpression="opday2">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_2" runat="server" Text='<%# Eval("opday2") %>'> </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="第三天" SortExpression="opday3">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_3" runat="server" Text='<%# Eval("opday3") %>'> </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="第四天" SortExpression="opday4">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_4" runat="server" Text='<%# Eval("opday4") %>'> </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="第五天" SortExpression="opday5">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_5" runat="server" Text='<%# Eval("opday5") %>'> </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="第六天" SortExpression="opday6">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_6" runat="server" Text='<%# Eval("opday6") %>'> </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="第七天" SortExpression="opday7">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_7" runat="server" Text='<%# Eval("opday7") %>'> </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="第八天" SortExpression="opday8">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_8" runat="server" Text='<%# Eval("opday8") %>'> </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="第九天" SortExpression="opday9">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_9" runat="server" Text='<%# Eval("opday9") %>'> </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="第十天" SortExpression="opday10">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_10" runat="server" Text='<%# Eval("opday10") %>'> </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="第十一天" SortExpression="opday11">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_11" runat="server" Text='<%# Eval("opday11") %>'> </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="第十二天" SortExpression="opday12">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_12" runat="server" Text='<%# Eval("opday12") %>'> </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="第十三天" SortExpression="opday13">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_13" runat="server" Text='<%# Eval("opday13") %>'> </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="第十四天" SortExpression="opday14">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_14" runat="server" Text='<%# Eval("opday14") %>'> </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="备注" SortExpression="opremark">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_remark" runat="server" Text='<%# Eval("opremark")!=null?(Eval("opremark").ToString().Length>4?Eval("opremark").ToString().Substring(0,4):Eval("opremark").ToString()):"" %>'
                                        ToolTip='<%# Eval("opremark") %>'> </asp:Label>
                                </ItemTemplate>
                                <%--<EditItemTemplate>
                                    <asp:TextBox ID="txt_remark" runat="server" Text='<%# Bind("cremark") %>' Width="300"></asp:TextBox>
                                </EditItemTemplate>--%>
                                <ItemStyle Width="50px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="操作" ShowHeader="False" ItemStyle-Font-Bold="true">
                                <%--<EditItemTemplate>
                                    <asp:LinkButton ID="lbtn_update" runat="server" CausesValidation="True" CommandName="Update"
                                        Text="更新"></asp:LinkButton>
                                    &nbsp;<asp:LinkButton ID="lbtn_clear" runat="server" CausesValidation="False" CommandName="Cancel"
                                        Text="取消"></asp:LinkButton>
                                </EditItemTemplate>--%>
                                <ItemTemplate>
                                    <%--<asp:LinkButton ID="lbtn_edit" runat="server" CausesValidation="False" CommandName="Edit"
                                        Text="编辑"></asp:LinkButton>--%>
                                    <asp:HyperLink ID="hl_info" runat="server" Text="编辑" NavigateUrl='<%# "basic_order_plan_add.aspx?id="+ Eval("opid") %>'></asp:HyperLink>
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
                            SubmitButtonText="Go" TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到" UrlPaging="True">
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
