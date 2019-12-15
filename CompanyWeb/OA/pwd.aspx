<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pwd.aspx.cs" Inherits="OA_pwd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="js/jquery.min.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="content">
        <div class="c_title">
            <div class="c_t_name">
                ● 修改密码</div>
        </div>
        <br />
        <table>
            <tr>
                <td>
                    原始密码
                </td>
                <td>
                    <asp:TextBox ID="txt_pwd" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    新密码
                </td>
                <td>
                    <asp:TextBox ID="txt_pwd2" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    确认密码
                </td>
                <td>
                    <asp:TextBox ID="txt_pwd3" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Button ID="btn_save" runat="server" Text="保存" OnClientClick=" return to_save();"
                        OnClick="btn_save_Click" />
                </td>
            </tr>
        </table>
    </div>
    <script>

        function to_save() {
            if ($("#txt_pwd").val() == "") {
                alert("请输入原始密码");
                $("#txt_pwd").select();
                return false;
            }
            if ($("#txt_pwd2").val() == "") {
                alert("请输入新密码");
                $("#txt_pwd2").select();
                return false;
            }
            if ($("#txt_pwd3").val() == "") {
                alert("请输入确认密码");
                $("#txt_pwd3").select();
                return false;
            }
            if ($("#txt_pwd3").val() != $("#txt_pwd2").val()) {
                alert("两次输入的密码不相同，亲重新输入");
                $("#txt_pwd3").val("");
                $("#txt_pwd2").select();
                return false;
            }
            return true;
        }
    </script>
    </form>
</body>
</html>
