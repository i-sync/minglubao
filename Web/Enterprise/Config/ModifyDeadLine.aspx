<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModifyDeadLine.aspx.cs" Inherits="Web.Enterprise.Config.ModifyDeadLine" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>名录期限设置</title>
    <link href="../../Styles/Site.css" rel="stylesheet" type="text/css" />
    <script src="../../JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="../../JS/jquery.cookie.js" type="text/javascript"></script>
    <script src="../../JS/common.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $("#txtDeadLine").blur(function () {
                var v = $.trim($(this).val());
                var msg = "";
                if ($.IsNullOrEmpty(v)) {
                    msg = "<span class='error'>请输入期限</span>";
                }
                else if (!$.IsInt(v)) {
                    msg = "<span class='error'>请输入正确的整数</span>";
                }
                else {
                    msg = "";
                }
                $("#TipsDeadLine").html(msg);
            });
            $("#txtRemind").blur(function () {
                var v = $.trim($(this).val());
                var msg = "";
                if ($.IsNullOrEmpty(v)) {
                    msg = "<span class='error'>请输入期限</span>";
                }
                else if (!$.IsInt(v)) {
                    msg = "<span class='error'>请输入正确的整数</span>";
                }
                else {
                    msg = "";
                }
                $("#TipsRemind").html(msg);
            });

            $("#btnSubmit").click(function () {
                $("#txtDeadLine").triggerHandler("blur");
                $("#txtRemind").triggerHandler("blur");
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
    <div>
        <div class="nav">
            <h3>名录期限设置</h3>
        </div>
        <div class="divlist">
     
            <table>
                <tr style=" line-height:35px; ">
                    <td valign="top">期限设置：</td>
                    <td valign="middle">
                        潜在客户<asp:TextBox ID = "txtLatenDay" CssClass="txt w50" MaxLength="3" runat="server"/>天后没有转为意向客户，将进入共享池。系统将提前<asp:TextBox ID = "txtLRemindDay" CssClass="txt w50" MaxLength="2" runat="server"/>天提示。<br />
                        意向客户<asp:TextBox ID = "txtWishDay" CssClass="txt w50" MaxLength="3" runat="server"/>天后无法成交，将进入失败客户，默认失败理由:<asp:DropDownList runat="server" CssClass="ddl" ID="ddlNotTraded"></asp:DropDownList>。系统将提前<asp:TextBox ID = "txtWRemindDay" CssClass="txt w50" MaxLength="2" runat="server"/>天提示。
                    </td>
                    <td id="TipsDeadLine">
                        
                    </td>
                    <td id ="TipsRemind">
                        
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td colspan="3" style="color:Red; height:25px;">设置天数为0，表示不启用此功能。提醒天数为0,表示不启用提醒功能。</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td colspan="3">
                        <asp:Button ID = "btnSubmit" Text="确定" CssClass="btn" runat="server" OnClick = "btnSubmit_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
    <script id="pagetipsjs" src="/JS/PageTips.js?menuid=56" type="text/javascript"></script>
</body>
</html>
