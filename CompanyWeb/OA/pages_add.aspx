<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pages_add.aspx.cs" Inherits="OA_pages_add"
    ValidateRequest="false" %>

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
    <script charset="utf-8" src="kindeditor/kindeditor.js"></script>
    <script charset="utf-8" src="kindeditor/lang/zh_CN.js"></script>
    <script charset="utf-8" src="kindeditor/plugins/code/prettify.js"></script>
    <script>
        KindEditor.ready(function (K) {
            var editor1 = K.create('#txt_context', {
                cssPath: 'kindeditor/plugins/code/prettify.css',
                uploadJson: 'control/upload_json.ashx',
                fileManagerJson: 'control/file_manager_json.ashx',
                allowFileManager: true,
                afterCreate: function () {
                }
            });
            prettyPrint();
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="content">
        <div class="c_title">
            <div class="c_t_name">
                ● 资料管理</div>
            <div class="c_t_desc">
                <ul>
                    <li>（添加或修改页面） </li>
                    <li></li>
                    <li>
                        <asp:Button ID="btn_tolist" runat="server" Text="页面列表" OnClientClick="window.location.href = 'pages_list.aspx';return false;" />
                    </li>
                </ul>
            </div>
        </div>
        <div style="width: 800px; margin: 20px auto;">
            <table>
                <tr>
                    <td style="color: red;">
                    </td>
                    <td>
                        资料类型
                    </td>
                    <td>
                        <asp:DropDownList ID="ddl_pagestype" runat="server" Width="300">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="color: red;">
                    </td>
                    <td>
                        标题名称
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
                        <textarea id="txt_context" cols="100" rows="8" style="width: 700px; height: 500px;
                            visibility: hidden;" runat="server"></textarea>
                    </td>
                </tr>
                <tr>
                    <td style="color: red;">
                    </td>
                    <td>
                        添加时间
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
            </table>
        </div>
    </div>
    <script>
        function to_save() {
            if ($("#txt_name").val() == "") {
                alert("请输入标题名称");
                $("#txt_name").focus();
                return false;
            }
            return true;
        }
     
    </script>
    </form>
</body>
</html>
