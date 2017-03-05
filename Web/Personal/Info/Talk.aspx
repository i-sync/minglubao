<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Talk.aspx.cs" Inherits="Web.Personal.Info.Talk" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>话术</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Repeater ID="rpList" runat="server">
            <ItemTemplate>
                <b>
                    <%#Container.ItemIndex+1 %>、<%#Eval("TalkSubject") %></b>
                <div style="margin: 0 0 0 24px;">
                    <%#Eval("Detail") %></div>
            </ItemTemplate>
        </asp:Repeater>
        <%if (flag)
          { %>
          <a href="/Personal/Material/TalkEdit.aspx" target="main">赶紧添加吧</a>

        <%} %>
    </div>
    </form>
</body>
</html>
