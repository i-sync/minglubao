<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SendMail.aspx.cs" Inherits="Web.Personal.Info.SendMail" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>名录录入</title>
    <script src="../../JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="../../JS/common.js" type="text/javascript"></script>
    <link href="../../Styles/Site.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        ul, p
        {
            padding: 0;
            margin: 0;
        }
        li
        {
            margin: 5px 2px;
        }
        .mailkuang
        {
            width: 550px;
            overflow: hidden;
        }
        .mailkuang .txtW{}
        .mailkuang .mail
        {
            float: left;
            width: 520px;
        }
        .mailkuang .mail .txtW{ width:440px;}
        .mailkuang .mail .txtW2{ width:448px;}
        .mailkuang .mailAll
        {
            width: 670px;
        }
        .mailkuang .mailAll .txtW{ width:580px;}
        .mailkuang .mailAll .txtW2{ width:588px;}
        .mailkuang .fj
        {
            height: 320px;
            border-left: 1px solid #c6d8e0;
            border-bottom: 1px solid #c6d8e0;
            width: 150px;
            overflow: auto;
            margin: 0;
            float: right;
        }
    </style>
    <script type="text/javascript">
        $(function () {
            //调用父亲的方法，关闭弹出层
            $("#btnCancel").click(function () {
                parent.EmailClose();
            });

            //-----------基本验证---------------
            $("#txtReceiveEmail").blur(function () {  //验证邮箱
                var v = $(this).val();
                var msg = "";
                if ($.IsNullOrEmpty(v)) {
                    msg = "<span class='error'>请填写收件人邮箱</span>";
                }
                else if (!$.IsEmail(v)) {
                    msg = "<span class='error'>请填写正确的邮箱</span>";
                }
                else {
                    msg = "";
                }
                $("#TipsEmail").html(msg);
            });
            $("#txtSubject").blur(function () {  //验证主题
                var v = $(this).val();
                var msg = "";
                if ($.IsNullOrEmpty(v)) {
                    msg = "<span class='error'>请填写主题</span>";
                }
                else {
                    msg = "";
                }
                $("#TipsSubject").html(msg);
            });
            $("#txtContent").blur(function () {  //验证内容
                var v = $(this).val();
                var msg = "";
                if ($.IsNullOrEmpty(v)) {
                    msg = "<span class='error'>请填写内容</span>";
                }
                else {
                    msg = "";
                }
                $("#TipsContent").html(msg);
            });

            //---提交--
            $("#btnSend").click(function () {
                $(":text").trigger("blur");
                if ($.IsNullOrEmpty($("#txtContent").val())) {
                    $("#TipsContent").html("<span class='error'>请填写内容</span>");
                }
                if ($(".error").length > 0) {
                    alert("请检查红色部分");
                    return false;
                }
            });
        });
    </script>
</head>
<body>
<form runat="server" id="form1">
    <asp:Panel runat="server" ID="plSend" CssClass="mailkuang">
        <div class="mail">
            <table style="margin: 10px 0 0 30px;">
                <tr>
                    <td class="infoname" style="width:50px;">发件人：</td>
                    <td>
                        <asp:Literal runat="server" ID="ltSendEmail" />
                        <a href="/personal/Config/MailConfig.aspx?backurl=../Info/SendMail.aspx" >修改发送人</a>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="infoname h38">收件人：</td>
                    <td><asp:TextBox runat="server" ID="txtReceiveEmail" CssClass="txt" Width="300" /></td>
                    <td id="TipsEmail">
                        
                    </td>
                </tr>
                <tr>
                    <td class="infoname h38">主题：</td>
                    <td><asp:TextBox runat="server" ID="txtSubject" CssClass="txt" Width="300" /></td>
                    <td id="TipsSubject">
                        
                    </td>
                </tr>
                <tr>
                    <td valign="top" class="infoname h38">内容：</td>
                    <td><asp:TextBox runat="server" ID="txtContent" TextMode="MultiLine" Rows="5" Columns="40" style="max-height:180px;max-width:350px;min-height:180px;min-width:350px;" /></td>
                    <td id="TipsContent">
                        
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td class="h38">
                        <asp:Button runat="server" ID="btnSend" CssClass="btn" Text="发送" onclick="btnSend_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <input id ="btnCancel" type="button" class="btn" value="取消" />
                    </td>                    
                </tr>
            </table>
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="plConfig" style="padding:20px 20px;">
        <a href="/personal/Config/MailConfig.aspx?backurl=../Info/SendMail.aspx" >请先配置代发邮件帐号信息</a>
    </asp:Panel>
</form>
</body>
</html>