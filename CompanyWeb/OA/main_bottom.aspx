<%@ Page Language="C#" AutoEventWireup="true" CodeFile="main_bottom.aspx.cs" Inherits="OA_main_bottom" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    
    <script src="js/jquery-1.4.3.min.js"></script>
    <script src="js/Date.js"></script>
</head>
<style>
    body
    {
        background-color: #abdeff;
    }
    #bottom_div_state
    {
        margin-top:7px;
        margin-bottom:10px;
        font-weight: bold;
        color: #333;
    }
    #bottom_div_name
    {
        margin-top:7px;
        margin-bottom:10px;
        font-weight: bold;
        color: #333;
    }
</style>
<body>
    <form id="form1" runat="server">
    <div id="bottom_div_state">
    </div>
    <div id="bottom_div_name">
        斯蒂芬斯蒂芬
    </div>
    </form>
</body>
<script>
    setDate();
    function setDate() {
        var myDate = new Date();
        var Week = myDate.DatePart('w');
        var now = CurentTime();
        $("#bottom_div_state").text(now + " " + "星期" + Week);
        setTimeout(function () {
            setDate();
        }, 1000);
    }
</script>
</html>
