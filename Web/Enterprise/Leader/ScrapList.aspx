<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ScrapList.aspx.cs" Inherits="Web.Enterprise.Leader.ScrapList" %>

<%@ Register Src="../Controls/Property.ascx" TagName="Property" TagPrefix="mlb" %>
<%@ Register Src="../Controls/LSOperate.ascx" TagName="LSOperate" TagPrefix="mlb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>报废名录</title>
    <link href="/Styles/Site.css" rel="stylesheet" type="text/css" />
    <script src="/JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="/JS/hover.js" type="text/javascript"></script>
    <script src="../../JS/common.js" type="text/javascript"></script>
    <script src="../../JS/jquery.cookie.js" type="text/javascript"></script>
    <script src="../../JS/poptip.js" type="text/javascript"></script>
    <link href="../../Styles/msgbox.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        var URL_CONFIG = {
            ResultUrl: "ScrapResult.aspx"
        };
        $(function () {

            //设置列表宽度（使列头不换行）
            var width = 0;
            $(".cilist_title li").each(function () {
                width = width + $(this).width() + 2;
            });
            var cWidth = $(".cilist_title").width();
            $("body").width(cWidth > width ? cWidth : width);

            //---------------高级---------------------
            //0:默认隐藏Property    1：显示Property
            var flag = $.cookie("flag");
            if (flag != null && flag == 1) {
                $("#trProperty").show();
                $("#Advanced").html("隐藏高级");
            }
            else {
                $("#trProperty").hide();
                $("#Advanced").html("高级");
            }
            //点击高级显示名录属性
            $("#Advanced").click(function () {
                var tr = $("#trProperty");
                if (tr.is(":visible")) {
                    tr.hide();
                    $("#Advanced").html("高级");
                    $.cookie("flag", 0, null);
                }
                else {
                    tr.show();
                    $("#Advanced").html("隐藏高级");
                    $.cookie("flag", 1, null);
                }
            });
            //------------------------------------------

            //点击检索
            $("#btnSearch").click(function () {
                var objid = $("#ddlObject").val();
                if (objid == null) { objid = -1; }
                var data = "objid=" + objid + "&scrapid=" + $("#ddlScrap").val() + "&keyword=" + escape($.trim($("#txtName").val())) + Property.GetQuery();
                window.location.replace("ScrapList.aspx?" + data);
            });
            //--加载列表
            $.CheckAllOperate("#cbAll", ".cilist_list :checkbox[name='cbClient']");
            
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
    <div class="nav">
        <h3>
            报废名录</h3>
    </div>
    <div class="divlist">
        <table>
            <tr>
                <td>
                    查询对象：
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlObject" CssClass="ddl1 w160" />
                </td>
                <td>
                    名称：
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtName" CssClass="txt1 w300" />
                </td>
                <td>
                    理由：
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlScrap" CssClass="ddl1 w160" />
                </td>
                <td>
                    <input type="button" id="btnSearch" value="检索" class="btn1" />
                </td>
                <td>
                    <a href="Javascript:void(0);" id="Advanced">高级</a>
                </td>
            </tr>
            <tr id="trProperty" style="display:none;">
                <td colspan="8">
                    <mlb:Property ID="Property1" runat="server" />
                </td>
            </tr>
        </table>
    </div>
    <div class="Statistics" style="display:none;">
        <div class="nav">
            <h3>
                统计结果</h3>
        </div>
        <div class="divlist">
            <!--统计结果 开始-->
            <table class="tablist" cellpadding="1" cellspacing="1" style="width: 400px;">
                <tr>
                    <th>
                        &nbsp;
                    </th>
                    <th>
                        数量
                    </th>
                    <th>
                        百分比
                    </th>
                </tr>
                <asp:Repeater runat="server" ID="rpStatistics">
                    <ItemTemplate>
                        <tr class="c">
                            <td>
                                <%#Eval("ScrapName")%>
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
            <!--统计结果 结束-->
        </div>
    </div>
    <div class="updown">
        <img src="/images/down.jpg" id="imgUpDown" alt="展开统计" title="展开统计" /></div>
    <!--结果列表 开始-->
    <div class=" mar5 ml50">
        <mlb:LSOperate runat="server" ID="LSOperate1" HideShareAll="false" selector=".cilist_list :checkbox[name='cbClient']" />
    </div>
    <div id="divResult">
        <div id="list" class="cilist">
            <div class="cilist_title">
                <ul>
                    <li class="num">
                        <input type="checkbox" id="cbAll" name="cbAll" value="-1" />
                    </li>
                    <li class="name">名录名称 </li>
                    <li class="reason">理由</li>
                    <li class="time">操作时间 </li>
                    <li class="person">位置 </li>
                    <%if (TradeFlag)
                      { %><li class="property">行业 </li>
                    <%} if (SourceFlag)
                      { %><li class="property">来源 </li>
                    <%} if (AreaFlag)
                      { %><li class="property">地区 </li>
                    <%} %>
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
                                <a href="../clientinfo/info.aspx?ciid=<%#Eval("ClientInfoID") %>" title="<%#Eval("ClientName") %>">
                                    <%#Eval("ClientName") %></a>
                            </div>
                            <div class="reason">
                                <%#Eval("ScrapName")%></div>
                            <div class="time">
                                <%#Eval("UpdateStatusDate", "{0:yyyy-MM-dd HH:mm}")%>
                            </div>
                            <div class="person">
                                <%#Eval("TeamName")%>
                            </div>
                            <%if (TradeFlag)
                              { %><div class="property">
                                  <%#Eval("TradeName") %>
                              </div>
                            <%} if (SourceFlag)
                              { %><div class="property">
                                  <%#Eval("SourceName") %>
                              </div>
                            <%} if (AreaFlag)
                              { %><div class="property">
                                  <%#Eval("AreaName") %>
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
            PrevPageText="上一页" ShowCustomInfoSection="Left" CustomInfoTextAlign="Center"
            LayoutType="Table" ShowPageIndex="false" ShowBoxThreshold="1" UrlPaging="true" />
    </div>
    <!--结果列表 结束-->
    </form>
    <script id="pagetipsjs" src="/JS/PageTips.js?menuid=28" type="text/javascript"></script>
</body>
</html>
