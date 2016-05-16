<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="DDIWebApp.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="padding-top: 40px; padding-left: 100px">
    
    <asp:Button ID="Button1" runat="server" Text="配置列表" onclick="Button1_Click" />&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button2" runat="server" Text="配置信息" onclick="Button2_Click" />&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button3" runat="server" Text="执行日志" onclick="Button3_Click" />

    </div>
    </form>
</body>
</html>
