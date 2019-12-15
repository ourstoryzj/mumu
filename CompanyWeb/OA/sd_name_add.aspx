<%@ Page Language="C#" AutoEventWireup="true" CodeFile="sd_name_add.aspx.cs" Inherits="OA_sd_name_add"
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
                ● 刷单账号管理</div>
            <div class="c_t_desc">
                <ul>
                    <li>（添加或修改账号） </li>
                    <li></li>
                    <li>
                        <asp:Button ID="btn_tolist" runat="server" Text="姓名列表" OnClientClick="window.location.href = 'sd_name_list.aspx';return false;" />
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
                        姓名
                    </td>
                    <td>
                        <asp:TextBox ID="txt_name" runat="server" Width="300"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="color: red;">
                    </td>
                    <td>
                        使用次数
                    </td>
                    <td>
                        共
                        <asp:Literal ID="liter_count" runat="server"></asp:Literal>
                        次
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
                </tr>
                <tr>
                    <td style="color: red;">
                        *
                    </td>
                    <td>
                    </td>
                    <td>
                        <a href="http://www.xingzuo360.cn/xingmingdaquan/" target="_blank">点击查看数据采集网址</a>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <script>
        function to_save() {
            if ($("#txt_name").val() == "") {
                alert("请输入姓名");
                $("#txt_name").focus();
                return false;
            }
            return true;
        }
        function to_save2() {
            if ($("#txt_data").val() == "") {
                alert("请输入批量数据");
                $("#txt_data").focus();
                return false;
            }
            return true;
        }
    </script>
    </form>
</body>
</html>
