<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApplyDetail.aspx.cs" Inherits="WebAdmin.Enterprise.Apply.ApplyDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>��ҵ�û���Ϣ</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <script type="text/javascript" src="../../js/jquery-1.6.4.js"></script>
    <script type="text/javascript" src="../../js/common.js"></script>
    <link href="../../images/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <table class="tableBorder" cellspacing="1" cellpadding="3" width="98%" align="center"
        border="0">
        <tr>
            <th class="bigTitle" colspan="4">
                <b>��ҵ�û���Ϣ </b>
            </th>
        </tr>
        <tr>
            <td class="title" style=" width:100px;">
                ��ҵ���ƣ�
            </td>
            <td colspan="3">
                <asp:Label ID="lblName" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="title">
                ��ϵ�ˣ�
            </td>
            <td style=" width:200px;">
                <asp:Label ID="lblLinkman" runat="server"></asp:Label>
            </td>
            <td class="title" style=" width:100px;">
                ְ��
            </td>
            <td>
                <asp:Label ID="lblPosition" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="title">
                �绰��
            </td>
            <td>
                <asp:Label ID="lblTel" runat="server"></asp:Label>
            </td>
            <td class="title">
                E-mail��
            </td>
            <td>
                <asp:Label ID="lblEmail" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="title">
                �ֻ���
            </td>
            <td>
                <asp:Label ID="lblMobile" runat="server"></asp:Label>
            </td>
            <td class="title">
                ���棺
            </td>
            <td>
                <asp:Label ID="lblFax" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="title">
                ��ַ��
            </td>
            <td>
                <asp:Label ID="lblAddress" runat="server"></asp:Label>
            </td>
            <td colspan="2">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="title">
                �����û�������
            </td>
            <td>
                <asp:Label ID="lblUserAmount" runat="server"></asp:Label>
            </td>
            <td colspan="2">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td colspan="3" align="left">
                <input type="button" value="����" onclick="window.location.replace('ApplyList.aspx');" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
