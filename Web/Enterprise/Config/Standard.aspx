<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Standard.aspx.cs" Inherits="Web.Enterprise.Config.Standard" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>最低标准设置</title>
    <script src="../../JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="../../JS/jquery.cookie.js" type="text/javascript"></script>
    <script src="../../JS/Common.js" type="text/javascript"></script>
    <link href="../../Styles/Site.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(document).ready(function () {
            $("#txtNewAmount").blur(function () {
                var num = $(this).val();
                var msg = "";
                if ($.IsInt(num) && num > 0) {
                    msg = "<span class='succ'>输入正确</span>";
                }
                else {
                    msg = "<span class='error'>请输入整数</span>";
                }
                $("#TipsNew").html(msg);
            });
            $("#txtCommAmount").blur(function () {
                var num = $(this).val();
                var msg = "";
                if ($.IsInt(num)) {
                    msg = "<span class='succ'>输入正确</span>";
                }
                else {
                    msg = "<span class='error'>请输入整数</span>";
                }
                $("#TipsComm").html(msg);
            });
            $("#txtTradedAmount").blur(function () {
                var num = $(this).val();
                var msg = "";
                if ($.IsInt(num)) {
                    msg = "<span class='succ'>输入正确</span>";
                }
                else {
                    msg = "<span class='error'>请输入整数</span>";
                }
                $("#TipsTraded").html(msg);
            });
            $("#txtTradedMoney").blur(function () {
                var num = $(this).val();
                var msg = "";
                if ($.IsFloat(num)) {
                    msg = "<span class='succ'>输入正确</span>";
                }
                else {
                    msg = "<span class='error'>请输入数字</span>";
                }
                $("#TipsMoney").html(msg);
            });
            $("#btnSubmit").click(function () {
                if ($.IsNullOrEmpty($("#txtNewAmount").val())) {
                    $("#TipsNew").html("<span class='error'>请输入每天录入名录数量！</span>");
                    return false;
                }
                else if ($.IsNullOrEmpty($("#txtCommAmount").val())) {
                    $("#TipsComm").html("<span class='error'>请输入每天沟通名录数量! </span>");
                    return false;
                }
                else if ($.IsNullOrEmpty($("#txtTradedAmount").val())) {
                    $("#TipsTraded").html("<span class='error'>请输入每月成交记录数量！</span>");
                    return false;
                }
                else if ($.IsNullOrEmpty($("#txtTradedMoney").val())) {
                    $("#TipsTraded").html("<span class='error'>请输入每月交易金额！</span>");
                    return false;
                }
                if ($(".error").length > 0) {
                    alert("有错误，请检查");
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
            最低标准设置</h3>
    </div>
    <div class="editlist">
        <table>
            <tr>
                <td class="name">
                    每天录入名录数量：
                </td>
                <td>
                    <asp:TextBox ID="txtNewAmount" CssClass="txt" runat="server"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
                <td id="TipsNew">
                </td>
            </tr>
            <tr>
                <td class="name">
                    每天沟通名录数量：
                </td>
                <td>
                    <asp:TextBox ID="txtCommAmount" CssClass="txt" runat="server"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
                <td id="TipsComm">
                </td>
            </tr>
            <tr>
                <td class="name">
                    每月成交业务数：
                </td>
                <td>
                    <asp:TextBox ID="txtTradedAmount" CssClass="txt" runat="server"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
                <td id="TipsTraded">
                </td>
            </tr>
            <tr>
                <td class="name">
                    每月销售金额：
                </td>
                <td>
                    <asp:TextBox ID="txtTradedMoney" CssClass="txt" runat="server"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
                <td id="TipsMoney">
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td colspan="3">
                    <asp:Button ID="btnSubmit" CssClass="btn" Text="确定" OnClick="btnSubmit_Click" runat="server" />
                </td>
            </tr>
        </table>
    </div>
    </form>
    <script id="pagetipsjs" src="/JS/PageTips.js?menuid=21" type="text/javascript"></script>
</body>
</html>
