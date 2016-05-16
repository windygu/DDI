<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FileDownloadList.aspx.cs"
    Inherits="DDIWebApp.DDI.FileDownloadList" %>

<%@ Register Assembly="DiyAspNetPager" Namespace="Diy.Pager" TagPrefix="diyAsp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>数据文件下载列表</title>
    <link href="../css/commom.css" rel="stylesheet" type="text/css" />
    <script language="javascript" src="/js/CheckBox.js" type="text/javascript"></script>
    <link href="../DatePicker/skin/WdatePicker.css" rel="stylesheet" type="text/css" />
    <%--<link href="../css/StyleDDI.css" rel="stylesheet" type="text/css" />--%>
    <script src="../../DatePicker/WdatePicker.js" type="text/javascript"></script>
     <script type="text/javascript">
         if (window.top == window)
             window.top.location = "main.html";
    </script>
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
        <div class="formbody">
            <table class="tableTwo">
                <tr>
                    <td align="right">业务名称 ：
                    </td>
                    <td  align="left">
                        <asp:TextBox ID="TextBoxBusinessName" runat="server" CssClass="CtextTwo" MaxLength="100"></asp:TextBox>
                    </td>
                    <td  align="right">文件格式 ：
                    </td>
                    <td  align="left">
                        <asp:DropDownList ID="DropDownListFileType" Width="185px" runat="server" Height="26px" CssClass="Cddl">
                            <asp:ListItem Selected="true" Enabled="true" Text="" Value=""></asp:ListItem>
                            <asp:ListItem Enabled="true" Text="Excel97_2003" Value="3"></asp:ListItem>
                            <asp:ListItem Enabled="true" Text="Excel2007" Value="2"></asp:ListItem>
                            <asp:ListItem Enabled="true" Text="文本文件" Value="1"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td  align="right">执行周期 ：
                    </td>
                    <td  align="left" >
                        <asp:DropDownList ID="DropDownListCycle" Width="185px" runat="server" Height="26px" CssClass="Cddl">
                            <asp:ListItem Selected="true" Enabled="true" Text="" Value=""></asp:ListItem>
                            <asp:ListItem Enabled="true" Text="日" Value="日"></asp:ListItem>
                            <asp:ListItem Enabled="true" Text="周" Value="周"></asp:ListItem>
                            <asp:ListItem Enabled="true" Text="月" Value="月"></asp:ListItem>
                            <asp:ListItem Enabled="true" Text="季度" Value="季度"></asp:ListItem>
                            <asp:ListItem Enabled="true" Text="半年" Value="半年"></asp:ListItem>
                            <asp:ListItem Enabled="true" Text="年" Value="年"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td height="30" width="20%" align="right"></td>
                    <td height="30" width="20%" align="left"></td>
                </tr>
            </table>
            <div class="funcbar">
                <asp:Button ID="btnSerch" runat="server" Text="查 询" class="scbtn" OnClick="btnSerch_Click"></asp:Button>
            </div>
            <asp:GridView ID="gridview" runat="server" DataKeyNames="id" Width="100%" SkinID="Default"
                RowStyle-HorizontalAlign="Center" AllowPaging="false" AutoGenerateColumns="False"
                OnRowCommand="gridview_RowCommand"
                OnRowDataBound="gridview_RowDataBound"
                OnRowDeleting="gridview_RowDeleting">
                <Columns>
                    <asp:TemplateField HeaderStyle-Width="100px" HeaderText="操 作" Visible="true">
                        <ItemTemplate>
                            <asp:Panel ID="panel" runat="server">
                                <a href='FileDownloadEdit.aspx?id=<%#Eval("id") %>' style="color: #0000FF">进入下载页</a>
                            </asp:Panel>
                            
                            <asp:HiddenField ID="hfid" runat="server" Value='<%#Eval("id") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField DataField="LoseEfficacyDate" HeaderText="失效日期" SortExpression="LoseEfficacyDate" DataFormatString="{0:yyyy-MM-dd}">
                    </asp:BoundField>
                    <asp:BoundField DataField="Cycle" HeaderText="执行周期" SortExpression="Cycle"></asp:BoundField>
                    <asp:BoundField DataField="BusinessName" HeaderText="业务名称" SortExpression="BusinessName" ItemStyle-HorizontalAlign="Left">
                    </asp:BoundField>
                    <asp:TemplateField ControlStyle-Width="30" HeaderText="执行时间">
                        <ItemTemplate>
                            <%#setTimes(Eval("VoluntarilyTime").ToString())%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="FileFormatName" HeaderText="文件名称格式" SortExpression="FileFormatName"
                        ItemStyle-HorizontalAlign="Left">
                    </asp:BoundField>

                    <asp:BoundField DataField="PathName" HeaderText="输出路径" SortExpression="PathName"
                        ItemStyle-HorizontalAlign="Left">
                    </asp:BoundField>

                    <asp:BoundField DataField="BecomeValidateDate" HeaderText="生效日期" SortExpression="BecomeValidateDate" DataFormatString="{0:yyyy-MM-dd}">
                    </asp:BoundField>
                    <asp:TemplateField ControlStyle-Width="50" HeaderText="文件格式" Visible="true">
                        <ItemTemplate>
                            <%#SubStr(Eval("FileType").ToString())%>
                        </ItemTemplate>
                    </asp:TemplateField>
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
