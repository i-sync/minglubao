<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EnterpriseEdit.aspx.cs" Inherits="Web.Enterprise.EnterpriseEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>管理员修改企业基本信息</title>
    <link href="../Styles/Site.css" rel="stylesheet" type="text/css" />
    <script src="/JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="/JS/jquery.cookie.js" type="text/javascript"></script>
    <script src="../JS/common.js" type="text/javascript"></script>

    <script type="text/javascript">
        var Tips = {
            succ: '输入正确'
        };
        $(function () {
            //检测检查项目名称
            $("#txtItemName").blur(function () {
                var v = $(this).val();
                var msg = "";
                if ($.IsNullOrEmpty(v)) {
                    msg = "<span class='error'>请输入项目名称</span>";
                } else {
                    msg = "<span class='succ'>" + Tips.succ + "</span>";
                }
                $("#TipsItemName").html(msg);
            });
            //检测联系人
            $("#txtLinkman").blur(function () {
                var v = $(this).val();
                var msg = "";
                if ($.IsNullOrEmpty(v)) {
                    msg = "<span class='error'>请输入联系人名称</span>";
                } else {
                    msg = "<span class='succ'>" + Tips.succ + "</span>";
                }
                $("#TipsLinkman").html(msg);
            });
            //检测联系人职务
            $("#txtPosition").blur(function () {
                var v = $(this).val();
                var msg = "";
                if ($.IsNullOrEmpty(v)) {
                    msg = "<span class='error'>请输入联系人职位</span>";
                } else {
                    msg = "<span class='succ'>" + Tips.succ + "</span>";
                }
                $("#TipsPosition").html(msg);
            });
            //检测
            $("#txtAddress").blur(function () {
                var v = $(this).val();
                var msg = "";
                if ($.IsNullOrEmpty(v)) {
                    msg = "<span class='error'>请输入地址</span>";
                } else {
                    msg = "<span class='succ'>" + Tips.succ + "</span>";
                }
                $("#TipsAddress").html(msg);
            });

            //检测手机
            $("#txtMobile").blur(function () {
                var v = $(this).val();
                var msg = "";
                if ($.IsNullOrEmpty(v)) {
                    msg = "<span class='error'>请输入手机号码</span>";
                } else if (!$.IsMobile(v)) {
                    msg = "<span class='error'>请输入正确的手机号码</span>";
                }
                else {
                    msg = "<span class='succ'>" + Tips.succ + "</span>";
                }
                $("#TipsMobile").html(msg);
            });
            //检测邮箱
            $("#txtEmail").blur(function () {
                var v = $(this).val();
                var msg = "";
                if ($.IsNullOrEmpty(v)) {
                    msg = "<span class='error'>请输入邮箱</span>";
                } else if (!$.IsEmail(v)) {
                    msg = "<span class='error'>请输入正确的邮箱</span>";
                } else {
                    msg = "<span class='succ'>" + Tips.succ + "</span>";
                }
                $("#TipsEmail").html(msg);
            });
            //检测电话
            $("#txtTel").blur(function () {
                var v = $(this).val();
                var msg = "";
                if ($.IsNullOrEmpty(v)) {
                    msg = "<span class='error'>请输入电话号码</span>";
                } else if (!$.IsTel(v)) {
                    msg = "<span class='error'>请输入正确的电话号码</span>";
                } else {
                    msg = "<span class='succ'>" + Tips.succ + "</span>";
                }
                $("#TipsTel").html(msg);
            });
            //检测传真
            $("#txtFax").blur(function () {
                var v = $(this).val();
                var msg = "";
                if ($.IsNullOrEmpty(v)) {
                    msg = "<span class='error'>请输入传真</span>";
                } else if (!$.IsTel(v)) {
                    msg = "<span class='error'>请输入正确的传真</span>";
                } else {
                    msg = "<span class='succ'>" + Tips.succ + "</span>";
                }
                $("#TipsFax").html(msg);
            });

            ///----------提交修改----------------
            $("#btnSubmit").click(function () {
                $(":text").triggerHandler("blur");
                if ($(".error").length > 0) {
                    alert("请检查红色部分");
                    return false;
                }
                /*
                if ($.IsNullOrEmpty($("#txtItemName").val())) { alert("请输入项目名称"); $("#txtItemName").focus(); return false; }
                if ($.IsNullOrEmpty($("#txtLinkman").val())) { alert("请输入联系人"); $("#txtLinkman").focus(); return false; }
                if ($.IsNullOrEmpty($("#txtPosition").val())) { alert("请输入联系人职务"); $("#txtPosition").focus(); return false; }
                if ($.IsNullOrEmpty($("#txtTel").val())) { alert("请输入电话号码"); $("#txtTel").focus(); return false; }
                if (!$.IsTel($("#txtTel").val())) { alert("请输入正确的电话号码"); $("#txtTel").focus(); return false; }
                if (!$.IsEmail($("#txtEmail").val())) { alert("请输入正确的邮箱"); $("#txtEmail").focus(); return false; }
                if (!$.IsNullOrEmpty($("#txtMobile").val()) && !$.IsMobile($("#txtMobile").val())) { alert("请输入正确的手机号码"); $("#txtMobile").focus(); return false; }
                */
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="nav">
        <h3>企业信息</h3>
    </div>
    <div class="divlist">
        <table class="tabtxtlist">
            <tr>
                <td class="name" style="width:100px;">
                    企业号：
                </td>
                <td colspan="2">                    
                    <asp:Literal ID ="ltEPCode" runat="server"></asp:Literal>
                </td>     
                <td>&nbsp;</td>           
            </tr>
            <tr>
                <td class="name">
                    企业名称：
                </td>
                <td colspan="2">
                    <asp:Literal ID ="ltEPName" runat="server"></asp:Literal>                    
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="name">
                    项目名称：
                </td>
                <td colspan="2">
                    <asp:TextBox runat="server" CssClass="txt1" ID="txtItemName" Width="400" MaxLength="64" />
                </td>
                <td id="TipsItemName">
                    
                </td>
            </tr>
            <tr>
                <td class="name">
                    联系人：
                </td>
                <td style="width:180px;">
                    <asp:TextBox runat="server" CssClass="txt1" ID="txtLinkman" MaxLength="32" />
                </td>
                <td id="TipsLinkman"></td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                 <td class="name">
                    联系人职务：
                </td>
                <td>
                    <asp:TextBox runat="server" CssClass="txt1" ID="txtPosition" MaxLength="32" />
                </td>
                <td id ="TipsPosition"></td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="name">
                    电话：
                </td>
                <td>
                    <asp:TextBox runat="server" CssClass="txt1" ID="txtTel" MaxLength="32" />
                </td>
                <td id ="TipsTel"></td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="name">
                    手机：
                </td>
                <td>
                    <asp:TextBox runat="server" CssClass="txt1" ID="txtMobile" MaxLength="32" />
                </td>
                <td id ="TipsMobile"></td>
                <td >&nbsp;</td>
            </tr>
            <tr>                
                <td class="name">
                    邮箱：
                </td>
                <td>
                    <asp:TextBox runat="server" CssClass="txt1" ID="txtEmail" MaxLength="64" />
                </td>
                <td id ="TipsEmail"></td>
                <td >&nbsp;</td>
            </tr>
            <tr>
                <td class="name">
                    传真：
                </td>
                <td>
                    <asp:TextBox runat="server" CssClass="txt1" ID="txtFax" MaxLength="32" />
                </td>
                <td id ="TipsFax"></td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="name">
                    地址：
                </td>
                <td colspan="2">
                    <asp:TextBox runat="server" ID="txtAddress" CssClass="txt1" MaxLength="64" Width="400" />
                </td>
                <td id ="TipsAddress"></td>
            </tr>
            <tr>               
                <td  class="name">
                    有效日期：
                </td>
                <td colspan="3">
                    <asp:TextBox runat="server" CssClass="txt1"  ID="txtStartDate" Enabled="false" TabIndex="4"/>
               
                    至
                
                    <asp:TextBox runat="server" CssClass="txt1"  ID="txtExpireDate" Enabled="false" TabIndex="5"/>
                </td>
            </tr>
            <tr>               
                <td class="name">
                    当前用户数量：
                </td>
                <td colspan="3">
                    <asp:TextBox runat="server" CssClass="txt1"  ID="txtUserNum" Enabled="false" TabIndex="4"/>
                </td>
            </tr>
            <tr>
                <td class="name">
                    系统管理员账号：
                </td>
                <td>
                    <asp:TextBox runat="server" CssClass="txt1"  ID="txtUserName" Enabled="false" TabIndex="8" />
                </td>   
                <td colspan="2">&nbsp;</td>            
            </tr>
            <tr>
                <td class="name">
                    系统管理员密码：
                </td>
                <td>
                    <asp:TextBox runat="server" CssClass="txt1"  ID="txtPassword" TabIndex="9"/>
                </td> 
                <td colspan="2">&nbsp;</td>              
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td colspan="2">
                    <asp:Button runat="server" ID="btnSubmit" class="btn1" Text="修改" OnClick="btnSubmit_Click" />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </div>
    </form>
    <script id="pagetipsjs" src="/JS/PageTips.js?menuid=51" type="text/javascript"></script>
</body>
</html>
