<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reg.aspx.cs" Inherits="Web.User.Reg" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>个人注册</title>
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

            $("#btnAuthCode").click(function () {
                var username = $("#txtUserName").val();
                var uid = $("#hdUID").val();
                if ($.IsNullOrEmpty(username)) {
                    alert("请输入邮箱！");
                    return false;
                }
                else if (!$.IsEmail(username)) {
                    alert("请输入正确的邮箱!");
                    return false;
                }
                $.ajax({
                    type: "POST",
                    url: "../Handler/UserHandler.ashx",
                    data: { key: "101", uid: uid, email: username },
                    success: function (data) {
                        if (data == "1") {
                            //$("#txtEmailCode").removeAttr("disabled");
                            $("#linkEmail").show();
                            //判断是否是Gmail
                            var mname = username.substring(username.indexOf("@") + 1);
                            var path = "";
                            if (mname.substring(0, 5) == "gmail") {
                                path = "http://www." + mname;
                            }
                            else {
                                path = "http://mail." + mname;
                            }
                            $("#linkEmail").attr("href", path);
                            alert("验证码发送成功，请到你邮箱查收");
                        }
                        else if (data == "0") {
                            alert("验证码插入失败，请重试！");
                        }
                        else if (data == "-2") {
                            alert("该邮箱已注册，请输入其它邮箱");
                        }
                        else if (data == "-1") {
                            alert("邮件发送失败，请重试");
                        }
                    },
                    dataType: "text"
                });
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="wrap">
        <mlb:Header runat="server" ID="header" />
        <div class="webkuang" style=" width:100%;">
            <div class="reg" style=" width:99%;">
                <div class="regcur">
                    1.发送邮箱激活码
                </div>
                <div class="regci">
                </div>
                <div class="regitem">
                    2.免费注册</div>
                <div class="regii">
                </div>
                <div class="regitem">
                    3.注册成功</div>
            </div>
            <div style=" margin:20px auto 20px 200px;">
                <table class="tabweblist">
                    <tr><td colspan="2" style=" color:Red;"><h3>有了名录宝，业务不得了，永久免费！</h3></td></tr>
                    <tr>
                        <td class="name">
                            电子邮箱：
                        </td>
                        <td>
                            <asp:TextBox ID="txtUserName" runat="server" CssClass="txt w300"></asp:TextBox>
                             <asp:HiddenField runat="server" ID="hdUID" />
                        </td>
                    </tr>
                    <tr>
                        <td class="name">
                            验证码：
                        </td>
                        <td>
                            <asp:TextBox ID="txtValidateCode" runat="server" CssClass="txt w60"></asp:TextBox>
                            <img id="span_img" src="../AuthCode.aspx" alt="验证码" />
                            <a class="next">看不清？</a>
                        </td>
                        <td>
                            
                        </td>
                    </tr>
                    <tr>
                        <td class="name">
                            &nbsp;
                        </td>
                        <td>
                            <input type="button" id="btnAuthCode" value="发送验证码" class="btn" />
                            <a id="linkEmail" style="display: none;" target="_blank">点击查看邮箱，进行下一步操作</a>
                        </td>
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
