<%@ Control Language="C#" AutoEventWireup="true" CodeFile="sign.ascx.cs" Inherits="OA_control_sign" %>
<script src="../js/jquery.min.js" type="text/javascript"></script>
<!-- open win -->
<style type="text/css">
    #show_win
    {
        position: absolute;
        width: 400px;
        height: 130px;
        border: 2px solid #b4d7f8;
        color: #333;
        background-color: #fafafa;
        display: none;
    }
    #load
    {
        position: absolute;
        display: none;
        height: 124px;
        width: 124px; /*height:435px;
        width:580px;*/
    }
    .show_top
    {
        width: 100%;
        background-color: #8dc0ef;
        height: 30px;
        line-height: 30px;
    }
    .show_title
    {
        float: left;
        margin-left: 10px;
        font-weight: bold;
        font-size: 14px;
        *width:100%;
    }
    .show_close
    {
        float: right;
        margin-right: 10px;
        margin-top: 2px;
        width: 25px;
    }
    .dang
    {
        background-color: #f0f1f1;
        width: 100%;
        height: 100%;
        position: absolute;
        top: 0px;
        left: 0px; /*-moz-opacity: 0.8;
        -khtml-opacity: 0.8;*/
        display: none;
    }
    
    .show_content
    {
        width: 100%;
        margin: 10px auto;
        border:0px;
        padding:0px;
        
    }
    .show_content tr
    {
        height: 30px;
        line-height: 30px;
        
    }
</style>
<script type="text/javascript">
    $(document).ready(function () {
        site("show_pro");
    });
    var t;
    function site(d) {
        var w = ($(document).width() - $("#show_win").width()) / 2;
        var h = ($(document).height() - $("#show_win").height()) / 3;
        $("#show_win").css("left", w);
        $("#show_win").css("top", h);
        var w = ($(document).width() - $("#load").width()) / 2;
        var h = ($(document).height() - $("#load").height()) / 2;
        $("#load").css("left", w);
        $("#load").css("top", h);
    }
    function exit() {
        $(".dang").fadeOut("fast");
        $("#show_win").fadeOut("fast");
    }
    function open_jiekou(tt) {
        $(".dang").fadeIn("fast");
        $("#show_win").fadeIn("fast");
        $("#txt_jiekou").select();
        $("#btn_sign_jiekou").attr('onclick', '').unbind('click').click('click', function () {
            $("#load").show();
            if ($("#txt_jiekou").val() == "") {
                alert("请输入签到原因！");
                $("#load").fadeOut("fast");
                return false;
            } 
            to_sign(tt); 
        });
       
    }
    
    function bind_date(dt) {
        var d = new Date(dt);
        return d.getFullYear() + "年" + d.getMonth() + "月" + d.getDate() + "日";
    }
</script>
<div class="dang" style="filter: alpha(opacity=80); opacity: 0.8;">
    &nbsp;
</div>
<div id="show_win">
    <div id="msgs">
    </div>
    <table class="show_top">
        <tr>
            <td class="show_title">
                签到原因
            </td>
            <td class="show_close">
                <img src="images/show_win_close.jpg" onclick="exit();" />
            </td>
        </tr>
    </table>
    <table class="show_content" id="pro" cellpadding="0" cellspacing="0">
        <tr>
            <td align="center">
                <%--<input type="text"style="width: 95%; height: 50px;" />--%>
                <textarea id="txt_jiekou" style="width: 95%; height: 50px;"></textarea>
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-right: 10px;">
                <input type="button" id="btn_sign_jiekou" value="签到" style="width: 50px;" onclick="to_sign();" />
            </td>
        </tr>
    </table>
</div>
<div id="load">
    <img src="images/loading.gif" />
</div>
<!-- open win -->
