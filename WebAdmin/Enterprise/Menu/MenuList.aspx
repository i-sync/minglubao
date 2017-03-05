<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuList.aspx.cs" Inherits="WebAdmin.Enterprise.Menu.MenuList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>菜单列表</title>
    <script src="../../js/jquery-1.6.4.js" type="text/javascript"></script>
    <link href="../../images/main.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <table class="tableBorder" width="98%"  border="0" align="center">
            <tr>
                <th class="bigTitle">
                    菜单提示管理
                </th>
            </tr>
            <tr>
                <td>
                    <table class="tablist" cellspacing="1" cellpadding="1">
                        <tr align="center" style="color: White; background-color: #DADAE9; font-weight: bold;">
                            <th style="width:50px;">序号</th>
                            <th>菜单名称</th>
                            <th>操作</th>
                        </tr>
                        <asp:Repeater ID ="rpList" runat="server">
                            <ItemTemplate>
                                <tr menuid ="<%#Eval("MenuID") %>" class="c">
                                    <td>
                                        <%#Container.ItemIndex+1 %>
                                    </td>
                                    <td>
                                        <%#Eval("MenuName") %>
                                    </td>
                                    <td>
                                        <a href="MenuTips.aspx?menuid=<%#Eval("MenuID") %>&menuname=<%#Eval("MenuName") %>">修改提示信息</a>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </td>
            </tr>
        </table>        
    </form>
</body>
</html>
