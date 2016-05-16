<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FileDownloadEdit.aspx.cs" Inherits="DDIWebApp.DDI.FileDownloadEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>文件生成</title>
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
        <div class="formbody">
            <table width="850px" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td height="30" width="20%" align="right">供应商编码 ：
                    </td>
                    <td height="30" align="left" class="style1">
                        <asp:TextBox ID="txtsupcode" runat="server" CssClass="Ctext" Width="150px" MaxLength="100"></asp:TextBox>
                    </td>
                    <td height="30" width="20%" align="right">供应商名称 ：
                    </td>
                    <td height="30" align="left" class="style1">
                        <asp:TextBox ID="txtSupName" runat="server" CssClass="Ctext"  Width="150px" MaxLength="100"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td height="30" align="right">开始时间 ：
                    </td>
                    <td height="30" width="20%" align="left">
                        <asp:TextBox ID="txtBeginDate" runat="server" CssClass="Wdate" Width="150px" onfocus="WdatePicker({isShowClear:true,dateFmt:'yyyy-MM-dd',readOnly:true})"></asp:TextBox>
                    </td>
                    <td height="30" width="20%" align="right">截止时间 ：
                    </td>
                    <td height="30" align="left" class="style1">
                       <asp:TextBox ID="txtEndDate" runat="server" CssClass="Wdate" Width="150px" onfocus="WdatePicker({isShowClear:true,dateFmt:'yyyy-MM-dd',readOnly:true})"></asp:TextBox>
                    </td>
                </tr>
                 <tr style="height: 50px;">
                <td colspan="4" height="60" align="center">
                    <asp:Button ID="btnFileDownload" runat="server" Text="输出文件" class="scbtnthree" OnClick="btnFileDownload_Click" ></asp:Button>&nbsp;&nbsp;
                    <asp:HiddenField ID="ConfigId" runat="server" />
                </td>
            </tr>
            </table>
        </div>
    </form>
</body>
</html>
