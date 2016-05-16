<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="right.aspx.cs" Inherits="Web.Main.right" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="css/commom.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery-1.7.1.js" type="text/javascript"></script>
    
</head>
<body>
    <div class="divsitemap">
        <div class="sitemap">
            <b>位置：</b><asp:SiteMapPath ID="SiteMapPath1" runat="server">
            </asp:SiteMapPath>
        </div>
        <div class="sitemap_line">
        </div>
    </div>
    <form id="form1" runat="server">
    <div class="rightinfo rightinfo_welcome">
        <%--<h2>欢迎进入服务平台</h2>--%>

    </div>
    </form>
</body>
</html>
