<%@ Page Language="C#" AutoEventWireup="true" CodeFile="sh_good.aspx.cs" Inherits="OA_sh_good"
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
                ● 基础设置</div>
            <div class="c_t_desc">
                <ul>
                    <li>（时间必须按照规定格式。例如:12:00）添加计划： </li>
                    <li>上午上班时间
                        <asp:TextBox ID="txt_1" runat="server" Width="40"></asp:TextBox>
                    </li>
                    <li>上午下班时间
                        <asp:TextBox ID="txt_2" runat="server" Width="40"></asp:TextBox>
                    </li>
                    <li>下午上班时间
                        <asp:TextBox ID="txt_3" runat="server" Width="40"></asp:TextBox>
                    </li>
                    <li>下午下班时间
                        <asp:TextBox ID="txt_4" runat="server" Width="40"></asp:TextBox>
                    </li>
                    <li>
                        <asp:Button ID="btn_save" runat="server" Text="保存" OnClientClick="return to_save();"
                            OnClick="btn_save_Click" />
                    </li>
                </ul>
            </div>
            <script>
                function to_save() {
                    if ($("#txt_1").val() == "") {
                        alert("请输入上午上班时间");
                        $("#txt_1").select();
                        return false;
                    }
                    if ($("#txt_2").val() == "") {
                        alert("请输入上午下班时间");
                        $("#txt_2").select();
                        return false;
                    }
                    if ($("#txt_3").val() == "") {
                        alert("请输入下午上班时间");
                        $("#txt_3").select();
                        return false;
                    }
                    if ($("#txt_4").val() == "") {
                        alert("请输入下午下班时间");
                        $("#txt_4").select();
                        return false;
                    }
                    return true;
                }
            </script>
        </div>
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" EnableModelValidation="True"
                OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowCommand="GridView1_RowCommand"
                OnRowDataBound="GridView1_RowDataBound" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating"
                DataKeyNames="Id,State">
                <Columns>
                    <asp:TemplateField HeaderText="编号" SortExpression="Id">
                        <ItemTemplate>
                            <asp:Label ID="Label6" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="50" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="上午上班时间" SortExpression="Sign1">
                        <ItemTemplate>
                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("Sign1") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txt_sign1" runat="server" Text='<%# Bind("Sign1") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="上午下班时间" SortExpression="Sign2">
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("Sign2") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txt_sign2" runat="server" Text='<%# Bind("Sign2") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="下午上班时间" SortExpression="Sign3">
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("Sign3") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txt_sign3" runat="server" Text='<%# Bind("Sign3") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="下午下班时间" SortExpression="Sign4">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("Sign4") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txt_sign4" runat="server" Text='<%# Bind("Sign4") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="方案状态" SortExpression="State">
                        <ItemTemplate>
                            <asp:LinkButton ID="lb_state" runat="server" CommandName="state"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="操作" ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                Text="编辑"></asp:LinkButton>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update"
                                Text="更新"></asp:LinkButton>
                            &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel"
                                Text="取消"></asp:LinkButton>
                        </EditItemTemplate>
                        <ItemStyle Width="100" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="SearchAll"
                TypeName="BLL.BasicManager"></asp:ObjectDataSource>
        </div>
    </form>
</body>
</html>
