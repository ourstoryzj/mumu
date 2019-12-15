<%@ Page Language="C#" AutoEventWireup="true" CodeFile="goodstype.aspx.cs" Inherits="OA_goodstype"
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
                ● 商品类型件管理</div>
            <div class="c_t_desc">
                <ul>
                    <li>（添加商品类型,排序数值越小越靠前）添加： </li>
                    <li>商品类型名称
                        <asp:TextBox ID="txt_name" runat="server" Width="120"></asp:TextBox>
                    </li>
                    <li>排序
                        <asp:TextBox ID="txt_sort" runat="server" Width="80"></asp:TextBox>
                    </li>
                    <li>
                        <asp:Button ID="btn_save" runat="server" Text="保存" OnClientClick="return to_save();"
                            OnClick="btn_save_Click" />
                        <asp:Button ID="btn_sort" runat="server" Text="重新排序" OnClick="btn_sort_Click" />
                    </li>
                </ul>
                <script>
                    function to_save() {
                        if ($("#txt_name").val() == "") {
                            alert("请输入商品类型名称");
                            $("#txt_name").focus();
                            return false;
                        }
                        if ($("#txt_sort").val() == "") {
                            alert("请输入排序");
                            $("#txt_sort").focus();
                            return false;
                        }
                        return true;
                    }
                </script>
            </div>
        </div>
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="GridView1_RowCancelingEdit"
                OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" OnRowEditing="GridView1_RowEditing"
                OnRowUpdating="GridView1_RowUpdating" DataKeyNames="gtid,gtstate" OnRowDeleting="GridView1_RowDeleting">
                <Columns>
                    <asp:TemplateField HeaderText="序号" SortExpression="gtid">
                        <ItemTemplate>
                            <asp:Label ID="lbl_id" runat="server" Text='<%# Bind("gtid") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="50px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="商品类型名称" SortExpression="gtanme">
                        <ItemTemplate>
                            <asp:Label ID="lbl_name" runat="server" Text='<%# Bind("gtanme") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txt_name" runat="server" Text='<%# Bind("gtanme") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemStyle />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="排序" SortExpression="gtsort">
                        <ItemTemplate>
                            <asp:Label ID="lbl_sort" runat="server" Text='<%# Bind("gtsort") %>'> </asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txt_sort" runat="server" Text='<%# Bind("gtsort") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="状态" SortExpression="gtstate">
                        <ItemTemplate>
                            <asp:LinkButton ID="lb_state" runat="server" CommandName="state"></asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="添加时间" SortExpression="gtdate">
                        <ItemTemplate>
                            <asp:Label ID="lbl_date" runat="server" Text='<%# Convert.ToDateTime(Eval("gtdate").ToString()).ToString("yyyy年MM月dd日 HH:mm") %>'> </asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="150px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="操作" ShowHeader="False">
                        <EditItemTemplate>
                            <asp:LinkButton ID="lbtn_update" runat="server" CausesValidation="True" CommandName="Update"
                                Text="更新"></asp:LinkButton>
                            &nbsp;<asp:LinkButton ID="lbtn_clear" runat="server" CausesValidation="False" CommandName="Cancel"
                                Text="取消"></asp:LinkButton>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="lbtn_edit" runat="server" CausesValidation="False" CommandName="Edit"
                                Text="编辑"></asp:LinkButton>
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
    </form>
</body>
</html>
