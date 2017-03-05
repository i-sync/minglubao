<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Share.aspx.cs" Inherits="Web.Enterprise.Item.Share" %>


<%@ Register Src="~/Enterprise/Controls/Property.ascx" TagName="Property" TagPrefix="mlb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>共享池</title>
    <link href="/Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="/Styles/msgbox.css" rel="stylesheet" type="text/css" />
    <script src="/JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="/JS/jquery.cookie.js" type="text/javascript"></script>
    <script src="/JS/hover.js" type="text/javascript"></script>
    <script src="/JS/common.js" type="text/javascript"></script>    
    <script src="/JS/poptip.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
        var Operate_CONFIG = {
            Post_URL: "/enterprise/handler/item.ashx", //------提交地址
            selector: ":checked[name='cbClient']", //---选择器
            GetIDs: function () {//获取编号
                if (this.selector.length > 0) {//使用选择器
                    var ids = new Array();
                    $(this.selector).filter(":checked").each(function () {
                        ids.push($(this).val());
                    });
                    if (ids.length == 0) {
                        PopTip.Show(PopTip.Type.Error, "请选择名录信息", false);
                        return null;
                    }
                    return ids.join(',');
                }
                else {
                    PopTip.Show(PopTip.Type.Error, "配置错误，未能完成操作", false);
                    return null;
                }
            }
        };

        $(function () {
            //设置列表宽度（使不换行）
            var width = 0;
            $(".cilist_title li").each(function () {
                width = width + $(this).width() + 2;
            });
            var cWidth = $(".cilist_title").width();
            $("body").width(cWidth > width ? cWidth : width);
            $(".cilist_list .item").hoverForIE6();

            //全选
            $.CheckAllOperate("#cbAll", ".cilist_list :checkbox[name='cbClient']");

            //总监删除共享中选中的名录
            $("#btnDel").click(function () {
                var ids = Operate_CONFIG.GetIDs();
                if (ids && confirm("确认要删除吗？")) {
                    $.ajax({
                        type: "POST",
                        url: URLPlusRandom(Operate_CONFIG.Post_URL),
                        data: { key: "delete", ids: ids },
                        success: function (data) {
                            if (data == "1") {
                                PopTip.Show(PopTip.Type.Succ, "删除成功", true);
                            }
                            else {
                                PopTip.Show(PopTip.Type.Error, "删除失败", false);
                            }
                        },
                        dataType: "text"
                    });
                }
            });


            //总监删除所有共享的名录
            $("#btnDelAll").click(function () {
                if (confirm("确认要全部删除吗？")) {
                    $.ajax({
                        type: "POST",
                        url: URLPlusRandom(Operate_CONFIG.Post_URL),
                        data: { key: "deleteall"},
                        success: function (data) {
                            if (data == "1") {
                                PopTip.Show(PopTip.Type.Succ, "删除成功", true);
                            }
                            else {
                                PopTip.Show(PopTip.Type.Error, "删除失败", false);
                            }
                        },
                        dataType: "text"
                    });
                }
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="nav">
        <h3>
        共享池</h3>
    </div>
    
    <div class="divlist">
        <table>
            <tr>
                <td>
                    名录名称：
                </td>
                <td>
                    <asp:TextBox runat="server" CssClass="txt1 w300" ID="txtName" />
                </td>
                <td>
                    <mlb:Property ID="Property1" runat="server" />
                </td>
                <td>
                    <asp:Button runat="server" ID="btnSearch" CssClass="btn1" Text="检索" OnClick="btnSearch_Click" />
                </td>
            </tr>
        </table>
    </div>

    <div style="margin:5px 20px; padding:5px 10px;">
        <input type="button" id="btnDel" value ="删除" class="btn1" />
        &nbsp;&nbsp;
        <input type="button" id="btnDelAll" value ="全部删除" class="btn1" />
    </div>
    <div class="cilist">
        <div class="cilist_title">
            <ul>
                <li class="num">
                    <input type="checkbox" name="cbAll" id="cbAll" value="-1" />
                </li>
                <li class="operate">
                    查看
                </li>
                <li class="name">
                    名录名称
                </li>
                <li class="time">
                    共享日期
                </li>
                <%if (TradeFlag)
                  { %><li class="property">
                      行业
                  </li>
                <%} if (AreaFlag)
                  { %><li class="property">
                      地区
                  </li>
                <%} if (SourceFlag)
                  { %>
                <li class="property">
                    来源
                </li>
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
                        <div class="operate">
                            <a href="info.aspx?ciid=<%#Eval("ClientInfoID") %>">查看</a>
                        </div>
                        <div class="name">
                            <a href="info.aspx?ciid=<%#Eval("ClientInfoID") %>" title="备注：<%#Eval("Remark") %>">
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
                        <i class="clear"></i>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>       
    <MLB:AspNetPager runat="server" ID="pageList1" CssClass="paginator" CurrentPageButtonClass="cpb"
        PageIndexBoxClass="textbox_page1" SubmitButtonClass="btn_go" SubmitButtonText=""
        TextBeforePageIndexBox="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;第&nbsp;"
        AlwaysShow="true" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageSize="1"
        PrevPageText="上一页" ShowCustomInfoSection="Left" ShowInputBox="Never" CustomInfoTextAlign="Center"
        LayoutType="Table" ShowPageIndex="false" ShowBoxThreshold="1" UrlPaging="true" />    
    </form>
</body>
</html>