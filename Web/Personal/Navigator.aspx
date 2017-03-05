<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Navigator.aspx.cs" Inherits="Web.Personal.Navigator" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Styles/index.css" rel="stylesheet" type="text/css" />
    <script src="../JS/jquery-1.6.4.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="neirongbufen fl" style="width:100%" id="divMain">
            <div class="gongsimingcheng">
                帐号：<asp:Literal runat="server" ID="ltLoginName" /><span class="fuzeren">手机号码：<asp:Literal runat="server" ID="ltMobile" /> </span>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
