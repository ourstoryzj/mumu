<%@ Page Language="C#" AutoEventWireup="true" CodeFile="fanxian_add.aspx.cs" Inherits="OA_fanxian_add"
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
                        ● 返现管理</div>
                    <div class="c_t_desc">
                        <ul>
                            <li>（添加或修改问返现） </li>
                            <li></li>
                            <li>
                                <asp:Button ID="btn_tolist" runat="server" Text="返现列表" OnClientClick="window.location.href = 'fanxian_list.aspx';return false;" />
                            </li>
                        </ul>
                    </div>
                </div>
                <div style="width: 450px; height: 650px; margin: 50px auto;">
                    <table>
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
                                *
                            </td>
                            <td>
                                支付宝账号
                            </td>
                            <td>
                                <asp:TextBox ID="txt_zhifubao" runat="server" Width="300"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="color: red;">
                                *
                            </td>
                            <td>
                                返现金额
                            </td>
                            <td>
                                <asp:TextBox ID="txt_num" runat="server" Width="300">2</asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="color: red;">
                            </td>
                            <td>
                                返现状态
                            </td>
                            <td>
                                <asp:DropDownList ID="ddl_state" runat="server" Width="300">
                                    <asp:ListItem Text="未返现" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="已返现" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="有问题" Value="3"></asp:ListItem>
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
                                登记时间
                            </td>
                            <td>
                                <asp:Label ID="lbl_date1" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="color: red;">
                            </td>
                            <td>
                                返现时间
                            </td>
                            <td>
                                <asp:Label ID="lbl_date2" runat="server" Text=""></asp:Label>
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
                    if ($("#ddl_dianpu").val() == "") {
                        alert("请选择店铺");
                        $("#ddl_dianpu").focus();
                        return false;
                    }
                    if ($("#txt_account").val() == "") {
                        alert("请输入买家账号");
                        $("#txt_account").focus();
                        return false;
                    }
                    if ($("#txt_zhifubao").val() == "") {
                        alert("请输入买家支付宝");
                        $("#txt_zhifubao").focus();
                        return false;
                    }
                    if ($("#txt_num").val() == "") {
                        alert("请输入返现金额");
                        $("#txt_num").focus();
                        return false;
                    }

                    return true;
                }
            </script>
            <uc1:loading id="loading1" runat="server" associatedupdatepanelid1="UpdatePanel1" />
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
