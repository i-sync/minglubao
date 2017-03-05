<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShareList.aspx.cs" Inherits="Web.Enterprise.Leader.ShareList" %>

<%@ Register Src="../Controls/Property.ascx" TagName="Property" TagPrefix="mlb" %>
<%@ Register Src="../Controls/LSOperate.ascx" TagName="LSOperate" TagPrefix="mlb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>管理共享池</title>
    <link href="/Styles/Site.css" rel="stylesheet" type="text/css" />
    <script src="/JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="/JS/hover.js" type="text/javascript"></script>
    <script src="../../JS/jquery.cookie.js" type="text/javascript"></script>
    <script src="../../JS/common.js" type="text/javascript"></script>
    <script src="../../JS/poptip.js" type="text/javascript"></script>
    <link href="../../Styles/msgbox.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            //设置列表宽度（使列头不换行）
            var width = 0;
            $(".cilist_title li").each(function () {
                width = width + $(this).width() + 2;
            });
            var cWidth = $(".cilist_title").width();
            $("body").width(cWidth > width ? cWidth : width);
            //--全选
            $.CheckAllOperate("#cbAll", ".cilist_list :checkbox[name='cbClient']");

            $(".cilist_list .item").hoverForIE6();
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="nav">
        <h3>
            管理共享池</h3>
    </div>
    <div class="divlist">
        <table>
            <tr>
                <td>
                    名录名称：
                </td>
                <td>
                    <asp:TextBox runat="server" class="txt1 w300" ID="txtName" />
                </td>
                <td>
                    <mlb:Property ID="Property1" runat="server" />
                </td>
                <td>
                    <asp:Button runat="server" ID="btnSearch" class="btn1" Text="检索" OnClick="btnSearch_Click" />
                </td>
            </tr>
        </table>
    </div>
    <div class=" mar5 ml50">
        <mlb:LSOperate runat="server" ID="LSOperate1" selector=".cilist_list :checkbox[name='cbClient']"
            HideShare="true" />
    </div>
    <div class="cilist">
        <div class="cilist_title">
            <ul>
                <li class="num">
                    <input type="checkbox" name="cbAll" id="cbAll" value="-1" />
                </li>
                <li class="name">名录名称 </li>
                <li class="time">共享日期 </li>
                <%if (TradeFlag)
                  { %><li class="property">行业 </li>
                <%} if (AreaFlag)
                  { %><li class="property">地区 </li>
                <%} if (SourceFlag)
                  { %>
                <li class="property">来源 </li>
                <%} %>
                <li class="operate">操作 </li>
            </ul>
        </div>
        <i class="clear"></i>
        <div class="cilist_list">
            <asp:Repeater runat="server" ID="rpList">
                <ItemTemplate>
                    <div class="item">
                        <div class="num">
                            <input type="checkbox" name="cbClient" value="<%#Eval("ClientInfoID") %>" />
                        </div>
                        <div class="name">
                            <a href="../clientinfo/info.aspx?ciid=<%#Eval("ClientInfoID") %>" title="备注：<%#Eval("Remark") %>">
                                <%#Eval("ClientName") %></a>
                        </div>
                        <div class="time">
                            <%#Eval("UpdateStatusDate", "{0:yyyy-MM-dd HH:mm}")%>
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
                        <div class="operate">
                            <a href="../clientinfo/info.aspx?ciid=<%#Eval("ClientInfoID") %>">查看</a>
                        </div>
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
    <script id="pagetipsjs" src="/JS/PageTips.js?menuid=38" type="text/javascript"></script>
</body>
</html>
