<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="Web.Enterprise.Leader.Search" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>模糊查询</title>
    <link href="/Styles/Site.css" rel="stylesheet" type="text/css" />
    <script src="/JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="/JS/hover.js" type="text/javascript"></script>
    <script src="/JS/jquery.cookie.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $("form").submit(function () {
                var keyword = $.trim($("#txtKeyword").val());
                var url = "search.aspx?keyword=" + escape(keyword);
                location = url;
                return false;
            });
            //-------------关闭 展开统计--------------
            $("#imgUpDown").click(function () {
                var type = "up";
                if ($(this).attr("src").indexOf("up.jpg") > 0) {
                    $(this).attr("src", $(this).attr("src").replace("up", "down"));
                    type = "down";
                }
                else {
                    $(this).attr("src", $(this).attr("src").replace("down", "up"));
                    type = "up";
                }
                $(".Statistics").toggle();
                $.cookie("updown", type);
            });
            var updown = $.cookie("updown");
            if (updown != null && updown == "down") {
                $("#imgUpDown").triggerHandler("click");
            }

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
                    名录名称：
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtKeyword" CssClass="txt1 w300" />
                </td>
                <td>
                    <input type="submit" id="btnSearch" name="btnSearch" class="btn1" value="检索" />
                </td>
            </tr>
        </table>
    </div>
    <div class="Statistics" style="display:none;">
        <i class="line"></i>
        <div class="nav">
            <h3>
                统计</h3>
        </div>
        <div class="divlist" >
            <table class="tablist" cellpadding="1" cellspacing="1" style="width: 500px; margin: auto 0 0 10px;">
                <tr>
                    <th>
                        &nbsp;
                    </th>
                    <th style="width: 100px;">
                        数量
                    </th>
                    <th style="width: 100px;">
                        百分比
                    </th>
                </tr>
                <asp:Repeater runat="server" ID="rpStatistics">
                    <ItemTemplate>
                        <tr class="c">
                            <td>
                                <%#Eval("Name") %>
                            </td>
                            <td>
                                <%#Eval("Amount")%>
                            </td>
                            <td>
                                <%#Eval("Percentage")%>%
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
    </div>
    <div class="updown">
        <img src="/images/down.jpg" id="imgUpDown" alt="关闭统计" title="关闭统计" /></div>
    <div class="cilist">
        <div class="cilist_title">
            <ul>
                <li class="num">序号</li>
                <li class="name">名录名称</li>
                <li class="time">入库时间</li>
                <li class="time">更新时间</li>
                <li class="status">状态</li>
                <li class="location">位置</li>
            </ul>
        </div>
        <i class="clear"></i>
        <div class="cilist_list">
            <asp:Repeater runat="server" ID="rpList">
                <ItemTemplate>
                    <div class="item">
                        <div class="num">
                            <%#Eval("nid") %></div>
                        <div class="name">
                            <a href="../clientinfo/info.aspx?ciid=<%#Eval("ClientInfoID") %>" title="<%#Eval("ClientName") %>">
                                <%#MLMGC.COMP.PageHelper.HighlightKeyword(Eval("ClientName").ToString(),txtKeyword.Text) %></a></div>
                        <div class="time">
                            <%#Eval("AddDate","{0:yyyy-MM-dd HH:mm}") %>
                        </div>
                        <div class="time">
                            <%#Eval("UpdateStatusDate", "{0:yyyy-MM-dd HH:mm}")%></div>
                        <div class="status">
                            <%#MLMGC.COMP.EnumUtil.GetName<MLMGC.DataEntity.Enterprise.EnumClientStatus>(Eval("Status").ToString())%></div>
                        <div class="location">
                            <%#Eval("Location") %></div>
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
    <script id="pagetipsjs" src="/JS/PageTips.js?menuid=22" type="text/javascript"></script>
</body>
</html>
