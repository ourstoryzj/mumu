<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="OA_Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="js/jquery-1.4.3.min.js" type="text/javascript"></script>
</head>
<body class="login_body"  >
    <form id="form1" runat="server">
    <div class="login_bg">
        <div class="login_login">
            <ul>
                <li class="login_acc">
                    <input type="text" id="txt_acc" class="l_t_acc" runat="server" />
                </li>
                <li class="login_pwd">
                    <asp:TextBox ID="txt_pwd" runat="server" CssClass="l_t_acc" TextMode="Password"></asp:TextBox>
                </li>
                <li class="login_state">
                    <div class="l_s_title">
                    </div>
                    <div class="l_s_button2" id="div_state" runat="server">
                    </div>
                </li>
                <li>
                    <div class="l_b_reset">
                    </div>
                    <div class="l_b_ok">
                    </div>
                </li>
            </ul>
        </div>
    </div>
    </form>
</body>
<script type="text/javascript">
    $("#div_state").click(function () {
        var c = $(this).attr("class");
        if (c == "l_s_button") {
            $(this).removeClass("l_s_button");
            $(this).addClass("l_s_button2");
        }
        else {
            $(this).removeClass("l_s_button2");
            $(this).addClass("l_s_button");
        }
    });
    $(".l_b_reset").click(function () {
        $("#txt_acc").val("");
        $("#txt_pwd").val("");
        $("#txt_acc").focus();
    });
    $(".l_b_ok").click(function () {
        var acc = $("#txt_acc").val();
        var pwd = $("#txt_pwd").val();
        if (acc == "") {
            alert("请输入账号！");
            $("#txt_acc").focus();
            return;
        }
        if (pwd == "") {
            alert("请输入密码！");
            $("#txt_pwd").focus();
            return;
        }
        var statu = $("#div_state");
        var s_value = $("#div_state").attr("class") == "l_s_button" ? "1" : "2";
        $.ajax({
            type: "POST",
            url: "handler/login.ashx",
            dataType: "html",
            data: "acc=" + acc + "&pwd=" + pwd + "&statu=" + s_value,
            success: function (msg) {
                msg = eval('(' + msg + ')');
                var obj = msg['info'][0];
                if (obj.statu == "2") {
                    alert(obj.mess);
                    $("#txt_pwd").val("");
                    $("#txt_acc").select();
                    return;
                }
                else {
                    window.location.href = "Default.aspx";
                    retrun;
                }
            },
            error: function (msg) {
                alert("出问题了！");
            }
        });
    });
    
</script>
</html>
