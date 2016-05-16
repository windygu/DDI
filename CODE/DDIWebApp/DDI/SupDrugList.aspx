<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupDrugList.aspx.cs" Inherits="DDIWebApp.DDI.SupDrugList" %>

<!DOCTYPE html>

<%@ Register Assembly="DiyAspNetPager" Namespace="Diy.Pager" TagPrefix="diyAsp" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../css/commom.css" rel="stylesheet" type="text/css" />
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
                    <td align="right">商品编码 ：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtdrugcode" runat="server" CssClass="CtextTwo" MaxLength="100"></asp:TextBox>
                    </td>
                    <td align="right">供应商编码 ：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtsupcode" runat="server" CssClass="CtextTwo" MaxLength="100"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">供应商名称 ：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtsupname" runat="server" CssClass="CtextTwo" MaxLength="100"></asp:TextBox>
                    </td>
                    <td align="right">查询码：</td>
                    <td align="left">
                        <asp:TextBox ID="txtddicode" runat="server" CssClass="CtextTwo" MaxLength="100"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                   
                    <td align="right">状态：</td>
                    <td align="left">
                        <asp:CheckBox ID="checkstatus" runat="server" Text="禁用" />
                    </td>
                     <td align="right"></td>
                    <td align="left">
                    </td>
                </tr>
            </table>
            <div class="funcbar">
                <asp:Button ID="btnSerch" runat="server" Text="查 询" class="scbtn" OnClick="btnSerch_Click"></asp:Button>&nbsp;&nbsp;
            </div>
            <asp:GridView ID="gridview" runat="server" DataKeyNames="DdiCode,DrugCode,OrgCode" Width="100%"
                SkinID="Default" RowStyle-HorizontalAlign="Center" AllowPaging="false" AutoGenerateColumns="False" OnRowCommand="gridview_RowCommand" OnRowDataBound="gridview_RowDataBound" OnRowUpdating="gridview_RowUpdating">
                <Columns>
                    <asp:TemplateField ControlStyle-Width="80" HeaderText="操 作" Visible="true">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbtnDele" runat="server" CausesValidation="False" Text="" CommandName="Update"
                                CommandArgument='<%#gridview.Rows.Count + 1%>' OnClientClick="return confirm('确定本次操作吗？')" ForeColor="#3333FF"></asp:LinkButton>
                            <asp:LinkButton ID="lbtnStars" runat="server" CausesValidation="False" Text="" CommandName="Stars"
                                CommandArgument='<%#gridview.Rows.Count + 1%>' OnClientClick="return confirm('确定本次操作吗？')" ForeColor="#3333FF"></asp:LinkButton>
                            <asp:Label ID="lab_IsEnabled" Visible="false" runat="server" Text='<%# Eval("IsEnabled")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ControlStyle-Width="80" HeaderText="是否启用" Visible="true">
                        <ItemTemplate>
                            <asp:Label ID="lab_Status" runat="server" Text='<%# GetStatusStr(Eval("IsEnabled").ToString())%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="SupCode" HeaderText="供应商编码" SortExpression="SupCode"
                        ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                    <asp:BoundField DataField="SupName" HeaderText="供应商名称" SortExpression="SupName"
                        ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                    <asp:BoundField DataField="DrugCode" HeaderText="药品编码" SortExpression="DrugCode"
                        ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                    <asp:BoundField DataField="OrgCode" HeaderText="机构编码" SortExpression="OrgCode"
                        ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                    <asp:BoundField DataField="DdiCode" HeaderText="查询码" SortExpression="DdiCode"
                        ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                    <asp:BoundField DataField="CreateMan" HeaderText="操作人" SortExpression="CreateMan"
                        ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                    <asp:BoundField DataField="CreateDate" HeaderText="添加时间" SortExpression="CreateDate"
                        ItemStyle-HorizontalAlign="Left" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}"></asp:BoundField>
                    <asp:TemplateField ControlStyle-Width="80" HeaderText="禁用时间" Visible="true">
                        <ItemTemplate>
                            <asp:Label ID="lab_ForbiddenDate" runat="server" Text='<%# GetdateTimeStr(Eval("ForbiddenDate").ToString())%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:BoundField DataField="FORBIDDENMAN" HeaderText="禁用人" SortExpression="FORBIDDENMAN"
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
