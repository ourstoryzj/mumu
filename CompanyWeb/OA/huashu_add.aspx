<%@ Page Language="C#" AutoEventWireup="true" CodeFile="huashu_add.aspx.cs" Inherits="OA_huashu_add"
    ValidateRequest="false" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="js/Calendar.js" type="text/javascript"></script>
    <script src="js/jquery-1.4.3.min.js" type="text/javascript"></script>
    <style>
        tr
        {
            height: 30px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="content">
        <div class="c_title">
            <div class="c_t_name">
                ● 话术管理</div>
            <div class="c_t_desc">
                <ul>
                    <li>（添加或修改话术） </li>
                    <li></li>
                    <li>
                        <asp:Button ID="btn_tolist" runat="server" Text="话术列表" OnClientClick="window.location.href = 'huashu_list.aspx';return false;" />
                    </li>
                </ul>
            </div>
        </div>
        <div style="width: 450px; margin: 20px auto;">
            <table>
                <tr>
                    <td style="color: red;">
                    </td>
                    <td>
                        话术类型
                    </td>
                    <td>
                        <asp:DropDownList ID="ddl_type" runat="server" Width="300">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="color: red;">
                    </td>
                    <td>
                        话术标题
                    </td>
                    <td>
                        <asp:TextBox ID="txt_title" runat="server" Width="300"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="color: red;">
                    </td>
                    <td>
                        话术内容
                    </td>
                    <td>
                        <asp:TextBox ID="txt_context" runat="server" Width="300"  Height="300px" 
                            TextMode="MultiLine"   ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="color: red;">
                    </td>
                    <td>
                        话术排序
                    </td>
                    <td>
                        <asp:TextBox ID="txt_sort" runat="server" Width="300px" >100</asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="color: red;">
                    </td>
                    <td>
                        点击次数
                    </td>
                    <td>
                        <asp:TextBox ID="txt_count" runat="server" Width="300"  >0</asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="color: red;">
                    </td>
                    <td>
                        状态
                    </td>
                    <td>
                        <asp:DropDownList ID="ddl_state" runat="server" Width="300">
                            <asp:ListItem Text="正常" Value="1"></asp:ListItem>
                            <asp:ListItem Text="禁用" Value="2"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="color: red;">
                    </td>
                    <td>
                        录入时间
                    </td>
                    <td>
                        <asp:Literal ID="liter_date" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td style="color: red;">
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="btn_save" runat="server" Text="保存" OnClientClick="return to_save();"
                            OnClick="btn_save_Click" />
                    </td>
                </tr>
             <%--   <tr>
                    <td style="color: red;">
                    </td>
                    <td>
                        批量数据
                    </td>
                    <td>
                        <asp:TextBox ID="txt_data" runat="server" Width="300" TextMode="MultiLine" Height="100"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="color: red;">
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="btn_save2" runat="server" Text="批量保存" OnClientClick="return to_save2();"
                            OnClick="btn_save2_Click" />
                    </td>
                </tr>--%>
            </table>
        </div>
    </div>
    <script>
        function to_save() {
            if ($("#txt_context").val() == "") {
                alert("请输入评语");
                $("#txt_context").focus();
                return false;
            }
            return true;
        }
//        function to_save2() {
//            if ($("#txt_context").val() == "") {
//                alert("请输入批量数据");
//                $("#txt_context").focus();
//                return false;
//            }
//            return true;
//        }
    </script>
    </form>
</body>
</html>
