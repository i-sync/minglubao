<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PersonalList.aspx.cs" Inherits="WebAdmin.User.PersonalList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>个人用户列表</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <link href="../images/main.css" rel="stylesheet" type="text/css" />
    <link href="../My97DatePicker/skin/WdatePicker.css" type="text/css" rel="Stylesheet" />
    <script src="../JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="../JS/common.js" type="text/javascript"></script>
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            //启用、禁用
            $(".status").click(function () {
                var aryStatus = new Array();
                aryStatus[0] = "启用";
                aryStatus[1] = "禁用";
                var status = $(this).attr("status");
                status = Math.abs(status - 1);
                var trObj = $(this).parents("tr");
                var _Obj = $(this);
                var uid = $(trObj).attr("uid");
                var pid = $(trObj).attr("pid");
                $.ajax({
                    type: "POST",
                    url: "../Handler/User.ashx",
                    data: { type: "status", uid: uid, pid: pid, status: status },
                    success: function (data) {
                        if (data == "1") {
                            $(_Obj).attr("status", status);
                            $(_Obj).text(aryStatus[status]);
                            alert("操作成功");
                        } else {
                            alert("操作失败");
                        }
                    },
                    dataType: "text"
                });
            });

            //删除个人用户
            $(".del").click(function () {
                if (!confirm("确认要删除吗？"))
                    return false;
                var trObj = $(this).parents("tr");
                var uid = $(trObj).attr("uid");
                var pid = $(trObj).attr("pid");
                $.ajax({
                    type: "POST",
                    url: "../Handler/User.ashx",
                    data: { type: "delete", uid: uid, pid: pid },
                    success: function (data) {
                        if (data == "-1") {
                            alert("该用户已加入企业，无法删除！");
                        }
                        else if (data == "1") {
                            alert("删除成功");
                            window.location = window.location;
                        }
                        else {
                            alert("删除失败" + data);
                        }
                    },
                    dataType: "text"
                });
                return false;
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <table class="tableBorder"  width="98%" align="center" border="0">
            <tr>
                <th class="bigTitle">
                    个人用户列表
                </th>
            </tr>
            <tr>
                <td>
                    <table>
                        <tr>
                            <td>
                                账号：
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtUserName" />
                            </td>
                            <td>
                                姓名：
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtRealName" />
                            </td>
                            <td>
                                开通日期：
                            </td>
                            <td>
                                <input type="text" class="Wdate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'});" id="txtStartDate"
                                    runat="server" />
                                <span>---</span>
                                <input type="text" class="Wdate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'});" id="txtEndDate"
                                    runat="server" />
                            </td>
                            <td>
                                <asp:Button runat="server" ID="btnSearch" Text="检索" OnClick="btnSearch_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table class="tablist" cellspacing="1" border="0" cellpadding="1">
                        <tr>
                            <th>
                                序号
                            </th>
                            <th>
                                姓名
                            </th>
                            <th>
                                账号
                            </th>
                            <th>
                                手机
                            </th>
                            <th>
                                邮箱
                            </th>
                            <th>
                                开通日期
                            </th>
                            <th>
                                到期日期
                            </th>
                            <th>
                                当前名录数
                            </th>
                            <th>
                                操作
                            </th>
                        </tr>
                        <asp:Repeater runat="server" ID="rpList">
                            <ItemTemplate>
                                <tr class="c" uid="<%#Eval("UserID") %>" pid="<%#Eval("PersonalID") %>">
                                    <td>
                                        <%#Eval("nid") %>
                                    </td>
                                    <td>
                                        <a href="PersonalDetail.aspx?uid=<%#Eval("UserID") %>&pid=<%#Eval("PersonalID") %>">
                                            <%#Eval("RealName") %></a>
                                    </td>
                                    <td>
                                        <%#Eval("UserName") %>
                                    </td>
                                    <td>
                                        <%#Eval("Mobile") %>
                                    </td>
                                    <td>
                                        <%#Eval("Email") %>
                                    </td>
                                    <td>
                                        <%#Eval("AddDate", "{0:yyyy-MM-dd HH:mm}")%>
                                    </td>
                                    <td>
                                        <%#Eval("ExpiredDate", "{0:yyyy-MM-dd HH:mm}")%>
                                    </td>
                                    <td>
                                        <%#Eval("ClientNum") %>
                                    </td>
                                    <td>
                                        <a href="#" class="status" status="<%#Eval("Status")%>"><%#Eval("Status").ToString().Equals("0")?"启用":"禁用"%></a> 
                                        <a href="javascript:void(0);" class="del">删除</a>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                    <mlb:AspNetPager runat="server" ID="pageList1" CssClass="paginator" CurrentPageButtonClass="cpb"
                        PageIndexBoxClass="textbox_page1" SubmitButtonClass="btn_go" SubmitButtonText=""
                        TextBeforePageIndexBox="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;第&nbsp;"
                        AlwaysShow="true" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageSize="1"
                        PrevPageText="上一页" ShowCustomInfoSection="Left" ShowInputBox="Never" CustomInfoTextAlign="Center"
                        LayoutType="Table" ShowPageIndex="false" ShowBoxThreshold="1" UrlPaging="true" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
