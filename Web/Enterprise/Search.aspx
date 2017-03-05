<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="Web.Enterprise.Search" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>模糊查询</title>
    <link href="../Styles/Site.css" rel="stylesheet" type="text/css" />
    <script src="../JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="../JS/hover.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $("form").submit(function () {
                var keyword = $.trim($("#txtKeyword").val());
                var url = "Search.aspx?keyword=" + escape(keyword) + "&t=" + Math.random();
                location = url;
                return false;
            });
            var width = 0;
            $(".cilist_title li").each(function () {
                width = width + $(this).width() + 2;
            });
            var cWidth = $(".cilist_title").width();
            $("body").width(cWidth > width ? cWidth : width);
            $(".cilist_list .item").hoverForIE6();
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="divlist">
        <table>
            <tr>
                <td>
                    关键字：
                </td>
                <td>
                    <asp:TextBox runat="server" CssClass="txt1" ID="txtKeyword" />
                </td>
                <td>
                    <input type="submit" id="btnSearch" class="btn1" name="btnSearch" value="检索" />
                </td>
            </tr>
        </table>
    </div>
    <div class="cilist">
        <div class="cilist_title">
            <ul>
                <li class="num">序号</li>
                <li class="name">名录名称 </li>
                <li class="linkman">联系人 </li>
                <li class="location">位置</li>
                <li class="status">状态 </li>
                <%if (TradeFlag)
                  { %><li class="property">行业 </li>
                <%} if (AreaFlag)
                  { %>
                <li class="property">地区 </li>
                <%} if (SourceFlag)
                  { %>
                <li class="property">来源 </li>
                <%} %>
            </ul>
        </div>
        <i class="clear"></i>
        <div class="cilist_list">
            <asp:Repeater runat="server" ID="rpList">
                <ItemTemplate>
                    <div class="item">
                        <div class="num">
                            <%#Eval("nid") %>
                        </div>
                        <div class="name">
                            <a href="ClientInfo/Info.aspx?ciid=<%#Eval("ClientInfoID") %>" title="备注：<%#Eval("Remark") %>;地址：<%#Eval("Address") %>">
                            <%#MLMGC.COMP.PageHelper.HighlightKeyword(Eval("ClientName").ToString(),txtKeyword.Text) %></a>
                        </div>
                        <div class="linkman">
                            <%#Eval("LinkMan")%></div>
                        <div class="location">
                            <%#Eval("Location") %>
                        </div>
                        <div class="status">
                            <%#GetStatusName(Eval("Status"))%>
                        </div>
                        <%if (TradeFlag)
                          { %><div class="property">
                              <%#Eval("TradeName") %>
                          </div>
                        <%} if (AreaFlag)
                          { %>
                        <div class="property">
                            <%#Eval("AreaName") %>
                        </div>
                        <%} if (SourceFlag)
                          { %>
                        <div class="property">
                            <%#Eval("SourceName") %>
                        </div>
                        <%} %>
                        <i class="clear"></i>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
    <mlb:AspNetPager runat="server" ID="pageList1" CssClass="paginator" CurrentPageButtonClass="cpb"
        PageIndexBoxClass="textbox_page1" SubmitButtonClass="btn_go" SubmitButtonText=""
        TextBeforePageIndexBox="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;第&nbsp;"
        AlwaysShow="true" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageSize="1"
        PrevPageText="上一页" ShowCustomInfoSection="Left" ShowInputBox="Never" CustomInfoTextAlign="Center"
        LayoutType="Table" ShowPageIndex="false" ShowBoxThreshold="1" UrlPaging="true" />
    </form>
</body>
</html>
