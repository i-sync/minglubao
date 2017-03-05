<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImportingStep4.aspx.cs" Inherits="Web.Enterprise.Data.ImportingStep4" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>名录导入第四步</title>
    <link href="../../Styles/Site.css" rel="stylesheet" type="text/css" />
    <script src="/JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="/JS/jquery.cookie.js" type="text/javascript"></script>
</head>
<body>
<div class="nav">
        <h3>
            名录导入</h3>
    </div>
    <form id="form1" runat="server">
    <div class="divlist">
        <div class="step4 step4four">
            <div>
                <a href="ImportingStep1.aspx">1.上传文件</a></div>
            <div>
                <a href="ImportingStep2.aspx">2.映射字段</a></div>
            <div>
                <a href="ImportingStep3.aspx">3.调整数据</a></div>
            <div class="cur">
                4.确认导入</div>
            <i class="clear"></i>
        </div>
        <div class=" mar10">
            <asp:Button runat="server" ID="btnSubmit" Text="导入" CssClass="btn1" 
                onclick="btnSubmit_Click"/>
                <asp:Panel runat="server" ID="plResult" CssClass=" mar10" Visible="false">
                    <p>导入成功: <span class="green b"><asp:Literal runat="server" ID="ltSucc" Text="0" /></span> 条.</p>
                    <p>导入失败: <span class="red b"><asp:Literal runat="server" ID="ltFail" Text="0" /></span> 条.</p>
                </asp:Panel>
        </div>
    </div>
    </form>
    <script id="pagetipsjs" src="/JS/PageTips.js?menuid=55" type="text/javascript"></script>
</body>
</html>
