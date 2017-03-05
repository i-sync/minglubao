<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Importing.aspx.cs" Inherits="Web.Personal.Data.Importing" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>名录导入</title>
    <link href="../../Styles/Site.css" rel="stylesheet" type="text/css" />
    <script src="../../JS/jquery-1.6.4.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="nav">
        <h3>名录导入</h3>
    </div>
    <div class="divlist">
        <p style=" color:Red;">请您按照我们提供的模板格式调整您的Excel文件格式。调整至与我们提供的格式完成一致，否则导入失败。<a href="个人名录导入模板.xls" target="_blank">[下载模板]</a></p>
        <MLB:FileUpload runat="server" ID="FileUpload1" />
        <asp:Button runat="server" ID="BtnSubmit" Text="上传并导入" CssClass="btn1" onclick="BtnSubmit_Click" />
    </div>
    
    </form>
</body>
</html>
