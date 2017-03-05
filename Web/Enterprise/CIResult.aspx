<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CIResult.aspx.cs" Inherits="Web.Enterprise.CIResult" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>查询结果</title>
    <script src="../JS/jquery-1.6.4.js" type="text/javascript"></script>
    <link href="../Styles/Site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table class="tablist" cellpadding="1" cellspacing="1">
    <tr><th>&nbsp;</th><th>名录名称</th><th>入库时间</th><th>行业</th><th>地区</th><th>来源</th><th>状态</th></tr>
    <asp:Repeater runat="server" ID="rpList">
    <ItemTemplate>
    <tr  class="c">
    <td><input type="checkbox" name="cbClient" /></td>
    <td><a href="ClientInfoTrack.aspx?clientinfoid=<%#Eval("ClientInfoID") %>" title="备注：<%#Eval("Remark") %>"><%#Eval("ClientName") %></a></td>
    <td><%#Eval("AddDate") %></td>
    <td><%#Eval("TradeName") %></td>
    <td><%#Eval("AreaName") %></td>
    <td><%#Eval("SourceName") %></td>
    <td><%#GetStatusName(Eval("Status"))%></td>
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
</body>
</html>
