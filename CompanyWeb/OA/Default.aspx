<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="OA_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<frameset rows="60,10,*,25" cols="*" framespacing="0"  border="0" bordercolor="#47b8ff" >
  <frame src="main_top.aspx" name="topFrame" scrolling="No"  noresize="noresize"  id="topFrame" title="topFrame"  />
  <frame src="main_top_fenge.html" name="top_fengeFrame" scrolling="No"  noresize="noresize"  id="top_fengeFrame" title="top_fengeFrame"  />
  <frameset cols="234,8,*" frameborder="no" border="0" framespacing="0">
        <frame src="main_left.html" name="leftFrame"  id="leftFrame" />
        <frame src="main_left_fenge.html" name="left_fengeFrame" scrolling="No" noresize="noresize" id="left_fengeFrame" />
        <frame src="index.aspx " name="mainFrame" id="mainFrame" />
    </frameset>
  <frame src="main_bottom.html" name="bottomFrame" scrolling="No"  noresize="noresize" id="bottomFrame" title="bottomFrame" />
</frameset>
<noframes>
<body>
</body>
</html>
