<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImportingStep3.aspx.cs" Inherits="Web.Personal.Data.ImportingStep3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>名录导入第三步</title>
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
        <div class="step4 step4three">
            <div>
                <a href="ImportingStep1.aspx">1.上传文件</a></div>
            <div>
                <a href="ImportingStep2.aspx">2.映射字段</a></div>
            <div class="cur">
                3.调整数据</div>
            <div>
                4.确认导入</div>
            <i class="clear"></i>
        </div>
        <div class=" mar10">
            <asp:Button runat="server" ID="btnNext" Text="下一步" OnClick="btnNext_Click" CssClass="btn1" />
            <div>
                <b>导入预览</b>
                <asp:GridView runat="server" ID="gvList" AutoGenerateColumns="true">
                </asp:GridView>
            </div>
        </div>
    </div>
    </form>
</body>
</html>