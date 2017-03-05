<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetPassword.aspx.cs" Inherits="Web.User.GetPassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>找回密码</title>
    <script src="../JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="../JS/common.js" type="text/javascript"></script>
    <link href="/Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="/Styles/web.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
     .next{ cursor:pointer;}
    .nexthover{ text-decoration:underline;}
    </style>
    <script type="text/javascript">
        $(function () {
            $(".next").click(function () {
                $("#span_img").attr("src", "../AuthCode.aspx?t=" + Math.random());
            }).mouseover(function () {
                $(this).addClass("nexthover");
            }).mouseout(function () {
                $(this).removeClass("nexthover");
            });
        });

        function ValidateCode(o, e) {
            var value = e.Value;
            var result = document.cookie;
            result = result.substr(result.lastIndexOf("=") + 1, 4)
            result = result.toLowerCase();
            value = value.toLowerCase();
            if (value == result)
                e.IsValid = true;
            else
                e.IsValid = false;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="wrap">
        <mlb:Header runat="server" ID="header" />
        <div class="webkuang">
            <div class="app">
                忘记密码</div>
            <table border="0" cellspacing="1" cellpadding="1" class="tabweblist">
                <tr>
                    <td class="name" style="width: 100px;">
                        注册邮箱：
                    </td>
                    <td colspan="3">
                        <asp:TextBox runat="server" ID="txtUserName" CssClass="txt w300" />
                    </td>
                </tr>
                <tr>
                    <td class="name">
                        验证码：
                    </td>
                    <td>
                        <asp:TextBox ID="txtValidateCode" runat="server" CssClass="txt w60"></asp:TextBox>
                        <asp:CustomValidator ID="validateCode" ControlToValidate="txtValidateCode" ValidateEmptyText="true"
                            ClientValidationFunction="ValidateCode" Text="*" ErrorMessage="验证码输入错误!" runat="server"></asp:CustomValidator>
                    </td>
                    <td>
                        <img id="span_img" src="../AuthCode.aspx" alt="验证码" />
                        <a class="next">看不清？</a>
                        <asp:ValidationSummary ID="validateSummary" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td><asp:Button ID="btnSubmit" Text="确定" OnClick="btnSubmit_Click" runat="server" CssClass="btn" /></td>
                </tr>
            </table>
            <div class="webkuangfoot">
            </div>
        </div>
    </div>
    <mlb:Bottom runat="server" ID="bottom" />
    </form>
</body>
</html>
