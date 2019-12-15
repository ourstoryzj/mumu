<%@ Page Language="C#" AutoEventWireup="true" CodeFile="sh_problem_add.aspx.cs" Inherits="OA_sh_problem_add"
    ValidateRequest="false" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="control/loading.ascx" TagName="loading" TagPrefix="uc1" %>
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
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="content">
                <div class="c_title">
                    <div class="c_t_name">
                        ● 问题件管理</div>
                    <div class="c_t_desc">
                        <ul>
                            <li>（添加或修改问题件信息） </li>
                            <li></li>
                            <li>
                                <asp:Button ID="btn_toadd" runat="server" Text="售后列表" OnClientClick="window.location.href = 'sh_problem_list.aspx';return false;" />
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
                                买家姓名
                            </td>
                            <td>
                                <asp:TextBox ID="txt_name" runat="server" Width="300"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="color: red;">
                                *
                            </td>
                            <td>
                                买家账号
                            </td>
                            <td>
                                <asp:TextBox ID="txt_account" runat="server" Width="300"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="color: red;">
                            </td>
                            <td>
                                手机号码
                            </td>
                            <td>
                                <asp:TextBox ID="txt_phone" runat="server" Width="300"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="color: red;">
                            </td>
                            <td>
                                订单编号
                            </td>
                            <td>
                                <asp:TextBox ID="txt_ordercode" runat="server" Width="300"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="color: red;">
                            </td>
                            <td>
                                快递电话
                            </td>
                            <td>
                                <asp:TextBox ID="txt_kdphone" runat="server" Width="300"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="color: red;">
                            </td>
                            <td>
                                快递单号
                            </td>
                            <td>
                                <asp:TextBox ID="txt_kdcode" runat="server" Width="300"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="color: red;">
                                *
                            </td>
                            <td>
                                选择店铺
                            </td>
                            <td>
                                <asp:DropDownList ID="ddl_dianpu" runat="server" Width="300">
                                </asp:DropDownList>
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
                                    <asp:ListItem Text="未处理" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="已投诉" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="已处理" Value="3"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="color: red;">
                            </td>
                            <td>
                                售后原因
                            </td>
                            <td>
                                <asp:TextBox ID="txt_yuanyin" runat="server" Width="300" TextMode="MultiLine" Height="100"></asp:TextBox>
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
                                在蘑菇街订"单详情页"和淘宝"交易详情页"ctrl+a所有数据
                            </td>
                        </tr>
                        <tr>
                            <td style="color: red;">
                            </td>
                            <td>
                                大数据
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
                                <asp:Button ID="btn_quickadd" runat="server" Text="快速添加" OnClick="btn_quickadd_Click"
                                    OnClientClick="return to_add_batch();" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <script>
                function to_save() {
                    //            if ($("#txt_name").val() == "") {
                    //                alert("请输入买家姓名");
                    //                $("#txt_name").focus();
                    //                return false;
                    //            }
                    if ($("#txt_account").val() == "") {
                        alert("请输入买家账号");
                        $("#txt_account").focus();
                        return false;
                    }
                    //            if ($("#txt_phone").val() == "") {
                    //                alert("请输入买家手机号码");
                    //                $("#txt_phone").focus();
                    //                return false;
                    //            }
                    //            if ($("#txt_ordercode").val() == "") {
                    //                alert("请输入订单编号");
                    //                $("#txt_ordercode").focus();
                    //                return false;
                    //            }
                    if ($("#ddl_dianpu").val() == "") {
                        alert("请选择店铺");
                        $("#ddl_dianpu").focus();
                        return false;
                    }
                    return true;
                }
                function to_add_batch() {
                    if ($("#txt_quickadd").val() == "") {
                        alert("请输入大数据");
                        $("#txt_quickadd").focus();
                        return false;
                    }
                    return true;
                }
            </script>
            <uc1:loading ID="loading1" runat="server" AssociatedUpdatePanelID1="UpdatePanel1" />
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
