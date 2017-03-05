<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegStep2.aspx.cs" Inherits="Web.User.RegStep2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>个注册</title>
    <script src="../JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="../JS/common.js" type="text/javascript"></script>
    <link href="/Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="/Styles/web.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            $("#btnSubmit").click(function () {
                var username = $("#txtUserName").val();
                var emailcode = $("#txtEmailCode").val();
                var password = $("#txtPassword").val();
                var confirm = $("#txtConfirm").val();
                var realname = $("#txtRealName").val();
                var mobile = $("#txtMobile").val();
                var tel = $("#txtTel").val();
                var fax = $("#txtFax").val();
                var address = $("#txtAddress").val();
                if (!$.IsEmail(username)) {
                    alert("请输入正确的邮箱!");
                    return false;
                }
                if ($.IsNullOrEmpty(username)) {
                    alert("请输入邮箱！");
                    return false;
                } else if ($.IsNullOrEmpty(emailcode)) {
                    alert("请输入邮箱验证码!");
                    return false;
                }
                else if ($.IsNullOrEmpty(password)) {
                    alert("请输入密码!");
                    return false;
                }
                else if ($.IsNullOrEmpty(confirm)) {
                    alert("请再次确定密码!");
                    return false;
                }
                else if ($.IsNullOrEmpty(realname)) {
                    alert("请输入真实姓名！");
                    return false;
                }
                else if ($.IsNullOrEmpty(mobile)) {
                    alert("手机号不能为空！");
                    return false;
                }
                else if ($.IsNullOrEmpty(address)) {
                    alert("地址不能为空！");
                    return false;
                }
                if (password != confirm) {
                    alert("两次密码输入不一致！");
                    return false;
                }
                if (!$.IsMobile(mobile)) {
                    alert("请输入正确的手机号！");
                    return false;
                }
            });
        });
    </script>
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
                <div class="regic"></div>
                <div class="regcur">2.免费注册</div>
                <div class="regci"></div>
                <div class="regitem">3.注册成功</div>
            </div>
            <div>
                <table  class="tabweblist">
                    <tr>
                        <td class="name">
                            电子邮箱：
                        </td>
                        <td>
                            <asp:TextBox ID="txtUserName" runat="server" CssClass="txte w300" ReadOnly="true"></asp:TextBox>
                        </td>
                        <td>
                            <asp:HiddenField runat="server" ID="hdUID" />
                        </td>
                    </tr>
                    <tr>
                        <td class="name">
                            邮箱验证码：
                        </td>
                        <td>
                            <asp:TextBox ID="txtEmailCode" runat="server" CssClass="txte"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="name">
                            密码：
                        </td>
                        <td>
                            <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" CssClass="txt"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="name">
                            确定密码：
                        </td>
                        <td>
                            <asp:TextBox ID="txtConfirm" TextMode="Password" runat="server" CssClass="txt"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="name">
                            真实姓名：
                        </td>
                        <td>
                            <asp:TextBox ID="txtRealName" runat="server" CssClass="txt"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="name">
                            性别：
                        </td>
                        <td>
                            <asp:RadioButtonList RepeatLayout="Flow" RepeatDirection="Horizontal" ID="rbSex"
                                runat="server">
                                <asp:ListItem Text="男" Value="1" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="女" Value="0"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="name">
                            手机号码：
                        </td>
                        <td>
                            <asp:TextBox ID="txtMobile" runat="server" CssClass="txt"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="name">
                            联系电话：
                        </td>
                        <td>
                            <asp:TextBox ID="txtTel" runat="server" CssClass="txt"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="name">
                            传真：
                        </td>
                        <td>
                            <asp:TextBox ID="txtFax" runat="server" CssClass="txt"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="name">
                            地址：
                        </td>
                        <td colspan="2">
                            <asp:TextBox ID="txtAddress" runat="server" CssClass="txt"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td><asp:Button ID="btnSubmit" Text="注册" OnClick="btnSubmit_Click" runat="server" CssClass="btn" /></td>
                    </tr>
                </table>
            </div>
            <div class="webkuangfoot">
            </div>
        </div>
    </div>
    <mlb:Bottom runat="server" ID="bottom" />
    </form>
</body>
</html>
