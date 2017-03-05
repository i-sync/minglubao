<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Web.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>名录宝</title>
    <link rel="Bookmark" href="favicon.ico" />
    <link rel="Shortcut Icon" href="favicon.ico" />
    <link href="Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="Styles/web.css" rel="stylesheet" type="text/css" />
    <link href="Styles/msgbox.css" rel="stylesheet" type="text/css" />
    <script src="JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="JS/common.js" type="text/javascript"></script>
    <script type="text/javascript">
        var Constant = {
        Login_URL:'handler/login.ashx'
    };
    $(function () {
        $(".loginTag div[tagtype]").click(function () {
            var tagtype = $(this).attr("tagtype");
            $(".loginform div").hide();
            if (tagtype == "ep") {//企业
                $(".loginTag").attr("class", "loginTag curep");
                $(".loginform .ep").show();
            }
            else {
                $(".loginTag").attr("class", "loginTag curps");
                $(".loginform .ps").show();
            }
        });
        $("#txtEPCode").focus();
        //--企业登录
        $("#btnEPLogin").click(function () {
            var code = $.trim($("#txtEPCode").val());
            var name = $.trim($("#txtEPUserName").val());
            var pwd = $.trim($("#txtEPPassword").val());
            var data = "type=1&code=" + code + "&name=" + name + "&pwd=" + pwd;

            $.ajax({
                type: "POST",
                url: URLPlusRandom(Constant.Login_URL),
                data: data,
                success: function (result) {
                    if (result === "1") {
                        top.location.href = "enterprise/selectrole.aspx";
                    } else {
                        alert("登录信息错误，请重新输入登录信息！");
                    }
                },
                error: function (data) {
                    alert("登录失败");
                },
                dataType: "text"
            });
        });
        $("#txtEPPassword").keydown(function (e) {
            var code = window.event ? e.keyCode : e.which;
            if (code === 13) {
                $("#btnEPLogin").trigger("click");
                return false;
            }
        });

        //--个人登录
        $("#btnPLogin").click(function () {
            var name = $("#txtPUserName").val();
            var pwd = $("#txtPPassword").val();
            var auto = $("#cbAuto").attr("checked") == "checked" ? "1" : "0";
            var data = "type=2&name=" + name + "&pwd=" + pwd + "&auto=" + auto + "&screen=" + escape(screen.width + 'x' + screen.height);

            $.ajax({
                type: "POST",
                url: URLPlusRandom(Constant.Login_URL),
                data: data,
                success: function (result) {
                    if (result === "1") {
                        top.location.href = "personal/index.html";
                    } else {
                        alert("登录信息错误，请重新输入登录信息！");
                    }
                },
                error: function (data) {
                    alert("登录失败！");
                },
                dataType: "text"
            });
        });
        //个人回车
        $("#txtPPassword").keydown(function (e) {
            var code = window.event ? e.keyCode : e.which;
            if (code === 13) {
                $("#btnPLogin").trigger("click");
                return false;
            }
        });
        ///-------------个人的自动登录-------------
        //获取cookie信息
        var logininfo = $.cookie("autologin");
        if (logininfo != null) {
            var name = logininfo.substr(0, logininfo.indexOf('&'))
            var pwd = logininfo.substr(logininfo.indexOf('&') + 1);
            name = name.substr(name.indexOf('=') + 1);
            pwd = pwd.substr(pwd.indexOf('=') + 1);
            $("#txtPUserName").val(name);
            $("#txtPPassword").val(pwd);
            $("#cbAuto").attr("checked", "checked");
            $("#btnPLogin").trigger("click");
        }
        ///---------------------------------------
    });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="wrap dengbubg">
        <div class="top">
            <div class="fl logo">
                <img src="images/logo2.jpg" title="名录宝" alt="名录宝" /></div>
            <div class="fr link">
                <a href="apply.aspx">
                    <img src="images/qiyeshenqing.jpg" alt="企业申请" />
                    企业申请</a> <a href="user/reg.aspx">
                        <img src="images/gerenzhuce.jpg" alt="个人注册" />
                        个人免费注册</a> <a href="mlb.exe" target="_blank">
                            <img src="images/xiazai.jpg" alt="下载名录宝桌面快捷方式" />下载名录宝桌面快捷方式 </a>
            </div>
        </div>
        <div class="loginTag curep">
            <div tagtype="ep">
            </div>
            <div tagtype="ps">
            </div>
        </div>
        <div class="loginform">
            <div class="ep">
                <table>
                    <tr>
                        <td class="nametag">
                            企业号：
                        </td>
                        <td>
                            <input type="text" id="txtEPCode" class="txt w190" />
                        </td>
                    </tr>
                    <tr>
                        <td class="nametag">
                            帐&nbsp;&nbsp;&nbsp;&nbsp;号：
                        </td>
                        <td>
                            <input type="text" id="txtEPUserName" class="txt w190" />
                        </td>
                    </tr>
                    <tr>
                        <td class="nametag">
                            密&nbsp;&nbsp;&nbsp;&nbsp;码：
                        </td>
                        <td>
                            <input type="password" id="txtEPPassword" class="txt w190" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <input type="button" id="btnEPLogin" name="btnEPLogin" class="btn" value="登录" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <input type="button" id="btnEPApply" value="申请" onclick="location.href='apply.aspx';"
                                class="btn" />
                        </td>
                    </tr>
                </table>
            </div>
            <div class="ps" style="display: none;">
                <table>
                    <tr>
                        <td class="nametag">
                            邮&nbsp;&nbsp;&nbsp;&nbsp;箱：
                        </td>
                        <td>
                            <input type="text" id="txtPUserName" class="txt w190" />
                        </td>
                    </tr>
                    <tr>
                        <td class="nametag">
                            密&nbsp;&nbsp;&nbsp;&nbsp;码：
                        </td>
                        <td>
                            <input type="password" id="txtPPassword" class="txt w190" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <input type="checkbox" id="cbAuto" name="cbAuto" value="1" /><label for="cbAuto">自动登录</label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <input type="button" id="btnPLogin" value="登录" class="btn" />
                            <a href="User/GetPassword.aspx" class="zhmm">找回密码</a>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    
    <div class="copyright">
        copyright 2011 名录宝</div>
    </form>
    <script src="JS/tongji.js" type="text/javascript"></script>
</body>
</html>
