<%@ Page Language="C#" AutoEventWireup="true" CodeFile="yh_keys_add.aspx.cs"
    Inherits="OA_yh_keys_add" ValidateRequest="false" %>

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
                ● 关键词管理</div>
            <div class="c_t_desc">
                <ul>
                    <li>（添加或修改关键词信息） </li>
                    <li></li>
                     <li>
                        <asp:Button ID="btn_tolist" runat="server" Text="关键词列表" OnClientClick="window.location.href = 'yh_keys_list.aspx';return false;" />
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
                        关键词
                    </td>
                    <td>
                        <asp:TextBox ID="txt_name" runat="server" Width="300"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="color: red;">
                    </td>
                    <td>
                        搜索人数
                    </td>
                    <td>
                        <asp:TextBox ID="txt_sousuorenshu" runat="server" Width="300"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="color: red;">
                    </td>
                    <td>
                        搜索次数
                    </td>
                    <td>
                        <asp:TextBox ID="txt_sousuocishu" runat="server" Width="300"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="color: red;">
                    </td>
                    <td>
                        搜索占比
                    </td>
                    <td>
                        <asp:TextBox ID="txt_sousuozhanbi" runat="server" Width="300"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="color: red;">
                    </td>
                    <td>
                        点击指数
                    </td>
                    <td>
                        <asp:TextBox ID="txt_dianjizhishu" runat="server" Width="300"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="color: red;">
                    </td>
                    <td>
                        商城点击占比
                    </td>
                    <td>
                        <asp:TextBox ID="txt_dianjizhanbi" runat="server" Width="300"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="color: red;">
                    </td>
                    <td>
                        点击率
                    </td>
                    <td>
                        <asp:TextBox ID="txt_dianjilv" runat="server" Width="300"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="color: red;">
                    </td>
                    <td>
                        商品数量
                    </td>
                    <td>
                        <asp:TextBox ID="txt_shangpinshuliang" runat="server" Width="300"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="color: red;">
                    </td>
                    <td>
                        转化率
                    </td>
                    <td>
                        <asp:TextBox ID="txt_zhuanhualv" runat="server" Width="300"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td style="color: red;">
                    </td>
                    <td>
                        直通车出价
                    </td>
                    <td>
                        <asp:TextBox ID="txt_zhitongche" runat="server" Width="300"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td style="color: red;">
                    </td>
                    <td>
                        单个宝贝搜索次数（搜索次数/商品数量）
                    </td>
                    <td>
                        <asp:Label ID="lbl_dangebaobeisousuocishu" runat="server" ></asp:Label>
                    </td>
                </tr>
                 <tr>
                    <td style="color: red;">
                    </td>
                    <td>
                       千个宝贝成交次数（点击指数*转化率/当前宝贝数*1000）
                    </td>
                    <td>
                        <asp:Label ID="lbl_qiangebaobeichengjiaocishu" runat="server" ></asp:Label>
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
                        一行一个关键词
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
                alert("请输入关键词");
                $("#txt_name").focus();
                return false;
            }
            if ($("#txt_sousuorenshu").val() == "") {
                alert("请输入搜索人数");
                $("#txt_sousuorenshu").focus();
                return false;
            }
            if ($("#txt_sousuocishu").val() == "") {
                alert("请输入搜索次数");
                $("#txt_sousuocishu").focus();
                return false;
            }
            if ($("#txt_sousuozhanbi").val() == "") {
                alert("请输入搜索占比");
                $("#txt_sousuozhanbi").focus();
                return false;
            }
            if ($("#txt_dianjizhishu").val() == "") {
                alert("请输入点击指数");
                $("#txt_dianjizhishu").focus();
                return false;
            }
            if ($("#txt_dianjizhanbi").val() == "") {
                alert("请输入点击占比");
                $("#txt_dianjizhanbi").focus();
                return false;
            }
            if ($("#txt_dianjilv").val() == "") {
                alert("请输入点击率");
                $("#txt_dianjilv").focus();
                return false;
            }
            if ($("#txt_shangpinshuliang").val() == "") {
                alert("请输入商品数量");
                $("#txt_shangpinshuliang").focus();
                return false;
            }
            if ($("#txt_zhuanhualv").val() == "") {
                alert("请输入转化率");
                $("#txt_zhuanhualv").focus();
                return false;
            }
            if ($("#txt_zhitongche").val() == "") {
                alert("请输入直通车出价");
                $("#txt_zhitongche").focus();
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
            return true;
        }
    </script>
    </form>
</body>
</html>
