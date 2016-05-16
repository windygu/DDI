<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsersLogin.aspx.cs" Inherits="DDIWebApp.UsersLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>DDI数据中心</title>
<link href="css/commom.css" rel="stylesheet" type="text/css" />
<script  type="text/javascript" src="js/jquery-1.7.1.js"></script>
</head>
<body>
   <div id="mainBody">
      <div id="cloud1" class="cloud"></div>
      <div id="cloud2" class="cloud"></div>
    </div> 
    <div class="logintop">
    <div class="wrap"><img src="images/login_logo.jpg"  /></div>       
   <!-- <ul>
    <li><a href="#">回首页</a></li>
    </ul>-->    
    </div>
   
    <div class="loginbody">
    
   <div class="loginbody_bg">
   <div class="wrap">    
    <div class="loginbox">
    <div class="loginbox_tit">DDI 用户登录</div>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <ul>
            <li><asp:TextBox ID="txtname" runat="server" class="loginuser login_input" value="" onclick="JavaScript:this.value=''"></asp:TextBox> </li>
            <li><asp:TextBox ID="txtpwd" runat="server" CssClass="loginpwd login_input" TextMode="Password" value="" onclick="JavaScript:this.value=''"></asp:TextBox>
            </li>
            <li class="login-memory">
            <table width="312" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="20"><%--<label class="memory-account"><input name="" type="checkbox" value="" class="cbx"/></label>--%></td><td width="100"><%--<span class="remember">记住帐号</span>--%></td>
    <td><%--<a class="forget-password" href="/index.php/reset_pass">忘记密码？</a>--%></td>
  </tr>
</table>
            </li>
            <li>
             <img src="./checkcode.ashx" onclick="this.src='./checkcode.ashx?rand='+Math.random()" style="cursor: pointer" title="点击重新获取验证码" alt="" align="absmiddle" />
            <asp:TextBox ID="txtcheckcode" runat="server" CssClass="logincode" MaxLength="4"></asp:TextBox>		   
             </li>
             <li><asp:Button ID="ImgSubmit" runat="server" CssClass="loginbtn" Text="登 录" OnClientClick="$(this).val('登录验证中...').attr('disable','disabled')"  OnClick="ImgSubmit_Click" /></li>
            </ul>
        </ContentTemplate>
    </asp:UpdatePanel>
</form>	
   
    </div>
    </div>
    </div>
    </div>
    
    
    
    <div class="loginbm">版权所有  2015  华润医药商业集团</div>
</body>
</html>
