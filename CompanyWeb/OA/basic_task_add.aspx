<%@ Page Language="C#" AutoEventWireup="true" CodeFile="basic_task_add.aspx.cs" Inherits="OA_basic_order_record_add"
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
                ● 工作安排</div>
            <div class="c_t_desc">
                <ul>
                    <li>（添加或修改工作安排） </li>
                    <li></li>
                    <li>
                        <asp:Button ID="btn_tolist" runat="server" Text="任务列表" OnClientClick="window.location.href = 'basic_task_list.aspx';return false;" />
                    </li>
                </ul>
            </div>
        </div>
        <div style="width: 450px; margin: 20px auto;">
            <table>
                <tr>
                    <td style="color: red;">
                        *
                    </td>
                    <td>
                        任务标题
                    </td>
                    <td>
                        <asp:TextBox ID="txt_title" runat="server" Width="300"></asp:TextBox>
                    </td>
                </tr>
 <tr>
                    <td style="color: red;">
                    </td>
                    <td>
                        重复任务
                    </td>
                    <td>
                        <asp:DropDownList ID="ddl_chongfu" runat="server" Width="300">
                            <asp:ListItem Text="无" Value="0"></asp:ListItem>
                            <%--<asp:ListItem Text="工作中" Value="2"></asp:ListItem>--%>
                            <asp:ListItem Text="每天" Value="1"></asp:ListItem>
                            <asp:ListItem Text="每月" Value="2"></asp:ListItem>
                            <asp:ListItem Text="每年" Value="3"></asp:ListItem>
                        </asp:DropDownList>
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
                            <asp:ListItem Text="未处理" Value="1"></asp:ListItem>
                            <%--<asp:ListItem Text="工作中" Value="2"></asp:ListItem>--%>
                            <asp:ListItem Text="已完成" Value="2"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="color: red;">
                    </td>
                    <td>
                        执行时间
                    </td>
                    <td>
                        <%-- <asp:Label ID="lb_date" runat="server" Text=""></asp:Label>--%>
                        <asp:TextBox ID="txt_date1" runat="server" Width="100"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="color: red;">
                    </td>
                    <td>
                        任务内容
                    </td>
                    <td>
                        <asp:TextBox ID="txt_remark" runat="server" Width="300" TextMode="MultiLine" Height="100"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="color: red;">
                    </td>
                    <td>
                        保存时间
                    </td>
                    <td>
                        <asp:Label ID="lb_date" runat="server" Text=""></asp:Label>
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
    <script>
        function to_save() {
            if ($("#txt_title").val() == "") {
                alert("请输入商品标题");
                $("#txt_title").focus();
                return false;
            }


            return true;
        }
     
    </script>
    </form>
</body>
</html>
