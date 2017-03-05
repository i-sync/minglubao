<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="Web.Enterprise.User.UserList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>用户管理</title>
    <link href="/Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="../../Styles/msgbox.css" rel="stylesheet" type="text/css" />
    <script src="/JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="../../JS/jquery.cookie.js" type="text/javascript"></script>
    <script src="../../JS/common.js" type="text/javascript"></script>
    <script src="../../JS/poptip.js" type="text/javascript"></script>
    <script type="text/javascript">
        var URL_CONFIG = {
            Post_URL: "../EPHandler.ashx"
        };
        $(function () {
            //启用、禁用
            $(".status").click(function () {
                var aryStatus = new Array();
                aryStatus[1] = "禁用";
                aryStatus[0] = "启用";
                var status = $(this).attr("status");
                status = Math.abs(status - 1);
                var trObj = $(this).parents("tr");
                var _Obj = $(this);
                var uid = $(trObj).attr("uid");
                var data = "key=201&status=" + status + "&uid=" + uid;
                $.get(URL_CONFIG.Post_URL, data, function (res) {
                    if (res == "1") {
                        $(_Obj).attr("status", status);
                        $(_Obj).text(aryStatus[status]);
                        PopTip.Show(PopTip.Type.Succ, "操作成功", false);
                    } else {
                        PopTip.Show(PopTip.Type.Error, "操作失败", false);
                    }
                }, "text");
                return false;
            });
            $(".del").click(function () {
                var result = confirm("确认要删除吗？");
                if (!result)
                    return false;
                var trObj = $(this).parents("tr");
                var uid = $(trObj).attr("uid");
                var data = "key=203&uid=" + uid;
                $.get(URL_CONFIG.Post_URL, data, function (res) {
                    if (res == "-1") {
                        //alert("该销售人员还有名录，不能删除！");
                        PopTip.Show(PopTip.Type.Tips, "该销售人员还有名录，不能删除！", false);
                    } else if (res == "1") {
                        PopTip.Show(PopTip.Type.Succ, "删除成功", true);
                    } else {
                        //alert("删除失败");
                        PopTip.Show(PopTip.Type.Error, "删除失败", false);
                    }
                }, "text");
                return false;
            });
            //背景色
            $.Hover(".tablist tr");
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="nav">
        <h3>
            用户管理</h3>
    </div>
    <div class="divlist">
        <table>
            <tr>
                <td>
                    <asp:Button runat="server" ID="btnAddUser" Text="增加用户" OnClick="btnAddUser_Click"
                        CssClass="btn1" Visible="false" />
                </td>
                <td>
                    &nbsp;&nbsp;<span>当前已使用人数：</span>
                    <asp:Literal ID="liNum" runat="server"></asp:Literal>
                    <span>/</span>
                    <asp:Literal ID="liCount" runat="server"></asp:Literal>
                </td>
                <td>
                    <table id="tableSearch" style="margin-left: 50px;" runat="server">
                        <tr>
                            <td>
                                帐号：
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtUserName" CssClass="txt1" />
                            </td>
                            <td>
                                姓名：
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtTrueName" CssClass="txt1" />
                            </td>
                            <td>
                                <asp:Button ID="btnSearch" Text="检索" CssClass="btn1" OnClick="btnSearch_Click" runat="server" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <table cellpadding="1" cellspacing="1" border="0" class="tablist top10">
            <tr>
                <th>
                    帐号
                </th>
                <th>
                    姓名
                </th>
                <th>
                    职位
                </th>
                <th>
                    操作
                </th>
            </tr>
            <asp:Repeater runat="server" ID="rpList">
                <ItemTemplate>
                    <tr class="c" uid="<%#Eval("userid") %>">
                        <td>
                            <%#Eval("UserName") %>
                        </td>
                        <td>
                            <%#Eval("TrueName") %>
                        </td>
                        <td>
                            <%#Eval("RoleNames")%>
                        </td>
                        <td>
                            <a href="UserEdit.aspx?type=update&uid=<%#Eval("userid") %>">修改</a>&nbsp;&nbsp;<a
                                href="../MailConfig.aspx?uid=<%#Eval("userid")%>&backurl=User/UserList.aspx"> 邮件配置</a>&nbsp;&nbsp;<a
                                    href="javascript:void(0);" class="status" status="<%#Eval("Status")%>">
                                    <%#Eval("Status").ToString().Equals("0")?"启用":"禁用"%></a>&nbsp;&nbsp;<a href="javascript:void(0);"
                                        class="del">删除</a>
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
    </div>
    </form>

    <script id="pagetipsjs" src="/JS/PageTips.js?menuid=3" type="text/javascript"></script>
</body>
</html>
