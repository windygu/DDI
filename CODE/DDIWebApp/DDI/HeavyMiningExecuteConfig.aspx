<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HeavyMiningExecuteConfig.aspx.cs"
    Inherits="DDIWebApp.DDI.HeavyMiningExecuteConfig" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/commom.css" rel="stylesheet" type="text/css" />
    <script language="javascript" src="/js/CheckBox.js" type="text/javascript"></script>
    <link href="../DatePicker/skin/WdatePicker.css" rel="stylesheet" type="text/css" />
    <script src="../../DatePicker/WdatePicker.js" type="text/javascript"></script>
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
    <div align="left">
        <table width="100%" cellspacing="0">
            <tr>
                <td height="40" bgcolor='' align="center">
                    <b style="font-size: 22px">重 采</b>
                </td>
            </tr>
        </table>
        <table width="850px" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td height="30" width="20%" align="right">
                </td>
                <td height="30" align="left" class="style1">
                </td>
                <td height="30" align="right">
                </td>
                <td height="30" width="20%" align="left">
                </td>
            </tr>
            <tr>
                <td height="30" width="20%" align="right">
                    重采业务时间 ：
                </td>
                <td height="30" align="left" class="style1">
                    <asp:TextBox ID="txtywdate" runat="server" Width="180px" CssClass="Wdate" onfocus="WdatePicker({isShowClear:true,dateFmt:'yyyy-MM-dd',readOnly:false})"></asp:TextBox>
                </td>
                <td height="30" align="right">
                    重采操作时间 ：
                </td>
                <td height="30" width="20%" align="left">
                    <asp:TextBox ID="txtczdate" runat="server" Width="180px" CssClass="Wdate" onfocus="WdatePicker({isShowClear:true,dateFmt:'yyyy-MM-dd',readOnly:false})"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td height="30" width="20%" align="right">
                </td>
                <td height="30" align="left" class="style1">
                    <asp:CheckBox ID="CbisDownload" runat="server" Text="重采是否自动下载" />
                </td>
                <td height="30" align="right">
                    
                </td>
                <td height="30" width="20%" align="left">
                </td>
            </tr>
            <tr>
                <td colspan="4" height="60" width="20%" align="center">
                    <asp:Button ID="btnAdd" runat="server" Text="重 采" class="scbtn" 
                        onclick="btnAdd_Click"></asp:Button>&nbsp;&nbsp;
                    <asp:Button ID="btnc" runat="server" Text="取 消" class="scbtn" OnClick="btnc_Click"></asp:Button>&nbsp;&nbsp;
                </td>
            </tr>
        </table>
        <asp:HiddenField ID="hfid" runat="server" />

    </div>
    </form>
</body>
</html>
