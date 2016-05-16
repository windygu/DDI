<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DdiConfigEdit.aspx.cs"
    Inherits="huaruncms.Web.DDI.DdiConfigEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>数据传输配置</title>
    <link href="../css/commom.css" rel="stylesheet" type="text/css" />
    <script language="javascript" src="/js/CheckBox.js" type="text/javascript"></script>
    <link href="../DatePicker/skin/WdatePicker.css" rel="stylesheet" type="text/css" />
    <script src="../../DatePicker/WdatePicker.js" type="text/javascript"></script>
    <style type="text/css">
        .style1 {
            width: 18%;
        }

        #TextBoxSql {
            width: 534px;
        }
    </style>
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
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="formbody">
            <table width="850px" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td height="30" width="20%" align="right">配置方式 ：
                    </td>
                    <td height="30" align="left" class="style1" width="180px">
                        <asp:DropDownList ID="DropDownListType" Width="304px" Height="26px" runat="server"
                            CssClass="Cddl">
                            <asp:ListItem Enabled="true" Text="内置配置" Value="0"></asp:ListItem>
                            <asp:ListItem Enabled="true" Selected="true" Text="自定义配置" Value="1"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td height="30" width="15%" align="right">文件格式 ：
                    </td>
                    <td height="30" width="20%" align="left">
                        <asp:DropDownList ID="DropDownListFileType" Width="152px" runat="server" Height="26px"
                            CssClass="Cddl">
                            <asp:ListItem Selected="true" Enabled="true" Text="Excel97_2003" Value="1"></asp:ListItem>
                            <asp:ListItem Enabled="true" Text="Excel2007" Value="2"></asp:ListItem>
                            <asp:ListItem Enabled="true" Text="文本文件" Value="3"></asp:ListItem>
                            <asp:ListItem Enabled="true" Text="CSV" Value="4"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td height="30" width="20%" align="right">业务名称 ：
                    </td>
                    <td height="30" align="left" class="style1">
                        <asp:TextBox ID="TextBoxBusinessName" runat="server" CssClass="Ctext" MaxLength="100"></asp:TextBox>
                    </td>
                    <td height="30" align="right">执行时间 ：
                    </td>
                    <td height="30" width="20%" align="left">
                        <asp:TextBox ID="txtVoluntarilyTime" runat="server" CssClass="Wdate" Width="150px" onfocus="WdatePicker({isShowClear:true,dateFmt:'HH:mm:ss',readOnly:true})"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td height="30" width="20%" align="right">文件目标路径 ：
                    </td>
                    <td height="30" align="left" class="style1">
                        <asp:TextBox ID="TextBoxPathName" runat="server" CssClass="Ctext" MaxLength="100"></asp:TextBox>
                    </td>
                    <td height="30" align="right">执行周期 ：
                    </td>
                    <td height="30" width="20%" align="left">
                        <asp:DropDownList ID="DropDownListCycle" Width="152px" runat="server" Height="26px"
                            CssClass="Cddl">
                            <asp:ListItem Selected="true" Enabled="true" Text="日" Value="日"></asp:ListItem>
                            <asp:ListItem Enabled="true" Text="周" Value="周"></asp:ListItem>
                            <asp:ListItem Enabled="true" Text="月" Value="月"></asp:ListItem>
                            <asp:ListItem Enabled="true" Text="季度" Value="季度"></asp:ListItem>
                            <asp:ListItem Enabled="true" Text="半年" Value="半年"></asp:ListItem>
                            <asp:ListItem Enabled="true" Text="年" Value="年"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td height="30" width="20%" align="right">首次执行日期 ：
                    </td>
                    <td height="30" align="left" class="style1">
                        <asp:TextBox ID="TextBoxValidateDate" runat="server" CssClass="Wdate" Width="300px" onfocus="WdatePicker({isShowClear:true,dateFmt:'yyyy-MM-dd',readOnly:true})"></asp:TextBox>
                    </td>
                    <td height="30" align="right">失效日期 ：
                    </td>
                    <td height="30" align="left" class="style1">
                        <asp:TextBox ID="TextBoxLoseEfficacyDate" runat="server" CssClass="Wdate" Width="150px" onfocus="WdatePicker({isShowClear:true,dateFmt:'yyyy-MM-dd',readOnly:true})"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td height="30" width="20%" align="right">备注 ：
                    </td>
                    <td height="30" width="20%" align="left" colspan="3">
                        <asp:TextBox ID="TextBoxRemark" runat="server" CssClass="Ctext" Width="650px" MaxLength="100"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td height="30" width="20%" align="right">格式化文件名称 ：
                    </td>
                    <td height="30" width="20%" align="left" colspan="3">
                        <asp:TextBox ID="TextBoxFileFormatName" runat="server" CssClass="Ctext" Width="650px"
                            MaxLength="100"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td height="30" width="20%" align="right">格式化文件变量名称 ：
                    </td>
                    <td height="30" align="left" class="style1">
                        <asp:TextBox ID="TxtFormatVariable" runat="server" CssClass="Ctext" MaxLength="20"></asp:TextBox>
                    </td>
                    <td height="30" align="right">文件名称变量 ：
                    </td>
                    <td height="30" width="20%" align="left">
                        <asp:DropDownList ID="DropDownListVariable" Width="152px" runat="server" Style="margin-bottom: 0px"
                            Height="26px" CssClass="Cddl">
                            <asp:ListItem Selected="true" Enabled="true" Text="无" Value=""></asp:ListItem>
                            <asp:ListItem Enabled="true" Text="年" Value="YYYY"></asp:ListItem>
                            <asp:ListItem Enabled="true" Text="年周" Value="YYYYWEEK"></asp:ListItem>
                            <asp:ListItem Enabled="true" Text="年上一周" Value="YYYYUPWEEK"></asp:ListItem>
                            <asp:ListItem Enabled="true" Text="年月" Value="YYYYMM"></asp:ListItem>
                            <asp:ListItem Enabled="true" Text="年月日" Value="YYYYMMDD"></asp:ListItem>
                            <asp:ListItem Enabled="true" Text="年月日时" Value="YYYYMMDDHH"></asp:ListItem>
                            <asp:ListItem Enabled="true" Text="年月日时分" Value="YYYYMMDDHHMM"></asp:ListItem>
                            <asp:ListItem Enabled="true" Text="年月日时分秒" Value="YYYYMMDDHHMMSS"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td height="30" width="20%" align="right">文件名称变量来源 ：
                    </td>
                    <td height="30" width="20%" align="left">
                        <asp:DropDownList ID="DropDownListDataSource" Width="304px" runat="server" Style="margin-bottom: 0px"
                            Height="26px" CssClass="Cddl">
                            <asp:ListItem Enabled="true" Text="业务日期" Value="yw"></asp:ListItem>
                            <asp:ListItem Enabled="true" Text="操作日期" Value="cz"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td height="30" align="right">浮动变量 ：
                    </td>
                    <td height="30" width="20%" align="left">
                        <asp:DropDownList ID="DropDownListConnector" Width="152px" runat="server" Style="margin-bottom: 0px"
                            Height="26px" CssClass="Cddl">
                            <asp:ListItem Enabled="true" Text="无" Value="无"></asp:ListItem>
                            <asp:ListItem Enabled="true" Text="上一天" Value="Upday"></asp:ListItem>
                            <asp:ListItem Enabled="true" Text="上周一" Value="UpMonday"></asp:ListItem>
                            <asp:ListItem Enabled="true" Text="上周日" Value="UpSunday"></asp:ListItem>
                            <asp:ListItem Enabled="true" Text="上月第一天" Value="UpMonthOne"></asp:ListItem>
                            <asp:ListItem Enabled="true" Text="上月最后一天" Value="UpMonthLast"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td height="30" width="20%" align="right">测试格式化文件名称 ：
                    </td>
                    <td height="30" width="20%" align="left">
                        <asp:TextBox ID="txtCheckFileName" runat="server" CssClass="Ctext"
                            MaxLength="100" Enabled="false"></asp:TextBox>
                    </td>
                    <td></td>
                    <td height="30" width="20%" align="left">
                        <asp:CheckBox ID="cbDownload" runat="server" Text="手动下载" Checked="false" />
                    </td>
                </tr>
                        <tr>
                            <td height="30" width="20%" align="right">
                                <asp:Label ID="lblVariable" runat="server" Text="格式名称变量列表："></asp:Label>
                            </td>
                            <td colspan="3" align="left">
                                <asp:GridView ID="gridviewVariable" runat="server" DataKeyNames="Name" Width="86%"
                                    SkinID="Default" RowStyle-HorizontalAlign="Center" AutoGenerateColumns="False"
                                    HeaderStyle-Height="28" SelectedRowStyle-CssClass="GridViewSelectedRowStyle"
                                    Height="16px" OnRowCommand="gridviewVariable_RowCommand" OnRowDeleting="gridviewVariable_RowDeleting">
                                    <Columns>
                                        <asp:TemplateField HeaderText="编号" ControlStyle-Width="25">
                                            <ItemTemplate>
                                                <%#gridviewVariable.Rows.Count + 1%>
                                            </ItemTemplate>
                                            <ControlStyle Width="25px"></ControlStyle>
                                            <HeaderStyle Height="28px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField ControlStyle-Width="25" HeaderText="操 作" Visible="true">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbtnDele" runat="server" CausesValidation="False" Text="删除" CommandName="Delete"
                                                    CommandArgument='<%#Eval("Name") %>' OnClientClick="return confirm('确定删除？')"></asp:LinkButton>
                                            </ItemTemplate>
                                            <ControlStyle Width="25px"></ControlStyle>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Name" HeaderText="变量名称" SortExpression="Name" ItemStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="VariableType" HeaderText="变量后格式" SortExpression="VariableType"
                                            ItemStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DataSource" HeaderText="数据来源" SortExpression="DataSource"
                                            ItemStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Connector" HeaderText="浮动变量" SortExpression="Connector"
                                            ItemStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:BoundField>
                                    </Columns>
                                    <HeaderStyle Height="28px" BackColor="#66CCFF" BorderColor="#0066FF"></HeaderStyle>
                                    <RowStyle Height="20px" HorizontalAlign="Center" BackColor="#F1F3F3" BorderColor="#6699FF"></RowStyle>
                                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle"></SelectedRowStyle>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr style="height: 50px;">
                            <td colspan="4" align="center">
                                <asp:Button ID="btnVariable" runat="server" Text="添加文件名称变量" class="scbtnmulti" OnClick="btnVariable_Click"></asp:Button>&nbsp;&nbsp;
                    <asp:Button ID="btnCheckout" runat="server" Text="测试文件名称" class="scbtnmulti" OnClick="btnCheckout_Click"></asp:Button>
                            </td>
                        </tr>
                <tr>
                    <td height="30" width="20%" align="right">文件数据Sql ：
                    </td>
                    <td height="30" align="left" class="style1" colspan="3">
                        <textarea id="TextBoxSql" runat="server" rows="20" wrap="virtual" style="width: 650px"
                            class="Ctextarea"></textarea>
                    </td>
                </tr>
                <tr>
                    <td height="30" width="20%" align="right">参数名称 ：
                    </td>
                    <td height="30" align="left" class="style1">
                        <asp:TextBox ID="TextBoxParaName" runat="server" CssClass="Ctext" MaxLength="20"></asp:TextBox>
                    </td>
                    <td height="30" align="right">参数类型 ：
                    </td>
                    <td height="30" width="20%" align="left">
                        <asp:DropDownList ID="DropDownListParaType" Width="152px" runat="server" Style="margin-bottom: 0px"
                            Height="26px" CssClass="Cddl">
                            <asp:ListItem Enabled="true" Text="datetime" Value="datetime"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td height="30" width="20%" align="right">参数排序号 ：
                    </td>
                    <td height="30" align="left" class="style1">
                        <asp:TextBox ID="TextBoxParaOrderBy" runat="server" Text="1" CssClass="Ctext" MaxLength="20"></asp:TextBox>
                    </td>
                    <td height="30" align="right">参数值来源 ：
                    </td>
                    <td height="30" width="20%" align="left">
                        <asp:DropDownList ID="DropDownListIllustrate" Width="152px" runat="server" Style="margin-bottom: 0px"
                            Height="26px" CssClass="Cddl">
                            <asp:ListItem Enabled="true" Text="业务日期" Value="yw"></asp:ListItem>
                            <asp:ListItem Enabled="true" Text="操作日期" Value="cz"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td height="30" width="20%" align="right">数据访问库类型 ：
                    </td>
                    <td height="30" align="left" class="style1">
                        <asp:DropDownList ID="ServerTypeddl" Width="304px" runat="server" Style="margin-bottom: 0px"
                            Height="26px" CssClass="Cddl">
                            <asp:ListItem Enabled="true" Text="Sql Server" Value="sql"></asp:ListItem>
                            <asp:ListItem Enabled="true" Text="Oracle" Value="oracle"></asp:ListItem>
                        </asp:DropDownList>

                    </td>
                    <td height="30" align="right"></td>
                    <td height="30" width="20%" align="left">
                        <asp:CheckBox ID="cbHead" runat="server" Text="是否显示导出列头" Checked="true" />
                    </td>
                </tr>

                <tr style="height: 50px;">
                    <td colspan="4" align="center">
                        <asp:Button ID="ButtonAdd" runat="server" Text="添加参数" class="scbtnthree" OnClick="ButtonAdd_Click"></asp:Button>&nbsp;&nbsp;
                    <asp:Button ID="btnCheckSql" runat="server" Text="验证语句" class="scbtnthree" OnClick="btnCheckSql_Click"></asp:Button>
                    </td>
                </tr>
                <tr>
                    <td height="30" width="20%" align="right"></td>
                    <td colspan="3" align="left">
                        
                                <asp:GridView ID="gridview" runat="server" DataKeyNames="OrderBy" Width="86%" SkinID="Default"
                                    RowStyle-HorizontalAlign="Center" AutoGenerateColumns="False" HeaderStyle-Height="28"
                                    SelectedRowStyle-CssClass="GridViewSelectedRowStyle" OnRowCommand="gridview_RowCommand"
                                    OnRowDeleting="gridview_RowDeleting" OnRowUpdating="gridview_RowUpdating" Height="61px">
                                    <Columns>
                                        <asp:TemplateField ControlStyle-Width="25" HeaderText="操 作" Visible="true">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbtnUpdate" runat="server" CausesValidation="False" Text="编辑"
                                                    CommandName="Update" CommandArgument='<%#Eval("OrderBy") %>'></asp:LinkButton>
                                                <asp:LinkButton ID="lbtnDele" runat="server" CausesValidation="False" Text="删除" CommandName="Delete"
                                                    CommandArgument='<%#Eval("OrderBy") %>' OnClientClick="return confirm('确定删除？')"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="OrderBy" HeaderText="排序" SortExpression="OrderBy" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                                        <asp:BoundField DataField="ParameterName" HeaderText="参数名称" SortExpression="ParameterName"
                                            ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                                        <asp:BoundField DataField="ParameterType" HeaderText="参数类型" SortExpression="ParameterType"
                                            ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                                        <asp:BoundField DataField="Illustrate" HeaderText="说明" SortExpression="Illustrate"
                                            ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                                    </Columns>
                                </asp:GridView>

                           
                    </td>
                </tr>

                <tr style="height: 50px;">
                    <td colspan="4" align="center">
                        <asp:Button ID="btnSave" runat="server" Text="保 存" class="scbtn" OnClick="btnSave_Click"></asp:Button>&nbsp;&nbsp;
                    <asp:Button ID="btnCancle" runat="server" Text="取 消" class="scbtn" OnClick="btnCancle_Click"></asp:Button>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" height="40"></td>
                </tr>
            </table>
            <asp:HiddenField ID="HiddenFieldid" runat="server" />
            <asp:HiddenField ID="HiddenFieldEdit" runat="server" />
        </div>
    </form>
</body>
</html>
