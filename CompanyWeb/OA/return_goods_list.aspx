<%@ Page Language="C#" AutoEventWireup="true" CodeFile="return_goods_list.aspx.cs"
    Inherits="OA_sd_account_list" ValidateRequest="false" %>

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
    <div class="content">
        <div class="c_title">
            <div class="c_t_name">
                ● 退货管理</div>
            <div class="c_t_desc">
                <ul>
                    <li>（关键词可搜索账号,密码以及备注）搜索： </li>
                    <li>开始时间
                        <asp:TextBox ID="txt_date1" runat="server" Width="80"></asp:TextBox>
                    </li>
                    <li>结束时间
                        <asp:TextBox ID="txt_date2" runat="server" Width="80"></asp:TextBox>
                    </li>
                    <li>快递公司
                        <asp:DropDownList ID="ddl_courier" runat="server">
                        </asp:DropDownList>
                    </li>
                    <li>关键词
                        <asp:TextBox ID="txt_key" runat="server" Width="80"></asp:TextBox>
                    </li>
                    <li>
                        <asp:Button ID="btn_search" runat="server" Text="搜索" OnClick="btn_search_Click" />
                    </li>
                    <li>
                        <asp:Button ID="btn_toadd" runat="server" Text="添加退货" OnClientClick="window.location.href = 'return_goods_add.aspx';return false;" />
                    </li>
                    <li>
                        <asp:Button ID="btn_del" runat="server" Text="批量删除" ForeColor="Red" OnClick="btn_del_Click" OnClientClick="return confirm('确定要批量删除么?')"  />
                    </li>
                </ul>
            </div>
        </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="GridView1_RowCancelingEdit"
                        OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" OnRowEditing="GridView1_RowEditing"
                        OnRowUpdating="GridView1_RowUpdating" DataKeyNames="rgid,cid,rgcode" OnRowDeleting="GridView1_RowDeleting">
                        <Columns>
                            <asp:TemplateField HeaderText="&lt;input type='checkbox' id='chk' name='chk' onclick='checkJs(this.checked);'/&gt;">
                                <ItemTemplate>
                                    <input type="checkbox" id="checkboxname" name="checkboxname" value='<%# DataBinder.Eval(Container.DataItem, "rgid")%>'
                                        onclick='SingleCheckJs();' style="height: 12; width: 12" />
                                </ItemTemplate>
                                <ItemStyle Width="50" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="快递公司">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_courier" runat="server" Text='<%# Bind("cname") %>'> </asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="100" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="快递单号（点击查询）" HeaderStyle-ForeColor="Red">
                                <ItemTemplate>
                                    <asp:HyperLink ID="hl_code" runat="server" Text='<%# Bind("rgcode") %>' Target="_blank"> </asp:HyperLink>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_code" runat="server" Text='<%# Bind("rgcode") %>' Width="180px"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="备注">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_remark" runat="server" Text='<%# Bind("rgremark") %>'> </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_remark" runat="server" Text='<%# Bind("rgremark") %>' Width="180px"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="操作时间">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_date" runat="server" Text='<%# Convert.ToDateTime(Eval("rgdate").ToString()).ToString("yyyy年MM月dd日") %>'> </asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="150px" />
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
                                    <asp:HyperLink ID="hl_info" runat="server" Text="详细" NavigateUrl='<%# "return_goods_add.aspx?id="+ Eval("rgid") %>'></asp:HyperLink>
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
                        <asp:Label ID="lbl_count" runat="server" Text="" ForeColor="Red"></asp:Label>
                    </div>
                </div>
                <uc1:loading ID="loading1" runat="server" AssociatedUpdatePanelID1="UpdatePanel1" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
