<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FeedbackDetail.aspx.cs"
    Inherits="WebAdmin.FeedbackDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>������Ϣ����</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <link href="images/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <table class="tableBorder" width="98%" align="center" border="0">
        <tr>
            <th class="bigTitle" colspan="2">
                <b>������Ϣ���� </b>
            </th>
        </tr>
        <tr>
            <td class="title" style=" width:60px;">
                ���⣺
            </td>
            <td>
                <asp:Label ID="lblSubject" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="title">
                ���ڣ�
            </td>
            <td>
                <asp:Label ID="lblAddDate" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="title">
                ������
            </td>
            <td>
                <asp:Label ID="lblDetail" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="title">
                ������
            </td>
            <td>
                <asp:Image ID="imgFile" ImageUrl="" runat="server" />
                <asp:HyperLink ID="hlFile" NavigateUrl="" runat="server"></asp:HyperLink>
            </td>
        </tr>
        <tr>
        <td>&nbsp;</td>
            <td>
                <input type="button" value="����" id="btnCancel" onclick="window.location.replace('FeedbackList.aspx');" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
