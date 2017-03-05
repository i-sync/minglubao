<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Export.aspx.cs" Inherits="Web.Enterprise.Data.Export" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>名录导出</title>
    <link href="../../Styles/Site.css" rel="stylesheet" type="text/css" />
    <script src="../../JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="../../JS/jquery.cookie.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="nav">
        <h3>名录导出</h3>
    </div>
    <div class="divlist">
        <b>名录类型</b>
        <asp:RadioButtonList runat="server" ID="rblStatus" RepeatDirection="Horizontal"/>
        
        <asp:Button runat="server" ID="btnExport" CssClass="btn1" Text="导出" onclick="btnExport_Click" />
    </div>
    
    </form>
    <script id="pagetipsjs" src="/JS/PageTips.js?menuid=37" type="text/javascript"></script>
</body>
</html>
