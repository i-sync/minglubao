<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AnnLeader.aspx.cs" Inherits="Web.Enterprise.Announcement.AnnLeader" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>上级公告</title>
    <script src="/JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="/JS/jquery.cookie.js" type="text/javascript"></script>
    <script src="/JS/common.js" type="text/javascript"></script>
    <link href="/Styles/Site.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            //为表格添加滑动样式
            $.Hover(".tablist tr");
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="nav">
        <h3>
            上级公告</h3>
    </div>
    <div class="divlist">
        <table>
            <tr>
                <td>
                    公告标题：
                </td>
                <td>
                    <asp:Label ID="lblTitle" Text="" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    发布时间：
                </td>
                <td>
                    <asp:Label ID="lblAddDate" Text="" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    公告内容：
                </td>
                <td>
                    <asp:Label ID="lblContent" Text="" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <table cellpadding="1" cellspacing="1" class="tablist">
            <tr>
                <th>
                    序号
                </th>
                <th>
                    标题
                </th>
                <th>
                    内容
                </th>
                <th>
                    添加时间
                </th>
            </tr>
            <asp:Repeater ID="rpList" runat="server">
                <ItemTemplate>
                    <tr class="c">
                        <td>
                            <%#Eval("nid") %>
                        </td>
                        <td>
                            <%#Eval("AnnTitle") %>
                        </td>
                        <td>
                            <%#Eval("AnnContent") %>
                        </td>
                        <td>
                            <%#Eval("AddDate","{0:yyyy-MM-dd HH:mm}")%>
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
    <script id="pagetipsjs" src="/JS/PageTips.js?menuid=42" type="text/javascript"></script>
</body>
</html>
