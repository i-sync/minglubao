<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemMember.aspx.cs" Inherits="Web.Enterprise.Item.ItemMember" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>项目成员列表</title>
    <link href="/Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="/Styles/msgbox.css" rel="stylesheet" type="text/css" />
    <script src="/JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="/JS/common.js" type="text/javascript"></script>
    <script type="text/javascript" >
        $(function () {
            $(".del").click(function () {
                if (confirm("您确定要删除些人员吗？")) {
                    var uid = $(this).parents("tr").attr("uid");
                    $.ajax({
                        type: "POST",
                        url: "/enterprise/handler/item.ashx",
                        data: { key: "deletemember", uid: uid },
                        success: function (data) {
                            if (data == "1") {
                                reload();
                            }
                            else {
                                alert("删除失败");
                            }
                        },
                        dataType: "text"
                    });
                }
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="nav">
            <h3>项目成员列表</h3>
        </div>
        <div class="divlist">
            <table cellpadding="1" cellspacing="1" border="0" class="tablist top10" style="width:600px;">
                <tr>
                    <th style="width:50px;">
                        序号
                    </th>
                    <th>
                        姓名
                    </th>
                    <th style="width:140px;">
                        加入时间
                    </th>
                    <th>
                        操作
                    </th>
                </tr>
                <asp:Repeater runat="server" ID="rpList">
                    <ItemTemplate>
                        <tr class="c" uid="<%#Eval("UserID") %>">
                            <td>
                                <%#Container.ItemIndex+1 %>
                            </td>
                            <td>
                                <a href="personalinfo.aspx?uid=<%#Eval("UserID") %>&pid=<%#Eval("PersonalID") %>" title="<%#Eval("RealName") %>">
                                    <%#Eval("RealName") %>
                                </a>
                            </td>
                            <td>
                                <%#Eval("AddDate","{0:yyyy-MM-dd}")%>
                            </td>
                            <td>
                                <a href="javascript:void();" class="del">删除</a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
