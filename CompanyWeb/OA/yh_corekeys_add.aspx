<%@ Page Language="C#" AutoEventWireup="true" CodeFile="yh_corekeys_add.aspx.cs"
    Inherits="OA_yh_corekeys_add" ValidateRequest="false" %>

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
                ● 核心关键词管理</div>
            <div class="c_t_desc">
                <ul>
                    <li>（添加或修改问题件信息） </li>
                    <li></li>
                     <li>
                        <asp:Button ID="btn_tolist" runat="server" Text="核心关键词列表" OnClientClick="window.location.href = 'yh_corekeys_list.aspx';return false;" />
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
                        选择商品类型
                    </td>
                    <td>
                        <asp:DropDownList ID="ddl_goodstype" runat="server" Width="300">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="color: red;">
                    </td>
                    <td>
                        核心关键词
                    </td>
                    <td>
                        <asp:TextBox ID="txt_name" runat="server" Width="300"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="color: red;">
                    </td>
                    <td>
                        排序
                    </td>
                    <td>
                        <asp:TextBox ID="txt_sort" runat="server" Width="300">1000</asp:TextBox>
                    </td>
                </tr>
    
                <tr>
                    <td style="color: red;">
                    </td>
                    <td>
                        售后状态
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
                        时间
                    </td>
                    <td>
                        <asp:Label ID="lbl_date" runat="server" Text=""></asp:Label>
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
                <tr>
                    <td style="color: red;">
                    </td>
                    <td>
                    </td>
                    <td style="color: red;">
                        一行一个核心关键词
                    </td>
                </tr>
                <tr>
                    <td style="color: red;">
                    </td>
                    <td>
                        批量数据
                    </td>
                    <td>
                        <asp:TextBox ID="txt_quickadd" runat="server" Width="300" TextMode="MultiLine" Height="100"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="color: red;">
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="btn_quickadd" runat="server" Text="批量添加" OnClick="btn_quickadd_Click" OnClientClick="return to_save2();" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <script>
        function to_save() {
            if ($("#txt_name").val() == "" ) {
                alert("请输入核心关键词");
                $("#txt_name").focus();
                return false;
            }
            if ($("#ddl_goodstype").val() == "") {
                alert("请选择商品类型");
                $("#ddl_goodstype").focus();
                return false;
            }
            return true;
        }
        function to_save2() {
            if ( $("#txt_quickadd").val() == "") {
                alert("请输入批量核心关键词");
                $("#txt_quickadd").focus();
                return false;
            }
            if ($("#ddl_goodstype").val() == "") {
                alert("请选择商品类型");
                $("#ddl_goodstype").focus();
                return false;
            }
            return true;
        }
    </script>
    </form>
</body>
</html>
