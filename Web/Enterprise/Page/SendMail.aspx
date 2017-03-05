<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SendMail.aspx.cs" Inherits="Web.Enterprise.Page.SendMail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>发送邮件</title>
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
            width: 680px;
            overflow: hidden;
        }
        .mailkuang .txtW
        {
        }
        .mailkuang .mail
        {
            float: left;
            width: 520px;
        }
        .mailkuang .mail .txtW
        {
            width: 440px;
        }
        .mailkuang .mail .txtW2
        {
            width: 448px;
        }
        .mailkuang .mailAll
        {
            width: 670px;
        }
        .mailkuang .mailAll .txtW
        {
            width: 580px;
        }
        .mailkuang .mailAll .txtW2
        {
            width: 588px;
        }
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
        var Tips = {
            succ: '输入正确'
        };
        $(function () {
            //------------------------------附件------------------------------
            //--点击 增加 附件
            $("#divMaterial a[url]").click(function () {
                var name = $(this).text();
                var mid = $(this).attr("mid");
                var url = $(this).attr("url");
                if ($("#tdAttachment").find("a[mid='" + mid + "']").length == 0) {
                    var obj = "<p><a mid='" + mid + "' url='" + url + "'>" + name + "</a>&nbsp;&nbsp;<a href='javascript:void(0)' mid='" + mid + "' class='del'>删除</a></p>";
                    $("#tdAttachment").append(obj);
                }
            });
            //--删除已经选中的附件
            $("#tdAttachment .del").live("click", function () {
                $(this).parent().remove();
            });

            //------------------验证-----------------
            $("#txtReceiveEmail").blur(function () {  //验证邮箱
//                var v = $(this).val();
//                var msg = "";
//                if ($.IsNullOrEmpty(v)) {
//                    msg = "<span class='error'>请填写收件人邮箱</span>";
//                }
//                else if (!$.IsEmail(v)) {
//                    msg = "<span class='error'>请填写正确的邮箱</span>";
//                }
//                else {
//                    msg = "<span class='succ'>"+Tips.succ+"</span>";
//                }
//                $("#TipsEmail").html(msg);
            });
            $("#txtSubject").blur(function () {  //验证主题
                var v = $(this).val();
                var msg = "";
                if ($.IsNullOrEmpty(v)) {
                    msg = "<span class='error'>请填写主题</span>";
                }
                else {
                    msg = "<span class='succ'>" + Tips.succ + "</span>";
                }
                $("#TipsSubject").html(msg);
            });

            //------------------------------提交------------------------------
            $("form").submit(function () {
                $(":text").trigger("blur");
                if ($(".error").length > 0) {
                    return false;
                }
                var aryURL = Array();
                //获取附件信息
                $("#tdAttachment a[url]").each(function () {
                    aryURL.push($(this).attr("url"));
                });
                $("#hdAttachment").val(aryURL);
            });
            $("#btnCancel").click(function () {
                parent.EmailClose();
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:Panel runat="server" ID="plSend" CssClass="mailkuang">
        <div class="mail">
            <table style="margin: 10px 0 0 10px;">
                <tr>
                    <td class="infoname">
                        发件人：
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lbSendUser" />
                        <a href="/enterprise/mailconfig.aspx?backurl=Page/SendMail.aspx">修改发送人</a>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="infoname h38" style="width:100px;">
                        收件人：
                    </td>
                    <td style="width:300px;">
                        <asp:TextBox runat="server" ID="txtReceiveEmail" CssClass="txt1 w300" />
                    </td>
                    <td id ="TipsEmail" style="width:150px;">
                    </td>
                </tr>
                <tr>
                    <td class="infoname h38">
                        主题：
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtSubject" CssClass="txt1 w300" />
                    </td>
                    <td id="TipsSubject">
                    </td>
                </tr>
                <tr>
                    <td class="infoname" valign="top">
                        附件：
                    </td>
                    <td colspan="2" id="tdAttachment">
                    </td>
                </tr>
                <tr>
                    <td class="infoname" valign="top">
                        内容：
                    </td>
                    <td colspan="2">
                        <asp:TextBox runat="server" ID="txtContent" TextMode="MultiLine" Rows="8" Columns="40"
                            CssClass="txtW2" />
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td class="h38">
                        <asp:Button runat="server" ID="btnSend" Text="发送" OnClick="btnSend_Click" CssClass="btn1" />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <input type="button" id="btnCancel" value="取消" class="btn1" />
                        <asp:HiddenField runat="server" ID="hdAttachment" />
                    </td>                    
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
        <div id="divMaterial" class="fj">
            <div style="text-align: center; font-size: 14px; line-height: 28px; background: #e3e9ed;">
                <b>项目资料库</b></div>
            <ul>
                <asp:Repeater runat="server" ID="rpList">
                    <ItemTemplate>
                        <li><a href="javascript:void(0)" mid="<%#Eval("MaterialID") %>" url="<%#Eval("Url") %>">
                            <%#Eval("MaterialName") %></a> <a href="<%#MLMGC.COMP.Config.GetEnterpriseMaterialUrl(EnterpriceID,Eval("Url").ToString()) %>"
                                target="_blank">查看</a> </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
        <div class="clear">
        </div>
        <div style=" margin:4px auto 2px 15px;">
            <asp:Label runat="server" ID="lbErrClient" ForeColor="Red" />
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="plConfig" style="padding:20px 20px;">
        <a href="/enterprise/mailconfig.aspx?backurl=Page/SendMail.aspx">请先配置代发邮件帐号信息</a>
    </asp:Panel>
    </form>
</body>
</html>
