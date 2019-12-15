<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pages.aspx.cs" Inherits="OA_pages_add"
    ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="js/Calendar.js" type="text/javascript"></script>
    <script src="js/jquery-1.4.3.min.js" type="text/javascript"></script>
    <style>
        div,p,span
        {
            font-size: 16px;
            line-height:30px;
        }
        
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="content">
        <div class="c_title">
            <div class="c_t_name">
                ●
                <asp:Label ID="lbl_name" runat="server" Text=""></asp:Label></div>
            <div class="c_t_desc">
                <ul>
                    <li>
                        <asp:Label ID="lbl_date" runat="server"></asp:Label></li>
                    <li></li>
                </ul>
            </div>
        </div>
        <asp:Literal ID="liter_context" runat="server"></asp:Literal>
    </div>
    </form>
</body>
</html>
