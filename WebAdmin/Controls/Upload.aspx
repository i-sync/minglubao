<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Upload.aspx.cs" Inherits="WebAdmin.Controls.Upload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link href="../../Styles/Site.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
    *{ margin:0; font-size:12px;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <input type="file" id="File1" name="File1" runat="server"/>
    <asp:Button runat="server" ID="BtnUpload" Text="上传" onclick="BtnUpload_Click" />
    </div>
    </form>
</body>
</html>
