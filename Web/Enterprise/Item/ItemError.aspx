<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemError.aspx.cs" Inherits="Web.Enterprise.Item.ItemError" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>错误</title>
    <link type="text/css" rel="Stylesheet" href="/Styles/Site.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="nav">
        <h3>错误</h3>
    </div>
    <div class="divlist">
        <h4>            
            <asp:Literal ID="ltContent" runat="server" Text="您没有权限或该项目尚未开通，所有无法查看！"></asp:Literal>
        </h4>
    </div>
    </form>
</body>
</html>
