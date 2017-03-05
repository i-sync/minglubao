<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Apply.aspx.cs" Inherits="Web.Apply" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>企业申请</title>
    <link href="Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="Styles/web.css" rel="stylesheet" type="text/css" />
    <script src="JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="JS/common.js" type="text/javascript"></script>
    <script type="text/javascript">
        function ShowInfo(sender,msg,flag)
        {            
            if(flag==null)
            {
                sender.html(msg);
            }
            else if(flag)
            {
                sender.html("<span class='succ'>"+msg+"</span>");
            }
            else
            {
                sender.html("<span class='error'>"+msg+"</span>");
            }
        }
        $(function () {
            //----------------------------基本信息区--------------------------------
            //检测是否输入企业名
            $("#txtEnterpriseName").blur(function () {
                var v = $.trim($(this).val());
                if (v == "") {
                    ShowInfo($("#TipsEPName"), "请输入企业名称", false);
                } else {
                    ShowInfo($("#TipsEPName"), "", null);
                }
            });

            //检测是否输入详细地址
            $("#txtAddress").blur(function () {
                var v = $.trim($(this).val());
                if ($.IsNullOrEmpty(v)) {
                    ShowInfo($("#TipsAddress"), "请输入详细地址", false);
                } else {
                    ShowInfo($("#TipsAddress"), "", null);
                }
            });
            //检测是否输入联系人称呼
            $("#txtLinkman").blur(function () {
                var v = $.trim($(this).val());
                if ($.IsNullOrEmpty(v)) {
                    ShowInfo($("#TipsLinkMan"), "请输入联系人称呼", false);
                } else {
                    ShowInfo($("#TipsLinkMan"), "", null);
                }
            });
            //检测是否输入联系人职位
            $("#txtPosition").blur(function () {
                var v = $.trim($(this).val());
                if ($.IsNullOrEmpty(v)) {
                    ShowInfo($("#TipsPosition"), "请输入联系人职位", false);
                } else {
                    ShowInfo($("#TipsPosition"), "", null);
                }
            });

            //检测手机
            $("#txtMobile").blur(function () {
                var v = $.trim($(this).val());
                if ($.IsNullOrEmpty(v)) {
                    ShowInfo($("#TipsMobile"), "请输入手机号", false);
                } else if (!$.IsMobile(v)) {
                    ShowInfo($("#TipsMobile"), "请输入正确的手机号", false);
                } else {
                    ShowInfo($("#TipsMobile"), "格式:158xxxxxxxx", null);
                }
            });
            //检测邮箱
            $("#txtEmail").blur(function () {
                var v = $.trim($(this).val());
                if ($.IsNullOrEmpty(v)) {
                    ShowInfo($("#TipsEmail"), "请输入邮箱", false);
                } else if (!$.IsEmail(v)) {
                    ShowInfo($("#TipsEmail"), "请输入正确的邮箱", false);
                }
                else {
                    ShowInfo($("#TipsEmail"), "", null);
                }
            });
            //检测电话
            $("#txtTel").blur(function () {
                var v = $.trim($(this).val());
                if ($.IsNullOrEmpty(v)) {
                    ShowInfo($("#TipsTel"), "请输入电话号码", false);
                } else if (!$.IsTel(v)) {
                    ShowInfo($("#TipsTel"), "请输入正确电话号码", false);
                }
                else {
                    ShowInfo($("#TipsTel"), "格式:010-88888888", null);
                }
            });
            //检测传真
            $("#txtFax").blur(function () {
                var v = $.trim($(this).val());
                if ($.IsNullOrEmpty(v)) {
                    ShowInfo($("#TipsFax"), "请输入传真", false);
                } else {
                    ShowInfo($("#TipsFax"), "", null);
                }
            });
            //检测用户数量是否正确
            $("#txtUserAmount").blur(function () {
                var v = $.trim($(this).val());
                if ($.IsNullOrEmpty(v)) {
                    ShowInfo($("#TipsUserAmount"), "请输入用户数量", false);
                } else if (!$.IsInt(v)) {
                    ShowInfo($("#TipsUserAmount"), "请输入正确的数量", false);
                } else {
                    ShowInfo($("#TipsUserAmount"), "", null);
                }
            });
            $("form").submit(function () {
               
                $(":text").trigger("blur");
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
    <div class="wrap">
        <mlb:header runat="server" id="header" />
        <div class="webkuang">
            <div class="app">企业申请</div>
            <table border="0" cellspacing="1" cellpadding="1" class="tabweblist">
                <tr>
                    <td class="name" style=" width:100px;">
                        企业名称：
                    </td>
                    <td colspan="3">
                        <asp:TextBox runat="server" ID="txtEnterpriseName" CssClass="txt  w420" />
                    </td>
                    <td id = "TipsEPName" colspan="2">
                    </td>
                </tr>
                <tr>
                    <td class="name">
                        详细地址：
                    </td>
                    <td colspan="3">
                        <asp:TextBox runat="server" ID="txtAddress" CssClass="txt w420" />
                    </td>
                    <td id = "TipsAddress" colspan="2">
                    </td>
                </tr>
                <tr>
                    <td class="name">
                        联系人称呼：
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtLinkman" CssClass="txt" />
                    </td>
                    <td id ="TipsLinkMan" style="width:130px;">
                        
                    </td>
                    <td class="name" style=" width:100px;">
                        联系人职务：
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtPosition" CssClass="txt" />
                    </td>
                    <td id = "TipsPosition">
                    </td>
                </tr>
                <tr>
                    <td class="name">
                        联系人电话：
                    </td>
                    <td valign="middle">
                        <asp:TextBox runat="server" ID="txtTel" CssClass="txt" />
                    </td>
                    <td id="TipsTel">
                        <span>格式:010-88888888</span>
                    </td>
                    <td class="name">
                        电子邮箱：
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtEmail" CssClass="txt" />
                    </td>
                    <td id = "TipsEmail">
                    </td>
                </tr>
                <tr>
                    <td class="name">
                        联系人手机：
                    </td>
                    <td >
                        <asp:TextBox runat="server" ID="txtMobile" CssClass="txt" />
                    </td>
                    <td id ="TipsMobile">
                        <span>格式:158xxxxxxxx</span>
                    </td>
                    <td class="name">
                        传真：
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtFax" CssClass="txt" />
                    </td>
                    <td id = "TipsFax">
                    </td>
                </tr>
                <tr>
                    <td class="name">
                        用户数量：
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtUserAmount" Text="10" CssClass="txt" />
                    </td>
                    <td colspan ="4" id="TipsUserAmount">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td colspan="5">
                        <asp:Button runat="server" ID="btnSubmit" Text="申请" OnClick="btnSubmit_Click" CssClass="btn" />
                    </td>
                </tr>
            </table>
            <div class="webkuangfoot"></div>
        </div>
    </div>
    <mlb:bottom runat="server" id="bottom" />
    </form>
</body>
</html>
