<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="top.aspx.cs" Inherits="Web.Main.top" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>无标题文档</title>
    <link href="css/commom.css" rel="stylesheet" type="text/css" />
     <script type="text/javascript" src="js/jquery-1.7.1.js"></script>
    <script type="text/javascript">
    $(function(){	
        //顶部导航切换
        $(".nav li a").click(function(){
            $(".nav li a.selected").removeClass("selected")
            $(this).addClass("selected");
        })
    })

    jQuery(document).ready(function () {
        $(".nav li a").eq(0).children(":first").click();
    });
    </script>
    <script type="text/javascript">
        if (window.top == window)
            window.top.location = "Default.html";
    </script>
   
</head>


<body style="background:url(images/topbg.gif) repeat-x;">
    <form id="Form1" method="post" runat="server"> 
    <div class="topleft">
    <a href="main.html" target="_parent"><img src="images/logo.png" title="系统首页" alt="" /></a>
    </div>
    <ul class="nav">
        <asp:Repeater ID="RPT_TopMenu" runat="server">
            <ItemTemplate>
                <li >
                <a href="left.aspx?menuid=<%#Eval("MenuId") %>" target="leftFrame">
                
                <h2><%#Eval("MenuName") %></h2></a>
                </li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
                                               
  <div class="topright">
  <ul>  
    <li><asp:Label ID="lbl_org" runat="server" Text="" ForeColor="White"></asp:Label></li>
    <li><asp:Label ID="lbl_name" runat="server" Text="" ForeColor="White"></asp:Label></li>
    <li><a href="UsersPwdEidt.aspx" target="rightFrame">修改密码</a></li>
    <li><asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">退出</asp:LinkButton></li>
      
    </ul>
     
    </div>
</form>
</body>
</html>

