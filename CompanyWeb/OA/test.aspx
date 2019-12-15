<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form action="https://shenghuo.alipay.com/send/payment/fill.htm" accept-charset="gbk"
    id="dinggou" method="post" name="dinggou" target="_blank">
    <input name="" type="submit" value="点我" class="btn btn-success" />
    <input name="optEmail" type="hidden" value="18981932715" />
    <%--<input name="memo" type="hidden" value="如果你觉得有用，不妨打赏我一杯咖啡" />--%>
    <input id="payAmount" name="payAmount" type="hidden" value="9.99">
    <input id="title" name="title" type="hidden" value="一键打赏测试" />
    </form>
</body>
</html>
