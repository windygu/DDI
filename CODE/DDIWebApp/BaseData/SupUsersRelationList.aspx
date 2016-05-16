<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupUsersRelationList.aspx.cs" Inherits="DDIWebApp.DDI.SupUsersRelationList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>用户权限配置</title>
    <link href="../css/commom.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.7.1.js" type="text/javascript"></script>
    <script src="../js/MakerSelect.js" type="text/javascript"></script>
    <script type="text/javascript">

        function postBackByObject()  
            　　{  
                   　　var o = window.event.srcElement;  
                   　　if (o.tagName == "INPUT" && o.type == "checkbox")  
                   　　{  
                           　　__doPostBack("UpdatePanel1","");　　//此处前面是两个下划线(UpdatePanel1处是因为用了UpdatePanel所以才写这个控件ID的)  
                       }   
            　　}  

    </script>
</head>
<body>
    <%-- <div class="divsitemap">
        <div class="sitemap">
            <asp:SiteMapPath ID="SiteMapPath1" runat="server"></asp:SiteMapPath>
        </div>
        <div class="sitemap_line"></div>
    </div>--%>
    <form id="form1" runat="server">
        <table class="formbody">
            <tr>
                <td style="vertical-align: top" >
                    <div style="margin-left: 10px; margin-top: 10px; float: left; width: 600px;">

                        <table class="tableTwo">
                            <tr>
                                <td align="right">登录名 ：
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtloginname" runat="server" CssClass="CtextTwo" MaxLength="100"></asp:TextBox>
                                </td>
                                <td align="right">机构编码 ：
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtorgcode" runat="server" CssClass="CtextTwo" MaxLength="100"></asp:TextBox>
                                </td>
                            </tr>
                            <tr style="height: 50px;">
                                <td colspan="4" align="center">&nbsp;&nbsp;
                     <asp:Button ID="btnSerch" runat="server" Text="查 询" class="scbtn" OnClick="btnSerch_Click"></asp:Button>&nbsp;&nbsp;
                                </td>
                            </tr>
                        </table>
                        <asp:GridView ID="gridview" runat="server" DataKeyNames="Id" Width="100%"
                            SkinID="Default" RowStyle-HorizontalAlign="Center" AllowPaging="false" AutoGenerateColumns="False" OnRowDataBound="gridview_RowDataBound" OnRowCommand="gridview_RowCommand">
                            <Columns>

                                <asp:BoundField DataField="Id" HeaderText="编码" SortExpression="Id"
                                    ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                                <asp:BoundField DataField="LoginName" HeaderText="登录名称" SortExpression="LoginName"
                                    ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                                <asp:BoundField DataField="OrgCode" HeaderText="机构编码" SortExpression="OrgCode"
                                    ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                                <asp:BoundField DataField="OrgName" HeaderText="机构名称" SortExpression="OrgName"
                                    ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                                <asp:TemplateField ControlStyle-Width="50" HeaderText="操 作" Visible="true">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbtnUpdate" runat="server" CausesValidation="False" Text="绑定供应商" CommandName="LBEdit"
                                            CommandArgument='<%#gridview.Rows.Count + 1%>' ForeColor="#3333FF"></asp:LinkButton>
                                        <asp:Label ID="lblid" Visible="false" runat="server" Text='<%# Eval("Id")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>

                </td>
                <td style="vertical-align: top">
                    <div class="wrapper" style="float: right; width: 600px; margin-top: 10px; padding-left:50px;">
                         <table class="tableTwo">
                            <tr>
                                <td align="right">供应商编码 ：
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtsupcode" runat="server" CssClass="CtextTwo" MaxLength="100"></asp:TextBox>
                                </td>
                                <td align="right">供应商名称 ：
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtsupname" runat="server" CssClass="CtextTwo" MaxLength="100"></asp:TextBox>
                                </td>
                            </tr>
                            <tr style="height: 50px;">
                                <td colspan="4" align="center">&nbsp;&nbsp;
                     <asp:Button ID="btnRightSerch" runat="server" Text="查 询" class="scbtn" OnClick="btnRightSerch_Click" ></asp:Button>&nbsp;&nbsp;
                                    <asp:HiddenField ID="hfuserid" runat="server" />
                                </td>
                            </tr>
                        </table>
                            <asp:GridView ID="gridview1" runat="server" DataKeyNames="supcode,supname,status" Width="100%"
                            SkinID="Default" RowStyle-HorizontalAlign="Center" AllowPaging="false" AutoGenerateColumns="False" OnRowDataBound="gridview1_RowDataBound" OnRowCommand="gridview1_RowCommand"  >
                            <Columns>
                                 <asp:TemplateField ControlStyle-Width="50" HeaderText="绑定操作" Visible="true">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbtnEdit" runat="server" CausesValidation="False" Text="" CommandName="RowEdit"
                                            CommandArgument='<%#gridview1.Rows.Count + 1%>' ForeColor="#3333FF"></asp:LinkButton>
                                        <asp:Label ID="lblsupcode" Visible="false" runat="server" Text='<%# Eval("supcode")%>' />
                                        <asp:Label ID="lblstatus" Visible="false" runat="server" Text='<%# Eval("status")%>' />
                                        <asp:Label ID="lblsupname" Visible="false" runat="server" Text='<%# Eval("supname")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="supcode" HeaderText="供应商编码" SortExpression="supcode"
                                    ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                                <asp:BoundField DataField="supname" HeaderText="供应商名称" SortExpression="supname"
                                    ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                               
                            </Columns>
                        </asp:GridView>

                        
                        
                    </div>
                </td>
            </tr>

        </table>


    </form>
</body>
</html>
