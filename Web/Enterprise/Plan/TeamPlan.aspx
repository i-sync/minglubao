<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeamPlan.aspx.cs" Inherits="Web.Enterprise.Plan.TeamPlan" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>团队计划</title>
    <script type="text/javascript" src="/JS/jquery-1.6.4.js"></script>
     <script src="/JS/jquery.cookie.js" type="text/javascript"></script>
    <script type="text/javascript" src="/JS/common.js"></script>
    <script type="text/javascript" src="/JS/My97DatePicker/WdatePicker.js"></script>
    <link rel="Stylesheet" type="text/css" href="/Styles/Site.css" />
    <link rel="Stylesheet" type="text/css" href="/JS/My97DatePicker/skin/WdatePicker.css" />
    <script type="text/javascript">
        $(function () {
            $("#txtTradedAmount").blur(function () {
                var num = $.trim($(this).val());
                var msg = "";
                if ($.IsInt(num)) {
                    msg = "<span class='succ'>输入正确</span>";
                }
                else {
                    msg = "<span class='error'>请输入整数</span>";
                }
                $("#TipsTrade").html(msg);
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
                if ($(".error").length > 0) {
                    alert("请检查红色部分");
                    return false;
                }
                if ($.IsNullOrEmpty($("#txtTradedAmount").val())) {
                    $("#TipsTrade").html("<span class='error'>请输入数量！</span>");
                    return false;
                }
                else if ($.IsNullOrEmpty($("#txtTradedMoney").val())) {
                    $("#TipsMoney").html("<span class='error'>请输入金额！</span>");
                    return false;
                }
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="nav">
        <h3>团队计划</h3>
    </div>
    <div class="divlist">
        <table class="tabtxtlist">
            <tr>
                <td class="infoname" style=" width:120px;">
                    月份：
                </td>
                <td>
                    <asp:Label ID ="lblYearMonth" Text ="" CssClass="lbl" runat="server"></asp:Label>
                </td>
                <td id ="TipsDate">&nbsp;</td>
            </tr>
          
            <tr>
                <td class="infoname">
                    每月成交业务数：
                </td>
                <td>
                    <asp:TextBox ID ="txtTradedAmount" CssClass="txt" runat="server"></asp:TextBox>
                </td>
                <td id ="TipsTrade"></td>
            </tr>
           
            <tr>
                <td class="infoname">
                    每月销售金额：
                </td>
                <td>
                    <asp:TextBox ID ="txtTradedMoney" CssClass="txt" runat="server"></asp:TextBox>
                </td>
                <td id ="TipsMoney"></td>
            </tr>
            <tr> 
                <td>
                    &nbsp;
                </td>
                <td colspan="2">
                    <asp:Button ID ="btnSubmit" Text="确定" CssClass="btn" OnClick="btnSubmit_Click" runat="server" />
                </td>
            </tr>
        </table>
    </div>
    </form>
    <script id="pagetipsjs" src="/JS/PageTips.js?menuid=34" type="text/javascript"></script>
</body>
</html>
