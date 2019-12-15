<%@ Page Language="C#" AutoEventWireup="true" CodeFile="basic_goods_add.aspx.cs"
    Inherits="OA_basic_goods_add" ValidateRequest="false" %>

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
                ● 商品管理</div>
            <div class="c_t_desc">
                <ul>
                    <li>（添加或修改商品信息） </li>
                    <li></li>
                    <li>
                        <asp:Button ID="btn_tolist" runat="server" Text="商品列表" OnClientClick="window.location.href = 'basic_goods_list.aspx';return false;" />
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
                        店铺
                    </td>
                    <td>
                        <asp:DropDownList ID="ddl_dianpu" runat="server" Width="300">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="color: red;">
                        *
                    </td>
                    <td>
                        商品标题
                    </td>
                    <td>
                        <asp:TextBox ID="txt_title" runat="server" Width="300"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="color: red;">
                    </td>
                    <td>
                        商品网址
                    </td>
                    <td>
                        <asp:TextBox ID="txt_url" runat="server" Width="300"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="color: red;">
                        *
                    </td>
                    <td>
                        上架时间
                    </td>
                    <td>
                        <asp:TextBox ID="txt_time" runat="server" Width="300"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td style="color: red;">
                        2016-10-1 00:00
                    </td>
                </tr>
                <tr>
                    <td style="color: red;">
                        *
                    </td>
                    <td>
                        补单方案
                    </td>
                    <td>
                        <asp:DropDownList ID="ddl_order_plan" runat="server" Width="300">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="color: red;">
                        *
                    </td>
                    <td>
                        报名方案
                    </td>
                    <td>
                        <asp:DropDownList ID="ddl_basic_huodong" runat="server" Width="300">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="color: red;">
                    </td>
                    <td>
                        是否重点
                    </td>
                    <td>
                        <asp:DropDownList ID="ddl_key" runat="server" Width="300">
                            <asp:ListItem Text="是" Value="1"></asp:ListItem>
                            <asp:ListItem Text="否" Value="2"></asp:ListItem>
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
                            <asp:ListItem Text="启用" Value="1"></asp:ListItem>
                            <asp:ListItem Text="禁用" Value="2"></asp:ListItem>
                        </asp:DropDownList>
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
            if ($("#txt_time").val() == "") {
                alert("请输入上架时间");
                $("#txt_time").focus();
                return false;
            }

            return true;
        }
     
    </script>
    </form>
</body>
</html>
