<%@ Page Language="C#" AutoEventWireup="true" CodeFile="副本 sign.aspx.cs" Inherits="sign" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="js/jquery-1.4.3.min.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
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
            <img id="img_1" src="image/sign_1_1.jpg" onclick="to_sign(1);" runat="server" />
            <img id="img_2" src="image/sign_1_2.jpg" onclick="to_sign(2);" runat="server" />
            <img id="img_3" src="image/sign_1_3.jpg" onclick="to_sign(3);" runat="server" />
            <img id="img_4" src="image/sign_1_4.jpg" onclick="to_sign(4);" runat="server" />
        </div>
        <div>
            <asp:TextBox ID="txt_info" runat="server" TextMode="MultiLine" Width="300" Height="100"></asp:TextBox>
        </div>
    </div>
    </form>
    <script>
        function to_sign(t) {
            var btn;
            if (t == 1) {
                img = $("#img_1");
            }
            if (t == 2) {
                img = $("#img_2");
            }
            if (t == 3) {
                img = $("#img_3");
            }
            if (t == 4) {
                img = $("#img_4");
            }

            $.ajax({
                url: "handler/sign.ashx",
                dataType: "html",
                data: "type=" + t,
                type: "Post",
                success: function (mes) {
                    if (mes == 1) {
                        if (t == 1) {
                            img.attr("src", "image/sign_3_1.jpg");
                            $("#img_2").attr("src", "image/sign_1_2.jpg");
                        }
                        else if (t == 2) {
                            img.attr("src", "image/sign_3_2.jpg");
                            $("#img_3").attr("src", "image/sign_1_3.jpg");
                        }
                        else if (t == 3) {
                            img.attr("src", "image/sign_3_3.jpg");
                            $("#img_4").attr("src", "image/sign_1_4.jpg");
                        }
                        else if (t == 4) {
                            img.attr("src", "image/sign_3_4.jpg");
                        }
                        img.attr("onclick", "");
                        alert("签到成功");
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
</body>
</html>
