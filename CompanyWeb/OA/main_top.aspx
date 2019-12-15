<%@ Page Language="C#" AutoEventWireup="true" CodeFile="main_top.aspx.cs" Inherits="OA_main_top" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="js/jquery-1.4.3.min.js" type="text/javascript"></script>
    <script src='js/tagscloud.js' type="text/javascript"></script>
    <style>
        img
        {
            cursor: pointer;
        }
    </style>
    <style type="text/css">
        body
        {
            font-family: "微软雅黑" , Arial, sans-serif;
        }
        #main
        {
            border: none;
            background: none;
        }
        body, ul, li, h1, h2, h3, p, form
        {
            margin: 0;
            padding: 0;
        }
        body
        {
            background: #fbfbfb;
            color: #444;
            font-size: 12px;
        }
        a
        {
            color: #444;
            text-decoration: none;
        }
        a:hover
        {
            color: red;
        }
        
        /* tagscloud */
        #tagscloud
        {
            width: 280px;
            height: 60px;
            position: relative;
            font-size: 14px;
            color: #333;
            text-align: left;
        }
        #tagscloud a
        {
            position: absolute;
            top: 0px;
            left: 0px;
            color: #333;
            font-family: Arial;
            text-decoration: none;
            margin: 0 10px 15px 0;
            line-height: 18px;
            text-align: center;
            font-size: 12px;
            padding: 1px 5px;
            display: inline-block;
            border-radius: 3px;
        }
        #tagscloud a.tagc1
        {
            background: #666;
            color: #fff;
        }
        #tagscloud a.tagc2
        {
            background: #F16E50;
            color: #fff;
        }
        #tagscloud a.tagc5
        {
            background: #006633;
            color: #fff;
        }
        #tagscloud a:hover
        {
            color: #fff;
            background: #0099ff;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <%--<img src="images/logo.jpg" />--%>
    <div class="top_logo">
        <div id="tagscloud">
            <a href="sh_problem_list.aspx?state=1" class="tagc1" target="mainFrame">待处理售后</a>
            <a href="sh_problem_list.aspx" class="tagc2" target="mainFrame">全部售后列表</a> <a href="sh_problem_add.aspx"
                class="tagc5" target="mainFrame">添加售后</a> <a href="fanxian_list.aspx?state=1" class="tagc2"
                    target="mainFrame">待处理返现<a> <a href="fanxian_add.aspx" class="tagc2" target="mainFrame">
                        添加返现</a> <a href="fanxian_add_batch.aspx" class="tagc1" target="mainFrame">批量添加返现</a>
                        <a href="sd_account_add.aspx" class="tagc2" target="mainFrame">添加刷单账号</a> <a href="sd_account_list.aspx"
                            class="tagc5" target="mainFrame">刷单账号列表</a> <a href="sd_pingjia_add.aspx" class="tagc2"
                                target="mainFrame">添加评语</a> <a href="sd_add_import.aspx" class="tagc2" target="mainFrame">
                                    添加导入刷单</a> <a href="sh_problem_list.aspx?state=1" class="tagc1" target="mainFrame">待处理售后</a>
                        <a href="sh_problem_list.aspx" class="tagc2" target="mainFrame">全部售后列表</a> <a href="sh_problem_add.aspx"
                            class="tagc5" target="mainFrame">添加售后</a> <a href="fanxian_list.aspx?state=1" class="tagc2"
                                target="mainFrame">待处理返现<a> <a href="fanxian_add.aspx" class="tagc2" target="mainFrame">
                                    添加返现</a> <a href="fanxian_add_batch.aspx" class="tagc1" target="mainFrame">批量添加返现</a>
                                    <a href="sd_account_add.aspx" class="tagc2" target="mainFrame">添加刷单账号</a> <a href="sd_account_list.aspx"
                                        class="tagc5" target="mainFrame">刷单账号列表</a> <a href="sd_pingjia_add.aspx" class="tagc2"
                                            target="mainFrame">添加评语</a> <a href="sd_add_import.aspx" class="tagc2" target="mainFrame">
                                                添加导入刷单</a>
        </div>
    </div>
    <div class="top_use">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:TextBox ID="txt_shouhou" runat="server"></asp:TextBox>
                <asp:Button ID="btn_toadd" runat="server" Text="查询退货" OnClientClick="return to_return_goods();" />
                <div style="display: none">
                    (快速处理问题返现)关键词
                    <asp:TextBox ID="txt_key" runat="server"></asp:TextBox>
                    <asp:Button ID="btn_do" runat="server" Text="处理" OnClick="btn_do_Click" OnClientClick="return to_do();" />
                    <script>
                        function to_do() {
                            var key = $("#txt_key").val();
                            if (key == "") {
                                alert("请输入关键词");
                                $("#txt_key").focus();
                                return false;
                            }
                            return true;
                        }
                        $("input:text").click(function () {
                            $(this).select();
                        });
                        function to_return_goods() {
                            var key = $("#txt_shouhou").val();
                            if (key == "") {
                                alert("请输入退货信息");
                                $("#txt_shouhou").focus();
                                return false;
                            }
                            window.parent.mainFrame.location.href = 'return_goods_list.aspx?key=' + key;
                            //window.location.href = 'return_goods_list.aspx?key=' + key;
                            return false;
                        }
                    </script>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <%--   <img src="images/canceled.jpg" onclick="to_exit(1);" />
        <img src="images/exit.jpg" onclick="to_exit(2);" />
        <script>
            function to_exit(t) {
                if (t == 1) {
                    if (!confirm("确定要注销么？")) {
                        return;
                    }
                }
                else if (t == 2) {
                    if (!confirm("确定要退出么？")) {
                        return;
                    }
                }
                if (t == 1||t==2) {
                    $.ajax({
                        type: "post",
                        url: "handler/top.ashx",
                        dataType: "html",
                        success: function (msg) {
                            if (t == 1) {
                                window.parent.location.href = window.parent.location.href;
                            }
                            else if (t == 2) {
                                window.opener = null;
                                window.open("", "_self");
                                window.close();
                            }
                        },
                        error: function () {
                            alert("出错");
                            return;
                        }
                    });
                }
            }
        </script>--%>
    </div>
    </form>
</body>
</html>
