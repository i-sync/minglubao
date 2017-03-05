<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SendSMS.aspx.cs" Inherits="Web.Enterprise.Page.SendSMS" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>发送短信</title>
    <link href="../../Styles/Site.css" rel="stylesheet" type="text/css" />
    <script src="../../JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="../../JS/common.js" type="text/javascript"></script>
    <style type="text/css">
        .sendsms{width: 490px;margin: 5px 5px 0 5px;}
    </style>
    <script type="text/javascript">
        $(function () {

            $("#btnCancel").click(function () {
                parent.SMSClose();
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="sendsms">
        <table class="tabtxtlist">
            <tr>
                <td>
                    手机号码：
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtMobileNumber" CssClass="txt1 w300" />
                </td>
            </tr>
            <tr>
                <td valign="top">
                    短信内容：
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtSMSContent" TextMode="MultiLine" Rows="4" Columns="40" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    <asp:Button runat="server" ID="btnSubmit" Text="发送" CssClass="btn1" />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <input type="button" id="btnCancel" value="取消" class="btn1" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
