<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StatusLog.aspx.cs" Inherits="Web.Enterprise.Info.StatusLog" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>状态日志</title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="loglist">
    <table cellpadding="1" cellspacing="1" class="tablist" style=" margin:10px; width:600px;">
    <tr><th style=" width:50px;">序号</th><th>时间</th><th>操作</th></tr>
    <asp:Repeater runat="server" ID="rpList">
    <ItemTemplate>
    <tr><td class="c"><%#Container.ItemIndex+1 %></td><td class="c"><%#Eval("AddDate","{0:yyyy-MM-dd HH:mm}")%></td><td>
    <%#Eval("Operate")%>
    <%#OperateType(Eval("OperateType"))%>
    <%#Eval("Result")%>
    </td></tr>
    </ItemTemplate>
    </asp:Repeater>
    </table>
    </div>
    </form>
</body>
</html>
