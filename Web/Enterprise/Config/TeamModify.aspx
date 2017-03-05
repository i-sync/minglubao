<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeamModify.aspx.cs" Inherits="Web.Enterprise.Config.TeamModify" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>团队信息</title>
    <script src="../../JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="../../JS/jquery.cookie.js" type="text/javascript"></script>
    <script src="../../JS/Common.js" type="text/javascript"></script>
    <link href="../../Styles/Site.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        var Tips = {
            succ: '输入正确'
        };
        $(document).ready(function () {
            ///验证团队名称
            $("#txtTeamName").blur(function () {
                var v = $.trim($(this).val());
                var msg = "";
                if ($.IsNullOrEmpty(v)) {
                    msg = "<span class='error'>请输入团队名称</span>";
                } else {
                    msg = "<span class='succ'>" + Tips.succ + "</span>";
                }
                $("#TipsName").html(msg);
            });
            /*
            //验证团队口号
            $("#txtSignature").blur(function () {
                var v = $.trim($(this).val());
                var msg = "";
                if ($.IsNullOrEmpty(v)) {
                    msg = "<span class='error'>请输入团队口号</span>";
                } else {
                    msg = "<span class='succ'>" + Tips.succ + "</span>";
                }
                $("#TipsSign").html(msg);
            });
            */
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
            团队信息</h3>
    </div>
    <div class="divlist">
        <table class="tabtxtlist">
            <tr>
                <td>
                    名称：
                </td>
                <td>
                    <asp:TextBox ID="txtTeamName" CssClass="txt w300" runat="server"/>
                </td>
                <td>
                    &nbsp;
                </td>
                <td id="TipsName">
                </td>
            </tr>
            <tr>
                <td>
                    口号：
                </td>
                <td>
                    <asp:TextBox ID="txtSignature" CssClass="txt w420" runat="server"/>
                </td>
                <td>
                    &nbsp;
                </td>
                <td id="TipsSign">
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    <asp:Button ID="btnSubmit" Text="确定" CssClass="btn" OnClick="btnSubmit_Click" runat="server" />
                </td>
            </tr>
        </table>
    </div>
    </form>
    <script id="pagetipsjs" src="/JS/PageTips.js?menuid=29" type="text/javascript"></script>
</body>
</html>
