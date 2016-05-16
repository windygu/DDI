<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="left.aspx.cs" Inherits="Web.Main.left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>无标题文档</title>
    <link href="css/commom.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery-1.7.1.js" type="text/javascript"></script>

    <script type="text/javascript">
        $(function () {
            //导航切换
            $(".menuson li").click(function () {
                $(".menuson li.active").removeClass("active")
                $(this).addClass("active");
            });

            $('.title').click(function () {
                var $ul = $(this).next('ul');
                $('dd').find('ul').slideUp();
                if ($ul.is(':visible')) {
                    $(this).next('ul').slideUp();
                } else {
                    $(this).next('ul').slideDown();
                }
            });
        })
    </script>


</head>

<body style="background: #f0f9fd;">
    <div class="lefttop"><span></span>功能菜单</div>

    <dl class="leftmenu">
          <asp:Repeater ID="RPT_Menu" runat="server" OnItemDataBound="RPT_Menu_ItemDataBound">
            <ItemTemplate>
             <dd>
                <div class="title">
                <span><img alt="" src="images/leftico01.png" /></span><%#Eval("MenuName") %>
                </div>
                    <ul class="menuson">
                    
                    <asp:Repeater ID="RPT_ChildMenu" runat="server">
                        <ItemTemplate>
                            <li><cite></cite><a href="<%#Eval("menuaction")%>" target="rightFrame"><%#Eval("MenuName") %></a><i></i></li>
                        </ItemTemplate>
                    </asp:Repeater>
                    
                    </ul>    
                </dd>
                
            </ItemTemplate>
        </asp:Repeater>

    </dl>

</body>
</html>

