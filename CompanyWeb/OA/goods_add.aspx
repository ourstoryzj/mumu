<%@ Page Language="C#" AutoEventWireup="true" CodeFile="goods_add.aspx.cs" Inherits="OA_goods_add"
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
    <asp:ScriptManager ID="ScriptManager1" runat="server"  EnablePartialRendering="false" >
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="content">
                <div class="c_title">
                    <div class="c_t_name">
                        ● 商品管理</div>
                    <div class="c_t_desc">
                        <ul>
                            <li>（添加或修改问题件信息） </li>
                            <li></li>
                            <li>
                                <asp:Button ID="btn_tolist" runat="server" Text="商品列表" OnClientClick="return to_list();" />
                            </li>
                        </ul>
                        <script>
                            function to_list() {
                                window.location.href = "goods_list.aspx";
                                return false;
                            }
                        </script>
                    </div>
                </div>
                <div style="width: 450px; margin: 20px auto;">
                    <table>
                        <tr>
                            <td style="color: red;">
                                *
                            </td>
                            <td>
                                商品类型
                            </td>
                            <td>
                                <asp:DropDownList ID="ddl_goodstype" runat="server" Width="300">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="color: red;">
                                *
                            </td>
                            <td>
                                商品简称
                            </td>
                            <td>
                                <asp:TextBox ID="txt_name" runat="server" Width="300"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="color: red;">
                            </td>
                            <td>
                                初始价格
                            </td>
                            <td>
                                <asp:TextBox ID="txt_price" runat="server" Width="300"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="color: red;">
                            </td>
                            <td>
                                网供商品URL
                            </td>
                            <td>
                                <asp:TextBox ID="txt_url_yuan" runat="server" Width="300"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="color: red;">
                            </td>
                            <td>
                                淘宝标题
                            </td>
                            <td>
                                <asp:TextBox ID="txt_title" runat="server" Width="300"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="color: red;">
                            </td>
                            <td>
                                淘宝价格
                            </td>
                            <td>
                                <asp:TextBox ID="txt_price1" runat="server" Width="300"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="color: red;">
                            </td>
                            <td>
                                淘宝URL
                            </td>
                            <td>
                                <asp:TextBox ID="txt_url" runat="server" Width="300"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="color: red;">
                            </td>
                            <td>
                                淘宝图片
                            </td>
                            <td style="height: 200px">
                                <div class="div_img">
                                    <a id="a_img1" runat="server" target="_blank">
                                        <table>
                                            <tr>
                                                <td id="div_img1">
                                                    <asp:Image ID="img_tu" runat="server" ImageUrl="~/OA/images/noimg.jpg" />
                                                </td>
                                            </tr>
                                        </table>
                                    </a>
                                </div>
                                <asp:FileUpload ID="fu_img" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td style="color: red;">
                            </td>
                            <td>
                                蘑菇街价格
                            </td>
                            <td>
                                <asp:TextBox ID="txt_price2" runat="server" Width="300"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="color: red;">
                            </td>
                            <td>
                                蘑菇街URL
                            </td>
                            <td>
                                <asp:TextBox ID="txt_url2" runat="server" Width="300"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="color: red;">
                            </td>
                            <td>
                                蘑菇街图片
                            </td>
                            <td style="height: 200px">
                                <div class="div_img">
                                    <a id="a_img2" runat="server" target="_blank">
                                        <table>
                                            <tr>
                                                <td id="div_img2">
                                                    <asp:Image ID="img_tu2" runat="server" ImageUrl="~/OA/images/noimg.jpg" />
                                                </td>
                                            </tr>
                                        </table>
                                    </a>
                                </div>
                                <asp:FileUpload ID="fu_img2" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td style="color: red;">
                            </td>
                            <td>
                                图片状态
                            </td>
                            <td>
                                <asp:DropDownList ID="ddl_state_img" runat="server" Width="300">
                                    <asp:ListItem Text="未传图" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="已传图" Value="2"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="color: red;">
                            </td>
                            <td>
                                上架状态
                            </td>
                            <td>
                                <asp:DropDownList ID="ddl_state_up" runat="server" Width="300">
                                    <asp:ListItem Text="未上架" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="已上架" Value="2"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="color: red;">
                            </td>
                            <td>
                                优化状态
                            </td>
                            <td>
                                <asp:DropDownList ID="ddl_state_yh" runat="server" Width="300">
                                    <asp:ListItem Text="未优化标题" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="已优化标题" Value="2"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="color: red;">
                            </td>
                            <td>
                                重点商品
                            </td>
                            <td>
                                <asp:DropDownList ID="ddl_important" runat="server" Width="300">
                                    <asp:ListItem Text="否" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="是" Value="2"></asp:ListItem>
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
                                上架时间
                            </td>
                            <td>
                                <asp:Label ID="lbl_date_up" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="color: red;">
                            </td>
                            <td>
                                上图时间
                            </td>
                            <td>
                                <asp:Label ID="lbl_date_img" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="color: red;">
                            </td>
                            <td>
                                优化时间
                            </td>
                            <td>
                                <asp:Label ID="lbl_date_yh" runat="server" Text=""></asp:Label>
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
                        alert("请输入买家账号");
                        $("#txt_name").focus();
                        return false;
                    }
                    if ($("#ddl_goodstype").val() == "") {
                        alert("请选择店铺");
                        $("#ddl_goodstype").focus();
                        return false;
                    }
                    return true;
                }
                $(document).ready(function () {
                    $("#txt_price").focus(function () {
                        this.select();
                    })
                    onfocus = "this.select() "
                    $("#txt_price").change(function () {
                        if (!isNaN($("#txt_price").val())) {
                            var p = $("#txt_price").val();
                            $("#txt_price1").val(((parseInt(p) + 20) * 2));
                            $("#txt_price2").val(((parseInt(p) + 30) / 0.7).toFixed(2));
                        }
                        else {
                            alert("初始价格设置失败!");
                            $("#txt_price").focus();
                        }
                    })
                }) 
        
            </script>
            <uc1:loading ID="loading1" runat="server" AssociatedUpdatePanelID1="UpdatePanel1" />
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
