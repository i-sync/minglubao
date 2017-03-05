<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdatePassword.aspx.cs"
    Inherits="Web.Enterprise.UpdatePassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>修改密码</title>
    <script src="../JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="../JS/jquery.cookie.js" type="text/javascript"></script>
    <script src="../JS/Common.js" type="text/javascript"></script>
    <link href="../Styles/Site.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(document).ready(function () {
            $("#txtEPOldPassword").blur(function () {
                var msg = "";
                if ($.IsNullOrEmpty($(this).val())) {
                    msg = "<span class='error'>请输入旧密码</span>";
                }
                else if ($(this).val().length < 4) {
                    msg = "<span class='error'>密码至少为4位</span>";
                }
                else if ($(this).val().length > 30) {
                    msg = "<span class='error'>密码最长为30位</span>";
                }
                else {
                    msg = "";
                }
                $("#TipsOld").html(msg);
            });

            $("#txtNewPassword").blur(function () {
                var msg = "";
                if ($.IsNullOrEmpty($(this).val())) {
                    msg = "<span class='error'>请输入新密码</span>";
                }
                else if ($(this).val().length < 4) {
                    msg = "<span class='error'>密码至少为4位</span>";
                }
                else if ($(this).val().length > 30) {
                    msg = "<span class='error'>密码最长为30位</span>";
                }
                else {
                    msg = "";
                }
                $("#TipsNew").html(msg);
            });

            $("#txtConfirm").blur(function () {
                var msg = "";
                if ($.IsNullOrEmpty($(this).val())) {
                    msg = "<span class='error'>请输入确认密码</span>";
                }
                else if ($(this).val().length < 4) {
                    msg = "<span class='error'>密码至少为4位</span>";
                }
                else if ($(this).val().length > 30) {
                    msg = "<span class='error'>密码最长为30位</span>";
                }
                else if ($(this).val() != $("#txtNewPassword").val()) {
                    msg = "<span class='error'>两次密码输入不一致</span>";
                }
                else {
                    msg = "";
                }
                $("#TipsConfirm").html(msg);
            });

            $("#btnSubmit").click(function () {
                $(":text").triggerHandler("blur");
                if ($(".error").length > 0) {
                    alert("请检查红色部分");
                    return false;
                }
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="nav">
        <h3>
            修改密码</h3>
    </div>
    <div class="divlist">
        <table class="tabtxtlist">
            <tr>
                <td class="name">
                    旧密码：
                </td>
                <td>
                    <asp:TextBox ID="txtEPOldPassword" TextMode="Password" class="txt" runat="server"></asp:TextBox>
                    <span>(密码长度为4-30)</span>
                </td>
                <td id="TipsOld"></td>
            </tr>
            <tr>
                <td class="name">
                    新密码：
                </td>
                <td>
                    <asp:TextBox ID="txtNewPassword" TextMode="Password" MaxLength ="30" class="txt" runat="server"></asp:TextBox>
                    <span>(密码长度为4-30)</span>
                </td>
                <td id="TipsNew"></td>
            </tr>
            <tr>
                <td class="name">
                    确认新密码：
                </td>
                <td>
                    <asp:TextBox ID="txtConfirm" TextMode="Password" MaxLength="30" class="txt" runat="server"></asp:TextBox>
                    <span>(密码长度为4-30)</span>
                </td>
                <td id ="TipsConfirm"></td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    <asp:Button ID="btnSubmit" Text="确定" OnClick="btnSubmit_Click" runat="server" CssClass="btn" />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <input type="button" value="取消" class="btn" onclick="history.back();" />
                </td>
            </tr>
        </table>
    </div>
    </form>
    <script id="pagetipsjs" src="/JS/PageTips.js?menuid=30" type="text/javascript"></script>
</body>
</html>
