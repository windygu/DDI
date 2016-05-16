<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupAndDrugRelation.aspx.cs" Inherits="DDIWebApp.DDI.SupAndDrugRelation" %>

<!DOCTYPE html>

<%@ Register Assembly="DiyAspNetPager" Namespace="Diy.Pager" TagPrefix="diyAsp" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../css/commom.css" rel="stylesheet" />
    <script src="../js/jquery-1.7.1.js" type="text/javascript"></script>
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
                <tr>
                    <td align="right">商品编码 ：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtgoodcode" runat="server" CssClass="CtextTwo" MaxLength="20"></asp:TextBox>
                    </td>
                    <td align="right">状态：</td>
                    <td align="left">
                        <asp:CheckBox ID="checkstatus" runat="server" Text="禁 用" />
                    </td>
                    
                    
                </tr>
            </table>
            <div class="funcbar">
                <asp:Button ID="btnSerch" runat="server" Text="查 询" class="scbtn" OnClick="btnSerch_Click"></asp:Button>&nbsp;&nbsp;
                <asp:Button ID="btnAdd" runat="server" Text="添 加" class="scbtn" OnClick="btnAdd_Click" ></asp:Button>&nbsp;&nbsp;
            </div>
            <asp:GridView ID="gridview" runat="server" DataKeyNames="USERID,SUPCODE,GOODSCODE,ISENABLED" Width="100%"
                SkinID="Default" RowStyle-HorizontalAlign="Center" AllowPaging="false" AutoGenerateColumns="False" OnRowCommand="gridview_RowCommand" OnRowDataBound="gridview_RowDataBound" >
                <Columns>
                     <asp:TemplateField HeaderStyle-Width="100px" HeaderText="操 作" Visible="true">
                        <ItemTemplate>
                             <asp:Panel ID="panel" runat="server">
                                <a href='SupAndDrugRelationEdit.aspx?userid=<%#Eval("USERID")%>&supcode=<%#Eval("SUPCODE")%>&durgcode=<%#Eval("GOODSCODE")%>' style="color: #0000FF">编辑</a>
                                 
                                 <asp:LinkButton ID="lbtnDele" runat="server" CausesValidation="False" Text="" CommandName="ISENABLED"
                                CommandArgument='<%#gridview.Rows.Count + 1%>' OnClientClick="return confirm('确定本次操作吗？')" ForeColor="#3333FF"></asp:LinkButton>
                            </asp:Panel>
                            
                            <asp:Label ID="lab_IsEnabled" Visible="false" runat="server" Text='<%# Eval("ISENABLED")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="SUPCODE" HeaderText="供应商编码" SortExpression="SupCode"
                        ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                    <asp:BoundField DataField="SUPNAME" HeaderText="供应商名称" SortExpression="SUPNAME"
                        ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                    <asp:BoundField DataField="GOODSCODE" HeaderText="商品编码" SortExpression="GOODSCODE"
                        ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                    <asp:BoundField DataField="GOODSNAME" HeaderText="商品名称" SortExpression="GOODSNAME"
                        ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                    <asp:BoundField DataField="GOODSSPEC" HeaderText="规格" SortExpression="GOODSSPEC"
                        ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                    <asp:BoundField DataField="CREATEMAN" HeaderText="添加人编码" SortExpression="CREATEMAN"
                        ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                    <asp:BoundField DataField="CREATEDATE" HeaderText="添加时间" SortExpression="CREATEDATE"
                        ItemStyle-HorizontalAlign="Left" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}"></asp:BoundField>
                    <asp:BoundField DataField="DELETEMAN" HeaderText="删除人编码" SortExpression="DELETEMAN"
                        ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                    <asp:BoundField DataField="DELETEDATE" HeaderText="删除时间" SortExpression="DELETEDATE"
                        ItemStyle-HorizontalAlign="Left" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}"></asp:BoundField>
                    
                    <asp:BoundField DataField="ISENABLED" HeaderText="状态" SortExpression="ISENABLED"
                        ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                </Columns>
            </asp:GridView>

            <div>
                <diyAsp:AspNetPager ID="AspNetPager1" runat="server" CustomInfoHTML="第%CurrentPageIndex%页 共%PageCount%页 %RecordCount%条记录&nbsp;&nbsp;"
                    CustomInfoTextAlign="Right" HorizontalAlign="right" LayoutType="Table" PagingButtonSpacing="8px"
                    ShowCustomInfoSection="Right" ShowNavigationToolTip="true" ShowPageIndexBox="Always"
                    SubmitButtonStyle="width:32px;height:23px;vertical-align:top;" AlwaysShow="False"
                    UrlPageIndexName="pageindex" UrlPaging="False" Width="100%" PageSize="10" ShowInputBox="Always"
                    FirstPageText="首页" LastPageText="末页" NextPageText="下一页" PrevPageText="上一页" OnPageChanging="AspNetPager1_PageChanging"
                    PageIndexBoxType="TextBox" CustomInfoSectionWidth="200px" Wrap="False">
                </diyAsp:AspNetPager>
            </div>
        </div>
    </form>
</body>
</html>
