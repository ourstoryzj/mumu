<%@ Page Language="C#" AutoEventWireup="true" CodeFile="sd_add_dynamic.aspx.cs" Inherits="OA_sd_add_dynamic"
    ValidateRequest="false" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="control/loading.ascx" TagName="loading" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="js/Calendar.js" type="text/javascript"></script>
    <script src="js/jquery-1.4.3.min.js" type="text/javascript"></script>
    <script src="js/JScript.js" type="text/javascript"></script>
    <style>
        tr
        {
            height: 30px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <%--    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
    <div class="content">
        <div class="c_title">
            <div class="c_t_name">
                ● 动态生成收货信息</div>
            <div class="c_t_desc">
                <ul>
                    <li>（根据系统内部数据生成收货信息） </li>
                    <li></li>
                    <li>
                        <asp:Button ID="btn_tolist" runat="server" Text="刷单列表" OnClientClick="window.location.href = 'sd_list.aspx';return false;" />
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
                        账号信息
                    </td>
                    <td>
                        剩余未使用账号<asp:Label ID="lbl_account" runat="server" ForeColor="Red"></asp:Label>个
                    </td>
                </tr>
                <tr>
                    <td style="color: red;">
                    </td>
                    <td>
                        导出条数
                    </td>
                    <td>
                        <asp:TextBox ID="txt_num" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="color: red;">
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="btn_save" runat="server" Text="生成" OnClientClick="return to_save();"
                            OnClick="btn_save_Click" />
                    </td>
                </tr>
                <tr>
                    <td style="color: red;">
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:HyperLink ID="hl_download" runat="server" Target="_blank"></asp:HyperLink>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <script>
        function to_save() {

            return true;
        }
    </script>
    <%--<uc1:loading ID="loading1" runat="server" AssociatedUpdatePanelID1="UpdatePanel1" />
        </ContentTemplate>
    </asp:UpdatePanel>--%>
    </form>
</body>
</html>
