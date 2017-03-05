<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminList.aspx.cs" Inherits="WebAdmin.AdminList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="images/main.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="js/common.js" type="text/javascript"></script>
    <script type="text/javascript">
        var CONFIG = {
            POST_URL:"/handler/user.ashx"
        }
        $(function () {
            $("#btnAdd").click(function () {
                window.location.replace("adminedit.aspx?id=0&type=add");
            });

            //点击删除
            $(".del").click(function () {
                if (!confirm("确认要删除吗？")) {
                    return false;
                }
                var id = $(this).parents("tr").attr("id");
                //异步请求删除
                $.ajax({
                    type: "POST",
                    url: CONFIG.POST_URL,
                    data: { type: "admindelete", id: id },
                    success: function (data) {
                        if (data == "1") {
                            alert("删除成功！");
                            window.location = window.location;
                        }
                        else {
                            alert("删除失败！");
                        }
                    },
                    dataType: "text"
                });
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table class="tableBorder"  width="98%" align="center" border="0">
            <tr>
                <th class="bigTitle">
                    管理员列表
                </th>
            </tr>
            <tr>
                <td>
                    <input id="btnAdd" type="button" value="添加" />
                </td>
            </tr>
            <tr style="text-align:left;">
                <td>
                    <table class="tablist" cellspacing="1" border="0" cellpadding="1">
                        <tr>
                            <th>
                                序号
                            </th>
                            <th>
                                用户名
                            </th>
                            <th>
                                操作
                            </th>
                        </tr>
                        <asp:Repeater runat="server" ID="rpList">
                            <ItemTemplate>
                                <tr class="c" id="<%#Eval("AdminID") %>">
                                    <td>
                                        <%#Container.ItemIndex+1 %>
                                    </td>
                                    <td>
                                        <%#Eval("UserName") %>
                                    </td>
                                    <td>
                                        <a href="adminedit.aspx?id=<%#Eval("AdminID") %>&type=update" class="update">修改</a>
                                        <a href="javascript:void(0);" class="del">删除</a>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </td>
            </tr>
        </table>
        
    </div>
    </form>
</body>
</html>
