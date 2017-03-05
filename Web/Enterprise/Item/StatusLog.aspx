<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StatusLog.aspx.cs" Inherits="Web.Enterprise.Item.StatusLog" %>

<div id="loglist">
    <table cellpadding="1" cellspacing="1" class="tablist" style="margin: 10px; width: 500px;">
        <tr>
            <th>
                序号
            </th>
            <th>
                时间
            </th>
            <th>
                操作
            </th>
        </tr>
        <asp:repeater runat="server" id="rpList">
    <ItemTemplate>
    <tr><td class="c"><%#Container.ItemIndex+1 %></td><td class="c"><%#Eval("AddDate","{0:yyyy-MM-dd HH:mm}")%></td>
    <td>
        <%#Eval("Detail")%>
    </td></tr>
    </ItemTemplate>
    </asp:repeater>
    </table>
</div>
