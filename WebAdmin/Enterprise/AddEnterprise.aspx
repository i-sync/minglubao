<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddEnterprise.aspx.cs"
    Inherits="WebAdmin.Enterprise.AddEnterprise" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>增加企业</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <link href="../images/main.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="../js/common.js" type="text/javascript"></script>
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $(".Wdate").focus(function () { WdatePicker(); });
            //企业号验证
            $("#txtEPCode").blur(function () {
                var v = $.trim($(this).val());
                if (v.length==0) {
                    $("#codeTips").text("");
                    return;
                }
                $("#codeTips").text("验证中");
                var data = "key=100&code=" + escape(v) + "&t=" + Math.random();
                $.get("Handler.ashx", data, function (res) {
                    if (res == "1") {//已经存在
                        $("#codeTips").text("已经存在");
                    } else {
                        $("#codeTips").text("可以使用");
                    }
                }, "text");
            });

            $("form").submit(function () {
                if ($.IsNullOrEmpty($("#txtEPCode").val())) { alert("请输入企业号"); $("#txtEPCode").focus(); return false; }
                if ($.IsNullOrEmpty($("#txtEPName").val())) { alert("请输入企业名称"); $("#txtEPName").focus(); return false; }
                if ($.IsNullOrEmpty($("#txtItemName").val())) { alert("请输入项目名称"); $("#txtItemName").focus(); return false; }
                //if ($.IsNullOrEmpty($("#txtLinkman").val())) { alert("请输入联系人"); $("#txtLinkman").focus(); return false; }
                //if ($.IsNullOrEmpty($("#txtPosition").val())) { alert("请输入联系人职务"); $("#txtPosition").focus(); return false; }
                //if ($.IsNullOrEmpty($("#txtTel").val())) { alert("请输入电话号码"); $("#txtTel").focus(); return false; }
                //if (!$.IsTel($("#txtTel").val())) { alert("请输入正确的电话号码"); $("#txtTel").focus(); return false; }
                //if (!$.IsEmail($("#txtEmail").val())) { alert("请输入正确的邮箱"); $("#txtEmail").focus(); return false; }
                //if (!$.IsNullOrEmpty($("#txtMobile").val()) && !$.IsMobile($("#txtMobile").val())) { alert("请输入正确的手机号码"); $("#txtMobile").focus(); return false; }
                if (!$.IsInt($("#txtUserAmount").val())) { alert("请输入正确的购买用户数量"); $("#txtUserAmount").focus(); return false; }
                if (!$.IsDate($("#txtStartDate").val())) { alert("请选择开始日期"); $("#txtStartDate").focus(); return false; }
                if (!$.IsDate($("#txtEndDate").val())) { alert("请选择截止日期"); $("#txtEndDate").focus(); return false; }
                if (!$.CompareDate($("#txtStartDate").val(), $("#txtEndDate").val())) {
                    alert("开始日期不能大于等于截止日期");
                    return false;
                }
                if ($.IsNullOrEmpty($("#txtAdminUserName").val())) { alert("请输入管理员帐号"); $("#txtAdminUserName").focus(); return false; }
                
                return true;
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table align="center" width="98%" class="tableBorder">
			<tr>
				<th  colspan="4" class="bigTitle">企业信息</th>
			</tr>
            <tr>                
                <asp:Literal ID="ltTips" runat="server"></asp:Literal>                
            </tr>
            <tr>
                <td class="title">
                    企业号：
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtEPCode" />
                </td>
                <td  colspan="2" id="codeTips"></td>
            </tr>
            <tr>
                <td class="title">
                    企业名称：
                </td>
                <td colspan="3">
                    <asp:TextBox runat="server" ID="txtEPName" Width="400" />
                </td>
            </tr>
            <tr>
                <td class="title">
                    项目名称：
                </td>
                <td colspan="3">
                    <asp:TextBox runat="server" ID="txtItemName"  Width="400" />
                </td>
            </tr>
            <tr>
                <td class="title">
                    联系人：
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtLinkman" />
                </td>
                <td class="title">
                    联系人职务：
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtPosition" />
                </td>
            </tr>
            <tr>
                <td class="title">
                    电话：
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtTel" />
                </td>
                <td class="title">
                    邮箱：
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtEmail" />
                </td>
            </tr>
            <tr>
                <td class="title">
                    手机：
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtMobile" />
                </td>
                <td class="title">
                    传真：
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtFax" />
                </td>
            </tr>
            <tr>
                <td class="title">
                    地址：
                </td>
                <td colspan="3">
                    <asp:TextBox runat="server" ID="txtAddress" Width="400" />
                </td>
            </tr>
            <tr>
                <td class="title">
                    购买用户数量：
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtUserAmount" />
                </td>
                <td class="title">
                    有效期：
                </td>
                <td >
                    <asp:TextBox runat="server" ID="txtStartDate" CssClass="Wdate" />
                    至
                    <asp:TextBox runat="server" ID="txtEndDate" CssClass="Wdate" />
                </td>
            </tr>
            <tr>
                <td class="title">
                    管理员帐号：
                </td>
                <td colspan="3">
                    <asp:TextBox runat="server" ID="txtAdminUserName" />
                </td>
            </tr>
            <tr>
                <td class="title">
                    管理员密码：
                </td>
                <td colspan="3">
                    <asp:TextBox runat="server" ID="txtAdminPassword" MaxLength="30" />
                    <span>(密码长度为4-30)</span>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td colspan="3">
                    <asp:Button runat="server" ID="btnSubmit" Text="提交" OnClick="btnSubmit_Click" />
                    <input type ="button" value ="返回" onclick="window.location.replace('List.aspx');" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
