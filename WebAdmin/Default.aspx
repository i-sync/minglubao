<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebAdmin.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>�����̨��¼</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <link rel="stylesheet" href="images/main.css" type="text/css" />
    <script src="js/jquery-1.6.4.js" type="text/javascript"></script>
    <style type="text/css">
        .error
        {
            color: Red;
        }
        .btn
        {
            padding:6px 10px;
        }
        .txt{ width:260px;}
        td{ text-align:left;}
    </style>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
    <div align="center">
        <br>
        <table border="0" align="center" cellpadding="5" cellspacing="1" class="tableBorder"
            width="60%">
            <tr>
                <th colspan="2" class="bigTitle">
                    ����Ա��¼
                </th>
            </tr>
            <tr>
                <td class="forumRowHighlight" style=" text-align:right;">
                    �û�����
                </td>
                <td class="forumRow">
                    <asp:TextBox ID="UserName" runat="server" CssClass="tableBorder txt" Height="20" />
                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                        CssClass="error" ErrorMessage="������д���û�������" ToolTip="������д���û�������" ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="forumRowHighlight" style=" text-align:right;">
                    �� �룺
                </td>
                <td class="forumRow">
                    <asp:TextBox ID="Password" runat="server" CssClass="tableBorder txt" TextMode="Password"
                        Height="20"/>
                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                        CssClass="error" ErrorMessage="������д�����롱��" ToolTip="������д�����롱��" ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="forumRow">
                    &nbsp;
                </td>
                <td class="forumRow">
                    &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="LoginButton" runat="server" CommandName="Login"
                        Text=" �� ¼ " ValidationGroup="LoginUserValidationGroup" OnClick="LoginButton_Click"
                        CssClass="btn" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <input type="reset" id="btnReset" value=" �� �� " class="btn" />
                </td>
            </tr>
        </table>
        <div>
        </div>
    </div>
    </form>
</body>
</html>
