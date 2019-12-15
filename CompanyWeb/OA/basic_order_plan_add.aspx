<%@ Page Language="C#" AutoEventWireup="true" CodeFile="basic_order_plan_add.aspx.cs" Inherits="OA_basic_order_plan_add"
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
                ● 订单计划管理</div>
            <div class="c_t_desc">
                <ul>
                    <li>（添加或修改订单计划信息） </li>
                    <li></li>
                    <li>
                        <asp:Button ID="btn_tolist" runat="server" Text="订单计划列表" OnClientClick="window.location.href = 'basic_order_plan_list.aspx';return false;" />
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
                        订单计划类型
                    </td>
                    <td>
                        <asp:DropDownList ID="ddl_optype" runat="server">
                            <asp:ListItem Text="淘宝" Value="1"></asp:ListItem>
                            <asp:ListItem Text="蘑菇街" Value="2"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="color: red;">
                    </td>
                    <td>
                        方案名称
                    </td>
                    <td>
                        <asp:TextBox ID="txt_name" runat="server" Width="300"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="color: red;">
                    </td>
                    <td>
                        第一天
                    </td>
                    <td>
                        <asp:TextBox ID="txt_1" runat="server" Width="300"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="color: red;">
                    </td>
                    <td>
                        第二天
                    </td>
                    <td>
                        <asp:TextBox ID="txt_2" runat="server" Width="300"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="color: red;">
                    </td>
                    <td>
                        第三天
                    </td>
                    <td>
                        <asp:TextBox ID="txt_3" runat="server" Width="300"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="color: red;">
                    </td>
                    <td>
                        第四天
                    </td>
                    <td>
                        <asp:TextBox ID="txt_4" runat="server" Width="300"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="color: red;">
                    </td>
                    <td>
                        第五天
                    </td>
                    <td>
                        <asp:TextBox ID="txt_5" runat="server" Width="300"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="color: red;">
                    </td>
                    <td>
                        第六天
                    </td>
                    <td>
                        <asp:TextBox ID="txt_6" runat="server" Width="300"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="color: red;">
                    </td>
                    <td>
                        第七天
                    </td>
                    <td>
                        <asp:TextBox ID="txt_7" runat="server" Width="300"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="color: red;">
                    </td>
                    <td>
                        第八天
                    </td>
                    <td>
                        <asp:TextBox ID="txt_8" runat="server" Width="300"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="color: red;">
                    </td>
                    <td>
                        第九天
                    </td>
                    <td>
                        <asp:TextBox ID="txt_9" runat="server" Width="300"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="color: red;">
                    </td>
                    <td>
                        第十天
                    </td>
                    <td>
                        <asp:TextBox ID="txt_10" runat="server" Width="300"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="color: red;">
                    </td>
                    <td>
                        第十一天
                    </td>
                    <td>
                        <asp:TextBox ID="txt_11" runat="server" Width="300"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="color: red;">
                    </td>
                    <td>
                        第十二天
                    </td>
                    <td>
                        <asp:TextBox ID="txt_12" runat="server" Width="300"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="color: red;">
                    </td>
                    <td>
                        第十三天
                    </td>
                    <td>
                        <asp:TextBox ID="txt_13" runat="server" Width="300"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="color: red;">
                    </td>
                    <td>
                        第十四天
                    </td>
                    <td>
                        <asp:TextBox ID="txt_14" runat="server" Width="300"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="color: red;">
                    </td>
                    <td>
                        备注信息
                    </td>
                    <td>
                        <asp:TextBox ID="txt_remark" runat="server" Width="300" TextMode="MultiLine" Height="100"></asp:TextBox>
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
            </table>
        </div>
    </div>
    <%-- <script>
        function to_save() {
            if ($("#txt_name").val() == "") {
                alert("请输入快递名称");
                $("#txt_name").focus();
                return false;
            }
            return true;
        }
     
    </script>--%>
    </form>
</body>
</html>
