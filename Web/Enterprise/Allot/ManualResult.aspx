<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManualResult.aspx.cs" Inherits="Web.Enterprise.Allot.ManualResult" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>已选择名录</title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="nav">
        <h3>已选择名录</h3>
    </div>
    <div class="divlist" id ="list">
        <table class="tablist" cellpadding="1" cellspacing="1">
            <tr>
                <th>
                    
                </th>
                <th>
                    名录名称
                </th>               
                <th>
                    入库时间
                </th>
            </tr>
            <asp:Repeater runat="server" ID="rpList">
                <ItemTemplate>
                    <tr class="c">
                        <td>
                            <a href="javascript:void(0);" class="showdel" ciid="<%#Eval("ClientInfoID") %>">删除选择</a>
                        </td>
                        <td>
                            <%#Eval("ClientName") %>
                        </td>
                        <td>
                            <%#Eval("AddDate","{0:yyyy-MM-dd HH:mm}") %>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        <span>已选择名录：</span>
        <asp:Label ID="lblCount" runat="server"></asp:Label>
        <span>个。</span>
    </div>
    </form>
</body>
</html>
