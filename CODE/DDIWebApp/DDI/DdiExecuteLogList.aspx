<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DdiExecuteLogList.aspx.cs"
    Inherits="DDIWebApp.DDI.DdiExecuteLogList" %>

<%@ Register Assembly="DiyAspNetPager" Namespace="Diy.Pager" TagPrefix="diyAsp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>业务执行日志列表</title>
    <link href="../css/commom.css" rel="stylesheet" type="text/css" />
    <script language="javascript" src="/js/CheckBox.js" type="text/javascript"></script>
    <link href="../DatePicker/skin/WdatePicker.css" rel="stylesheet" type="text/css" />
    <link href="../css/StyleDDI.css" rel="stylesheet" type="text/css" />
    <script src="../../DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        function openFileIIs() {
            try {
                alert("jjdjdjd");
                alert(event.text());
                var filename = event.text();
                var obj = new ActiveXObject("wscript.shell");
                if (obj) {
                    obj.Run("\"" + filename + "\"", 1, false);
                    obj = null;

                    return false;
                }
            } catch (e) {
                alert("请确定是否存在该盘符或文件");
                return false;
            }
        }
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
                    <td  align="right">业务名称 ：
                    </td>
                    <td  align="left" >
                        <asp:TextBox ID="TextBoxBusinessName" runat="server" CssClass="CtextTwo" MaxLength="100"></asp:TextBox>
                    </td>
                    <td  align="right">自动执行 ：
                    </td>
                    <td  align="left">
                        <asp:DropDownList ID="DropDownListIsVoluntarily" Width="185px" runat="server" Height="26px"
                            CssClass="Cddl">
                            <asp:ListItem Selected="true" Enabled="true" Text="" Value=""></asp:ListItem>
                            <asp:ListItem Enabled="true" Text="" Value=""></asp:ListItem>
                            <asp:ListItem Enabled="true" Text="是" Value="是"></asp:ListItem>
                            <asp:ListItem Enabled="true" Text="否" Value="否"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">状态 ：
                    </td>
                    <td align="left" >
                        <asp:DropDownList ID="DropDownListStatus" Width="185px" runat="server" Height="26px"
                            CssClass="Cddl">
                            <asp:ListItem Selected="true" Enabled="true" Text="" Value=""></asp:ListItem>
                            <asp:ListItem Enabled="true" Text="自动执行正常" Value="1"></asp:ListItem>
                            <asp:ListItem Enabled="true" Text="自动执行异常" Value="2"></asp:ListItem>
                            <asp:ListItem Enabled="true" Text="手动执行正常" Value="3"></asp:ListItem>
                            <asp:ListItem Enabled="true" Text="手动执行异常" Value="4"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td  align="right">操作是否正常 ：
                    </td>
                    <td  align="left">
                        <asp:DropDownList ID="DropDownListIsMormal" Width="185px" runat="server" Style="margin-bottom: 0px"
                            Height="26px" CssClass="Cddl">
                            <asp:ListItem Selected="true" Enabled="true" Text="" Value=""></asp:ListItem>
                            <asp:ListItem Enabled="true" Text="是" Value="True"></asp:ListItem>
                            <asp:ListItem Enabled="true" Text="否" Value="False"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
             <div class="funcbar">
                <asp:Button ID="btnSerch" runat="server" Text="查 询" class="scbtn"  OnClick="btnSerch_Click"></asp:Button>
            </div>
                <asp:GridView ID="gridview" runat="server" DataKeyNames="id,ConfigId" Width="100%"
                    SkinID="Default" RowStyle-HorizontalAlign="Center" AllowPaging="false" AutoGenerateColumns="False" OnRowCommand="gridview_RowCommand" OnRowDataBound="gridview_RowDataBound">
                    <Columns>
                        <asp:TemplateField ControlStyle-Width="80" HeaderText="操 作" Visible="true">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtnDele" runat="server" CausesValidation="False" Text="" CommandName="Manual"
                                    CommandArgument='<%#gridview.Rows.Count + 1%>' OnClientClick="return confirm('确定手动生成文件吗？')" ForeColor="#3333FF"></asp:LinkButton>
                                <asp:Label ID="lab_Statusint" Visible="false" runat="server" Text='<%# Eval("Status")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ControlStyle-Width="80" HeaderText="状态" Visible="true">
                            <ItemTemplate>
                                <asp:Label ID="lab_Status" runat="server" Text='<%# GetStatusStr(Eval("Status").ToString())%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ControlStyle-Width="80" HeaderText="操作是否正常" Visible="true">
                            <ItemTemplate>
                                <%# Eval("IsMormal").ToString().Trim() == "" ? "" : Eval("IsMormal").ToString().Trim() == "True" ? "正常" : "异常"%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ControlStyle-Width="80" HeaderText="是否自动" Visible="true">
                            <ItemTemplate>
                                <%# Eval("IsVoluntarily").ToString().Trim() == "" ? "" : Eval("IsVoluntarily").ToString().Trim() == "是" ? "自动" : "手动"%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="BusinessName" HeaderText="业务配置名称" SortExpression="BusinessName"
                            ItemStyle-HorizontalAlign="Center">
                        </asp:BoundField>
                        <asp:BoundField DataField="BusinessExecuteDate" HeaderText="业务时间" SortExpression="BusinessExecuteDate"
                            ItemStyle-HorizontalAlign="Center" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}">
                        </asp:BoundField>
                        <asp:BoundField DataField="OperateDateTime" HeaderText="操作时间" SortExpression="OperateDateTime"
                            ItemStyle-HorizontalAlign="Center" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}">
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="文件备份路径" Visible="true">
                            <ItemTemplate>
                                <asp:LinkButton ID="LBUrl" runat="server" Text='<%# Eval("BackUrl")%>'></asp:LinkButton>
                                <%-- <asp:HiddenField ID="hfPathName" runat="server" value=' <%# Eval("PathName").ToString()%>'/>--%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="OperateMan" HeaderText="操作人" SortExpression="OperateMan"
                            ItemStyle-HorizontalAlign="Center">
                        </asp:BoundField>
                        <asp:BoundField DataField="BusinessEndDateTime" HeaderText="业务数据截止时间" SortExpression="BusinessEndDateTime"
                            ItemStyle-HorizontalAlign="Center" DataFormatString="{0:yyyy-MM-dd}">
                        </asp:BoundField>
                        <asp:BoundField DataField="ConfigId" HeaderText="业务配置编码" SortExpression="ConfigId"
                            ItemStyle-HorizontalAlign="Center">
                        </asp:BoundField>
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
