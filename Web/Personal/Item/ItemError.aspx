<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemError.aspx.cs" Inherits="Web.Personal.Item.ItemError" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>错误</title>
    <link href="/Styles/Site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="nav">
        <h3>错误</h3>
    </div>
    <div class="divlist">
        <h4>
            <asp:Literal ID="ltContent" runat="server" Text="您还没有加入项目无法操作或您所加入的企业项目还未开通！"></asp:Literal>
        </h4>
    </div>
    </form>
</body>
</html>
