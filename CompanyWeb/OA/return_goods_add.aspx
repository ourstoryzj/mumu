<%@ Page Language="C#" AutoEventWireup="true" CodeFile="return_goods_add.aspx.cs"
    Inherits="OA_return_goods_add" ValidateRequest="false" %>

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
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="content">
                <div class="c_title">
                    <div class="c_t_name">
                        ● 退货管理</div>
                    <div class="c_t_desc">
                        <ul>
                            <li>（添加或修改退货信息） </li>
                            <li></li>
                            <li>
                                <%--<asp:Button ID="btn_tolist" runat="server" Text="退货列表" OnClientClick="window.location.href = 'return_goods_list.aspx';return false;"
                                    TabIndex="1" />--%>
                                <input type="button" value="退货列表" onclick="window.location.href = 'return_goods_list.aspx';return false;" >
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
                                快递公司
                            </td>
                            <td>
                                <asp:DropDownList ID="ddl_courier" runat="server" Width="300">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="color: red;">
                            </td>
                            <td>
                                快递单号
                            </td>
                            <td>
                                <asp:TextBox ID="txt_name" runat="server" Width="300"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="color: red;">
                            </td>
                            <td>
                                备注
                            </td>
                            <td>
                                <asp:TextBox ID="txt_remark" runat="server" Width="300"></asp:TextBox>
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
                        <tr>
                            <td style="color: red;">
                            </td>
                            <td>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="color: red;">
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:Label ID="lbl_message" runat="server" Text="" ForeColor="Red" Font-Bold="true"
                                    Font-Size="X-Large"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <script>
                function to_save() {
                    if ($("#txt_name").val() == "") {
                        alert("请输入快递单号");
                        $("#txt_name").focus();
                        return false;
                    }
                    return true;
                }
                document.onkeydown = function (event) {
                    var e = event || window.event || arguments.callee.caller.arguments[0];
                    if (e && e.keyCode == 27) { // 按 Esc 
                        //要做的事情
                    }
                    if (e && e.keyCode == 113) { // 按 F2 
                        //要做的事情
                    }
                    if (e && e.keyCode == 13) { // enter 键
                        //要做的事情
                        document.getElementById("btn_save").click();
                        event.returnValue = false; //取消回车键的默认操作
                    }
                }; 
            </script>
            <uc1:loading ID="loading1" runat="server" associatedupdatepanelid1="UpdatePanel1" />
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
