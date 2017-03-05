<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Exchange.aspx.cs" Inherits="Web.Enterprise.Info.Exchange" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>沟通记录</title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="list">
        <table cellpadding="1" cellspacing="1" class="tablist" style="width: 97%; margin: 10px 0 40px 10px;
                font-size: 12px; line-height: 180%;" id="tbExchangeList">
                <tr>
                    <th style="width: 40px;">
                        序号
                    </th>
                    <th>
                        沟通内容
                    </th>
                    <th style="width: 120px;">
                        通话时间
                    </th>
                    <th style="width: 100px;">
                        联系人
                    </th>
                </tr>
                <asp:Repeater runat="server" ID="rpExchangeList">
                    <ItemTemplate>
                        <tr class="c">
                            <td>
                                <%#Container.ItemIndex+1 %>
                            </td>
                            <td>
                                <%#Eval("Detail") %>
                            </td>
                            <td>
                                <%#Eval("ExchangeDate", "{0:yyyy-MM-dd HH:mm}")%>
                            </td>
                            <td>
                                <%#Eval("UserInfo") %>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
    </div>
    </form>
</body>
</html>
