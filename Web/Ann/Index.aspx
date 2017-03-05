<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Web.Ann.Index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>名录宝公告信息</title>
    <link href="../Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/web.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="wrap">
        <mlb:Header runat="server" ID="header" />
        <div class="webkuang">
            <div class="app">
                名录宝公告信息</div>
            <div class="annindexlist">
                <ul>
                    <asp:Repeater ID="rpList" runat="server">
                        <ItemTemplate>
                            <li><a href="info.aspx?id=<%#Eval("AnnouncementID") %>" class="info">
                                <%#Eval("AnnTitle") %></a>&nbsp;&nbsp;[<%#Eval("AddDate","{0:yyyy-MM-dd HH:mm}") %>]
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
                <mlb:AspNetPager runat="server" ID="pageList1" CssClass="paginator" CurrentPageButtonClass="cpb"
                    PageIndexBoxClass="textbox_page1" SubmitButtonClass="btn_go" SubmitButtonText=""
                    TextBeforePageIndexBox="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;第&nbsp;"
                    AlwaysShow="true" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageSize="1"
                    PrevPageText="上一页" ShowCustomInfoSection="Left" ShowInputBox="Never" CustomInfoTextAlign="Center"
                    LayoutType="Table" ShowPageIndex="false" ShowBoxThreshold="1" UrlPaging="true" />
            </div>
            <div class="webkuangfoot">
            </div>
        </div>
    </div>
    <mlb:Bottom runat="server" ID="bottom" />
    </form>
</body>
</html>
