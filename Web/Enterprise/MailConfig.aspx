<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MailConfig.aspx.cs" Inherits="Web.Enterprise.MailConfig" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>企业用户邮件配置</title>
    <link href="../Styles/Site.css" rel="stylesheet" type="text/css" />
    <script src="../JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="../JS/common.js" type="text/javascript"></script>
    <style>
        .name120 b{color:Black;}
    </style>
    <script type="text/javascript">
        //邮箱类型数组
        var array = 
        [{ key: "163",name:"163", suffix: "163.com", smtp: "smtp.163.com", port: 25 },
        { key: "126",name:"126", suffix: "126.com", smtp: "smtp.126.com", port: 25 },
        { key: "sina",name:"sina", suffix: "sina.com", smtp: "smtp.sina.com", port: 25 },
        { key: "gmail",name:"gmail", suffix: "gmail.com", smtp: "smtp.gmail.com", port: 25 },
        { key: "yahoo.cn", name: "yahoo.cn", suffix: "yahoo.cn", smtp: "smtp.mail.yahoo.cn", port: 25 },
        { key: "yahoo.com.cn", name: "yahoo.com.cn", suffix: "yahoo.com.cn", smtp: "smtp.mail.yahoo.com.cn", port: 25 },
        { key: "other", name: "other", suffix: "", smtp: "smtp.", port: 25 }];
        $(function () {
            //选择邮箱类型改变事件
            $(":radio[name='rdType']").click(function () {
                var v = $(this).val();
                $.each(array, function (i) {
                    if (v == array[i].key) {
                        $("#txtEmailSuffix").val(array[i].suffix);
                        $("#txtSMTP").val(array[i].smtp);
                        $("#txtPort").val(array[i].port);
                        //判断是否为yahoo.cn邮箱
                        if (v == "yahoo.cn") {
                            $("#TipsUserName").html("<span class='succ'>cn的别忘加后缀噢！</span>");
                            setTimeout(function () { $("#TipsUserName").html(""); }, 2000);
                        }
                    }
                });
            });

            //基本验证       
            $("#txtEmailSuffix").blur(function () {
                var email = $("#txtEmail").val();
                var suffix = $(this).val();
                var msg = "";
                if ($.IsNullOrEmpty(email)) {
                    msg = "<span class='error'>请输入邮箱名称</span>";
                }
                else {
                    msg = "<span class='error'>请输入邮箱后缀</span>";
                }
                if (!$.IsEmail(email + "@" + suffix)) {
                    msg = "<span class='error'>输入有误</span>";
                }
                else {
                    msg = "<span class='succ'>输入正确</span>";
                }
                $("#TipsEmail").html(msg);
            });
            $("#txtSMTP").blur(function () {
                if ($.IsNullOrEmpty($(this).val())) {
                    $("#TipsSMTP").html("<span class='error'>请输入邮件服务器</span>");
                }
                else {
                    $("#TipsSMTP").html("");
                }
            });
            $("#txtPort").blur(function () {
                if ($.IsNullOrEmpty($(this).val())) {
                    $("#TipsPort").html("<span class='error'>请输入端口号</span>");
                }
                if (!$.IsInt($(this).val())) {
                    $("#TipsPort").html("<span class='error'>请输入整数</span>");
                }
                else {
                    $("#TipsPort").html("<span class='succ'>输入正确</span>");
                }
            });
            $("#txtUserName").blur(function () {
                if ($.IsNullOrEmpty($(this).val())) {
                    $("#TipsUserName").html("<span class='error'>请输入用户名</span>");
                }
                else {
                    $("#TipsUserName").html("");
                }
            });
            $("#txtPassword").blur(function () {
                if ($.IsNullOrEmpty($(this).val())) {
                    $("#TipsPassword").html("<span class='error'>请输入密码</span>");
                }
                else {
                    $("#TipsPassword").html("");
                }
            });
            $("#txtName").blur(function () {
                if ($.IsNullOrEmpty($(this).val())) {
                    $("#TipsName").html("<span class='error'>请输入姓名</span>");
                }
                else {
                    $("#TipsName").html("");
                }
            });

            ///发送人的change事件
            $("#txtEmail").keyup(function () {
                var v = $.trim($(this).val());
                $("#txtUserName").val(v);
            });

            $("#btnSubmit").click(function () {
                $(":text").trigger("blur");
                if ($(".error").length > 0) {
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
            企业用户邮件配置</h3>
    </div>
    <div class="divlist">
        <table class="tabtxtlist">
            <tr>
                <td class="name150">
                    <b>快速配置：</b>
                </td>
                <td colspan="2">
                    <input id="rd163" type="radio" name="rdType" value="163" /><label for="rd163">163</label>
                    <input id="rd126" type="radio" name="rdType" value="126" /><label for="rd126">126</label>
                    <input id="rdsina" type="radio" name="rdType" value="sina" /><label for="rdsina">sina</label>
                    <input id="rdgmail" type="radio" name="rdType" value="gmail" /><label for="rdgmail">gmail</label>
                    <input id="rdyahoo.cn" type="radio" name="rdType" value="yahoo.cn" /><label for="rdyahoo.cn">yahoo.cn</label>
                    <input id="rdyahoo.com.cn" type="radio" name="rdType" value="yahoo.com.cn" /><label for="rdyahoo.com.cn">yahoo.com.cn</label>
                    <input id="rdother" type="radio" name="rdType" value="other" /><label for="rdother">其它</label>
                </td>
            </tr>
            <tr>
                <td class="name150">
                    <b>发送人邮箱：</b><br />
                    例:***@163.com                    
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtEmail" CssClass="txt" AutoComplete="off" Width="136" />
                    <span>@</span>
                    <asp:TextBox runat="server" ID ="txtEmailSuffix" CssClass="txt" Width="110"></asp:TextBox>
                </td>
                <td id="TipsEmail">
                    
                </td>
            </tr>
            <tr>
                <td class="name150">
                    <b>发送邮件服务器：</b><br />发送邮件的SMTP服务器
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtSMTP" CssClass="txt" Width="280"/>
                </td>
                <td id="TipsSMTP">
                    
                </td>
            </tr>
            <tr>
                <td class="name150" >
                    <b>端口号：</b><br />非负整数，默认是25
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtPort" CssClass="txt" Width="280"/>
                </td>
                <td id="TipsPort">
                    
                </td>
            </tr>
            <tr>
                <td class="name150">
                    <b>用户名：</b>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtUserName" CssClass="txt" Width="280"/>
                </td>
                <td id="TipsUserName" style="width:130px;">
                </td>
            </tr>
            <tr>
                <td class="name150">
                    <b>邮箱密码：</b>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtPassword" CssClass="txt" Width="280"/>
                </td>
                <td id="TipsPassword">
                    
                </td>
            </tr>
            <tr>
                <td class="name150">
                    <b>昵称：</b>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtName" CssClass="txt" Width="280"/>
                </td>
                <td id="TipsName">
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    <asp:Button runat="server" ID="btnSubmit" Text="保存" OnClick="btnSubmit_Click" CssClass="btn" />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <input type="button" id="btnReturn" value="返回" class="btn" onclick="window.location.replace('<%=Request["backurl"] %>');" />
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
