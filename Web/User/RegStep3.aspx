<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegStep3.aspx.cs" Inherits="Web.User.RegStep3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>个注册</title>
    <script src="../JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="../JS/common.js" type="text/javascript"></script>
    <link href="/Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="/Styles/web.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="wrap">
        <mlb:Header runat="server" ID="header" />
        <div class="webkuang">
            <div class="reg">
                <div class="regitem">
                    1.发送邮箱激活码
                </div>
                <div class="regii">
                </div>
                <div class="regitem">
                    2.免费注册</div>
                <div class="regic">
                </div>
                <div class="regcur">
                    3.注册成功</div>
            </div>
            <div style=" margin:80px auto 20px 200px;">
                <div class="regsucc">
                <div class="regsucctip">恭喜您，注册成功！</div>
                </div>
                <div><a href="/" class="logintip">登录，开始使用名录宝</a></div>
            </div>
            <div class="webkuangfoot">
            </div>
        </div>
    </div>
    <mlb:Bottom runat="server" ID="bottom" />
    </form>
</body>
</html>
