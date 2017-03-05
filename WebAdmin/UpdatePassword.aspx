<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdatePassword.aspx.cs" Inherits="WebAdmin.UpdatePassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="images/main.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="js/common.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            
            //原密码
            $("#txtOldPassword").blur(function () {
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

            //新密码
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

            //确认密码
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
                    return false;
                }
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table align="center" width="98%" class="tableBorder">
            <tr>
                <th class="bigTitle" colspan="4">
                    企业基本信息
                </th>
            </tr>
            <tr>
                <td>
                    <table class="tabtxtlist">
                        <tr>
                            <td class="name">
                                旧密码：
                            </td>
                            <td>
                                <asp:TextBox ID="txtOldPassword" TextMode="Password" class="txt" runat="server"></asp:TextBox>
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
                                <asp:Button ID="btnSubmit" Text="确定" OnClick="btnSubmit_Click" runat="server"  />
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                <input type="button" value="取消"  onclick="history.back();" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
