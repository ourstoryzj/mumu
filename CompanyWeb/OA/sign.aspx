<%@ Page Language="C#" AutoEventWireup="true" CodeFile="sign.aspx.cs" Inherits="OA_sign" %>

<%@ Register Src="control/sign.ascx" TagName="sign" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="js/jquery-1.4.3.min.js" type="text/javascript"></script>
</head>
<body onload="to_bind(); ">
    <form id="form1" runat="server">
    <uc1:sign ID="sign1" runat="server" />
    <div class="content">
        <div class="c_title">
            <div class="c_t_name">
                ● 今日签到</div>
            <div class="c_t_desc">
                <ul>
                    <li class="c_t_d_1"></li>
                    <li>正常</li>
                    <li class="c_t_d_2"></li>
                    <li>非正常签到</li>
                    <li class="c_t_d_3"></li>
                    <li>已签</li>
                </ul>
            </div>
        </div>
        <div class="c_sign">
            <img id="img_1" src="images/sign_1_1.jpg" runat="server" />
            <img id="img_2" src="images/sign_1_2.jpg" runat="server" />
            <img id="img_3" src="images/sign_1_3.jpg" runat="server" />
            <img id="img_4" src="images/sign_1_4.jpg" runat="server" />
        </div>
    </div>
    <script>
        function to_bind() {
            $(".dang").show();
            $("#load").show();
            $.ajax({
                url: "handler/sign.ashx",
                dataType: "html",
                data: "fun=to_bind",
                type: "Post",
                contentType: "application/x-www-form-urlencoded; charset=utf-8",
                complete: function () { $("#load").fadeOut("fast"); $(".dang").fadeOut("fast"); }, //AJAX请求完成时隐藏loading提示
                success: function (msg) {
                    msg = eval('(' + msg + ')');
                    var obj = msg['Table'][0];
                    var newclick;
                    //s1
                    if (obj.s1 == "1") {
                        $("#img_1").attr("src", "images/sign_3_1.jpg");
                        $('#img_1').unbind('click', '');
                    }
                    else {
                        $("#img_1").attr("src", "images/sign_1_1.jpg");
                        if (obj.s1_s == "2") {
                            $('#img_1').attr('onclick', '').unbind('click').click(function () { alert('请填写迟到原因！'); open_jiekou('1'); });
                            $("#img_1").attr("src", "images/sign_2_1.jpg");
                        }
                        else {
                            $("#img_1").attr("onclick", "to_sign(1);");
                        }
                    }


                    //s2
                    if (obj.s2 == "1") {
                        $("#img_2").attr("src", "images/sign_3_2.jpg");
                        $('#img_2').unbind('click', '');
                    }
                    else {
                        $("#img_2").attr("src", "images/sign_1_2.jpg");
                        if (obj.s2_s == "2" || obj.s1_s == "2") {
                            $('#img_2').attr('onclick', '').unbind('click').click(function () { alert('请填写早退原因！'); open_jiekou('2'); });
                            $("#img_2").attr("src", "images/sign_2_2.jpg");
                        }
                        else {
                            $("#img_2").attr("onclick", "to_sign(2);");
                        }
                    }


                    //s3
                    if (obj.s3 == "1") {
                        $("#img_3").attr("src", "images/sign_3_3.jpg");
                        $('#img_3').unbind('click', '');
                    }
                    else {
                        $("#img_3").attr("src", "images/sign_1_3.jpg");
                        if (obj.s3_s == "2" || obj.s2_s == "2") {
                            $('#img_3').attr('onclick', '').unbind('click').click(function () { alert('请填写迟到原因！'); open_jiekou('3'); });
                            $("#img_3").attr("src", "images/sign_2_3.jpg");
                        }
                        else {
                            $("#img_3").attr("onclick", "to_sign(3);");
                        }
                    }


                    //s4
                    if (obj.s4 == "1") {
                        $("#img_4").attr("src", "images/sign_3_4.jpg");
                        $('#img_4').unbind('click', '');
                    }
                    else {
                        $("#img_4").attr("src", "images/sign_1_4.jpg");
                        if (obj.s4_s == "2" || obj.s3_s == "2") {
                            $('#img_4').attr('onclick', '').unbind('click').click(function () { alert('请填写早退原因！'); open_jiekou('4'); });
                            $("#img_4").attr("src", "images/sign_2_4.jpg");
                        }
                        else {
                            $("#img_4").attr("onclick", "to_sign(4);");
                        }
                    }
                },
                error: function (mes) {
                    alert("请联系张建解决问题");
                }
            });
        }
    </script>
    <script>
        function to_sign(t) {
            $("#load").show();
            var jiekou = $("#txt_jiekou").val();
            $.ajax({
                url: "handler/sign.ashx",
                dataType: "html",
                data: "fun=to_add&type=" + t + "&jiekou=" + jiekou,
                type: "Post",
                complete: function () { $("#load").fadeOut("fast"); }, //AJAX请求完成时隐藏loading提示
                success: function (mes) {
                    if (mes == 1) {
                        alert("签到成功");
                        to_bind();
                        exit();
                    }
                    else {
                        alert("签到失败");
                    }
                },
                error: function (mes) {
                    alert("操作失败");
                }
            });
        }
    </script>
    </form>
</body>
</html>
