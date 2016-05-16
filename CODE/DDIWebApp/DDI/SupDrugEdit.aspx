<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupDrugEdit.aspx.cs" Inherits="DDIWebApp.DDI.SupDrugEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
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
              <td align="right">药品编码</td>
              <td align="left">
                   <asp:TextBox ID="txtDrugCode" runat="server" CssClass="CtextTwo" MaxLength="50"></asp:TextBox>
              </td>
              <td align="right">供应商编码</td>
              <td align="left">
                   <asp:TextBox ID="txtSupCode" runat="server" CssClass="CtextTwo" MaxLength="50"></asp:TextBox>
              </td>
          </tr>
          <tr>
              <td align="right">供应商名称</td>
              <td align="left">
                   <asp:TextBox ID="txtSupName" runat="server" CssClass="CtextTwo" MaxLength="100"></asp:TextBox>
              </td>
              <td align="right">查询编码</td>
              <td align="left">
                   <asp:TextBox ID="txtddicode" runat="server" CssClass="CtextTwo" MaxLength="100"></asp:TextBox>
              </td>
          </tr>
          <tr style="height: 50px;">
                <td colspan="4" align="center">
                     &nbsp;&nbsp;
                     <asp:Button ID="btnSave" runat="server" Text="保 存" class="scbtn" OnClick="btnSave_Click"  ></asp:Button>&nbsp;&nbsp;
                </td>
            </tr>
       </table>

    </div>
    </form>
</body>
</html>
