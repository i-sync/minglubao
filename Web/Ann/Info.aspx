<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Info.aspx.cs" Inherits="Web.Ann.Info" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>名录宝公告信息</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <link href="../Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/web.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="wrap">
        <mlb:Header runat="server" ID="header" />
        <div class="webkuang">
            <div class="app">
                名录宝公告信息</div>
            <div class="anninfopage">
                <div class="title">
                    <h3>
                        <asp:Literal ID="ltAnnTitle" runat="server" /></h3>
                </div>
                <div class="titBar">
                    <asp:Literal ID="ltAddDate" runat="server" /></div>
                <div class="content">
                    <asp:Literal ID="ltContent" runat="server" /></div>
            </div>
            <div class="webkuangfoot">
            </div>
        </div>
    </div>
    <mlb:Bottom runat="server" ID="bottom" />
    </form>
</body>
</html>
