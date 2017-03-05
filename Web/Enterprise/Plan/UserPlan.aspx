<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserPlan.aspx.cs" Inherits="Web.Enterprise.Plan.UserPlan" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>个人计划设置</title>
    <script type="text/javascript" src="../../JS/jquery-1.6.4.js"></script>
    <script src="../../JS/jquery.cookie.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../JS/common.js"></script>
    <script type="text/javascript" src="../../JS/My97DatePicker/WdatePicker.js"></script>
    <link rel="Stylesheet" type="text/css" href="../../Styles/Site.css" />
    <link rel="Stylesheet" type="text/css" href="../../JS/My97DatePicker/skin/WdatePicker.css" />
        <script type="text/javascript">
            $(function () {
                //---------------基本的验证--------------
                //录入数量，失去焦点事件
                $("#txtNewAmount").blur(function () {
                    var num = $.trim($(this).val());
                    var msg = "";
                    if ($.IsInt(num)) {
                        msg = "<span class='succ'>输入正确</span>";
                    }
                    else {
                        msg = "<span class='error'>请输入整数</span>";
                    }
                    $("#TipsNew").html(msg);
                });
                //沟通数量，失去焦点验证事件
                $("#txtContactAmount").blur(function () {
                    var num = $.trim($(this).val());
                    var msg = "";
                    if ($.IsInt(num)) {
                        msg = "<span class='succ'>输入正确</span>";
                    }
                    else {
                        msg = "<span class='error'>请输入整数</span>";
                    }
                    $("#TipsCon").html(msg);
                });
                //成交数量，失去焦点验证事件
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
                //成交金额，失去焦点验证事件
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
                    if ($.IsNullOrEmpty($("#txtNewAmount").val())) {
                        $("#TipsNew").html("<span class='error'>请输入每日新增名录数量</span>");
                        return false;
                    }
                    else if ($.IsNullOrEmpty($("#txtContactAmount").val())) {
                        $("#TipsCon").html("<span class='error'>请输入每日沟通名录数量</span>");
                        return false;
                    }
                    else if ($.IsNullOrEmpty($("#txtTradedAmount").val())) {
                        $("#TipsTrade").html("<span class='error'>请输入交易数量</span>");
                        return false;
                    }
                    else if ($.IsNullOrEmpty($("#txtTradedMoney").val())) {
                        $("#TipsMoney").html("<span class='error'>请输入交易金额</span>");
                        return false;
                    }
                });
            });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="nav">
        <h3>个人计划设置</h3>
    </div>
    <div class="divlist">
        <table class="tabtxtlist">
            <tr>
                <td class="name120">
                    选择月份：
                </td>
                <td>
                    <asp:Label ID ="lblYearMonth" runat="server" ></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="name120">
                    每日新增名录数：
                </td>
                <td>
                    <asp:TextBox ID ="txtNewAmount" CssClass="txt" runat="server"></asp:TextBox>
                </td>
                <td id ="TipsNew"></td>                
            </tr>
            <tr>
                <td class="name120">
                    每日沟通名录数：
                </td>
                <td>
                    <asp:TextBox ID ="txtContactAmount" CssClass="txt" runat="server"></asp:TextBox>
                </td>
                <td id="TipsCon"></td>                
            </tr>
            <tr>
                <td class="name120">
                    每月成交业务数：
                </td>
                <td>
                    <asp:TextBox ID ="txtTradedAmount" CssClass="txt" runat="server"></asp:TextBox>
                </td>
                <td id ="TipsTrade"></td>                
            </tr>
            <tr>
                <td class="name120">
                    每月销售金额：
                </td>
                <td>
                    <asp:TextBox ID ="txtTradedMoney" CssClass="txt" runat="server"></asp:TextBox>
                </td>
                <td id="TipsMoney"></td>                
            </tr>    
            <tr>
                <td>
                    &nbsp;
                </td>   
                <td>
                    <asp:Button ID ="btnSubmit" Text="确定" CssClass="btn" OnClick="btnSubmit_Click" runat="server" />
                </td> 
                <td>
                    &nbsp;
                </td>               
            </tr>
        </table>
    </div>
    </form>
    <script id="pagetipsjs" src="/JS/PageTips.js?menuid=35" type="text/javascript"></script>
</body>
</html>
