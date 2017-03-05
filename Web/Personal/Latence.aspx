<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Latence.aspx.cs" Inherits="Web.Personal.Latence" %>

<%@ Register src="Controls/Property.ascx" tagname="Property" tagprefix="mlb" %>
<%@ Register src="Controls/Operate.ascx" tagname="Operate" tagprefix="mlb" %>
<!DOCTYPE html PUBLIC "-//W3C//Dspan XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>潜在客户</title>
    <link href="../Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/core.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/msgbox.css" rel="stylesheet" type="text/css" />
    <script src="../JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="../JS/common.js" type="text/javascript"></script>
    <script src="../JS/popup_layer.js" type="text/javascript"></script>
    <script type="text/javascript" src="../JS/poptip.js"></script>
    <script src="../JS/jquery.cookie.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {

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


            //设置列表宽度（使列头不换行）
            var width = 0;
            $(".cilist_title li").each(function () {
                width = width + $(this).width() + 2;
            });
            var cWidth = $(".cilist_title").width();
            $("body").width(cWidth > width ? cWidth : width);

            $.CheckAllOperate("#cbAll", ":checkbox[name='cbClient']");
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="nav">
            <h3>潜在客户</h3>
        </div>
        <div class="divlist">
            <table>
                <tr>
                    <td>
                        名录名称：
                    </td>
                    <td>
                        <asp:TextBox runat="server" CssClass="txt1" ID="txtName" />
                    </td>
                    <td>
                        <asp:Button runat="server" ID="btnSearch" Text="检索" CssClass="btn1" OnClick="btnSearch_Click" />
                    </td>
                    <td style="width:195px;">
                        <a href="Javascript:void(0);" id="Advanced">高级</a>
                    </td>
                </tr>
                <tr id="trProperty" style="display:none;">
                    <td colspan="6">
                        <mlb:Property ID="Property1" runat="server" />
                    </td>
                </tr>
            </table>
            <mlb:Operate ID="Operate1" runat="server" selector=".cilist_list :checked[name='cbClient']" />
        </div>
        
        <div class="cilist">
            <div class="cilist_title">
                <ul>
                    <li class="num">
                        <input type="checkbox" name="cbAll" id="cbAll" value="-1" />
                    </li>
                    <li class="name">
                        名录名称
                    </li>
                    <li class="time">
                        更新时间
                    </li>
                    <%if (TradeFlag)
                      { %><li class="property">
                        行业
                    </li>
                    <%} if(AreaFlag){ %><li class="property">
                        地区
                    </li><%} if (SourceFlag)
                      { %>
                    <li class="property">
                        来源
                    </li><%} %>
                    <li class="operate">
                        操作
                    </li>
                </ul>
            </div>
            <i class="clear"></i>
            <div class="cilist_list">
                 <asp:Repeater runat="server" ID="rpList">
                    <ItemTemplate>
                        <div class="item ">
                            <div class="num">
                                <input type="checkbox" name="cbClient" value="<%#Eval("ClientInfoID") %>" />
                            </div>
                            <div title="备注：<%#Eval("Remark") %>" class="name">
                                <a href="ClientInfoTrack.aspx?id=<%#Eval("ClientInfoID") %>">
                                    <%#Eval("ClientName") %></a>
                            </div>
                            <div class="time">
                                <%#Eval("UpdateDate", "{0:yyyy-MM-dd HH:mm}")%>
                            </div>
                            <%if (TradeFlag)
                                { %><div class="property">
                            <%#Eval("TradeName") %>
                            </div><%}if(AreaFlag){ %>
                            <div class="property">
                                <%#Eval("AreaName") %>
                            </div><%} if (SourceFlag)
                              { %>
                            <div class="property">
                                <%#Eval("SourceName") %>
                            </div><%} %>
                            <div class="operate">
                                <a href="ClientInfoTrack.aspx?id=<%#Eval("ClientInfoID") %>">跟踪</a>
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
    <div class="exectime">
        执行时间：<asp:Label ID ="lblExecTime" runat="server"></asp:Label>秒
    </div>
</body>
</html>
