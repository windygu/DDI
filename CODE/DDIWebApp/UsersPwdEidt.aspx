<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsersPwdEidt.aspx.cs" Inherits="DDIWebApp.UsersPwdEidt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>用户密码修改</title>
    <link href="../css/commom.css" rel="stylesheet" type="text/css" />
   <script type="text/javascript">
       if (window.top == window)
           window.top.location = "main.html";
    </script>
</head>
<body>
    <div class="divsitemap">
        <div class="sitemap">
            <asp:SiteMapPath ID="SiteMapPath1" runat="server">
            </asp:SiteMapPath>
        </div>
        <div class="sitemap_line">
        </div>
    </div>
    <form id="form1" runat="server">
        <div class="formbody">
            <table class="tableTwo">
                <tr>
                    <td align="right">用户名</td>
                    <td align="left">
                        <asp:TextBox ID="txtloginname" runat="server" CssClass="Ctext" MaxLength="50"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">原密码</td>
                    <td align="left">
                        <asp:TextBox ID="txtloginpwd" runat="server" CssClass="Ctext" MaxLength="50" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">新密码</td>
                    <td align="left">
                        <asp:TextBox ID="txtnewpwd" runat="server" CssClass="Ctext" MaxLength="100" TextMode="Password"></asp:TextBox>
                    </td>
                    
                <tr>
                    <td align="right">确认密码</td>
                    <td align="left">
                        <asp:TextBox ID="txtnewpwd1" runat="server" CssClass="Ctext" MaxLength="100" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr style="height: 50px;">
                    <td colspan="4" align="center">&nbsp;&nbsp;
                     <asp:Button ID="btnSave" runat="server" Text="保 存" class="scbtn" OnClick="btnSave_Click"></asp:Button>&nbsp;&nbsp;
                    </td>
                    
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
