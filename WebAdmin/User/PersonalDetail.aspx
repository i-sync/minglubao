<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PersonalDetail.aspx.cs"
    Inherits="WebAdmin.User.PersonalDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>������Ϣ</title>
    <script type="text/javascript" src="../js/jquery-1.6.4.js"></script>
    <script type="text/javascript" src="../js/common.js"></script>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <link href="../images/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <table class="tableBorder" width="98%" align="center"
        border="0">
        <tr>
            <th class="bigTitle" colspan="4">
                <b>�����û���Ϣ </b>
            </th>
        </tr>
        <tr>
            <td class="title" style="width:100px">
                ������
            </td>
            <td colspan="3">
                <asp:TextBox runat="server" ID="txtRealName" TabIndex="1" />
            </td>
        </tr>
        <tr>
            <td class="title">
                �绰��
            </td>
            <td style=" width:220px;">
                <asp:TextBox runat="server" ID="txtTel" TabIndex="2" />
            </td>
            <td class="title" style="width:100px;">
                E-Mail��
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtEmail" TabIndex="3" />
            </td>
        </tr>
        <tr>
            <td class="title">
                �ֻ���
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtMobile" TabIndex="4" />
            </td>
            <td class="title">
                ���棺
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtFax" TabIndex="5" />
            </td>
        </tr>
        <tr>
            <td class="title">
                ��ַ��
            </td>
            <td colspan="3">
                <asp:TextBox runat="server" ID="txtAddress" TabIndex="6" />
            </td>
        </tr>
        <tr>
            <td class="title">
                ��¼������
            </td>
            <td colspan="3">
                <asp:TextBox runat="server" ID="txtClientNum" TabIndex="7" />
            </td>
        </tr>
        <tr>
            <td class="title">
                �˺ţ�
            </td>
            <td colspan="3">
                <asp:TextBox runat="server" ID="txtUserName" TabIndex="8" />
            </td>
        </tr>
        <tr>
            <td class="title">
                ���룺
            </td>
            <td colspan="3">
                <asp:TextBox runat="server" ID="txtPassword" TabIndex="9" />
            </td>
        </tr>
        <tr><td>&nbsp;</td><td colspan="3"><a href="PersonalList.aspx">����</a></td></tr>
    </table>
    </form>
</body>
</html>
